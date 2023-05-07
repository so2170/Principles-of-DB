<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NYUProject.Pages.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:HyperLink ID="lnkRetirees" runat="server" NavigateUrl="Retirees.aspx">Retirees</asp:HyperLink>
        <p>
            <asp:HyperLink ID="lnkUsers" runat="server" NavigateUrl="SetupUsers.aspx">Mange Users</asp:HyperLink>
        </p>
       
        <p>
            <asp:HyperLink ID="lnkReports" runat="server" NavigateUrl="ReportView.aspx">Reports</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="lnkLogout" runat="server" NavigateUrl="Login.aspx">Logout</asp:HyperLink>
        </p>
    </form>
</body>
</html>
