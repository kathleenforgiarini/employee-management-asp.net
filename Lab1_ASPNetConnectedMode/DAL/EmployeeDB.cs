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
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
            
                cmdInsert.CommandText = "INSERT INTO Employees (EmployeeId,FirstName,LastName,JobTitle) " +
                                        "VALUES(@EmployeeID,@FirstName,@LastName,@JobTitle)";

                cmdInsert.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
                cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
                cmdInsert.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static void UpdateRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();

            try
            { 
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE Employees SET " +
                                        "FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle " +
                                        "WHERE EmployeeID = @EmployeeID";

                cmdUpdate.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                cmdUpdate.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmdUpdate.Parameters.AddWithValue("@LastName", emp.LastName);
                cmdUpdate.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("No records updated");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static void DeleteRecord(int empId)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();

            try
            {
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandText = "DELETE FROM Employees WHERE EmployeeId = @EmployeeID";
                cmdDelete.Parameters.AddWithValue("@EmployeeID", empId);
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Employee> GetAllRecords()
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
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

                return listE;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static Employee SearchRecord(int Id)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
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
            catch (SqlException ex)
            { 
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        public static List<Employee> SearchRecordByFName(string input)
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSelectByName = new SqlCommand();
                cmdSelectByName.Connection = conn;
                cmdSelectByName.CommandText = "SELECT * FROM Employees " +
                                              "WHERE FirstName = @FirstName";

                cmdSelectByName.Parameters.AddWithValue("@FirstName", input);

                SqlDataReader reader = cmdSelectByName.ExecuteReader();
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
                return listE;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static List<Employee> SearchRecordByLName(string input)
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSelectByName = new SqlCommand();
                cmdSelectByName.Connection = conn;
                cmdSelectByName.CommandText = "SELECT * FROM Employees " +
                                              "WHERE LastName = @LastName";

                cmdSelectByName.Parameters.AddWithValue("@LastName", input);

                SqlDataReader reader = cmdSelectByName.ExecuteReader();
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
                return listE;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static List<Employee> SearchRecord(string input)
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSelectByJob = new SqlCommand();
                cmdSelectByJob.Connection = conn;
                cmdSelectByJob.CommandText = "SELECT * FROM Employees " +
                                              "WHERE JobTitle = @JobTitle";

                cmdSelectByJob.Parameters.AddWithValue("@JobTitle", input);

                SqlDataReader reader = cmdSelectByJob.ExecuteReader();
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
                return listE;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static List<Employee> SearchRecord(string input1, string input2)
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSelectByName = new SqlCommand();
                cmdSelectByName.Connection = conn;
                cmdSelectByName.CommandText = "SELECT * FROM Employees " +
                                              "WHERE FirstName = @FirstName AND LastName = @LastName";

                cmdSelectByName.Parameters.AddWithValue("@FirstName", input1);
                cmdSelectByName.Parameters.AddWithValue("@LastName", input2);

                SqlDataReader reader = cmdSelectByName.ExecuteReader();
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
                return listE;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
    }
}