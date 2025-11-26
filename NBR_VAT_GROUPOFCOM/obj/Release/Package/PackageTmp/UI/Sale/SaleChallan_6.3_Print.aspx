<%@ page language="C#" autoeventwireup="true" inherits="SaleChallan_6_3_Print, App_Web_lqwzozjx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Styles/bootstrap/bootstrap.css" />
    <style>
     hr
     {
         width:30%;
         border-color:Black;
         float:left;
         margin-top:5%;
         border-width: 1px;
     }
    </style>
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
      <p style="text-align:center;margin-left: 80px;">কর চালানপত্র  <b style="border:1px solid #000; margin-left:1%; float:right">মূসক-৬.৩</b></p>
      <p style="text-align:center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (গ) ও দফা (চ) দ্রষ্টব্য]</p>
    </div>
    <div class="row">
        <p style="margin-left:25%">নিবন্ধিত ব্যক্তির নামঃ&nbsp <asp:Label runat="server" ID="lblOrgName" style="font-weight:bold;font-size:14px" /></p>
        <p style="margin-left:25%">নিবন্ধিত ব্যক্তির বিআইএনঃ&nbsp <asp:Label runat="server" ID="lblOrgBIN" style="font-weight:bold;font-size:14px"/></p>
        <p style="margin-left:25%">চালানপত্র ইস্যুর ঠিকানাঃ&nbsp <asp:Label runat="server" ID="lblOrgAddress" style="font-weight:bold;font-size:14px"/></p>
    </div>
    <div class="row">
     <div class="col-sm-6" style="padding:0px">
        <p>ক্রেতার নামঃ&nbsp <asp:Label runat="server" ID="lblPartyName" style="font-weight:bold;font-size:14px"/></p>
        <p>ক্রেতার বিআইএনঃ&nbsp <asp:Label runat="server" ID="lblPartyBIN" style="font-weight:bold;font-size:14px"/></p>
        <p>সরবরাহের গন্তব্যস্থলঃ&nbsp <asp:Label runat="server" ID="lblUltimateDestination" style="font-weight:bold;font-size:14px"/></p>
       
     </div>
     <div class="col-sm-6" >
         <p >চালানপত্র নম্বরঃ&nbsp <asp:Label runat="server" ID="lblChallanNo" style="font-weight:bold;font-size:14px"/></p>
         <p >ইস্যুর তারিখঃ&nbsp <asp:Label runat="server" ID="lblChallanDate" style="font-weight:bold;font-size:14px"/></p>
         <p >ইস্যুর সময়ঃ&nbsp <asp:Label runat="server" ID="lblChallanTime" style="font-weight:bold;font-size:14px"/></p>
     </div>
    </div>
    <div class="row" style="padding:1px">
      <p>সরবরাহের বিবরণঃ</p>
      <table class="table table-bordered" style="width:auto;text-align:center">
        <tr style="text-align:center">
          <th scope="row" style="width:5%;text-align:center">ক্রমিক</th>
          <th style="width:45%;text-align:center">সরবরাহের বিবরণ</th>
          <th style="width:5%;text-align:center">সরবরাহের একক</th>
          <th style="width:10%;text-align:center">পরিমাণ</th>
          <th style="width:15%;text-align:center">একক মূল্য<sup>১</sup> (টাকায়)</th>
          <th style="width:5%;text-align:center">সম্পূরক শুল্কের পরিমাণ </th>
          <th style="width:15%;text-align:center">মোট মূল্য (টাকায়) </th>
        </tr>
        <tr>
            <asp:Label runat="server" ID="lblSaleChallanReport"></asp:Label>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right;border:0">সর্বমোট</td>
         <td style="width:25px"><asp:Label runat="server" ID="lblTotalSD" /></td>
         <td style="width:25px"><asp:Label runat="server" ID="lblTotalPrice" /></td>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right;border:0">সর্বমোট মূসক<sup>২</sup></td>
         <td style="width:25px" colspan="2"><asp:Label runat="server" ID="lblTotalVat" /></td>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right; border:0">সর্বমোট কর<sup>৩</sup></td>
         <td style="width:25px" colspan="2"><asp:Label runat="server" ID="lblTotalTax" /></td>
        </tr>
        <tr>
         <td colspan="5" style="text-align:right;border:0">উৎসে কর্তনযোগ্য করের সর্বোচ্চ পরিমাণ<sup>৪</sup></td>
         <td style="width:25px" colspan="2"><asp:Label runat="server" ID="lblVDS" /></td>
        </tr>
      </table>
      <p>দায়িত্ব প্রাপ্ত ব্যক্তির নাম ও স্বাক্ষর</p>
    </div>
    <div class="row">
      <hr/>
    </div>
    
    <div class="row">
      
      <p><sup>১</sup> প্রতি একক সরবরাহের মূসক ও সম্পূরক শুল্ক (যদি থাকে) সহ মূল্য।</p>
      <p><sup>২</sup> সর্বমোট মূল্য গুণন কর-ভগ্নাংশ।</p>
      <p><sup>৩</sup> সর্বমোট সম্পূরক শুল্ক যোগ সর্বমোট মূসক।</p>
      <p><sup>৪</sup> সর্বমোট মূসক-এর এক-তৃতীয়াংশ পরিমাণ। শুধু উৎসে কর্তনযোগ্য সরবরাহের ক্ষেত্রে ফরমটি সমনবিত কর চালানপত্র ও </p>
      <p>উৎসে কর কর্তন সনদপত্র হিসেবে বিবেচিত হইবে। এটি উৎসে কর কর্তনযোগ্য সরবরাহের ক্ষেত্রে প্রযোজ্য হইবে। </p>
    </div>
    <div class="row">
      <center><a href="#" onclick="window.print(); return false;"  data-toggle="tooltip" title="Print Page" class="btn btn-danger noPrint"><i class="fa fa-print"></i> Print</a></center>
    </div>
</body>
</html>
