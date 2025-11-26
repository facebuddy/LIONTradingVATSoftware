<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_Own_Production_Receive6_4, App_Web_z1w3wddp" %>


<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
  <link rel="stylesheet" href="/resources/demos/style.css">  
        <link href="../../Styles/panel.css" rel="stylesheet" />
     <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />.
     <link href="../../Styles/panel.css" rel="stylesheet" />
     <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/bootstrap/bootstrap.css" />

        <style type="text/css">
     .style1 {
            text-align: right;
        }
     .hiddencol {
            display: none;
        }
        .input_field {
            text-align: right;
        }

        .FixedHeader {
            position: fixed;
            font-weight: bold;
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

         hr {
            padding: 0px;
            margin-top: 0px;
            margin-bottom: 5px;
        }

        .PnlDesign {
            border: solid 1px #000000;
            height: 100px;
            width: 115%;
            overflow: scroll;
            background-color: #EAEAEA;
            font-size: 15px;
            font-family: Arial;
        }

        .txtbox {
            background-image: url(../images/drpdwn.png);
            background-position: right top;
            background-repeat: no-repeat;
            cursor: pointer;
            cursor: hand;
        }

        
        .wrapper1, .wrapper2 { width: 100%; overflow-x: scroll; overflow-y: hidden; }
        .wrapper1 { height: 20px; }
        .div1 { height: 20px; }
        .div2 { overflow:none; }
    </style>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=cpPrint.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            //            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head>');
            printWindow.document.write('<body style="margin: 50px; font-family: "Times New Roman", Times, serif; font-size:18px">');
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
     <script>
            $(function () {
                $('.wrapper1').on('scroll', function (e) {
                    $('.wrapper2').scrollLeft($('.wrapper1').scrollLeft());
                });
                $('.wrapper2').on('scroll', function (e) {
                    $('.wrapper1').scrollLeft($('.wrapper2').scrollLeft());
                });
            });
            $(window).on('load', function (e) {
                $('.div1').width($('table').width());
                $('.div2').width($('table').width());
            });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <%--<div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">সত্ত্বাধিকারীর  সরবরাহ স্থল থেকে উৎপাদিত পণ্য গ্রহণ (মূসক-১১গ)</div>--%>
                        <%--<div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">সত্ত্বাধিকারীর  সরবরাহ স্থল থেকে উৎপাদিত পণ্য গ্রহণ ৬.৪ </div>--%>
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">Receive /উৎপাদনের চালানপত্র </div>
                        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                            <div class="row hiddencol" style="background-color: #FFD9C3; ">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Name :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="lt_companyName" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Address :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="It_companyAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. BIN :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row hiddencol">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpBranchName" runat="server" OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged" AutoPostBack="true"
                                            CssClass="form-control">
                                        </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Factory Name :</label>
                                        <div class="col-sm-7">
                                           <asp:DropDownList ID="drpParty" runat="server" CssClass="form-control" 
                                            AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Factory Address :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox class="form-control" ID="txtAddress" runat="server" placeholder="address here" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                              <%--  <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">BIN :</label>
                                        <div class="col-sm-7">
                                           <asp:TextBox ID="txtPartyBIN" runat="server"  class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Received Challan No :</label>
                                        <div class="col-sm-7">
                                           <asp:TextBox ID="txtChallanNo" CssClass="form-control" runat="server" Enabled="false"
                                        AutoPostBack="true"  OnTextChanged="challanNo_textChanged"></asp:TextBox>
                                    <asp:HiddenField ID="hdBookId" runat="server" />
                                    <asp:HiddenField ID="hdPageNo" runat="server" />
                                            <asp:CheckBox ID="chkDiscard" Style="float: left; margin-left: 3px; margin-top: 4px;"
                                        runat="server" AutoPostBack="True" OnCheckedChanged="chkDiscard_CheckedChanged"
                                        Text="Discard" Visible="false" />
                                    <asp:DropDownList ID="drpDiscardReason1" CssClass="present-address-tb" runat="server"
                                        Style="width: 125px; height: 27px; margin-left: 0px; margin-top: 3px" Visible="false" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Challan Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtChallanDate" Style="width: 50%; float: left" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanDate" />
                                            <asp:DropDownList ID="drpChDtHr" CssClass="form-control" runat="server" Style="width: 25%; float: left"
                                                    AutoPostBack="True" OnSelectedIndexChanged="drpChDtHr_SelectedIndexChanged">
                                                </asp:DropDownList>
                                    <asp:DropDownList ID="drpChDtMin" CssClass="form-control" runat="server" Style="width: 25%; float: left" 
                                        AutoPostBack="True" OnSelectedIndexChanged="drpChDtMin_SelectedIndexChanged">
                                    </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Receive Scroll No :</label>
                                        <div class="col-sm-7">
                                           <asp:TextBox ID="txtScroll" runat="server"  class="form-control"></asp:TextBox>
                                             <asp:Label ID="lblDiscardReason" CssClass="present-address-lbl" Style="margin-left: 5px; margin-top: 4px;"
                                            runat="server" Text="Discard Reason:" Visible="false"></asp:Label>
                                            <asp:DropDownList ID="drpDiscardReason" CssClass="present-address-tb" runat="server"
                                            Style="width: 94%; height: 27px; margin-left: 0px" Visible="false">
                                        </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Provided Challan No :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList class="form-control select2" ID="ddlProvidedChallan" runat="server" OnSelectedIndexChanged="ddlProvidedChallan_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                       <asp:Label runat="server" ID="priceDecId" CssClass="hiddencol"></asp:Label>
                                            </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                               
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Price Declaration No :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList class="form-control select2" ID="drpPriceDeclarationNo" runat="server" OnSelectedIndexChanged="drpPriceDeclarationNo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                </div>
                            </div>                          
                            <div class="row" style="margin: 10px; padding: 0px">
                                <div class="test-label">
                                    <asp:Label ID="Label6" runat="server" Text="Role:"></asp:Label><br />
                                    <asp:DropDownList ID="drpRole" runat="server"  CssClass="detail-role select2" OnSelectedIndexChanged="drpRole_SelectedIndexChanged"
                                        AutoPostBack="True" TabIndex="1">
                                        <asp:ListItem>Finish Product(Production)</asp:ListItem>
                                        <asp:ListItem>Finish Product</asp:ListItem>
                                        <asp:ListItem>Ingredient</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label7" runat="server" Text="Category :"></asp:Label><br />
                                    <asp:DropDownList ID="drpCategory" runat="server" Style="text-align: left" CssClass="category select2" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                        Enabled="true" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label15" runat="server" Text="Sub Cat:"></asp:Label><br />
                                    <asp:DropDownList ID="drpSubCategory" Style="text-align: left" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                                        Enabled="true" CssClass="sub-category select2">
                                    </asp:DropDownList>

                                </div>
                               <%-- <div class="test-label">
                                    <asp:Label ID="Label40" runat="server" Text="Search Product:" /><br />
                                    <asp:TextBox Style="text-align: left" ID="productName" CssClass="search-product" AutoPostBack="true" placeholder="Search Product"
                                        runat="server" OnTextChanged="productName_TextChanged" />
                                    <div id="listPlacement" style="height: 100px; overflow: scroll;">
                                    </div>
                                    <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName"
                                        ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement" MinimumPrefixLength="1"
                                        EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetProductByProductName">
                                    </ajaxToolkit:AutoCompleteExtender>--%>
                                    <%--<ajaxToolkit:AutoCompleteExtender runat="server" ID="accProductName" TargetControlID="productName"
                             ServiceMethod="GetProductByProductName" ServicePath="~/WebService.asmx" MinimumPrefixLength="1"
                             CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement"
                             CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                             DelimiterCharacters=";, :" ShowOnlyCurrentWordInCompletionListItem="true">
                        </ajaxToolkit:AutoCompleteExtender>--%>
                               <%-- </div>--%>
                                <div class="test-label">
                                    <asp:Label ID="Label16" runat="server" Text="Item Name:" Style="margin-left: 0px;" /><br />
                                    <asp:DropDownList ID="drpItem" CssClass="item select2" Style="text-align: left" runat="server" AutoPostBack="True"
                                        Enabled="true" OnSelectedIndexChanged="drpItem_SelectedIndexChanged" />
                                    <asp:Label runat="server" ID="lblProductType" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp1" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp2" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp3" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp4" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lblProp5" Visible="false"></asp:Label>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                    <asp:TextBox ID="lblHSCode" CssClass="hs-code" runat="server" Style="width: 80px"
                                        Enabled="false"></asp:TextBox>
                                </div>
                            <div class="test-label">
                        <asp:Label ID="Label1" runat="server" Text="">Batch No.:</asp:Label><br />
                              <asp:TextBox ID="txtBatchNo" CssClass="hs-code" runat="server" Style="width: 80px"></asp:TextBox>
                           </div>
                                <div class="test-label">
                                                   <asp:Label ID="Label8" runat="server" Text="">Mfg.Date:</asp:Label><br />
                                    <asp:TextBox ID="txtMfgDate" CssClass="hs-code" Format="dd/MM/yyyy" runat="server" Style="width: 80px"></asp:TextBox>
                                      <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="txtMfgDate" />
                                </div>
                                 <div class="test-label">
                                             <asp:Label ID="Label10" runat="server" Text="">Expiry Date:</asp:Label><br />
                                    <asp:TextBox ID="txtExpDate" CssClass="hs-code" Format="dd/MM/yyyy" runat="server" Style="width: 80px"></asp:TextBox>
                                      <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtExpDate" />
                                </div>
                                <div class="test-label">                                    
                                    <asp:Label ID="Label18" runat="server" Text="Quantity:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtQuantity" CssClass="quantity" Style="width: 75px" runat="server"
                                        AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                                     <asp:Label ID="lblQuantityPrp" runat="server" class="hiddencol"  />
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                        runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     <asp:Label runat="server" ID="aa" Text="avl qnt: " Style="margin-left: -35px;color: #008000;font-weight:bold"/>
                                    <asp:Label runat="server" ID="lblAvailableQuantity"  class="hiddencol"/>
                                     <asp:Label runat="server" ID="lblavalqty"  style="color: #008000;font-weight:bold"/>
                                    <asp:Label runat="server" ID="fnUnitPrice" Visible="false"/>
                                    <asp:Label runat="server" ID="fnVat" Visible="false"/>
                                    <asp:Label runat="server" ID="fnSD" Visible="false"/>
                                    <asp:Label runat="server" ID="fnTotal" Visible="false"/>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label41" runat="server" Text="Unit:" /><br />
                                    <asp:DropDownList ID="drpUnit" CssClass="unit select2" runat="server" Style="width: 70px" OnSelectedIndexChanged="drpUnit_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:HiddenField ID="hdUnitID" runat="server" Visible="false" />
                                    <asp:HiddenField ID="hdItemType" runat="server" />
                                    <asp:Label runat="server" ID="lblCValue" Visible="false" />
                                    <asp:Label runat="server" ID="lblUID" Visible="false" />
                                    <asp:Label runat="server" ID="lblUnitCode" Visible="false" />
                                </div>
                                 <div class="test-label hiddencol">
                                    <asp:Label ID="Label2" runat="server" Text="" Style="margin-left: 0px;" />
                                    <asp:TextBox ID="txtFinalQuantity" CssClass="category" runat="server"/>                                   
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label13" runat="server" Text="Unit Price(S):" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtSaleUnitPrice" CssClass="category" runat="server" AutoPostBack="True" OnTextChanged="txtSaleUnitPrice_TextChanged" Style="background-color: #D4FCFF" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtSaleUnitPrice"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     <asp:Label ID="lblSaleUnitPrice" runat="server" Text="" Style="margin-left: 0px;" Visible="false" />
                                    <asp:HiddenField runat="server" ID="hdPriceID" />
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label34" runat="server" Text="Vatable(P):" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtSaleVatablePrice" CssClass="category" Style="background-color: #D4FCFF"
                                        runat="server" AutoPostBack="True" OnTextChanged="txtVatablePrice_TextChanged" />
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                        runat="server" Enabled="True" TargetControlID="txtSaleVatablePrice"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label42" runat="server" Text="VAT:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtSaleVat" CssClass="quantity" Style="background-color: #D4FCFF"
                                        runat="server" AutoPostBack="True"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                        runat="server" Enabled="True" TargetControlID="txtSaleVat"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                  <asp:Label ID="lblfxdVT" runat="server" Text="" />   <asp:Label ID="lblSaleVat" runat="server" Text="" /><asp:Label ID="Label9" runat="server" Text="%"></asp:Label>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label43" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtSaleSD" CssClass="quantity" Style="background-color: #D4FCFF"
                                        runat="server" AutoPostBack="True"></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                                        runat="server" Enabled="True" TargetControlID="txtSaleSD"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:Label ID="lblSaleSD" runat="server" Text="" /><asp:Label ID="Label11" runat="server" Text="%"></asp:Label>
                                </div>
                                  <div class="test-label">
                                    <asp:Label ID="Label5" runat="server" Text="Remarks:" /><br />
                                    <asp:TextBox ID="txtRemark" CssClass="remark" runat="server" Style="width: 150px"></asp:TextBox>
                                    <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label>
                                </div>
                                 <div class="test-label">
                                       <asp:Label ID="Label3" runat="server"  Style="margin-left: 0px;" /><br />
                                    <asp:CheckBox ID="chkExcel" runat="server" ForeColor="green" AutoPostBack="true"  OnCheckedChanged="ChckedChanged" Text="Add Additional Information?"/>
                                </div>
                            </div>
                           

                            <div class="row" style="padding-left: 25px; padding-right: 18px;" runat="server" id="divProp">
                              
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp1" runat="server" />
                                        <%--<asp:Label ID="lblProperty1" runat="server" Text="" Visible="false"><span class="required"> * </span>Size:</asp:Label><br />--%>
                                        <asp:Label ID="lblProperty1" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp1_SelectedIndexChanged"
                                            CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp2" runat="server" />
                                        <%--<asp:Label ID="lblProperty2" runat="server" Text="" Visible="false"><span class="required"> * </span>Color:</asp:Label><br />--%>
                                        <asp:Label ID="lblProperty2" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty2" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="drpProp2_SelectedIndexChanged"                                          
                                            Visible="false" CssClass="category" Style="height: 27px; text-align: left">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp3" runat="server" />
                                       <%--<asp:Label ID="lblProperty3" runat="server" Text="" Visible="false"><span class="required"> * </span>Grade:</asp:Label><br />--%>
                                        <asp:Label ID="lblProperty3" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty3" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="drpProp3_SelectedIndexChanged"                                          
                                            CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp4" runat="server" />
                                        <%--<asp:Label ID="lblProperty4" runat="server" Text="" Visible="false"><span class="required"> * </span>Box:</asp:Label><br />--%>
                                        <asp:Label ID="lblProperty4" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp4_SelectedIndexChanged"
                                            CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hdProp5" runat="server" />
                                        <%--<asp:Label ID="lblProperty5" runat="server" Text="" Visible="false"><span class="required"> * </span>Specification:</asp:Label><br />--%>
                                        <asp:Label ID="lblProperty5" runat="server" Visible="false"><span class="required"> * </span></asp:Label><br />
                                        <asp:DropDownList ID="drpProperty5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProp5_SelectedIndexChanged"
                                            CssClass="category" Visible="false" Style="height: 27px; text-align: left">
                                        </asp:DropDownList>
                                    </div>
                              
                                
                            </div>
                            <div class="row" style="text-align:right">
                                
                                <div class="test-btn">
                                    <asp:Button ID="printBTN" runat="server"  OnClick="btnPrint_Click" Text="Show Report" class="btn-btn"  Style="background-color:#5CB85C;margin-top: 17px;" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnAdd" runat="server"  OnClick="btnAddItem_Click" Text="Add Item" class="btn-btn" style="background-color:#B681B7;margin-top: 17px;" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnSave" runat="server"  Text="Save" OnClick="btnSave_Click" class="btn-btn" style="background-color:#4CAF50;margin-top: 17px;" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnClear" runat="server"  OnClick="btnClear_Click" Text="Refresh" class="btn-btn" style="background-color: #4CAF50;margin-top: 17px;" />
                                </div>
                               
                                
                               
                            </div>
                           <div class="row" runat="server" id="form">
                    <div class="row" style="padding-left: 25px; padding-right: 18px;" runat="server" id="divexcelProp">

                               <div class="test-label">
                                                                             
                                        <asp:Label ID="Label4" runat="server" ForeColor="Green" Font-Bold="true"  >Enter the Additional Property in Excel Header: </asp:Label>
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty1" runat="server" />                                       
                                        <asp:Label ID="prop1" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ><span class="required"> * </span></asp:Label> &nbsp
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty2" runat="server" />                                       
                                        <asp:Label ID="prop2" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ><span class="required"> * </span></asp:Label>&nbsp
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty3" runat="server" />                                      
                                        <asp:Label ID="prop3" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ><span class="required"> * </span></asp:Label>&nbsp
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty4" runat="server" />                                      
                                        <asp:Label ID="prop4" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ><span class="required"> * </span></asp:Label>&nbsp
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField ID="hfProperty5" runat="server" />                                       
                                        <asp:Label ID="prop5" runat="server" Visible="false"  ForeColor="Green" Font-Bold="true" ></asp:Label>
                                       
                                    </div>
                              
                                
                            </div>
                    <div class="col-sm-6">
                        <asp:FileUpload ID="FileUpload1" runat="server" Style="background: #E0EBF5" />
                      <%--  <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload and Check" CssClass="btn btn-primary btn-sm" />--%>
                        <asp:Label ID="Label29" runat="server"></asp:Label>
                        <%--<asp:Button ID="btnExcelSave" runat="server" OnClick="btnExcelSave_Click" Text="Save" CssClass="btn-btn"  style="background-color:#4CAF50"/>--%>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
                <br /> 
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                <div class="container-fluid">
                  <div class="gridDiv table-responsive paddingsmall" runat="server">
                                <div class="wrapper1">
                                    <div class="div1"></div>
                                 </div>
                              <div class="wrapper2">
                                   <div class="div2">
                                 <asp:GridView ID="gvExcelFile"  runat="server" AutoGenerateColumns="false" CellPadding="4" Width="100%"
                                       DataKeyNames="Item_id"  OnRowDataBound="gvExcelFile_RowDataBound" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
                                     <Columns>

                                  <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="rowNo" Value='<%# Eval("rowNo") %>' runat="server" />
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
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnYesNoModal" runat="server" Width="350" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
   
        <div class="panel panel-primary panel-primary-custom">
            <div class="panel-heading panel-heading-custom">  
                <b><asp:Label ID="lblMessage" runat="server" ></asp:Label></b>                         
                
                <div class="clearfix"></div>

            </div>
         
        </div>
    </asp:Panel>
    <asp:Button ID="btnHideButton" runat="server" Text="Close" CssClass="hide"  />
    
    <ajaxToolkit:ModalPopupExtender ID="mpeYesNoModal" runat="server" 
        PopupControlID="pnYesNoModal" TargetControlID="btnHideButton" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>
                            <div class="row" style="margin: 10px">
                                <div class="panel panel-primary">
                                    <div class="panel-body">
                                        <div class="">
                                            <asp:GridView ID="gvMainItem" runat="server" AutoGenerateColumns="False"
                                                CssClass="sGrid" DataKeyNames="RowNo" Width="100%" BackColor="#DEBA84" BorderColor="#DEBA84"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                                                    <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                                                    <asp:BoundField HeaderText="Item" DataField="ItemName" />
                                                    <asp:BoundField HeaderText="Batch No" DataField="Batch_no" />
                                                     <asp:BoundField HeaderText="Mfg. Date" DataField="MfgDate" />
                                                     <asp:BoundField HeaderText="Expiry Date" DataField="ExpiryDate" />
                                                    <asp:BoundField HeaderText="Property1" DataField="Property_id1" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                    <asp:BoundField HeaderText="Property2" DataField="Property_id2" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                    <asp:BoundField HeaderText="Property3" DataField="Property_id3" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                    <asp:BoundField HeaderText="Property4" DataField="Property_id4" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                    <asp:BoundField HeaderText="Property5" DataField="Property_id5" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                    <asp:BoundField HeaderText="Used Quantity" DataField="Quantity" DataFormatString="{0:n2}"/><%--zahid 09-08-22 --> uncommented--%>
                                                    <%--<asp:BoundField HeaderText="Used Quantity" DataField="PreQuantity" DataFormatString="{0:n2}"/> <%--sabbir 24/8/20 to show input quanitty in grid--%>
                                                    <%--zahid 09-08-22 commented the whole line--%>
                                                    <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                                                    <asp:BoundField HeaderText="Unit Price" DataField="SaleUnitPrice"  DataFormatString="{0:n2}"/>
                                                    <asp:BoundField HeaderText="Vat" DataField="SaleVat" DataFormatString="{0:n2}" />
                                                    <asp:BoundField HeaderText="SD" DataField="SaleSD"  DataFormatString="{0:n2}"/>
                                                    <asp:BoundField HeaderText="Vatable Price" DataField="SaleVatablePrice"  DataFormatString="{0:n2}"/>
                                                    
                                                    <asp:BoundField HeaderText="Property1" DataField="Property1_Text" HeaderStyle-ForeColor="White" />
                                                    <asp:BoundField HeaderText="Property2" DataField="Property2_Text" HeaderStyle-ForeColor="White" />
                                                    <asp:BoundField HeaderText="Property3" DataField="Property3_Text" HeaderStyle-ForeColor="White" />
                                                    <asp:BoundField HeaderText="Property4" DataField="Property4_Text" HeaderStyle-ForeColor="White" />
                                                    <asp:BoundField HeaderText="Property5" DataField="Property5_Text" HeaderStyle-ForeColor="White" />

                                                    <asp:BoundField HeaderText="Remark" DataField="Remark" />
                                                   
                                                </Columns>
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True"
                                                    ForeColor="White" />
                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7"
                                                    ForeColor="#8C4510" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:TextBox runat="server" ID="lblquantity" CssClass="hiddencol"></asp:TextBox>
                            <div class="row" style="margin: 10px">
                                <div class="panel panel-primary">
                                    <div class="panel-body">
                                        <div class="">
                                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid" DataKeyNames="RowNo" Width="100%"
                                                OnSelectedIndexChanged="gvItem_SelectedIndexChanged"
                                                OnPreRender="gvItem_PreRender" OnRowDataBound="gvItem_RowDataBound"
                                                OnRowDeleting="gvItem_RowDeleting" BackColor="#DEBA84" BorderColor="#DEBA84"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                                                        ShowSelectButton="True" />
                                                    <%-- <asp:BoundField HeaderText="Category" DataField="CategoryName" />--%>
                                                    <asp:BoundField HeaderText="Sub Category" DataField="SubCategoryName" />
                                                    <asp:BoundField HeaderText="Item" DataField="ItemName" />
                                                    <asp:BoundField HeaderText="Property1" DataField="Property_id1" Visible="False" />
                                                    <asp:BoundField HeaderText="Property2" DataField="Property_id2" Visible="False" />
                                                    <asp:BoundField HeaderText="Property3" DataField="Property_id3" Visible="False" />
                                                    <asp:BoundField HeaderText="Property4" DataField="Property_id4" Visible="False" />
                                                    <asp:BoundField HeaderText="Property5" DataField="Property_id5" Visible="False" />
                                                    <asp:BoundField HeaderText="Used Quantity" DataField="Quantity" DataFormatString="{0:n2}" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                                                   <asp:TemplateField HeaderText="Used Quantity">
                             <ItemTemplate>
                               <asp:TextBox ID="Quantity" runat="server" Text= '<%# Eval("Quantity") %>' style="width:auto" AutoPostBack="true" OnTextChanged="Quantity_TextChanged" DataFormatString="{0:n2}" ></asp:TextBox>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                                                      runat="server" Enabled="True" TargetControlID="Quantity"
                                                                      ValidChars=".0123456789">
                                 </ajaxToolkit:FilteredTextBoxExtender>
                             </ItemTemplate>
                         </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                                                    <asp:BoundField HeaderText="PrevPrice" DataField="PriceValue" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                                                    <asp:BoundField HeaderText="Price" DataField="PriceValue" />
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                                </Columns>
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True"
                                                    ForeColor="White" />
                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7"
                                                    ForeColor="#8C4510" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <uc2:MsgBox ID="msgBox" runat="server" />
                        </div>
                    </div>
                </div>
               <div id="cpPrint" class="container-fluid" style="margin-top: 2%;" runat="server" visible="true">
                    <div class="row">
                          <table style="border:none;width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; font-size: 14px; border:none"
                    </th>
                </tr>
         <tr>
       <%-- <td> <img src="../../Images/bdlogo.png" style="height:50px;margin-left:80px;margin-top:-100px" ></img></td>--%>
    
          <td>
         <div class="row"  style="margin-right:220px">
               <p style="text-align: center">               
            
        <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                             <p style="text-align:center">জাতীয় রাজস্ব বোর্ড</p>
                      
                    <%--    <p style="text-align:right; padding:5px;font-size:20px"><b style="border:1px solid gray;margin-right: 17px;">মূসক-৬.৪</b></p>--%>
                         <p style="text-align:center;font-size:20px"><strong>Receive /উৎপাদনের চালানপত্র</strong></p>
               <%--<p style="text-align:center">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (ঘ) দ্রষ্টব্য]</p>   --%>    
         </div>    
      </td>
    
      </table>
                      
                    </div>
                    <div class="row" style="margin-top: 4%">
                        <p style="margin-left: 35%">
                            নিবন্ধিত ব্যক্তির নামঃ
                            <asp:Label runat="server" ID="lblOrgName" />
                        </p>
                        <p style="margin-left: 35%">
                            নিবন্ধিত ব্যক্তির বিআইএনঃ 
                            <asp:Label runat="server" ID="lblOrgBinNo" />
                        </p>
                        <p style="margin-left: 35%">
                            চালান ইস্যুর ঠিকানাঃ
                            <asp:Label runat="server" ID="lblChallanAddress" />
                        </p>
                    </div>
                    <div class="row">
                        <div class="col-sm-6" style="width: 50%; float: left">
                            <p>
                                পণ্য গ্রহীতার নামঃ 
                                <asp:Label runat="server" ID="lblReceipentName" />
                            </p>
                            <p>
                                গ্রহীতার বিআইএনঃ 
                                <asp:Label runat="server" ID="lblReceipentBIN" />
                            </p>
                            <p>
                                গন্তব্যস্থলঃ 
                                <asp:Label runat="server" ID="lblTransport" />
                            </p>
                        </div>
                        <div class="col-sm-6" style="width: 49%; float: left">
                            <p>
                                চালানপত্র নম্বরঃ 
                                <asp:Label runat="server" ID="lblChallanNo" />
                            </p>
                            <p>
                                ইস্যুর তারিখঃ 
                                <asp:Label runat="server" ID="lblChallanIssueDate" />
                            </p>
                            <p>
                                ইস্যুর সময়ঃ 
                                <asp:Label runat="server" ID="lblChallanIssueTime" />
                            </p>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 3%">
                        <table class="table table-bordered" style="width: 100%; text-align: center; background: none; border-collapse: collapse">
                            <tr>
                                <td style="border: 1px solid gray">ক্রমিক নং
                                </td>
                                <td style="border: 1px solid gray">প্রকৃতি (উপকরণ বা উৎপাদিত পণ্য )
                                </td>
                                <td style="border: 1px solid gray">পণ্যের বিবরণ
                                </td>
                                <td style="border: 1px solid gray">পরিমাণ
                                </td>
                                <td style="border: 1px solid gray">মন্তব্য
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid gray">(১)
                                </td>
                                <td style="border: 1px solid gray">(২)
                                </td>
                                <td style="border: 1px solid gray">(৩)
                                </td>
                                <td style="border: 1px solid gray">(৪)
                                </td>
                                <td style="border: 1px solid gray">(৫)
                                </td>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="HaiMan"></asp:Label>
                            </tr>
                        </table>
                    </div>
                    <div class="row" style="margin-top: 10px">
                        <p>
                            দায়িত্ব প্রাপ্ত কর্মকর্তার স্বাক্ষর
                        </p>
                        <p>
                            নামঃ 
                            <asp:Label runat="server" ID="lblDutyOfficer" />
                        </p>
                    </div>
                     <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>

                </div>
                <asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" Style="float: right"
                    Text="Print" OnClientClick="return PrintPanel();" Visible="false" />
            </ContentTemplate>
             <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
            </Triggers>
        </asp:UpdatePanel>

    </div>
</asp:Content>
