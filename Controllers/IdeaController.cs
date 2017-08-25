using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using brightideas.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace brightideas.Controllers
{
    
    public class IdeaController : Controller
    {

        //==================================================================================
        // DB Connection settings. 
        //==================================================================================
        
        private IdeaContext _context; 

        public IdeaController(IdeaContext context)
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
            
            if (UserId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string CurrUserAlias = HttpContext.Session.GetString("UserAlias");
                ViewBag.CurrUserAlias = CurrUserAlias;

                List<Idea> ReturnedIdeas = _context.Ideas
                    .Include( x => x.CreatedBy )
                    .Include( y => y.Likes)
                    .ToList();
                return View();
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
                Idea NewIdea = new Idea
                {
                    IdeaText = model.IdeaText,
                    CreatedById = (int)UserId,
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