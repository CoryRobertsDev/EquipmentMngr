using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentMngr.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquipmentMngr.Models.ViewModels
{
    public class SearchTypeViewModel
    {
        public List<Assignment> Assignments { get; set; }
        public SelectList SearchTypes { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}
