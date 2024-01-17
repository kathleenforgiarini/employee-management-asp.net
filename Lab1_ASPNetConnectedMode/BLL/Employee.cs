using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1_ASPNetConnectedMode.BLL
{
    //instance class
    public class Employee
    {

        //class variables
        private int employeeID;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //properties
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }


        //default constructor
        public Employee()
        {
            employeeID = 0;
            firstName = string.Empty;
            lastName = string.Empty;
            jobTitle = string.Empty;
        }

        //parameterized constructor
        public Employee(int employeeID,  string firstName, string lastName, string jobTitle)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;
        }

        //custom methods
        //public int GetEmployeeID() { return employeeID; }
        //public void SetEmployeeID(int employeeID) { this.employeeID = employeeID; }

    }
}