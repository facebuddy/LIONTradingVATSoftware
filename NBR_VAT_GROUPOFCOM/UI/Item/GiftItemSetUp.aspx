<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Item_GiftItemSetUp, App_Web_jwpupl0k" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<%--<!DOCTYPE html>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>

    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>

    <style media="print">
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Set Gift Items/Discount Plan
                </div>

                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    
                    <asp:TextBox runat="server" ID="hiddenPromoId" style="visibility:hidden;"></asp:TextBox>
                    
                    <div class="row" style="margin-top: 1%">
                           
                         <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label ID="label16" runat="server" class="control-label col-sm-5"><span class="required"> * </span>Date From:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" onkeydown="return (event.keyCode!=13);" Height="34px"
                                        onkeyup="FormatIt(this);" MaxLength="10" ID="txtDateFrom" placeholder="Enter here"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateFrom" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDateFrom"
                                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                        ErrorMessage="Invalid date format." CssClass="litMessage" />
                                </div>
                            </div>

                        </div>

                            <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label ID="label2" runat="server" class="control-label col-sm-5"><span class="required"> * </span>Date To:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" onkeydown="return (event.keyCode!=13);" Height="34px"
                                        onkeyup="FormatIt(this);" MaxLength="10" ID="txtDateTo" placeholder="Enter here"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cc12" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDateTo" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDateTo"
                                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                        ErrorMessage="Invalid date format." CssClass="litMessage" />
                                </div>
                            </div>

                        </div>

                        <div class="col-sm-3" Id="hiddenDate" style="visibility:hidden;">
                                 <asp:TextBox ID="txtHiddenDate" Style="width: 50%; float: left" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy" Enabled="false"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtHiddenDate" />
                                 <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                                 <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                         </div>

                    </div>



                    <table style="width:100%;border:hidden;">
                        <tr>

                            <td>
                                <fieldset class="scheduler-border" >
                                    <legend class="scheduler-border" >Item Wise</legend>
                                       <%--<H4 style="text-align:center;">Item Wise</H4>--%>
                                     <div class="row">
                                        <div class="col-sm-5">
                                            <div class="form-group">
                                                <asp:Label ID="label9" runat="server" Text="Category:" class="control-label col-sm-5" />
                                                <div class="col-sm-7">
                                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-input"
                                                        data-toggle="dropdown" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" Height="33px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>

                                        <%--<div class="col-sm-5">
                                            <div class="form-group">
                                                <asp:Label ID="label1" runat="server" Text="Sub Category:" class="control-label col-sm-5" />
                                                <div class="col-sm-7">
                                                    <asp:DropDownList ID="drpSubCategory" runat="server" class="form-input"
                                                        data-toggle="dropdown" AutoPostBack="True"
                                                        Height="33px"
                                                        OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>--%>
                                          <div class="col-sm-5">
                                            <div class="form-group">
                                                <asp:Label ID="label1" runat="server" Text="Sub Category:" class="control-label col-sm-5" />
                                                <div class="col-sm-7">
                                                    <asp:DropDownList ID="drpSubCategory" runat="server" class="form-input"
                                                        data-toggle="dropdown" AutoPostBack="True"
                                                        Height="33px"
                                                        OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                          

                        
                        
                    </div>

                        <div class="row" style="margin-top: 1%;" >
                                    

                                           <div class="col-sm-5">
                                    <div class="form-group">
                                        <asp:Label ID="label10" runat="server" class="control-label col-sm-5"><span class="required"> * </span>Item Name:</asp:Label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItemName" runat="server" class="form-input select2"
                                                data-toggle="dropdown"
                                                OnSelectedIndexChanged="ddlItemName_SelectedIndexChanged" Height="33px"
                                                AutoPostBack="True">
                                            </asp:DropDownList>

                                        </div>

                                        <div class="col-sm-3" style="display:none;">                                            
                                            
                                            <%--<asp:Label ID="label11" runat="server" class="control-label col-sm-5">Unit:</asp:Label>--%>
                                            <asp:DropDownList ID="drpItemUnit" CssClass="form-input select2" runat="server" Style="width: 80px;" AutoPostBack="true"></asp:DropDownList>

                                        </div>

                                    </div>
                                </div>
                                        


                                 <div class="col-sm-5">

                                    <div class="form-group">
                                     

                                        <asp:Label ID="label7" runat="server" class="control-label col-sm-5">Min. Qauntity:</asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox Id="txtMinItemQnt"   runat="server"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                runat="server" Enabled="True" TargetControlID="txtMinItemQnt"
                                                ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>

                                        </div>

                                                </div>

                                            </div>
                                    </div>

                                </fieldset> 
                            </td>


                            <td>

                                <fieldset class="scheduler-border" >

                                    <legend class="scheduler-border" >Sale Price Wise</legend>
                                     <%-- <H4 style="text-align:center;">Sale Price Wise</H4>--%>

                                    
                                        <div  class="row" style="margin-top: 1%; padding:20px;">

                                            <div class="col-sm-8">
                                                <div class="form-group">
                                                 <%--   <asp:Label ID="label10" runat="server" Text="Item Name:" class="control-label col-sm-5" />--%>
                                                    <asp:Label ID="label8" runat="server" class="control-label col-sm-5">Sale Min. Price:</asp:Label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox Id="txtMinSalePrice"  runat="server"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                            runat="server" Enabled="True" TargetControlID="txtMinSalePrice"
                                                            ValidChars=".0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    
                                </fieldset>
                            </td>

                        </tr>
                    </table>
  

                    <fieldset class="scheduler-border" >

                        <legend class="scheduler-border" >Prommotion Detail</legend>
                          <%--<H4 style="text-align:center;">Prommotion Detail</H4>--%>

                        <div class="row" style="padding-left:2%;">

                            <div class="test-label">
                                    <asp:Label ID="Label36" runat="server" Text="Gift Name:" Style="margin-left: 0px;" /><br />
                                    <asp:DropDownList ID="drpGiftItem" CssClass="present-address-tb select2" Style="width: 250px; margin-left: 0px; text-align: left"
                                        runat="server"  AutoPostBack="True" OnSelectedIndexChanged="drpGiftItem_SelectedIndexChanged" Height="27px" TabIndex="4" />
                                </div>

                                <div class="test-label">
                                    <asp:Label ID="Label34" runat="server" Text="Unit:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="lblGiftUnit" CssClass="present-address-tb hiddencol" runat="server" Style="width: 70px; height: 27px; margin-left: 0px"
                                        TabIndex="6"></asp:TextBox>
                                    <asp:DropDownList ID="drpGiftUnit" CssClass="unit select2" runat="server" Style="width: 80px" AutoPostBack="true"></asp:DropDownList>
                                     <asp:HiddenField ID="hdGiftUnitID" runat="server" Visible="false" /> 
                                </div>

                                <div class="test-label">
                                    <asp:Label ID="Label35" runat="server" Text="Gift Quantity:" Style="margin-left: 11px;" /><br />
                                    <asp:TextBox ID="txtGiftQnt" CssClass="present-address-tb" Style="height: 27px; width: 100px; margin-left: 0px"
                                        runat="server" AutoPostBack="True"
                                        TabIndex="5"></asp:TextBox>
                                    <asp:Label ID="Label39" runat="server" class="hiddencol" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14"
                                        runat="server" Enabled="True" TargetControlID="txtGiftQnt"
                                        ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                                <div class="test-label hiddencol">
                                    <asp:Label ID="Label48" runat="server" Text="" Style="margin-left: 0px;" />
                                    <asp:TextBox ID="txtHiddenGiftQnt" CssClass="category" runat="server"/>                                   
                                </div>
                                <div class="test-label hiddencol" >
                                    <asp:Label ID="Label49" runat="server" Text="" Style="margin-left: 0px;" />
                                    <asp:TextBox ID="txtGiftItemUnitPrice" CssClass="category" runat="server"/>                                   
                                </div>

                                <div class="test-label"  style="padding-left:100px;padding-right:100px;">
                                    <asp:Label ID="Label5" runat="server" /><br />
                                    <b> <asp:Label ID="Label6" runat="server" Text="OR" /> </b>
                                    </div>

                               <div class="test-label">
                                    <asp:Label ID="Label3" runat="server" Text="Discount% :" Style="margin-left: 11px;" /><br />
                                    <asp:TextBox ID="txtDiscntPrcntg" CssClass="present-address-tb" Style="height: 27px; width: 100px; margin-left: 0px"
                                        runat="server" AutoPostBack="True"
                                        TabIndex="5"></asp:TextBox>
                                    <asp:Label ID="Label4" runat="server" class="hiddencol" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                        runat="server" Enabled="True" TargetControlID="txtDiscntPrcntg"
                                        ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>

                                 <div class="test-label">
                                    <asp:Label ID="Label11" runat="server" Text="Discount :" Style="margin-left: 11px;" /><br />
                                    <asp:TextBox ID="txtDiscountAmt" CssClass="present-address-tb" Style="height: 27px; width: 100px; margin-left: 0px"
                                        runat="server" AutoPostBack="True"
                                        TabIndex="5"></asp:TextBox>
                                    <asp:Label ID="Label12" runat="server" class="hiddencol" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                        runat="server" Enabled="True" TargetControlID="txtDiscountAmt"
                                        ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>

                                <div class="test-label">
                                        <asp:Label ID="Label46" Style="margin-left: 15px; float: left;" runat="server" Text="Remarks:"></asp:Label><br />
                                        <asp:TextBox ID="txtGiftRemarks" TextMode="MultiLine" runat="server" Style="float: left; width: 250px; text-align: left"
                                            CssClass="present-address-tb"></asp:TextBox>
                                </div>

                                <div class="test-label" style="padding-left:10px;">
                                    <br /> 
                                        <asp:Button ID="btnSaveGift" runat="server" class="btn-btn" Style="background-color: #B681B7" OnClick="btnSaveGiftGiftItem_Click" Text="Save Promo" />
                                 </div>

                        </div>
                     <%--   
                         <div style="padding-top: 5%;">
                                    <asp:GridView ID="gvGiftItem" runat="server" AutoGenerateColumns="False" 
                                        CssClass="mydatagrid" HeaderStyle-CssClass="gvheader" 
                                        RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                                    DataKeyNames="RowNo" Width="100%" OnRowDeleting="gvGiftItem_RowDeleting" OnSelectedIndexChanged="gvGiftItem_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField HeaderText="Item ID" DataField="ItemID" Visible="false" />
                                        <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                                        <asp:BoundField HeaderText="Quantity" DataField="GiftQuantity" DataFormatString="{0:n2}" />
                                        <asp:BoundField HeaderText="Unit ID" DataField="UnitID" Visible="false" />
                                        <asp:BoundField HeaderText="Unit" DataField="UnitName" />                                        
                                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="White" />
                                        </asp:GridView>
                                      </div>
                      --%>

                    </fieldset>

                   
                </div>
            </div>
            

                            <%--OnRowDataBound="gvPromo_RowDataBound"--%>
                           <%-- OnRowCommand="gvPromo_RowCommand"--%>

            <div class="panel panel-primary">
                <div class="panel-body">
                    <div class="">
                        <asp:GridView ID="gvPromos" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid"
                            DataKeyNames="entry_id" Width="100%"
                            OnSelectedIndexChanged="gvPromo_SelectedIndexChanged"
                            OnRowDeleting="gvPromo_RowDeleting" OnRowDataBound="gvPromo_RowDataBound"
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            AllowPaging="true" PageSize="10" OnPageIndexChanging="gvPromo_PageIndexChanging">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:BoundField DataField="entry_id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                                <asp:BoundField HeaderText="Parent Item Name" DataField="parent_item_name" />
                                <asp:BoundField HeaderText="Parent Item Id" DataField="parent_item_id"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                                <asp:BoundField HeaderText="Minimum Parent Item Qnt." DataField="parent_item_qnt" />
                                <asp:BoundField HeaderText="Min. Sale Price" DataField="min_sale_amount" />
                                <asp:BoundField HeaderText="Parent Unit Name" DataField="parent_unit_code" />
                                <asp:BoundField HeaderText="Parent Unit Id" DataField="parent_item_unit" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"  />
                                <asp:BoundField HeaderText="Gift Item Name" DataField="gift_item_name" />
                                <asp:BoundField HeaderText="Gift Item Id" DataField="gift_item_id"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                                <asp:BoundField HeaderText="Gift Unit Name" DataField="gift_unit_code" />
                                <asp:BoundField HeaderText="Gift Unit Id" DataField="gift_unit_id"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                                <asp:BoundField HeaderText="Gift Quantity" DataField="gift_qnt" />
                                <asp:BoundField HeaderText="Discount(%)" DataField="discount_percentage" />
                                <asp:BoundField HeaderText="Discount Amount" DataField="discount_amount" />
                                <asp:BoundField HeaderText="Promo Type" DataField="promo_type" />
                                <asp:BoundField HeaderText="Date From" DataField="date_from" />
                                <asp:BoundField HeaderText="Date To" DataField="date_to" />
                                <asp:BoundField HeaderText="Remarks" DataField="remarks" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                <%--<asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Details" runat="server" CommandName="Details" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <uc1:MsgBoxs runat="server" ID="msgBox" />
<%--    <uc2:MsgBox ID="msgBox" runat="server" />--%>
</asp:Content>
