using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using DegreeConverter;
using NSubstitute;

namespace DegreeConverterTest
{
    [TestClass]
    public class DegreeConverterTest
    {
        [TestMethod]
        public void ToFarenheit_ZeroToCelcius_Returns32()
        {
            //arrange
            var converter = new DegreeConverterModel();

            //act
            double result = converter.ToFarenheit(Celcius: 0);

            //assert
            result.Should().Equals(32);

        }

        [TestMethod]
        public void ToCelcius_1Farenheit_Returns0()
        {
            //arrange
            var converter = new DegreeConverterModel();

            //act 
            double result = converter.ToCelcius(Farenheit: 1);

            //assert
            result.Should().Equals(0);
        }

        [TestMethod]
        public void ToFarenheit_ZeroToCelcius_Returns32_BySubstitute()
        {
            //arrange
            var converter = Substitute.For<IDegreeConverterModel>();

            //act
            double result = converter.ToFarenheit(Celcius: 0);            

            //assert
            result.Should().Equals(32);
        }

        [TestMethod]
        public void ToCelcius_1Farenheit_Returns0_BySubstitute()
        {
            //arrange
            var converter = Substitute.For<IDegreeConverterModel>();

            //act 
            double result = converter.ToCelcius(Farenheit: 1);

            //assert
            result.Should().Equals(0);
        }

    }
}
