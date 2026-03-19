using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using pharmacy_api.Entities;

namespace pharmacy_api.Context
{  
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
		public DbSet<User> Users{get;set;}
		public DbSet<Pharmacy> Pharmacies{get;set;}
		public DbSet<Category> Categories{get;set;}
		public DbSet<Medication> Medications{get;set;}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			
			modelBuilder.Entity<User>(e =>
				{
					e.ToTable("users");
					e.HasKey(e=>e.id);
					e.Property(e=>e.id).HasColumnName("id").HasColumnType("char(36)").ValueGeneratedNever();
					e.Property(e=>e.name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
					e.Property(e=>e.lastName).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
					e.Property(e=>e.passHash).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
					e.Property(u => u.email).HasColumnName("email").HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
					e.Property(u=>u.role).HasColumnName("role").HasConversion<int>().IsRequired();
					e.Property(e=>e.createdAt).HasColumnType("datetime(6)");
					e.Property(e=>e.updatedA).HasColumnType("datetime(6)");
					e.HasIndex(e=>e.email).IsUnique();	
				}
		  );

			modelBuilder.Entity<Pharmacy>(p=>
			{
				p.ToTable("pharmacies");
				p.HasKey(p=>p.id);
				p.Property(p=>p.id).HasColumnName("id").HasColumnType("char(36)").ValueGeneratedNever();
				p.Property(p=>p.idAdmin).HasColumnName("idAdmin").HasColumnType("char(36)");
				p.Property(p=>p.name).HasColumnName("name").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
				p.Property(p=>p.cnpj).HasColumnName("cnpj").HasColumnType("varchar(20)").HasMaxLength(20).IsRequired();
				p.Property(p=>p.address).HasColumnName("address").HasColumnType("varchar(250)").HasMaxLength(250).IsRequired();
				p.Property(p=>p.city).HasColumnName("city").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
				p.Property(p=>p.state).HasColumnName("state").HasColumnType("varchar(2)").HasMaxLength(2).IsRequired();
				p.Property(p=>p.logoUrl).HasColumnName("logo_url").HasColumnType("varchar(350)").HasMaxLength(350);
				p.Property(p=>p.phone).HasColumnName("phone").HasColumnType("varchar(11)").HasMaxLength(11).IsRequired();
				p.Property(p=>p.email).HasColumnName("email").HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
				p.Property(p=>p.passHash).HasColumnName("pass_hash").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
				p.Property(p=>p.status).HasColumnName("status");
				p.Property(p=>p.createdAt).HasColumnType("datetime(6)");
				p.Property(p=>p.updatedA).HasColumnType("datetime(6)");
			});

			modelBuilder.Entity<Category>(m=>
			{
				m.ToTable("categories");
				m.HasKey(p=>p.id);
				m.Property(p=>p.id).HasColumnName("id").HasColumnType("char(36)").ValueGeneratedNever();
				m.Property(p=>p.idPharmacy).HasColumnName("id_pharmacy").HasColumnType("char(36)");
				m.Property(p=>p.name).HasColumnName("name").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
				m.Property(p=>p.description).HasColumnName("description").HasColumnType("varchar(550)").HasMaxLength(550);
				m.Property(p=>p.createdAt).HasColumnType("datetime(6)");
				m.Property(p=>p.updatedA).HasColumnType("datetime(6)");
			});

			modelBuilder.Entity<Medication>(m=>
			{
				m.ToTable("medications");
				m.HasKey(p=>p.id);
				m.Property(p=>p.id).HasColumnName("id").HasColumnType("char(36)").ValueGeneratedNever();
				m.Property(p=>p.idPharmacy).HasColumnName("id_pharmacy").HasColumnType("char(36)").IsRequired();
				m.Property(p=>p.idCategory).HasColumnName("id_category").HasColumnType("char(36)").IsRequired();
				m.Property(p=>p.name).HasColumnName("name").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
				m.Property(p=>p.description).HasColumnName("description").HasColumnType("varchar(550)").HasMaxLength(550).IsRequired();
				m.Property(p=>p.dosage).HasColumnName("dosage").HasColumnType("varchar(150)").HasMaxLength(150);
				m.Property(p=>p.manufacturer).HasColumnName("manufacturer").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
				m.Property(p=>p.imageurl).HasColumnName("image_url").HasColumnType("varchar(350)").HasMaxLength(350);
				m.Property(p=>p.price).HasColumnName("price").HasColumnType("decimal(10,2)").IsRequired();
				m.Property(p=>p.requirePrescription).HasColumnName("require_prescription");
				m.Property(p=>p.stock).HasColumnName("stock").IsRequired();
				m.Property(p=>p.tags).HasColumnName("tags").HasColumnType("varchar(150)");
				m.Property(p=>p.createdAt).HasColumnType("datetime(6)");
				m.Property(p=>p.updatedA).HasColumnType("datetime(6)");
			});
				

		// Relacionamentos

  //User 1 : Phamarcy 1
  modelBuilder.Entity<User>()
    .HasOne(u => u.pharmacy)
    .WithOne(p=>p.admin)
    .HasForeignKey<Pharmacy>(p => p.idAdmin);


//phamarcy 1:N categories
   modelBuilder.Entity<Category>()
        .HasOne(c => c.pharmacy)
        .WithMany(p => p.Categories)
        .HasForeignKey(c => c.idPharmacy);



  //categorias 1:N Medicaments 
		 modelBuilder.Entity<Medication>()
			   .HasOne(m=>m.category)
			   .WithMany(c=>c.medicaments)
			   .HasForeignKey(m=>m.idCategory)
			   .OnDelete(DeleteBehavior.Restrict);
		}

    }
}