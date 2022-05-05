using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DojoMUC.Models;

namespace DojoMUC.Controllers
{
    public class MeetUpController : Controller
    {
        private readonly ILogger<MeetUpController> _logger;
        private MyContext db;
        public MeetUpController(MyContext conext, ILogger<MeetUpController> logger)
        {
            _logger = logger;
            db = conext;
        }
        public int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        // MeetUp Routes================================================================================
            // Rendering the New view (1)
        [HttpGet("Meetup")]
        public IActionResult New()
        {
            if (uid == null)
            {
                return RedirectToAction("Login", "Home");
            }
            
            return View();
        }
        //Create a post===VVV=== (2)
        [HttpPost("Meetup/create")]
        public IActionResult NewPost(MeetUp newMeetup)
        {
            if (uid == null)
            {
                return RedirectToAction("Login", "Home");
            }
                // New Post - Do not forget (int)uid====
            if (ModelState.IsValid)
            {
                newMeetup.UserId = (int)uid;
                db.MeetUps.Add(newMeetup);
                db.SaveChanges();
                return RedirectToAction("Details", new {meetupId = newMeetup.MeetUpId});
            }
            return View("New");
        }
            //Detailed ONE post===VVV=== (3)
        [HttpGet("Meetup/{meetupId}")]
        public IActionResult Details(int meetupId)
        {
            if (uid == null)
            {
                return RedirectToAction("Login", "Home");
            }
            MeetUp OneM = db.MeetUps
            .Include(w => w.Creator)
            .Include(w => w.Participation)
            .ThenInclude(aw => aw.User)
            .FirstOrDefault(w => w.MeetUpId == meetupId);

            if (OneM == null)
            {
                return RedirectToAction("Dashboard");
            }

            return View("One", OneM);
        }
        // Dashboard Routes=================================================================================

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if (uid == null)
            {
                return RedirectToAction("Login", "Home");
            }
            // List of all posts posted. Also to find Count of (Likes/Attendance).
            List<MeetUp> All = db.MeetUps
            .Include(m => m.Creator)
            .Include(m => m.Participation)
            .ThenInclude(aw => aw.User)
            .OrderBy(m => m.DateTime)
            .ToList();

            return View("Dashboard", All);
        }
        // User Actions and Instances of a post (POST REQs)==================================================
            // like posts POST ======VVV======= (Re:Dash)
        [HttpPost("Meetup/{meetupId}/join")]
        public IActionResult Like(int meetupId)
        {
            if (uid == null)
            {
                return RedirectToAction("Login", "Home");
            }
            // Finding EXISTING instances for the Join/Leave instance --VVV--
            Participant existingLike = db.Participants
            .FirstOrDefault(att => att.UserId == uid && att.MeetUpId == meetupId);

                    // ====== Join
            if (existingLike == null)
            {
                Participant newLike = new Participant()
                {
                    UserId = (int)uid,
                    MeetUpId = meetupId
                };
                db.Participants.Add(newLike);
            }
                    // ====== UNLIKE
            else
            {
                db.Participants.Remove(existingLike);
            }
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

            // DELETE posts POST ======VVV====== (Re:Dash)
        [HttpPost("Meetup/{meetupId}/delete")]
        public IActionResult Delete(int meetupId)
        {
            if (uid == null)
            {
                return RedirectToAction("Login", "Home");
            }
            MeetUp post = db.MeetUps
            .FirstOrDefault(w => w.MeetUpId == meetupId);
            
            if(post == null || post.UserId != uid)
            {
                return RedirectToAction("Dashboard");
            }
            db.MeetUps.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}