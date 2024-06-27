using System;
using Microsoft.EntityFrameworkCore;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Data
{
	public class ApplicationDbContext: DbContext
	{
        //private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{
            
        }

		//public ApplicationDbContext(IConfiguration configuration)
		//{
  //          _configuration = configuration;
  //      }

		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<Teacher> Teachers { get; set; }
		public virtual DbSet<Subject> Subjects { get; set; }
		public virtual DbSet<Standard> Standards { get; set; }

   //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   //     {
			//optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_configuration.GetConnectionString("Default"));
   //         base.OnConfiguring(optionsBuilder);
   //     }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<Subject>().HasMany<Teacher>();

			//modelBuilder.Entity<Subject>().HasData(
			//	new Subject { Id = 1, Name = "English" },
			//	new Subject { Id = 2, Name = "Maths" }
			//	);
		}
	}
}

