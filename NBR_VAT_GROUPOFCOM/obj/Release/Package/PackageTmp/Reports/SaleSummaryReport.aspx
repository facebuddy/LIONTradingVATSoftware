<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_SaleSummaryReport, App_Web_y1tsx4fu" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%--<%@ Register assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        
       
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
 
<table align="center" class="brd_tbl_input">
 <tr>
            <td colspan="2" height="25" class="page_title">
               Sale Summary Report<uc1:ReportsNav ID="ReportsNav1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style1">
               
                <asp:Label ID="Label1" runat="server" Text="Item :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlItem" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
            <asp:Label runat="server" Text="Party Name"></asp:Label>
            </td>
            <td>
            <asp:DropDownList runat="server" ID="drpPartyName" Width="300px">
               
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="style1"><asp:Label runat="server">Invoice Number</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtInvoiceNumber" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Date From :"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="dtpDateFrom" runat="server" Width="300px" 
                    DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text=" Date To :"></asp:Label>
            </td>
            <td>
                <ww:jQueryDatePicker ID="dtpDateTo" runat="server" Width="300px" 
                    DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" 
                    Text="Show Report" CssClass="button" />
            </td>
        </tr>
        </table>
    <br />

 


<%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ToolbarImagesFolderUrl="" 
        ToolPanelView="None" ToolPanelWidth="200px" Width="350px" 
        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
        onunload="CrystalReportViewer1_Unload" />--%>


        <asp:Literal ID="lt_saleSummary" runat="server"></asp:Literal>



<%--   <asp:GridView ID="gv_salesSummary_report" runat="server" AutoGenerateColumns="false" >
        <Columns>
            
           
            <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" />            
            <asp:BoundField DataField="UNIT_CODE" HeaderText="UNIT CODE" />              
             
             <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
             <asp:BoundField DataField="TOTAL_PRICE" HeaderText="TOTAL PRICE" />
                          
             <asp:BoundField DataField="TOTAL_SD" HeaderText="TOTAL SD" />
             <asp:BoundField DataField="TOTAL_VAT" HeaderText="TOTAL VAT"/>
             <asp:BoundField DataField="TOTAL_PRICE_WITH_SD_VAT" HeaderText="TOTAL PRICE WITH SD VAT" />

            
            
        </Columns>
    </asp:GridView>--%>


</asp:Content>

