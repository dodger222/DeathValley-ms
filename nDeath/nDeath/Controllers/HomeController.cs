using nDeath.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nDeath.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Parabola parabola)
        {
            if (parabola.X1 > parabola.X2)
            {
                ModelState.AddModelError("X1", "X1 must be less than X2");
            }
            if (ModelState.IsValid)
            {
                List<int> points = new List<int>();

                int y;
                
                for (int x = parabola.X1; x <= parabola.X2; x += parabola.Step)
                {
                    y = parabola.A * x * x + parabola.B * x + parabola.C;
                    points.Add(x);
                    points.Add(y);
                }

                string jsonFile = "points.json";
                System.IO.File.WriteAllText(Server.MapPath(jsonFile), JsonConvert.SerializeObject(points));

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
