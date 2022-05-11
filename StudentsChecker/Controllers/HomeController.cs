    using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
    using StudentsChecker.Models;
    using StudentsChecker.Repositories;
    using StudentsControl;
    using StudentsControl.Models;

    namespace StudentsChecker.Controllers;

    public class HomeController : Controller
    {
        private readonly StudentsRepository studentsRepository;
        private readonly SubjectRepository subjectRepository;
        public HomeController(ApplicationContext context)
        {
            studentsRepository=new(context);
            subjectRepository = new(context);
        }
    
        //[Authorize]
        public IActionResult Index()
        {
            //studentsRepository.CreateTestUsers();
            ViewBag.Students = studentsRepository.GetAll();
            return View();
        }   
        //[Authorize]
        public IActionResult Statement()
        {
            ViewBag.Groups = studentsRepository.GetGroups();
            return View();
        }
        //[Authorize]
        public IActionResult AddStatement(string Group)
        {
        
            var Statement= subjectRepository.GetSubjectsByGroup(Group).ToList();
            var Subjects = subjectRepository.GroupSubject(Group);
            var Students= studentsRepository.GetStudentsByGroup(Group).ToList();
            var Teachers = Subjects.SelectMany(x=>x.Teachers).ToList();
            foreach (var item in Students )
            {
                if (!Statement.Any(x=>x.Student==item))
                {
                    Statement.Add(new SubjectStudent{Student=item});
                }
            }
            ViewBag.Statement = Statement;
            ViewBag.Subjects = Subjects;
            ViewBag.Group = Group;
            ViewBag.Students = Students;
            ViewBag.Count = Students.Count();
            ViewBag.Teachers = Teachers;

            return View();
        }
        //[Authorize]
        public IActionResult Recalculation([FromForm]IEnumerable<SubjectStudent> subjectStudents,int SubjectId,int TeacherId)
        {
            Subject subject = subjectRepository.FindById(SubjectId);
        
            //try
            //{
                    foreach (var item in subjectStudents)
                {
                Student student = studentsRepository.FindById(item.Student.Id);
                SubjectStudent CurrentStatement= subjectRepository.FindByParams(subject, student);
                    bool isNew = false;
                    int Mark = item.Mark;
                    float VisitTime = item.VisitTime;
                 
                if (CurrentStatement==null)
                    {
                        isNew = true;   
                        item.Subject = subject;
                        item.Student = student;
                  
                        CurrentStatement= item; 
                    }

                    CurrentStatement.Teacher = subjectRepository.GetTeacherById(TeacherId);
                    CurrentStatement.Mark = Mark;
                    CurrentStatement.VisitTime = VisitTime;



                     if (CurrentStatement.Mark!=0&&CurrentStatement.VisitTime!=0)
                     {                      
                      studentsRepository.Recalculation(student,CurrentStatement);
                      }
               
                }
            
                return Redirect("/");
            //}
            //catch 
            //{
              //  return false;
            //}
        } 
    }

