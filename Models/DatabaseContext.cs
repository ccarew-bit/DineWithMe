﻿using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DineWithMe.Models
{
  public partial class DatabaseContext : DbContext
  {

    public DbSet<User> Users { get; set; }
    public DbSet<Request> Requests { get; set; }

    public DbSet<Restaurant> Restaurants { get; set; }

    public DbSet<Agreement> Agreements { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<Restaurant>().HasData(
          new Restaurant
          {
            Id = 1,
            Name = "Ceviche tapas St.Pete",
            Type = "Spanish",
            Reviews = "GREAT",
            Hours = "9am-5pm",
            Expenses = "$$",
            ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051715/Ceviche_i5ai5k.jpg",
            Location = "St.Petersburg, Fl"

          },
          new Restaurant
          {
            Id = 2,
            Name = "Red Mesa",
            Type = "Mexican",
            Reviews = "GREAT",
            Hours = "9am-5pm",
            Expenses = "$$",
            ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051736/RedMesa_qdqyml.jpg",
            Location = "St.Petersburg, Fl"
          },

          new Restaurant
          {
            Id = 3,
            Name = "Parkshore Grill",
            Type = "American",
            Reviews = "GREAT",
            Hours = "9am-5pm",
            Expenses = "$$",
            ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051732/ParkshoreGrill_hfcqp7.jpg",
            Location = "St.Petersburg, Fl"
          },

          new Restaurant
          {
            Id = 4,
            Name = "Harvey's 4th Street Grill",
            Type = "Spanish",
            Reviews = "GREAT",
            Hours = "9am-5pm",
            Expenses = "$$",
            ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051720/Harveys4thStreetGrill_shx5pc.jpg",
            Location = "St.Petersburg, Fl"
          },

          new Restaurant
          {
            Id = 5,
            Name = "BellaBrava",
            Type = "Pizza",
            Reviews = "GREAT",
            Hours = "9am-5pm",
            Expenses = "$$",
            ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051681/BellaBrava_pawxiw.jpg",
            Location = "St.Petersburg, Fl"
          },

           new Restaurant
           {
             Id = 6,
             Name = "Hawkers Asian Street Fare",
             Type = "Asian",
             Reviews = "GREAT",
             Hours = "9am-5pm",
             Expenses = "$$",
             ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051722/HawkersAsianStreetFare_hebtp3.jpg",
             Location = "St.Petersburg, Fl"
           },

           new Restaurant
           {
             Id = 7,
             Name = "Casita Taqueria",
             Type = "Mexican",
             Reviews = "GREAT",
             Hours = "9am-5pm",
             Expenses = "$",
             ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051706/CasitaTaqueria_oiw2bj.jpg",
             Location = "St.Petersburg, Fl"
           },

           new Restaurant
           {
             Id = 8,
             Name = "Rawk Star Cafe St. Pete",
             Type = "Vegan",
             Reviews = "GREAT",
             Hours = "9am-5pm",
             Expenses = "$",
             ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051735/RawkStarCafeStPete_uyc2bm.jpg",
             Location = "St.Petersburg, Fl"
           },

           new Restaurant
           {
             Id = 9,
             Name = "Central Melt",
             Type = "Deli",
             Reviews = "GREAT",
             Hours = "9am-5pm",
             Expenses = "$",
             ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051713/Central_Melt_eubwhw.jpg",
             Location = "St.Petersburg, Fl"
           },

           new Restaurant
           {
             Id = 10,
             Name = "Bodega on Central",
             Type = "Cuban",
             Reviews = "GREAT",
             Hours = "9am-5pm",
             Expenses = "$",
             ImageUrl = "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051688/BodegaonCentral_udxwnf.jpg",
             Location = "St.Petersburg, Fl"
           }

        );
    }
    private string ConvertPostConnectionToConnectionString(string connection)
    {
      var _connection = connection.Replace("postgres://", String.Empty);
      var output = Regex.Split(_connection, ":|@|/");
      return $"server={output[2]};database={output[4]};User Id={output[0]}; password={output[1]}; port={output[3]}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var envConn = Environment.GetEnvironmentVariable("DATABASE_URL");

        var conn = "server=localhost;database=DineWithMeDatabase";
        if (envConn != null)
        {
          conn = ConvertPostConnectionToConnectionString(envConn);
        }
        optionsBuilder.UseNpgsql(conn);
      }
    }

  }
}
