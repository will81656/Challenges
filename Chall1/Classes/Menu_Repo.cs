using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chall1.Classes
{
    public class Menu_Repo
    {
        
        public List<Menu> _menuItems = new List<Menu>();

        public int menuCount = 0;

        public bool CreateMenuItem(int number, string name, string desc, string ingredients, double price)
        {
           int listCount = _menuItems.Count();

            menuCount++;

            Menu item = new Menu(number, name, desc, ingredients, price);
           _menuItems.Add(item);

            bool wasAdded = (_menuItems.Count > listCount) ?true : false;

            return wasAdded;
            
        }
       

        public List<Menu> CurrentMenu()
        {
            return _menuItems;
        }

        public int DeleteMenuItem(int item)
        {
            int num = item;
            _menuItems.Remove(_menuItems[num]);
           int newlist = _menuItems.Count();

            
            menuCount--;
            return newlist;

        }
    }
}
