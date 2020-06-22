using System.Collections.Generic;

namespace DataBase.Model.Table
{
    class Product
    {
        public Product()
        {
            Gu12 = new List<Gu12>();
        }
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public double WeightProduct { get; set; }
        public string DangerProduct { get; set; }

        public virtual ICollection<Gu12> Gu12 { get; set; }

    }
}
