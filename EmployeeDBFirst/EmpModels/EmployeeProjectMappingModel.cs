using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpModels
{
    public class EmployeeProjectMappingModel
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProjectId { get; set; }
        public string IsActive { get; set; }

        public EmployeeModel employeeModel { get; set; }
        public ProjectModel projectModel { get; set; }
    }
}
