using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpModels;

namespace EmpDb.EmployeeRepository
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeProjectMappingModel employeeProjectMappingModel)
        {
            using (var context = new EmployeeDBEntities())
            {
                EmployeeProjectMapping employee = new EmployeeProjectMapping()
                {
                    IsActive = employeeProjectMappingModel.IsActive
                };
                if (employeeProjectMappingModel.employeeModel != null)
                {
                    employee.Employee = new Employee()
                    {
                        FirstName = employeeProjectMappingModel.employeeModel.FirstName,
                        LastName = employeeProjectMappingModel.employeeModel.LastName,
                        DOB = employeeProjectMappingModel.employeeModel.DOB,
                        DOJ = employeeProjectMappingModel.employeeModel.DOJ,
                        Address = employeeProjectMappingModel.employeeModel.Address,
                        IsActive = employeeProjectMappingModel.IsActive

                    };
                }

                if (employeeProjectMappingModel.projectModel != null)
                {
                    employee.Project = new Project()
                    {
                        Name = employeeProjectMappingModel.projectModel.Name,
                        AccountName = employeeProjectMappingModel.projectModel.AccountName,
                    };
                }

                if (employeeProjectMappingModel.employeeModel.departmentModel != null)
                {
                    employee.Employee.Department = new Department()
                    {
                        Name = employeeProjectMappingModel.employeeModel.departmentModel.Name,
                        Description = employeeProjectMappingModel.employeeModel.departmentModel.Description,
                    };
                }

                context.EmployeeProjectMapping.Add(employee);
                context.SaveChanges();
                return employee.Id;
            }
        }
        public List<EmployeeModel> GetEmployees()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Select(x => new EmployeeModel()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        DOB = x.DOB,
                        DOJ = x.DOJ,
                        Address = x.Address,
                        IsActive = x.IsActive
                    }).ToList();
                return result;
            }
        }
        public List<ProjectModel> GetProjects()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Project
                    .Select(x => new ProjectModel()
                    {
                        Name = x.Name,
                        AccountName = x.AccountName,

                    }).ToList();
                return result;
            }
        }
        public List<DepartmentModel> GetDepartments()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Department
                    .Select(x => new DepartmentModel()
                    {
                        Name = x.Name,
                        Description = x.Description
                    }).ToList();
                return result;
            }
        }
        public List<EmployeeModel> GetEmployeesDOJ()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Where(x=>x.DOJ > new DateTime(2019,01,01))
                    .Select(x => new EmployeeModel()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        DOB = x.DOB,
                        DOJ = x.DOJ,
                        Address = x.Address,
                        IsActive = x.IsActive
                    }).ToList();
                return result;
            }
        }
        public List<EmployeeModel> GetEmployeesHR()
        {
            using (var context = new EmployeeDBEntities())
            {
                var employee = context.Employee;
                var result = employee.Where(x => x.Department.Name == "HR" && x.DepartmentID == x.Department.Id).
                    Select(x => new EmployeeModel()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        DOB = x.DOB,
                        DOJ = x.DOJ,
                        Address = x.Address,
                        IsActive = x.IsActive
                    }).ToList();
                return result;
            }
        }
        public List<EmployeeModel> GetEmployeeAccordingProjectName(string ProjectName)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.EmployeeProjectMapping
                    .Where(x => x.Project.Name.Equals(ProjectName))
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Employee.Id,
                        FirstName = x.Employee.FirstName,
                        LastName = x.Employee.LastName,
                        DOB = x.Employee.DOB,
                        DOJ = x.Employee.DOJ,
                        Address = x.Employee.Address,
                        IsActive = x.Employee.IsActive,
                    }).ToList();
                return result;
            }
        }
        public List<EmployeeModel> GetDepartmentNameAccordingProjectName(string ProjectName)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.EmployeeProjectMapping
                    .Where(x => x.Project.Name.Equals(ProjectName))
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Employee.Id,
                        FirstName = x.Employee.FirstName,
                        LastName = x.Employee.LastName,
                        DOB = x.Employee.DOB,
                        DOJ = x.Employee.DOJ,
                        Address = x.Employee.Address,
                        DepartmentID = x.Employee.DepartmentID,
                        IsActive = x.Employee.IsActive,
                        departmentModel = new DepartmentModel()
                        {
                            Name = x.Employee.Department.Name,
                            Description = x.Employee.Department.Description
                        }
                    }).ToList();
                return result;
            }
        }
    }
}
