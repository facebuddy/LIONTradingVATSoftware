<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="SaleSummaryMonthwises.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.SaleSummaryMonthwises" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
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
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/panel.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                     
                        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 25px; padding-top: 0px">Sale Summary Report</div>

                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <asp:Label CssClass="control-label col-sm-5 text-right" runat="server" Text="Year :"></asp:Label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpChallanYear" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="Label2" CssClass="control-label col-sm-5 text-right" runat="server" Text="Month :"></asp:Label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpMonth" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                  <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <asp:Label ID="Label6" CssClass="control-label col-sm-5 text-right" runat="server" Text="Item :"></asp:Label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpItem" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 
                                 </div>
                         <div class="row">

                              <div class="col-md-12" style="text-align:right">
                                        <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox> 
                                     <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success" OnClick="showReport_OnClick"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                                      <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                                    </div>
                         </div>

                        </div>
                        </div>
                     <div class="panel panel-primary" style="font-family:Nikosh">
                        <div class="panel panel-body">
                            <div class="col-md-12">
                                <div runat="server" id="print">
                               <div class="row" style="margin-top:1%;font-family:Nikosh;font-size:12px">
                           <asp:Panel ID="pnlContents" runat="server">
                            <div class="row" style="font-size:15px">
                                        
                                        <p style="text-align: center">
                                           <asp:Label Style="font-weight: bold;font-size:25px;" runat="server" ID="TaxOrganizationName" />
                                        </p>
                                        <p style="text-align:center">
                                            <asp:Label  runat="server" ID="TaxOrganizationAddress" />
                                        </p>
                                        <p style="text-align:center">
                                            <asp:Label  runat="server" ID="TaxOrganizationBIN" />
                                        </p>
                                       
                                        <p style="text-align: center">
                                            <asp:Label runat="server" ID="lblHeading" style="font-weight:bold;font-size:20px;"></asp:Label>
                                        </p>
                                        <p style="text-align:center"><asp:Label  runat="server" ID="lblDate" />  </p>
                                    </div>
                    <table border="1" class="table" style="width: 100%; border-collapse:collapse">
                       
                       
                        
                        <tr>
                            <asp:Label runat="server" ID="lblHeaderShow" Visible= "false"></asp:Label></tr>
                    </table>
                    <table border="1" class="table" style="width: 100%;border-collapse:collapse">
                         <tr>
                            <td colspan="7" scope="colgroup" style="text-align: center; background-color: #cccccc"
                                 runat="server" id="lblYearSaleFrom">
                             
                            </td>
                           
                        </tr>
                        <tr style = "background-color: White">
                             <td class="style10" align="center" style="width: 10%;border-style:solid; border-width:1px" runat="server" id="item_nameS">
                                <strong>Item(HS Code)</strong>
                            </td>
                            <td class="style10" align="center" style="width: 10%;border-style:solid; border-width:1px">
                                <strong>Month</strong>
                            </td>

                            <td class="style10" align="center" style="width: 10%;border-style:solid; border-width:1px">
                                <strong>Sale Amount</strong>
                            </td>
                             <td class="style10" align="center" style="width: 10%;border-style:solid; border-width:1px">
                                <strong>VAT </strong>
                            </td>
                            <td class="style11" align="center" style="width: 10%;border-style:solid; border-width:1px">
                                <strong>SD</strong>
                            </td>
                             <td class="style11" align="center" style="width: 10%;border-style:solid; border-width:1px">
                                <strong>Total</strong>
                            </td>
                            <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                                        <strong>Action</strong>
                                                    </td>

                        </tr>
                        
                        <tr>
                            <asp:Label runat="server" ID="lblleisureShow"></asp:Label></tr>
                    </table>



                    </asp:Panel>
                    
 <div id="PopupContainer" runat="server">
                                        </div>
                               
          </div>  </div>  </div>  </div>
            </div>
       <%--     <uc2:MsgBox ID="msgBox" runat="server" />--%>
                    <uc1:MsgBoxs runat="server" ID="msgBox" />
        </div>
       
   
                            </ContentTemplate>
        </asp:UpdatePanel>
     
    </asp:Content>