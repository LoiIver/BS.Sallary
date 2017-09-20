using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BS.Data.Model.System;
using BS.Data;
using BS.Data.Model;

namespace BS
{
	// >dotnet ef migration add testMigration in AspNet5MultipleProject
	public class DomainModelPostgreSqlContext : DbContext
	{
		public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
		{
		}

		public DomainModelPostgreSqlContext() : base() { }


		public DbSet<Menu> Menus { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Company> Companies { get; set; }
		public DbSet<LegalForm> LegalForms { get; set; }
		public DbSet<Employee> Employees { get; set; }
		

		public DbSet<Position> Position { get; set; }
		public DbSet<PositionInCompany> PositionInCompanys { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.Entity<ServiceType>()
			//	.HasKey(m => m.ServiceTypeId);
			//builder.Entity<Company>().HasKey(m => m.CompanyId);
			//builder.Entity<CompanyServiceType>()
			//.HasKey(m => m.CompanyServiceTypeId);
			//builder.Entity<LegalForm>()
			//   .HasKey(m => m.CompanyTypeId);
			//builder.Entity<User>()
			//  .HasKey(m => m.UserId);
			//builder.Entity<Role>()
			// .HasKey(m => m.RoleId);
			//builder.Entity<UsersRole>()
			//	.HasKey(m => m.UsersRoleId);
			//base.OnModelCreating(builder);
		}

		public override int SaveChanges()
		{
			ChangeTracker.DetectChanges();

			//	updateUpdatedProperty<SourceInfo>();
			//	updateUpdatedProperty<DataEventRecord>();

			return base.SaveChanges();
		}

		private void updateUpdatedProperty<T>() where T : class
		{
			var modifiedSourceInfo =
				ChangeTracker.Entries<T>()
					.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

			foreach (var entry in modifiedSourceInfo)
			{
				entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
			}
		}
	}
}