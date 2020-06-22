using System;
using System.Collections.Generic;

namespace DataBase.Model.Table
{
    class Send
    {
        public Send()
        {
            Gu12 = new List<Gu12>();
        }
        public int Id { get; set; }

        public DateTime DataNachaloOtpravki { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string TypeProduct { get; set; }
        public double WeightProduct { get; set; }
        public int CountVagonov { get; set; }
        public string StanciyaNasnacheniya { get; set; }
        public string StanciyaOtrpavlenie { get; set; }
        public virtual ICollection<Gu12> Gu12 { get; set; }
    }
}
