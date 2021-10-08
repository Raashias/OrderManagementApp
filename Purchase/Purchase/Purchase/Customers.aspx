<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Purchase.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body> <%--Step1--%>
    <form id="form1" runat="server">
        <div>
            <table> 
                <tr>
                    <td>Customer_ID</td>
                    <asp:Label ID="lblCustomer_ID" runat="server" Text="Label"></asp:Label>
                </tr>
                <tr>
                     <td>Customer_Name</td>
                     <td>
                         <asp:TextBox ID="txtCustomer_Name" runat="server"></asp:TextBox></td>
                     <%--<td>  <asp:Label ID="lblCustomer_ID" runat="server" Text="Label"></asp:Label></td>
                    <td> <asp:Label ID="lblSalesman_ID" runat="server" Text="Label"></asp:Label></td>--%>
                </tr>
                 <tr>
                     <td>City</td>
                     <td>
                         <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Grade</td>
                     <td>
                         <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox></td>
                     </tr>
                 <tr>
                     <td>
                         <asp:Label ID="SalesmanID" runat="server" Text="SalesmanID"></asp:Label></td>
                     <td>
                         <asp:DropDownList ID="DropDownListSalesman_ID" runat="server"></asp:DropDownList></td>
                 </tr>
                <tr>
                    <td></td><td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server"  Text="Update" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
            </table>
            <div>
                <asp:GridView ID="gvCustomerDetails" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCustomerDetails_RowCommand" OnRowDeleting="gvCustomerDetails_RowDeleting" OnRowEditing="gvCustomerDetails_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="Customer_ID" HeaderText="Customer_ID" />
                        <asp:BoundField DataField="Salesman_ID" HeaderText="Salesman_ID" />
                        <asp:BoundField DataField="Cust_Name" HeaderText="Customer_Name" />
                        <asp:BoundField DataField="City" HeaderText="Customer_City" />
                        <asp:BoundField DataField="Grade" HeaderText="Customer_Grade" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Customer_ID")%>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Customer_ID")%>'>Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <%--<table>
                 <thead>
                    <tr>
                        <th>Customer_ID
                        </th>
                        <th>Customer_Name
                        </th>
                        <th>City
                        </th>
                        <th>Grade
                        </th>
                        <th>Salesman_ID
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>--%>               <%-- </tbody>
                </table>--%>
        </div>
    </form>
</body>
</html>
