﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMICalculator.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet(string message)
        {
            Message = "Your application description page.";
        }
    }
}
