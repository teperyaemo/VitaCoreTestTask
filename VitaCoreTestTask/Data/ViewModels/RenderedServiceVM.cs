using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class RenderedServiceVM
    {
        public List<SelectListItem>? EmployeeList { get; set; }
        public List<SelectListItem>? ServiceList { get; set; }
        public int Id_RenderedServ { get; set; }
        public int Id_VisitLog { get; set; }
        public int Id_Employee { get; set; }
        public int Id_Service { get; set; }
        public int ServiceCount { get; set; }
    }
}
