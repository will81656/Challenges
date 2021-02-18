using Chall1.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1Test
{
    [TestClass]
    public class UnitTest1

    {       // Arrange
            private Menu_Repo _menuRepo = new Menu_Repo();

        [TestInitialize]
        
        public void Seed()
        {
           // seed for delete test
            _menuRepo.CreateMenuItem(1, "Hotdog", " Classic Hotdog", "Buns, ketchup, mustard, Onions", 3.99);

        }



        [TestMethod]
        public void AddTest()
        {   
            
            
            // Act
             bool isAdded = _menuRepo.CreateMenuItem(1, "Burger", " Classic Hamburger", "Buns, Lettuce, Beef, Onions", 4.99);

            // Assert
            Assert.IsTrue(isAdded);
        }
        [TestMethod]
        public void ShowTest()
        {
            // Arrange 
           List<Menu> list = _menuRepo.CurrentMenu();

            // Act
            int items = list.Count;

            //Assert
            Assert.AreEqual(1, items);
           

        }

        [TestMethod]
        public void DeleteTest()
        {
           //Act and Assert
           

            int Less = _menuRepo.DeleteMenuItem(1);

            Assert.AreEqual(1, Less);

        }
    }
}
