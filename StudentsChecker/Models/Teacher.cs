using System;
using StudentsControl.Models;

namespace StudentsChecker.Models
{
	public class Teacher
	{
		public int Id { get; set; }
		public string Fcs { get; set; }
		public IEnumerable<Subject> Subjects { get; set; }
	}
}

