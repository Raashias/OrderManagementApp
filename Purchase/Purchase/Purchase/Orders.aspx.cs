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
            DbConnection DbObj = new DbConnection();
            DataTable dtCustomerResult = DbObj.GetCustomer();
            DropDownListCustomer_ID.Items.Add("--Select--");
            for (int i = 0; i < dtCustomerResult.Rows.Count; i++)
            {
                DropDownListCustomer_ID.Items.Add(new ListItem(dtCustomerResult.Rows[i][0].ToString() + "->" + dtCustomerResult.Rows[i][2], dtCustomerResult.Rows[i][0].ToString()));
                //string a = Convert.ToString(txtSalesmanID.Text);
                //a = (string)(dtCustomerResult.Rows[i][1]);
            }

            DbConnection obj = new DbConnection();
            DataTable dtOrderResult = obj.GetOrder();
            gvOrderDetails.DataSource = dtOrderResult;
            gvOrderDetails.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            int Customer_ID = Convert.ToInt32(DropDownListCustomer_ID.SelectedValue.ToString());
            var CustomerName = DropDownListCustomer_ID.SelectedItem.Text;
            DbConnection dbConnection = new DbConnection();
            dbConnection.InsertOrder(txtPurchAmt.Text, txtOrderDate.Text, Convert.ToString(Customer_ID), txtSalesmanID.Text);
        }
    }
}