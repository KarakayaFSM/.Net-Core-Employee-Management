using System;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EmployeeManagement.Controllers
{
    public class HomeController:Controller
    {
        private readonly Models.IEmployeeRepository _Er;
        private readonly IHostingEnvironment ihe;

        public HomeController(Models.IEmployeeRepository Er,IHostingEnvironment ihe)
        {
            _Er = Er;
            this.ihe = ihe;
        }
        
        public ViewResult Index()
        {
            var model = _Er.GetAllEmployees();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniquefileName = processUploadedFile(model);

                Employee newEmp = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniquefileName
                };

                _Er.Add(newEmp);
                return RedirectToAction("details", new { id = newEmp.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee em = _Er.GetEmployee(id);
            EmployeeEditViewModel eevm = new EmployeeEditViewModel
            {
                Id = id,
                Name = em.Name,
                Email = em.Email,
                Department = em.Department,
                ExistingPhotoPath = em.PhotoPath
            };
            return View(eevm);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee em = _Er.GetEmployee(model.Id);
                em.Name = model.Name;
                em.Email = model.Email;
                em.Department = model.Department;
                if(model.Photo != null){

                    if(model.ExistingPhotoPath != null)
                    {
                       string filePath = Path.Combine(ihe.WebRootPath, 
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    em.PhotoPath = processUploadedFile(model);
                  }

                _Er.Update(em);
                return RedirectToAction("details", new { id = em.Id } );
            }
            return View();
        }

        private string processUploadedFile(EmployeeCreateViewModel model)
        {
            string uniquefileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(ihe.WebRootPath, "images");
                uniquefileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniquefileName);

                using(var fs = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fs);
                }
            }
            return uniquefileName;
        }
            

        public ViewResult Details(int? id) //int? id : nullable param.
        {
            Employee em = _Er.GetEmployee(id.Value);

            if(em == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel hdvm = new HomeDetailsViewModel()
            {
                Employee = em,
                PageTitle = "Employee Details:"
            };
            return View(hdvm);
        }
    }
}
