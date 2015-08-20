using System.Data.Entity;
using BusinessLogic.DomainLayer;

namespace BusinessLogic.DataLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Human> People { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
