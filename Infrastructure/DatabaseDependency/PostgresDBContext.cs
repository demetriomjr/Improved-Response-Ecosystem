﻿using Microsoft.EntityFrameworkCore;
using Models.Interfaces_Abstracts;
using Models.People;

namespace Infrastructure.SQLDatabase
{
    public class PostgresDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var et in modelBuilder.Model.GetEntityTypes().Where(x => x.BaseType!.Name.Equals(nameof(SQLPersistentModel))))
            {
                modelBuilder.Entity(et.Name).HasIndex("Id");
                //modelBuilder.Entity(et.Name).Property("Id").HasCheckConstraint("CK_Id_NonNegative", "[Id] >= 0");
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
