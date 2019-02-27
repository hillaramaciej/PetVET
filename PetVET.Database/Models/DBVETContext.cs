using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetVET.Database.Models
{
    public partial class DBVETContext : DbContext
    {
        public DBVETContext()
        {
        }

        public DBVETContext(DbContextOptions<DBVETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<AnimalRace> AnimalRace { get; set; }
        public virtual DbSet<AnimalSpecies> AnimalSpecies { get; set; }
        public virtual DbSet<AssortPrice> AssortPrice { get; set; }
        public virtual DbSet<AssortType> AssortType { get; set; }
        public virtual DbSet<Assortment> Assortment { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAnimal> CustomerAnimal { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeGroup> EmployeeGroup { get; set; }
        public virtual DbSet<EmployeeHoliday> EmployeeHoliday { get; set; }
        public virtual DbSet<EmployeeOffice> EmployeeOffice { get; set; }
        public virtual DbSet<EmployeeOpenHour> EmployeeOpenHour { get; set; }
        public virtual DbSet<EmployeeService> EmployeeService { get; set; }
        public virtual DbSet<Equipemnt> Equipemnt { get; set; }
        public virtual DbSet<EquipemntType> EquipemntType { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceAssortment> InvoiceAssortment { get; set; }
        public virtual DbSet<InvoiceService> InvoiceService { get; set; }
        public virtual DbSet<MethodPay> MethodPay { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<OfficeCustomer> OfficeCustomer { get; set; }
        public virtual DbSet<OfficeHoliday> OfficeHoliday { get; set; }
        public virtual DbSet<OfficeOpenHour> OfficeOpenHour { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<ReservationService> ReservationService { get; set; }
        public virtual DbSet<Servic> Servic { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Animal__97BD02EBEEC24E68");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.AnimBirthdate)
                    .HasColumnName("ANIM_BIRTHDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnimCastrated).HasColumnName("ANIM_CASTRATED");

                entity.Property(e => e.AnimChip)
                    .HasColumnName("ANIM_CHIP")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimCoat)
                    .HasColumnName("ANIM_COAT")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimCreateby)
                    .HasColumnName("ANIM_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimCreatedate)
                    .HasColumnName("ANIM_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnimId).HasColumnName("ANIM_ID");

                entity.Property(e => e.AnimName)
                    .HasColumnName("ANIM_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimRaceid).HasColumnName("ANIM_RACEID");

                entity.Property(e => e.AnimSex)
                    .HasColumnName("ANIM_SEX")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimSpeciesid).HasColumnName("ANIM_SPECIESID");

                entity.Property(e => e.AnimUpdateby)
                    .HasColumnName("ANIM_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimUpdatedate)
                    .HasColumnName("ANIM_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AnimRace)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.AnimRaceid)
                    .HasConstraintName("FK_Animal_RaceId_01");

                entity.HasOne(d => d.AnimSpecies)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.AnimSpeciesid)
                    .HasConstraintName("FK_Animal_SpieciesId_01");
            });

            modelBuilder.Entity<AnimalRace>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__AnimalRa__97BD02EB331B1782");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.AnimracCreateby)
                    .HasColumnName("ANIMRAC_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimracCreatedate)
                    .HasColumnName("ANIMRAC_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnimracDesc)
                    .HasColumnName("ANIMRAC_DESC")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimracImg01)
                    .HasColumnName("ANIMRAC_IMG01")
                    .HasMaxLength(500);

                entity.Property(e => e.AnimracName)
                    .HasColumnName("ANIMRAC_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimracNoteused).HasColumnName("ANIMRAC_NOTEUSED");

                entity.Property(e => e.AnimracSpieciesid).HasColumnName("ANIMRAC_SPIECIESID");

                entity.Property(e => e.AnimracUpdateby)
                    .HasColumnName("ANIMRAC_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimracUpdatedate)
                    .HasColumnName("ANIMRAC_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<AnimalSpecies>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__AnimalSp__97BD02EBCBDC6B70");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.AnimspiecCreateby)
                    .HasColumnName("ANIMSPIEC_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimspiecCreatedate)
                    .HasColumnName("ANIMSPIEC_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnimspiecDesc)
                    .HasColumnName("ANIMSPIEC_DESC")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimspiecImg01)
                    .HasColumnName("ANIMSPIEC_IMG01")
                    .HasMaxLength(500);

                entity.Property(e => e.AnimspiecName)
                    .HasColumnName("ANIMSPIEC_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimspiecNoteused).HasColumnName("ANIMSPIEC_NOTEUSED");

                entity.Property(e => e.AnimspiecUpdateby)
                    .HasColumnName("ANIMSPIEC_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimspiecUpdatedate)
                    .HasColumnName("ANIMSPIEC_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<AssortPrice>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__AssortPr__97BD02EBE7CE2047");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.AsspriceAssortid).HasColumnName("ASSPRICE_ASSORTID");

                entity.Property(e => e.AsspriceCreateby)
                    .HasColumnName("ASSPRICE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AsspriceCreatedate)
                    .HasColumnName("ASSPRICE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AsspriceDate)
                    .HasColumnName("ASSPRICE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AsspriceNotused).HasColumnName("ASSPRICE_NOTUSED");

                entity.Property(e => e.AsspriceOfficeid).HasColumnName("ASSPRICE_OFFICEID");

                entity.Property(e => e.AsspricePrice)
                    .HasColumnName("ASSPRICE_PRICE")
                    .HasColumnType("numeric(30, 2)");

                entity.Property(e => e.AsspriceUpdateby)
                    .HasColumnName("ASSPRICE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AsspriceUpdatedate)
                    .HasColumnName("ASSPRICE_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AsspriceVersion).HasColumnName("ASSPRICE_VERSION");

                entity.HasOne(d => d.AsspriceAssort)
                    .WithMany(p => p.AssortPrice)
                    .HasForeignKey(d => d.AsspriceAssortid)
                    .HasConstraintName("FK_Ass_Ass_0");

                entity.HasOne(d => d.AsspriceOffice)
                    .WithMany(p => p.AssortPrice)
                    .HasForeignKey(d => d.AsspriceOfficeid)
                    .HasConstraintName("FK_Ass_Office_01");
            });

            modelBuilder.Entity<AssortType>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__AssortTy__97BD02EB03BD6BE3");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.AsstypCode)
                    .HasColumnName("ASSTYP_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.AsstypDesc)
                    .HasColumnName("ASSTYP_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.AsstypNotused).HasColumnName("ASSTYP_NOTUSED");

                entity.Property(e => e.AsstypeCreateby)
                    .HasColumnName("ASSTYPE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AsstypeCreatedate)
                    .HasColumnName("ASSTYPE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AsstypeUpdateby)
                    .HasColumnName("ASSTYPE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AsstypeUpdatedate)
                    .HasColumnName("ASSTYPE_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Assortment>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Assortme__97BD02EB65FCA3D6");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.AssortCreateby)
                    .HasColumnName("ASSORT_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AssortCreatedate)
                    .HasColumnName("ASSORT_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssortDesc)
                    .HasColumnName("ASSORT_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.AssortName)
                    .HasColumnName("ASSORT_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.AssortPrescription).HasColumnName("ASSORT_PRESCRIPTION");

                entity.Property(e => e.AssortTypid).HasColumnName("ASSORT_TYPID");

                entity.Property(e => e.AssortUpdateby)
                    .HasColumnName("ASSORT_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.AssortUpdatedate)
                    .HasColumnName("ASSORT_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AssortTyp)
                    .WithMany(p => p.Assortment)
                    .HasForeignKey(d => d.AssortTypid)
                    .HasConstraintName("FK_Assort_TypeId_02");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Company__97BD02EBE3C0BE0F");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.CompCreateby)
                    .HasColumnName("COMP_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCreatedate)
                    .HasColumnName("COMP_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CompDesc)
                    .HasColumnName("COMP_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.CompFb)
                    .HasColumnName("COMP_FB")
                    .HasMaxLength(100);

                entity.Property(e => e.CompImg01)
                    .HasColumnName("COMP_IMG01")
                    .HasMaxLength(500);

                entity.Property(e => e.CompInsta)
                    .HasColumnName("COMP_INSTA")
                    .HasMaxLength(100);

                entity.Property(e => e.CompName)
                    .HasColumnName("COMP_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.CompOfficename)
                    .HasColumnName("COMP_OFFICENAME")
                    .HasMaxLength(100);

                entity.Property(e => e.CompPhone)
                    .HasColumnName("COMP_PHONE")
                    .HasMaxLength(50);

                entity.Property(e => e.CompTrade01).HasColumnName("COMP_TRADE01");

                entity.Property(e => e.CompTrade02).HasColumnName("COMP_TRADE02");

                entity.Property(e => e.CompTrade03).HasColumnName("COMP_TRADE03");

                entity.Property(e => e.CompTrade04).HasColumnName("COMP_TRADE04");

                entity.Property(e => e.CompTrade05).HasColumnName("COMP_TRADE05");

                entity.Property(e => e.CompTrade06).HasColumnName("COMP_TRADE06");

                entity.Property(e => e.CompTrade07).HasColumnName("COMP_TRADE07");

                entity.Property(e => e.CompTrade08).HasColumnName("COMP_TRADE08");

                entity.Property(e => e.CompTrade09).HasColumnName("COMP_TRADE09");

                entity.Property(e => e.CompTrade10).HasColumnName("COMP_TRADE10");

                entity.Property(e => e.CompTradedef).HasColumnName("COMP_TRADEDEF");

                entity.Property(e => e.CompUpdateby)
                    .HasColumnName("COMP_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.CompUpdatedate)
                    .HasColumnName("COMP_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CompWww)
                    .HasColumnName("COMP_WWW")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Customer__97BD02EBF465DC5A");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.CustAgree1).HasColumnName("CUST_AGREE1");

                entity.Property(e => e.CustAgree2).HasColumnName("CUST_AGREE2");

                entity.Property(e => e.CustAgree3).HasColumnName("CUST_AGREE3");

                entity.Property(e => e.CustAgree4).HasColumnName("CUST_AGREE4");

                entity.Property(e => e.CustAgree5).HasColumnName("CUST_AGREE5");

                entity.Property(e => e.CustBirthdate)
                    .HasColumnName("CUST_BIRTHDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustCity)
                    .HasColumnName("CUST_CITY")
                    .HasMaxLength(50);

                entity.Property(e => e.CustCitycode)
                    .HasColumnName("CUST_CITYCODE")
                    .HasMaxLength(50);

                entity.Property(e => e.CustCreateby)
                    .HasColumnName("CUST_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.CustCreatedate)
                    .HasColumnName("CUST_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustFirstname)
                    .HasColumnName("CUST_FIRSTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.CustFlat)
                    .HasColumnName("CUST_FLAT")
                    .HasMaxLength(50);

                entity.Property(e => e.CustHouse)
                    .HasColumnName("CUST_HOUSE")
                    .HasMaxLength(50);

                entity.Property(e => e.CustLastname)
                    .HasColumnName("CUST_LASTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.CustMail)
                    .HasColumnName("CUST_MAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.CustNotused).HasColumnName("CUST_NOTUSED");

                entity.Property(e => e.CustPhone)
                    .HasColumnName("CUST_PHONE")
                    .HasMaxLength(50);

                entity.Property(e => e.CustStreet)
                    .HasColumnName("CUST_STREET")
                    .HasMaxLength(50);

                entity.Property(e => e.CustUpdateby)
                    .HasColumnName("CUST_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.CustUpdatedate)
                    .HasColumnName("CUST_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CustomerAnimal>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Customer__97BD02EBAF9E7965");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.CustanimAnimalid).HasColumnName("CUSTANIM_ANIMALID");

                entity.Property(e => e.CustanimCreateby)
                    .HasColumnName("CUSTANIM_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.CustanimCreatedate)
                    .HasColumnName("CUSTANIM_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustanimCustomerid).HasColumnName("CUSTANIM_CUSTOMERID");

                entity.Property(e => e.CustanimUpdateby)
                    .HasColumnName("CUSTANIM_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.CustanimUpdatedate)
                    .HasColumnName("CUSTANIM_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CustanimAnimal)
                    .WithMany(p => p.CustomerAnimal)
                    .HasForeignKey(d => d.CustanimAnimalid)
                    .HasConstraintName("FK_Customer_Animal_01");

                entity.HasOne(d => d.CustanimCustomer)
                    .WithMany(p => p.CustomerAnimal)
                    .HasForeignKey(d => d.CustanimCustomerid)
                    .HasConstraintName("FK_Animal_Customer_02");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Employee__97BD02EBB5DCF592");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.EmplAccountenable).HasColumnName("EMPL_ACCOUNTENABLE");

                entity.Property(e => e.EmplAdress)
                    .HasColumnName("EMPL_ADRESS")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplBegindate)
                    .HasColumnName("EMPL_BEGINDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmplCreateby)
                    .HasColumnName("EMPL_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplCreatedate)
                    .HasColumnName("EMPL_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmplEmail)
                    .HasColumnName("EMPL_EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplGroupid).HasColumnName("EMPL_GROUPID");

                entity.Property(e => e.EmplLastname)
                    .HasColumnName("EMPL_LASTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplName)
                    .HasColumnName("EMPL_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplNotused).HasColumnName("EMPL_NOTUSED");

                entity.Property(e => e.EmplPesel).HasColumnName("EMPL_PESEL");

                entity.Property(e => e.EmplPhone)
                    .HasColumnName("EMPL_PHONE")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplPwz)
                    .HasColumnName("EMPL_PWZ")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplUpdateby)
                    .HasColumnName("EMPL_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplUpdatedate)
                    .HasColumnName("EMPL_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EmplGroup)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmplGroupid)
                    .HasConstraintName("FK_Employee_GruupID_01");
            });

            modelBuilder.Entity<EmployeeGroup>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Employee__97BD02EBB59C27A0");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.EmpgroupCode)
                    .HasColumnName("EMPGROUP_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.EmpgroupCreateby)
                    .HasColumnName("EMPGROUP_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpgroupCreatedate)
                    .HasColumnName("EMPGROUP_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpgroupDesc)
                    .HasColumnName("EMPGROUP_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.EmpgroupNotused).HasColumnName("EMPGROUP_NOTUSED");

                entity.Property(e => e.EmpgroupUpdateby)
                    .HasColumnName("EMPGROUP_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpgroupUpdatedate)
                    .HasColumnName("EMPGROUP_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeHoliday>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Employee__97BD02EBAFA187C1");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.EmpholiCreateby)
                    .HasColumnName("EMPHOLI_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpholiCreatedate)
                    .HasColumnName("EMPHOLI_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpholiDate)
                    .HasColumnName("EMPHOLI_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpholiEmpid).HasColumnName("EMPHOLI_EMPID");

                entity.Property(e => e.EmpholiNotused).HasColumnName("EMPHOLI_NOTUSED");

                entity.Property(e => e.EmpholiUpdateby)
                    .HasColumnName("EMPHOLI_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpholiUpdatedate)
                    .HasColumnName("EMPHOLI_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EmpholiEmp)
                    .WithMany(p => p.EmployeeHoliday)
                    .HasForeignKey(d => d.EmpholiEmpid)
                    .HasConstraintName("FK_Emp_Holiday_01");
            });

            modelBuilder.Entity<EmployeeOffice>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Employee__97BD02EB0F0A28C4");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.EmpofficeBegindate)
                    .HasColumnName("EMPOFFICE_BEGINDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpofficeCreateby)
                    .HasColumnName("EMPOFFICE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpofficeCreatedate)
                    .HasColumnName("EMPOFFICE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpofficeEmpid).HasColumnName("EMPOFFICE_EMPID");

                entity.Property(e => e.EmpofficeEnddate)
                    .HasColumnName("EMPOFFICE_ENDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpofficeNotused).HasColumnName("EMPOFFICE_NOTUSED");

                entity.Property(e => e.EmpofficeOfficeid).HasColumnName("EMPOFFICE_OFFICEID");

                entity.Property(e => e.EmpofficeUpdateby)
                    .HasColumnName("EMPOFFICE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpofficeUpdatedate)
                    .HasColumnName("EMPOFFICE_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EmpofficeEmp)
                    .WithMany(p => p.EmployeeOffice)
                    .HasForeignKey(d => d.EmpofficeEmpid)
                    .HasConstraintName("FK_EmployeeOffice_EMPID_01");

                entity.HasOne(d => d.EmpofficeOffice)
                    .WithMany(p => p.EmployeeOffice)
                    .HasForeignKey(d => d.EmpofficeOfficeid)
                    .HasConstraintName("FK_EmployeeOffice_OFFICEID_01");
            });

            modelBuilder.Entity<EmployeeOpenHour>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Employee__97BD02EB493BE12B");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.EmplopenBegindate)
                    .HasColumnName("EMPLOPEN_BEGINDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmplopenCreateby)
                    .HasColumnName("EMPLOPEN_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplopenCreatedate)
                    .HasColumnName("EMPLOPEN_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmplopenEmpid).HasColumnName("EMPLOPEN_EMPID");

                entity.Property(e => e.EmplopenEnddate)
                    .HasColumnName("EMPLOPEN_ENDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmplopenFlag).HasColumnName("EMPLOPEN_FLAG");

                entity.Property(e => e.EmplopenNotused).HasColumnName("EMPLOPEN_NOTUSED");

                entity.Property(e => e.EmplopenUpdateby)
                    .HasColumnName("EMPLOPEN_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmplopenUpdatedate)
                    .HasColumnName("EMPLOPEN_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EmplopenEmp)
                    .WithMany(p => p.EmployeeOpenHour)
                    .HasForeignKey(d => d.EmplopenEmpid)
                    .HasConstraintName("FK_Emp_OpenHouer_02");
            });

            modelBuilder.Entity<EmployeeService>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Employee__97BD02EBF04D7A8D");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.EmpserviceCreateby)
                    .HasColumnName("EMPSERVICE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpserviceCreatedate)
                    .HasColumnName("EMPSERVICE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpserviceEmploeeyid).HasColumnName("EMPSERVICE_EMPLOEEYID");

                entity.Property(e => e.EmpserviceNotused).HasColumnName("EMPSERVICE_NOTUSED");

                entity.Property(e => e.EmpserviceServiceid).HasColumnName("EMPSERVICE_SERVICEID");

                entity.Property(e => e.EmpserviceUpdateby)
                    .HasColumnName("EMPSERVICE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpserviceUpdatedate)
                    .HasColumnName("EMPSERVICE_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EmpserviceEmploeey)
                    .WithMany(p => p.EmployeeService)
                    .HasForeignKey(d => d.EmpserviceEmploeeyid)
                    .HasConstraintName("FK_Service_Emploeey_02");

                entity.HasOne(d => d.EmpserviceService)
                    .WithMany(p => p.EmployeeService)
                    .HasForeignKey(d => d.EmpserviceServiceid)
                    .HasConstraintName("FK_Service_Emploeey_01");
            });

            modelBuilder.Entity<Equipemnt>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Equipemn__97BD02EB647ABC7D");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.EquipCreateby)
                    .HasColumnName("EQUIP_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EquipCreatedate)
                    .HasColumnName("EQUIP_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EquipDesc)
                    .HasColumnName("EQUIP_DESC")
                    .HasMaxLength(250);

                entity.Property(e => e.EquipName)
                    .HasColumnName("EQUIP_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.EquipOfficeid).HasColumnName("EQUIP_OFFICEID");

                entity.Property(e => e.EquipSerialnum)
                    .HasColumnName("EQUIP_SERIALNUM")
                    .HasMaxLength(50);

                entity.Property(e => e.EquipTypeid).HasColumnName("EQUIP_TYPEID");

                entity.Property(e => e.EquipUpdateby)
                    .HasColumnName("EQUIP_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EquipUpdatedate)
                    .HasColumnName("EQUIP_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EquipWarrantydata)
                    .HasColumnName("EQUIP_WARRANTYDATA")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EquipOffice)
                    .WithMany(p => p.Equipemnt)
                    .HasForeignKey(d => d.EquipOfficeid)
                    .HasConstraintName("FK_Equipemnt_Office_01");

                entity.HasOne(d => d.EquipType)
                    .WithMany(p => p.Equipemnt)
                    .HasForeignKey(d => d.EquipTypeid)
                    .HasConstraintName("FK_Equipemnt_Type_01");
            });

            modelBuilder.Entity<EquipemntType>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Equipemn__97BD02EB01D291F4");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.EquiptypeCode)
                    .HasColumnName("EQUIPTYPE_CODE")
                    .HasMaxLength(50);

                entity.Property(e => e.EquiptypeCreateby)
                    .HasColumnName("EQUIPTYPE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EquiptypeCreatedate)
                    .HasColumnName("EQUIPTYPE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EquiptypeDesc)
                    .HasColumnName("EQUIPTYPE_DESC")
                    .HasMaxLength(200);

                entity.Property(e => e.EquiptypeNotused).HasColumnName("EQUIPTYPE_NOTUSED");

                entity.Property(e => e.EquiptypeUpdateby)
                    .HasColumnName("EQUIPTYPE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.EquiptypeUpdatedate)
                    .HasColumnName("EQUIPTYPE_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Invoice__97BD02EB23F4F080");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.InvCode)
                    .HasColumnName("INV_CODE")
                    .HasMaxLength(100);

                entity.Property(e => e.InvCost)
                    .HasColumnName("INV_COST")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.InvCreateby)
                    .HasColumnName("INV_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.InvCreatedate)
                    .HasColumnName("INV_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvCustomeranimalid).HasColumnName("INV_CUSTOMERANIMALID");

                entity.Property(e => e.InvEmpid).HasColumnName("INV_EMPID");

                entity.Property(e => e.InvMethodpayid).HasColumnName("INV_METHODPAYID");

                entity.Property(e => e.InvOfficeid).HasColumnName("INV_OFFICEID");

                entity.Property(e => e.InvStatus).HasColumnName("INV_STATUS");

                entity.Property(e => e.InvUpdateby)
                    .HasColumnName("INV_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.InvUpdatedate)
                    .HasColumnName("INV_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvVisitid).HasColumnName("INV_VISITID");

                entity.HasOne(d => d.InvCustomeranimal)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvCustomeranimalid)
                    .HasConstraintName("FK_CustomerAnimal_Invoice_01");

                entity.HasOne(d => d.InvEmp)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvEmpid)
                    .HasConstraintName("FK_Emp_Invoice_01");

                entity.HasOne(d => d.InvMethodpay)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvMethodpayid)
                    .HasConstraintName("FK_PayMethod_Invoice_01");

                entity.HasOne(d => d.InvVisit)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvVisitid)
                    .HasConstraintName("FK_Visit_Invoice_01");
            });

            modelBuilder.Entity<InvoiceAssortment>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__InvoiceA__97BD02EBDD4C4715");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.InvassortAssortid).HasColumnName("INVASSORT_ASSORTID");

                entity.Property(e => e.InvassortCreateby)
                    .HasColumnName("INVASSORT_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.InvassortCreatedate)
                    .HasColumnName("INVASSORT_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvassortDiscount).HasColumnName("INVASSORT_DISCOUNT");

                entity.Property(e => e.InvassortFreq).HasColumnName("INVASSORT_FREQ");

                entity.Property(e => e.InvassortHowlong).HasColumnName("INVASSORT_HOWLONG");

                entity.Property(e => e.InvassortInvoiceid).HasColumnName("INVASSORT_INVOICEID");

                entity.Property(e => e.InvassortNotused).HasColumnName("INVASSORT_NOTUSED");

                entity.Property(e => e.InvassortPortion)
                    .HasColumnName("INVASSORT_PORTION")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.InvassortQty)
                    .HasColumnName("INVASSORT_QTY")
                    .HasColumnType("numeric(36, 2)");

                entity.Property(e => e.InvassortUpdateby)
                    .HasColumnName("INVASSORT_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.InvassortUpdatedate)
                    .HasColumnName("INVASSORT_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.InvassortAssort)
                    .WithMany(p => p.InvoiceAssortment)
                    .HasForeignKey(d => d.InvassortAssortid)
                    .HasConstraintName("FK_Assortment_Invoice_01");

                entity.HasOne(d => d.InvassortInvoice)
                    .WithMany(p => p.InvoiceAssortment)
                    .HasForeignKey(d => d.InvassortInvoiceid)
                    .HasConstraintName("FK_Invoice_02");
            });

            modelBuilder.Entity<InvoiceService>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__InvoiceS__97BD02EBBBCEBBE7");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.InvserviceCreateby)
                    .HasColumnName("INVSERVICE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.InvserviceCreatedate)
                    .HasColumnName("INVSERVICE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvserviceDiscount).HasColumnName("INVSERVICE_DISCOUNT");

                entity.Property(e => e.InvserviceInvoiceid).HasColumnName("INVSERVICE_INVOICEID");

                entity.Property(e => e.InvserviceNotused).HasColumnName("INVSERVICE_NOTUSED");

                entity.Property(e => e.InvserviceQty)
                    .HasColumnName("INVSERVICE_QTY")
                    .HasColumnType("numeric(36, 2)");

                entity.Property(e => e.InvserviceServiceid).HasColumnName("INVSERVICE_SERVICEID");

                entity.Property(e => e.InvserviceUpdateby)
                    .HasColumnName("INVSERVICE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.InvserviceUpdatedate)
                    .HasColumnName("INVSERVICE_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.InvserviceInvoice)
                    .WithMany(p => p.InvoiceService)
                    .HasForeignKey(d => d.InvserviceInvoiceid)
                    .HasConstraintName("FK_Invoice_03");
            });

            modelBuilder.Entity<MethodPay>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__MethodPa__97BD02EB4E2EEBA5");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.MetpayCode)
                    .HasColumnName("METPAY_CODE")
                    .HasMaxLength(50);

                entity.Property(e => e.MetpayCreateby)
                    .HasColumnName("METPAY_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.MetpayCreatedate)
                    .HasColumnName("METPAY_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MetpayDay).HasColumnName("METPAY_DAY");

                entity.Property(e => e.MetpayNotused).HasColumnName("METPAY_NOTUSED");

                entity.Property(e => e.MetpayUpdateby)
                    .HasColumnName("METPAY_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.MetpayUpdatedate)
                    .HasColumnName("METPAY_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Office__97BD02EBE6BD5054");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.OfficeCity)
                    .HasColumnName("OFFICE_CITY")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeCitycode)
                    .HasColumnName("OFFICE_CITYCODE")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeCompanyid).HasColumnName("OFFICE_COMPANYID");

                entity.Property(e => e.OfficeCreateby)
                    .HasColumnName("OFFICE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeCreatedate)
                    .HasColumnName("OFFICE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OfficeEmail)
                    .HasColumnName("OFFICE_EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeFlat)
                    .HasColumnName("OFFICE_FLAT")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeHouse)
                    .HasColumnName("OFFICE_HOUSE")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeNotused).HasColumnName("OFFICE_NOTUSED");

                entity.Property(e => e.OfficePhone)
                    .HasColumnName("OFFICE_PHONE")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeStreet)
                    .HasColumnName("OFFICE_STREET")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeUpdateby)
                    .HasColumnName("OFFICE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeUpdatedate)
                    .HasColumnName("OFFICE_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.OfficeCompany)
                    .WithMany(p => p.Office)
                    .HasForeignKey(d => d.OfficeCompanyid)
                    .HasConstraintName("FK_Office_Company_01");
            });

            modelBuilder.Entity<OfficeCustomer>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__OfficeCu__97BD02EBCA0133EB");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.OffcustomCreateby)
                    .HasColumnName("OFFCUSTOM_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.OffcustomCreatedate)
                    .HasColumnName("OFFCUSTOM_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffcustomCustomerid).HasColumnName("OFFCUSTOM_CUSTOMERID");

                entity.Property(e => e.OffcustomNotused).HasColumnName("OFFCUSTOM_NOTUSED");

                entity.Property(e => e.OffcustomOfficeid).HasColumnName("OFFCUSTOM_OFFICEID");

                entity.Property(e => e.OffcustomUpdateby)
                    .HasColumnName("OFFCUSTOM_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.OffcustomUpdatedate)
                    .HasColumnName("OFFCUSTOM_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.OffcustomCustomer)
                    .WithMany(p => p.OfficeCustomer)
                    .HasForeignKey(d => d.OffcustomCustomerid)
                    .HasConstraintName("FK_Customer_Office_01");

                entity.HasOne(d => d.OffcustomOffice)
                    .WithMany(p => p.OfficeCustomer)
                    .HasForeignKey(d => d.OffcustomOfficeid)
                    .HasConstraintName("FK_Customer_Office_02");
            });

            modelBuilder.Entity<OfficeHoliday>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__OfficeHo__97BD02EBFE7DABC3");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.OffholiCreateby)
                    .HasColumnName("OFFHOLI_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.OffholiCreatedate)
                    .HasColumnName("OFFHOLI_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffholiDate)
                    .HasColumnName("OFFHOLI_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffholiNotused).HasColumnName("OFFHOLI_NOTUSED");

                entity.Property(e => e.OffholiOfficeid).HasColumnName("OFFHOLI_OFFICEID");

                entity.Property(e => e.OffholiUpdateby)
                    .HasColumnName("OFFHOLI_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.OffholiUpdatedate)
                    .HasColumnName("OFFHOLI_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.OffholiOffice)
                    .WithMany(p => p.OfficeHoliday)
                    .HasForeignKey(d => d.OffholiOfficeid)
                    .HasConstraintName("FK_Office_Holiday_01");
            });

            modelBuilder.Entity<OfficeOpenHour>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__OfficeOp__97BD02EB0BCC8D99");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.OffopenBegindate)
                    .HasColumnName("OFFOPEN_BEGINDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffopenCreateby)
                    .HasColumnName("OFFOPEN_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.OffopenCreatedate)
                    .HasColumnName("OFFOPEN_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffopenEnddate)
                    .HasColumnName("OFFOPEN_ENDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffopenFlag).HasColumnName("OFFOPEN_FLAG");

                entity.Property(e => e.OffopenNotused).HasColumnName("OFFOPEN_NOTUSED");

                entity.Property(e => e.OffopenOfficeid).HasColumnName("OFFOPEN_OFFICEID");

                entity.Property(e => e.OffopenUpdateby)
                    .HasColumnName("OFFOPEN_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.OffopenUpdatedate)
                    .HasColumnName("OFFOPEN_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffopenWeekday).HasColumnName("OFFOPEN_WEEKDAY");

                entity.HasOne(d => d.OffopenOffice)
                    .WithMany(p => p.OfficeOpenHour)
                    .HasForeignKey(d => d.OffopenOfficeid)
                    .HasConstraintName("FK_Office_OpenHouer_01");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Reservat__97BD02EB169A7E70");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.ReservAnimalid).HasColumnName("RESERV_ANIMALID");

                entity.Property(e => e.ReservCreateby)
                    .HasColumnName("RESERV_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.ReservCreatedate)
                    .HasColumnName("RESERV_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReservDate)
                    .HasColumnName("RESERV_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReservEmpid).HasColumnName("RESERV_EMPID");

                entity.Property(e => e.ReservNotused).HasColumnName("RESERV_NOTUSED");

                entity.Property(e => e.ReservOfficeid).HasColumnName("RESERV_OFFICEID");

                entity.Property(e => e.ReservStatus)
                    .HasColumnName("RESERV_STATUS")
                    .HasMaxLength(30);

                entity.Property(e => e.ReservUpdateby)
                    .HasColumnName("RESERV_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.ReservUpdatedate)
                    .HasColumnName("RESERV_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ReservationService>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Reservat__97BD02EB00BAF5D8");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.ReserserviceCreateby)
                    .HasColumnName("RESERSERVICE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.ReserserviceCreatedate)
                    .HasColumnName("RESERSERVICE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReserserviceNotused).HasColumnName("RESERSERVICE_NOTUSED");

                entity.Property(e => e.ReserserviceReservationid).HasColumnName("RESERSERVICE_RESERVATIONID");

                entity.Property(e => e.ReserserviceServiceid).HasColumnName("RESERSERVICE_SERVICEID");

                entity.Property(e => e.ReserserviceUpdateby)
                    .HasColumnName("RESERSERVICE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.ReserserviceUpdatedate)
                    .HasColumnName("RESERSERVICE_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ReserserviceReservation)
                    .WithMany(p => p.ReservationService)
                    .HasForeignKey(d => d.ReserserviceReservationid)
                    .HasConstraintName("FK_Reservation_Service_01");
            });

            modelBuilder.Entity<Servic>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Servic__97BD02EB5287B434");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.ServicCost)
                    .HasColumnName("SERVIC_COST")
                    .HasColumnType("numeric(30, 2)");

                entity.Property(e => e.ServicCreateby)
                    .HasColumnName("SERVIC_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.ServicCreatedate)
                    .HasColumnName("SERVIC_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServicDesc)
                    .HasColumnName("SERVIC_DESC")
                    .HasMaxLength(50);

                entity.Property(e => e.ServicDuration)
                    .HasColumnName("SERVIC_DURATION")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ServicName)
                    .HasColumnName("SERVIC_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.ServicNotused).HasColumnName("SERVIC_NOTUSED");

                entity.Property(e => e.ServicOfficeid).HasColumnName("SERVIC_OFFICEID");

                entity.Property(e => e.ServicTaxid).HasColumnName("SERVIC_TAXID");

                entity.Property(e => e.ServicTypeid).HasColumnName("SERVIC_TYPEID");

                entity.Property(e => e.ServicUpdateby)
                    .HasColumnName("SERVIC_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.ServicUpdatedate)
                    .HasColumnName("SERVIC_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ServicTax)
                    .WithMany(p => p.Servic)
                    .HasForeignKey(d => d.ServicTaxid)
                    .HasConstraintName("FK_Service_Tax_01");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__ServiceT__97BD02EB659D82F1");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.ServicetypCode)
                    .HasColumnName("SERVICETYP_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.ServicetypDesc)
                    .HasColumnName("SERVICETYP_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.ServicetypNotused).HasColumnName("SERVICETYP_NOTUSED");

                entity.Property(e => e.ServicetypeCreateby)
                    .HasColumnName("SERVICETYPE_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.ServicetypeCreatedate)
                    .HasColumnName("SERVICETYPE_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServicetypeUpdateby)
                    .HasColumnName("SERVICETYPE_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.ServicetypeUpdatedate)
                    .HasColumnName("SERVICETYPE_UPDATEDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Tax__97BD02EB79D5205E");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.TaxCode)
                    .HasColumnName("TAX_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.TaxCreateby)
                    .HasColumnName("TAX_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxCreatedate)
                    .HasColumnName("TAX_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaxNotused).HasColumnName("TAX_NOTUSED");

                entity.Property(e => e.TaxUpdateby)
                    .HasColumnName("TAX_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxUpdatedate)
                    .HasColumnName("TAX_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaxValue)
                    .HasColumnName("TAX_VALUE")
                    .HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasKey(e => e.Rowid)
                    .HasName("PK__Visit__97BD02EB5C018E57");

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.VisCreateby)
                    .HasColumnName("VIS_CREATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.VisCreatedate)
                    .HasColumnName("VIS_CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisInfo).HasColumnName("VIS_INFO");

                entity.Property(e => e.VisInterview).HasColumnName("VIS_INTERVIEW");

                entity.Property(e => e.VisNote).HasColumnName("VIS_NOTE");

                entity.Property(e => e.VisSendcheck).HasColumnName("VIS_SENDCHECK");

                entity.Property(e => e.VisTreatdesc).HasColumnName("VIS_TREATDESC");

                entity.Property(e => e.VisUpdateby)
                    .HasColumnName("VIS_UPDATEBY")
                    .HasMaxLength(50);

                entity.Property(e => e.VisUpdatedate)
                    .HasColumnName("VIS_UPDATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisWeight)
                    .HasColumnName("VIS_WEIGHT")
                    .HasColumnType("numeric(10, 2)");
            });
        }
    }
}
