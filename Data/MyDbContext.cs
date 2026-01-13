using Auth_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace Auth_WebAPI.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }


        }
}
