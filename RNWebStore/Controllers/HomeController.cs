﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using RNWebStore.Models;

namespace RNWebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();          
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}