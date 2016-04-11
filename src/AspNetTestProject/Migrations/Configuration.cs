using System.Collections.Generic;
using AspNetTestProject.DAL;

namespace AspNetTestProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetTestProject.DAL.DbEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AspNetTestProject.DAL.DbEntities";
        }

        protected override void Seed(AspNetTestProject.DAL.DbEntities context)
        {
            var tasksToAdd = new List<Task>
            {
                new Task { Title = "Crete asp.net task project", Description = "Create a  project to show how to buid an asp.net app"},
                new Task { Title = "Go to the Market", Description = "Go to the market for fruits"},
                new Task { Title = "Get a 40+ hours per week job in IpWork", Description = "Need to get a good job in UpWork"},
                new Task { Title = "Call Mon", Description = "Need to call mon"},
                new Task { Title = "Buy a new bike for my son", Description = "Need to buy a new bike for my child"},
                new Task { Title = "Send my dog to the farm", Description = "Send my dog to my dad in the farm"},
                new Task { Title = "Take a day for do nothing", Description = "A day really doing nothing"},
                new Task { Title = "Go to the beach", Description = "Go to the beach with familiy"},
            };
            context.Tasks.AddRange(tasksToAdd);
            context.SaveChanges();
        }
    }
}
