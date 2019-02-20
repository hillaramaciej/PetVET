
using PetVET.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetVET.Repository
{
    public interface IUnitOfWork
    {
        IAnimalRepository Animal { get; }
        IAnimalRaceRepository AnimalRace { get; }
        IAnimalSpeciesRepository AnimalSpecies { get; }
        IAssortmentRepository Assortment { get; }
        IAssortPriceRepository AssortPrice { get; }
        IAssortTypeRepository AssortType { get; }
        ICompanyRepository Company { get; }
        ICustomerRepository Customer { get; }
        ICustomerAnimalRepository CustomerAnimal { get; }
        IEmployeesRepository Employee { get; }
        IEmployeeGroupRepository EmployeeGroup { get; }
        IEmployeeHolidayRepository EmployeeHoliday { get; }
        IEmployeeOpenHourRepository EmployeeOpenHour { get; }
        IEmployeeServiceRepository EmployeeService { get; }
        IEquipemntTypeRepository EquipemntType { get; }
        IInvoiceRepository Invoice { get; }
        IInvoiceAssortmentRepository InvoiceAssortment { get; }
        IInvoiceServiceRepository InvoiceService { get; }
        IMethodPayRepository MethodPay { get; }
        IOfficeRepository Office { get; }
        IOfficeCustomerRepository OfficeCustomer { get; }
        IOfficeHolidayRepository OfficeHoliday { get; }
        IOfficeOpenHourRepository OfficeOpenHour { get; }
        IReservationRepository Reservation { get; }
        IReservationServiceRepository ReservationService { get; }
        IServicRepository Servic { get; }
        IServiceTypeRepository ServiceType { get; }
        ITaxRepository Tax { get; }
        IVisitRepository Visit { get; }

        DBVETContext Context { get; }

        int Complete();
    }
}
