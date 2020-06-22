namespace DataBase.Model.Table
{
    class Math
    {
        public int Id { get; set; }
        public int? ConsignmentId { get; set; }
        public virtual Consignment Consignment { get; set; }
        public int? Gu12Id{ get; set; }
        public virtual Gu12 Gu12 { get; set; }
    }
}
