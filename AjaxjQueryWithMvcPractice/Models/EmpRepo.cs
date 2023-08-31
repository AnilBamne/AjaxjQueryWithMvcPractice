using System.Collections.Generic;

namespace AjaxjQueryWithMvcPractice.Models
{
    public class EmpRepo
    {
        //this is the repository class
        List<Employee> list = new List<Employee> ();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string Add(Employee employee)
        {
            list.Add(employee);
            return "successfull";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetList()
        {
            return list;
        }
    }
}
