<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_SaleChallan17, App_Web_y1tsx4fu" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%--<%@ Register Assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
<table align="center" class="brd_tbl_input">
 <tr>
            <td colspan="4" height="25" class="page_title"> Sale Account 17  <uc1:ReportsNav ID="ReportsNav1" runat="server" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Item :"></asp:Label>
            </td>
            <td>
               
                <asp:DropDownList ID="ddlItem" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Date From :"></asp:Label>
            </td>
            <td>
                    <ww:jQueryDatePicker ID="dtpFrom" runat="server" 
                        DateFormat="dd/MM/yyyy" Width="280px"></ww:jQueryDatePicker>
            </td>
            
           
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Date To :"></asp:Label>
            </td>
            <td>
                    <ww:jQueryDatePicker ID="dtpTo" runat="server" 
                        DateFormat="dd/MM/yyyy" Width="280px"></ww:jQueryDatePicker>
            </td>
         
        </tr>
             <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" 
                    Text="Show Report" CssClass="button" />
            </td>
          
        </tr>
        </table>
<%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ToolbarImagesFolderUrl="" 
        ToolPanelView="None" ToolPanelWidth="200px" Width="350px" 
        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
        onunload="CrystalReportViewer1_Unload" />--%>
</asp:Content>

