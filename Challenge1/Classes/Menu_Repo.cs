using System;
using System.Collections.Generic;
using System.Text;


namespace Challenge1
{
    public class Menu_Repo
    {
        private List<Menu> _menuItems = new List<Menu>();

        public int menuCount = 0;

        public void CreateMenuItem(string name, string desc, string ingredients, double price)
        {
            menuCount++;

            Menu item = new Menu( menuCount, name, desc, ingredients, price);
            _menuItems.Add(item);
        }
        public void CreateMenuItem(Menu item)
        {
            menuCount++;
            _menuItems.Add(item);
        }

        public List<Menu> CurrentMenu()
        {
            return _menuItems;
        }

        public void DeleteMenuItem(Menu item)
        { 

            _menuItems.Remove(item);

            menuCount--;
        }
    }
}
