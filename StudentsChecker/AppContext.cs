using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsChecker.Models;
using StudentsControl.Models;

namespace StudentsControl
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions options): base(options)
		{
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}


		public DbSet<Teacher> Teachers { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<Subject> Subjects { get; set; }

		public DbSet <SubjectStudent>  SubjectStudent { get; set; }

		public DbSet<Group> Groups { get; set; }
	}
}

