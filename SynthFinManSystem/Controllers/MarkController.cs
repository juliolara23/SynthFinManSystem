﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynthFinManSystem.Web.Controllers
{
    public class MarkController : Controller
    {
        public IActionResult Index()
        {
            return PartialView();
        }
    }
}
