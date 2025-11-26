<%@ page language="C#" autoeventwireup="true" inherits="UI_Sale_SaleChallan11Print, App_Web_ebyme1bz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sale Challan Report</title>
    <style>
        .btn
            {
                padding:5px;
                margin:10px;
                text-decoration:none;
            }
            .btn-default
            {
                background:#ddd;
                color:#000;
            }
             .btn-danger
            {
                background:#F26363;
                color:#fff;
            }
            td{padding-right:15px;}
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
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="ltChallanDetail" runat="server"></asp:Literal>
        <asp:Literal ID="ltChallanProductDetail" runat="server"></asp:Literal>
        
        <br>
        <center><a href="SaleChallan11.aspx" class="btn btn-default noPrint">Back</a> <a href="#" onclick="window.print(); return false;"  data-toggle="tooltip" title="Print Page" class="btn btn-danger noPrint"><i class="fa fa-print"></i> Print</a></center>
        
    </div>
    </form>
</body>
</html>
