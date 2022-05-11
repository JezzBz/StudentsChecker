using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsControl.Models
{
	public class Student
	{
		public int Id { get; set; }
		[Required]
		public string Fcs { get; set; } = "NoName";
		public string IsStuding { get; set; } = "Обучается";

		public float Attendance { get; set;}

		public bool Admitted { get; set; } = true;

		public Group Group { get; set; }

		public IEnumerable<SubjectStudent> SubjectStudent { get; set;}


	}
}

