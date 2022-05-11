using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsChecker.Repositories;
using StudentsControl;
using StudentsControl.Models;

namespace StudentsChecker.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserRepository userRepository;

        public AuthController(ApplicationContext context)
        {
            userRepository = new(context);
        }

        [Route("/authorization")]
        public IActionResult Index()
        {
            
            return View();
        }
        [Route("/login")]
        public IActionResult Login(string login, string password)
        {


            User? user=userRepository.FindUser(login,password);
            if (user!=null)
            {
                return Ok();
            }
            
            
            
            return View("Index");
        }
        private string Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
            }
            return "";
        }
    }
}

