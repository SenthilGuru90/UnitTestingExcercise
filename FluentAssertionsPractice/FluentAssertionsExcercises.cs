using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using FluentAssertions.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertionsPractice
{
    [TestClass]
    public class FluentAssertionsExcercises
    {
        //Using general options available in fluent assertions


        //using startwith, endwith and havelength   
        [TestMethod]
        public void TestMethod1()
        {
            string strName = "Senthilmurugan Gurusamy";

            strName.Should().StartWith("Sen").And.EndWith("samy").And.Contain("murugan").And.HaveLength(23);
        }

        //assertion scope for batching multiple assertions into single scope so it show in one exception with all failure
        [TestMethod]
        public void TestMethod2()
        {
            using (new AssertionScope())
            {
                5.Should().Be(10);
                "Actual".Should().Be("Expected");
            }
        }

        //trying basic assertions

        //to assert two objects are equal
        [TestMethod]
        public void TestMethod3()
        {
            string object1 = "Senthil";
            string object2 = "murugan";
            string object3 = "Senthil";
            object1.Should().Be(object3, "because they have the same values");
            object1.Should().NotBe(object2, "because they don't have the same values");
        }

        //making sure it is using same memory
        [TestMethod]
        public void TestMethod4()
        {
            string object1 = "Senthil";
            string object2 = object1;
            string object3 = "murugan";
            object1.Should().BeSameAs(object2);
            object1.Should().NotBeSameAs(object3);
        }

        //using BeAssignableTo,NotBeAssignableTo and match
        [TestMethod]
        public void TestMethod5()
        {
            var ex = new ArgumentException();
            ex.Should().BeAssignableTo<Exception>("because it is an exception");
            ex.Should().NotBeAssignableTo<DateTime>("because it is an exception");

            var dummy = new Object();
            dummy.Should().Match(d => (d.ToString() == "System.Object"));
            dummy.Should().Match<string>(d => (d == "System.Object"));
            dummy.Should().Match((string d) => (d == "System.Object"));
        }

        //Nullable types
        [TestMethod]
        public void TestMethod6()
        {
            int? theInt = 3;
            theInt.Should().HaveValue();
            theInt.Should().NotBeNull();
        }

        //Booleans
        [TestMethod]
        public void TestMethod7()
        {
            bool theBoolean = false;
            theBoolean.Should().BeFalse("it's set to false");

            theBoolean = true;
            theBoolean.Should().BeTrue();
        }

        //strings
        [TestMethod]
        public void TestMethod8()
        {
            string strName = "Senthilmurugan Gurusamy";
            strName.Should().Be("Senthilmurugan Gurusamy");
            strName.Should().NotBe("Kunal");
            strName.Should().BeEquivalentTo("Senthilmurugan Gurusamy");
            strName.Should().NotBeEquivalentTo("Kunal");
            strName.Should().BeOneOf("Senthilmurugan Gurusamy", "Kunal");
            strName.Should().Contain("ru", MoreThan.Thrice());
            strName.Should().ContainAll("Sen", "muru", "guru", "amy");
        }

        //numbers
        [TestMethod]
        public void TestMethod9()
        {
            int iNumber = 5;
            iNumber.Should().BeGreaterOrEqualTo(5);
            iNumber.Should().BeLessOrEqualTo(6);
            iNumber.Should().BePositive();
            iNumber.Should().BeInRange(1, 9);
            iNumber.Should().Match(x => x % 2 == 1);
            iNumber.Should().BeOneOf(5, 6, 8);
        }

        //DateTime
        [TestMethod]
        public void TestMethod10()
        {
            DateTime dateTime = 4.April(1990).AsLocal();
            dateTime.Should().BeAfter(1.March(1990));
            dateTime.Should().BeBefore(2.May(1990));
            dateTime.Should().BeOnOrAfter(1.March(1990));
            dateTime.Should().BeOnOrBefore(1.May(1990));
            dateTime.Should().BeSameDateAs(1.April(1990));
            dateTime.Should().BeIn(DateTimeKind.Local);

            dateTime.Should().HaveDay(4);
            dateTime.Should().HaveMonth(4);
            dateTime.Should().HaveYear(1990);
        }

        //collection
        [TestMethod]
        public void TestMethod11()
        {
            ICollection collection = new[] { 1, 2, 3, 4, 5 };

            collection.Should().NotBeEmpty().And.HaveCount(5);
            collection.Should().HaveCount(c => c > 3).And.OnlyHaveUniqueItems();

            collection.Should().HaveCountGreaterThan(3);
            collection.Should().HaveCountGreaterOrEqualTo(4);
            collection.Should().HaveCountLessOrEqualTo(4);
            collection.Should().HaveCountLessThan(5);
            collection.Should().NotHaveCount(3);
            collection.Should().HaveSameCount(new[] { 6, 2, 0, 5 });
            collection.Should().NotHaveSameCount(new[] { 6, 2, 0 });

            collection.Should().BeInAscendingOrder();
            collection.Should().BeInDescendingOrder();
            collection.Should().NotBeInAscendingOrder();
            collection.Should().NotBeInDescendingOrder();

        }

        //Collections -> apply assertions on each item
        [TestMethod]
        public void TestMethod12()
        {
            var collection = new[]
            {
                new { Id = 1, Name = "Senthilmurugan", Attributes = new string[] {}},
                new { Id = 2, Name = "Ramarajan", Attributes = new string[] {}}
            };

            collection.Should().SatisfyRespectively(
                first =>
                {
                    first.Id.Should().Be(1);
                    first.Name.Should().StartWith("S");
                    first.Attributes.Should().NotBeNull();
                },
                second =>
                {
                    second.Id.Should().Be(2);
                    second.Name.Should().StartWith("R");
                    second.Attributes.Should().NotBeNull();
                }
                );
        }


        //Generics Dictionary
        [TestMethod]
        public void TestMethod13()
        {
            var dictionary1 = new Dictionary<int, string>
                            {
                                { 1, "One" },
                                { 2, "Two" }
                            };

            var dictionary2 = new Dictionary<int, string>
                                {
                                    { 1, "One" },
                                    { 2, "Two" }
                                };

            var dictionary3 = new Dictionary<int, string>
                                {
                                    { 3, "Three" },
                                };

            dictionary1.Should().Equal(dictionary2);
            dictionary1.Should().NotEqual(dictionary3);
        }

        //Key value pair
        [TestMethod]
        public void TestMethod14()
        {
            var dictionary = new Dictionary<int, string>
                            {
                                { 1, "One" },
                                { 2, "Two" }
                            };

            KeyValuePair<int, string> item1 = new KeyValuePair<int, string>(1, "One");
            KeyValuePair<int, string> item2 = new KeyValuePair<int, string>(2, "Two");

            dictionary.Should().Contain(item1);
            dictionary.Should().Contain(item1, item2);
        }


        //Guid
        [TestMethod]
        public void TestMethod15()
        {
            Guid theGuid = Guid.NewGuid();
            Guid sameGuid = theGuid;
            Guid otherGuid = Guid.NewGuid();

            theGuid.Should().Be(sameGuid);
            theGuid.Should().NotBe(otherGuid);
            theGuid.Should().NotBeEmpty();
        }        
    }
}
