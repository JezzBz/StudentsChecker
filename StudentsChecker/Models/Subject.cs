using System;
using StudentsChecker.Models;

namespace StudentsControl.Models
{
	public class Subject
	{
		public int Id { get; set; }

		public string Name { get; set; } = "NoName";

		public float Time { get; set; }

		

		public IEnumerable<SubjectStudent> SubjectStudents { get; set;}
		public IEnumerable<Group> Groups { get; set; }
		public IEnumerable<Teacher> Teachers { get; set; }

	

	}
}

