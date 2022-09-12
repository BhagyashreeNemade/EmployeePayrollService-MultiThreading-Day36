using EmployeePayrollSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmployeePayrollSystemMSTest
{
    [TestClass]
    public class TestEmployeePayrollOperations
    {
        public List<Employee> AddingDataToList()
        {
            List<Employee> employeeDetails = new List<Employee>();

            employeeDetails.Add(new Employee() { employeeID = 101, employeeName = "A1", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 100, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 102, employeeName = "A2", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 101, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 103, employeeName = "A3", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 102, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 104, employeeName = "A4", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 103, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 105, employeeName = "A5", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 104, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 106, employeeName = "A6", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 105, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 107, employeeName = "A7", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 106, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 108, employeeName = "A8", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 107, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 109, employeeName = "A9", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 108, departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeID = 110, employeeName = "A10", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", deptID = 109, departmentName = "CE", basicPay = 20000 });
            return employeeDetails;
        }

        [TestMethod]
        public void CompareTimeAddingToListWithOrWithoutThreading()
        {
            List<Employee> empList = AddingDataToList();
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            DateTime t1 = DateTime.Now;
            employeePayrollOperations.AddToListWithoutThreading(empList);
            DateTime t2 = DateTime.Now;
            Console.WriteLine("Time taken while adding to list without threading: " + (t2 - t1));

            DateTime t3 = DateTime.Now;
            employeePayrollOperations.AddToListWithThreading(empList);
            DateTime t4 = DateTime.Now;
            Console.WriteLine("Time taken while adding to list with threading: " + (t4 - t3));
        }


        [TestMethod]
        public void CompareTimeAddingToDBWithOrWithoutThreading()
        {
            List<Employee> empList = AddingDataToList();
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            DateTime t1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeListToDBWithoutThread(empList);
            DateTime t2 = DateTime.Now;
            Console.WriteLine("Time taken while adding to list without threading: " + (t2 - t1));

            DateTime t3 = DateTime.Now;
            employeePayrollOperations.AddEmployeeListToDBWithThread(empList);
            DateTime t4 = DateTime.Now;
            Console.WriteLine("Time taken while adding to list with threading: " + (t4 - t3));
        }

        [TestMethod]
        public void CompareTimeAddingToMultipleTableDBWithOrWithoutThreading()
        {
            List<Employee> empList = AddingDataToList();
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            DateTime t1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeListToDBMultipleTablesWithoutThread(empList);
            DateTime t2 = DateTime.Now;
            Console.WriteLine("Time taken while adding to list without threading: " + (t2 - t1));

            DateTime t3 = DateTime.Now;
            employeePayrollOperations.AddEmployeeListToDBMultipleTableWithThread(empList);
            DateTime t4 = DateTime.Now;
            Console.WriteLine("Time taken while adding to list with threading: " + (t4 - t3));
        }
    }
}