using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logindemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace logindemo.Controllers
{
    public class LoginController : Controller
    {
      

        registeropertation rop = new registeropertation();
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login([Bind] register reg)
        {
            int res = rop.logcheck(reg);
            if(res==1)
            {
                TempData["msg"] = "You are Successfully Login!!";
            }
            else
            {
                TempData["msg"] = "Username and Password are Wrong!";
            }
            return View();
        }
    }
}
