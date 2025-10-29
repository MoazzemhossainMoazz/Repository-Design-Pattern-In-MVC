using Microsoft.AspNetCore.Mvc;
using RepoDesignPetternC22.Models;
using RepoDesignPetternC22.Repositoies;

namespace RepoDesignPetternC22.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployee _employeeRepo;
        public EmployeesController(IEmployee employeeRepo)
        {
            this._employeeRepo = employeeRepo;
        }

        public IActionResult Index()
        {
            var model = _employeeRepo.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                _employeeRepo.Insert(employee);
                if(_employeeRepo.Save() > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return BadRequest();
            }
            var model = _employeeRepo.GetById(id.Value);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                _employeeRepo.Update(employee);
                if (_employeeRepo.Save() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employee);
        }


        //public IActionResult Delete(int id)
        //{
        //    var model = _employeeRepo.Models.FirstOrDefault(c => c.Id == id);
        //    if (model is not null)
        //    {
        //        _employeeRepo.Remove(model);
        //        _employeeRepo.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View("Error", "Home");
        //}
    }


}

