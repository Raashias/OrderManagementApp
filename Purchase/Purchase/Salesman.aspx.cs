using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Purchase
{
    public partial class Salesman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbConnection DbObj = new DbConnection();
            DataTable dtSalesmanResult = DbObj.Getsalesman();
            gvSalesmanDetails.DataSource = dtSalesmanResult;
            gvSalesmanDetails.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string salesmanname = "";
            string salesmancity = "";
            string commission = "";
            salesmanname = txtName.Text;
            salesmancity = txtCity.Text;
            commission = txtCommission.Text;
            DbConnection DbObj = new DbConnection();
            DbObj.InsertSalesPerson(salesmanname, salesmancity, commission);

            DataTable dtSalesmanResult = DbObj.Getsalesman();
            gvSalesmanDetails.DataSource = dtSalesmanResult;
            gvSalesmanDetails.DataBind();

        }

        protected void gvSalesmanDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Salesman_ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Edit")
            {
                DbConnection dbConnection = new DbConnection();
                DataTable dt = dbConnection.Getsalesmanid(Salesman_ID);
                txtName.Text = dt.Rows[0][1].ToString();
                txtCity.Text = dt.Rows[0][2].ToString();
                txtCommission.Text = dt.Rows[0][3].ToString();
                lblSalesman_ID.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                DbConnection DbObj = new DbConnection();
                DbObj.Deletesalesman(Salesman_ID);
                DataTable dtSalesmanResult = DbObj.Getsalesman();
                gvSalesmanDetails.DataSource = dtSalesmanResult;
                gvSalesmanDetails.DataBind();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void gvSalesmanDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvSalesmanDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Updatesalesman(Convert.ToInt32(lblSalesman_ID.Text), txtName.Text, txtCity.Text, txtCommission.Text);
            DataTable dtSalesmanResult = dbConnection.Getsalesman();
            gvSalesmanDetails.DataSource = dtSalesmanResult;
            gvSalesmanDetails.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {


        }
    }
}