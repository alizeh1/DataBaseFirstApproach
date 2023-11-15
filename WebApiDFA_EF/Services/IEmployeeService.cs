using WebApiDFA_EF.Models;
using WebApiDFA_EF.ViewModels;


namespace WebApiDFA_EF.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployeesList();


        Employee GetEmployeeDetailsById(int empId);

     
        ResponseModel SaveEmployee(EmployeeRequestBody employeeModel);


  
        //ResponseModel DeleteEmployee(int employeeId);

    }

}
