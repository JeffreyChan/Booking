﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Ploeh.Samples.Booking.WebModel
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return this.View();
        }
    }
}