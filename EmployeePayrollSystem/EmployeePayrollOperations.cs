using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    public class EmployeePayrollOperations
    {
        public List<Employee> employeeDataList = new List<Employee>();
        NLog nLog = new NLog();
        public void AddEmployeeToDataBase(Employee employee)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spAddEmployeeToEmp_Payroll", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@employee_name", employee.employeeName);
                    sqlCommand.Parameters.AddWithValue("@gender", employee.gender);
                    sqlCommand.Parameters.AddWithValue("@address", employee.address);
                    sqlCommand.Parameters.AddWithValue("@start_date", employee.startDate);
                    sqlCommand.Parameters.AddWithValue("@phone_number", employee.phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@department_name", employee.departmentName);
                    sqlCommand.Parameters.AddWithValue("@basic_pay", employee.basicPay);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public void AddEmployeeListToDBWithoutThread(List<Employee> empList)
        {
            empList.ForEach(employee =>
            {
                nLog.LogDebug("Adding of Employee: " + employee.employeeName);
                Console.WriteLine("Employee being added" + employee.employeeName);
                this.AddEmployeeToDataBase(employee);
                Console.WriteLine("Employee added: " + employee.employeeName);
            });
        }

        public void AddEmployeeListToDBWithThread(List<Employee> empList)
        {
            empList.ForEach(employee =>
            {
                Task thread = new Task(() =>
                {
                    nLog.LogDebug("Adding of Employee: " + employee.employeeName);
                    Console.WriteLine("Employee Being added" + employee.employeeName);
                    this.AddEmployeeToDataBase(employee);
                    Console.WriteLine("Employee added: " + employee.employeeName);
                });
                thread.Start();
            });
        }

        public void AddToListWithoutThreading(List<Employee> empList)
        {
            empList.ForEach(employee =>
            {
                nLog.LogDebug("Adding of Employee: " + employee.employeeName);
                Console.WriteLine("Employee being added" + employee.employeeName);
                this.employeeDataList.Add(employee);
                Console.WriteLine("Employee added: " + employee.employeeName);
            });
        }

        public void AddToListWithThreading(List<Employee> empList)
        {
            empList.ForEach(employee =>
            {
                Task thread = new Task(() =>
                {
                    nLog.LogDebug("Adding of Employee: " + employee.employeeName);
                    Console.WriteLine("Employee Being added" + employee.employeeName);
                    this.employeeDataList.Add(employee);
                    Console.WriteLine("Employee added: " + employee.employeeName);
                });
                thread.Start();
            });
        }
    }
}