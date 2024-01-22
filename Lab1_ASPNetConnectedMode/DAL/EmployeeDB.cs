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
        //1. A method to save an employee record to the database
        /// <summary>
        /// Version : 2 Solving SQL injection
        /// This method saves an employee record to the database
        /// </summary>
        /// <param name="emp"></param>

        //insert into Employees
        //values(8888, 'John', 'Thomas', 'Java Programmer');

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

        internal static void DeleteRecord(int empId)
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

        internal static DataTable listAll()
        {
            SqlConnection conn = UtilityDB.GetDBConnection();

            //perform SELECT operation
            //create and customize an object of type SqlCommand
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = conn;
            cmdSelect.CommandText = "SELECT * FROM Employees";
            SqlDataAdapter adapter = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //close DB
            conn.Close();
            return dt;            
        }
    }
}