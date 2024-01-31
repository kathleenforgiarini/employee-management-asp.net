using Lab1_ASPNetConnectedMode.BLL;
using Lab1_ASPNetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Lab1_ASPNetConnectedMode.VALIDATION;

// State Management in ASP.Net
// Http : Stateless
//      Client side state management
//          - ViewState
//
//      Server Side State Management
//          - Database
//          - Session State
//          - Application State

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
                Label1.Text = "Please enter the Employee ID";
                txtSearch.Focus();
                GridView1.HeaderStyle.ForeColor = Color.Chocolate;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeId = txtId.Text.Trim();
                string fName = txtFirstName.Text.Trim();
                string lName = txtLastName.Text.Trim();
                string jTitle = txtJobTitle.Text.Trim();

                if (!Validator.IsValidId(employeeId))
                {
                    MessageBox.Show("Employee ID must be a 4-digit number", "Invalid Employee Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtId.Text = "";
                    txtId.Focus();
                    return;
                }
                if (!Validator.IsValidName(fName))
                {
                    MessageBox.Show("Invalid first name \nPlease enter another name", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFirstName.Text = "";
                    txtFirstName.Focus();
                    return;
                }
                if (!Validator.IsValidName(lName))
                {
                    MessageBox.Show("Invalid last name \nPlease enter another name", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLastName.Text = "";
                    txtLastName.Focus();
                    return;
                }
                if (!Validator.IsValidName(jTitle))
                {
                    MessageBox.Show("Invalid job title \nPlease enter another job title", "Invalid Job Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtJobTitle.Text = "";
                    txtJobTitle.Focus();
                    return;
                }

                int empId = Convert.ToInt32(employeeId);
                Employee employee = new Employee(empId, fName, lName, jTitle);
                employee.SaveEmployee(employee);
                MessageBox.Show("Employee saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridView1.DataSource = Employee.GetAllEmployees();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wront", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeId = txtId.Text.Trim();
                string fName = txtFirstName.Text.Trim();
                string lName = txtLastName.Text.Trim();
                string jTitle = txtJobTitle.Text.Trim();

                if (!Validator.IsValidId(employeeId))
                {
                    MessageBox.Show("Employee ID must be a 4-digit number", "Invalid Employee Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtId.Text = "";
                    txtId.Focus();
                    return;
                }
                if (!Validator.IsValidName(fName))
                {
                    MessageBox.Show("Invalid first name \nPlease enter another name", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFirstName.Text = "";
                    txtFirstName.Focus();
                    return;
                }
                if (!Validator.IsValidName(lName))
                {
                    MessageBox.Show("Invalid last name \nPlease enter another name", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLastName.Text = "";
                    txtLastName.Focus();
                    return;
                }
                if (!Validator.IsValidName(jTitle))
                {
                    MessageBox.Show("Invalid job title \nPlease enter another job title", "Invalid Job Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtJobTitle.Text = "";
                    txtJobTitle.Focus();
                    return;
                }

                int empId = int.Parse(employeeId);
                Employee employee = new Employee(empId, fName, lName, jTitle);
                employee.UpdateEmployee(employee);
                MessageBox.Show("Employee updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridView1.DataSource = Employee.GetAllEmployees();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wront", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = GridView1.Rows.Count;
                if (rows != 1)
                {
                    MessageBox.Show("Please search for an employee first", "Mandatory search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSearch.Focus();
                    return;
                }

                GridViewRow row = GridView1.Rows[0];
                int empId = Convert.ToInt32(row.Cells[0].Text);
                string fName = row.Cells[1].Text;
                string lName = row.Cells[2].Text;
                string job = row.Cells[3].Text;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?\n" +
                                                      empId.ToString() + " - " + fName + " " + lName + " - " +
                                                      job, "Delete Employee", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    Employee.DeleteEmployee(empId);
                    MessageBox.Show("Employee deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridView1.DataSource = Employee.GetAllEmployees();
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wront", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnListAll_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = Employee.GetAllEmployees();
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtJobTitle.Text = "";
            GridView1.DataSource = Employee.GetAllEmployees(); 
            GridView1.DataBind();
            string input  = txtSearch.Text.Trim();
            List<Employee> employees = new List<Employee>();
            Employee emp = null;

            switch (DropDownList1.SelectedIndex)
            {
                case 0:
                    if (!Validator.IsValidId(input))
                    {
                        MessageBox.Show("Employee ID must be a 4-digit number", "Invalid Employee Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Text = "";
                        txtSearch.Focus();
                        return;
                    }
                    emp = Employee.SearchEmployee(Convert.ToInt32(input));
                    if (emp != null)
                    {
                        employees.Add(emp);
                    }
                    break; 

                case 1: 
                    if (!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid first name \nPlease enter another name", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Text = "";
                        txtSearch.Focus();
                        return;
                    }
                    employees = Employee.SearchEmployeeByFName(input);
                    break; 

                case 2:
                    if (!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid last name \nPlease enter another name", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Text = "";
                        txtSearch.Focus();
                        return;
                    }
                    employees = Employee.SearchEmployeeByLName(input);
                    break;

                case 3:
                    if (!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid job title \nPlease enter another job title", "Invalid Job Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Text = "";
                        txtSearch.Focus();
                        return;
                    }
                    employees = Employee.SearchEmployee(input);
                    break; 

                case 4:
                    string input2 = txtSearch2.Text.Trim();
                    if (!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid first name \nPlease enter another name", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Text = "";
                        txtSearch.Focus();
                        return;
                    }
                    if (!Validator.IsValidName(input2))
                    {
                        MessageBox.Show("Invalid last name \nPlease enter another name", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch2.Text = "";
                        txtSearch2.Focus();
                        return;
                    }
                    employees = Employee.SearchEmployee(input, input2);
                    break; 

                default: 
                    break;
            }

            if (employees.Count == 1)
            {
                Label1.Text = "";
                GridView1.DataSource = employees;
                GridView1.DataBind();
                foreach (var emps in employees)
                {
                    txtId.Text = emps.EmployeeID.ToString();
                    txtFirstName.Text = emps.FirstName.ToString();
                    txtLastName.Text = emps.LastName.ToString();
                    txtJobTitle.Text = emps.JobTitle.ToString();
                }
                
            }
            else if (employees.Count > 1)
            {
                Label1.Text = "";
                GridView1.DataSource = employees;
                GridView1.DataBind();
            }
            else
            {
                MessageBox.Show("Employee not found!", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList1.SelectedIndex)
            {
                case 0:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter the Employee ID";
                        txtSearch2.Visible = false;
                    }
                    break; 

                case 1:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter the Employee First Name";
                        txtSearch2.Visible = false;
                    }
                    break; 

                case 2:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter the Employee Last Name";
                        txtSearch2.Visible = false;
                    }
                    break;

                case 3:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter the Job Title";
                        txtSearch2.Visible = false;
                    }
                    break;

                case 4:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter the Employee First Name and Last Name";
                        txtSearch2.Visible = true;
                    }
                    break;

                default:
                    txtSearch2.Visible = false;
                    break;
            }
            Label1.Text = Session["message"].ToString();
            txtSearch.Focus();
        }
    }
}