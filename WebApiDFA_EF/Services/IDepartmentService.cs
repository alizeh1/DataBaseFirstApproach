using WebApiDFA_EF.Models;
using WebApiDFA_EF.ViewModels;

namespace WebApiDFA_EF.Services
{
    public interface IDepartmentService
    {
        List<Department> GetDepartmentList();

        Department GetDepartmentDetailsById(int deptId);

        ResponseModel SaveDepartment(Department departmentModel);

        ResponseModel DeleteDepartment(int departmentId);
    }
}
