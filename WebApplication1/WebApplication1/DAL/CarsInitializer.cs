using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Migrations;
using System.Data.Entity.Migrations;

namespace WebApplication1.DAL
{
    public class CarsInitializer : MigrateDatabaseToLatestVersion<CarsContext, WebApplication1.Migrations.Configuration>
    {
        public static void SeedCars(CarsContext context)
        {
            var categories = new List<Category>()
            {
                new Category
                {
                    CategoryID = 1,
                    Name = "Van",
                    Desc = "Samochod rodzinny"
                },
                new Category
                {
                    CategoryID = 2,
                    Name = "Sedan",
                    Desc = "Sportowy wyglad"
                },
                new Category
                {
                    CategoryID = 3,
                    Name = "Kombi",
                    Desc = "Dużo przestrzeni w bagażniku"
                },
                new Category
                {
                    CategoryID = 4,
                    Name = "Hatchback",
                    Desc = "Krótszy tył"
                }
            };

            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(category);
            }

            context.SaveChanges();

            var cars = new List<Car>()
            { 
                new Car
                {
                    Mark = "Ford",
                    Model = "Focus",
                    CarRegistration = "CB00001",
                    CategoryID = 3,
                    AddDate = DateTime.Now
                },
                new Car
                {
                    Mark = "Honda",
                    Model = "Civic",
                    CarRegistration = "CB00002",
                    CategoryID = 2,
                    AddDate = DateTime.Now
                },
                new Car
                {
                    Mark = "Nissan",
                    Model = "Skyline",
                    CarRegistration = "CB00003",
                    CategoryID = 2,
                    AddDate = DateTime.Now
                }
            };
            foreach (var car in cars)
            {
                //add-Migration 'nazwa'   dodanie migracji
                //update-Database-TargetMigration:podajemuNazweMigracji
                //update-Database odświeżenie bazy danych

                //Zmiana przeglądania bazy, nie po CarID tylko przez CarRegistration
                context.Cars.AddOrUpdate(c=>c.CarRegistration,car);
            }

            context.SaveChanges();

        }
    }
}