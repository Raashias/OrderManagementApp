<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Purchase.Orders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table> 
                <tr>
                    <td>Order_No</td>
                    <td>
                        <asp:Label ID="lblOrderNo" runat="server" Text="Label"></asp:Label></td> 
                </tr>
                <tr>
                     <td>Purch_Amt</td>
                     <td>
                         <asp:TextBox ID="txtPurchAmt" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                     <td>Order_Date</td>
                     <td>
                         <asp:TextBox ID="txtOrderDate" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Customer_ID</td>
                     <td>
                         <asp:DropDownList ID="DropDownListCustomer_ID" runat="server"></asp:DropDownList>
                        </td>
                     </tr>
                 <tr>
                     <td>Salesman_ID</td>
                     <td>
                         <asp:DropDownList ID="DropDownListSalesman_ID" runat="server"></asp:DropDownList></td>
                 </tr>
                <tr>
                    <td></td><td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" />
                        <asp:Button ID="Button1" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    </td>
                </tr>
            </table>
            <div>
                <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" OnRowCommand="gvOrderDetails_RowCommand" OnRowDeleting="gvOrderDetails_RowDeleting" OnRowEditing="gvOrderDetails_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="Ord_no" HeaderText="OrderNo" />
                        <asp:BoundField DataField="Purch_Amt" HeaderText="Purchase_Amt" />
                        <asp:BoundField DataField="Ord_date" HeaderText="Order_Date" />
                        <asp:BoundField DataField="Customer_ID" HeaderText="Customer_ID" />
                        <asp:BoundField DataField="Salesman_ID" HeaderText="Salesman_ID" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Ord_no")%>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Ord_no")%>'>Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
