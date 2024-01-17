using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;    // just for testing
using Lab1_ASPNetConnectedMode.DAL; // just for testing
using Lab1_ASPNetConnectedMode.BLL;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebFormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonConnectDB_Click(object sender, EventArgs e)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            MessageBox.Show("Database connection is " + conn.State.ToString());
        }

        protected void ButtonSaveEmployee_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee(8881, "Mary", "Green", "C# Programmer");
            employee.SaveEmployee(employee);
            MessageBox.Show("Employee saved", "Saved");
        }
    }
}