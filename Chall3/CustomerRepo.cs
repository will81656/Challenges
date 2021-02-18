using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chall3.Classes
{
    public class CustomerRepo
    {
        List<Customer> _customerList = new List<Customer>();

        int customers = 0;


        public bool CreateCustomer(string firstName, string lastName, int typeNum)
        {
            int Count = _customerList.Count();

            customers++;

            Customer newCustomer = new Customer(customers, firstName, lastName, typeNum);

            _customerList.Add(newCustomer);
            bool wasAdded = (_customerList.Count > Count) ? true : false;

            return wasAdded;
        }

        public List<Customer> CurrentCustomers()
        {
            return _customerList;
        }

        public void UpdateCustomers()
        {
            foreach (Customer customer in _customerList)
            {
                customer.UserID = (_customerList.IndexOf(customer) + 1);
            }
        }


        public int DeleteCustomer(int customerID)
        {
            int idNum = customerID;
            idNum--;

            int newlist = _customerList.Count();
            customers--;

            _customerList.Remove(_customerList[idNum]);
            UpdateCustomers();

            return newlist;

        }

    }
}
