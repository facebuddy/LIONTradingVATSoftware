

<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.master" CodeBehind="Admin_DashboardsSIMS.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Admin_DashboardsSIMS" %>
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
    <h1 style="color: #7c795d; font-family: 'Trocchi', serif; font-size: 30px; font-weight: normal;
        line-height: 48px; margin: 0;">
        Dashboard
    </h1>

     <fieldset class="scheduler-border">
        <legend class="scheduler-borderBold"></legend>
       <%--  <asp:Calendar runat="server" SelectionMode="DayWeekMonth"></asp:Calendar>--%>
         <asp:TextBox ID="dtFinalDate" runat="server"  CssClass="hiddencol" DateFormat="yyyy-MM-dd" style="text-align:center;color:black;background-color:#B5C6E7"></asp:TextBox>
               <table border="1" style="width: 100%; border-collapse: collapse; border: 1px solid #000000">
                <thead style="text-align: center; font-weight: bold">
                
                    <tr style="background-color:#B5C6E7">
                    <td  colspan="2" style="color:#375623;font-weight:bolder">
                     Purchase
                    </td>
                       
                       <%-- <cc1:CalendarExtender ID="cc11" runat="server" Format="MMMM,yyyy" TargetControlID="dtpDateFrom" /></td>--%>
                    <td  colspan="2" style="color:#7030A0;font-weight:bolder">
                    Sale
                    </td>
               </tr>
                    
                     <tr class="HeaderRow">
                   
                    <td class="HeaderTDP">
                      Local (BDT)
                    </td>
                    <td class="HeaderTDP">
                        Import (BDT)
                    </td>
                    <td class="HeaderTDP">
                         VAT (BDT)
                    </td>
                    <td class="HeaderTDS">
                        Amount (BDT)
                    </td>
                     <td class="HeaderTDS">
                      VAT (BDT)
                    </td>
                  
                </tr>
                    </thead>
                <tbody>
                    <tr>
                    <asp:Label runat="server" ID="lblPurchaseSale"></asp:Label>
                   </tr>
                </tbody>
            
            </table>
         <table border="1" style="width: 100%; border-collapse: collapse; border: 1px solid #000000">
                <thead style="text-align: center; font-weight: bold">
                
                    <tr style="border:none" >
                    <td style="color:black;font-weight:bolder;background-color:#90AADB;">
                     VAT Payable (BDT) 
                    </td>
                   
                      <td class="hiddencol" style="color:black;font-weight:bolder;background-color:#90AADB">
                     VAT Receivable (BDT)
                    </td>  
                   <td style="color:black;font-weight:bolder;background-color:#90AADB;">
                     VDS Payable (BDT) (upto this month) 
                    </td>
                    <td style="color:black;font-weight:bolder;background-color:#9CC3E5">
                    VDS Payable (BDT)(this month)
                    </td>
                         <td class="hiddencol" style="color:black;font-weight:bolder;background-color:#9CC3E5">
                    VDS Receivable (BDT)
                    </td>
                    <td style="color:black;font-weight:bolder;background-color:#B5C6E7">
                   Rebate (BDT)
                    </td>
               </tr>
                   
                   
                    </thead>
                <tbody>
                    <tr style="border:none">
                    <asp:Label runat="server" ID="lblVATVDSReb"></asp:Label>
                   </tr>
                </tbody>
            
            </table>
    </fieldset>

    <fieldset class="scheduler-border">
       
     
          
           
            <table class="MainTable">              
                 <tr class="HeaderRow">
                     <td style="text-align:center;font-weight:bolder"><i class="fa fa-angle-left fa-3x"> Purchase & Sale</i> <i class="fa fa-angle-right fa-3x"></i></td>
                     <td style="text-align:center;font-weight:bolder"><i class="fa fa-angle-left fa-3x">VDS Payable & VDS Paid</i> <i class="fa fa-angle-right fa-3x"></i> </td>
                  </tr>
                <tr class="HeaderRow">
                    <td class="DataTDForChart">
                         
                        <asp:Chart ID="chrtPurchaseSale" runat="server" BorderlineWidth = "0" Width="600px" ImageStorageMode="UseImageLocation" ImageLocation="~/Images/chart/ChartPicSale#SEQ(300,3)">
                            <Series>
                                <asp:Series Name="Series1" XValueMember = "date" YValueMembers = "total_Purchase"
                                LegendText = "Purchase" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Aqua">
                                </asp:Series>


                                <asp:Series Name="Series2" XValueMember = "date" YValueMembers = "total_sale"
                                LegendText = "Sale" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Green">
                                </asp:Series>

                            </Series>

                        <Legends>
                        <asp:Legend title = "" />
                        </Legends>
                        <Titles>
                      
                        </Titles>

                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                 <AxisX Title="Date" IsLabelAutoFit = "false" LabelAutoFitMaxFontSize="8" LabelAutoFitMinFontSize="7" LabelAutoFitStyle="None">
                            <LabelStyle Angle="90" Font="Verdana, 8pt" Interval="Auto" IsEndLabelVisible="False"/>
                                 <ScaleBreakStyle BreakLineStyle="None" /></AxisX>
                                    <AxisY Title="Value"></AxisY>


                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>


                    </td>
                      <td class="DataTDForChart">
                        
                        <asp:Chart ID="chrtVATVDS" runat="server" BorderlineWidth = "0" Width="600px" ImageStorageMode="UseImageLocation" ImageLocation="~/Images/chart/ChartPicSale#SEQ(300,3)">
                            <Series>
                                <asp:Series Name="Series1" XValueMember = "date" YValueMembers = "total_VAT"
                                LegendText = "Payable" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Aqua">
                                </asp:Series>
                                <asp:Series Name="Series2" XValueMember = "date" YValueMembers = "total_VDS"
                                LegendText = "Paid" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Green">
                                </asp:Series>

                            </Series>

                        <Legends>
                        <asp:Legend title = "" />
                        </Legends>
                        <Titles>
                      
                        </Titles>

                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                 <AxisX Title="Date" IsLabelAutoFit = "false" LabelAutoFitMaxFontSize="8" LabelAutoFitMinFontSize="7" LabelAutoFitStyle="None">
                            <LabelStyle Angle="90" Font="Verdana, 8pt" Interval="Auto" IsEndLabelVisible="False"/>
                                 <ScaleBreakStyle BreakLineStyle="None" /></AxisX>
                                    <AxisY Title="Value"></AxisY>


                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>


                    </td>
                </tr>
            </table>
        </fieldset>
           
             
      <fieldset class="scheduler-border">
        <legend class="scheduler-borderBold">Branch wise Tranfer Challan List</legend>
       
            <table border="1" style="width: 100%; border-collapse: collapse; border: 1px solid #000000" class=MainTable>
                <thead style="text-align: center; font-weight: bold">
                <tr class="HeaderRow">
                   
                    <td class="HeaderTD">
                       Branch Name
                    </td>
                    <td class="HeaderTD">
                       Challan Number
                    </td>
                   <td class="HeaderTD">
                       
                    </td>
                </tr>
                    </thead>
                <tbody>
                    <tr>
                    <asp:Label runat="server" ID="lblTransferInfo"></asp:Label>
                   </tr>
                </tbody>
              
               
            </table>
        
           
        </fieldset>
     
       
  

     <fieldset class="scheduler-border">
        <legend class="scheduler-borderBold">VDS</legend>
       
            <table border="1" style="width: 100%; border-collapse: collapse; border: 1px solid #000000">
                <thead style="text-align: center; font-weight: bold">
                <tr class="HeaderRow">
                   
                    <td class="HeaderTD">
                       No. of TR Challan Acknowledged
                    </td>
                    <td class="HeaderTD">
                        No. of TR Challan not Printed
                    </td>
                    <td class="HeaderTD" style="color:orangered">
                      Last Day for TR Challan
                    </td>
                    <td class="HeaderTD" style="color:red">
                        No. of Challan expired for TR Challan
                    </td>
                     <td class="HeaderTD">
                       No. of 6.6 Issued  
                    </td>
                    <td class="HeaderTD">
                        No. of 6.6 Pending
                    </td>
                </tr>
                    </thead>
                <tbody>
                    <tr>
                    <asp:Label runat="server" ID="lblReportData"></asp:Label>
                   </tr>
                </tbody>
               <%-- <tr class="HeaderRow">
                    <td class="DataTD">
                        <asp:Label runat="server" ID="Label13">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="Label14">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="Label15">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="Label16">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="Label17">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="Label18">0</asp:Label>
                    </td>
                </tr>--%>
            </table>
        
           
        </fieldset>
    
    <fieldset class="scheduler-border hiddencol">
        <legend class="scheduler-borderBold">Purchase</legend>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border"></legend>
            <table class="MainTable">
                <tr class="HeaderRow">
                    <td class="HeaderTD">Purchase</td>
                </tr>

               
                <tr class="HeaderRow">
                    <td class="DataTDForChart">
                        
                        <asp:Chart ID="chrtServicePurchase" runat="server" BorderlineWidth = "0" Width="1200px" ImageStorageMode="UseImageLocation" ImageLocation="~/Images/chart/ChartPicPurchase#SEQ(300,3)">
                            <Series>
                                <asp:Series Name="Series1" XValueMember = "date" YValueMembers = "vat"
                                LegendText = "VAT" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Aqua">
                                </asp:Series>

                                <asp:Series Name="Series2" XValueMember = "date" YValueMembers = "sd"
                                LegendText = "SD" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Red">
                                </asp:Series>

                                <asp:Series Name="Series3" XValueMember = "date" YValueMembers = "total_price"
                                LegendText = "Total Price" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Green">
                                </asp:Series>

                            </Series>

                        <Legends>
                        <asp:Legend title = "" />
                        </Legends>
                        <Titles>
                    <%--    <asp:Title  Docking = "Bottom" Text = "Report In Chart" />--%>

                        </Titles>

                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                 <AxisX Title="Date" IsLabelAutoFit = "false" LabelAutoFitMaxFontSize="8" LabelAutoFitMinFontSize="7" LabelAutoFitStyle="None">
                            <LabelStyle Angle="90" Font="Verdana, 8pt" Interval="Auto" IsEndLabelVisible="False"/>
                                 <ScaleBreakStyle BreakLineStyle="None" /></AxisX>
                                    <AxisY Title="Value"></AxisY>


                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>


                    </td>
                    
                </tr>
            </table>
        </fieldset>
    </fieldset>

    <fieldset class="scheduler-border hiddencol">
        <legend class="scheduler-borderBold">Sale</legend>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border"></legend>
            <table class="MainTable">
                <tr class="HeaderRow">
                    <td class="HeaderTD">
                    Sale</td>
                </tr>

               
                <tr class="HeaderRow">
                    <td class="DataTDForChart">
                        
                        <asp:Chart ID="chrtServiceSale" runat="server" BorderlineWidth = "0" Width="1200px" ImageStorageMode="UseImageLocation" ImageLocation="~/Images/chart/ChartPicSale#SEQ(300,3)">
                            <Series>
                                <asp:Series Name="Series1" XValueMember = "date" YValueMembers = "vat"
                                LegendText = "VAT" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Aqua">
                                </asp:Series>


                                <asp:Series Name="Series3" XValueMember = "date" YValueMembers = "total_price"
                                LegendText = "Total Price" IsValueShownAsLabel = "false" ChartArea = "ChartArea1" 
                                MarkerBorderColor = "Green">
                                </asp:Series>

                            </Series>

                        <Legends>
                        <asp:Legend title = "" />
                        </Legends>
                        <Titles>
                       <%-- 
                       <asp:Title  Docking = "Bottom" Text = "Report In Chart" />
                       --%>
                        </Titles>

                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                 <AxisX Title="Date" IsLabelAutoFit = "false" LabelAutoFitMaxFontSize="8" LabelAutoFitMinFontSize="7" LabelAutoFitStyle="None">
                            <LabelStyle Angle="90" Font="Verdana, 8pt" Interval="Auto" IsEndLabelVisible="False"/>
                                 <ScaleBreakStyle BreakLineStyle="None" /></AxisX>
                                    <AxisY Title="Value"></AxisY>


                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>


                    </td>
                    
                </tr>
            </table>
        </fieldset>
    </fieldset>
    <fieldset class="scheduler-border">
        <legend class="scheduler-borderBold">Service</legend>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Purchase</legend>
            <table class="MainTable">
                <tr class="HeaderRow">
                    <td class="HeaderTD">
                        VAT <a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServicePurchaseVATCount"></asp:Label>) </a>
                    </td>
                    <td class="HeaderTD">
                        SD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServicePurchaseSDCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        CD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServicePurchaseCDCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        RD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServicePurchaseRDCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        VDS<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServicePurchaseVASCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        Total Price<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServicePurchaseTotalCount"></asp:Label>)</a>
                    </td>
                </tr>
                <tr class="HeaderRow">
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServicePurchaseVAT">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServicePurchaseSD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServicePurchaseCD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServicePurchaseRD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServicePurchaseVAS">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServicePurchaseTotal">0</asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Sales</legend>
            <table class="MainTable">
                <tr class="HeaderRow">
                    <td class="HeaderTD">
                        VAT<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServiceSalesVATCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        SD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServiceSalesSDCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        CD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="Label1">0</asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        RD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="Label2">0</asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        VDS<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="Label3">0</asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        Total Price<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblServiceSalesTotalCount"></asp:Label>)</a>
                    </td>
                </tr>
                <tr class="HeaderRow">
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServiceSalesVAT">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServiceSalesSD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServiceSalesCD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServiceSalesRD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServiceSalesVAS">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblServiceSalesTotal">0</asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </fieldset>
    <fieldset class="scheduler-border">
        <legend class="scheduler-borderBold">Goods</legend>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Purchase</legend>
            <table class="MainTable">
                <tr class="HeaderRow">
                    <td class="HeaderTD">
                        VAT<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsPurchaseVATCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        SD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsPurchaseSDCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        CD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsPurchaseCDCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        RD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsPurchaseRDCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        VDS<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsPurchaseVASCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        Total Price<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsPurchaseTotalCount"></asp:Label>)</a>
                    </td>
                </tr>
                <tr class="HeaderRow">
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsPurchaseVAT">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsPurchaseSD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsPurchaseCD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsPurchaseRD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsPurchaseVAS">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsPurchaseTotal">0</asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Sales</legend>
            <table class="MainTable">
                <tr class="HeaderRow">
                    <td class="HeaderTD">
                        VAT<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsSalesVATCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        SD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsSalesSDCount"></asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        CD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="Label4">0</asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        RD<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="Label5">0</asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        VDS<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="Label6">0</asp:Label>)</a>
                    </td>
                    <td class="HeaderTD">
                        Total Price<a href="Admin_Dashboard_Detal.aspx" target="_blank">(<asp:Label runat="server"
                            CssClass="color_code" ID="lblGoodsSalesTotalCount"></asp:Label>)</a>
                    </td>
                </tr>
                <tr class="HeaderRow">
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsSalesVAT">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsSalesSD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsSalesCD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsSalesRD">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsSalesVAS">0</asp:Label>
                    </td>
                    <td class="DataTD">
                        <asp:Label runat="server" ID="lblGoodsSalesTotal">0</asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </fieldset>
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
               Edited on 24.05.2021
            </div>
</asp:Content>

