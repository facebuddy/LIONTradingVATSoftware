<%@ page language="C#" autoeventwireup="true" inherits="TurnoverVatChallan_6_9_Print, App_Web_fxp4hfg1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link rel="stylesheet" type="text/css" href="../../Styles/bootstrap/bootstrap.css" />
<style media="print">
            .noPrint{ display: none;}
            @media print { table{width:100%;} tr,td {padding:5px;}
            .full_width{
                width: 100%;
            }
            } 
            .yesPrint{ display: block !important; }
            input[type=text],select,textarea,.text_box
            {
                border:none;
            }
            
        </style>
</head>
<body style="padding:2%">
    <div class="row">
      <p style="text-align:center;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
      <p style="text-align:center; padding:0px">জাতীয় রাজস্ব বোর্ড</p>
      <p style="text-align:center;margin-left: 80px;">টার্নওভার কর চালানপত্র <b style="border:1px solid #000; margin-left:1%; float:right">মূসক-৬.৯</b></p>
      <p style="text-align:center">[বিধি ৪১ এর দফা (খ) দ্রষ্টব্য]</p>
    </div>
    <div class="row">
        <p>তালিকাভুক্ত ব্যক্তির নামঃ <asp:Label runat="server" ID="LPN" style="margin-left:5px; font-size:16px"></asp:Label></p>
        <p>তালিকাভুক্ত ব্যক্তির বিআইএনঃ <asp:Label runat="server" ID="LPBIN" style="margin-left:5px; font-size:16px"/></p>
        <p>চালান ইস্যুর ঠিকানাঃ <asp:Label runat="server" ID="CIA" style="margin-left:5px; font-size:16px"/></p>
        <p>চালান নম্বরঃ <asp:Label runat="server" ID="CN" style="margin-left:5px; font-size:16px"/></p>
        <p>চালান ইস্যুর তারিখঃ <asp:Label runat="server" ID="CID" style="margin-left:5px; font-size:16px"/></p>
    </div>
    <div class="row">
        <p style="margin-left:36%">ক্রেতার নামঃ <asp:Label runat="server" ID="PN" style="margin-left:5px; font-size:16px"/></p>
        <p style="margin-left:34%">ক্রেতার বিআইএনঃ <asp:Label runat="server" ID="PBIN" style="margin-left:5px; font-size:16px"/></p>
    </div>
    <div class="row" style="padding:1px">
      <p>সরবরাহের বিবরণঃ</p>
      <table class="table table-bordered" style="width:100%;text-align:center">
        <tr style="text-align:center">
          <th scope="row" style="width:5%;text-align:center">ক্রমিক</th>
          <th style="width:45%;text-align:center">সরবরাহের বর্ণনা</th>
          <th style="width:10%;text-align:center">সরবরাহের একক</th>
          <th style="width:10%;text-align:center">পরিমাণ</th>
          <th style="width:15%;text-align:center">একক মূল্য<sup>১</sup> (টাকায়)</th>
          <th style="width:15%;text-align:center">মোট মূল্য<sup>১২</sup> (টাকায়) </th>
        </tr>
        <tr>
            <asp:Label runat="server" ID="lblTurnoverReport" ></asp:Label>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right;border:none; padding-right:5px">সর্বমোট মূল্য</td>
         <td style="width:25px"><asp:Label runat="server" ID="lblgrandTotal"></asp:Label></td>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right;border:none; padding-right:5px">টার্নওভার করের পরিমাণ (টাকা)<sup>১৩</sup></td>
         <td style="width:25px"><asp:Label runat="server" ID="lblTurnoverTax"></asp:Label></td>
        </tr>
      </table>
      <p>দায়িত্ব প্রাপ্ত ব্যক্তির স্বাক্ষর </p>
    </div>
    <div class="row">
      <center><a href="#" onclick="window.print(); return false;"  data-toggle="tooltip" title="Print Page" class="btn btn-danger noPrint"><i class="fa fa-print"></i> Print</a></center>
    </div>
</body>
</html>
