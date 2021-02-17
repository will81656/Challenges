using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge3.Classes
{
    public enum CustomerType
    {
        Potential = 1 , Current, Past
    }


    public class Customer
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }

        private string tab;
        public override string ToString()
        {
            return $"  {UserID}\t{FirstName}\t{LastName}\t{Type}{tab}";
        }

        public Customer(int id, string firstName, string lastName, int typeNum)
        {
            UserID = id;
            FirstName = firstName;
            LastName = lastName;

            switch (typeNum)
            {
                case 1:
                    Type = CustomerType.Potential;
                    break;
                case 2:
                    Type = CustomerType.Current;
                    break;
                case 3:
                    Type = CustomerType.Past;
                    tab = "\t";
                    break;
            }

        }
    }
}
