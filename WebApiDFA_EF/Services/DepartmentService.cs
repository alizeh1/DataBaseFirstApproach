using WebApiDFA_EF.Models;
using WebApiDFA_EF.ViewModels;

namespace WebApiDFA_EF.Services
{
    public class DepartmentService:IDepartmentService
    {
        private WebApicfaContext _context;
        public DepartmentService(WebApicfaContext context)
        {
            _context = context;
        }


        public List<Department> GetDepartmentList()
        {
            List<Department> deptList;
            try
            {
                deptList = _context.Set<Department>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return deptList;
        }

       
        public Department GetDepartmentDetailsById(int deptId)
        {
            Department Dept;
            try
            {
                Dept = _context.Find<Department>(deptId);
            }
            catch (Exception)
            {
                throw;
            }
            return Dept;
        }


        public ResponseModel SaveDepartment(Department departmentModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Department _temp = GetDepartmentDetailsById(departmentModel.DepartmentId);
                if (_temp != null)
                {
                    _temp.DepartmentId = departmentModel.DepartmentId;
                    _temp.DepartmentName = departmentModel.DepartmentName;
                    _context.Update<Department>(_temp);
                    model.Messsage = "Department Update Successfully";
                }
                else
                {
                    _context.Add<Department>(departmentModel);
                    model.Messsage = "Department Inserted Successfully";
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


        public ResponseModel DeleteDepartment(int departmentId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Department _temp = GetDepartmentDetailsById(departmentId);
                if (_temp != null)
                {
                    _context.Remove<Department>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Department Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Department Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
