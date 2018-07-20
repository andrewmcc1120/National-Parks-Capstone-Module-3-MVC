using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public string Park { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Activity { get; set; }
    }

    public static List<SelectListItem> park = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Cuyahoga Valley National Park", Value = "CVNP"},
            new SelectListItem() {Text = "Everglades National Park", Value = "ENP"}

        };
}
