<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_BandrollManagement, App_Web_o1josinq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    <script type="text/javascript">
        <%--function PrintPanel() {
            var panel = document.getElementById("<%=reportMain.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head><body style="margin: 50px;">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }--%>
    </script>
    <style>
        .m
        {
            text-align:right;
            padding-right:5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
  <%--  <div style="float:right">
         <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
    </div>--%>
       <div class="panel panel-group">
                <div class="panel panel-primary panel-primary-custom">
                  <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 25px; padding-top: 0px"></div>
                          <div class="panel-body">
    <div class="row">
        <div class="col-md-4">
            <div class="form-group form-group-sm">
                <label class="col-sm-5 control-label text-right" ><span class="required" style="color:red">* </span>Category :</label>
                <div class="col-sm-7">
                    <asp:DropDownList ID="drpRegType" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpRegType_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">বিড়ি</asp:ListItem>
                        <asp:ListItem Value="2">সিগারেট</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
          </div>           </div>
                    </div>
     <div class="row">
     <div class="col-md-4"></div>
                    <div class="col-md-6">

                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>প্রতিষ্ঠানের নাম :
                                                  <asp:Label ID="provider_name" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label> ঠিকানা  :
                                                  <asp:Label ID="provider_address" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                 <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>মূসক নিবন্ধন নং  :
                                               <asp:Label ID="receiver_name" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                       
                                     <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>মজুদ গ্রহনের তারিখ ও সময়   :
                                                 <asp:Label ID="receiver_BIN" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                           
                                    
                                    </div>         
                                              
                                    <div class="col-md-2"><label>ছক-ক</label>
                                </div>
          <div class="col-md-12" runat="server" id="biri">
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <p  style="text-align:center;font-weight:bold">(ক) উৎপাদিত বিড়ির মজুদ সংক্রান্ত তথ্যঃ</p>
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>বিড়ির ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ (হার্ড/সফট/শেল এন্ড স্লাইড/হেঞ্জ)</th>
                                                <th>প্রতি প্যাকেটে শলাকার সংখ্যা</th>
                                                <th>ব্যন্ডরোলের ডিজাইন <br /> রং</th>
                                                <th>প্রতি প্যাকেটের মুদ্রিত খুচরা মূল্য</th>                                               
                                                <th>মজুদ পণ্যের প্যাকেটের সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody> 
                                              <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                            <td style="text-align: center">(৮)
                                            </td>
                                                  </tr>
                                                                                     
                                            <tr>

                                                <asp:Label runat="server" ID="lblReportHtml" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <p  style="text-align:center;font-weight:bold">(খ) অব্যবহিত মুদ্রিত বিড়ির প্যাকেটের মজুদ সংক্রান্ত তথ্য</p>
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>বিড়ির ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ (হার্ড/সফট/শেল এন্ড স্লাইড/হেঞ্জ)</th>
                                                <th>প্রতি প্যাকেটে শলাকার সংখ্যা</th>                                                
                                                <th>প্রতি প্যাকেটের মুদ্রিত খুচরা মূল্য</th>                                               
                                                <th>মজুদ পণ্যের প্যাকেটের সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody>  
                                             <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                           
                                                  </tr>                                        
                                            <tr>
                                                <asp:Label runat="server" ID="Label1" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <p  style="text-align:center;font-weight:bold">(গ) অব্যবহিত ব্যন্ডরোলের মজুদ সংক্রান্ত তথ্যঃ</p>
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>বিড়ির ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ</th>
                                                <th>ব্যন্ডরোল</th>                                                
                                                <th>ব্যন্ডরোলদের ডিজাইন (রং)</th>                                               
                                                <th> অব্যবহিত ব্যন্ডরোলের সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody> 
                                             <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                           
                                                  </tr>                                              
                                            <tr>
                                                <asp:Label runat="server" ID="Label2" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                 <p  style="text-align:center;font-weight:bold">(ঘ) নতুন ব্যন্ডরোলের মজুদ সংক্রান্ত তথ্যঃ(চাহিদা পত্রের ভিত্তিতে)</p>
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>বিড়ির ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ (হার্ড/সফট/শেল এন্ড স্লাইড/হেঞ্জ)</th>
                                                <th>ব্যন্ডরোল</th>                                                
                                                <th>ব্যন্ডরোলদের ডিজাইন (রং)</th>                                               
                                                <th> মজুদ সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody> 
                                             <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                           
                                                  </tr>                                              
                                            <tr>
                                                <asp:Label runat="server" ID="Label3" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                 <p  style="text-align:center;font-weight:bold"> (ঙ)নতুন খুচরা মূল্যের ভিত্তিতে মুদ্রিত বিড়ির প্যাকেটের মজুদ সংক্রান্ত তথ্যঃ</p>

                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>বিড়ির ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ (হার্ড/সফট/শেল এন্ড স্লাইড/হেঞ্জ)</th>
                                                <th>প্রতি প্যাকেটে শলাকার সংখ্যা</th>                                                
                                                <th>প্রতি প্যাকেটের মুদ্রিত খুচরা মূল্য</th>                                               
                                                <th>মজুদ পণ্যের প্যাকেটের সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody>  
                                             <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                           
                                                  </tr>                                             
                                            <tr>
                                                <asp:Label runat="server" ID="Label4" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
         </div>

        <div class="col-md-12" runat="server" id="ciggerette">
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <p  style="text-align:center;font-weight:bold">(ক) উৎপাদিত সিগারেট মজুদ সংক্রান্ত তথ্যঃ</p>
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>সিগারেট (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ (হার্ড/সফট/শেল এন্ড স্লাইড/হেঞ্জ)</th>
                                                <th>প্রতি প্যাকেটে শলাকার সংখ্যা</th>
                                                <th>ব্যন্ডরোলের ডিজাইন <br /> রং</th>
                                                <th>প্রতি প্যাকেটের মুদ্রিত খুচরা মূল্য</th>                                               
                                                <th>মজুদ পণ্যের প্যাকেটের সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody> 
                                              <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                            <td style="text-align: center">(৮)
                                            </td>
                                                  </tr>
                                                                                     
                                            <tr>

                                                <asp:Label runat="server" ID="Label5" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <p  style="text-align:center;font-weight:bold">(খ) অব্যবহিত মুদ্রিত সিগারেট প্যাকেটের মজুদ সংক্রান্ত তথ্য</p>
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>সিগারেট ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ (হার্ড/সফট/শেল এন্ড স্লাইড/হেঞ্জ)</th>
                                                <th>প্রতি প্যাকেটে শলাকার সংখ্যা</th>                                                
                                                <th>প্রতি প্যাকেটের মুদ্রিত খুচরা মূল্য</th>                                               
                                                <th>মজুদ পণ্যের প্যাকেটের সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody>  
                                             <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                           
                                                  </tr>                                        
                                            <tr>
                                                <asp:Label runat="server" ID="Label6" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <p  style="text-align:center;font-weight:bold">(গ) অব্যবহিত ব্যন্ডরোলের মজুদ সংক্রান্ত তথ্যঃ</p>
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>সিগারেট ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ</th>
                                                <th>ব্যন্ডরোল</th>                                                
                                                <th>ব্যন্ডরোলদের ডিজাইন (রং)</th>                                               
                                                <th> অব্যবহিত ব্যন্ডরোলের সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody> 
                                             <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                           
                                                  </tr>                                              
                                            <tr>
                                                <asp:Label runat="server" ID="Label7" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                 <p  style="text-align:center;font-weight:bold">(ঘ) নতুন ব্যন্ডরোলের মজুদ সংক্রান্ত তথ্যঃ(চাহিদা পত্রের ভিত্তিতে)</p>
                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>সিগারেট ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ (হার্ড/সফট/শেল এন্ড স্লাইড/হেঞ্জ)</th>
                                                <th>ব্যন্ডরোল</th>                                                
                                                <th>ব্যন্ডরোলদের ডিজাইন (রং)</th>                                               
                                                <th> মজুদ সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody> 
                                             <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                           
                                                  </tr>                                              
                                            <tr>
                                                <asp:Label runat="server" ID="Label8" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
               <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                 <p  style="text-align:center;font-weight:bold"> (ঙ)নতুন খুচরা মূল্যের ভিত্তিতে মুদ্রিত সিগারেট প্যাকেটের মজুদ সংক্রান্ত তথ্যঃ</p>

                                   <table border="1" class="table" style="width: 100%; border-collapse: collapse">
                                        <thead>
                                            <tr>
                                               <th>ক্রমিক নং</th>                                                
                                                <th>সিগারেট ধরন (ফিল্টার যুক্ত/বিযুক্ত)</th>
                                                <th>প্যাকেটের ধরণ (হার্ড/সফট/শেল এন্ড স্লাইড/হেঞ্জ)</th>
                                                <th>প্রতি প্যাকেটে শলাকার সংখ্যা</th>                                                
                                                <th>প্রতি প্যাকেটের মুদ্রিত খুচরা মূল্য</th>                                               
                                                <th>মজুদ পণ্যের প্যাকেটের সংখ্যা</th>
                                                <th>মন্তব্য</th>
                                            </tr>
                                        </thead>
                                        <tbody>  
                                             <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                           
                                                  </tr>                                             
                                            <tr>
                                                <asp:Label runat="server" ID="Label9" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
         </div>
</div>

</asp:Content>