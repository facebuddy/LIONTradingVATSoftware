<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Sale_InstallmentPaymentSchedule, App_Web_lqwzozjx" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
      <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    .
     <link href="../../Styles/panel.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <style>
          .hiddencol {
            display: none;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                           Installment Payment Scheduler
                          
                        </div>
                          
                        <div class="panel-body" style="padding-right: 0px; padding-bottom: 30px">
                            <div class="container-fluid">
                           <div class="row" runat="server" id="div_a">
                                    <div class="test-label">
                                        <asp:Label ID="Label7" runat="server" Text="Category :"></asp:Label><br />
                                        <asp:DropDownList ID="drpCategory" CssClass="present-address-tb select2" runat="server" Style="width: 80px; height: 27px; margin-left: 0px; text-align: left"
                                            OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                            AutoPostBack="True" TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label15" runat="server" Text="Sub Cat:"></asp:Label><br />
                                        <asp:DropDownList ID="drpSubCategory" CssClass="present-address-tb select2" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged"
                                            Style="width: 80px; height: 27px; margin-left: 0px; text-align: left" TabIndex="2">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="test-label" style="display: none;">
                                        <asp:Label ID="Label40" runat="server" Text="Search Product:" /><br />
                                        <asp:TextBox ID="productName" CssClass="present-address-tb" AutoPostBack="true" Style="width: 160px; height: 27px; margin-left: 0px; text-align: left"
                                            placeholder="Search Product"
                                            runat="server"  TabIndex="3" />
                                        <div id="listPlacement" style="height: 100px; overflow: scroll;">
                                        </div>
                                        <ajaxToolkit:AutoCompleteExtender ID="accProductName" runat="server" TargetControlID="productName"
                                            ServicePath="~/WebService.asmx" CompletionListElementID="listPlacement" MinimumPrefixLength="1"
                                            EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="GetSaleProductByProductName">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label16" runat="server" Text="Item Name & SKU:" Style="margin-left: 0px;" />
                                        <asp:Label ID="lblSku" runat="server"></asp:Label><br />
                                        <asp:DropDownList ID="drpItem" CssClass="present-address-tb select2" Style="width: 250px; margin-left: 0px; text-align: left"
                                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpItem_SelectedIndexChanged"
                                            Height="27px" TabIndex="4" />
                                        <asp:Label runat="server" ID="lblProductType" Visible="false" /><br />
                                       
                                    </div>
                                    <div class="test-label">
                                        <asp:HiddenField runat="server" ID="txtSpecification" />

                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label17" runat="server" Text="HS Code:" /><br />
                                        <asp:TextBox ID="lblHSCode" CssClass="present-address-tb" runat="server" Style="width: 80px; height: 27px; margin-left: 0px"
                                            Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="test-label hiddencol">
                                        <asp:Label ID="Label25" runat="server" Text="Batch No" /><br />
                                        <asp:TextBox ID="txtBatchNo" CssClass="present-address-tb" Style="width: 80px; margin-left: 0px; text-align: left"
                                            runat="server" Height="27px" TabIndex="4"></asp:TextBox>
                                        <%--<asp:TextBox ID="txtBatchNo" CssClass="present-address-tb select2" Style="width: 75px; margin-left: 0px; text-align: left"
                                                          runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtBatchNo_SelectedIndexChanged"
                                                          Height="27px" TabIndex="4" />--%>
                                        <%--<asp:TextBox ID="txtBatchNo" CssClass="present-address-tb" Style="width: 75px; margin-left: 0px; text-align: left"                                                          runat="server"
                                                          Height="27px" TabIndex="4" ></asp:TextBox>
                                        --%>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label18" runat="server" Text="Quantity:" Style="margin-left: 11px;" /><br />
                                        <asp:TextBox ID="txtFinalQuantity" CssClass="present-address-tb" Style="height: 27px; width:100px; margin-left: 0px"
                                            runat="server" AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"
                                            TabIndex="5"></asp:TextBox>
                                        <asp:Label ID="lblQuantityPrp" runat="server" class="hiddencol"  />
                                        <asp:Label ID="Label13" Style="margin-left: -60px;color: #008000;font-weight:bold" runat="server" Text="Avl. Stock:"  CssClass="hiddencol"></asp:Label>
                                        <asp:Label ID="lblAvailStock" Style="color: #008000;font-weight:bold"  runat="server" CssClass="hiddencol"></asp:Label>
                                         <asp:Label ID="lblavlStock" Style="color: #008000;font-weight:bold"  runat="server"  CssClass="hiddencol"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                            runat="server" Enabled="True" TargetControlID="txtQuantity"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label hiddencol">
                                    <asp:Label ID="Label29" runat="server" Text="" Style="margin-left: 0px;" />
                                    <asp:TextBox ID="txtQuantity" CssClass="category" runat="server"/> 
                                         <%--<asp:TextBox ID="txtMinQntForPromo" CssClass="category" Text="0" runat="server"/>--%>    <%--<sabbir 16/3/21> --%>                              
                                </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label41" runat="server" Text="Unit:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="lblUnit" CssClass="hiddencol" runat="server" Style="width: 70px; height: 27px; margin-left: 0px"
                                            TabIndex="6"></asp:TextBox>
                                         <asp:DropDownList ID="drpUnit" CssClass="unit select2" runat="server" Style="width: 80px" ></asp:DropDownList>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label22" runat="server" Text="Unit Price:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtUnitPrice" CssClass="present-address-tb" Style="width:100px; height: 27px; margin-left: 0px"
                                            runat="server" AutoPostBack="True" OnTextChanged="txtUnitPrice_TextChanged"
                                            TabIndex="7" />
                                        <asp:Label ID="lblUnitPrice" runat="server" Text="" Style="margin-left: 0px;" Visible="false" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                            runat="server" Enabled="True" TargetControlID="txtUnitPrice"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label5" runat="server" Text="Price:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtTotalPrice" CssClass="category" Style="background-color: #CAFDD2; width:130px;" runat="server" ReadOnly="true" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                            runat="server" Enabled="True" TargetControlID="txtTotalPrice"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label6" runat="server" Text="Price(Inc. VAT)" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtPriceIncludingVat" CssClass="category" Style="background-color: #CAFDD2; width: 130px;" runat="server" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                            runat="server" Enabled="True" TargetControlID="txtPriceIncludingVat"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label42" runat="server" Text="VAT:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="tbTotalVAT" CssClass="present-address-tb" Style="width: 100px; height: 27px; margin-left: 0px"
                                            runat="server" AutoPostBack="True" TabIndex="8"></asp:TextBox>
                                       <asp:Label ID="lblfxdVT" runat="server" Text="" /> <asp:Label ID="lblVAT" runat="server" Text="" /><asp:Label ID="Label9" runat="server"
                                            Text="%"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                            runat="server" Enabled="True" TargetControlID="tbTotalVAT"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="test-label">
                                        <asp:Label ID="Label43" runat="server" Text="SD:" Style="margin-left: 0px;" /><br />
                                        <asp:TextBox ID="txtTotalSD" CssClass="present-address-tb" Style="width:100px; height: 27px; margin-left: 0px"
                                            runat="server" AutoPostBack="True" TabIndex="9"></asp:TextBox>
                                        <asp:Label ID="lblSD" runat="server" Text="" /><asp:Label ID="Label11" runat="server"
                                            Text="%"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                            runat="server" Enabled="True" TargetControlID="txtTotalSD"
                                            ValidChars=".0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>


                           </div>
                               
                              </div>
                              </div>
                 
                    <div class="panel-group">
                      <div class="panel panel-primary">
                          <div class="panel-body">
                              <div class="row">
                                  
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>Customer :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpParty" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>                              
                              
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Loan From Date:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtfromDate" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                             <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtfromDate" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Loan To Date</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txttoDate" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                             <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txttoDate" />
                                        </div>
                                    </div>
                                 </div>
                               </div>
                        
                           <div class="row">
                                   <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>Agreement No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtAgreement" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                             <asp:HiddenField ID="hdBookId" runat="server" />
                                        <asp:HiddenField ID="hdPageNo" runat="server" />
                                        </div>
                                    </div>
                                </div>  
                                <div class="col-md-4 hiddencol">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>Years of Loan :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtnoofInstalment" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtnoofInstalment_OnTextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>                              
                              
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Total Installment Month:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtInstallmentmonth" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtInstallmentmonth_OnTextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">4.3 wise price:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtPriceDec" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                          
                                        </div>
                                    </div>
                                </div>     
                               </div>
                           <div class="row">
                             
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>Down Payment :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtDownPayment" CssClass="form-control" runat="server"  AutoPostBack="true" OnTextChanged="txtDownPayment_OnTextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>    
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Schedule Create Amount :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtSchedulerAmount" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>   
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Interest Rate:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtInterestRate" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                 </div>                          
                             </div>  
                           <div class="row">
                                  
                                   <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Installment Interset Amount:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtinterestAmount" CssClass="form-control" runat="server"  AutoPostBack="true" OnTextChanged="txtinterestAmount_OnTextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>                        
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Monthly Installment Amount:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtMonthInstallment" CssClass="form-control" runat="server"   AutoPostBack="true" OnTextChanged="txtinterestAmount_OnTextChanged"></asp:TextBox>
                                          
                                        </div>
                                    </div>
                                </div>
                               
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Product Price with Interest:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtProductPrice" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>    
                               </div>
                           <div class="row">
                                  
                                                   
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Discount %:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtdiscountpct" CssClass="form-control" runat="server"></asp:TextBox>
                                          
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Discount:</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtdiscountAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                               <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">For Last Installment Amount::</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtlstInsAmnt" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                               </div>

                              <div class="row" Style="margin-top: 10px;">
                                    <div class="test-btn">
                                        <asp:Button ID="btnGenerate" runat="server" Style="background-color: #4CAF50" class="btn-btn" Text="Generate Schedule" OnClick="btnGenerate_Click"/>
                                    </div>
                                    <div class="test-btn">
                                        <asp:Button ID="btnSave" runat="server" Style="background-color: #4CAF50" class="btn-btn" Text="Save" OnClick="btnSave_Click"/>
                                    </div>
                                </div>
                                <div class="row" >
                                     <asp:GridView ID="grdInstalment" runat="server" AutoGenerateColumns="False"
                            CssClass="mydatagrid" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" Width="100%">
                            <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderTemplate >                                                
                                            </HeaderTemplate>
                                            <ItemTemplate >
                                                <asp:CheckBox ID="chkChallan" runat="server"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:BoundField HeaderText="Schedule No" DataField="scheduleNo"/>
                               <asp:BoundField HeaderText="Monthly Installment  with Interest " DataField="paymentWithInterest"  DataFormatString="{0:n}"/>
                                <asp:BoundField HeaderText="Vatable Price " DataField="paymentWithoutInterest"  DataFormatString="{0:n}"/>
                                <asp:BoundField HeaderText="VAT" DataField="restvat"  DataFormatString="{0:n}"/>
                              <%--  <asp:BoundField HeaderText="Interest" DataField="restInterest"  DataFormatString="{0:n}"/>--%>
                                                         
                            </Columns>
                        </asp:GridView>
                                </div>
                               </div>

                         </div>
                      </div>
                                   </div>
                      </div>  
                  <uc2:MsgBox ID="msgBox" runat="server" />
                        </ContentTemplate>
             </asp:UpdatePanel>
        </div>
    </asp:Content>