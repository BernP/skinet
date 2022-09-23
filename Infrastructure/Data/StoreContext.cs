using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;



namespace API.Data
{
    public class StoreContex : DbContext
    {
        public StoreContex(DbContextOptions<StoreContex> options) : base(options)
        {
        }

        public DbSet<Product> Products{get; set;}
    }
}