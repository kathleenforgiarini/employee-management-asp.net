using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1_ASPNetConnectedMode.BLL;
using Lab1_ASPNetConnectedMode.DAL;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Web.UI.WebControls;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public static class EmployeeDB
    {
        public static void SaveRecord(Employee emp)
        {
            //connect DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //perform INSERT operation
            //create and customize an object of type SqlCommand
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            
            cmdInsert.CommandText = "INSERT INTO Employees (EmployeeId,FirstName,LastName,JobTitle) " +
                                    "VALUES(@EmployeeID,@FirstName,@LastName,@JobTitle)";

            cmdInsert.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmdInsert.ExecuteNonQuery();

            //close DB
            conn.Close();

        }

        public static void UpdateRecord(Employee emp)
        {
            //connect DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //perform UPDATE operation
            //create and customize an object of type SqlCommand
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = "UPDATE Employees SET " +
                                    "FirstName = '" + emp.FirstName + "', LastName = '" + emp.LastName + "', JobTitle = '" + emp.JobTitle + "' " +
                                    "WHERE EmployeeID = " + emp.EmployeeID;
           
            cmdUpdate.ExecuteNonQuery();
            //close DB
            conn.Close();

        }

        public static void DeleteRecord(int empId)
        {
            //connect DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //perform DELETE operation
            //create and customize an object of type SqlCommand
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = conn;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmployeeId = " + empId;

            cmdDelete.ExecuteNonQuery();
            //close DB
            conn.Close();
        }

        public static List<Employee> GetAllRecords()
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            Employee emp;

            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listE.Add(emp);
            }

            conn.Close();
            return listE;
        }

        public static Employee SearchRecord(int Id)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;
            cmdSearch.CommandText = "SELECT * FROM Employees " + 
                                    "WHERE EmployeeId = @EmployeeId";
            cmdSearch.Parameters.AddWithValue("@EmployeeId", Id);
            SqlDataReader reader = cmdSearch.ExecuteReader();
            Employee emp = new Employee();
            if (reader.Read())
            {
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
            }
            else
            {
                emp = null;
            }

            return emp;
        }

        public static List<Employee> SearchRecord(string input)
        {
            List<Employee> employees = new List<Employee>();

            return employees;
        }

        public static List<Employee> SearchRecord(string input1, string input2)
        {
            List<Employee> employees = new List<Employee>();

            return employees;
        }
    }
}