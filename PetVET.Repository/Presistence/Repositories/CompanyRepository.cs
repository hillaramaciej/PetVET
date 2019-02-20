using Microsoft.EntityFrameworkCore;
using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace PetVET.Repository
{
    class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private DbSet<Company> Company;
        public CompanyRepository(DBVETContext context) : base(context)
        {
            Company = context.Company;
        }


    }
}
