using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class GeoServiceContext : DbContext
    {
        protected string _connectionString;
        public GeoServiceContext(IConfiguration configuration)//, string connection = "production")
        {
            _connectionString = configuration.GetConnectionString("production");
            //SetConnectionString(connection);
        }
        public DbSet<ContinentDb> Continents { get; set; }
        public DbSet<CountryDb> Countries { get; set; }
        public DbSet<CityDb> Cities { get; set; }
        public DbSet<RiverDb> Rivers { get; set; }
        //protected virtual void SetConnectionString(string connection)
        //{
        //    // TODO change to use AppSettings (but how?)
        //    if (connection == "production")
        //        _connectionString = @"Data Source=DESKTOP-4NAJBEU\SQLEXPRESS;Initial Catalog=GeoService;Integrated Security=True";
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryRiver>().HasKey(x => new { x.CountryId, x.RiverId });
        }
    }
}
