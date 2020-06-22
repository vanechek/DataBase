using System;
using System.Collections.Generic;

namespace DataBase.Model.Table
{
    class Consignment
    {
        public Consignment()
        {
            Maths = new List<Math>();
        }
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ComingDate { get; set; }
        public string StanciyaOtpravlenya { get; set; }
        public string StanciyaNsnacheniya { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? SendId { get; set; }
        public virtual Send Send { get; set; }
        public int? SupplyScheduleId { get; set; }
        public virtual SupplySchedule SupplySchedule { get; set; }
        public int? Gu12Id { get; set; }
        public virtual Gu12 Gu12 { get; set; }
        public virtual ICollection<Math> Maths { get; set; }
    }
}
