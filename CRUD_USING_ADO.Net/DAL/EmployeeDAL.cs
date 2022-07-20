using CRUD_USING_ADO.Net.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_USING_ADO.Net.DAL
{
    public class EmployeeDAL
    {
      
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            public EmployeeDAL()
            {
                con = new SqlConnection(Startup.ConnectionString);
            }
            public List<Employee> GetAllEmployee()
            {
                List<Employee> elist = new List<Employee>();

                string qry = "select * from Employee;";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Employee p = new Employee();
                        p.Id = Convert.ToInt32(dr["Id"]);
                        p.Name = dr["Name"].ToString();
                        p.Salary = Convert.ToDouble(dr["Salary"]);
                        elist.Add(p);
                    }
                }
                con.Close();
                return elist;

            }
            public Employee GetEmployeeById(int id)
            {
                Employee p = new Employee();
                string qry = "select * from Employee where Id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        p.Id = Convert.ToInt32(dr["Id"]);
                        p.Name = dr["Name"].ToString();
                        p.Salary = Convert.ToDouble(dr["Salary"]);
                    }
                }
                con.Close();
                return p;
            }

            public int AddEmployee(Employee emp)
            {
                string qry = "insert into employee values(@name,@salary)";
                cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            public int UpdateEmployee(Employee emp)
            {
                string qry = "update Employee set Name=@name,Salary=@salary where Id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            public int DeleteEmployee(int id)
            {
                string qry = "delete from Employee where Id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }
}
