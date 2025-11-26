<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Sale_AllSaleChallan11View, App_Web_ebyme1bz" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register src="../../UserControls/Sale.ascx" tagname="sale" tagprefix="uc1" %>--%>
<%@ Register Src="../../UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 25px;
        }
        .style3
        {
            height: 24px;
        }

        
        
        .btn
        {
            padding: 5px;
            margin: 10px;
            text-decoration: none;
        }
        .btn-default
        {
            background: #ddd;
            color: #000;
        }
        .btn-danger
        {
            background: #F26363;
            color: #fff;
        }
        td
        {
            padding-right: 15px;
        }
        
        .zero-padding-top
        {
            padding-top: 0px;
        }
        .zero-padding-bottom
        {
            padding-bottom: 0px;
            height: 0px;
        }
        
        .modal_custom
        {
            background: #fff;
            padding: 10px;
        }
    </style>
    <style media="print">
        .noPrint
        {
            display: none;
        }
        @media print
        {
            table
            {
                width: 100%;
            }
            tr, td
            {
            }
            .full_width
            {
                width: 100%;
            }
        }
        .yesPrint
        {
            display: block !important;
        }
        input[type=text], select, textarea, .text_box
        {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2>Sale Challan List</h2>
        <table border="1" style="border-collapse:collapse;">
            <thead>
                <tr>
                    <th>Challan No</th>
                    <th>Party Name</th>
                    <th>Challan Date</th>
                    <th>View & Print</th>
                    <th>Cash Memo</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <asp:Literal ID="ltAllChallan" runat="server"></asp:Literal>
                </tr>
            </tbody>
        </table>

</asp:Content>

