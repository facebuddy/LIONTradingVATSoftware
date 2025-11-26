<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_RebateAdjustment, App_Web_znns2ib5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
     <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>

      <script type="text/javascript">
        function addVat(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;
            var jsGvChallanItem = document.getElementById("<%=gvIngredience.ClientID%>");

            var IsChecked = chkB.checked;
            if (IsChecked) {
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else {
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }
        }

        function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvPurchase2.ClientID%>");
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 30px; padding-top: 0px">রেয়াত সমন্বয়</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                        <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">From Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="dtpFromDate" DateFormat="dd/MM/yyyy" />
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpFromDate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">To Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="dtpToDate" DateFormat="dd/MM/yyyy" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpToDate" />
                                        </div>
                                    </div>
                                </div>
                             <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Tax Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpTaxTyp" runat="server" class="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="drpTaxTyp_SelectedIndexChanged">
                                            <asp:ListItem Value="1">VAT</asp:ListItem>
                                             <asp:ListItem Value="2">SD</asp:ListItem> 
                                                 </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                              
                             <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Item Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpSaleItem" runat="server" class="form-control select2">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            <%--  <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Ingridience Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpItem" runat="server" class="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>--%>
                               <%-- <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Challan No :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpChallanNo" runat="server" class="form-control select2"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>--%>

                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">সরবরাহের প্রকৃতি :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpSaleType" runat="server" class="form-control select2">
                                                <asp:ListItem Value="1">শূন্যহার বিশিষ্ট পণ্য/সেবা</asp:ListItem>
                                                <asp:ListItem Value="3">অব্যাহতিপ্রাপ্ত পণ্য/সেবা</asp:ListItem>                                               
                                                <asp:ListItem Value="5">সর্বোচ্চ খুচরা মূল্যভিত্তিক পণ্য</asp:ListItem>
                                                 <asp:ListItem Value="6">সুনির্দিষ্ট কর ভিত্তিক পণ্য/সেবা</asp:ListItem>
                                                <asp:ListItem Value="7">আদর্শ করহার ব্যতীত ভিন্ন করহার ভিত্তিক পণ্য/সেবা</asp:ListItem>
                                                <asp:ListItem Value="8">খুচরা/পাইকারী/ব্যবসায়ী ভিত্তিক সরবরাহ</asp:ListItem>                                               
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        <div class="row">
                                <div class="col-md-12" style="text-align:right">
                                 
                                  <asp:TextBox ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px"></asp:TextBox>
                                      <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" Style="background-color: #3B7CB5;" Text="Search" OnClick="btnSearch_Click" /> 
                                    <asp:LinkButton ID="showBTN" runat="server" CssClass="btn btn-success" OnClick="showBTN_Click"><i class="fa fa-search-plus"></i> Report</asp:LinkButton>
                                    <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-info" OnClientClick=" return PrintPanel();"><i class="fa fa-print"></i>  Print</asp:LinkButton>
                                     
                                </div>
                              
                            </div>
                      <div class="row" style="margin: 10px">
                                <div class="panel panel-primary">
                                    <div class="panel-body">                                     

                                        <div class="">
                                            <asp:GridView ID="gvIngredience" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                                 Width="100%" OnSelectedIndexChanged="gvIngredience_SelectedIndexChanged"
                                                BackColor="#DEBA84" BorderColor="#DEBA84" OnRowDataBound="gvIngredience_RowDataBound"
                                                BorderStyle="None" BorderWidth="1px">
                                                <Columns>
                                       <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Item Id" DataField="item_id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Challan No" DataField="challan_no" />
                                        <asp:BoundField HeaderText="Challan Date" DataField="challan_date" />
                                        <asp:BoundField HeaderText="Item" DataField="item_name" FooterText="Total" />
                                        <asp:BoundField HeaderText="Quantity" DataField="quantity" />
                                        <asp:BoundField HeaderText="Unit Price" DataField="unit_price" />
                                        <asp:BoundField HeaderText="Total" DataField="price" />
                                        <asp:BoundField HeaderText="VAT" DataField="vat" />
                                        <asp:BoundField HeaderText="SD" DataField="sd" />
                                        <asp:BoundField HeaderText="Gross Total" DataField="grossTotal" />
                                        <asp:BoundField HeaderText="VAT Rate" DataField="vat_rate" />
                                        <asp:BoundField HeaderText="SD Rate" DataField="sd_rate" />                                                 
                                        <asp:BoundField HeaderText="Challan Id" DataField="challan_id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                                        <asp:BoundField HeaderText="Rebate Adjustment Amount" DataField="rebate_adjust_amount" />  
                                        <asp:BoundField HeaderText="Rebate Adjustment Date" DataField="rebate_adjust_date" />  
                                                            </Columns>
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                            </asp:GridView>
                                        </div>

                                         <div id="pnLocalPurchase" cssclass="popupBlock" runat="server" style="background: #C0C0C0; box-shadow: 10px 10px 5px #888888; width: 80%; margin-left: 9%;">
                <div class="row" style="text-align: center">
                    <asp:Label ID="Label3" runat="server" Style="font-size: 18px; font-weight: bold;font-family:Cambria, Cochin, Georgia, Times, Times New Roman, serif">Local Purchase Details</asp:Label>
                </div>
                <div class="row" style="margin-top: -4px; margin-right: 1%; margin-left: 1%;">
                    <asp:GridView ID="gvPurchase2" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                        CssClass="sGrid" DataKeyNames="RowId" Width="100%" ShowHeaderWhenEmpty="True" OnRowDataBound="gvPurchase2_RowDataBound">
                        <Columns>
                               <asp:TemplateField HeaderText="">
                                            <HeaderTemplate >
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)" ToolTip="Check to Select All Item" />
                                            </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkChallan" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" onclick="addVat(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Raw Materils Name" DataField="IngridienceName" />
                            <asp:BoundField HeaderText="Quantity" DataField="usedQuantity" />
                            <asp:BoundField HeaderText="Ingredients Price" DataField="usedTotalPrice" />                          
                            <asp:BoundField HeaderText="VAT" DataField="usedVATAmount" />
                            <asp:BoundField HeaderText="VAT Rate" DataField="usedVATRate" />
                            <asp:BoundField HeaderText="SD" DataField="usedSDAmount" />
                            <asp:BoundField HeaderText="SD Rate" DataField="usedSDRate" />
                         
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="row_no" Value='<%# Eval("RowId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        
                        <HeaderStyle Height="25px" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    </asp:GridView>
                      <div class="col-md-6">
                          <asp:Label ID="lblTotalRebateable" runat="server" Style="font-size: 16px; font-weight: bold;color:darkgreen;font-family:Cambria, Cochin, Georgia, Times, Times New Roman, serif">Total VAT Amount:</asp:Label>
                          <asp:TextBox ID="txtTotalRebateable" runat="server" Style="text-align:left;" ></asp:TextBox>
                      </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblCreditEx" runat="server" Style="font-size: 16px; font-weight: bold; color: darkgreen; font-family: Cambria, Cochin, Georgia, Times, Times New Roman, serif">হ্রাসকারী সমন্বয়</asp:Label>&nbsp&nbsp
                        <asp:Label ID="lblDebitEx" runat="server" Style="font-size: 16px; font-weight: bold; color: darkgreen; font-family: Cambria, Cochin, Georgia, Times, Times New Roman, serif">বৃদ্ধিকারী সমন্বয়</asp:Label>

                    </div>
                </div>
                  <div class="row">
                      <div style="height:3px;"></div>
                  </div>
            
                  <div class="row">
                      <div style="height:3px;"></div>
                  </div>
                 <div class="row" style="text-align: center">
                    <asp:Label ID="Label5" runat="server" Style="font-size: 18px; font-weight: bold;font-family:Cambria, Cochin, Georgia, Times, Times New Roman, serif"></asp:Label>
                </div>
              
               
                <div>
                    <asp:Button ID="btnUpdate" runat="server" Text="Save" CssClass="test-btn-primary" Style="margin-right: 12px; float: right"
                        ValidationGroup="addCategory"/>
                    &nbsp;
                    <asp:Button ID="btnCatClear" runat="server" Text="Close" CssClass="test-btn-primary" Style="float: right" />
                </div>
            </div>
            <asp:Button ID="btnHiddenForLocalPurchase" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="modalPopupForLocalPurchase" runat="server" PopupControlID="pnLocalPurchase"
                TargetControlID="btnHiddenForLocalPurchase" BackgroundCssClass="mpBack">
            </ajaxToolkit:ModalPopupExtender>
                                    </div>
                                </div>
                            </div>
                </div>
            </div>
             <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
