using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetVET.Database.Models
{
    public partial class PetVetDbContext : DbContext
    {
        public PetVetDbContext(DbContextOptions<PetVetDbContext> options) : base(options)
        { }

        public virtual DbSet<Assortment> Assortment { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAnimal> CustomerAnimal { get; set; }
        public virtual DbSet<DepartmentVetHarm> DepartmentVetHarm { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<OfficeDepartment> OfficeDepartment { get; set; }
        public virtual DbSet<OfficeDepartmentVet> OfficeDepartmentVet { get; set; }
        public virtual DbSet<Treatment> Treatment { get; set; }
        public virtual DbSet<Typ1> Typ1 { get; set; }
        public virtual DbSet<Typ2> Typ2 { get; set; }
        public virtual DbSet<VarPkwiu> VarPkwiu { get; set; }
        public virtual DbSet<VarTypOfPay> VarTypOfPay { get; set; }
        public virtual DbSet<Vet> Vet { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        public virtual DbSet<VisitMedicines> VisitMedicines { get; set; }
        public virtual DbSet<VisitTreatment> VisitTreatment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assortment>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.AssCode)
                    .HasColumnName("ASS_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.AssCredate)
                    .HasColumnName("ASS_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssCreuser)
                    .HasColumnName("ASS_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.AssDesc)
                    .HasColumnName("ASS_DESC")
                    .HasMaxLength(400);

                entity.Property(e => e.AssDtx01)
                    .HasColumnName("ASS_DTX01")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssDtx02)
                    .HasColumnName("ASS_DTX02")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssDtx03)
                    .HasColumnName("ASS_DTX03")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssDtx04)
                    .HasColumnName("ASS_DTX04")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssDtx05)
                    .HasColumnName("ASS_DTX05")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssModdate)
                    .HasColumnName("ASS_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssModuser)
                    .HasColumnName("ASS_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.AssNotused).HasColumnName("ASS_NOTUSED");

                entity.Property(e => e.AssNtx01)
                    .HasColumnName("ASS_NTX01")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.AssNtx02)
                    .HasColumnName("ASS_NTX02")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.AssNtx03)
                    .HasColumnName("ASS_NTX03")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.AssNtx04)
                    .HasColumnName("ASS_NTX04")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.AssNtx05)
                    .HasColumnName("ASS_NTX05")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.AssOdtid).HasColumnName("ASS_ODTID");

                entity.Property(e => e.AssTxt01)
                    .HasColumnName("ASS_TXT01")
                    .HasMaxLength(50);

                entity.Property(e => e.AssTxt02)
                    .HasColumnName("ASS_TXT02")
                    .HasMaxLength(50);

                entity.Property(e => e.AssTxt03)
                    .HasColumnName("ASS_TXT03")
                    .HasMaxLength(50);

                entity.Property(e => e.AssTxt04)
                    .HasColumnName("ASS_TXT04")
                    .HasMaxLength(50);

                entity.Property(e => e.AssTxt05)
                    .HasColumnName("ASS_TXT05")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AssOdt)
                    .WithMany(p => p.Assortment)
                    .HasForeignKey(d => d.AssOdtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeDepartment_ASS");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.CusAddress)
                    .HasColumnName("CUS_ADDRESS")
                    .HasMaxLength(300);

                entity.Property(e => e.CusApproval).HasColumnName("CUS_APPROVAL");

                entity.Property(e => e.CusApprovalnum)
                    .HasColumnName("CUS_APPROVALNUM")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CusCity)
                    .HasColumnName("CUS_CITY")
                    .HasMaxLength(50);

                entity.Property(e => e.CusCredate)
                    .HasColumnName("CUS_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CusCreuser)
                    .HasColumnName("CUS_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.CusDtx01)
                    .HasColumnName("CUS_DTX01")
                    .HasColumnType("datetime");

                entity.Property(e => e.CusDtx02)
                    .HasColumnName("CUS_DTX02")
                    .HasColumnType("datetime");

                entity.Property(e => e.CusDtx03)
                    .HasColumnName("CUS_DTX03")
                    .HasColumnType("datetime");

                entity.Property(e => e.CusDtx04)
                    .HasColumnName("CUS_DTX04")
                    .HasColumnType("datetime");

                entity.Property(e => e.CusDtx05)
                    .HasColumnName("CUS_DTX05")
                    .HasColumnType("datetime");

                entity.Property(e => e.CusEmail)
                    .HasColumnName("CUS_EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.CusEmail2)
                    .HasColumnName("CUS_EMAIL2")
                    .HasMaxLength(255);

                entity.Property(e => e.CusLastname)
                    .HasColumnName("CUS_LASTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.CusModdate)
                    .HasColumnName("CUS_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CusModuser)
                    .HasColumnName("CUS_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.CusName)
                    .HasColumnName("CUS_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.CusNotused).HasColumnName("CUS_NOTUSED");

                entity.Property(e => e.CusNtx01)
                    .HasColumnName("CUS_NTX01")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.CusNtx02)
                    .HasColumnName("CUS_NTX02")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.CusNtx03)
                    .HasColumnName("CUS_NTX03")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.CusNtx04)
                    .HasColumnName("CUS_NTX04")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.CusNtx05)
                    .HasColumnName("CUS_NTX05")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.CusPhone)
                    .HasColumnName("CUS_PHONE")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.CusPhone2)
                    .HasColumnName("CUS_PHONE2")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.CusTxt01)
                    .HasColumnName("CUS_TXT01")
                    .HasMaxLength(50);

                entity.Property(e => e.CusTxt02)
                    .HasColumnName("CUS_TXT02")
                    .HasMaxLength(50);

                entity.Property(e => e.CusTxt03)
                    .HasColumnName("CUS_TXT03")
                    .HasMaxLength(50);

                entity.Property(e => e.CusTxt04)
                    .HasColumnName("CUS_TXT04")
                    .HasMaxLength(50);

                entity.Property(e => e.CusTxt05)
                    .HasColumnName("CUS_TXT05")
                    .HasMaxLength(50);

                entity.Property(e => e.CusZipcode)
                    .HasColumnName("CUS_ZIPCODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerAnimal>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.CalBirthdate)
                    .HasColumnName("CAL_BIRTHDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CalCastrated).HasColumnName("CAL_CASTRATED");

                entity.Property(e => e.CalChip)
                    .HasColumnName("CAL_CHIP")
                    .HasMaxLength(100);

                entity.Property(e => e.CalColor)
                    .HasColumnName("CAL_COLOR")
                    .HasMaxLength(30);

                entity.Property(e => e.CalCredate)
                    .HasColumnName("CAL_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CalCreuser)
                    .HasColumnName("CAL_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.CalCustomerid).HasColumnName("CAL_CUSTOMERID");

                entity.Property(e => e.CalDeath).HasColumnName("CAL_DEATH");

                entity.Property(e => e.CalDescription).HasColumnName("CAL_DESCRIPTION");

                entity.Property(e => e.CalImg01)
                    .HasColumnName("CAL_IMG01")
                    .HasMaxLength(36);

                entity.Property(e => e.CalModdate)
                    .HasColumnName("CAL_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CalModuser)
                    .HasColumnName("CAL_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.CalName)
                    .IsRequired()
                    .HasColumnName("CAL_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.CalNotused).HasColumnName("CAL_NOTUSED");

                entity.Property(e => e.CalSex)
                    .HasColumnName("CAL_SEX")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CalTyp1).HasColumnName("CAL_TYP1");

                entity.Property(e => e.CalTyp2).HasColumnName("CAL_TYP2");

                entity.HasOne(d => d.CalCustomer)
                    .WithMany(p => p.CustomerAnimal)
                    .HasForeignKey(d => d.CalCustomerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VET3");

                entity.HasOne(d => d.CalTyp1Navigation)
                    .WithMany(p => p.CustomerAnimal)
                    .HasForeignKey(d => d.CalTyp1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYP1");

                entity.HasOne(d => d.CalTyp2Navigation)
                    .WithMany(p => p.CustomerAnimal)
                    .HasForeignKey(d => d.CalTyp2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYP2");
            });

            modelBuilder.Entity<DepartmentVetHarm>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.DvhBegin)
                    .HasColumnName("DVH_BEGIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.DvhCredate)
                    .HasColumnName("DVH_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DvhCreuser)
                    .HasColumnName("DVH_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.DvhDepartmentid).HasColumnName("DVH_DEPARTMENTID");

                entity.Property(e => e.DvhEnd)
                    .HasColumnName("DVH_END")
                    .HasColumnType("datetime");

                entity.Property(e => e.DvhModdate)
                    .HasColumnName("DVH_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DvhModuser)
                    .HasColumnName("DVH_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.DvhNotused).HasColumnName("DVH_NOTUSED");

                entity.Property(e => e.DvhVet).HasColumnName("DVH_VET");

                entity.HasOne(d => d.DvhDepartment)
                    .WithMany(p => p.DepartmentVetHarm)
                    .HasForeignKey(d => d.DvhDepartmentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEP");

                entity.HasOne(d => d.DvhVetNavigation)
                    .WithMany(p => p.DepartmentVetHarm)
                    .HasForeignKey(d => d.DvhVet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VET2");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.InvCode)
                    .HasColumnName("INV_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.InvCredate)
                    .HasColumnName("INV_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvCreuser)
                    .HasColumnName("INV_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.InvDate)
                    .HasColumnName("INV_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvModdate)
                    .HasColumnName("INV_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvModuser)
                    .HasColumnName("INV_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.InvNotused).HasColumnName("INV_NOTUSED");

                entity.Property(e => e.InvSelldate)
                    .HasColumnName("INV_SELLDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvTypid).HasColumnName("INV_TYPID");

                entity.Property(e => e.InvVisit).HasColumnName("INV_VISIT");

                entity.HasOne(d => d.InvTyp)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvTypid)
                    .HasConstraintName("FK_INV_TYPPAY");

                entity.HasOne(d => d.InvVisitNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvVisit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INV_VISIT");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.OffAddress)
                    .HasColumnName("OFF_ADDRESS")
                    .HasMaxLength(300);

                entity.Property(e => e.OffCity)
                    .HasColumnName("OFF_CITY")
                    .HasMaxLength(50);

                entity.Property(e => e.OffCredate)
                    .HasColumnName("OFF_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffCreuser)
                    .HasColumnName("OFF_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.OffDescription)
                    .IsRequired()
                    .HasColumnName("OFF_DESCRIPTION")
                    .HasMaxLength(250);

                entity.Property(e => e.OffDtx01)
                    .HasColumnName("OFF_DTX01")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffDtx02)
                    .HasColumnName("OFF_DTX02")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffDtx03)
                    .HasColumnName("OFF_DTX03")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffDtx04)
                    .HasColumnName("OFF_DTX04")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffDtx05)
                    .HasColumnName("OFF_DTX05")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffImg01)
                    .HasColumnName("OFF_IMG01")
                    .HasMaxLength(36);

                entity.Property(e => e.OffModdate)
                    .HasColumnName("OFF_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OffModuser)
                    .HasColumnName("OFF_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.OffNip)
                    .HasColumnName("OFF_NIP")
                    .HasMaxLength(14);

                entity.Property(e => e.OffNotused).HasColumnName("OFF_NOTUSED");

                entity.Property(e => e.OffNtx01)
                    .HasColumnName("OFF_NTX01")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OffNtx02)
                    .HasColumnName("OFF_NTX02")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OffNtx03)
                    .HasColumnName("OFF_NTX03")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OffNtx04)
                    .HasColumnName("OFF_NTX04")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OffNtx05)
                    .HasColumnName("OFF_NTX05")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OffRegon)
                    .HasColumnName("OFF_REGON")
                    .HasMaxLength(9);

                entity.Property(e => e.OffTxt01)
                    .HasColumnName("OFF_TXT01")
                    .HasMaxLength(50);

                entity.Property(e => e.OffTxt02)
                    .HasColumnName("OFF_TXT02")
                    .HasMaxLength(50);

                entity.Property(e => e.OffTxt03)
                    .HasColumnName("OFF_TXT03")
                    .HasMaxLength(50);

                entity.Property(e => e.OffTxt04)
                    .HasColumnName("OFF_TXT04")
                    .HasMaxLength(50);

                entity.Property(e => e.OffTxt05)
                    .HasColumnName("OFF_TXT05")
                    .HasMaxLength(50);

                entity.Property(e => e.OffZipcode)
                    .HasColumnName("OFF_ZIPCODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OfficeDepartment>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.OdtAddress)
                    .HasColumnName("ODT_ADDRESS")
                    .HasMaxLength(300);

                entity.Property(e => e.OdtCity)
                    .HasColumnName("ODT_CITY")
                    .HasMaxLength(50);

                entity.Property(e => e.OdtCredate)
                    .HasColumnName("ODT_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdtCreuser)
                    .HasColumnName("ODT_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.OdtDescription)
                    .HasColumnName("ODT_DESCRIPTION")
                    .HasMaxLength(250);

                entity.Property(e => e.OdtDtx01)
                    .HasColumnName("ODT_DTX01")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdtDtx02)
                    .HasColumnName("ODT_DTX02")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdtDtx03)
                    .HasColumnName("ODT_DTX03")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdtDtx04)
                    .HasColumnName("ODT_DTX04")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdtDtx05)
                    .HasColumnName("ODT_DTX05")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdtEmail)
                    .HasColumnName("ODT_EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.OdtModdate)
                    .HasColumnName("ODT_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdtModuser)
                    .HasColumnName("ODT_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.OdtNotused).HasColumnName("ODT_NOTUSED");

                entity.Property(e => e.OdtNtx01)
                    .HasColumnName("ODT_NTX01")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OdtNtx02)
                    .HasColumnName("ODT_NTX02")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OdtNtx03)
                    .HasColumnName("ODT_NTX03")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OdtNtx04)
                    .HasColumnName("ODT_NTX04")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OdtNtx05)
                    .HasColumnName("ODT_NTX05")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.OdtOfficeid).HasColumnName("ODT_OFFICEID");

                entity.Property(e => e.OdtPhone)
                    .HasColumnName("ODT_PHONE")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.OdtTxt01)
                    .HasColumnName("ODT_TXT01")
                    .HasMaxLength(50);

                entity.Property(e => e.OdtTxt02)
                    .HasColumnName("ODT_TXT02")
                    .HasMaxLength(50);

                entity.Property(e => e.OdtTxt03)
                    .HasColumnName("ODT_TXT03")
                    .HasMaxLength(50);

                entity.Property(e => e.OdtTxt04)
                    .HasColumnName("ODT_TXT04")
                    .HasMaxLength(50);

                entity.Property(e => e.OdtTxt05)
                    .HasColumnName("ODT_TXT05")
                    .HasMaxLength(50);

                entity.Property(e => e.OdtZipcode)
                    .HasColumnName("ODT_ZIPCODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.OdtOffice)
                    .WithMany(p => p.OfficeDepartment)
                    .HasForeignKey(d => d.OdtOfficeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OFFICE");
            });

            modelBuilder.Entity<OfficeDepartmentVet>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.OdvCredate)
                    .HasColumnName("ODV_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdvCreuser)
                    .HasColumnName("ODV_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.OdvDatabegin)
                    .HasColumnName("ODV_DATABEGIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdvDataend)
                    .HasColumnName("ODV_DATAEND")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdvDescription).HasColumnName("ODV_DESCRIPTION");

                entity.Property(e => e.OdvModdate)
                    .HasColumnName("ODV_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OdvModuser)
                    .HasColumnName("ODV_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.OdvNotused).HasColumnName("ODV_NOTUSED");

                entity.Property(e => e.OdvOdtid).HasColumnName("ODV_ODTID");

                entity.Property(e => e.OdvVetid).HasColumnName("ODV_VETID");

                entity.HasOne(d => d.OdvOdt)
                    .WithMany(p => p.OfficeDepartmentVet)
                    .HasForeignKey(d => d.OdvOdtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEPARTMENT");

                entity.HasOne(d => d.OdvVet)
                    .WithMany(p => p.OfficeDepartmentVet)
                    .HasForeignKey(d => d.OdvVetid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VET");
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.TreCost)
                    .HasColumnName("TRE_COST")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.TreCredate)
                    .HasColumnName("TRE_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TreCreuser)
                    .HasColumnName("TRE_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.TreDescription).HasColumnName("TRE_DESCRIPTION");

                entity.Property(e => e.TreModdate)
                    .HasColumnName("TRE_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TreModuser)
                    .HasColumnName("TRE_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.TreNotused).HasColumnName("TRE_NOTUSED");

                entity.Property(e => e.TreOdtid).HasColumnName("TRE_ODTID");

                entity.Property(e => e.TrePkwiu)
                    .HasColumnName("TRE_PKWIU")
                    .HasMaxLength(10);

                entity.HasOne(d => d.TreOdt)
                    .WithMany(p => p.Treatment)
                    .HasForeignKey(d => d.TreOdtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeDepartment_TES");

                entity.HasOne(d => d.TrePkwiuNavigation)
                    .WithMany(p => p.Treatment)
                    .HasForeignKey(d => d.TrePkwiu)
                    .HasConstraintName("FK_Treat_Pkwiu");
            });

            modelBuilder.Entity<Typ1>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.Typ1Credate)
                    .HasColumnName("TYP1_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Typ1Creuser)
                    .HasColumnName("TYP1_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.Typ1Desc)
                    .HasColumnName("TYP1_DESC")
                    .HasMaxLength(200);

                entity.Property(e => e.Typ1Moddate)
                    .HasColumnName("TYP1_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Typ1Moduser)
                    .HasColumnName("TYP1_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.Typ1Notused).HasColumnName("TYP1_NOTUSED");
            });

            modelBuilder.Entity<Typ2>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.Typ2Credate)
                    .HasColumnName("TYP2_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Typ2Creuser)
                    .HasColumnName("TYP2_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.Typ2Desc)
                    .HasColumnName("TYP2_DESC")
                    .HasMaxLength(200);

                entity.Property(e => e.Typ2Moddate)
                    .HasColumnName("TYP2_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Typ2Moduser)
                    .HasColumnName("TYP2_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.Typ2Notused).HasColumnName("TYP2_NOTUSED");

                entity.Property(e => e.Typ2Typ1id).HasColumnName("TYP2_TYP1ID");

                entity.HasOne(d => d.Typ2Typ1)
                    .WithMany(p => p.Typ2)
                    .HasForeignKey(d => d.Typ2Typ1id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYP1_TYP2");
            });

            modelBuilder.Entity<VarPkwiu>(entity =>
            {
                entity.HasKey(e => e.PkwiuCode);

                entity.ToTable("VarPKWIU");

                entity.Property(e => e.PkwiuCode)
                    .HasColumnName("PKWIU_CODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.PkwiuCredate)
                    .HasColumnName("PKWIU_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.PkwiuCreuser)
                    .HasColumnName("PKWIU_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.PkwiuDesc)
                    .HasColumnName("PKWIU_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.PkwiuModdate)
                    .HasColumnName("PKWIU_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.PkwiuModuser)
                    .HasColumnName("PKWIU_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.PkwiuNotused).HasColumnName("PKWIU_NOTUSED");
            });

            modelBuilder.Entity<VarTypOfPay>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.VtopCredate)
                    .HasColumnName("VTOP_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtopCreuser)
                    .HasColumnName("VTOP_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VtopDay).HasColumnName("VTOP_DAY");

                entity.Property(e => e.VtopDesc)
                    .HasColumnName("VTOP_DESC")
                    .HasMaxLength(200);

                entity.Property(e => e.VtopModdate)
                    .HasColumnName("VTOP_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VtopModuser)
                    .HasColumnName("VTOP_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VtopNotused).HasColumnName("VTOP_NOTUSED");
            });

            modelBuilder.Entity<Vet>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.VetCredate)
                    .HasColumnName("VET_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VetCreuser)
                    .HasColumnName("VET_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VetDtx01)
                    .HasColumnName("VET_DTX01")
                    .HasColumnType("datetime");

                entity.Property(e => e.VetDtx02)
                    .HasColumnName("VET_DTX02")
                    .HasColumnType("datetime");

                entity.Property(e => e.VetDtx03)
                    .HasColumnName("VET_DTX03")
                    .HasColumnType("datetime");

                entity.Property(e => e.VetDtx04)
                    .HasColumnName("VET_DTX04")
                    .HasColumnType("datetime");

                entity.Property(e => e.VetDtx05)
                    .HasColumnName("VET_DTX05")
                    .HasColumnType("datetime");

                entity.Property(e => e.VetEmail)
                    .HasColumnName("VET_EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.VetLastname)
                    .HasColumnName("VET_LASTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.VetModdate)
                    .HasColumnName("VET_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VetModuser)
                    .HasColumnName("VET_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VetName)
                    .HasColumnName("VET_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.VetNotused).HasColumnName("VET_NOTUSED");

                entity.Property(e => e.VetNtx01)
                    .HasColumnName("VET_NTX01")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VetNtx02)
                    .HasColumnName("VET_NTX02")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VetNtx03)
                    .HasColumnName("VET_NTX03")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VetNtx04)
                    .HasColumnName("VET_NTX04")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VetNtx05)
                    .HasColumnName("VET_NTX05")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VetPhone)
                    .HasColumnName("VET_PHONE")
                    .HasMaxLength(13);

                entity.Property(e => e.VetTxt01)
                    .HasColumnName("VET_TXT01")
                    .HasMaxLength(50);

                entity.Property(e => e.VetTxt02)
                    .HasColumnName("VET_TXT02")
                    .HasMaxLength(50);

                entity.Property(e => e.VetTxt03)
                    .HasColumnName("VET_TXT03")
                    .HasMaxLength(50);

                entity.Property(e => e.VetTxt04)
                    .HasColumnName("VET_TXT04")
                    .HasMaxLength(50);

                entity.Property(e => e.VetTxt05)
                    .HasColumnName("VET_TXT05")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.VisAnimalid).HasColumnName("VIS_ANIMALID");

                entity.Property(e => e.VisCost)
                    .HasColumnName("VIS_COST")
                    .HasColumnType("numeric(36, 2)");

                entity.Property(e => e.VisCredate)
                    .HasColumnName("VIS_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisCreuser)
                    .HasColumnName("VIS_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VisCustomerid).HasColumnName("VIS_CUSTOMERID");

                entity.Property(e => e.VisDate)
                    .HasColumnName("VIS_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisDepartmentid).HasColumnName("VIS_DEPARTMENTID");

                entity.Property(e => e.VisDiet).HasColumnName("VIS_DIET");

                entity.Property(e => e.VisDtx01)
                    .HasColumnName("VIS_DTX01")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisDtx02)
                    .HasColumnName("VIS_DTX02")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisDtx03)
                    .HasColumnName("VIS_DTX03")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisDtx04)
                    .HasColumnName("VIS_DTX04")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisDtx05)
                    .HasColumnName("VIS_DTX05")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisMedicalhistory).HasColumnName("VIS_MEDICALHISTORY");

                entity.Property(e => e.VisModdate)
                    .HasColumnName("VIS_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisModuser)
                    .HasColumnName("VIS_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VisNotused).HasColumnName("VIS_NOTUSED");

                entity.Property(e => e.VisNtx01)
                    .HasColumnName("VIS_NTX01")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VisNtx02)
                    .HasColumnName("VIS_NTX02")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VisNtx03)
                    .HasColumnName("VIS_NTX03")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VisNtx04)
                    .HasColumnName("VIS_NTX04")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VisNtx05)
                    .HasColumnName("VIS_NTX05")
                    .HasColumnType("numeric(36, 6)");

                entity.Property(e => e.VisRecognition).HasColumnName("VIS_RECOGNITION");

                entity.Property(e => e.VisRecommendations).HasColumnName("VIS_RECOMMENDATIONS");

                entity.Property(e => e.VisTxt01)
                    .HasColumnName("VIS_TXT01")
                    .HasMaxLength(50);

                entity.Property(e => e.VisTxt02)
                    .HasColumnName("VIS_TXT02")
                    .HasMaxLength(50);

                entity.Property(e => e.VisTxt03)
                    .HasColumnName("VIS_TXT03")
                    .HasMaxLength(50);

                entity.Property(e => e.VisTxt04)
                    .HasColumnName("VIS_TXT04")
                    .HasMaxLength(50);

                entity.Property(e => e.VisTxt05)
                    .HasColumnName("VIS_TXT05")
                    .HasMaxLength(50);

                entity.Property(e => e.VisVet).HasColumnName("VIS_VET");

                entity.Property(e => e.VisWeight)
                    .HasColumnName("VIS_WEIGHT")
                    .HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.VisAnimal)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.VisAnimalid)
                    .HasConstraintName("FK_Animal");

                entity.HasOne(d => d.VisCustomer)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.VisCustomerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Visit");

                entity.HasOne(d => d.VisDepartment)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.VisDepartmentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_Visit");

                entity.HasOne(d => d.VisVetNavigation)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.VisVet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vet_VISIT");
            });

            modelBuilder.Entity<VisitMedicines>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.VimAssid).HasColumnName("VIM_ASSID");

                entity.Property(e => e.VimCost)
                    .HasColumnName("VIM_COST")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.VimCredate)
                    .HasColumnName("VIM_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VimCreuser)
                    .HasColumnName("VIM_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VimDose).HasColumnName("VIM_DOSE");

                entity.Property(e => e.VimModdate)
                    .HasColumnName("VIM_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VimModuser)
                    .HasColumnName("VIM_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VimNotused).HasColumnName("VIM_NOTUSED");

                entity.Property(e => e.VimQty)
                    .HasColumnName("VIM_QTY")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.VimVisid).HasColumnName("VIM_VISID");

                entity.HasOne(d => d.VimAss)
                    .WithMany(p => p.VisitMedicines)
                    .HasForeignKey(d => d.VimAssid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medi_VIsit");

                entity.HasOne(d => d.VimVis)
                    .WithMany(p => p.VisitMedicines)
                    .HasForeignKey(d => d.VimVisid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Medi");
            });

            modelBuilder.Entity<VisitTreatment>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.VitCost)
                    .HasColumnName("VIT_COST")
                    .HasColumnType("numeric(30, 6)");

                entity.Property(e => e.VitCredate)
                    .HasColumnName("VIT_CREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VitCreuser)
                    .HasColumnName("VIT_CREUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VitModdate)
                    .HasColumnName("VIT_MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VitModuser)
                    .HasColumnName("VIT_MODUSER")
                    .HasMaxLength(30);

                entity.Property(e => e.VitNotused).HasColumnName("VIT_NOTUSED");

                entity.Property(e => e.VitQty)
                    .HasColumnName("VIT_QTY")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.VitTreid).HasColumnName("VIT_TREID");

                entity.Property(e => e.VitVisid).HasColumnName("VIT_VISID");

                entity.HasOne(d => d.VitTre)
                    .WithMany(p => p.VisitTreatment)
                    .HasForeignKey(d => d.VitTreid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trea_Visit");

                entity.HasOne(d => d.VitVis)
                    .WithMany(p => p.VisitTreatment)
                    .HasForeignKey(d => d.VitVisid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Treat");
            });
        }
    }
}
