using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstituteExcercise;
using NSubstitute;
using System.Collections.Generic;

namespace NSubstituteUnitTest
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void Will_Return_Customer_FullName()
        {
            ICustomerRepository customerRepository = Substitute.For<ICustomerRepository>();
            customerRepository.GetCustomerById(1).Returns(new Customer() { FirstName = "Senthilmurugan", LastName = "Gurusamy" });

            CustomerService customerService = new CustomerService(customerRepository);

            string fullName = customerService.GetFullName(1);

            Assert.AreEqual("Senthilmurugan Gurusamy", fullName);
        }     
    }
}
