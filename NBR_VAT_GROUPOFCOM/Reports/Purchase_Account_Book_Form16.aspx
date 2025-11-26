<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_Purchase_Account_Book_Form16, App_Web_xijeoyc2" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%--<%@ Register assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
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
            <td colspan="4" height="25" class="page_title"> Purchase Account 16  <uc1:ReportsNav ID="ReportsNav2" runat="server" /></td>
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

    <table class="table_report">
        <thead>
            <tr>
                <td colspan="19"><center><h4>পণ্য/ সেবার উপকরণ ক্রয়</h4></center></td>
            </tr>
            <tr>
                <th rowspan="4" class="col_3_percent">ক্রমিক সংখ্যা</th>
                <th rowspan="4" class="col_3_percent">তারিখ</th>
                <th colspan="2">মজুদ উপকরণের প্রারম্ভিক</th>
                
                <th colspan="10">ক্রয়কৃত উপকরণ</th>
            
                <th colspan="2"></th>
                <th colspan="2">উপকরণের প্রান্তিক জের</th>
                
               
                <th rowspan="4">মন্তব্য</th>
            </tr>
            <tr>
                
               
                <th rowspan="3" class="col_3_percent">পরিমাণ</th>
                <th rowspan="3" class="col_3_percent">মূল্য</th>
                <th rowspan="3" class="col_5_percent">চালানপত্র / বিল অব এন্ট্রি নং</th>
                <th rowspan="3" class="col_3_percent">তারিখ</th>
                <th colspan="3" rowspan="2" class="col_15_percent">বিক্রেতা/সরবরাহকারী</th>
                
                <th rowspan="3" class="col_3_percent">বিবরণ</th>
                <th rowspan="3" class="col_3_percent">পরিমাণ</th>
                <th rowspan="3" class="col_3_percent">মূল্য (সম্পূরক শুল্ক ও মূসক বাদে)</th>
                <th rowspan="3" class="col_3_percent">সম্পূরক শুল্ক (যদি থাকে)</th>
                <th rowspan="3"class="col_3_percent">মূসক</th>
                <th rowspan="2" colspan="2" class="col_10_percent">পণ্য প্রস্তুতকরণ / উৎপাদনে ব্যবহার (ব্যবসায়ীদের ক্ষেত্রে পণ্য বিক্রয়)</th>
                
                <th rowspan="3" class="col_2_percent">পরিমাণ</th>
                <th rowspan="3" class="col_3_percent">মূল্য</th>
                
            </tr>
            <tr>
             
            </tr>
             <tr>  
                
                <th>নাম</th>
                <th>ঠিকানা</th>
                <th>নিবন্ধন নং</th>
              
                <th class="col_2_percent">পরিমাণ</th>
                <th class="col_3_percent">মূল্য</th>
                
              
            </tr>
            <tr>
                <th>1</th>
                <th>2</th>
                <th>3</th>
                <th>4</th>
                <th>5</th>
                <th>6</th>
                <th>7</th>
                <th>8</th>
                <th>9</th>
                <th>10</th>
                <th>11</th>
                <th>12</th>
                <th>13</th>
                <th>14</th>
                <th>15</th>
                <th>16</th>
                <th>17</th>
                <th>18</th>
                <th>19</th>

            </tr>

        </thead>
        <tbody>
            <tr>
                <td>01</td>
                <td>31.10.2016</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>01</td>               
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
                <td>NO</td>
            </tr>
        </tbody>
        </table>
<%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ToolbarImagesFolderUrl="" 
        ToolPanelView="None" ToolPanelWidth="200px" Width="350px" 
        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
        onunload="CrystalReportViewer1_Unload" />--%>
</asp:Content>

