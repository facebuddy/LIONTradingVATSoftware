<%@ page language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_treasuryChallan_form, App_Web_o1josinq" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">


    <style>
        table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;}
        table.allSolid td { border: 1.5px solid black;}

    </style>
    <style>
.zoom {
  padding: 50px;
  padding: 50px;
  background-color: green;
  transition: transform .2s; /* Animation */
  width: 200px;
  height: 200px;
  margin: 0 auto;
}

.zoom:hover {
  transform: scale(1.5); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
}
</style>
    <script type="text/javascript">
            function PrintAnnexure() {
                var panel = document.getElementById("<%=printAnnexure.ClientID %>");
                var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=1100,toolbar=0,scrollbars=1,status=0,dir=ltr');
                printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
                printWindow.document.write('<body>');
                printWindow.document.write(panel.innerHTML);
                printWindow.document.write('</body>');
                printWindow.document.write('</html>');
                printWindow.document.close();
                setTimeout(function () {
                    printWindow.print();
                }, 500);
                return false;
            }

            function PrintPanel() {
                var panel = document.getElementById("<%=printTRForm.ClientID %>");
                var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=1100,toolbar=0,scrollbars=1,status=0,dir=ltr');
                printWindow.document.write('<html><head><title></title>');
                printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
                printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
                
                printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;font-size:smaller;} table.allSolid th { border: 1.5px solid black;} table.allSolid td { border: 1.5px solid black;}</style>');
                printWindow.document.write('</head>');
                //printWindow.document.write('<body>');
                printWindow.document.write('<body style="font-size:smaller;">');
                printWindow.document.write(panel.innerHTML);
                printWindow.document.write('</body>');
                printWindow.document.write('</html>');
                printWindow.document.close();
                setTimeout(function () {
                    printWindow.print();
                }, 500);
                return false;
            }

  
    </script>
      <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upContent" runat="server">
        <ContentTemplate>
             <div class="panel panel-primary panel-primary-custom">               
                     <div class="panel-heading text-center" style=" font-family:Tahoma; font-size:18px;"><b>চালান ফরম</b></div>                
                     <div class="panel-body">
               
                    <div class="row">            
                         <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateFrom" style="font-size:11pt" />
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                                </div>
                            </div>
                        </div>
                     
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">To Date :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="dtpDateTo" style="font-size:11pt" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                                </div>
                            </div>
                        </div>
                       <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">TR Challan No :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="drptrChallan" placeholder="Enter Sale Challan No" />
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="row" style="text-align:right">
                    <div class="col-md-12">
                          
                          <asp:LinkButton ID="btnPrint" runat="server" style="float:right" CssClass="btn btn-info btn-sm" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>Print</asp:LinkButton>&nbsp&nbsp
                        <asp:LinkButton ID="btnClear"  runat="server" CssClass="btn btn-success btn-sm " style="float:right" OnClick="btnShow_Click" ><i class="fa fa-archive"></i> Report</asp:LinkButton>
                         <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"  CssClass="hiddencol"></asp:TextBox>
                         </div>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="precisionTxtBox" runat="server"
                                ErrorMessage="Precision has to be a number between 0 to 12"
                                ForeColor="Red"
                                ValidationExpression="\d+">
                            </asp:RegularExpressionValidator> 
               </div>
                 
                      
           
                </div>
             </div>               
             <div class="row" style="font-family:Nikosh">
                                <div class="col-sm-1"></div>
                                  <div class="col-sm-10">
                                   <div runat="server" id="printTRForm">
                          
                                        <div style="font-size:12px">
                                             <center>
                                                <asp:Label ID="Label13" runat="server" Text="চালান ফরম"></asp:Label><br />
                                                <asp:Label ID="Label14" runat="server" Text="টি, আর ফরম নং ৬ (এস, আর ৩৭ দ্রষ্টব্য)"></asp:Label><br />
                                                <asp:Label ID="Label15" runat="server" Text="চালান নং:"></asp:Label><span id="trch" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:Label ID="Label1" runat="server" Text="তারিখ: "></asp:Label><span id="trdate" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span><br />
                                                <asp:Label ID="Label16" runat="server" Text="বাংলাদেশ ব্যাংক/সোনালী ব্যাংকের " ></asp:Label>
                                                <span id="trBranchDistrict" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span> 
                                                 <asp:Label ID="Label3" runat="server" Text=" জেলার:" ></asp:Label>
                                                <span id="trbranch" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span> 
                                                <asp:Label ID="Label2" runat="server" Text="শাখায় টাকা জমা দেওয়ার  চালান" ></asp:Label><br /> 
                                              </center>
                                                <br />

                                             </div>                           
                                        <div>
                                             <div>
                                              <p style="margin-left:0px;font-size:12px;">
                                                কোড নং 
                                                <asp:TextBox runat="server" ID="TextBox0" style="width:22px; height:20px;margin-left:10px"/>

                                                <asp:TextBox runat="server" ID="TextBox1" style="width:22px; height:20px;margin-left:10px"/>
                                                <asp:TextBox runat="server" ID="TextBox2" style="width:22px; height:20px;margin-left:-4px"/>
                                                <asp:TextBox runat="server" ID="TextBox3" style="width:22px; height:20px;margin-left:-4px"/>
                                                <asp:TextBox runat="server" ID="TextBox4" style="width:22px; height:20px;margin-left:-4px"/>

                                                <asp:TextBox runat="server" ID="TextBox5" style="width:22px; height:20px;margin-left:10px"/>
                                                <asp:TextBox runat="server" ID="TextBox6" style="width:22px; height:20px;margin-left:-4px"/>
                                                <asp:TextBox runat="server" ID="TextBox7" style="width:22px; height:20px;margin-left:-4px"/>
                                                <asp:TextBox runat="server" ID="TextBox8" style="width:22px; height:20px;margin-left:-4px"/>

                                                <asp:TextBox runat="server" ID="TextBox9" style="width:22px; height:20px;margin-left:10px"/>
                                                <asp:TextBox runat="server" ID="TextBox10" style="width:22px; height:20px;margin-left:-4px"/>
                                                <asp:TextBox runat="server" ID="TextBox11" style="width:22px; height:20px;margin-left:-4px"/>
                                                <asp:TextBox runat="server" ID="TextBox12" style="width:22px; height:20px;margin-left:-4px"/>
                                              </p>
                                            </div>
                                            <div>
                            
                                              <%--<table border="1" class="allSolid" style="background:none; border-collapse:collapse; width:100%">--%>
                            
                                                <table border="1" class="allSolid" style="background:none; border-collapse:collapse; width:100%;font-size:12px;">
                                                <tr>
                                                    <th colspan="4" style="border:1px solid #000;text-align:center">জমা প্রদানকারী কর্তৃক পূরণ করিতে হইবে</th>
                                                    <th colspan="2" style="border:1px solid #000;text-align:center">টাকার অংক</th>
                                                    <th rowspan="2" style="border:1px solid #000;text-align:center">বিভাগের নাম এবং চালানের পৃষ্ঠাংকনকারী কর্মকর্তার নাম, পদবী ও দপ্তর।*</th>
                                                </tr>
                                                <tr>
                                                   <th style="border:1px solid #000;width:20%;text-align:center">যাহার মারফত প্রদত্ত হইল তাহার নাম ও ঠিকানা।</th>
                                                   <th style="border:1px solid #000;width:20%;text-align:center">যে ব্যক্তির/প্রতিষ্ঠানের পক্ষ হইতে টাকা প্রদত্ত হইল তাহার নাম, পদবী ও ঠিকানা।</th>
                                                   <th style="border:1px solid #000;width:15%;text-align:center">কি বাবদ জমা দেওয়া হইল তাহার বিবরণ</th>
                                                   <th style="border:1px solid #000;width:15%;text-align:center">মুদ্রা ও নোটের বিবরণ/ ড্রাফ্‌ট, পে-অডার ও চেকের বিবরণ</th>
                                                   <th style="border:1px solid #000;width:10%;text-align:center">টাকা</th>
                                                   <th style="border:1px solid #000;width:5%;text-align:center">পয়সা</th>
                                                </tr>
                                                <tr>
                                                  <asp:Label runat="server" ID="lblTRForm" />
                                                </tr>
                                                <tr>
                                                  <td ></td>
                                                  <td ></td>
                                                  <td ></td>
                                                  <td  style="text-align:right; padding-right:4px">মোট টাকা</td>
                                                  <td style="text-align:right;"><asp:Label runat="server" ID="lblTotalTK" /></td>
                                                  <td style="text-align:right;"><asp:Label runat="server" ID="lblTotalPaisa" /></td>
                                                  <td ></td>
                                                </tr>
                                                <tr>
                                                  <td colspan="4" >টাকা (কথায়):<asp:Label runat="server" ID="lblAmountInWord" /></td>
                                                  <td ></td>
                                                  <td ></td>
                                                  <td ></td>
                                                </tr>
                                                <tr>
                                                  <td colspan="4" >টাকা পাওয়া গেল</td>
                                                  <td ></td>
                                                  <td ></td>
                                                  <td ></td>
                                                </tr>
                                                <tr>
                                                  <td colspan="4" >তারিখ: &nbsp <asp:Label runat="server" ID="lblDate2" /></td>
                                                  <td colspan="3" ><center>ম্যানেজার<br />বাংলাদেশ ব্যাংক/সোনালী ব্যাংক </center></td>
                                                </tr>
                                              </table>
                          
                        
                                              <p style="margin-left:0px;margin-top:5px;">নোট :   ১ । সংশ্লিষ্ট দপ্তরের সহিত যোগাযোগ করিয়া সঠিক কোড নম্বর জানিয়া লইবেন ।</p>
                                              <p style="margin-left:22px;">২ ।* যে সকল ক্ষেত্রে কর্মকর্তা কর্তৃক পৃষ্টাংকন প্রয়োজন,সে সকল  ক্ষেত্রে প্রযোজ্য হইবে ।</p>
                                              <p style="margin-left:0px">বাঃসঃমুঃ -২০০৮/০৯-৪৮৬৬ কম (ডি)-১০০ বই , ২০০৯ ।</p>
                                            </div>
                    
                      
                                            <br />
                          
                      
                    
                                      </div>
                                        <div style="text-align:right;font-size:11px;">
                                              System Generated (KGCVAT)
                                          </div>
                                    </div>
                          
                                  </div>
                                <div class="col-sm-1"></div>
                                <uc2:MsgBox ID="msgBox" runat="server" />
                   
                               </div>       
             <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-10">
                            <div runat="server" id="printAnnexure">                
                                 <div class="form-group form-group-sm">
                                            <div class="table-responsive">
                         
                                               <table border="1" class="" style="width: 100%; border-collapse: collapse">
                                                    <thead>
                                                        <tr>
                                                           <th style="text-align:center;">Party Name</th>                                                
                                                           <th style="text-align:center;">Challan No</th>
                                                           <th style="text-align:center;">Scroll No</th>
                                                           <th style="text-align:center;">Deposite Account code</th>
                                                           <th style="text-align:center;">VAT/SD</th>
                                              
                                                        </tr>
                                                    </thead>
                                                    <tbody>                                          
                                                        <tr>
                                                            <asp:Label runat="server" ID="lblReportHtml" />
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                            </div>
                            <center> <asp:Button runat="server" style="float:right;" CssClass="btn btn-info" Text="Print Annexure" ID="btnPrintAnnexere" Visible= "false" OnClientClick="return PrintAnnexure()" /></center>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>   
             <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-10">
                
                                                <div class="full_body_readyform" runat="server" id="divImage" visible="false">
                                        
                                                    <asp:Panel ID="pnInput" CssClass="input-table tablefull center paddinglrb" Height="250px" runat="server">
                                                        <asp:Image ID="Image1" runat="server" Height="100" Width="100" />
                                                        <br />
                                                          <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong">Preview</button>

                                                    </asp:Panel>

                                                </div>   
                                                <!-- Modal -->
                                                <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" style="height:100%;width:100%">
                                                  <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                      <div class="modal-header">
                                                      <%--  <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>--%>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                          <span aria-hidden="true">&times;</span>
                                                        </button>
                                                      </div>
                                                      <div class="modal-body">
                                                        <asp:Image ID="ImageP" runat="server" Height="700" Width="500" />
                                                      </div>
                                                      <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                      <%--  <button type="button" class="btn btn-primary">Save changes</button>--%>
                                                      </div>
                                                    </div>
                                                  </div>
                                                </div>
                        </div>
                      </div>
            <br />
      
          </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>
