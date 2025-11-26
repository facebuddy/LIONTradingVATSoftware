<%@ page language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_VAT_Return_Form19_N, App_Web_y1tsx4fu" %>

<%@ Register Src="../UserControls/ReportsNav.ascx" TagName="ReportsNav" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
    <style type="text/css">
        .style1 {
            height: 10px;
            width: 24%;
        }

        .style3 {
            width: 8%;
        }
    </style>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=rpVatReturn.ClientID %>");
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
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upContent" runat="server">
        <ContentTemplate>
             <div class="panel panel-primary panel-primary-custom">
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="form-group form-group-sm">
                        <div class="col-md-4">
                            <label class="col-sm-4 comntrol-label">Date From :</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateFrom" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <label class="col-sm-3 comntrol-label">Date To :</label>
                            <div class="col-sm-9">
                                <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateTo" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="btnShow_OnClick" ><i class="fa fa-search-plus"></i>  Report</asp:LinkButton>
                            <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary" onclientclick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                            <asp:LinkButton ID="btnXMLFormat" runat="server" CssClass="btn btn-info" OnClick="btnXMLFormat_OnClick"><i class="fa fa-search-plus"></i>  XML Data</asp:LinkButton>
                        </div>
                    </div>

                    </div>
                     
                </div>
              </div>

     
   
   <%-- <div>
        <table class="table table-bordered" style="width: 100%">
            <tr>
                <th colspan="3" scope="colgroup" style="text-align: center; background-color: #cccccc">
                    &nbsp;
                </th>
            </tr>
            <tr style="background-color: White">
                <td class="td-width-30">
                    প্রতিষ্ঠান
                </td>
                <td class="td-width-2">
                </td>
                <td>
                    <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                        <asp:DropDownList ID="drpOrganization" runat="server" Width="100%" Height="25px">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 29%; float: right; font-weight: bold">
                    </div>
                </td>
            </tr>
            <tr style="background-color: White">
                <td class="td-width-30">
                    Date From :
                </td>
                <td class="td-width-2">
                </td>
                <td>
                    <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                        <ww:jQueryDatePicker ID="dtpDateFrom" runat="server" Width="300px" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                    </div>
                    <div style="width: 29%; float: right; font-weight: bold">
                    </div>
                </td>
            </tr>
            <tr style="background-color: White">
                <td class="td-width-30">
                    Date To :
                </td>
                <td class="td-width-2">
                </td>
                <td>
                    <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                        <ww:jQueryDatePicker ID="dtpDateTo" runat="server" Width="300px" DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                    </div>
                    <div style="width: 29%; border: 1px; float: right; font-weight: bold">
                    </div>
                </td>
            </tr>
            <tr style="background-color: White">
                <td class="td-width-30">
                </td>
                <td class="td-width-2">
                </td>
                <td>
                    <div style="width: 70%; float: left;">
                    </div>
                    <div style="width: 29%; border: 1px; border-style: solid; float: right; font-weight: bold">
                        <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="btnShow_OnClick" ><i class="fa fa-search-plus"></i>  Report</asp:LinkButton>
                        <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary" onclientclick="return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>--%>
    <br />
    <br />
    <div runat="server" id="rpVatReturn" style="padding-left:10%;padding-right:10%;padding-bottom:10%">
    <div class="row">
        <p style="text-align: center">
            গণপ্রজাতন্ত্রী বাংলাদেশ সরকার
        </p>
        <p style="text-align: center; margin-top:-0.5%">
            জাতীয় রাজস্ব বোর্ড
        </p>
        <p style="text-align: center;margin-top:-0.5%">
            ঢাকা
        </p>
        <br />
        <p style="text-align: center;margin-top:-2%;font-size:16px">
            <strong>মূল্য সংযোজন কর দাখিলপত্র </strong>
        </p>
        <p style="text-align: center;margin-top:-0.5%">
            [বিধি ২৪ (১) দ্রষ্টব্য ]</p>
        <p style="border: 1px solid #000; float: right; margin-right: 15px;padding:5px">
            মূসক-১৯</p>
    </div>
    <br />
    <br />
    <div style="margin-top:-4%">
        <table style="width: 100%">
            <tr>
                <td colspan="2" style="text-align:right;padding-right:20px">মাস</td>
                <td style="text-align:left;padding-left:15px;border-bottom:1px solid #000">বছর</td>
                <td></td><td></td>
            </tr>
            <tr>
                <td style="width:10%;text-align:right;padding-right:5px">কর মেয়াদ</td>
                <td style="width:6%;border:1px solid #000;padding:5px"><asp:Label ID="month" runat="server" ReadOnly="True"></asp:Label></td>
                <td style="width:6%;border:1px solid #000;border-top:0px;padding:5px"><asp:Label ID="year" runat="server" ReadOnly="True"></asp:Label></td>
                <td style="width:35%;text-align:right;padding-right:5px">করদাতা সনাক্তকরণ সংখ্যা</td>
                <td style="width:35%"> <asp:Label runat="server" ID="orgBIN" /></td>
            </tr>
        </table>

        <table style="width: 100%;margin-top:2%">
            <tr>
                <td style="text-align:left;width:15%;padding:5px;border-left:1px solid #000;border-top:1px solid #000">নাম </td>
                <td style="text-align:center;width:5%;border-top:1px solid #000">:</td>
                <td style="width:80%;text-align:left; padding-left:10px;border-top:1px solid #000;border-right:1px solid #000"> <asp:Label ID="orgName" runat="server"></asp:Label></td>
            </tr>
             <tr>
                <td style="text-align:left;width:15%;padding:5px;border-left:1px solid #000"> ঠিকানা </td>
                <td style="text-align:center;width:5%">:</td>
                <td style="width:80%;text-align:left; padding-left:10px;border-right:1px solid #000"><asp:Label ID="orgAddress" runat="server"></asp:Label></td>
            </tr>
             <tr>
                <td style="text-align:left;width:15%;padding:5px;border-left:1px solid #000;border-bottom:1px solid #000">টেলিফোন নম্বর</td>
                <td style="text-align:center;width:5%;border-bottom:1px solid #000">:</td>
                <td style="width:80%;text-align:left; padding-left:10px;border-bottom:1px solid #000;border-right:1px solid #000"><asp:Label ID="txtPhone" runat="server" ></asp:Label> </td>
            </tr>
        </table>
        <table style="width: 100%;margin-top:1.5%">
            <tr>
                <td style="width:50%;border:1px solid #000;padding:5px">শূন্য দাখিল পত্র (কর মেয়াদে কোন ক্রয় বিক্রয় হয় নাই) </td>
                <td style="width:5%;"></td>
                <td style="width:10%;border:1px solid #000"></td>
                <td style="width:35%;"></td>
            </tr>
        </table>
        
        
        
       <%--  <table style="width: 100%; border-style :none; border-width:0px" >
           <tr>
                <td style = "width:10%">
                </td>
                <td class="style1">
                    <div style="width: 49%; text-align: center; float: left">
                        মাস
                    </div>
                    <div style="width: 49%; text-align: center; float: right">
                        বছর
                    </div>
                </td>
                <td class="style1">
                    
                </td>
                <td class="style1">
                   
                </td>
                <td class="style1">
                    
                </td>
            </tr>
            <tr>
                <td style = "width:10%">
                    কর মেয়াদ
                </td>
                <td class="style1">
                    <div style="width: 45%; height: 100%; text-align: center; float: left">
                        <asp:TextBox ID="month" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div style="width: 45%; height: 100%; text-align: center; float: left">
                        <asp:TextBox ID="year" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </td>
                <td class="style1" style  ="text-align:right">
                    করদাতা সনাক্তকরণ সংখ্যা &nbsp
                </td>
                <td class="style1">
                   <asp:Label runat="server" ID="orgBIN" />
                </td>
                <td class="style1">
                </td>
            </tr>


            <tr>
                <td style = "width:10%">
                    নাম 
                </td>
                <td class="style1">
                   
                    <asp:TextBox ID="orgName" Width = "92%" runat="server"></asp:TextBox>
                   
                </td>
                <td class="style1">
                  
                </td>
                <td class="style1">
                    
                </td>
                <td class="style1">
                </td>
            </tr>


        </table>--%>
  </div>
  <div>
        <%-- <table style="width: 100%; border-style :none; border-width:0px">
            
           <tr>
                <td class="style3">
                    ঠিকানা 
                </td>
                <td width = "40%">
                   
                    <asp:TextBox ID="orgAddress" Width = "100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                   
                  </td>

                  <td width = "10%" style  ="text-align:center"> ফোন  </td>
                  <td width = "20%">
                  <asp:TextBox ID="txtPhone" Width = "100%" runat="server" ></asp:TextBox> </td>
                
               
            </tr>


            <tr>
                <td colspan = "4">
                    শূন্য দাখিল পত্র (কর মেয়াদে কোন ক্রয় বিক্রয় হয় নাই) 
                    
                        <asp:TextBox Width = "80px" ID="TextBox13" runat="server" ReadOnly="True"></asp:TextBox>
                    
                </td>
                
               
            </tr>


        </table>--%>
    </div>



    <table border="1" class="table" style="width: 100%;margin-top:1.5%;border-collapse:collapse">
        <thead>
            <tr>
               <th  colspan="2" style="text-align: center; font-weight: normal; width:55%; background-color: #cccccc"">
                   বিক্রয় সংক্রান্ত তথ্য 
                </th>


               <th colspan="1" style="text-align: center; font-weight: normal;width:15%; background-color: #cccccc"">
                    বিক্রয় মূল্য
                </th>

                <th colspan="1" style="text-align: center; font-weight: normal;width:15%; background-color: #cccccc"">
                    সম্পূরক শুল্ক
                </th>

                <th colspan="1" style="text-align: center; font-weight: normal;width:15%; background-color: #cccccc"">
                    মূল্য সংযোজন কর 
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td style = "text-align :center; width :5%" >
                    ১
                </td>
                <td style = "text-align : left; width :50%">
                  করযোগ্য পণ্য, সেবা বা পণ্য ও সেবার নীট বিক্রয়
                </td>

                <td style = "text-align :center">
                   
                    <asp:Label ID="localSalePrice" runat="server" ></asp:Label>
                   
                </td>
                <td style = "text-align :center">
                   
                    <asp:Label ID="localSaleSD" runat="server" ></asp:Label>
                   
                </td>
                <td style = "text-align :center">
                   
                    <asp:Label ID="localSaleVat" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
                <td style = "text-align :center; width :5%" >
                    ২
                </td>
                <td style = "text-align :left; width :50%" >
                শূন্য হারের পণ্য বা সেবার বিক্রয় (রপ্তানী) 
                </td>

                <td style = "text-align :center">
                   
                    <asp:Label ID="exportPrice" runat="server" Style="font-weight:bold" ></asp:Label>
                   
                </td>
                <td style = "text-align :center"><asp:Label ID="Label101" runat="server" Text="---" ></asp:Label></td>
                <td style = "text-align :center"><asp:Label ID="Label102" runat="server" Text="---" ></asp:Label></td>

                
                
            </tr>

            <tr>
                <td style = "text-align :center; width :5%" >
                    ৩
                </td>
                <td style = "text-align :left; width :50%" >
               অব্যাহতিপ্রাপ্ত পণ্য, সেবা বা পণ্য ও সেবার নীট বিক্রয় 
                </td>

                <td style = "text-align :center">
                   
                    <asp:Label ID="saleExamptedPrice" runat="server" ></asp:Label>
                   
                </td>
                <td style = "text-align :center"><asp:Label ID="Label103" runat="server" Text="---" ></asp:Label></td>
                <td style = "text-align :center"><asp:Label ID="Label104" runat="server" Text="---" ></asp:Label></td>

                
                
            </tr>


          

            

            
        </tbody>
    </table>

    <table class="table" style="width: 100%; border-collapse:collapse">
        <thead>
            <tr>
                <th  colspan="2" style="text-align: center; font-weight: normal; width:55%; background-color: #cccccc; border:1px solid #000">
                   প্রদেয় হিসাব  
                </th>


                <th style="text-align: center; font-weight: normal; width:15%; background-color: #cccccc;border:1px solid #000">
                   পরিমান  
                </th>

                <th style="text-align: center; font-weight: normal; border-style :none; border-width:0px" rowspan="4">
                    
                </th>

            </tr>
        </thead>
        <tbody>
            <tr>
                <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ৪
                </td>
                <td style = "text-align :left; width :50%;border:1px solid #000" >
                মোট প্রদেয় কর (সারি ১ হইতে SD + VAT)
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="totalSaleTax" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
              <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ৫
                </td>
                <td style = "text-align :left; width :50%;border:1px solid #000" >
                অন্যান্য সমন্বয়করণ (প্রদেয় / উৎসে কর্তন / বকেয়া / অর্থদণ্ড / জরিমানা / স্থান ও স্থাপনা ভাড়া গ্রহণকারী  )
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="otherSaleTax" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
               <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ৬
                </td>
                <td style = "text-align :left; width :50%;border:1px solid #000" >
               সর্বমোট প্রদেয় (সারি ৪+৫)
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="saleTotal" runat="server" ></asp:Label>
                   
                </td>
            </tr>
        </tbody>
    </table>



    <table class="table" style="width: 100%">
        <thead>
            <tr>
                <th  colspan="2" style="text-align: center; font-weight: normal; width:55%; background-color: #cccccc;border:1px solid #000">
                  ক্রয় সংক্রান্ত তথ্য
                </th>


               <th  colspan="1" style="text-align: center; font-weight: normal; width:15%; background-color: #cccccc;border:1px solid #000">
                ক্রয় মূল্য
                </th>

               <th colspan="1" style="text-align: center; font-weight: normal;width:15%; background-color: #cccccc;border:1px solid #000">
                    রেয়াতযোগ্য কর 
                </th>

                <th style="text-align: center; font-weight: normal;border-style :none; border-width:0px" rowspan="5">
                    
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
               <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ৭
                </td>
                <td style = "text-align :left; width :50%;border:1px solid #000" >
                স্থানীয় পর্যায়ে  করযোগ্য  পণ্য,  সেবা  বা  পণ্য  ও  সেবার ক্রয়
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="localPurchasePrice" runat="server" ></asp:Label>
                   
                </td>
                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="localPurchaseRebat" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
              <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ৮
                </td>
                <td style = "text-align :left; width :50%;border:1px solid #000" >
                করযোগ্য পণ্য, সেবা বা পণ্য ও সেবার আমদানি  
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="importPrice" runat="server" ></asp:Label>
                   
                </td>
                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="importRebat" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
                <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ৯
                </td>
                <td style = "text-align :left; width :50%;border:1px solid #000" >
               রপ্তানী ক্ষেত্রে অন্যান্য কর রেয়াত
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="Label11" runat="server" Text="---" ></asp:Label>
                   
                </td>
                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="exportRebat" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
                <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১০
                </td>
                <td style = "text-align :left; width :50%;border:1px solid #000" >
               অব্যাহতিপ্রাপ্ত পণ্য, সেবা বা পণ্য ও সেবার নীট ক্রয় 
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="purchaseExempted" runat="server" ></asp:Label>
                   
                </td>
                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="Label16" runat="server" ></asp:Label>
                   
                </td>
            </tr>
        </tbody>
    </table>
    


    <table class="table" style="width: 100%">
        <thead>
            <tr>
              <th  colspan="2" style="text-align: center; font-weight: normal; width:55%; background-color: #cccccc;border:1px solid #000">
                 উৎসে কর্তন / রেয়াত / প্রত্যর্পণ হিসাব 
                </th>


             <th  colspan="1" style="text-align: center; font-weight: normal; width:15%; background-color: #cccccc;border:1px solid #000">
               পরিমান  
                </th>

                <th style="text-align: center; font-weight: normal;border-style :none; border-width:0px" rowspan="5">
                  
                </th>

            </tr>
        </thead>
        <tbody>
            <tr>
                <td style = "text-align :center; width :5%;border:1px solid #000" >

                    ১১
                </td>
                <td style = "text-align : left; width :50%;border:1px solid #000">
                মোট রেয়াতযোগ্য কর (সারি ৭+৮+৯) 
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="totalRebat" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
                <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১২</td>
                <td style = "text-align : left; width :50%;border:1px solid #000">
                অন্যান্য সমন্বয়করণ (রেয়াত/পাওনা/আমদানি পর্যায়ে অগ্রিম মূসক/উৎসে প্রদত্ত মূসক)
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="other12" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
                <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১৩
                </td>
               <td style = "text-align : left; width :50%;border:1px solid #000">
               পূর্ববর্তী মাসের জের  
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="prevMonthValue" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
              <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১৪
                </td>
                <td style = "text-align : left; width :50%;border:1px solid #000">
               সর্বমোট রেয়াত (সারি ১১+১২+১৩)
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="grandTotalRebat" runat="server" ></asp:Label>
                   
                </td>
            </tr>
        </tbody>
    </table>


    <table class="table" style="width: 100%">
        <thead>
            <tr>
                <th  colspan="2" style="text-align: center; font-weight: normal; width:55%; background-color: #cccccc;border:1px solid #000">
                 চুড়ান্ত হিসাব 
                </th>


              <th  colspan="1" style="text-align: center; font-weight: normal; width:15%; background-color: #cccccc;border:1px solid #000">
               পরিমান  
                </th>

                <th style="text-align: center; font-weight: normal;border-style :none; border-width:0px" rowspan="5">
                  
                </th>

            </tr>
        </thead>
        <tbody>
            <tr>
                
                    <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১৫</td>
                
<td style = "text-align :left; width :50%;border:1px solid #000" >
                নীট প্রদেয় (সারি ৬-১৪) 
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="netPayment" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
                
                <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১৬</td>
                
<td style = "text-align :left; width :50%;border:1px solid #000" >
                ট্রেজারীতে জমা 
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="treasuryPaymentTax" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
               
<td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১৭</td>
              
<td style = "text-align :left; width :50%;border:1px solid #000" >
               পরবর্তী মাসের প্রারম্ভিক জের 
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="nextMonthJer" runat="server" ></asp:Label>
                   
                </td>

                
                
            </tr>

            <tr>
               
<td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১৮</td>
               
<td style = "text-align :left; width :50%;border:1px solid #000" >
               পরিদপ্তর হইতে প্রত্যর্পণ 
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="Label24" runat="server" ></asp:Label>
                   
                </td>
            </tr>
        </tbody>
    </table>


    <table class="table" style="width: 100%">
        <thead>
            <tr>
             <th  colspan="2" style="text-align: center; font-weight: normal; width:55%; background-color: #cccccc;border:1px solid #000">
                 সরবরাহকারী কর্তৃক উৎস মূসক কর্তনের হিসাব

                </th>


              <th  colspan="1" style="text-align: center; font-weight: normal; width:15%; background-color: #cccccc;border:1px solid #000">
               পরিমান  
                </th>

                <th style="text-align: center;border-style :none; border-width:0px; font-weight: normal" rowspan="2">
                  
                </th>

            </tr>
        </thead>
        <tbody>
            <tr>
                <td style = "text-align :center; width :5%;border:1px solid #000" >
                    ১৯
                </td>
              <td style = "text-align : left; width :50%;border:1px solid #000" >
                উৎসে কর্তিত মোট মূসকের পরিমাণ 
                </td>

                <td style = "text-align :center;border:1px solid #000">
                   
                    <asp:Label ID="VDS_19" runat="server" ></asp:Label>
                   
                </td>
            </tr>
            
        </tbody>
    </table>


 <div style="margin-top: 40px">
                <table style="width: 100%; border-style :none; border-width:0px">
                   
                    <tr>
                        <td colspan="4">
                         আমি ঘোষণা করিতেছি যে, এই দাখিলপত্রে উল্লেখিত সকল তথ্যাদি সত্য ও সঠিক ।
                        </td>
                    </tr>

                    <tr>
                        <td  style = "width:10%"> তারিখ :</td>
                        <td  style = "width:25%;border:1px solid #000">
                            <asp:Label ID="lblDate" Width = "100%" runat="server" TextMode="Password"></asp:Label> 
                        </td>
                        <td  style = "width:25%; text-align:right">করদাতার সাক্ষর ও সিল</td>
                        <td  style = "width:25%"></td>
                    </tr>
                    <tr>
                        <td colspan="4" >
                         সংযুক্তিঃ- বিধি ২৪ এ বর্ণিত সকল কাগজাদি/ দলিলাদি ৷
                        </td>
                    </tr>
                  
                </table>
            </div>
</div>
       </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
