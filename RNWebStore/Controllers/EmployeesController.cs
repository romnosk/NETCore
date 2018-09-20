using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RNWebStore.Models;
using RNWebStore.Infrastructure.Interfaces;

namespace RNWebStore.Controllers
{
    [Route("users")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }

        public IActionResult Index()
        {
            return View(_employeesData.GetAll());
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            EmployeeView employee = _employeesData.GetById(id);

            if (ReferenceEquals(employee, null)) return NotFound();

            return View(employee);
        }

        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            EmployeeView model;
            if (id.HasValue)
            {
                model = _employeesData.GetById(id.Value);
                if (ReferenceEquals(model, null)) return NotFound();
            }
            else model = new EmployeeView();

            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(EmployeeView model)
        {
            if (model.Id > 0)
            {
                var dbItem = _employeesData.GetById(model.Id);

                if (ReferenceEquals(model, null)) return NotFound();

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Age = model.Age;
                dbItem.Position = model.Position;
            }
            else _employeesData.AddNew(model);

            _employeesData.Commit();

            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            _employeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}