namespace WebApiDFA_EF.Models
{
    public class EmployeeRequestBody
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public decimal Salary { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
    }
}
