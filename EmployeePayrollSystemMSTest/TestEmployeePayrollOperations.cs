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

            employeeDetails.Add(new Employee() { employeeName = "A1", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A2", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A3", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A4", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A5", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A6", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A7", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A8", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A9", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
            employeeDetails.Add(new Employee() { employeeName = "A10", startDate = Convert.ToDateTime("1-1-2002"), gender = "F", phoneNumber = "8888999988", address = "KZH", departmentName = "CE", basicPay = 20000 });
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
    }
}