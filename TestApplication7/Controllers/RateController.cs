using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication7.Services.Ics;

using TestApplication7.Models;

namespace TestApplication7.Controllers
{
    public class RateController : Controller
    {
        // GET: Rate
        public ActionResult Index()
        {
            return View(new TestApplication7.Models.RatingModel());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RatingModel viewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    if (viewModel.PostalCode == "L4N 3P8")
                    {
                        ModelState.AddModelError("Model", "You cannot rate shop this postal code");
                        return View();
                    }

                    var api = new IcsServices();
                    decimal result = api.GetEstimatedCharges(viewModel.Weight, viewModel.Width, viewModel.Length, viewModel.Height, viewModel.PostalCode);

                    //Adding into ViewBag.RatingModel by creating new object of RatingModel by using RatingModel class from Models folder.
                    ViewBag.RatingModel = new RatingModel
                    {
                        Length = viewModel.Length,
                        Height = viewModel.Height,
                        Width = viewModel.Width,
                        Weight = viewModel.Weight,
                        PostalCode = viewModel.PostalCode,
                        EstimatedCost = result

                    };


                    if (result == 0)
                        ViewBag.Error = "Something went wrong with this request";

                    return View("Post");
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Index", "GetRate"));
            }

            return View();
        }
            
        

    }

}