<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="KGCDashboard.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.KGCDashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/Dashboard.css" rel="stylesheet" type="text/css" />
    <style>
    .blink_text {

    animation:30s blinker linear infinite;
    -webkit-animation:3s blinker linear infinite;
    -moz-animation:1s blinker linear infinite;    
    }

    @-moz-keyframes blinker {  
     0% { opacity: 1.0; }
     50% { opacity: 0.0; }
     100% { opacity: 1.0; }
     }

    @-webkit-keyframes blinker {  
     0% { opacity: 1.0; }
     50% { opacity: 0.0; }
     100% { opacity: 1.0; }
     }

    @keyframes blinker {  
     0% { opacity: 1.0; }
     50% { opacity: 0.0; }
     100% { opacity: 1.0; }
     }
    .HeaderTDP
{
    width: 16.66%;
    text-align: center;
    font-size: 15px;
    font-weight: bold;
    border-style: solid;
    border-width: 2px;
    color: #F7F7F7;
    background-color: #375623;
}
    .HeaderTDS
    {
    width: 16.66%;
    text-align: center;
    font-size: 15px;
    font-weight: bold;
    border-style: solid;
    border-width: 2px;
    color: #F7F7F7;
    background-color: #7030A0;
   }    
    .ajax__calendar_next {
    cursor: pointer;
    width: 15px;
    height: 15px;
    float: right;
    background-repeat: no-repeat;
    background-position: 50% 50%;
    background-image: url(WebResource.axd?d=8kov1q6cQDST05ktLhJkXUrOTE-6abrIZh810mIq_xQa2dG1eU3CFYh99x6vf4JZlzC6xyEGWFD5m-7Lz88rmPKmOkPo6ySkSiZnvjQog0aKp0zgChJhaVCELWJqXl4bMLnFaSSLTqf6Txs6PYGhxg2&t=637080524892428093);
}
   .ajax__calendar_prev {
    cursor: pointer;    
    height: 15px;
    float: left;   
    background-repeat: no-repeat;
    background-position: 50% 50%;
    
} 
   .hiddencol{
       display:none;
   }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
 
   <center>
       
       <h1 style="color: #337ab7; font-family: 'Trocchi', serif; font-size: 50px; font-weight: 500;
        line-height: 58px; margin: 0;">
     Welcome to the LION KALLOL LIMITED Vat Management Software
    </h1>
    </center>



      <a href="/Reports/Challan_Form11sCheck.aspx"><i class="bx bx-right-arrow-alt"></i>  চালানপত্র (মূসক-৬.৩) Checker</a>









     <div id="PopupContainer1" runat="server"></div>
    <div id="PopupContainer4" runat="server"></div>
    <div id="PopupContainer5" runat="server"></div>
    <div id="PopupContainer3" runat="server"></div>
    <div id="PopupContainer2" runat="server"></div>
    <div id="PopupContainer6" runat="server"></div>
    <%--   <fieldset class="scheduler-border">
    <legend class="scheduler-borderBold">VAT Refund Amount</legend>

     <fieldset class="scheduler-border">
            <legend class="scheduler-border"></legend>
    <table class = "MainTable">
        <tr class="HeaderRow">
            <td class="HeaderTD">
                With Minimum Time
            </td>
            <td class="HeaderTD">
                Expiry Date
            </td>
          
        </tr>
        <tr class="HeaderRow">
            <td class="DataTD" >
                
                 <asp:Label runat="server" ID="lblWithMinimumTime" />
                
            </td>
            <td class="DataTD"">
               
                 <asp:Label runat="server" ID="lblExpiryDate" />
               
            </td>
         
           
        </tr>
    </table>
    </fieldset>
    </fieldset>--%>
      <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
        
            </div>
</asp:Content>

