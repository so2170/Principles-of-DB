<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetupUsers.aspx.cs" Inherits="NYUProject.SetupUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
         <div>
             <br />
             <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="Home.aspx">Home</asp:HyperLink>
             <br />
            <br />
            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="#CC6600"></asp:Label>
            <br />
             <br />
        </div>
        <hr />
        <div>
            <p>
                <strong>Setup and Manage Users
            </strong>
            </p>
            <hr />
             <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3" DataKeyNames="Login_id" OnRowCancelingEdit="gvUsers_RowCancelingEdit" OnRowCommand="gvUsers_RowCommand" 
                OnRowDeleting="gvUsers_RowDeleting" OnRowEditing="gvUsers_RowEditing" OnRowUpdating="gvUsers_RowUpdating" ShowFooter="true" 
                ShowHeaderwhenEmpty="true">
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
                    
                    <asp:BoundField DataField="Login_id" HeaderText="ID" />
                    <asp:TemplateField HeaderText="User ID">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("userid") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUserID" runat="server" Text='<%# Eval("userid") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtUserIDFooter" runat="server" />
                        </FooterTemplate>
                     </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <asp:Label runat="server" Text="******" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPassword" runat="server" Text='<%# Eval("password") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPasswordFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Status") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStatus" runat="server" Text='<%# Eval("Status") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtStatusFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton runat="server" CommandName="Edit" Height="20px" ImageUrl="edit.png" ToolTip="Edit" Width="20px" />
                            <asp:ImageButton runat="server" CommandName="Delete" Height="20px" ImageUrl="delete.png" ToolTip="Delete" Width="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton runat="server" CommandName="Update" Height="20px" ImageUrl="save.png" ToolTip="Update" Width="20px" />
                            <asp:ImageButton runat="server" CommandName="Cancel" Height="20px" ImageUrl="cancel.png" ToolTip="Cancel" Width="20px" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton runat="server" CommandName="AddNew" Height="20px" ImageUrl="addnew.png" ToolTip="Add New" Width="20px" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <hr />
        </p>
        </div>
    </form>
</body>
</html>
