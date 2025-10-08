using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
        public ICollection<SitOrder>? SitOrders { get; set; }
    }
}
