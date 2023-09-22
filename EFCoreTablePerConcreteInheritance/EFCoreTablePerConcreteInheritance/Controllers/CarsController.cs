﻿using EFCoreTablePerConcreteInheritance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTablePerConcreteInheritance.Controllers
{
    public class CarsController : Controller
    {
        private readonly MyApplicationContext _context;

        public CarsController(MyApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cars = _context.Vehicles.OfType<Car>().AsNoTracking().ToList();
            return View(cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car carModel)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(carModel);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(carModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = GetCarById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(Car carModel)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Update(carModel);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(carModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var car = GetCarById(id);
            return View(car);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var car = GetCarById(id);
            _context.Vehicles.Remove(car);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private Car GetCarById(int id)
        {
            var car = _context.Vehicles.OfType<Car>().SingleOrDefault(x => x.Id == id);
            return car;
        }
    }
}