<%@ page language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="CategoryWisePreodicReport, App_Web_pj2ymx2u" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/panel.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <style media="print">
        {
        }

        .noPrint {
            display: none;
        }

        @media print {
            table {
                width: 100%;
            }

            tr, td {
            }

            .full_width {
                width: 100%;
            }
        }

        .yesPrint {
            display: block !important;
        }

        input[type=text], select, textarea, .text_box {
            border: none;
        }
    </style>
    <script type="text/javascript">
        function PrintPanel(a) {
            var panel = null;
            var panelS = null; //sabbir 19/5/20
            if(a == 1){
                panel = document.getElementById("<%=pnlContents.ClientID %>");
                panelS = document.getElementById("<%=searchReport.ClientID %>"); //sabbir 19/5/20
            }
            else
            {
                panel = document.getElementById("<%=pnlCategory.ClientID %>");
            }
            
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write(panelS.innerHTML); //sabbir 19/5/20
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
     <script type="text/javascript">
         function FormatIt(obj) {


             if (obj.value.length == 2) // Day
                 obj.value = obj.value + "/";
             if (obj.value.length == 5) // month
                 obj.value = obj.value + "/";
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Category Wise Purchase Periodic Report
                </div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top:1%">
                        <div class="col-md-2">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">From Date :</label>
                                <div class="col-sm-7">
                                   <asp:TextBox runat="server" ID="dtpFromDate" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpFromDate"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">To Date :</label>
                                <div class="col-sm-7">
                                   <asp:TextBox runat="server" ID="dtpToDate" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpToDate"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label text-right">Item Category :</label>
                                <div class="col-sm-7">
                                   <asp:DropDownList runat="server" ID="ddlItemCategory" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged"></asp:DropDownList>


                                </div>
                            </div>
                        </div>
                           <%--added zahid 18 july 2022--%>

                          <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                      <label class="col-sm-5 control-label text-right"> Purchase Type</label>
                                        <div class="col-sm-7">

                                         <asp:DropDownList ID="drpType" CssClass="form-control" runat="server">
                                              <asp:ListItem value="A" >All</asp:ListItem>
                                                <asp:ListItem value="L">Local Purchase</asp:ListItem>
                                                <asp:ListItem  value="I">Import</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                         <div class="col-md-2">
                              <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px;float: left"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-sm" Style="float: left" Text="Search" OnClick="showBTN_Click" />
                            <asp:Button ID="btnPrintSigCtg" CssClass="btn btn-default btn-sm"  Style="float: left" runat="server" Text="Print" OnClientClick="return PrintPanel(1);"/>
                            <asp:Button ID="btnPrintAllCtg" CssClass="btn btn-default btn-sm"  Style="float: left" runat="server" Text="Print" OnClientClick="return PrintPanel(2);"/>
                        </div>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="precisionTxtBox" runat="server"
                ErrorMessage="Precision has to be a number between 0 to 12"
                ForeColor="Red"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator> 
                    </div>
                    
                    <div class="row" style="margin-top:1%;font-family:Nikosh;font-size:12px">
                        <asp:Panel ID="pnlContents" runat="server">
                            <table border="1" class="table" style="width: 100%;border-collapse:collapse">
                                <tr>
                                    <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc" class="style4">
                                         <asp:Label runat="server" ID="lblHHH" Text="Category Wise Purchase Periodic Report" style="font-weight:bold"> </asp:Label> 
                                    </th>
                                </tr>


                                <tr>
                                    <asp:Label runat="server" ID="lblHeaderShow" Visible="false"></asp:Label>
                                </tr>
                            </table>
                             <asp:GridView ID="gvInvoice" runat="server" AutoGenerateColumns="false" DataKeyNames="contails_challan_no,subject"
                                    OnRowCommand="gvInvoice_RowCommand" OnSelectedIndexChanged="gvInvoice_SelectedIndexChanged" Width="100%" >
                                    <Columns>
                                        <asp:BoundField HeaderText="Date of Bill Generation" DataField="Date" />
                                        <asp:BoundField HeaderText="Subject" DataField="subject" />
                                        <asp:TemplateField HeaderText="Contails Challan No.">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbVoucharNo" runat="server" CommandArgument='<%# Eval("contails_challan_no") %>' OnClick="lbVoucharNo_Click"><%# Eval("contails_challan_no") %></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Amount" DataField="Amount" />
                                        <asp:BoundField HeaderText="Bills Received" DataField="BillsReceived" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="BurlyWood" Font-Bold="true" />
                                </asp:GridView>
                        </asp:Panel>
                        <asp:Panel ID="pnlCategory" runat="server">
                            <table border="1" class="table" style="width: 100%;border-collapse:collapse">
                                <tr>
                                    <th colspan="10" scope="colgroup" style="text-align: center; background-color: #cccccc" class="style4">
                                         <asp:Label runat="server" ID="Label1" Text="Category Wise Purchase Periodic Report (ALL)" style="font-weight:bold"> </asp:Label> 
                                    </th>
                                </tr>


                                <tr>
                                    <asp:Label runat="server" ID="Label4" Visible="false"></asp:Label>
                                </tr>
                            </table>
                            <asp:GridView runat="server" ID="gvCategoryAll" AutoGenerateColumns="false" Width="100%" DataKeyNames="ChallanNo,Subject,Contails" 
                                OnDataBinding="gvCategoryAll_DataBinding" OnRowDeleting="gvCategoryAll_RowDeleting" OnRowCommand="gvCategoryAll_RowCommand"
                                OnSelectedIndexChanged="gvCategoryAll_SelectedIndexChanged">
                                <Columns>
                                   <%-- <asp:CommandField ButtonType ="Image" ShowSelectButton="true" SelectImageUrl="~/Images/detail.png" />
                                    <asp:BoundField HeaderText="Category" DataField="Category" />--%>
                                    <asp:BoundField HeaderText="Date of Bill Generation" DataField="BillDate" />
                                    <asp:BoundField HeaderText="Subject" DataField="Subject" />
                                    <asp:TemplateField HeaderText="Contails Challan No.">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbVoucharNo" runat="server" CommandArgument='<%# Eval("Contails") %>' OnClick="lbVoucharNo_Click"><%# Eval("Contails") %></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="Contails Challan No." DataField="Contails" />--%>
                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:f2}" />
                                    <asp:BoundField HeaderText="Bills Received" DataField="BillsReceived" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <asp:Panel ID="pnlCategoryDetails" runat="server" style="margin-top:1%">
                            <table border="1" class="table" style="width: 100%;border-collapse:collapse">
                                <tr>
                                    <td colspan="9" align="center" style="background: lightgrey;font-weight:bold">
                                        <asp:Label runat="server" ID="lblChallanNo" />
                                    </td>
                                </tr>
                                <tr style="background-color: White">
                                    <td class="style10" align="center" style="width: 20%; border-style: solid; border-width: 1px">
                                        <strong>Item Name</strong>
                                    </td>
                                    <td class="style10" align="center" style="width: 5%; border-style: solid; border-width: 1px">
                                        <strong>Unit</strong>
                                    </td>
                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Quantity</strong>
                                    </td>
                                    <td class="style10" align="center" style="width: 15%; border-style: solid; border-width: 1px">
                                        <strong>Prev. Unit Price</strong>
                                    </td>
                                    <td class="style10" align="center" style="width: 15%; border-style: solid; border-width: 1px">
                                        <strong>Curr. Unit Price</strong>
                                    </td>

                                    <td class="style10" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Discount</strong>
                                    </td>

                                    <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Tax</strong>
                                    </td>

                                    <td class="style11" align="center" style="width: 25%; border-style: solid; border-width: 1px">
                                        <strong>Total Amount</strong>
                                    </td>
                                     <td class="style11" align="center" style="width: 10%; border-style: solid; border-width: 1px">
                                        <strong>Difference in %</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <asp:Label runat="server" ID="Label5"></asp:Label>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="searchReport" runat="server" style="margin-top:1%">
                          <div class="col-md-12" id="report" runat="server">
                          <div class="form-group form-group-sm">
                                <div class="table-responsive">     
                                  <%--commented-  zahid 18 july 2022----%>
                                      <%--<table border="1" class="table" style="width: 100%; border-collapse: collapse;background-color:white" >
                                        <thead>
                                            <tr>
                                               <th  style="text-align:center;" >Date of Bill Generation</th>                                                
                                                <th  style="text-align:center;" >Subject</th>
                                                  <th  style="text-align:center;">Contails Challan No.</th>
                                                  <th  style="text-align:center;">Amount</th>
                                                <th  style="text-align:center;">Bills Received</th>
                                              
                                            </tr>
                                        </thead>
                                        <tbody>                                          
                                            <tr>
                                                <asp:Label runat="server" ID="lblReportHtml" />
                                            </tr>
                                        </tbody>
                                    </table>--%>


                                     <%--added zahid 18 july 2022--%>
                                    <table border="1" class="table" style="width: 100%; border-collapse: collapse; background-color: white">
                                        <thead>
                                            <tr>
                                                <th style="text-align: center;">Category</th>
                                                <th style="text-align: center;">Sub-Category</th>
                                                <th style="text-align: center;">Item Name</th>
                                                <th style="text-align: center;"> Challan/Bill Of Entry No.</th>
                                                <th style="text-align: center;">Date of Bill Generation</th>
                                                <th style="text-align: center;">Quantity</th>
                                                <th style="text-align: center;">Amount</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <asp:Label runat="server" ID="lblReportHtml" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                              </div>
                            </asp:Panel>
                    </div>
                    
                </div>

            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
</asp:Content>