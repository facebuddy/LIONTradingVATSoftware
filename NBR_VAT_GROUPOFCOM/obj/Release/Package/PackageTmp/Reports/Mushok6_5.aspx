<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Mushok6_5, App_Web_o1josinq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <style>
        .m
        {
            text-align:right;
            padding-right:5px;
        }
    </style>
</asp:Content >
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="reportMain" class="container-fluid" style="padding: 2%" runat="server" visible="true">
        <div class="row">
            <p style="text-align:center">কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তর চালানপত্র</p>
            <p style="text-align:center; margin-top: -1%;">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (ঙ) দ্রষ্টব্য]</p>            
        </div>
        <div class="row">
                <label>নিবন্ধিত ব্যক্তির নাম:</label>
                 <br/>
                  <label>নিবন্ধিত ব্যক্তির বিআইএন:</label>                   
                <br/>
                <label>প্রেরণকারী ইউনিট/শাখা/পণ্যাগারের নাম ও ঠিকানা: </label>
                <br/>   
               <label>গ্রহীতা ইউনিট/শাখা/পণ্যাগারের নাম ও ঠিকানা:</label>
        </div>
          <div class="row" style="text-align:right;">
                <label> চালান নম্বর:</label>
                 <br/>
                  <label>ইস্যুর তারিখ:</label>                   
                <br/>
                <label>ইস্যুর সময়: </label>
                <br/>   
               
        </div>
        <div class="row">
            <table class="table table-bordered" style="overflow-x:scroll;overflow-y:hidden">
               <thead>
                <tr>
                    <th rowspan="3" style="text-align:center;">
                        ক্রমিক সংখ্যা
                    </th>
                    <th rowspan="3" style="text-align:center;">
                        পণ্যের (প্রযোজ্য ক্ষেত্রে সুনির্দিষ্ট ব্র্যান্ড নামসহ) বিবরণ
                    </th>
                     <th rowspan="3" style="text-align:center;">
                     পরিমান
                    </th>
                     <th rowspan="3" style="text-align:center;">
                       কর ব্যতীত মূল্য
                    </th>
                     <th rowspan="3" style="text-align:center;">
                      প্রযোজ্য করের পরিমাণ
                    </th>
                     <th rowspan="3" style="text-align:center;">
                     মন্তব্য
                    </th>
                  </tr>
                   </thead>
                <tbody>                                 
                     <tr>
                     <td style="text-align:center;">(১)</td>
                     <td style="text-align:center;">(২)</td>
                     <td style="text-align:center;">(৩)</td>
                     <td style="text-align:center;">(৪)</td>
                     <td style="text-align:center;">(৫)</td>
                     <td style="text-align:center;">(৬)</td>                                                
                      </tr>
                     <tr>
                 <asp:Label runat="server" ID="lblproduct" />
                    </tr>
                   </tbody>
                
            </table>
        </div>
         <br/>
         <div class="row">
                <label>প্রতিষ্ঠান কর্তৃপক্ষের দায়িত্বপ্রাপ্ত ব্যক্তির নাম ও ঠিকানা:</label>
                 <br/>
                  <label>পদবি:</label>                   
                <br/>
                <label>স্বাক্ষর: </label>
                <br/>   
               <label>সীল:</label>
        </div>
    </div>
</asp:Content>