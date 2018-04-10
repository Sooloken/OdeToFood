using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IResturantData _resturantData;
        private IGreeter _greeter;
        public HomeController(IResturantData resturantData, IGreeter greeter)
        {
            _resturantData = resturantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Resturants = _resturantData.GetAll();
            model.CurrentMassage = _greeter.GetMessageOfTheDay();

            return View(model);// ObjectResult(model);
        }

        public IActionResult Details(int id)
        {
            var model = _resturantData.get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ResurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newResturant = new Resturant();
                newResturant.Name = model.Name;
                newResturant.Cuisine = model.cuisine;

                newResturant = _resturantData.Add(newResturant);


                return RedirectToAction(nameof(Details), new { id = newResturant.Id, foo = "bar" });
                //View("Details", newResturant);
            }
            else
            {
                return View();
            }
        }
    }
}
