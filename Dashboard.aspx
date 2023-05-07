<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="NYUProject.Pages.WebForm1" %>

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
            <br />
        </div>
        <strong>Retiree Dashboard<br />
        </strong>
        <asp:GridView ID="gvRetirees" runat="server">
        </asp:GridView>
        <p>
            &nbsp;</p>
         <hr />
<p>
            <strong>Address Details</strong></p>
        
        <p>
            &nbsp;</p>
        
            <asp:GridView ID="gvAddress" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3" DataKeyNames="Address_id" OnRowCancelingEdit="gvAddress_RowCancelingEdit" OnRowCommand="gvAddress_RowCommand" 
                OnRowDeleting="gvAddress_RowDeleting" OnRowEditing="gvAddress_RowEditing" OnRowUpdating="gvAddress_RowUpdating" ShowFooter="true" 
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
                    
                    <asp:BoundField DataField="Address_ID" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Address Line 1">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Addressline1") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAddressline1" runat="server" Text='<%# Eval("Addressline1") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddressline1Footer" runat="server" />
                        </FooterTemplate>
                     </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Address Line 2">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Addressline2") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAddressline2" runat="server" Text='<%# Eval("Addressline2") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAddressline2Footer" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("City") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCity" runat="server" Text='<%# Eval("City") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCityFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("State") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtState" runat="server" Text='<%# Eval("State") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtStateFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Zipcode">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Zipcode") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtZip" runat="server" Text='<%# Eval("Zipcode") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtZipFooter" runat="server" />
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
        </p>
        
            &nbsp;</p>
           <hr />
        <p>
            <strong>Beneficiaries</strong></p>
        <p>
           
            <asp:GridView ID="gvBene" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3" DataKeyNames="Bene_id" OnRowCancelingEdit="gvBene_RowCancelingEdit" OnRowCommand="gvBene_RowCommand" 
                OnRowDeleting="gvBene_RowDeleting" OnRowEditing="gvBene_RowEditing" OnRowUpdating="gvBene_RowUpdating" ShowFooter="true" 
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
                    
                    <asp:BoundField DataField="Bene_ID" HeaderText="ID" />
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Firstname") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Eval("Firstname") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFirstNameFooter" runat="server" />
                        </FooterTemplate>
                     </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Lastname") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" runat="server" Text='<%# Eval("Lastname") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLastNameFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Relationship">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Relationship") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtRelationship" runat="server" Text='<%# Eval("Relationship") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtRelationshipFooter" runat="server" />
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
    
        <br />
            &nbsp;</p>
        <p>
            <strong>Bank Details</strong></p>
        <hr />
        <p>
            <asp:GridView ID="gvBank" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3" DataKeyNames="Bank_id" OnRowCancelingEdit="gvBank_RowCancelingEdit" OnRowCommand="gvBank_RowCommand" 
                OnRowDeleting="gvBank_RowDeleting" OnRowEditing="gvBank_RowEditing" OnRowUpdating="gvBank_RowUpdating" ShowFooter="true" 
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
                    
                    <asp:BoundField DataField="Bank_ID" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Bank Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Bankname") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBankName" runat="server" Text='<%# Eval("Bankname") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtBankNameFooter" runat="server" />
                        </FooterTemplate>
                     </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Routing Number">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Routingno") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtRoutingno" runat="server" Text='<%# Eval("Routingno") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtRoutingnoFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Number">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Accountno") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAccountno" runat="server" Text='<%# Eval("Accountno") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAccountnoFooter" runat="server" />
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
        </p>
        
        <p>
            <strong>Payment Details</strong></p>
        <p>
              <asp:GridView ID="gvPayment" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3" DataKeyNames="Pay_id" OnRowCancelingEdit="gvPayment_RowCancelingEdit" OnRowCommand="gvPayment_RowCommand" 
                OnRowDeleting="gvPayment_RowDeleting" OnRowEditing="gvPayment_RowEditing" OnRowUpdating="gvPayment_RowUpdating" ShowFooter="true" 
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
                    
                    <asp:BoundField DataField="Pay_id" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Payment Date">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Paymentdate") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPaymentDate" runat="server" Text='<%# Eval("Paymentdate") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPaymentDateFooter" runat="server" />
                        </FooterTemplate>
                     </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Gross Amount">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Grossamount") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtGrossamount" runat="server" Text='<%# Eval("Grossamount") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtGrossamountFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Net Amount">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Netamount") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNetamount" runat="server" Text='<%# Eval("Netamount") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNetamountFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField> 
                      <asp:TemplateField HeaderText="Federal Tax Amount">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Fedtax") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFedtax" runat="server" Text='<%# Eval("Fedtax") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFedtaxFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField> 
                      <asp:TemplateField HeaderText="State Tax Amount">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Statetax") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStatetax" runat="server" Text='<%# Eval("Statetax") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtStatetaxFooter" runat="server" />
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
        </p>
        <p>
           <hr /></p>
        <p>
            <strong>Employment Details</strong></p>
        <p>
            &nbsp;</p>
      <asp:GridView ID="gvEmployment" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3" DataKeyNames="Employment_id" OnRowCancelingEdit="gvEmployment_RowCancelingEdit" OnRowCommand="gvEmployment_RowCommand" 
                OnRowDeleting="gvEmployment_RowDeleting" OnRowEditing="gvEmployment_RowEditing" OnRowUpdating="gvEmployment_RowUpdating" ShowFooter="true" 
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
                    
                    <asp:BoundField DataField="Employment_id" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Employment Date">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Employername") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmployerName" runat="server" Text='<%# Eval("Employername") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmployerNameFooter" runat="server" />
                        </FooterTemplate>
                     </asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Employment Start Date">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Startdate") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtStartDate" runat="server" Text='<%# Eval("Startdate") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtStartDateFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employment End Date">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Enddate") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEndDate" runat="server" Text='<%# Eval("Enddate") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEndDateFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField> 
                      <asp:TemplateField HeaderText="Email Address">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("emailaddress") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("emailaddress") %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmailFooter" runat="server" />
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
    </form>
    
</body>
</html>
