using System;
using System.Collections.Generic;

namespace DataBase.Model.Table
{
    public class Gu12
    {
        public Gu12()
        {
            Maths = new List<Math>();
        }
        public int Id { get; set; }
        public string StanciyaOtpravlenie { get; set; }
        public string StanciyaNasnacheniya { get; set; }
        public DateTime DataNachaloPerevoski { get; set; }
        public DateTime PlaniruemayaDataOkonchaniya { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? SendId { get; set; }
        public virtual Send Send { get; set; }
        public int? SupplyScheduleId { get; set; }
        public virtual SupplySchedule SupplySchedule { get; set; }
        public virtual ICollection<Math> Maths { get; set; }
    }
}
