using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chall2.Classes
{
    public class OutingRepo
    {
        List<Outing> _outingList = new List<Outing>();
        
        public List<Outing> GetList()
        {
            return _outingList;
        }

        public bool AddOuting(EventType type, int attendees, DateTime date, decimal individualCost, decimal totalEventCost)
        {
            int listCount = _outingList.Count();

            Outing newOuting = new Outing(type, attendees, date, individualCost, totalEventCost);

            _outingList.Add(newOuting);

            bool wasAdded = (_outingList.Count > listCount) ? true : false;

            return wasAdded;
        }

        public decimal TotalCost()
        {
            decimal totalCost = 0m;

            foreach (Outing outing in _outingList)
            {
                totalCost = totalCost + outing.TotalEventCost;
            }

            return totalCost;
        }

        public decimal GetCostByType(EventType inType)
        {
            decimal totalCost = 0m;

            foreach (Outing outing in _outingList)
            {
                if (outing.OutingType == inType)
                {
                    totalCost = totalCost + outing.TotalEventCost;
                }
            }

            return totalCost;
        }

    }
}
