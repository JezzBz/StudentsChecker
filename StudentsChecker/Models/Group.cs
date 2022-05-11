using System;
namespace StudentsControl.Models
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; } = "NoName";
		public IEnumerable<Student> Students { get; set; }
		public IEnumerable<Subject> Subjects { get; set; }
	}
}

