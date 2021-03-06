﻿using Microsoft.EntityFrameworkCore;
using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace PetVET.Repository
{
    class EmployeesRepository : Repository<Employee>, IEmployeesRepository
    {
        private DbSet<Employee> Employee;
        public EmployeesRepository(DBVETContext context) : base(context)
        {
            Employee = context.Employee;
        }


    }
}
