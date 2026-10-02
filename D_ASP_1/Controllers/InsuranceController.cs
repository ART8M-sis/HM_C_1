using D_ASP_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace D_ASP_1.Controllers
{
    public class InsuranceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View( new InsuranceViewModel());
        }

        [HttpPost]
        public IActionResult Index(InsuranceViewModel model)
        {
            if (model.EngineCapacity<=0 || model.DriverExperienceYears <=0)
            {
                model.ErrorMessage = "Об'єм двигуна і стаж мають бути більшими за 0.";
                return View(model);
            }
            decimal price = 1000m;

            if (model.EngineCapacity <= 1600)
            {
                price *= 1.0m;
            }
            else if (model.EngineCapacity <= 2000)
            {
                price *= 1.3m;
            }
            else
            {
                price *= 1.6m;
            }

            switch (model.CityType)
            {
                case "Kyiv":
                    price *= 1.8m;
                    break;
                case "LargeCity":
                    price *= 1.3m;
                    break;
                case "SmallTown":
                default:
                    price *= 1.0m;
                    break;
            }

            if (model.DriverExperienceYears > 3)
            {
                price -= price * 0.10m;
            }

            if (model.HasDiscountCategory)
            {
                price -= price * 0.20m;
            }

            model.CalculatedPrice = Math.Round(price, 2);
            model.ErrorMessage = null;

            return View(model);
        }
    }
}
