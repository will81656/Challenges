using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chall3.Classes
{
    public class CustomerUI
    {
        CustomerRepo _custRepo = new CustomerRepo();
        public void Main()
        {




        }



        public void RunMenu()
        {
            CustomerRepo customers = new CustomerRepo();
            List<Customer> _customerList = _custRepo.CurrentCustomers();


            _custRepo.CreateCustomer("Jake", "Smith", 1);
            _custRepo.CreateCustomer("James", "Smith", 2);
            _custRepo.CreateCustomer("Jane", "Smith", 3);

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. View all Customers \n" +
                    "2. Create a new Customer \n" +
                    "3. Update a Customer \n" +
                    "4. Remove a Customer \n" +
                    "0. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // View all Customers
                        ViewallCustomers();
                        break;
                    case "2":
                        //-- Create new Customer
                        CreateNewCustomer();
                        break;
                    case "3":
                        //-- Update Customer
                        UpdateCustomer();
                        break;
                    case "4":
                        //-- Delete Customer
                        DeleteCustomer();
                        break;
                    case "0":
                        //-- Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 0 and 4.");

                        break;
                }
            }
        }
        // View all Customers
        void ViewallCustomers()
        {
            CustomerRepo customers = new CustomerRepo();

            List<Customer> _customerList = _custRepo.CurrentCustomers();

            Console.Clear();

            _customerList.Sort((x, y) => string.Compare(x.LastName, y.FirstName));
            Console.WriteLine("UserID\tFirst\tLast\tCustomer Type\tEmail Sent");

            customers.UpdateCustomers();

            foreach (Customer customer in _customerList)
            {
                string email = null;
                switch (customer.Type)
                {
                    case CustomerType.Potential:
                        email = "\tWe currently have the lowest rates on Helicopter Insurance!";
                        break;
                    case CustomerType.Current:
                        email = "\tThank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                        break;
                    case CustomerType.Past:
                        email = "\tIt's been a long time since we've heard from you, we want you back!";
                        break;
                }
                Console.WriteLine($"{customer} {email}");
            }

            Console.Read();

        }


        // Create New Customer
        void CreateNewCustomer()
        {
            Console.Clear();

            Console.Write(" Enter new Customer's First Name: ");
            string newFirst = Console.ReadLine();

            Console.Write("Enter new Customer's Last Name: ");
            string newLast = Console.ReadLine();

            Console.WriteLine("What type is this new Customer?\n" +
                      "1. Potential\n" +
                      "2. Current\n" +
                      "3. Past\n");

            string custType = Console.ReadLine();

            int newType = int.Parse(custType);

            _custRepo.CreateCustomer(newFirst, newLast, newType);
        }


        void DeleteCustomer()
        {


            List<Customer> _customerList = _custRepo.CurrentCustomers();

            Console.Clear();

            Console.Write("Enter the Customer's ID you would like to Delete: ");
            int response = Int32.Parse(Console.ReadLine());
            if (_customerList.Exists(x => x.UserID == response))
            {
                _custRepo.DeleteCustomer(response);
                Console.WriteLine("Customer Deleted.");
            }
            else
                Console.WriteLine("No Customer exists with that ID.");

            Console.ReadLine();


        }

        void UpdateCustomer()
        {


            List<Customer> _customerList = _custRepo.CurrentCustomers();
            Console.Clear();

            Console.Write("Enter the customer ID you would like to update: ");
            int response = Int32.Parse(Console.ReadLine());
            if (_customerList.Exists(x => x.UserID == response))
            {
                foreach (Customer customer in _customerList)
                {
                    if (customer.UserID == response)
                    {
                        Console.WriteLine($"1. First Name: {customer.FirstName}" +
                            $"\n2. Last Name: {customer.LastName}" +
                            $"\n3. Customer Type: {customer.Type}" +
                            $"\n4. Return to Menu" +
                            $"\n\nEnter the number to update: ");
                        int updateResponse = Int32.Parse(Console.ReadLine());
                        switch (updateResponse)
                        {
                            case 1:
                                Console.Write("Enter new Customer's First Name: ");
                                customer.FirstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write("Enter new Customer's Last Name: ");
                                customer.LastName = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine($"Enter new Customer's Type: " +
                                    $"\n\t1. Potential" +
                                    $"\n\t2. Current" +
                                    $"\n\t3. Past");
                                int updatedType = Int32.Parse(Console.ReadLine());

                                if (updatedType == 1)
                                    customer.Type = CustomerType.Potential;
                                else if (updatedType == 2)
                                    customer.Type = CustomerType.Current;
                                else if (updatedType == 3)
                                    customer.Type = CustomerType.Past;
                                else
                                    Console.WriteLine("Not a Valid Type.");
                                break;
                            case 4:
                                Console.WriteLine("Press Any Key to return to Main Menu");
                                break;
                            default:
                                Console.WriteLine("Something Went Wrong");
                                break;
                        }
                        break;
                    }
                }
            }
            else
                Console.WriteLine("No Customer has that ID.");

            Console.ReadLine();


        }


    }
}
