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

       
    }
}
