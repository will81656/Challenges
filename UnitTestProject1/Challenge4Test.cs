using Chall2.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class Challenge4Test
    {
        private OutingRepo _outingList = new OutingRepo();
        [TestInitialize]
        public void Seed()
        {


        }
        [TestMethod]
        public void GetListTest()
        {  // Arrange  
            List<Outing> listTest = _outingList.GetList();

            //Act
            int items = listTest.Count;

            //Assert
            Assert.AreEqual(0, items);
        }

        [TestMethod]
        public void AddOuting()
        {
            _outingList.AddOuting(EventType.AmusementPark, 500, DateTime.Now, 75, 6000);

            bool isAdded = _outingList.AddOuting(EventType.AmusementPark, 500, DateTime.Now, 75, 6000);

            Assert.IsTrue(isAdded);
        }

        [TestMethod]
        public void TotalCost()
        {

            decimal totalCost = _outingList.TotalCost();

            Assert.AreEqual(0, totalCost);
        }

        [TestMethod]
        
        public void GetCostByType()
        {       
                // Assert and Act
            decimal costAmuse = _outingList.GetCostByType(EventType.Bowling);
            Assert.AreEqual(0, costAmuse);


            decimal costBowling = _outingList.GetCostByType(EventType.Bowling);
            Assert.AreEqual(0, costBowling);

            decimal costConcert = _outingList.GetCostByType(EventType.Concert);
            Assert.AreEqual(0, costConcert);

            decimal costGolf = _outingList.GetCostByType(EventType.Golf);
            Assert.AreEqual(0, costGolf);



        }
    }
}
