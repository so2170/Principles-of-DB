<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Retirees.aspx.cs" Inherits="NYUProject.Pages.Retirees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="Home.aspx">Home</asp:HyperLink>
            <br />
        </div>
      
        <br />


        <asp:GridView ID="gvRetirees" runat="server"  AutoGenerateColumns ="false" ShowFooter="true" DataKeyNames="Retiree_id"
            ShowHeaderwhenEmpty ="true"  
            OnRowCommand="gvRetirees_RowCommand" OnRowEditing="gvRetirees_RowEditing" OnRowCancelingEdit="gvRetirees_RowCancelingEdit"
                OnRowUpdating="gvRetirees_RowUpdating" OnRowDeleting="gvRetirees_RowDeleting"

            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
          
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <Columns>
                <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Details" CommandName="Details" CommandArgument='<%# Eval("Retiree_id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
                 <asp:BoundField DataField="retiree_id" HeaderText="ID" />
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:label Text='<%# Eval("FirstName") %>' runat ="server" />
                     </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat ="server" />
                     </EditItemTemplate>
                     <FooterTemplate>
                        <asp:TextBox ID="txtFirstNameFooter"  runat ="server" />
                     </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:label Text='<%# Eval("LastName") %>' runat ="server" />
                     </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat ="server" />
                     </EditItemTemplate>
                     <FooterTemplate>
                        <asp:TextBox ID="txtLastNameFooter"  runat ="server" />
                     </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date of Birth">
                    <ItemTemplate>
                        <asp:label Text='<%# Eval("DateofBirth") %>' runat ="server" />
                     </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="txtDOB" Text='<%# Eval("DateofBirth") %>' runat ="server" />
                     </EditItemTemplate>
                     <FooterTemplate>
                        <asp:TextBox ID="txtDOBFooter"  runat ="server" />
                     </FooterTemplate>
                    </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Age">
                    <ItemTemplate>
                        <asp:label Text='<%# Eval("Age") %>' runat ="server" />
                     </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="txtAge" Text='<%# Eval("Age") %>' runat ="server" />
                     </EditItemTemplate>
                     <FooterTemplate>
                        <asp:TextBox ID="txtAgeFooter"  runat ="server" />
                     </FooterTemplate>
                    </asp:TemplateField>
                
                     <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Emailaddress") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" Text='<%# Eval("Emailaddress") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmailFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                             <asp:ImageButton Visible="False" ImageUrl="view.png" runat="server" CommandName="View" ToolTip="View Details" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
    </form>
</body>
</html>
