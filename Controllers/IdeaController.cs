using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using brightideas.Models;
using System.Linq;

namespace brightideas.Controllers
{
    
    public class IdeaController : Controller
    {

        //==================================================================================
        // DB Connection settings. 
        //==================================================================================
        
        private ideasContext _context; 

        public IdeaController(ideasContext context)
        {
            _context = context;
        }

        //==================================================================================
        // Root Route. Checks for session data and goes to Dashboard if found.
        //==================================================================================

        [HttpGet]
        [Route("main")]
        public IActionResult Main()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                string CurrUserAlias = HttpContext.Session.GetString("UserAlias");
                ViewBag.CurrUserAlias = CurrUserAlias;


                //get all ideas here and display is descending order by number of likes.. 
                List<users> ReturnedUsers = _context.users.ToList();
                List<ideas> ReturnedIdeas = _context.ideas.ToList();
                ViewBag.AllUsers = ReturnedUsers;
                ViewBag.AllIdeas = ReturnedIdeas;
                //get all likes here and display the likes for each post. 



                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //==================================================================================
        // Create Idea Route.
        //==================================================================================

        [HttpPost]
        [Route("CreateIdea")]
        public IActionResult CreateIdea(IdeaViewModel model)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                ideas NewIdea = new ideas
                {
                    Idea = model.Idea,
                    CreatedBy = UserId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                _context.Add(NewIdea);
                _context.SaveChanges();
                return RedirectToAction("Main", "Idea");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}