using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //required for Sql Server database
                             //  ADO.NET Object Model
using System.Configuration;

//How to write a method
//  Q1: What is the purpose of your method?
//  Q2: Does your method require fomal parameters?
//          YES             NO =======> ()
//      Specify it(item)          
//      Each parameter : Type, Passing method (By Value, by ref, by out)
//  Q3: Does your method return a value explicitly?
//  Q4: Where do you use your method?


namespace Lab1_ASPNetConnectedMode.DAL
{
    public class UtilityDB
    {
        /// <summary>
        /// Version : 1 Working but not good
        /// This methods returns an active database connection
        /// </summary>
        /// <returns>Obj of type SqlConnection</returns>

        //public static SqlConnection GetDBConnection()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = "server=.;database=EmployeeDB;user=sa;password=sysadm";
        //    conn.Open();

        //    return conn;
        //}


        //We encapsulate the database informations in the file Web.config, so that the code does not have access directly to the database informations
        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn.Open();

            return conn;
        }
    }
}