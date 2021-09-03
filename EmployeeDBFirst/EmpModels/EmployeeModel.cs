using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmpModels
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public DateTime DOJ { get; set; }
        [Required]
        public string Address { get; set; }
        public int? DepartmentID { get; set; }
        public string IsActive { get; set; }

        public DepartmentModel departmentModel { get; set; }
    }
}
