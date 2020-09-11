using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentMngr.TagHelpers
{
    public class OptionsTagHelper : PageModel
    {
        public List<SelectListItem> Items =>
            Enumerable.Range(1, 3).Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            }).ToList();

        public int Number { get; set; }

        public void OnGet()
        {
        }
    }
}