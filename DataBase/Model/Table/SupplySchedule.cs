using System;
using System.Collections.Generic;

namespace DataBase.Model.Table
{
    public class SupplySchedule
    {
        public SupplySchedule()
        {
            Gu12 = new List<Gu12>();
        }
        public int Id { get; set; }
        public DateTime SupplyDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double WeightProduct { get; set; }
        public int CountVagonov { get; set; }

        public virtual ICollection<Gu12> Gu12 { get; set; }
    }
}
