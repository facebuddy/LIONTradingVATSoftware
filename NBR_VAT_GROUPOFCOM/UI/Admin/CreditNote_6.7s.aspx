
<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="CreditNote_6.7s.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.CreditNote_6__7s" %>
<%--<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
  <%--  <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
     <script src="../../Scripts/jquery-1.4.4.min.js"></script>--%>
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
        .hiddencol {
            display: none;
        }
       
    </style>
    <style>
    .print
    {
        background:#ff00ff;
    }
    </style>
    <style media="print">
        .noPrint
        {
            display: none;
        }
        @media print
        {
            body
            {
                
            }
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
            border: 1px solid gray;
        }
    </style>
     
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
//            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head>');
            printWindow.document.write('<body style="margin: 50px;font-family: "Times New Roman", Times, serif; font-size:16px">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
        function SelectAllCheckboxesgvIngredience(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvAddtnProperty.ClientID%>");
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
    </script>
    <%--<script type="text/javascript">
        $(function () {
            $("#txtFormDate").datepicker();
        });

        function addVat(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAmount.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=txtAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
            document.getElementById("<%=txtAmount.ClientID%>").style.background = "#cfc";


        }

        function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvItem.ClientID%>");
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

            var jsGvItem = document.getElementById("<%=gvItem.ClientID%>");
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

//        function btnPrint_Click(Flag) {
//            if (Flag == "Print") {
//                var id = document.getElementById("cnPrint");
//                if (id.style.display == 'none') {
//                    document.getElementById("cnPrint").style.display = 'block';
//                } else {
//                    document.getElementById("cnPrint").style.display = 'none';
//                }
//            }
//        }

    </script>--%>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right:0%; padding-left:0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                  <div class="panel-group">
        <div class="panel panel-primary">
          <%-- <div class="panel-heading" style="text-align:center; font-size:21px; font-weight:bold; height:30px; padding-top:0px">ক্রেডিট নোট (মূসক-১২)</div>--%>
             <div class="panel-heading" style="text-align:center;font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">ক্রেডিট নোট (মূসক-৬.৭)</div>
            
            <div class="panel-body" style="padding-top:0px; padding-bottom:2px">
                 <div class="row" style="margin-top:0px">
                    <fieldset class="scheduler-border">
                        <legend class="scheduler-border">ফেরত গ্রহণকারী ব্যক্তির</legend>
                        <div class="col-sm-4" style="padding:0px">
                          <div class="col-sm-4" style="padding:0px">
                            <asp:Label ID="Label1" style="margin-left:100px" runat="server" Text="নাম:"></asp:Label>
                          </div>
                          <div class="col-sm-8" style="padding:0px">
                             <asp:Literal ID="lblOrgName" runat="server" Text="Bodrullah Khan"></asp:Literal>
                          </div>
                        </div>
                        <div class="col-sm-6" style="padding:0px">
                          <div class="col-sm-1" style="padding:0px">
                             <asp:Label runat="server" Text="ঠিকানা:"></asp:Label>
                          </div>
                          <div class="col-sm-11" style="padding:0px">
                             <asp:Literal ID="lblOrgAddress" runat="server" Text="Dhanmondi"></asp:Literal>
                          </div>
                        </div>
                        <div class="col-sm-2" style="padding:0px">
                          <div class="col-sm-5" style="padding:0px">
                            <asp:Label ID="Label8" style="margin-left:17px" runat="server" Text="বিআইএন:"></asp:Label>
                          </div>
                          <div class="col-sm-7" style="padding:0px">
                            <asp:Label ID="lblOrgBIN" style="margin-left: 0px;" runat="server" Text="123-123-123"></asp:Label>
                          </div>
                        </div>
                        <div class="col-sm-3 col-xs-3 col-lg-2">
                            <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                            <asp:Label ID="lblOrgAddress1" runat="server" Visible="False"></asp:Label>
                        </div>
                        </fieldset>
                    </div>
                       <div class="row" style="margin-top:0px">
                    <fieldset class="scheduler-border">
                        <legend class="scheduler-border"></legend>
                           <div class="col-sm-4" style="padding: 0px;padding-top:0.5%">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label17" CssClass="present-address-lbl" Style="margin-left: 22%" runat="server"
                                    Text="Branch Name:">
                                </asp:Label></div>
                            <div class="col-sm-5" style="padding: 0px">
                                <asp:DropDownList ID="drpBranchName" runat="server" Style="margin-left: 11px; height: 27px;text-align: left" OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged" AutoPostBack = "true"
                                     CssClass="present-address-tb">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px;padding-top:0.5%">
                            <div class="col-sm-3" style="padding: 0px">
                                <asp:Label ID="Label18" runat="server" Style="margin-left: -1%" CssClass="present-address-lbl"
                                    Text="Branch Address:"></asp:Label></div>
                            <div class="col-sm-9" style="padding: 0px">
                                <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px;padding-top:0.5%">
                            <div class="col-sm-3" style="padding: 0px; margin-left: 36px">
                                <asp:Label ID="Label19" Style="margin-left: 180%; margin-top: 4px" CssClass="present-address-lbl"
                                    runat="server" Text="BIN:"></asp:Label></div>
                            <div class="col-sm-3" style="padding: 0px; margin-left: 157px;">
                                <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                            </div>
                        </div>


                        </fieldset>
                        </div>



                    <div class="row" style="margin-top:0px;">
                      <fieldset class="scheduler-border">
                        <legend class="scheduler-border">ফেরত প্রদানকারী ব্যক্তির</legend>
                              <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">*</span>নাম:</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpParty" OnSelectedIndexChanged="drpParty_SelectedIndexChanged" AutoPostBack="true" class="present-address-tb select2"  runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                    <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">ঠিকানা:</label>
                                        <div class="col-sm-7">
                                           <asp:Literal ID="ltAddress" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                       <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">বিআইএন:</label>
                                        <div class="col-sm-7">
                                          <asp:Label ID="lblBIN" Style="margin-left: 0px;" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                   </div>
                                    
                                     <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Vehicle Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpVehicleType" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Vehicle No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtVehicleNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                           <asp:HiddenField runat="server" ID="ItemType" />
                                     </div>
                        <%--<div class="col-sm-4" style="padding:0px">
                          <div class="col-sm-4" style="padding:0px">
                            <asp:Label ID="Label3"  Style="margin-left: 100px" runat="server" Text=""><span class="required">*</span>নাম:</asp:Label>
                          </div>
                          <div class="col-sm-8" style="padding:0px">
                             <asp:DropDownList ID="drpParty" OnSelectedIndexChanged = "drpParty_SelectedIndexChanged" AutoPostBack="true" class="present-address-tb select2" style="width:58%;margin-left: 64px; height:27px;text-align:left" runat="server"></asp:DropDownList>
                          </div>
                        </div>
                        <div class="col-sm-6" style="padding:0px">
                          <div class="col-sm-1" style="padding:0px">
                             <asp:Label ID="Label4" runat="server" Text="ঠিকানা:"></asp:Label>
                          </div>
                          <div class="col-sm-11" style="padding:0px">
                             <asp:Literal ID="ltAddress" runat="server"></asp:Literal>
                          </div>
                        </div>
                        <div class="col-sm-2" style="padding:0px">
                          <div class="col-sm-5" style="padding:0px">
                            <asp:Label ID="Label5" style="margin-left:17px" runat="server" Text="বিআইএন:"></asp:Label>
                          </div>
                          <div class="col-sm-7" style="padding:0px">
                            <asp:Label ID="lblBIN" style="margin-left: 0px;" runat="server"></asp:Label>
                          </div>
                        </div>--%>
                        <div class="col-sm-3 col-xs-3 col-lg-2">
                            <asp:Label ID="Label7" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="DropDownList2" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                            <asp:Label ID="Label9" runat="server" Visible="False"></asp:Label>
                        </div>
                        </fieldset>
                    </div>
                    <div class="row" style="margin-top:20px">
                        <div class="col-sm-8" style="padding:0px">
                          <div class="col-sm-2" style="padding:0px">
                             <asp:Label ID="Label10" CssClass="present-address-lbl" style="margin-left:36px" runat="server" Text=""><span class="required">*</span>ক্রেডিট নোট নম্বর:</asp:Label>
                              <asp:Label ID="creditNoteId" runat="server" Visible = "false" />
                           </div>
                           <div class="col-sm-3" style="padding:0px">
                             <asp:TextBox ID="txtCraditNot" class="present-address-tb" runat="server" style="width:94%; height:27px" Enabled="false" ></asp:TextBox>
                             <asp:HiddenField ID="hdBookId" runat="server" />
                             <asp:HiddenField ID="hdPageNo" runat="server" />
                             <asp:HiddenField ID="HiddenFieldAkokMullo" runat="server" />
                           </div>
                           <div class="col-sm-2 hiddencol" style="padding:0px">
                             <asp:CheckBox ID="chkDiscard" style="float:left;" runat="server" OnCheckedChanged="chkDiscard_CheckedChanged" Text="Discard" AutoPostBack="true" />
                           </div>
                            <div class="col-sm-5" style="padding:0px">
                             <asp:Label ID="lblDiscardReason" style="float:left; margin-left:0px;margin-top:3px" CssClass="present-address-lbl" runat="server" Text="Discard Reason:" Visible="false"></asp:Label>
                             <asp:DropDownList ID="drpDiscardReason" CssClass="present-address-tb" runat="server" style="width:150px; height:27px;margin-left:100px" Visible="false"></asp:DropDownList>
                            </div>
                        </div>
                         <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="Label11" CssClass="present-address-lbl" runat="server" Style="margin-left: 9px;
                                float: left; margin-top: 2px;" Text="গ্রহনকারী ইস্যুর তারিখ ও সময়:"></asp:Label>
                            <asp:TextBox ID="txtRecipientDate" CssClass="present-address-tb" runat="server" Style="width: 122px;
                                margin-left: 14px; float: left; height: 27px" DateFormat="dd/MM/yyyy" ReadOnly="true"></asp:TextBox>
                             
                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtRecipientDate"/>
                            <asp:DropDownList ID="drpRecipientHr" CssClass="present-address-tb" runat="server" Style="width: 50px;
                                float: left; height: 27px" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpRecipientMin" CssClass="present-address-tb" runat="server" Style="width: 50px;
                                float: left; height: 27px" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-3 col-xs-3 col-lg-2">
                            <asp:Label ID="Label14" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="DropDownList4" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                            <asp:Label ID="Label15" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-top:5px">
                        <div class="col-sm-8" style="padding:0px">
                              <div class="col-sm-2" style="padding:0px">
                                <asp:Label ID="Label16" style="margin-left:45px" runat="server" Text=""><span class="required">*</span>মূল চালান নম্বর:</asp:Label>
                              </div>
                              <div class="col-sm-10" style="padding:0px">
                                 <asp:DropDownList ID="drpMainChallanNo" style="width:28%; height:27px" class="present-address-tb select2" OnSelectedIndexChanged="drpMainChallanNo_selectedIndexChanged" runat="server" AutoPostBack="true"></asp:DropDownList>
                              </div>
                        </div>
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="Label12" CssClass="present-address-lbl" runat="server" Style="margin-left: 8px;
                                float: left; margin-top: 2px;" Text="প্রদানকারী ইস্যুর তারিখ ও সময়:"></asp:Label>
                            <asp:TextBox ID="txtProviderDate" CssClass="present-address-tb" runat="server" Style="width: 122px;
                                margin-left: 14px; float: left; height: 27px" DateFormat="dd/MM/yyyy" Enabled="false"></asp:TextBox>
                            
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtProviderDate"/>
                            <asp:DropDownList ID="drpProviderHr" CssClass="present-address-tb" runat="server" Style="width: 50px;
                                float: left; height: 27px" AutoPostBack="True" Enabled="false">
                             </asp:DropDownList>
                             <asp:DropDownList ID="drpProviderMin" CssClass="present-address-tb" runat="server" Style="width: 50px;
                                float: left; height: 27px" AutoPostBack="True" Enabled="false">
                             </asp:DropDownList>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="Label20" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="DropDownList5" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                            <asp:Label ID="Label21" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="margin-top:20px;margin-left:5px">
                        <div class="test-label">
                            <asp:Label ID="Label33" runat="server"><strong>Type:</strong></asp:Label><br />
                            <asp:DropDownList ID="drpType" runat="server" class="category" style="width:100px"  OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" 
                            AutoPostBack="True">
                                <asp:ListItem>Goods</asp:ListItem>
                                <asp:ListItem>Service</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label34" runat="server"><strong>হ্রাসের ধরণ:</strong></asp:Label><br />
                            <asp:DropDownList ID="drpDecreaseType" runat="server" style="width:120px" class="category" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label22" runat="server"><strong>Category :</strong></asp:Label><br />
                            <asp:DropDownList ID="drpCategory" runat="server" class="category" style="text-align:left;width:120px" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" 
                            AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label23" runat="server"><strong>Sub Cat:</strong></asp:Label><br />
                            <asp:DropDownList ID="drpSubCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                            class="sub-category" Height="27px" style="text-align:left;width:120px"></asp:DropDownList>
                        </div>
                        <div class="test-label" style="display:none;">
                           <asp:Label ID="Label40" runat="server"><strong>Search Product:</strong></asp:Label><br />
                           <asp:TextBox ID="productName" CssClass="category" style="width:110px" AutoPostBack="true" placeholder="Search Product" runat="server" OnTextChanged="productName_TextChanged"/>
                           <div id="listPlacement" style="height:100px; overflow:scroll;" ></div>
                            <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName" ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement"
                                 MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetSaleProductByProductName" >
                            </ajaxToolkit:AutoCompleteExtender>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label24" runat="server" Text="" style="margin-left:0px;"/><strong>Item Name:</strong><br />
                            <asp:DropDownList ID="drpItem" CssClass="item select2" style="width:220px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged"/>
                           <asp:Label runat="server" ID="typeP" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp1" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp2" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp3" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp4" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblProp5" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="Label13" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="hdItemType" Visible="false"></asp:Label>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label25" runat="server"><strong>HS Code:</strong></asp:Label><br />
                             <asp:TextBox ID="lblHSCode" CssClass="hs-code" runat="server" style="width:100px" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="test-label">
                             <asp:Label ID="Label26" runat="server" style="margin-left: 0px;"><strong>Quantity:</strong></asp:Label> <br />
                             <asp:TextBox ID="txtQuantity" runat="server"  style="width:65px" class="quantity" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                             <asp:Label runat="server" style="margin-left:-40px;width:100px;color: #008000;font-weight:bold" ID="lblQ" Text="avl qnt: "/><asp:Label  style="color: #008000;font-weight:bold" runat="server" ID="lblQuantity"/>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                                 runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                             <asp:Label ID="lblQuantityPrp" runat="server" class="hiddencol"  />
                        </div>
                          <div class="test-label hiddencol">
                                    <asp:Label ID="Label29" runat="server" Text="" Style="margin-left: 0px;" />
                                    <asp:TextBox ID="txtcredQuantity" CssClass="category" runat="server"/>                                   
                                </div>
                        <div class="test-label">
                             <asp:Label ID="Label41" runat="server" Text="" style="margin-left: 0px;"/><strong>Unit:</strong><br />
                             <asp:TextBox ID="txtUnitName" CssClass="unit hiddencol" runat="server" style="width:55px"></asp:TextBox>
                            <asp:DropDownList ID="drpUnit" CssClass="unit select2" runat="server" Style="width: 80px" OnSelectedIndexChanged="drpUnit_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                              <asp:Label runat="server" ID="lblUnitId" Visible="false"></asp:Label>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label27" runat="server" Text="" style="margin-left:0px;"/><strong>Unit Price:</strong><br />
                            <asp:TextBox ID="txtUnitPrice" CssClass="category" style="width:130px" runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged"/>
                            <asp:Label ID="lblUnitPrice" runat="server" Text="" style="margin-left:0px;" Visible=false/>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                                 runat="server" Enabled="True" TargetControlID="txtUnitPrice"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label42" runat="server" Text="" style="margin-left:0px;"/><strong>Vat:</strong><br />
                            <asp:TextBox ID="txtVAT" ReadOnly="true" style="width:100px" CssClass="category" runat="server" AutoPostBack="True"></asp:TextBox>
                            <asp:Label ID="lblfxdVT" runat="server" Text=""/> <asp:Label ID="lblVat" runat="server" Text=""/><asp:Label ID="Label2" runat="server" Text="%"></asp:Label>
                            <asp:Label runat="server" ID="hdTotalVat"  Visible = "false"/>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                                 runat="server" Enabled="True" TargetControlID="txtVAT"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label43" runat="server" Text="" style="margin-left:0px;"/><strong>SD:</strong><br />
                            <asp:TextBox ID="txtSD" ReadOnly="true" style="width:100px" CssClass="category" runat="server" AutoPostBack="True"></asp:TextBox>
                            <asp:Label ID="lblSD" runat="server" Text=""/><asp:Label ID="Label6" runat="server" Text="%"></asp:Label>
                            <asp:Label runat="server" ID="hdTotalSD"  Visible = "false"/>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                                 runat="server" Enabled="True" TargetControlID="txtSD"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label31" runat="server" Text="" style="margin-left:0px;"/><strong>একক মূল্য</strong><br />
                            <asp:TextBox ID="txtTotalUnitPrice"  style="width:130px" CssClass="category" runat="server" placeholder="টাকায়"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                                                 runat="server" Enabled="True" TargetControlID="txtTotalUnitPrice"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label32" runat="server" Text="" style="margin-left:0px;"/><strong>মোট মূল্য</strong><br />
                            <asp:TextBox ID="txtAmount" ReadOnly="true" style="width:130px" CssClass="category" runat="server" placeholder="টাকায়"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                                                 runat="server" Enabled="True" TargetControlID="txtAmount"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="test-label">
                            <%--<asp:Label ID="Label35" runat="server" Text="বাদ কর্তন" style="margin-left:0px;"/><br />--%>
                            <asp:Label Style="margin-left: 0px;"><strong>বাদ কর্তন</strong></asp:Label><br />
                            <asp:TextBox ID="txtPreviousAmount" style="width:100px" CssClass="category" runat="server"  AutoPostBack="true" OnTextChanged="txtPreviousAmount_TextChanged" ></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                                                 runat="server" Enabled="True" TargetControlID="txtPreviousAmount"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label36" runat="server" Text="" style="margin-left:0px;"/><strong>মূসকসহ মূল্য</strong><br />
                            <asp:TextBox ID="txtTotalPricewithVat" ReadOnly="true" style="width:130px" CssClass="category" runat="server" AutoPostBack="True"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8"
                                                                 runat="server" Enabled="True" TargetControlID="txtTotalPricewithVat"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                        <div class="test-label">
                            <asp:Label ID="Label37" runat="server" Text="" style="margin-left:0px;"/><strong>মোট কর</strong><br />
                            <asp:TextBox ID="txtTotalTax" ReadOnly="true" style="width:130px" CssClass="category" runat="server" AutoPostBack="True"></asp:TextBox><br />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9"
                                                                 runat="server" Enabled="True" TargetControlID="txtTotalTax"
                                                                 ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                    </div>
                <div class="row" style="margin-top: 10px" runat="server" id="divProp">
                                <div class="test-label">
                                    <asp:HiddenField ID="hdProp1" runat="server" />
                                    <asp:Label ID="lblProperty1" Visible="false" runat="server"><span class="required"> * </span></asp:Label><br />
                                    <asp:DropDownList ID="drpProperty1" Visible="false" runat="server" AutoPostBack="True" CssClass="category" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="test-label">
                                    <asp:HiddenField ID="hdProp2" runat="server" />
                                    <asp:Label ID="lblProperty2" Visible="false" runat="server"><span class="required"> * </span></asp:Label><br />
                                    <asp:DropDownList ID="drpProperty2" Visible="false" runat="server" AutoPostBack="True" CssClass="category" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="test-label">
                                    <asp:HiddenField ID="hdProp3" runat="server" />
                                    <asp:Label ID="lblProperty3" Visible="false" runat="server"><span id="ddd" class="required"> * </span></asp:Label><br />
                                    <asp:DropDownList ID="drpProperty3" Visible="false" runat="server" AutoPostBack="True" CssClass="category" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty3_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="test-label">
                                    <asp:HiddenField ID="hdProp4" runat="server" />
                                    <asp:Label ID="lblProperty4" Visible="false" runat="server"><span class="required"> * </span></asp:Label><br />
                                    <asp:DropDownList ID="drpProperty4" Visible="false" runat="server" AutoPostBack="True" CssClass="category" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty4_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="test-label">
                                    <asp:HiddenField ID="hdProp5" runat="server" />
                                    <asp:Label ID="lblProperty5" Visible="false" runat="server" Text=""><span class="required"> * </span></asp:Label><br />
                                    <asp:DropDownList ID="drpProperty5" Visible="false" runat="server" AutoPostBack="True"
                                        CssClass="category" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpProperty5_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                    <div class="row" style="margin-top:1%">
                        <div class="col-sm-6" style="padding:0px">
                          <div class="col-sm-2" style="padding:0px">
                            <%--<asp:Label ID="Label28" runat="server" Text="ফেরতের কারণ:" style="margin-left:17px;"/>--%>
                              <label Style="margin-left: 17px;"><span class="required">*</span><strong>ফেরতের কারণ :</strong> </label>
                          </div>
                          <div class="col-sm-10" style="padding:0px">
                            <asp:TextBox ID="txtReasonofReturn" class="present-address-tb" style="width:100%;text-align:left;" runat="server" TextMode="MultiLine" Rows="1"></asp:TextBox><br />
                          </div>
                        </div>
                         <div class="col-sm-6" style="padding:0px;">
                           <asp:Button ID="btnAddRow" runat="server" class="btn-btn" style="background-color:#B681B7;margin-left:11px;margin-top:-2px" Text="Add Item" onclick="btnAddRow_Click" />
                           <asp:Button ID="btnRefresh" runat="server" class="btn-btn" style="background-color: #4CAF50;margin-top:-2px" 
                            Text="Refresh" onclick="btnRefresh_Click" />
                           <asp:Button ID="btnSave" runat="server" style="background-color:#4CAF50;margin-top:-2px;" class="btn-btn"
                            Text="Save Credit Note" onclick="btnSave_Click"/>
                           <asp:Button ID="btnPrint" runat="server" class="btn-btn hiddencol" style="background-color:#5CB85C;margin-top:-2px;"
                            Text="Show Report" onclick="btnPrint_Click"/>
                            <asp:Button ID="btnOA" runat="server" class="btn-btn hiddencol" style="background-color:#4CAF50;margin-top:-2px;"
                            Text="Other Adjusment" onclick="btnOA_Click"/>
                            <%--<asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" style="float:right"
                            Text="Print" OnClientClick="ToggleDiv('first');return false;"/>--%>
                         </div>
                    </div>
            </div>
        </div>
        <div class="panel panel-primary">
        <div class="panel-body">
             <div class="">
                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                    DataKeyNames="RowNo" Width="100%" OnSelectedIndexChanged="gvItem_SelectedIndexChanged"
                    OnPreRender="gvItem_PreRender" OnRowDataBound="gvItem_RowDataBound" OnRowDeleting="gvItem_RowDeleting" ShowHeaderWhenEmpty="true">
                    <Columns>
                      <%-- <asp:TemplateField HeaderText="">
                          <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)" ToolTip="Check to Select All Item" />
                          </HeaderTemplate>
                             <ItemTemplate>
                                 <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                             </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
                        <asp:BoundField HeaderText="Category" DataField="Category" Visible="False" />
                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategory" Visible="False" />
                        <asp:BoundField HeaderText="Item" DataField="Item" />

                        <asp:BoundField HeaderText="Property1" DataField="Property1" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField HeaderText="Property2" DataField="Property2" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField HeaderText="Property3" DataField="Property3" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField HeaderText="Property4" DataField="Property4" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField HeaderText="Property5" DataField="Property5" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />

                        <asp:BoundField HeaderText="Quantity" DataField="actualQuantity" DataFormatString="{0:n2}"/>
                        <asp:BoundField HeaderText="Unit" DataField="Unit" />
                        <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" DataFormatString="{0:n2}" />
                        <asp:BoundField HeaderText="VAT" DataField="Vat" DataFormatString="{0:n2}"/>
                        <asp:BoundField HeaderText="SD" DataField="Sd" DataFormatString="{0:n2}"/>
                        <asp:BoundField HeaderText="একক মূল্য" DataField="GUnitPrice" DataFormatString="{0:n2}"/>
                        <asp:BoundField DataField="GTotalPrice" HeaderText="মোট মূল্য" DataFormatString="{0:n2}"/>
                        <asp:BoundField DataField="PreviousAmount" HeaderText="বাদ কর্তন" DataFormatString="{0:n2}"/>
                        <asp:BoundField DataField="TotalPricewithVat" HeaderText="মূসকসহ মূল্য" DataFormatString="{0:n2}"/>
                        <asp:BoundField DataField="TotalTax" HeaderText="মোট কর" DataFormatString="{0:n2}"/>
                        <asp:BoundField DataField="ReasonOfReturn" HeaderText="ফেরতের কারণ" />
                        
                        <asp:BoundField HeaderText="Property1" DataField="Property1_Text" />
                        <asp:BoundField HeaderText="Property2" DataField="Property2_Text" />
                        <asp:BoundField HeaderText="Property3" DataField="Property3_Text" />
                        <asp:BoundField HeaderText="Property4" DataField="Property4_Text" />
                        <asp:BoundField HeaderText="Property5" DataField="Property5_Text" />

                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                </asp:GridView>
            </div>

            <br />
            <div class="row" style="text-align:right" runat="server" visible="false" id ="divSearch">
                                 Search:
                                <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="Search" AutoPostBack="true"></asp:TextBox>
                            </div>
                 <div class="row">
                     <asp:Label ID="lblTotalRow" runat="server" Text=""></asp:Label>
                                   <asp:GridView ID="gvAddtnProperty"  runat="server" AutoGenerateColumns="false" CellPadding="4" Width="100%"
                                       DataKeyNames="item_id" OnRowDataBound="gvAddtnProperty_RowDataBound" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
                                     <Columns>

                                  <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="additionalInfoId" Value='<%# Eval("additionalInfoId") %>' runat="server" />
                                    </ItemTemplate>
                                  </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderTemplate >
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesgvIngredience(this)" ToolTip="Check to Select All Item" />
                                            </HeaderTemplate>
                                            <ItemTemplate >
                                                <asp:CheckBox ID="chkChallan" runat="server" OnCheckedChanged="chkAdditionalProperty_CheckedChanged" AutoPostBack="true"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>  
                                 </Columns>  
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />  
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                                </asp:GridView>  
                            </div>

        </div>
    </div>
 <div class="panel panel-primary" style="font-family: Nikosh">
                    <div class="panel panel-body">
                        <div class="col-md-12">
                            <asp:Panel ID="pnlContents"  runat="server">

                                <div class="row">
                                    
                                                <div style="font-size: 16px">
                                                    <img src="../../Images/bdlogo.png" style="height: 50px; margin-left: 80px;"></img>
                                                    <p style="text-align: right; padding: 5px;">
                                                        <b style="border: 1px solid gray; margin-right: 17px;">মূসক-৬.৭</b>
                                                    </p>
                                                    <p style="text-align: center; font-size: 12px; margin: 2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                                                    <p style="text-align: center; font-size: 12px; margin: 2px;">জাতীয় রাজস্ব বোর্ড</p>
                                                    <p style="text-align: center; font-size: 12px; margin: 2px;"><strong>ক্রেডিট নোট</strong></p>
                                                    <p style="text-align: center; font-size: 12px; margin: 2px;">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (ছ)]</p>
                                                </div>

                                           
                                                
                                   </div>
                               
                                 <div style="font-size:12px">
                                <div class="col-sm-4" style="float: right;">
                                    <p style="margin: 2px;">
                                       ক্রেডিট নোট নম্বর: 
                                <asp:Label runat="server" ID="Challan_No" />
                                    </p>
                                    <p style="margin: 2px;">
                                        ইস্যুর তারিখঃ 
                                <asp:Label runat="server" ID="Challan_Date" />
                                    </p>
                                    <p style="margin: 2px;">
                                        ইস্যুর সময়ঃ 
                                <asp:Label runat="server" ID="Challan_Time" />
                                    </p>
                                </div>

                                <div class="row">

                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>নিবন্ধিত ব্যাক্তির নাম :
                                                     <asp:Label ID="receiver_name" runat="server" Text=""></asp:Label></label>
                                                
                                            </div>
                                        </div>
                                    </div>
                                <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>নিবন্ধিত ব্যক্তির বিআইএন  :
                                                 <asp:Label ID="receiver_BIN" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>নিবন্ধিত ব্যক্তির ঠিকানা  :
                                                   <asp:Label ID="receiver_address" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                 <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>ক্রেতা/গ্রহীতার নাম  :
                                                <asp:Label ID="provider_name" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>
                                       
                                     <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>ক্রেতা/গ্রহীতার বিআইন   :
                                                     <asp:Label ID="provider_BIN" runat="server" Text=""></asp:Label></label>
                                                 
                                            </div>
                                        </div>
                                    </div>
                                           
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>ঠিকানা :
                                                      <asp:Label ID="provider_address" runat="server" Text=""></asp:Label></label>
                                              
                                            </div>
                                        </div>
                                    </div>           
                                         <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <div class="col-sm-12" aria-orientation="horizontal">
                                                <label>যানবাহনের প্রকৃতি ও নম্বর :
                                                 <asp:Label ID="txtTransport" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                    </div>         
                                                <%-- commented onthe basis of  SRO-142 Publish Date: 11-June-2020--%>
                                                <%--  <tr style="background-color: White">

                                            <td style="width: 20%">মূল চালান নম্বর :</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="challan_no" runat="server" Text=""></asp:Label>
                                            </td>
                                              <td style="width: 20%">ক্রেডিট নোট নম্বর :</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="debit_no" runat="server" Text=""></asp:Label>
                                            </td>
                                            </tr>
                                        <tr>
                                              <td style="width: 20%">মূল চালান ইস্যুর তারিখ :</td>

                                            <td style="width: 29%">
                                                <asp:Label ID="challan_issue_date" runat="server"
                                                    Text=""></asp:Label>
                                            </td>
                                              <td style="width: 20%">ইস্যুর তারিখ :</td>

                                            <td style="width: 30%">
                                                <asp:Label ID="receive_issue_date" runat="server" Text=""></asp:Label>
                                            </td>

                                        </tr>

                                         <tr style="background-color: White">
                                            <td style="width: 20%"></td>
                                            <td style="width: 30%">
                                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 20%">ইস্যুর সময় :</td>
                                            <td style="width: 30%">
                                                <asp:Label ID="issue_time" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>--%><%-- commented onthe basis of  SRO-142 Publish Date: 11-June-2020--%>
                                  
                                </div>
                                <table border="1" class="table" style="width: 100%; background-color: White; border-collapse: collapse">
                                    <thead>

                                        <tr>
                                         
                                             <th rowspan="2" class="col_3_percent" style="font-weight: normal; text-align: center; border: 1px solid #000">ক্রমিক নং
                                            </th>
                                            <th rowspan="2" class="col_3_percent" style="font-weight: normal; text-align: center; border: 1px solid #000">কর চালান পত্রের নম্বর ও তারিখ

                                            <th rowspan="2" style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">ক্রেডিট নোট ইস্যুর কারণ
                                            </th>
                                             <th  colspan="4" style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">চালানপত্রে উল্লিখিত সরবরাহের
                                            </th>
                                             <th  colspan="4" style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">হ্রাসকারী সমন্বয়ের সহিত সংশিষ্ট
                                            </th>
                                             </tr>
                                            <tr>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">মূল্য<sup>১</sup> </th>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">পরিমাণ </th>
                                                <th style="font-weight: normal; text-align: center; border: 1px solid #000">মূল্য সংযোজন করের পরিমাণ </th>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">সম্পূরক শুল্কের পরিমাণ </th>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">মূল্য<sup>১</sup> </th>
                                                <th style="font-weight: normal; text-align: center; border: 1px solid #000">পরিমাণ </th>
                                                <th style="text-align: center; font-weight: normal; text-align: center; border: 1px solid #000">মূল্য সংযোজন করের পরিমাণ </th>
                                                <th style="font-weight: normal; text-align: center; border: 1px solid #000">সম্বনয়যোগ্য সম্পূরক শুল্কের পরিমাণ </th>
                                        </tr>
                                                                                                                     

                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align: center">(১)
                                            </td>
                                            <td style="text-align: center">(২)
                                            </td>
                                            <td style="text-align: center">(৩)
                                            </td>
                                            <td style="text-align: center">(৪)
                                            </td>
                                            <td style="text-align: center">(৫)
                                            </td>
                                            <td style="text-align: center">(৬)
                                            </td>
                                            <td style="text-align: center">(৭)
                                            </td>
                                            <td style="text-align: center">(৮)
                                            </td>
                                             <td style="text-align: center">(৯)
                                            </td>
                                            <td style="text-align: center">(১০)
                                            </td>
                                             <td style="text-align: center">(১১)
                                            </td>
                                        </tr>
                                        <tr>
                                            <asp:Label ID="debitNoteReport" runat="server" />
                                        </tr>
                                    </tbody>
                                </table>
                                
                                <div style="text-align:right;margin-right:100px;">
                                   <%-- <p>ফেরতের কারণ: <asp:TextBox ID="txtreason" runat="server" style="width:1200px"></asp:TextBox></p>--%>

                                    
                                   
                                     <p style="margin-top:15px;">দায়িত্ব প্রাপ্ত ব্যক্তির নাম:  <asp:Label style="font-size:11px;" runat="server" ID="lblDutyOfficerName"></asp:Label></p>
                                     <p style="margin-top:15px;">পদবি:    <asp:Label style="font-size:11px;" runat="server" ID="lblDutyOfficerDesignationName"></asp:Label></p>
                                     <p style="margin-top:15px;">সাক্ষর:   <asp:Label ID="Label3" runat="server"></asp:Label></p>
                                     <p style="margin-top:15px;">সিল:   <asp:Label ID="Label4" runat="server"></asp:Label></p>
                                     
                                 <br />
                                 <br />
                                 <br />                                 
                                  
                                </div>
                                <p>১পণ্য/সেবার মূসক ও সম্পূরক শুল্কসহ মূল্য।</p>
                                <div class="col-md-12" style="margin-top: 5px">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="System User: "></asp:Label>
                                        <asp:Label runat="server" ID="lblUser"></asp:Label>
                                        <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                        <asp:Label runat="server" ID="Label5" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                    </div>
                                </div>
<br />
                                      <div style="text-align:right;font-size:11px;">
                                         System Generated (KGCVAT)
                                     </div>
                                </div>
                                 
                            </asp:Panel>
                        </div>
                    </div>
                </div>

    <div id="cnPrint" class="container-fluid" style="width:100%;"  runat="server" visible = "false">
      <div class="row" style="margin:10px">
                                     <table style="border:none;width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; font-size: 14px; border:none"
                    </th>
                </tr>
         <tr>
        <td> <img src="../../Images/bdlogo.png" style="height:50px;margin-left:80px;margin-top:-100px" ></img></td>
    
          <td>
         <div class="row" style="margin-right:220px">
            <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
         <p style="text-align:center"><b>জাতীয় রাজস্ব বোর্ড</b></p>
         <p style="text-align:right"><b style="border:1px solid #000">ক্রেডিট নোট (মূসক-১২)</b></p>
         <p style="text-align:center"><b>ক্রেডিট নোট</b></p>
         <p style="text-align:center">[বিধি ১৭(ক) দ্রষ্টব্য]</p>
         </div>    
      </td>
    
      </table>
        
      </div>
      <div class="row" style="width:100%; height:0px;" >
        <div class="col-sm-6" style="width:50%; height:150px; float:left">
           <p><u>ফেরত প্রদানকারী ব্যক্তির-</u></p>
           <p>নামঃ&nbsp <asp:Label runat="server" ID="lblProviderName" style="font-weight:bold"/></p>
           <p>বিআইএনঃ&nbsp <asp:Label runat="server" ID="lblProviderBIN" style="font-weight:bold"/></p>
           <p>মূল চালান নম্বরঃ&nbsp <asp:Label runat="server" ID="lblProviderChallan" style="font-weight:bold"/></p>
           <p>মূল চালান ইস্যুর তারিখঃ&nbsp <asp:Label runat="server" ID="lblProviderDate2" style="font-weight:bold"/></p>
        </div>
        <div class="col-sm-6" style="border-left:1px solid #000;width:49%; float:left">
           <p><u>ফেরত গ্রহণকারী ব্যক্তির-</u></p>
           <p>নামঃ&nbsp <asp:Label runat="server" ID="lblReceiverName" style="font-weight:bold"/></p>
           <p>বিআইএনঃ&nbsp <asp:Label runat="server" ID="lblReceiverBIN" style="font-weight:bold"/></p>
           <p>ক্রেডিট নোট নম্বরঃ&nbsp <asp:Label runat="server" ID="lblReceiverNoteNumber" style="font-weight:bold"/></p>
           <p>ইস্যুর তারিখঃ&nbsp <asp:Label runat="server" ID="lblReceiverDate" style="font-weight:bold"/></p>
           <p>ইস্যুর সময়ঃ&nbsp <asp:Label runat="server" ID="lblReceiverTime" style="font-weight:bold"/></p>
        </div>
      </div>
      <div class="row"  style="width:100%; margin-top:10px" >
        <table class="table table-bordered" style="background:none; border-collapse:collapse; width:100%">
          <tr>
            <td style="border:1px solid gray">ক্রমিক নং</td>
            <td style="border:1px solid gray">ফেরতকৃত সরবরাহের বিবরণ</td>
            <td style="border:1px solid gray">সরবরাহের একক</td>
            <td style="border:1px solid gray">পরিমাণ</td>
            <td style="border:1px solid gray">একক মূল্য<sup>১</sup> (টাকায়)</td>
            <td style="border:1px solid gray">মোট মূল্য (টাকায়)</td>
          </tr>
          <tr>
            <asp:Label runat="server" ID="CreditNoteReport" />
          </tr>
          <tr>
            <td colspan="5" style="border:0; text-align:right; padding-right:3px">মোট মূল্য</td>
            <td style="border:1px solid gray"><asp:Label runat="server" ID="lblTotalPrice" /></td>
          </tr>
          <tr>
            <td colspan="5" style="border:0;text-align:right; padding-right:3px">বাদ কর্তন<sup>২</sup></td>
            <td style="border:1px solid gray"><asp:Label runat="server" ID="lblCutPrice" /></td>
          </tr>
          <tr>
            <td colspan="5" style="border:0;text-align:right; padding-right:3px">মূসকসহ মূল্য</td>
            <td style="border:1px solid gray"><asp:Label runat="server" ID="lblTotalPriceWithVat" /></td>
          </tr>
          <tr>
            <td colspan="5" style="border:0;text-align:right; padding-right:3px">মূসকের পরিমাণ</td>
            <td style="border:1px solid gray"><asp:Label runat="server" ID="lblVatPrice" /></td>
          </tr>
          <tr>
            <td colspan="5" style="border:0;text-align:right; padding-right:3px">সম্পূরক শুল্কের পরিমাণ</td>
            <td style="border:1px solid gray"><asp:Label runat="server" ID="lblSDPrice" /></td>
          </tr>
          <tr>
            <td colspan="5" style="border:0;text-align:right; padding-right:3px">মোট কর<sup>৩</sup></td>
            <td style="border:1px solid gray"><asp:Label runat="server" ID="lblTotalTax" /></td>
          </tr>
        </table>
      </div>
      <div class="row" style="width:100%; height:0px; margin-top:5px">
        <p>ফেরতের কারণ</p>
        <p><asp:TextBox runat="server" ID="ReturnComment" style="width:100%" TextMode="MultiLine" /></p>
      </div>
      <div class="row" style="width:100%; margin-top:10%">
        <p>দায়িত্ব প্রাপ্ত ব্যক্তির স্বাক্ষর </p><br />
        <p style="border-top:1px solid #000; width:20% "></p>
        <p><sup>১</sup> প্রতি একক পণ্য/সেবার মূসক ও সম্পূরক শুল্কসহ মূল্য।</p>
        <p><sup>২</sup>ফেরত প্রদানের জন্য কোনো ধরনের কর্তন থাকলে তার পরিমাণ।</p>
        <p><sup>৩</sup>মূসক ও সম্পূরক শুল্কের যোগফল। </p>
      </div>

        <div style="text-align:right;font-size:11px;">
               System Generated (KGCVAT)
        </div>  
    </div>
    </div>
    <asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" style="float:right"
    Text="Print" onclientclick="return PrintPanel();" Visible = "false"/>
   <%--   <uc2:MsgBox ID="msgBox" runat="server" />  --%>
                <uc1:MsgBoxs runat="server" ID="msgBox" />
            </ContentTemplate>
        </asp:UpdatePanel>
                        
</div>
</asp:Content>