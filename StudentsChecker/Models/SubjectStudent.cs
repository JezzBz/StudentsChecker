using System;
using StudentsChecker.Models;

namespace StudentsControl.Models
{
	public class SubjectStudent
	{
		public int Id { get; set; }
		public Student Student { get; set; }
		public Subject Subject { get; set; }
		public Teacher Teacher { get; set; }
		public TestType Type { get; set; }
		public float VisitTime { get; set; }
		public int Mark { get; set; }
		 
	}
	public enum TestType
    {
		Pass,
		PassA,
		Exam
	}
}

