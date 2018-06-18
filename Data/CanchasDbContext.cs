using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class CanchasDbContext : DbContext
    {
        public CanchasDbContext(DbContextOptions<CanchasDbContext> options) : base(options)
        {

        } 
        public DbSet<Field> Fields { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Business> Businesses { get; set; }
    }
}
