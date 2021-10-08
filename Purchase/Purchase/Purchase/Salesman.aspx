<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salesman.aspx.cs" Inherits="Purchase.Salesman" %>

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
                    <td>Salesman_ID</td>
                    <td><asp:TextBox ID="txtSalesmanID" runat="server"></asp:TextBox></td> 
                </tr>
                <tr>
                     <td>Name</td>
                     <td>
                         <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                         <asp:Label ID ="lblSalesman_ID" runat="server"></asp:Label>
                     </td>

                </tr>
                 <tr>
                     <td>City</td>
                     <td>
                         <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>Commission</td>
                     <td>
                         <asp:TextBox ID="txtCommission" runat="server"></asp:TextBox></td>
                     </tr>
              
                <tr>
                    <td></td><td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                        <asp:Button ID="Update" runat="server" Text="Update" OnClick="btnUpdate_Click"  />
                    </td>
                </tr>
                             </table>
                 <div>
                     <asp:GridView ID="gvSalesmanDetails" runat="server" AutoGenerateColumns="False" OnRowCommand="gvSalesmanDetails_RowCommand" OnRowDeleting="gvSalesmanDetails_RowDeleting" OnRowEditing="gvSalesmanDetails_RowEditing">
                         <Columns>
                             <asp:BoundField DataField="Salesman_ID" HeaderText="Salesman_ID" />
                             <asp:BoundField DataField="Name" HeaderText="Salesman_Name" />
                             <asp:BoundField DataField="City" HeaderText="City" />
                             <asp:BoundField DataField="Commission" HeaderText="Commission" />
                             <asp:TemplateField HeaderText="Edit">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Salesman_ID")%>'>Edit</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Delete">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Salesman_ID") %>'>Delete</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                 </div>
        </div>
    </form>
</body>
</html>
