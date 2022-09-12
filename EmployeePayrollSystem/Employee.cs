using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollSystem
{
    public class Employee
    {
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public DateTime startDate { get; set; }
        public string phoneNumber { get; set; }
        public string departmentName { get; set; }
        public double basicPay { get; set; }
    }
}