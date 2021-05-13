using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using newRepo.Models;

namespace newRepo.Data
{
    public class PropertyDB : DbContext
    {
        public PropertyDB(DbContextOptions<PropertyDB> options)
        : base(options) { }

        public DbSet<newRepo.Models.PropertyInfo> PropertyInfo { get; set; }

        public DbSet<newRepo.Models.User> User { get; set; }
    }

}
