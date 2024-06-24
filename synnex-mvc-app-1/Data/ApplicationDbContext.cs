using System;
using Microsoft.EntityFrameworkCore;
using synnex_mvc_app_1.Models;

namespace synnex_mvc_app_1.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{
		}

		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<Teacher> Teachers { get; set; }
	}
}

