<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="TreasuryChallan_6, App_Web_znns2ib5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<%--           <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
        <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
            <link rel="stylesheet" href="/resources/demos/style.css">
    <link href="../../Styles/panel.css" rel="stylesheet" />--%>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <%@ Register Src="~/UserControls/MsgBox.ascx" TagPrefix="uc1" TagName="MsgBox" %>

    <style type="text/css">
        .hiddencol {
            display: none;
        }
        .hiddent {
            display:normal;
        }

        .style1 {
            text-align: right;
        }

        .input_field {
            text-align: right;
        }

        .FixedHeader {
            position: fixed;
            MainContent_gvForTRchallan_txtTRchallanNO_0 font-weight: bold;
            text-align: center;
        }

        .grid_header {
            background-image: none;
            color: #000 !important;
            border: 1px solid #c9c9c9;
            font-family: arial,Helvetica,sans-serif;
            font-size: 15px;
            font-weight: 700;
            height: 20px;
            text-align: center;
        }

        .label {
            color: #000;
            font-size: 13px !important;
            font-family: arial,Helvetica,sans-serif;
        }
    </style>

    <%--For Print Only--%>
    <style media="print">
        .noPrint {
            display: none;
        }

        @media print {
            table {
                width: 100%;
            }

            tr, td {
                padding: 5px;
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

            table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;}
        table.allSolid td { border: 1.5px solid black;}
        }
    </style>
 <%--End For Print Only--%>
    <script type="text/javascript">
        $(function () {
          //  $("#txtFormDate").datepicker();
        });
        function addVatBreakdown(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAmount.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvPurchase2.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                //vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                vat += parseFloat((jsGvChallanItem.rows[rowIndex].cells[1].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                //vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                vat -= parseFloat((jsGvChallanItem.rows[rowIndex].cells[1].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=txtAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
            document.getElementById("<%=txtAmount.ClientID%>").style.background = "#cfc";


        }
         function addVatBreakdownAIT(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAmount.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gridAIT.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                //vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                vat += parseFloat((jsGvChallanItem.rows[rowIndex].cells[1].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                //vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                vat -= parseFloat((jsGvChallanItem.rows[rowIndex].cells[1].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=txtAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
            document.getElementById("<%=txtAmount.ClientID%>").style.background = "#cfc";


         }

        function addVatBreakdownSale(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAmount.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gridAIT.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                //vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                vat += parseFloat((jsGvChallanItem.rows[rowIndex].cells[1].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                //vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                vat -= parseFloat((jsGvChallanItem.rows[rowIndex].cells[1].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=txtAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
            document.getElementById("<%=txtAmount.ClientID%>").style.background = "#cfc";


        }
        function addVat(chkB) {
            //alert("Chudur Bhai");
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAmount.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvChallanItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                //vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
              
                vat += parseFloat((jsGvChallanItem.rows[rowIndex].cells[3].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                //vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                vat -= parseFloat((jsGvChallanItem.rows[rowIndex].cells[3].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }
            else {
                chkB.checked = false;
            }
            document.getElementById("<%=txtAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
            document.getElementById("<%=txtAmount.ClientID%>").style.background = "#cfc";


        }
        //mohi uddin
        function addVDS(chkvds) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAmount.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvChallanItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                vat += parseFloat((jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                vat -= parseFloat((jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString()).toLocaleString().replace(/,/g, ''));
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=txtAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
            document.getElementById("<%=txtAmount.ClientID%>").style.background = "#cfc";


        }

        function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvChallanItem.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked != IsChecked) {
                        items[i].click();
                    }
                }
            }

        }


        function clearChkBox(radioBtnNonChallan) {

            var isRadioBtnNonChallan = radioBtnNonChallan.checked;

            var jsGvItem = document.getElementById("<%=gvChallanItem.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked == isRadioBtnNonChallan) {
                        items[i].click();
                    }
                }
            }

        }

        function calledFn() {
            alert("code fired");
        }

    </script>

    <script type = "text/javascript">

        function PrintPanel() {
            var panel = document.getElementById("<%=printTRForm.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=1100,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            //            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('<style>table.allSolid { border: 1.5px solid black;font-size:smaller;} table.allSolid th { border: 1.5px solid black;} table.allSolid td { border: 1.5px solid black;}</style>');
            printWindow.document.write('</head>');
            //printWindow.document.write('<body>');
            printWindow.document.write('<body style="font-size:smaller;">');

            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
        function PrintAnnexure() {
            var panel = document.getElementById("<%=printAnnexure.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=1100,toolbar=0,scrollbars=1,status=0,dir=ltr');
            //printWindow.document.write('<html><head><title>আমদানি পর্যায়ে পরিশোধিত অগ্রীম কর ফেরত প্রাপ্তির আবেদন  (মূসক-৪.১)</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            //printWindow.document.write('</head>');
            printWindow.document.write('<body>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
        <div class="panel panel-primary">
           <div class="panel-heading" style="text-align:center; font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">Treasury Deposit (টি.আর. ফর্ম নং-৬)</div>
                <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
                   <div class="container-fluid" style="">
                      <div class="row" style="padding:0px">
                            <h4 style="border:1px solid blue; text-align:center;">চালান ফরম (টি.আর. ফর্ম নং-৬)</h4>
                          </div>
                        <div class="row">
                            <div class="col-sm-4">
                              <div class="form-group form-group-sm">
                               <asp:Label class="col-sm-4 control-label" ID="Label32" runat="server" style="text-align:right;"><span class="required"> * </span>Challan Date :</asp:Label>
                                <div class="col-sm-8">
                                  <asp:TextBox ID="dtpUnloadRealDate2"  CssClass="form-control" runat="server" Width="100%" Enabled="true" DateFormat="dd/MM/yyyy"/>
                                <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpUnloadRealDate2"/>
                                 </div>
                                </div>
                              </div>
                            <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="Label30" style="text-align:right;" runat="server"><span class="required"> * </span>Bank :</asp:Label>
                               <div class="col-sm-8">
                                <asp:DropDownList CssClass="form-control select2" ID="drpBankName" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="drpBankName_SelectedIndexChanged" style="Width:100%;">
                                </asp:DropDownList>
                                </div>
                              </div>
                          </div>
                            <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="Label3" style="text-align:right;" runat="server"><span class="required"> * </span>Branch :</asp:Label>
                                <div class="col-sm-8">       
                                     <asp:DropDownList CssClass="form-control select2" ID="drpBankBranch" runat="server" Width="100%">
                                </asp:DropDownList>
                             </div>
                         </div>
                        </div>
                             <div class="col-sm-4">
                                   <div class="form-group form-group-sm">
                                <asp:Label  class="col-sm-4 control-label" Visible="false" ID="Label9" runat="server" style="margin-left:78px;text-align:right;" Text="Challan No/ Scroll No :"></asp:Label>
                            <div class="col-sm-8">       
                                       <asp:TextBox Visible="false"  CssClass="form-control" ID="txtChallanNo" runat="server" Width="100%"></asp:TextBox>
                                  </div>
                              </div>
                                    </div>
                            
                             </div>
                             <div class="row">
                              
                            <div class="col-sm-4">
                                <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="Label37" runat="server" style="text-align:right"><span class="required"> * </span>Challan for :</asp:Label>
                                  <div class="col-sm-8">  
                                    <asp:DropDownList CssClass="form-control select2" ID="drpChallanType" runat="server" Width="100%" 
                                    onselectedindexchanged="drpChallanType_SelectedIndexChanged" 
                                    AutoPostBack="True"></asp:DropDownList>
                                   </div>
                              </div>
                        </div>
                          
                            <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="Label46" runat="server" style="text-align:right;"><span class="required"> * </span>A/C Code No :</asp:Label>
                                 <div class="col-sm-8">  
                                     <asp:TextBox CssClass="form-control" ID="txtCodeNo" runat="server" Width="100%" ></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtCodeNo" Mask="9 - 9999 - 9999 - 9999" runat="server" /> 
                            </div>
                              </div>
                                 </div>
                             <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                     <asp:Label class="col-sm-4 control-label" ID="Label2" style="text-align:right;" runat="server"><span class="required"> * </span>Behalf of :</asp:Label>
                               <div class="col-sm-8">                                    
                                <asp:DropDownList ID="drpOrgName" runat="server" AutoPostBack="True" CssClass="form-control" Width="100%"
                                    OnSelectedIndexChanged="drpOrgName_SelectedIndexChanged">
                                </asp:DropDownList> 
                                </div>                                      
                                <div class="col-sm-3 hidden"> 
                                       <asp:Button ID="btnNewOrg" CssClass="hidden" runat="server"  Width="40px" 
                                    OnClick="btnNewOrg_Click" Text="New"  />
                                <br />
                                <asp:TextBox ID="txtBehalfOf" runat="server" Width="100%" Visible="False"></asp:TextBox>
                            </div>
                                    
                                </div>
                                </div>
                        </div>
                      
                     <div class="row">
                          <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="Label1" runat="server" style="text-align:right;" Text="Bearer's Name &amp; Address:"></asp:Label>
                            <div class="col-sm-8">
                             <asp:TextBox CssClass="form-control" ID="txtBearerNameAddress" runat="server" style="Width:100%;resize: none;" Rows="2"  TextMode="MultiLine"></asp:TextBox>
                            </div>
                           </div>
                         </div>
                          
                            <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                     <asp:Label class="col-sm-4 control-label" ID="Label4" style="text-align:right;" runat="server" Text="Org. Address:"></asp:Label>
                                <div class="col-sm-8"> 
                                     <asp:TextBox  CssClass="form-control" ID="txtAddress1" runat="server" style="Width:100%; resize: none; " Rows="2" TextMode="MultiLine"></asp:TextBox>
                            </div>
                          </div>
                             </div>
                        <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="Label6" runat="server" style="text-align:right;" Text="Deposit Description:"></asp:Label>
                                <div class="col-sm-8">
                                      <asp:TextBox CssClass="form-control" ID="txtDepositDescription" style="Width:100%; resize: none;" Rows="2" TextMode=MultiLine runat="server"></asp:TextBox>
                                 </div>
                              </div>
                         </div>
                         
                       </div>
                          <div class="row">                            
                             <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="Label5" runat="server" style="text-align:right;" Text="Designation:"></asp:Label>
                                <div class="col-sm-8">
                                     <asp:TextBox CssClass="form-control" ID="txtDesignation" runat="server" Width="100%"></asp:TextBox>
                            </div>
                                </div>
                                </div>
                            <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                     <asp:Label class="col-sm-4 control-label" ID="Label7" style="text-align:right;" runat="server"><span class="required"> * </span>Instrument Type :</asp:Label>
                                <div class="col-sm-8">
                                      <asp:DropDownList CssClass="form-control select2" ID="drpInstrumentType" runat="server" Width="100%" AutoPostBack="True"
                                OnSelectedIndexChanged="drpInstrumentType_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                                </div>
                                </div>
                            <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="Label8" style="text-align:right;" runat="server"><span class="required"> * </span>Amount :</asp:Label>
                               <div class="col-sm-8">  
                                     <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" Width="100%" Text="0.00"  Enabled="true"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="txtAmount_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtAmount" ValidChars=".0123456789" />
                            </div>
                                </div>
                               </div>
                               </div>
                           <div class="row">
                            <div class="col-sm-4">
                                 <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-4 control-label" ID="lblInsDescription" runat="server" style="text-align:right;" Text=<abbr title="মুদ্রা ও নোটের বিবরন/ড্রাফট, প-অর্ডার ও চেকের বিবরণ">Description :</abbr> </asp:Label>
                                 <div class="col-sm-8">
                                     <asp:TextBox CssClass="form-control" ID="txtInstrumentDescription" runat="server" style="Width:100%;resize: none;" Rows="2" placeholder="মুদ্রা ও নোটের বিবরন/ড্রাফট, প-অর্ডার ও চেকের বিবরণ"
                                TextMode="MultiLine"></asp:TextBox>
                            </div>
                            </div>
                         </div>
                                <div class="col-sm-4">
                              <div class="form-group form-group-sm">
                               <asp:Label class="col-sm-4 control-label" ID="Label21" runat="server" style="text-align:right;"><span class="required"> * </span>Adjustment Tax Period:</asp:Label>
                                <div class="col-sm-8">
                                  <asp:DropDownList ID="drpsubmissionDate"  CssClass="form-control" runat="server" Width="100%"/>
                               
                                 </div>
                                </div>
                              </div>
                          </div>


                                   <div class="col-sm-12" style="padding:0px">
                              <asp:Label ID="Label36" runat="server" Text="Unit :" class="hiddencol"></asp:Label>
                             <asp:TextBox ID="txtUnit" runat="server" class="hiddencol"></asp:TextBox>
                              <div class="test-btn">
                                   <asp:Button runat="server" ID="btnTRInsert" CssClass="btn-btn" style="background-color:#4CAF50;float:right;" Text="Insert TR Challan" OnClick="btnTRInsert_Click"/>
                                  <%--<a href="../Others/Treasury_Deposit_show.aspx" class="btn btn-primary" style="background-color:#337AB7;float:right;margin-right: 35px;">Insert TR Challan</a>--%> 
                             </div>
                             <div class="test-btn">
                                <asp:Button ID="btnAddItem" runat="server" CssClass="btn-btn" OnClick="btnAddItem_Click" style="background-color:#B681B7;float:right;margin-right: 1px;"
                                    Text="Add Item" />
                             </div>
                             <div class="test-btn">
                                <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" style="background-color:#4CAF50;float:right;margin-right: 1px;"
                                    OnClick="btnRefresh_Click" Text="Refresh" />
                            </div>
                            <div class="test-btn">
                               <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" style="background-color:#4CAF50;float:right;margin-right: 1px;"
                                    OnClick="btnSave_Click" Text="Save" />
                             </div>
                             <div class="test-btn">
                                <asp:Button ID="btnShowItemList" runat="server" CssClass="btn-btn" Text="Show List" style="background-color:#5CB85C;float:right;margin-right: 1px;"
                                    OnClick="btnShowItemList_Click" />
                            </div>
                            <div class="test-btn">
                                <asp:Button ID="btnShowTRChallan" runat="server" CssClass="btn-btn" Text="Show TR Challan Form" style="background-color:#5CB85C;float:right;margin-right: 1px;" OnClick="btnShowTRChallan_Click" />
                            </div>
                        </div>
                         
                             
                 
                          <div class="col-sm-12" style="padding:0px">
                            <h4 style="border:1px solid blue; text-align:center;">Challan Selection</h4>
                          </div>
                        <div class="col-sm-12" style="padding:0px">
                         <div class="col-sm-12">
                                 <div class="col-sm-3">
                                <div class="form-group form-group-sm">
                                <asp:Label  class="col-sm-5 control-label" ID="Label10" runat="server" style="margin-left:0px" Text="Tax Type :"></asp:Label>
                               <div class="col-sm-7">
                                      <asp:DropDownList CssClass="form-control select2" ID="drpRdbSelection" runat="server" Width="150px" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="drpRdbSelection_SelectedIndexChanged">
                                    <asp:ListItem Value="1">VAT</asp:ListItem>
                                    <asp:ListItem Value="2">SD</asp:ListItem>
                                    <%--<asp:ListItem Value="3">AIT</asp:ListItem>--%>
                                   <asp:ListItem Value="4">Health care srucharge</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            </div>                         
                              </div>
                            <div class="col-sm-9">
                                <asp:RadioButton ID="radio_challan_list" Text="Sales Challan List" Checked="True" GroupName="vat_type" runat="server" OnCheckedChanged="radio_challan_list_CheckedChanged" AutoPostBack="true" />
                                <asp:RadioButton ID="radio_non_challan" Text="Non Sale Challan Issue " GroupName="vat_type" runat="server" OnCheckedChanged="radio_non_challan_CheckedChanged" AutoPostBack="true" onclick="clearChkBox(this)" />
                                <asp:RadioButton ID="radio_vat_9_1" Text="VDS" GroupName="vat_type" runat="server" OnCheckedChanged="radio_vat_9_1_CheckedChanged" AutoPostBack="true" onclick="clearChkBox(this)" />
                                <asp:RadioButton ID="radio_VAT_AIT" Text="AIT" GroupName="vat_type" runat="server" OnCheckedChanged="radio_VAT_AIT_CheckedChanged" AutoPostBack="true" onclick="clearChkBox(this)" />
                            </div>
                              </div>
                        </div>
                             <div  class="col-sm-12" >
                                     <div class="col-sm-3">
                                      <div class="form-group form-group-sm">
                                        <asp:Label ID="Label11" class="col-sm-5 control-label"  runat="server" style="margin-left:0px" Text="From Date:"></asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox CssClass="form-control" ID="txtFormDate" runat="server" Width="150px" Enabled="true" DateFormat="dd/MM/yyyy"/>
                                         <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFormDate"/>
                                   </div>
                                  </div>
                                </div>
                               <div class="col-sm-3">
                                  <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-5 control-label" ID="Label12" runat="server" style="margin-left:0px" Text="To Date:"></asp:Label>
                                  <div class="col-sm-7">
                                   <asp:TextBox CssClass="form-control" ID="txtToDate" runat="server" Width="150px" Enabled="true" DateFormat="dd/MM/yyyy"/>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate"/>
                             </div>
                            </div>
                              </div>
                                  <div class="col-sm-3">
                                  <div class="form-group form-group-sm">
                                <asp:Label class="col-sm-5 control-label" ID="Label22" runat="server" style="margin-left:0px" Text="Party Name:"></asp:Label>
                                  <div class="col-sm-7">
                                   <asp:DropDownList CssClass="form-control select2" ID="drpParty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpParty_SelectedIndexChanged"/>
                              
                             </div>
                            </div>
                              </div>
                                  <div class="col-sm-2">
                                 <%--<asp:Button runat=server  Text="Search" />--%>
                                <%--commented and updated below by sabbir 5/5/20--%>
                                 <asp:Button ID="searchByDateTax" CssClass="btn-btn" runat=server  Text="Search" style="background-color:#5CB85C;float:right;margin-right: 1px;" OnClick="btnSearch_Click" />
                               </div>
                       </div>
                                    
                            <div class="col-sm-12" runat="server" id="gvDiv" style="margin-top:5px;">
                               
                            <div style="overflow: auto; border: 0px solid green; width: 100%; height: 232px; margin-top:0px">
                                <asp:GridView ID="gvChallanItem" runat="server" AutoGenerateColumns="False" 
                                    HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="green" ShowHeaderWhenEmpty="true"
                                    OnRowDataBound="gvDistricts_RowDataBound" 
                                    onselectedindexchanged="gvChallanItem_SelectedIndexChanged" style="width: 100%;">
                                  <%--  <HeaderStyle CssClass="table table-border" />--%>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                            <HeaderTemplate >
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)" ToolTip="Check to Select All Item" /> 
                                            </HeaderTemplate>
                                            <ItemTemplate >
                                                <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this);" AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" />
                                                 <%--<asp:CheckBox ID="chkChallan" runat="server"  AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField ItemStyle-Width="20%" DataField="challan_no" />
                                        <asp:BoundField ItemStyle-Width="15%"  DataField="vat" />
                                        <asp:BoundField ItemStyle-Width="20%"  DataField="sale_price" />
                                        <asp:BoundField ItemStyle-Width="15%"  DataField="date_challan" />
                                        <asp:BoundField ItemStyle-Width="25%"  DataField="party_name" />--%>
                                       
                                        <asp:BoundField ItemStyle-Width="18%"  DataField="challan_no" HeaderText="Challan No" HeaderStyle-ForeColor="white"/>
                                        <asp:BoundField ItemStyle-Width="18%"  DataField="vat"  HeaderStyle-ForeColor="white"  DataFormatString="{0:n2}"/>
                                        <asp:BoundField ItemStyle-Width="20%"  DataField="sale_price" HeaderText="Sale Price" HeaderStyle-ForeColor="white" DataFormatString="{0:n2}"/>
                                        <asp:BoundField ItemStyle-Width="20%"  DataField="date_challan" HeaderText="Sale Date" HeaderStyle-ForeColor="white"/>
                                        <asp:BoundField ItemStyle-Width="20%"  DataField="party_name" HeaderText="Party Name" HeaderStyle-ForeColor="white"/>
                                        <asp:BoundField ItemStyle-Width="1%"  DataField="party_id" HeaderText="Party Id" HeaderStyle-ForeColor="white" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                                    <%-- <asp:BoundField ItemStyle-Width="1%"  DataField="scroll_id" HeaderText="" HeaderStyle-ForeColor="white" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>--%>
                                      <asp:BoundField DataField="challan_id" HeaderText="Challan No" HeaderStyle-ForeColor="White" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lbl_nonChallan" runat="server" Visible="false" Font-Size="18px">You Have Selected Non Challan Vat Type</asp:Label>
                            </div>
                            </div>
              <div id="pnLocalPurchase" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 80%; margin-left: 9%;">
                              <div class="row" style="text-align: center">
                                <asp:Label ID="Label16" runat="server" Style="font-size: 22px; font-weight: bold">Breakdown</asp:Label>
                             </div>
             <div class="row" style="margin-top: -4px; margin-right: 1%; margin-left: 1%;">
                    <asp:GridView ID="gvPurchase2" runat="server" AutoGenerateColumns="False"
                        CssClass="sGrid" Width="100%" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkChallan" runat="server" onclick="addVatBreakdown(this)" OnCheckedChanged="chkVDS_CheckedChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>                     
                            <asp:BoundField HeaderText="VDS/VAT Amount" DataField="proportion_vds" HeaderStyle-ForeColor="White" DataFormatString="{0:n2}" />
                            <asp:BoundField HeaderText="Amount" DataField="amount_for_vds" HeaderStyle-ForeColor="White" DataFormatString="{0:n2}"/>
                            <asp:BoundField DataField="challan_id" HeaderText="Challan No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                             <asp:BoundField DataField="challan_no" HeaderText="Challan No" HeaderStyle-ForeColor="White"/>
                             <asp:BoundField DataField="scroll_id" HeaderText="" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                             <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-ForeColor="White"/> 
                             <asp:BoundField DataField="index_id" HeaderText="" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                            <asp:BoundField   DataField="party_id" HeaderText="Party Id"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        </Columns>
                        <HeaderStyle Height="25px" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    </asp:GridView>
                </div>
             <div>
                <asp:Button ID="btnCatClear" runat="server" Text="Close" CssClass="test-btn-primary" Style="float: right" />
                </div>
             <asp:Button ID="btnHiddenForLocalPurchase" runat="server" Style="display: none" />
                               <cc1:ModalPopupExtender ID="modalPopupForLocalPurchase" runat="server" PopupControlID="pnLocalPurchase"
                TargetControlID="btnHiddenForLocalPurchase" BackgroundCssClass="mpBack">
            </cc1:ModalPopupExtender>
            </div>
        <div id="pnAIT" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 80%; margin-left: 9%;">
            <div class="row" style="margin-top: -4px; margin-right: 1%; margin-left: 1%;">
                    <asp:GridView ID="gridAIT" runat="server" AutoGenerateColumns="False"
                        CssClass="sGrid" Width="100%" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkChallan" runat="server" onclick="addVatBreakdownAIT(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>                         
                            <asp:BoundField HeaderText="AIT Amount" DataField="proportion_ait" HeaderStyle-ForeColor="White"  DataFormatString="{0:n2}"/>
                      
                            <asp:BoundField HeaderText="Amount" DataField="amount_for_vds" HeaderStyle-ForeColor="White"  DataFormatString="{0:n2}"/>
                             <asp:BoundField DataField="challan_id" HeaderText="Challan No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                             <asp:BoundField DataField="challan_no" HeaderText="Challan No" HeaderStyle-ForeColor="White"/>
                             <asp:BoundField DataField="scroll_id" HeaderText="" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                             <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-ForeColor="White"/>                          
                        </Columns>
                        <HeaderStyle Height="25px" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    </asp:GridView>
                </div>
             <div>
                <asp:Button ID="btnAIT" runat="server" Text="Close" CssClass="test-btn-primary" Style="float: right" />
                </div>
             <asp:Button ID="hiddenAIT" runat="server" Style="display: none" />
             <cc1:ModalPopupExtender ID="ModalPopupAIT" runat="server" PopupControlID="pnAIT"
                TargetControlID="hiddenAIT" BackgroundCssClass="mpBack">
            </cc1:ModalPopupExtender> 
 </div>
        <div id="pnSale" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 80%; margin-left: 9%;">
            <div class="row" style="margin-top: -4px; margin-right: 1%; margin-left: 1%;">
                    <asp:GridView ID="gridSale" runat="server" AutoGenerateColumns="False"
                        CssClass="sGrid" Width="100%" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkChallan" runat="server" onclick="addVatBreakdownSale(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="VDS/VAT Amount" DataField="proportion_vds" HeaderStyle-ForeColor="White"  DataFormatString="{0:n2}"/>
                           <%-- <asp:BoundField HeaderText="Bank" DataField="bank_amount" />--%>
                            <asp:BoundField HeaderText="Amount" DataField="amount_for_vds" HeaderStyle-ForeColor="White" DataFormatString="{0:n2}"/>
                            <asp:BoundField DataField="challan_id" HeaderText="Challan No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                             <asp:BoundField DataField="challan_no" HeaderText="Challan No" HeaderStyle-ForeColor="White"/>
                             <asp:BoundField DataField="scroll_id" HeaderText="" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                             <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-ForeColor="White"/>
                            </Columns>
                        <HeaderStyle Height="25px" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    </asp:GridView>
                </div>
             <div>
                <asp:Button ID="btnSale" runat="server" Text="Close" CssClass="test-btn-primary" Style="float: right" />
                </div>
             <asp:Button ID="hiddenSale" runat="server" Style="display: none" />
             <cc1:ModalPopupExtender ID="modalPopupForSale" runat="server" PopupControlID="pnSale"
                TargetControlID="hiddenSale" BackgroundCssClass="mpBack">
            </cc1:ModalPopupExtender> 
 </div>        
           
                   <div class="row">
                     <div class="col-sm-12">
                      <asp:GridView ID="dgvTreasuryDeposit" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                        DataKeyNames="orgName,orgAddress,orgId,challanTyped,branchId" Width="100%" 
                             ShowHeaderWhenEmpty="True" OnRowDataBound="dgvTreasuryDeposit_RowDataBound"
                        OnRowDeleting="dgvTreasuryDeposit_RowDeleting" 
                             OnSelectedIndexChanged="dgvTreasuryDeposit_SelectedIndexChanged" 
                             BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                             CellPadding="3" CellSpacing="2">
                        <Columns>
                             <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                                ShowSelectButton="True" />
                            <asp:BoundField HeaderText="C G Number" DataField="ChallanNo" HeaderStyle-ForeColor="white" />
                            <asp:BoundField HeaderText="Challan Date" DataField="StrDate" HeaderStyle-ForeColor="white" />
                            <asp:BoundField HeaderText="Bank" DataField="BankName" HeaderStyle-ForeColor="white">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Branch" DataField="BranchName" HeaderStyle-ForeColor="white" />
                            <asp:BoundField HeaderText="Account No" DataField="CodeNo" HeaderStyle-ForeColor="white">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Bearer Name &amp; Address" ItemStyle-Wrap="false" HeaderStyle-ForeColor="white"
                                DataField="BearerNameAddress">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Behalf Of" DataField="OrgName" HeaderStyle-ForeColor="white">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Designation" DataField="Designation" HeaderStyle-ForeColor="white">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Address" DataField="OrgAddress" HeaderStyle-ForeColor="white" />
                            <asp:BoundField HeaderText="Deposit Description" HeaderStyle-ForeColor="white"
                                DataField="DepositDescription" />
                            <asp:BoundField HeaderText="Instrument Type" DataField="InstrumentType" HeaderStyle-ForeColor="white" />
                            <asp:BoundField HeaderText="Instrument Description"
                                DataField="InstrumentDescription" HeaderStyle-ForeColor="white" />
                            <asp:BoundField HeaderText="Amount" DataField="Amount" HeaderStyle-ForeColor="white"  DataFormatString="{0:n2}"/>
                            <asp:BoundField HeaderText="Unit" DataField="unit" Visible="False" HeaderStyle-ForeColor="white" />
                            <asp:BoundField DataField="ChallanType" HeaderText="Challan Type" HeaderStyle-ForeColor="white" />
                            <%--<asp:BoundField DataField="Challan_numbers" HeaderText="Challlan Numbers" />--%>

                           
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" 
                              ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" 
                              BackColor="#FFF7E7" ForeColor="#8C4510" />

                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#FFF1D4" />
                          <SortedAscendingHeaderStyle BackColor="#B95C30" />
                          <SortedDescendingCellStyle BackColor="#F1E5CE" />
                          <SortedDescendingHeaderStyle BackColor="#93451F" />

                            </asp:GridView>
                          </div>
                       <%--<div class="col-sm-6">
                          <div CssClass="yesPrint" ID="pnGvArea" runat="server" Visible="true">
                            <center>
                            <asp:Label style="font-size:15px;" ID="lblHeader" runat="server" Text="চালান ফরম"></asp:Label><br />
                            <asp:Label style="font-size:15px;" ID="lblFrom" runat="server" Text="টি, আর ফরম নং ৬ (এস, আর ৩৭ দ্রষ্টব্য)"></asp:Label><br />
                            <asp:Label style="font-size:15px;" ID="lblChallanNo" runat="server" Text="চালান নং.......................... তারিখ.......................... "></asp:Label><br />
                            <asp:Label style="font-size:15px;" ID="lblDepositChallan" runat="server" Text="বাংলাদেশ ব্যাংক/সোনালী ব্যাংকের..........ঢাকা.........জেলার......মতিঝিল......শাখায় টাকা জমা দেওয়ার  চালান ।" ></asp:Label><br /> 
                             </center>
                             <table class="tablefull">
                               <tr>
                                <td class="auto-style1">কোড নং
                                </td>
                                <td colspan="5" class="auto-style1">
                                    <div class="div_box">
                                        <asp:Label ID="code1" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="div_space">&nbsp;&nbsp;-&nbsp;&nbsp;</div>
                                    <div class="div_box">
                                        <asp:Label ID="code2" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="div_box">
                                        <asp:Label ID="code3" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="div_box">
                                        <asp:Label ID="code4" runat="server" Text=""></asp:Label></div>
                                    <div class="div_box">
                                        <asp:Label ID="code5" runat="server" Text=""></asp:Label></div>
                                    <div class="div_space">&nbsp;&nbsp;-&nbsp;&nbsp;</div>
                                    <div class="div_box">
                                        <asp:Label ID="code6" runat="server" Text=""></asp:Label></div>
                                    <div class="div_box">
                                        <asp:Label ID="code7" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="div_box">
                                        <asp:Label ID="code8" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="div_box">
                                        <asp:Label ID="code9" runat="server" Text=""></asp:Label></div>
                                    <div class="div_space">&nbsp;&nbsp;-&nbsp;&nbsp;</div>
                                    <div class="div_box">
                                        <asp:Label ID="code10" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="div_box">
                                        <asp:Label ID="code11" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="div_box">
                                        <asp:Label ID="code12" runat="server" Text=""></asp:Label></div>
                                    <div class="div_box">
                                        <asp:Label ID="code13" runat="server" Text=""></asp:Label></div>
                                 </td>
                               </tr>
                            </table>
                            <table class="table_report">
                                <thead>
                                    <tr>
                                        <th colspan="4">জমা প্রদানকারী কর্তৃক পূরণ করিতে হইবে </th>
                        
                                        <th colspan="2">টাকার অংক</th>
                        
                                        <th rowspan="2">বিভাগের নাম এবং চালানের পৃষ্ঠাংকনকারী কর্মকর্তার নাম, পদবী ও দপ্তর </th>
                                    </tr>
                                    <tr>
                                        <th>যাহার মারফত প্রদত্ত হইল তাহার নাম ও ঠিকানা।</th>
                                        <th>যে ব্যত্তির/প্রতিষ্ঠানের পক্ষ হইতে টাকা প্রদত্ত হইল তাহার নাম, পদবী ও ঠিকানা।</th>
                                        <th>কি বাবদ জমা দেওয়া হইল তাহার বিবরণ</th>
                                        <th>মুদ্রা ও নোটের বিবরণ/ ড্রাফ্‌ট, পে-অডার ও চেকের বিবরণ</th>
                                        <th>টাকা</th>
                                        <th>পয়সা</th>
                        
                                    </tr>
                                </thead>
                                    <tbody>
                                        <asp:Literal ID="ltTRReportBody" runat="server"></asp:Literal>
                                        <tr>
                                            <td colspan="4" style="border-right:1px solid #fff;">তারিখ ........................</td>
                                            <td colspan="3"><center>ম্যানেজার<br />বাংলাদেশ ব্যাংক/সোনালী ব্যাংক </center></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNote" runat="server" Text="নোট :"></asp:Label></td>

                                        <td>
                                            <asp:Label ID="lblOne" runat="server" Text="১ । সংশ্লিষ্ট দপ্তরের সহিত যোগাযোগ করিয়া সঠিক কোড নম্বর জানিয়া লইবেন ।" ></asp:Label>
                                        </td>


                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="lblTwo" runat="server" Text="২ ।* যে সকল ক্ষেত্রে কর্মকর্তা কর্তৃক পৃষ্টাংকন প্রয়োজন,সে সকল  ক্ষেত্রে প্রযোজ্য হইবে । "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label10" runat="server"  Text="বাঃসঃমুঃ -২০০৮/০৯-৪৮৬৬ কম (ডি)-১০০ বই , ২০০৯ ।"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <center>
                                    <a href="#" onclick="window.print();  return false;"  data-toggle="tooltip" title="Print Page" class="btn btn-danger noPrint">
                                    <i class="fa fa-print"></i> Print</a>
                                </center>
                            </div>
                        <uc2:MsgBox ID="msgBox" runat="server" />
                       </div>--%>
                   </div>
                   <div class="row">
                       <div style="font-weight: bold;">Annexure</div>
                   </div>
                   <div class="row">
                    <div class="col-sm-1"></div>
                      <div class="col-sm-10">
                       <div runat="server" id="printTRForm" visible="false">
                        <div>
                         <center>
                            <%--<asp:Label style="font-size:15px;" ID="Label13" runat="server" Text="চালান ফরম"></asp:Label><br />
                            <asp:Label style="font-size:15px;" ID="Label14" runat="server" Text="টি, আর ফরম নং ৬ (এস, আর ৩৭ দ্রষ্টব্য)"></asp:Label><br />
                            <asp:Label style="font-size:15px;" ID="Label15" runat="server" Text="চালান নং:"></asp:Label><span id="trch" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span>&nbsp&nbsp
                             <asp:Label style="font-size:15px;" ID="Label17" runat="server" Text="তারিখ: "></asp:Label><span id="trdate" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span><br />
                            <asp:Label style="font-size:15px;" ID="Label18" runat="server" Text="বাংলাদেশ ব্যাংক/সোনালী ব্যাংকের...................জেলার:" ></asp:Label><span id="trbranch" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span> 
                             <asp:Label style="font-size:15px;" ID="Label19" runat="server" Text="শাখায় টাকা জমা দেওয়ার  চালান" ></asp:Label><br />--%>


                             <asp:Label ID="Label13" runat="server" Text="চালান ফরম"></asp:Label><br />
                            <asp:Label ID="Label14" runat="server" Text="টি, আর ফরম নং ৬ (এস, আর ৩৭ দ্রষ্টব্য)"></asp:Label><br />
                            <asp:Label ID="Label15" runat="server" Text="চালান নং:"></asp:Label><span id="trch" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="Label17" runat="server" Text="তারিখ: "></asp:Label><span id="trdate" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span><br />
                            <asp:Label ID="Label18" runat="server" Text="বাংলাদেশ ব্যাংক/সোনালী ব্যাংকের " ></asp:Label>
                            <span id="trBranchDistrict" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span> 
                             <asp:Label ID="Label19" runat="server" Text=" জেলার:" ></asp:Label>
                            <span id="trbranch" runat="server" style="border-bottom: 1px dotted black; width: 200px;"></span> 
                            <asp:Label ID="Label20" runat="server" Text="শাখায় টাকা জমা দেওয়ার  চালান" ></asp:Label><br /> 

                          </center>
                         </div>
                         <div>
                          <p style="margin-left:0px;font-size:12px;">
                            কোড নং 
                            <asp:TextBox runat="server" ID="TextBox0" style="width:22px; height:20px;margin-left:10px"/>

                            <asp:TextBox runat="server" ID="TextBox1" style="width:22px; height:20px;margin-left:10px"/>
                            <asp:TextBox runat="server" ID="TextBox2" style="width:22px; height:20px;margin-left:-4px"/>
                            <asp:TextBox runat="server" ID="TextBox3" style="width:22px; height:20px;margin-left:-4px"/>
                            <asp:TextBox runat="server" ID="TextBox4" style="width:22px; height:20px;margin-left:-4px"/>

                            <asp:TextBox runat="server" ID="TextBox5" style="width:22px; height:20px;margin-left:10px"/>
                            <asp:TextBox runat="server" ID="TextBox6" style="width:22px; height:20px;margin-left:-4px"/>
                            <asp:TextBox runat="server" ID="TextBox7" style="width:22px; height:20px;margin-left:-4px"/>
                            <asp:TextBox runat="server" ID="TextBox8" style="width:22px; height:20px;margin-left:-4px"/>

                            <asp:TextBox runat="server" ID="TextBox9" style="width:22px; height:20px;margin-left:10px"/>
                            <asp:TextBox runat="server" ID="TextBox10" style="width:22px; height:20px;margin-left:-4px"/>
                            <asp:TextBox runat="server" ID="TextBox11" style="width:22px; height:20px;margin-left:-4px"/>
                            <asp:TextBox runat="server" ID="TextBox12" style="width:22px; height:20px;margin-left:-4px"/>
                          </p>
                        </div>
                        <div>
                          <%--<table border="1" class="table" style="background:none; border-collapse:collapse; width:100%">--%>
                            <table border="1" class="allSolid" style="background:none; border-collapse:collapse; width:100%;font-size:12px;">
                            <tr>
                                <th colspan="4" style="text-align:center">জমা প্রদানকারী কর্তৃক পূরণ করিতে হইবে</th>
                                <th colspan="2" style="text-align:center">টাকার অংক</th>
                                <th rowspan="2" style="text-align:center">বিভাগের নাম এবং চালানের পৃষ্ঠাংকনকারী কর্মকর্তার নাম, পদবী ও দপ্তর।*</th>
                            </tr>
                            <tr>
                               <th style="width:20%;text-align:center">যাহার মারফত প্রদত্ত হইল তাহার নাম ও ঠিকানা।</th>
                               <th style="width:20%;text-align:center">যে ব্যক্তির/প্রতিষ্ঠানের পক্ষ হইতে টাকা প্রদত্ত হইল তাহার নাম, পদবী ও ঠিকানা।</th>
                               <th style="width:15%;text-align:center">কি বাবদ জমা দেওয়া হইল তাহার বিবরণ</th>
                               <th style="width:15%;text-align:center">মুদ্রা ও নোটের বিবরণ/ ড্রাফ্‌ট, পে-অডার ও চেকের বিবরণ</th>
                               <th style="width:10%;text-align:center">টাকা</th>
                               <th style="width:5%;text-align:center">পয়সা</th>
                            </tr>
                            <tr>
                              <asp:Label runat="server" ID="lblTRForm" />
                            </tr>
                            <tr>
                              <td></td>
                              <td></td>
                              <td></td>
                              <td  style="text-align:right; padding-right:4px;font-weight: bold;">মোট টাকা</td>
                              <td style="text-align:right;"><asp:Label runat="server" ID="lblTotalTK" /></td>
                              <td style="text-align:right;"><asp:Label runat="server" ID="lblTotalPaisa" /></td>
                              <td></td>
                            </tr>
                            <tr>
                              <td colspan="4">টাকা (কথায়):  <asp:Label runat="server" ID="lblAmountInWord" /></td>
                              <td></td>
                              <td></td>
                              <td></td>
                            </tr>
                            <tr>
                              <td colspan="4">টাকা পাওয়া গেল</td>
                              <td></td>
                              <td></td>
                              <td></td>
                            </tr>
                            <tr>
                              <td colspan="4">তারিখ: &nbsp <asp:Label runat="server" ID="lblDate2" /></td>
                              <td colspan="3"><center>ম্যানেজার<br />বাংলাদেশ ব্যাংক/সোনালী ব্যাংক </center></td>
                            </tr>
                          </table>
                            <br />
                          <p style="margin-left:0px;font-size:12px;">নোট :   ১ । সংশ্লিষ্ট দপ্তরের সহিত যোগাযোগ করিয়া সঠিক কোড নম্বর জানিয়া লইবেন ।</p>
                          <p style="margin-left:35px;font-size:12px;">২ ।* যে সকল ক্ষেত্রে কর্মকর্তা কর্তৃক পৃষ্টাংকন প্রয়োজন,সে সকল  ক্ষেত্রে প্রযোজ্য হইবে ।</p>
                          <p style="margin-left:0px;font-size:12px;">বাঃসঃমুঃ -২০০৮/০৯-৪৮৬৬ কম (ডি)-১০০ বই , ২০০৯ ।</p>
                        </div>
                       <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
                        </div>
                           <center> <asp:Button runat="server" style="float:right;" CssClass="btn btn-info" Text="Print" ID="btnPrint" Visible= "false" OnClientClick="return PrintPanel()" /></center>
                      </div>
                    <div class="col-sm-1"></div>
               
                       <uc1:MsgBox runat="server" id="msgBox" />
                   </div>
                   <div class="row">
                       <div class="col-sm-1"></div>
                       <div class="col-sm-10">
                           <div runat="server" id="printAnnexure" visible="false">
                               <asp:GridView ID="grdAnnexere" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="green" ShowHeaderWhenEmpty="true"
                                             style="width: 100%;" ShowFooter="true">
                                   <Columns>
                                       <asp:BoundField DataField="party_name" HeaderText="Party Name" HeaderStyle-ForeColor="white"/>
                                       <asp:BoundField DataField="challan_no" HeaderText="Challan No" HeaderStyle-ForeColor="white"/>
                                       <asp:BoundField DataField="tr_amount" HeaderText="VAT/SD" HeaderStyle-ForeColor="white" DataFormatString="{0:n2}"/>
                                   </Columns>
                               </asp:GridView>
                           </div>
                           <center> <asp:Button runat="server" style="float:right;" CssClass="btn btn-info" Text="Print Annexere" ID="btnPrintAnnexere" Visible= "false" OnClientClick="return PrintAnnexure()" /></center>
                       </div>
                       <div class="col-sm-1"></div>
                   </div>
                </div>
            </div>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>

    <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 06.06.2021
            </div>    

</asp:Content>

