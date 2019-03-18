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
        string jsonFile = "points.json";

        [HttpGet]
        public ActionResult Index()
        {
            FileCleaning(jsonFile);
            return View();
        }

        [HttpPost]
        public ActionResult Index(Parabola parabola)
        {
            if(parabola.A == 0)
            {
                ModelState.AddModelError("A", "Coefficient A should not be zero");
                FileCleaning(jsonFile);
            }
            if (parabola.X1 == parabola.X2)
            {
                ModelState.AddModelError("X1", "X1 should not be equal to X2");
                FileCleaning(jsonFile);
            }
            if(parabola.Step <= 0)
            {
                ModelState.AddModelError("Step", "Step must be greater than zero");
                FileCleaning(jsonFile);
            }
            if (ModelState.IsValid)
            {
                int X1 = 0;
                int X2 = 0;

                if (parabola.X1 < parabola.X2)
                {
                    X1 = parabola.X1;
                    X2 = parabola.X2;
                }
                else
                {
                    X2 = parabola.X1;
                    X1 = parabola.X2;
                }

                List<Point> points = new List<Point>();

                int y;
                
                for (int x = X1; x <= X2; x += parabola.Step)
                {
                    y = parabola.A * x * x + parabola.B * x + parabola.C;
                    points.Add(new Point(x, y));
                }
                
                System.IO.File.WriteAllText(Server.MapPath(jsonFile), JsonConvert.SerializeObject(points));

                return View();
            }
            else
            {
                return View();
            }
        }

        public void FileCleaning(string jsonFile)
        {
            System.IO.File.WriteAllText(Server.MapPath(jsonFile), null);
        }
    }
}
