using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext: DbContext
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
							e.HasKey(e=>e.Id);
							e.Property(e=>e.Id).HasColumnName("id").HasColumnType("char(36)").ValueGeneratedNever();
							e.Property(e=>e.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
							e.Property(e=>e.LastName).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
							e.Property(e=>e.PassHash).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
							e.Property(u => u.Email).HasColumnName("email").HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
							e.Property(u=>u.Role).HasColumnName("role").HasConversion<int>().IsRequired();
							e.Property(e=>e.CreatedAt).HasColumnName("created_at").HasColumnType("datetime(6)");
							e.Property(e=>e.UpdatedAt).HasColumnName("updated_at").HasColumnType("datetime(6)");
							e.HasIndex(e=>e.Email).IsUnique();	
						}
				);

			

					modelBuilder.Entity<Pharmacy>(p=>
					{
						p.ToTable("pharmacies");
						p.HasKey(p=>p.Id);
						p.Property(p=>p.Id).HasColumnName("id").HasColumnType("char(36)").ValueGeneratedNever();
						p.Property(p=>p.IdAdmin).HasColumnName("idAdmin").HasColumnType("char(36)");
						p.Property(p=>p.Name).HasColumnName("name").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
						p.Property(p=>p.Cnpj).HasColumnName("cnpj").HasColumnType("varchar(20)").HasMaxLength(20).IsRequired();
						p.Property(p=>p.Address).HasColumnName("address").HasColumnType("varchar(250)").HasMaxLength(250).IsRequired();
						p.Property(p=>p.City).HasColumnName("city").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
						p.Property(p=>p.State).HasColumnName("state").HasColumnType("varchar(2)").HasMaxLength(2).IsRequired();
						p.Property(p=>p.LogoUrl).HasColumnName("logo_url").HasColumnType("varchar(350)").HasMaxLength(350);
						p.Property(p=>p.Phone).HasColumnName("phone").HasColumnType("varchar(11)").HasMaxLength(11).IsRequired();
						p.Property(p=>p.Email).HasColumnName("email").HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
						p.Property(p=>p.PassHash).HasColumnName("pass_hash").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
						p.Property(p=>p.Status).HasColumnName("status");
						p.Property(p=>p.CreatedAt).HasColumnName("created_at").HasColumnType("datetime(6)");
						p.Property(p=>p.UpdatedAt).HasColumnName("updated_at").HasColumnType("datetime(6)");
					});

					modelBuilder.Entity<Category>(m=>
					{
						m.ToTable("categories");
						m.HasKey(e=>e.Id);
						m.Property(e=>e.Id).HasColumnName("id").HasColumnType("char(36)").ValueGeneratedNever();
						m.Property(p=>p.IdPharmacy).HasColumnName("id_pharmacy").HasColumnType("char(36)");
						m.Property(p=>p.Name).HasColumnName("name").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
						m.Property(p=>p.Description).HasColumnName("description").HasColumnType("varchar(550)").HasMaxLength(550);
						m.Property(p=>p.CreatedAt).HasColumnName("created_at").HasColumnType("datetime(6)");
						m.Property(p=>p.UpdatedAt).HasColumnName("updated_at").HasColumnType("datetime(6)");
					});

					modelBuilder.Entity<Medication>(m=>
					{
						m.ToTable("medications");
						m.HasKey(p=>p.Id);
						m.Property(p=>p.Id).HasColumnName("id").HasColumnType("char(36)").ValueGeneratedNever();
						m.Property(p=>p.IdPharmacy).HasColumnName("id_pharmacy").HasColumnType("char(36)").IsRequired();
						m.Property(p=>p.IdCategory).HasColumnName("id_category").HasColumnType("char(36)").IsRequired();
						m.Property(p=>p.Name).HasColumnName("name").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
						m.Property(p=>p.Description).HasColumnName("description").HasColumnType("varchar(550)").HasMaxLength(550).IsRequired();
						m.Property(p=>p.Dosage).HasColumnName("dosage").HasColumnType("varchar(150)").HasMaxLength(150);
						m.Property(p=>p.Manufacturer).HasColumnName("manufacturer").HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
						m.Property(p=>p.ImageUrl).HasColumnName("image_url").HasColumnType("varchar(350)").HasMaxLength(350);
						m.Property(p=>p.Price).HasColumnName("price").HasColumnType("decimal(10,2)").IsRequired();
						m.Property(p=>p.RequirePrescription).HasColumnName("require_prescription");
						m.Property(p=>p.Stock).HasColumnName("stock").IsRequired();
						m.Property(p=>p.Tags).HasColumnName("tags").HasColumnType("varchar(150)");
						m.Property(p=>p.CreatedAt).HasColumnName("created_at").HasColumnType("datetime(6)");
						m.Property(p=>p.UpdatedAt).HasColumnName("updated_at").HasColumnType("datetime(6)");
					});
						

				// Relacionamentos

		//User 1 : Phamarcy 1
		modelBuilder.Entity<User>()
			.HasOne(u => u.Pharmacy)
			.WithOne(p=>p.Admin)
			.HasForeignKey<Pharmacy>(p => p.IdAdmin);


		//phamarcy 1:N categories
		modelBuilder.Entity<Category>()
				.HasOne(c => c.Pharmacy)
				.WithMany(p => p.Categories)
				.HasForeignKey(c => c.IdPharmacy);



		//categorias 1:N Medicaments 
				modelBuilder.Entity<Medication>()
					.HasOne(m=>m.Category)
					.WithMany(c=>c.Medicaments)
					.HasForeignKey(m=>m.IdCategory)
					.OnDelete(DeleteBehavior.Restrict);
				}

    }

}