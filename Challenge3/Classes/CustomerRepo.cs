using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge3.Classes
{
    public class CustomerRepo
    {
            List<Customer> _customerList = new List<Customer>();

            int customers = 0;


        public void CreateCustomer(string firstName, string lastName, int typeNum)
        {
            customers++;

            Customer newCustomer = new Customer(customers, firstName, lastName, typeNum);

            _customerList.Add(newCustomer);

        }

        public List<Customer> CurrentCustomers()
        {  
            return _customerList;
        }

       public void UpdateCustomer()
        {
            foreach (Customer customer in _customerList)
            {
                customer.UserID = (_customerList.IndexOf(customer) + 1 );
            }
        }


       public void DeleteCustomer(int customerID)
        {
            int idNum = customerID;
            idNum--;

            _customerList.Remove(_customerList[idNum]);
            UpdateCustomer();

            customers--;

        }

    }
}
