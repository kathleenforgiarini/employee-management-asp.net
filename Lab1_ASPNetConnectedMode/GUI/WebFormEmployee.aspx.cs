using Lab1_ASPNetConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Add("Employee ID");
                DropDownList1.Items.Add("First Name");
                DropDownList1.Items.Add("Last Name");
                DropDownList1.Items.Add("Job Title");
                DropDownList1.Items.Add("First Name & Last Name");
                GridView1.HeaderStyle.ForeColor = Color.Chocolate;
            }
        }
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
            GridView1.DataSource = Employee.GetAllEmployees();
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedColumn = DropDownList1.SelectedItem.ToString();
                string search = txtSearch.Text.ToString();
                List<Employee> employees = new List<Employee>();
                if (selectedColumn == "Employee ID")
                {
                    int empId = Convert.ToInt32(search);
                    Employee emp = Employee.SearchEmployee(empId);
                    if (emp != null)
                    {
                        employees.Add(emp);
                        Label1.Text = "";
                        GridView1.DataSource = employees;
                        GridView1.DataBind();
                    }
                    else
                    {
                        employees.Clear();
                        Label1.Text = "Employee not found";
                        GridView1.DataSource = employees;
                        GridView1.DataBind();
                    }
                }
                
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }

    }
}