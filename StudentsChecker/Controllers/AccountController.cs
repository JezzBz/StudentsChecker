using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentsChecker.Repositories;
using StudentsControl;
using StudentsControl.Models;

namespace StudentsChecker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository userRepository;

        private readonly CookieOptions cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTime.UtcNow.AddDays(1)
        };

    

        public AccountController(ApplicationContext context)
        {
            userRepository = new(context);
        }

        [Route("/Login")]
        public IActionResult Index()
        {
            
            return View();
        }
        
        public async  Task<IActionResult> Login(string login, string password)
        {


            User? user=userRepository.FindUser(login,password);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Fcs")
            };
            var ClaimsIdentity = new ClaimsIdentity(claims, "Login");
            if (user!=null)
            {
              await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(ClaimsIdentity));
              return Redirect("/");
            }
            
            
            
            return View("Index");
        }



        private string GenerateJwtAccessToken()
        {
            var jwt = new JwtSecurityToken(
                        issuer: "Mai",
                        audience: "Client",
                        claims: null,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("DRfDgclpXToSOqHbdlbVoNtYfcdXd1Q1")), SecurityAlgorithms.HmacSha256)

                        );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return encodedJwt;
        }
    }

}

