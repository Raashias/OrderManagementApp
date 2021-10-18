using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Purchase
{
    public class DbConnection
    {
        public void InsertSalesPerson(string Name, string city, string commission)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("insert into salesman(Name,city,commission) values('" + Name + "','" + city + "'," + commission + ")", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataTable Getsalesman()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from salesman", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;
        }
        public DataTable Getsalesmanid(int Salesman_ID)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from salesman where Salesman_ID = " + Salesman_ID + "", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;
        }

        public DataTable Updatesalesman(int Salesman_ID, string Name, string City, string commission)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("Update salesman set Name = '" + Name + "', City ='" + City + "', Commission = '" + commission + "' where Salesman_ID = " + Salesman_ID + "", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;

        }

        public void Deletesalesman(int Salesman_ID)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("Delete from salesman where Salesman_ID = " + Salesman_ID + "", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        //Customer

        //Step3
        public void InsertCustomer(int Salesman_ID, string CustomerName, string Customercity, string CustomerGrade)
        {
            //string insertQuery = "insert into customer values(" + Customer_ID + "," + Salesman_ID + ",'" + CustomerName + "','" + Customercity + "','" + CustomerGrade + "')";
            //ExecuteQry(insertQuery);
            //return "Inserted";
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("insert into customer values( " + Salesman_ID + ", '" + CustomerName + "','" + Customercity + "','" + CustomerGrade + "')", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void ExecuteQry(string insertQuery)
        {

            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(insertQuery, sqlConnection);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

        }

        public DataTable GetCustomer()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from customer", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;
        }

        public DataTable GetCustomerbyID(int Customer_ID)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from customer where Customer_ID = " + Customer_ID + "", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;
        }

        public void DeleteCustomer(int Customer_ID)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("Delete from customer where Customer_ID = " + Customer_ID + "", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataTable UpdateCustomer(int Customer_ID, int Salesman_ID, string Name, string City, string grade)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("Update customer set Cust_Name = '" + Name + "', City ='" + City + "', Grade = '" + grade + "' where Customer_ID = " + Customer_ID + "", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;

        }


        public void InsertOrder(string PurchaseAmt, DateTime OrdDate, string Customer_ID, int Salesman_ID)
        {
            //string insertQuery = "insert into customer values(" + Customer_ID + "," + Salesman_ID + ",'" + CustomerName + "','" + Customercity + "','" + CustomerGrade + "')";
            //ExecuteQry(insertQuery);
            //return "Inserted";
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("insert into orders(Purch_Amt,Ord_Date,Customer_ID,Salesman_ID) values( " + PurchaseAmt + ", '" + OrdDate + "'," + Customer_ID + "," + Salesman_ID + ")", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public DataTable GetOrder()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from orders", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;
        }

        public DataTable GetOrderbyID(int Order_No)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from orders where Ord_No = " + Order_No + "", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;
        }
        public void DeleteOrder(int Order_No)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("Delete from orders where Ord_No = " + Order_No + "", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public DataTable UpdateOrder(int Order_No, string Purch_Amt, DateTime Ord_date, string Customer_ID, int Salesman_ID)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-1EQ6NMD1;Initial Catalog=Purchase;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("Update orders set Purch_Amt = '" + Purch_Amt + "', Ord_Date ='" + Ord_date + "', Customer_ID = '" + Customer_ID + "', Salesman_ID = " + Salesman_ID + " where Ord_No = " + Order_No + "", sqlConnection);
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlConnection.Close();
            return dt;

        }

    }
}