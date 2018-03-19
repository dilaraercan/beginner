using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        /*public ActionResult Index()//ilk gelip girdiği yer
        {
            return View("About");
        }*/
        public ActionResult Index()
        {
            return View();//it will return the index view
        }
        public ActionResult About()
        {
            return View();//it will return the about view
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View(); //it will return the contact view 
                
        }


    }
    
}