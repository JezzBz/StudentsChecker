using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace StudentsControl.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		public string Fcs { get; set; } = "NoName";

		public string PasswordHash { get; set; }
	




	}
}

