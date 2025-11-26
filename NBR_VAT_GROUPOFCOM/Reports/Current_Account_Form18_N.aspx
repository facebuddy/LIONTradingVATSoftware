<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_Current_Account_Form18_N, App_Web_xijeoyc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/Panel_Custom.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
     <script type="text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlContents.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title>DIV Contents</title>');
             printWindow.document.write('</head><body >');
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
    <div>
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
                    Tax For
                </td>
                <td class="td-width-2">
                </td>
                <td>
                    <div style="width: 70%; border: 1px; border-style: solid; float: left;">
                        <asp:DropDownList ID="drpReportFor" runat="server" Width="100%" Height="25px">
                            <asp:ListItem Value="1">VAT</asp:ListItem>
                            <asp:ListItem Value="2">SD</asp:ListItem>
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
                        <asp:TextBox ID="txtFromDate" runat="server" Width="300px" DateFormat="dd/MM/yyyy" style="font-size:11pt"></asp:TextBox>
                        <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate"/>
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
                        <asp:TextBox ID="txtToDate" runat="server" Width="300px" DateFormat="dd/MM/yyyy" style="font-size:11pt"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate"/>
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
                        <asp:Button ID="btnShow" runat="server" CssClass="button" Text="Show Report" OnClick="btnShow_Click" />
                        <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="Print" OnClientClick="return PrintPanel();"
                                    Width="64px" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />

    <panel id = "pnlContents" runat = "server" >


    <div class="row">
        <p style="text-align: center">
            গণপ্রজাতন্ত্রী বাংলাদেশ সরকার
        </p>
        <p style="text-align: center">
            জাতীয় রাজস্ব বোর্ড
        </p>
        <p style="text-align: center">
            ঢাকা
        </p>
        <br />
        <p style="text-align: center">
            <strong>চলতি হিসাব </strong>
        </p>
        <p style="text-align: center">
            [বিধি 22(১) দ্রষ্টব্য]</p>
        <p style="border: 1px solid #000; float: right; margin-right: 15px">
            মূসক-<b><span lang="BN-BD">১৮</span></b>.</p>
    </div>
    <br />
    <br />
    <div class="row">
        <p style="float: left">
    </div>
    <div>
        <table class="table table-bordered" style="width: 100%; background-color: White; border-style :none; border-width:0px" >
            <tr>
                <td style="text-align: right; font-weight: normal; width:20%; height:20px">
                    করদাতা সনাক্তকরণ সংখ্যা
                </td>
                <td style="text-align: center; font-weight: normal; width:2%; height:20px">
                    &nbsp;
                </td>
               <td style="text-align: left; font-weight: normal; width:78%;height:20px">
                    <asp:Label ID="lblIdentificationNumber" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                 <td style="text-align: right; font-weight: normal; width:20%; height:20px">
                    নাম
                </td>
               <td style="text-align: center; font-weight: normal; width:2%; height:20px">
                    &nbsp;
                </td>
               <td style="text-align: left; font-weight: normal; width:78%;height:20px">
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  <td style="text-align: right; font-weight: normal; width:20%; height:20px">
                    ঠিকানা
                </td>
                <td style="text-align: center; font-weight: normal; width:2%; height:20px">
                    &nbsp;
                </td>
               <td style="text-align: left; font-weight: normal; width:78%;height:20px">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
                   
                </td>
            </tr>
            
            <tr>
                 <td style="text-align: right; font-weight: normal; width:20%; height:20px">
                   
                    টেলিফোন
                </td>
               <td style="text-align: center; font-weight: normal; width:2%; height:20px">
                    &nbsp;
                </td>
               <td style="text-align: left; font-weight: normal; width:78%;height:20px">
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <table border="1" class="table table-bordered" style="width: 100%; background-color: White;border-collapse:collapse" >
        <thead>
            <tr>
                <th class="col_3_percent" 
                    style="text-align: center; font-weight: normal" >
                    ক্রমিক সংখ্যা
                </th>
                <th class="col_t_percent" 
                    style="text-align: center; font-weight: normal" >
                    তারিখ
                </th>
                <th style="text-align: center; font-weight: normal" >
                    লেনদেনের বর্ণনা
                </th>
                <th colspan="2" style="text-align: center; font-weight: normal">
                    ক্রয় বা বিক্রয় হিসাব পুস্তকের
                </th>
                <th style="text-align: center; font-weight: normal" >
                    ট্রেজারি জমা
                </th>
                <th style="text-align: center; font-weight: normal" >
                    রেয়াত
                </th>

                 <th style="text-align: center; font-weight: normal" >
                    অন্যান্য সমন্বয়(যদি থাকে)
                </th>

                <th style="text-align: center; font-weight: normal" >
                    প্রদেয়
                </th>
                <th style="text-align: center; font-weight: normal" >
                    সমাপণী জের
                </th>
                <th style="text-align: center; font-weight: normal" >
                    মন্তব্য
                   
                </th>
            </tr>
            
        </thead>
        <tbody>
              <tr>
              <td style="text-align: center">
                    
                </td>
                <td style="text-align: center">
                    
                </td>
                <td style="text-align: center">
                    
                </td>
                <td style="text-align: center">
                    ক্রমিক নং
                </td>
                <td style="text-align: center">
                    তারিখ
                </td>
                 <td style="text-align: center">
                    
                </td>
                <td style="text-align: center">
                    
                </td>
                <td style="text-align: center">
                    
                </td>
                <td style="text-align: center">
                    
                </td>
                <td style="text-align: center">
                    
                </td>
                 <td style="text-align: center">
                    
                </td>
                
            </tr>
            
            <tr>
                <td style="text-align: center">
                    ১
                </td>
                <td style="text-align: center">
                    ২
                </td>
                <td style="text-align: center">
                    ৩
                </td>
                <td style="text-align: center">
                    ৪
                </td>
                <td style="text-align: center">
                    ৫
                </td>
                <td style="text-align: center">
                    ৬
                </td>
                <td style="text-align: center">
                    ৭
                </td>
                <td style="text-align: center">
                    ৮
                </td>
                <td style="text-align: center">
                    ৯
                </td>
                <td style="text-align: center">
                    ১০
                </td>
                 <td style="text-align: center">
                    ১১
                </td>
            </tr>
            <tr style="background-color: White">
                <asp:Label runat="server" ID="lblInfoShow"></asp:Label></tr>
        </tbody>
    </table>
   <div class="col-md-12" style="margin-top:5px">
        <div class="form-group form-group-sm">
            <asp:Label runat="server" Text="System User: "></asp:Label>
            <asp:Label runat="server" ID="lblUser"></asp:Label>
            <asp:Label runat="server" ID="lblPrintDateTime" style="float:right"></asp:Label>
            <asp:Label runat="server" ID="Label1" style="float:right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
        </div>
    </div>
    </panel>
    <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>
