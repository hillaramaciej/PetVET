
using Microsoft.EntityFrameworkCore;
using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetVET.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetVetDbContext _context;

        public ICustomerRepository Customer { get; set; }
        public IAssortmentRepository Assortment { get; set; }
        public IOfficeDepartmentRepository OfficeDepartment { get; set; }
        public ICustomerAnimalRepository CustomerAnimal { get; set; }
        public IServiceRepository Treatment { get; set; }
        public IEmployeesRepository Vet { get; set; }
        public IPKWIURepository PKWIUR { get; }
        public IInvoiceRepository Invoice { get; }
        public IOfficeRepository Office { get; }


        PetVetDbContext IUnitOfWork.Context => _context;

        public UnitOfWork(PetVetDbContext context)
        {
            _context = context;
            Customer = new CustomerRepository(context);
            Assortment = new AssortmentRepository(context);
            OfficeDepartment = new OfficeDepartmentRepository(context);
            CustomerAnimal = new CustomerAnimalRepository(context);
            Treatment = new ServiceRepository(context);
            Vet = new EmployeesRepository(context);
            PKWIUR = new PKWIURepository(context);
            //Equipment = new EquipmentRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
