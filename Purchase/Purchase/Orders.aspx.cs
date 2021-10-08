using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Purchase
{
    public partial class Orders : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DbConnection DbObj = new DbConnection();
                DataTable dtCustomerResult = DbObj.GetCustomer();
                DropDownListCustomer_ID.Items.Add("--Select--");
                DropDownListSalesman_ID.Items.Add("--Select--");
                for (int i = 0; i < dtCustomerResult.Rows.Count; i++)
                {
                    DropDownListCustomer_ID.Items.Add(new ListItem(dtCustomerResult.Rows[i][0].ToString() + "->" + dtCustomerResult.Rows[i][2], dtCustomerResult.Rows[i][0].ToString()));
                    DropDownListSalesman_ID.Items.Add(new ListItem(dtCustomerResult.Rows[i][0].ToString() + "->" + dtCustomerResult.Rows[i][1], dtCustomerResult.Rows[i][1].ToString()));
                    //txtSalesmanID.Text = (string)dtCustomerResult.Rows[i][1];
                    //string a = Convert.ToString(txtSalesmanID.Text);
                    //a = (string)(dtCustomerResult.Rows[i][1]);
                }

            }
            DbConnection obj = new DbConnection();
            DataTable dtOrderResult = obj.GetOrder();
            gvOrderDetails.DataSource = dtOrderResult;
            gvOrderDetails.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            int Customer_ID = Convert.ToInt32(DropDownListCustomer_ID.SelectedValue.ToString());
            int Salesman_ID = Convert.ToInt32(DropDownListSalesman_ID.SelectedValue.ToString());
            var CustomerName = DropDownListCustomer_ID.SelectedItem.Text;
            DbConnection dbConnection = new DbConnection();
            dbConnection.InsertOrder(txtPurchAmt.Text,txtOrderDate.Text, Convert.ToString(Customer_ID),Salesman_ID);
            DbConnection obj = new DbConnection();
            DataTable dtOrderResult = obj.GetOrder();
            gvOrderDetails.DataSource = dtOrderResult;
            gvOrderDetails.DataBind();
        }

        protected void gvOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Order_No = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Edit")
            {
                DbConnection dbConnection = new DbConnection();
                DataTable dt = dbConnection.GetOrderbyID(Order_No);
                txtPurchAmt.Text = dt.Rows[0][1].ToString();
                txtOrderDate.Text = dt.Rows[0][2].ToString();
                lblOrderNo.Text = dt.Rows[0][0].ToString();
                DropDownListCustomer_ID.Text = dt.Rows[0][3].ToString();
                DropDownListSalesman_ID.Text = dt.Rows[0][4].ToString();
            }
            else
            {
                DbConnection DbObj = new DbConnection();
                DbObj.DeleteOrder(Order_No);
                DataTable dtOrderResult = DbObj.GetOrder();
                gvOrderDetails.DataSource = dtOrderResult;
                gvOrderDetails.DataBind();
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DbConnection DbObj = new DbConnection();
            DbObj.UpdateOrder(Convert.ToInt32(lblOrderNo.Text),txtPurchAmt.Text, txtOrderDate.Text,DropDownListCustomer_ID.Text,Convert.ToInt32(DropDownListSalesman_ID.Text));
            DataTable dtOrderResult = DbObj.GetOrder();
            gvOrderDetails.DataSource = dtOrderResult;
            gvOrderDetails.DataBind();
        }

        protected void gvOrderDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}