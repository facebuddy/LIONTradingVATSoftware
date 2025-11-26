<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="AccountingBookAudit, App_Web_qhrdyc5n" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <style>
        tr > td {
            padding: 5px;
        }

        tr > th {
            padding: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 25px; padding-top: 0px">Accounting Book Audit by NBR Authority</div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">Audit Part :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlAuditPart" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAuditPart_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                                <asp:ListItem Value="1">Purchase Accounting Book</asp:ListItem>
                                                <asp:ListItem Value="2">Sale Accounting Book</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="col-md-6"  style="padding-left:0px;padding-right:0px">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date From :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateFrom" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6"  style="padding-left:0px;padding-right:0px">
                                        <div class="form-group form-group-sm">
                                            <label class="control-label col-sm-5 text-right">Date To :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateTo" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-4 text-right">Items :</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlItems" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-warning btn-sm" OnClick="btnSearch_Click"><i class="fa fa-search-plus"></i> Item</asp:LinkButton>
                                    <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnShow_Click"><i class="fa fa-clone"></i> Report</asp:LinkButton>
                                </div>
                                
                            </div>
                            <div class="row">
                                    <asp:Label runat="server" ID="lblAuditPartID" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblChallanID" Visible="false"></asp:Label>
                                    <fieldset class="scheduler-border">
                                        <legend class="scheduler-border">For NBR Authority</legend>
                                        <div class="col-md-3">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-5 text-right">Authority Name :</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtNBRAuthorityName" runat="server" CssClass="form-control" MaxLength="120" Height="35px">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-4 text-right"> Designation :</label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox ID="txtAuthorityDesignation" runat="server" CssClass="form-control" Height="35px" MaxLength="120">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-sm-4 text-right">Comment :</label>
                                                <div class="col-sm-8">
                                                    <asp:TextBox ID="txtNBRAuthorityComment" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" MaxLength="500" Height="35px">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:LinkButton ID="btnlnAccountingBook" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnlnAccountingBook_Click"><i class="fa fa-send"></i> Save Audit Record</asp:LinkButton>
                                        </div>
                                    </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel panel-body">
                            <div class="col-md-12">
                                <div runat="server" id="PurchaseAccountingBook">
                                    <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse; background-color: white;">
                                        <thead>
                                            <tr style="border: 1px solid #000">
                                                <td colspan="19" style="font-weight: normal">
                                                    <center>
                                                        <h4 style="font-weight: normal">
                                                            পণ্য/ সেবার উপকরণ ক্রয় (ক্রয় হিসাব পুস্তক)</h4>
                                                    </center>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th rowspan="3" class="col_3_percent" style="font-weight: normal">ক্রমিক সংখ্যা</th>
                                                <th rowspan="3" class="col_3_percent" style="font-weight: normal">তারিখ</th>
                                                <th colspan="2" style="font-weight: normal">মজুদ উপকরণের প্রারম্ভিক  জের</th>
                                                <th colspan="10" style="text-align: center" style="font-weight: normal">ক্রয়কৃত উপকরণ</th>
                                                <th colspan="2" rowspan="2" class="col_10_percent" style="font-weight: normal">পণ্য প্রস্তুতকরণ / উৎপাদনে ব্যবহার (ব্যবসায়ীদের ক্ষেত্রে পণ্য বিক্রয়)</th>
                                                <th colspan="2" rowspan="2" style="font-weight: normal">উপকরণের প্রান্তিক জের</th>
                                                <th rowspan="3" style="font-weight: normal">মন্তব্য</th>

                                            </tr>
                                            <tr>
                                                <th class="col_3_percent" style="font-weight: normal" rowspan="2">পরিমাণ</th>
                                                <th class="col_3_percent" style="font-weight: normal" rowspan="2">মূল্য</th>
                                                <th class="col_5_percent" style="font-weight: normal" rowspan="2">চালানপত্র / বিল অব এন্ট্রি নং</th>
                                                <th class="col_3_percent" style="font-weight: normal" rowspan="2">তারিখ</th>
                                                <th colspan="3" class="col_15_percent" style="text-align: center" style="font-weight: normal">বিক্রেতা/সরবরাহকারী</th>

                                                <th class="col_3_percent" style="font-weight: normal" rowspan="2">বিবরণ</th>
                                                <th class="col_3_percent" style="font-weight: normal" rowspan="2">পরিমাণ</th>
                                                <th class="col_3_percent" style="font-weight: normal" rowspan="2">মূল্য (সম্পূরক শুল্ক ও মূসক বাদে)</th>
                                                <th class="col_3_percent" style="font-weight: normal" rowspan="2">সম্পূরক শুল্ক (যদি থাকে)</th>
                                                <th class="col_3_percent" style="font-weight: normal" rowspan="2">মূসক</th>



                                            </tr>
                                            <tr>
                                                <th style="font-weight: normal">নাম</th>
                                                <th style="font-weight: normal">ঠিকানা</th>
                                                <th style="font-weight: normal">নিবন্ধন নং</th>
                                                <th style="font-weight: normal">পরিমাণ</th>
                                                <th style="font-weight: normal">মূল্য</th>
                                                <th style="font-weight: normal">পরিমাণ</th>
                                                <th style="font-weight: normal">মূল্য</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>১</td>
                                                <td>২</td>
                                                <td>৩</td>
                                                <td>৪</td>
                                                <td>৫</td>
                                                <td>৬</td>
                                                <td>৭</td>
                                                <td>৮</td>
                                                <td>৯</td>
                                                <td>১০</td>
                                                <td>১১</td>
                                                <td>১২</td>
                                                <td>১৩</td>
                                                <td>১৪</td>
                                                <td>১৫</td>
                                                <td>১৬</td>
                                                <td>১৭</td>
                                                <td>১৮</td>
                                                <td>১৯</td>
                                            </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblPurchaseBookRow" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div runat="server" id="SalesAccountingBook">
                                    <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse;background-color:white">
                                        <thead>
                                            <tr style="border: 1px solid #000">
                                                <td colspan="19" style="font-weight: normal">
                                                    <center>
                                                        <h4 style="text-align: center; font-weight: normal">পণ্য/সেবার বিক্রয় (বিক্রয় হিসাব পুস্তক )</h4>
                                                    </center>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th rowspan="1" class="col_3_percent" style="text-align: center; font-weight: normal">ক্রমিক সংখ্যা
                                                </th>
                                                <th rowspan="1" class="col_3_percent" style="text-align: center; font-weight: normal">তারিখ
                                                </th>
                                                <th colspan="2" style="text-align: center; font-weight: normal">উৎপাদিত পণ্যের প্রারম্ভিক জের (ব্যবসায়ীদের ক্ষেত্রে আমদানি/ক্রয়কৃত পণ্যের প্রারম্ভিক জের
                                                </th>
                                                <th colspan="2" style="text-align: center; font-weight: normal">উৎপাদন (ব্যবসায়ীদের ক্ষেত্রে আমদানি/ক্রয়কৃত পণ্য)
                                                </th>
                                                <th colspan="3" style="text-align: center; font-weight: normal">ক্রেতা/ সরবরাহ গ্রহীতা
                                                </th>
                                                <th colspan="2" style="text-align: center; font-weight: normal">চালানপত্রের
                                                </th>
                                                <th colspan="5" style="text-align: center; font-weight: normal">সরবরাহকৃত পণ্য
                                                </th>
                                                <th colspan="2" style="text-align: center; font-weight: normal">পণ্যের প্রান্তিক জের
                                                </th>
                                                <th colspan="1" style="text-align: center; font-weight: normal">মন্তব্য
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td style="text-align: center"></td>
                                                <td style="text-align: center"></td>
                                                <td style="text-align: center">পরিমাণ 
                                                </td>
                                                <td style="text-align: center">মূল্য 
                                                </td>
                                                <td style="text-align: center">পরিমাণ 
                                                </td>
                                                <td style="text-align: center">মূল্য 
                                                </td>
                                                <td style="text-align: center">নাম 
                                                </td>
                                                <td style="text-align: center">নিবন্ধন নং 
                                                </td>
                                                <td style="text-align: center">ঠিকানা 
                                                </td>
                                                <td style="text-align: center">নম্বর 
                                                </td>
                                                <td style="text-align: center">তারিখ ও সময়
                                                </td>
                                                <td style="text-align: center">বিবরণ 
                                                </td>
                                                <td style="text-align: center">পরিমাণ 
                                                </td>
                                                <td style="text-align: center">করযোগ্য মূল্য(সম্পূরক শুল্ক ও মুসক বাদে) 
                                                </td>
                                                <td style="text-align: center">সম্পূরক শুল্ক(যদি থাকে) 
                                                </td>
                                                <td style="text-align: center">মুসক 
                                                </td>
                                                <td style="text-align: center">পরিমাণ 
                                                </td>
                                                <td style="text-align: center">মূল্য 
                                                </td>
                                                <td style="text-align: center"></td>
                                            </tr>



                                            <tr>
                                                <td style="text-align: center">১
                                                </td>
                                                <td style="text-align: center">২
                                                </td>
                                                <td style="text-align: center">৩
                                                </td>
                                                <td style="text-align: center">৪
                                                </td>
                                                <td style="text-align: center">৫
                                                </td>
                                                <td style="text-align: center">৬
                                                </td>
                                                <td style="text-align: center">৭
                                                </td>
                                                <td style="text-align: center">৮
                                                </td>
                                                <td style="text-align: center">৯
                                                </td>
                                                <td style="text-align: center">১০
                                                </td>
                                                <td style="text-align: center">১১
                                                </td>
                                                <td style="text-align: center">১২
                                                </td>
                                                <td style="text-align: center">১৩
                                                </td>
                                                <td style="text-align: center">১৪
                                                </td>
                                                <td style="text-align: center">১৫
                                                </td>
                                                <td style="text-align: center">১৬
                                                </td>
                                                <td style="text-align: center">১৭
                                                </td>
                                                <td style="text-align: center">১৮
                                                </td>
                                                <td style="text-align: center">১৯
                                                </td>
                                            </tr>
                                            <tr>
                                                <asp:Label runat="server" ID="lblReportView" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
