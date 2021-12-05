using DataApi1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApi1.Context
{
    public class MoneyContext : DbContext
    {
        public MoneyContext(DbContextOptions<MoneyContext> options) : base(options) { }
        public DbSet<Tarih_Date> tarih_Dates { get; set; }
        public DbSet<Currency> currencies { get; set; }
    }
}
