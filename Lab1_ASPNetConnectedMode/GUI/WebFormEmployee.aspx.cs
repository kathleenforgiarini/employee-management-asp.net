using Lab1_ASPNetConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try 
            {
                string employeeId = txtId.Text;
                string fName = txtFirstName.Text;
                string lName = txtLastName.Text;
                string jTitle = txtJobTitle.Text;

                if (employeeId == "" || fName == "" || lName == "" || jTitle == "")
                {
                    MessageBox.Show("Please fill in all fields", "Error");
                }
                else
                {
                    int empId = int.Parse(employeeId);
                    Employee employee = new Employee(empId, fName, lName, jTitle);
                    employee.SaveEmployee(employee);
                    MessageBox.Show("Employee saved", "Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeId = txtId.Text;
                string fName = txtFirstName.Text;
                string lName = txtLastName.Text;
                string jTitle = txtJobTitle.Text;

                if (employeeId == "" || fName == "" || lName == "" || jTitle == "")
                {
                    MessageBox.Show("Please fill in all fields", "Error");
                }
                else
                {
                    int empId = int.Parse(employeeId);
                    Employee employee = new Employee(empId, fName, lName, jTitle);
                    employee.UpdateEmployee(employee);
                    MessageBox.Show("Employee updated", "Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeId = txtId.Text;
               
                if (employeeId == "")
                {
                    MessageBox.Show("Please fill in the Employee ID", "Error");
                }
                else
                {
                    int empId = int.Parse(employeeId);
                    Employee.DeleteEmployee(empId);
                    MessageBox.Show("Employee deleted", "Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void btnListAll_Click(object sender, EventArgs e)
        {
            DataTable dt = Employee.ListAllEmployees();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}