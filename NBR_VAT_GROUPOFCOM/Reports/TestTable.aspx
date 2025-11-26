<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_TestTable, App_Web_o1josinq" %>
<%@ Register src="../UserControls/ReportsNav.ascx" tagname="ReportsNav" tagprefix="uc1" %>
<%--<%@ Register assembly="CrystalDecisions.Web,  Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

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
</asp:Content>

