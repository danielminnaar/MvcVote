using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConferenceVote.Controllers
{
    public class VotingController : Controller
    {
        // GET: Voting
        public ActionResult Index()
        {
            return View("Vote");
        }

        public ActionResult Results()
        {
            return View();
        }

        public ActionResult Vote()
        {
            return View();
        }
    }
}