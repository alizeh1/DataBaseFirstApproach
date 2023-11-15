using WebApiDFA_EF.Models;
using WebApiDFA_EF.ViewModels;

namespace WebApiDFA_EF.Services
{
    public class EmployeeService : IEmployeeService
    {
        private WebApicfaContext _context;
        public EmployeeService(WebApicfaContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployeesList()
        {
            List<Employee> empList;
            try
            {
                empList = _context.Set<Employee>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }

        public Employee GetEmployeeDetailsById(int empId)
        {
            Employee emp;
            try
            {
                emp = _context.Find<Employee>(empId);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }


        public ResponseModel SaveEmployee(EmployeeRequestBody employeeModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employee _temp = GetEmployeeDetailsById(employeeModel.EmployeeId);
                if (_temp != null)
                {
                    // Update the properties of the existing Employee entity
                    _temp.Designation = employeeModel.Designation;
                    _temp.EmployeeFirstName = employeeModel.EmployeeFirstName;
                    _temp.EmployeeLastName = employeeModel.EmployeeLastName;
                    _temp.Salary = employeeModel.Salary;
                    _temp.DepartmentId = employeeModel.DepartmentId;

                    // No need to use _context.Update here, as the entity is already tracked
                    model.Messsage = "Employee Update Successfully";
                }
                else
                {
                    // Create a new Employee entity and add it to the context
                    var newEmployee = new Employee
                    {
                        EmployeeFirstName = employeeModel.EmployeeFirstName,
                        EmployeeLastName = employeeModel.EmployeeLastName,
                        Salary = employeeModel.Salary,
                        Designation = employeeModel.Designation,
                        DepartmentId = employeeModel.DepartmentId
                    };

                    _context.Add(newEmployee);
                    model.Messsage = "Employee Inserted Successfully";
                }

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        //public ResponseModel SaveEmployee(EmployeeRequestBody employeeModel)
        //{
        //    ResponseModel model = new ResponseModel();
        //    try
        //    {
        //        EmployeeRequestBody _temp = GetEmployeeDetailsById(employeeModel.EmployeeId);
        //        if (_temp != null)
        //        {
        //            _temp.Designation = employeeModel.Designation;
        //            _temp.EmployeeFirstName = employeeModel.EmployeeFirstName;
        //            _temp.EmployeeLastName = employeeModel.EmployeeLastName;
        //            _temp.Salary = employeeModel.Salary;
        //            _temp.DepartmentId= employeeModel.DepartmentId;
        //            _context.Update(_temp);
        //            model.Messsage = "Employee Update Successfully";
        //        }
        //        else
        //        {
        //            _context.Add<EmployeeRequestBody>(employeeModel);
        //            model.Messsage = "Employee Inserted Successfully";
        //        }
        //        _context.SaveChanges();
        //        model.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        model.IsSuccess = false;
        //        model.Messsage = "Error : " + ex.Message;
        //    }
        //    return model;
        //}


        //public ResponseModel DeleteEmployee(int employeeId)
        //{
        //    ResponseModel model = new ResponseModel();
        //    try
        //    {
        //        Employee _temp = GetEmployeeDetailsById(employeeId);
        //        if (_temp != null)
        //        {
        //            _context.Remove<Employee>(_temp);
        //            _context.SaveChanges();
        //            model.IsSuccess = true;
        //            model.Messsage = "Employee Deleted Successfully";
        //        }
        //        else
        //        {
        //            model.IsSuccess = false;
        //            model.Messsage = "Employee Not Found";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        model.IsSuccess = false;
        //        model.Messsage = "Error : " + ex.Message;
        //    }
        //    return model;
        //}
    }

}
