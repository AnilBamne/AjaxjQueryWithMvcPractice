using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AjaxjQueryWithMvcPractice.Models
{
    public class EmpRepo
    {
        private readonly string _ConnectionString;
        private readonly SqlConnection sqlConnection;
        public EmpRepo(IConfiguration configuration)
        {

            this._ConnectionString = configuration.GetConnectionString("ConnectDB");
            this.sqlConnection = new SqlConnection(this._ConnectionString);
        }
        //this is the repository class
        //List<Employee> list = new List<Employee> ();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        //public string Add(Employee employee)
        //{
        //    list.Add(employee);
        //    return "successfull";
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public List<Employee> GetList()
        //{
        //    return list;
        //}

        public string AddEmp(Employee employee)
        {
            try
            {
                using (sqlConnection)
                {
                    string query = @"Insert Into tbl_Employees Values(@empName,@empDesignation,@empEmail);";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@empName", employee.Name);
                    cmd.Parameters.AddWithValue("@empDesignation", employee.Designation);
                    cmd.Parameters.AddWithValue("@empEmail", employee.Email);
                    sqlConnection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count >= 1)
                    {
                        return "Employee Added";
                    }
                    return "Employee not added";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public IEnumerable<Employee> GetAllEmp()
        {
            try
            {
                using (sqlConnection)
                {
                    string query = @"Select * From tbl_Employees;";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader=cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<Employee> list = new List<Employee>();
                        while (reader.Read())
                        {
                            Employee emp = new Employee();
                            emp.Id = reader.GetInt32(0);
                            emp.Name = reader.GetString(1);
                            emp.Designation = reader.GetString(2);
                            emp.Email = reader.GetString(3);
                            list.Add(emp);
                        }
                        return list;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
