<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Dashboard.Master" inherits="Admin_Dashboard, App_Web_1kre2rwf" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="color: #7c795d; font-family: 'Trocchi', serif; font-size: 30px; font-weight: normal;
        line-height: 48px; margin: 0;">
        Dashboard
    </h1>
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
    
    <fieldset class="scheduler-border">
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

    <fieldset class="scheduler-border">
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
</asp:Content>
