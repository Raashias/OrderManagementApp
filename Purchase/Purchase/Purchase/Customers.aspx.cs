using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Purchase
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbConnection DbObj = new DbConnection();
            DataTable dtSalesmanResult = DbObj.Getsalesman();
            DropDownListSalesman_ID.Items.Add("--Select--");
            for (int i = 0; i < dtSalesmanResult.Rows.Count; i++)
            {
                DropDownListSalesman_ID.Items.Add(new ListItem(dtSalesmanResult.Rows[i][0].ToString() + "->" + dtSalesmanResult.Rows[i][1], dtSalesmanResult.Rows[i][0].ToString()));
            }

            DbConnection obj = new DbConnection();
            DataTable dtCustomerResult = obj.GetCustomer();
            gvCustomerDetails.DataSource = dtCustomerResult;
            gvCustomerDetails.DataBind();


        }
        //step2
        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            int Salesman_ID = Convert.ToInt32(DropDownListSalesman_ID.SelectedValue.ToString());
            var SalesmanName = DropDownListSalesman_ID.SelectedItem.Text;
            DbConnection dbConnection = new DbConnection();
            dbConnection.InsertCustomer(Salesman_ID, txtCustomer_Name.Text, txtCity.Text, txtGrade.Text);
            //string Customer_ID = "";
            //string Customer_Name = "";
            //string Customer_City = "";
            //string Customer_Grade = "";
            //string Salesman_ID = "";
            //Customer_ID = txtCustomerID.Text;
            //Customer_Name = txtCustomer_Name.Text;
            //Customer_City = txtCity.Text;
            //Customer_Grade = txtGrade.Text;
            //Salesman_ID = DropDownListSalesman_ID.Text;
            //DbConnection DbObj = new DbConnection();
            //DbObj.InsertCustomerPerson(Customer_Name, Customer_City, Customer_Grade);

            //DataTable dtCustomerResult = DbObj.GetCustomer();
            //gvCustomerDetails.DataSource = dtCustomerResult;
            //gvCustomerDetails.DataBind();



        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void gvCustomerDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            int Customer_ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Edit")
            {
                DbConnection dbConnection = new DbConnection();
                DataTable dt = dbConnection.GetCustomerbyID(Customer_ID);
                txtCustomer_Name.Text = dt.Rows[0][2].ToString();
                txtCity.Text = dt.Rows[0][3].ToString();
                txtGrade.Text = dt.Rows[0][4].ToString();
                lblCustomer_ID.Text = dt.Rows[0][0].ToString();
                DropDownListSalesman_ID.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                DbConnection DbObj = new DbConnection();
                DbObj.DeleteCustomer(Customer_ID);
                DataTable dtSalesmanResult = DbObj.GetCustomer();
                gvCustomerDetails.DataSource = dtSalesmanResult;
                gvCustomerDetails.DataBind();
            }


        }
        protected void gvCustomerDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvCustomerDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.UpdateCustomer(Convert.ToInt32(lblCustomer_ID.Text), Convert.ToInt32(DropDownListSalesman_ID.Text), txtCustomer_Name.Text, txtCity.Text, txtGrade.Text);
            DataTable dtSalesmanResult = dbConnection.GetCustomer();
            gvCustomerDetails.DataSource = dtSalesmanResult;
            gvCustomerDetails.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomer_Name.Text = string.Empty;
            txtGrade.Text = string.Empty;
            txtCity.Text = string.Empty;
          
        }
    }
}