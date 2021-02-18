using Chall3.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge5Test
{

    [TestClass]
    public class UnitTest1
    {
        private CustomerRepo _repo = new CustomerRepo();

       


        [TestInitialize]

        public void Seed()
        {       // seed for delete test
            _repo.CreateCustomer("John", "Doe", 2);

        }

        [TestMethod]
        public void CreateCustomer()
        {  //Act
            bool isAdded = _repo.CreateCustomer("Will", "Casteel", 1);

            //Assert
            Assert.IsTrue(isAdded);
        }

        [TestMethod]
        public void DeleteCustomer()
        {       //Act
            int less = _repo.DeleteCustomer(1);

            
                //Assert
            Assert.AreEqual(1, less);

            List<Customer> stuff = _repo.CurrentCustomers();
        }

        [TestMethod]
        public void UpdateCustomers()
        {
            Customer newCustomer = new Customer(1, "Paige", "Fanok", 2);

            _repo.UpdateCustomers();

            Assert.IsNotNull(newCustomer);
        }

        [TestMethod]
        public void CurrentCustomers()
        {       // Arramge
            List<Customer> list = _repo.CurrentCustomers();

            //Act
            int items = list.Count;

            //Assert
            Assert.AreEqual(1, items);


        }








    }
}
