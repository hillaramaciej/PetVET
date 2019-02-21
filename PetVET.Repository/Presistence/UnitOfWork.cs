
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
        private readonly DBVETContext _context;

       public IAnimalRepository Animal { get; set; }
       public IAnimalRaceRepository AnimalRace { get; set; }
       public IAnimalSpeciesRepository AnimalSpecies { get; set; }
       public IAssortmentRepository Assortment { get; set; }
       public IAssortPriceRepository AssortPrice { get; set; }
       public IAssortTypeRepository AssortType { get; set; }
       public ICompanyRepository Company { get; set; }
       public ICustomerRepository Customer { get; set; }
       public ICustomerAnimalRepository CustomerAnimal { get; set; }
       public IEmployeesRepository Employee { get; set; }
       public IEmployeeGroupRepository EmployeeGroup { get; set; }
       public IEmployeeHolidayRepository EmployeeHoliday { get; set; }
       public IEmployeeOpenHourRepository EmployeeOpenHour { get; set; }
       public IEmployeeServiceRepository EmployeeService { get; set; }
       public IEquipemntTypeRepository EquipemntType { get; set; }
       public IInvoiceRepository Invoice { get; set; }
       public IInvoiceAssortmentRepository InvoiceAssortment { get; set; }
       public IInvoiceServiceRepository InvoiceService { get; set; }
       public IMethodPayRepository MethodPay { get; set; }
       public IOfficeRepository Office { get; set; }
       public IOfficeCustomerRepository OfficeCustomer { get; set; }
       public IOfficeHolidayRepository OfficeHoliday { get; set; }
       public IOfficeOpenHourRepository OfficeOpenHour { get; set; }
       public IReservationRepository Reservation { get; set; }
       public IReservationServiceRepository ReservationService { get; set; }
       public IServicRepository Servic { get; set; }
       public IServiceTypeRepository ServiceType { get; set; }
       public ITaxRepository Tax { get; set; }
       public IVisitRepository Visit { get; set; }



        DBVETContext IUnitOfWork.Context => _context;

        public UnitOfWork(DBVETContext context)
        {
            _context = context;
            Animal = new AnimalRepository(context);
            AnimalRace = new AnimalRaceRepository(context);
            AnimalSpecies = new AnimalSpeciesRepository(context);
            Assortment = new AssortmentRepository(context);
            AssortPrice = new AssortPriceRepository(context);
            AssortType = new AssortTypeRepository(context);
            Company = new CompanyRepository(context);
            Customer = new CustomerRepository(context);
            CustomerAnimal = new CustomerAnimalRepository(context);
            Employee = new EmployeesRepository(context);
            EmployeeGroup = new EmployeeGroupRepository(context);
            EmployeeHoliday = new EmployeeHolidayRepository(context);
            EmployeeOpenHour = new EmployeeOpenHourRepository(context);
            EmployeeService = new EmployeeServiceRepository(context);
            EquipemntType = new EquipemntTypeRepository(context);
            Invoice = new InvoiceRepository(context);
            InvoiceAssortment = new InvoiceAssortmentRepository(context);
            InvoiceService = new InvoiceServiceRepository(context);
            MethodPay = new MethodPayRepository(context);
            Office = new OfficeRepository(context);
            OfficeCustomer = new OfficeCustomerRepository(context);
            OfficeHoliday = new OfficeHolidayRepository(context);
            OfficeOpenHour = new OfficeOpenHourRepository(context);
            Reservation = new ReservationRepository(context);
            ReservationService = new ReservationServiceRepository(context);
            Servic = new ServicRepository(context);
            ServiceType = new ServiceTypeRepository(context);
            Tax = new TaxRepository(context);
            Visit = new VisitRepository(context);

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
