﻿using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.DataPersistence
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<WeekPeriod> WeekPeriod { get; set; }
        public DbSet<User> User { get; set; }

    }
}
