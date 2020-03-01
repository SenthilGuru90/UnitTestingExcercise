using System;
using System.Collections.Generic;
using System.Text;

namespace NSubstituteExcercise
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int customerId);

        List<Customer> ListOfCustomers();
    }
}
