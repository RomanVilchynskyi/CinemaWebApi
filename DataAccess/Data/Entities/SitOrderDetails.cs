namespace DataAccess.Data.Entities
{
    public class SitOrderDetails
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Sit { get; set; }

        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        public int SitOrderId { get; set; }
        public SitOrder? SitOrder { get; set; }
    }
}
