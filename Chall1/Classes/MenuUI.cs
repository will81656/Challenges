using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chall1.Classes
{
    public class MenuUI
    {
        public Menu_Repo _menuRepo = new Menu_Repo();


        private int itemCount = 0;

        public void Start()
        {
            StartMenu();
        }


        // Main Menu
        private void StartMenu()
        {

            bool runMenu = true;

            while (runMenu)
            {

                Console.Clear();
                Console.WriteLine($" What would you like to do? \n" +
                $"0. Exit \n" +
                $"1. Create Menu Item \n" +
                $"2. Show Current Menu \n" +
                $"3. Delete Menu item \n");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        runMenu = false;
                        break;
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        CurrentMenu();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;

                    default:
                        StartMenu();
                        break;
                }
            }
        }
        // Create Menu Item
        private void CreateMenuItem()
        {

            Console.Clear();
            Console.WriteLine(" Enter a number for the new Menu Item: ");
            int newNumber = Int32.Parse(Console.ReadLine());

            Console.Write("Enter the name of the new Menu Item: ");
            string newName = Console.ReadLine();

            Console.Write($"Enter the description for {newName}: ");
            string newDesc = Console.ReadLine();

            Console.Write($"Enter the list of ingredients for {newName}: ");
            string newIngredients = Console.ReadLine();

            Console.Write($"Enter the price for {newName}: ");
            double newPrice = 0;
            bool valid = false;
            while (!valid)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out newPrice))
                    valid = true;
                else
                    Console.WriteLine("Please enter a number:");
            }

            _menuRepo.CreateMenuItem(newNumber, newName, newDesc, newIngredients, newPrice);

            itemCount++;
            

        }

        //View Menu
        private void CurrentMenu()
        {
            List<Menu> menu = _menuRepo.CurrentMenu();

            Console.Clear();

            foreach (var item in menu)
            {
                Console.WriteLine($"{item.MealNumber}. {item.MealName}\n" +
                    $"   Description: {item.MealDescription}\n" +
                    $"   Ingredients: {item.MealIngredients}\n" +
                    $"   Price: ${item.MealPrice}\n");
            }
            if (menu.Count() == 0)
            {
                Console.WriteLine("Currently the menu is empty.");
            }
            Console.ReadLine();
        }

        //Delete Menu Item
        public void DeleteMenuItem()
        {
            List<Menu> menu = _menuRepo.CurrentMenu();
            
            Console.Clear();

            int num;

            Console.WriteLine("Enter the number of the item you would like to delete.");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out num);
            if (isNumber)
            {
                foreach (Menu item in menu)
                {
                    if (num == item.MealNumber)
                    {
                        Console.Write($"Are you sure you would like to delete {item.MealName}?\n" +
                            $"(Y/N): ");
                        string delResponse = Console.ReadLine().ToLower();
                        if (delResponse == "y")
                        {
                            num--;
                            _menuRepo.DeleteMenuItem(num);
                            Console.WriteLine($"{item.MealName} has been removed.\n");

                            foreach (Menu oldItem in menu)
                            {
                                int spot = menu.IndexOf(oldItem);
                                spot++;
                                oldItem.MealNumber = spot;
                            }
                            itemCount--;
                        }
                        Console.WriteLine(" No items present");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid meal number");
                Console.ReadLine();
            }
        }
    }
}
