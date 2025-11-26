<%@ page title="Opening Info" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_Itm_OpeningInfo, App_Web_jwpupl0k" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/bootstrap/bootstrap.css" />
    <style type="text/css">
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

        .hiddencol {
            display: none;
        }
            .wrapper1, .wrapper2 { width: 100%; overflow-x: scroll; overflow-y: hidden; }
        .wrapper1 { height: 20px; }
        .div1 { height: 20px; }
        .div2 { overflow:none; }
    </style>


    <script type="text/javascript">

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

        $(document).ready(function () {
            $("#<%= gvItem.ClientID %>").tablesorter();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $("#<%= gvItem.ClientID %>").tablesorter();
       });
       function setQuantityLevel() {
           //document.getElementById('<%= lblMsUnit.ClientID %>').innerHTML = document.getElementById('<%= drpUnit.ClientID %>'.
       }
        function keepScrollPosition() {
            var s = document.getElementById("divForMaster").scrollTop;
            document.getElementById("<%= scrollPos.ClientID %>").value = s;
        }
    </script>
    <script type="text/javascript">
        function keepScrollPosition() {
            var s = document.getElementById("divForMaster").scrollTop;
            document.getElementById("<%= scrollPos.ClientID %>").value = s;
        }
        function SetScroolBar() {
            document.getElementById("divForMaster").scrollTop = document.getElementById("<%= scrollPos.ClientID %>").value;
        }
        $(document).ready(function () {
            SetScroolBar();
        });

        function enablePercent(rdUtity) {

            document.getElementById("<%= drpVATRebate.ClientID %>").disabled = false;
    }

    function disablePercent(rdItemService) {

        document.getElementById("<%= drpVATRebate.ClientID %>").disabled = true;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="updatePanelTree" runat="server">
        <ContentTemplate>

            <div class="row" style="padding: 2%">
                <div class="col-sm-5">
                    <asp:TreeView ID="tvwCategory" runat="server" Font-Names="Verdana"
                        Font-Size="10pt" Height="350px" ShowLines="True" Style="z-index: 100; overflow: scroll; left: 38px; top: 226px"
                        Width="400px"
                        OnSelectedNodeChanged="tvwCategory_SelectedNodeChanged"
                        onscroll="keepScrollPosition();" Font-Bold="False" ForeColor="Black">
                        <SelectedNodeStyle Font-Bold="True" ForeColor="Black" />
                    </asp:TreeView>
                    <input id="scrollPos" runat="server" type="hidden" value="0" />

                    <asp:HiddenField ID="hnCategoryID" runat="server" />
                    <asp:HiddenField ID="hnCategoryLevel" runat="server" />
                    <asp:HiddenField ID="hnParentID" runat="server" />
                    <asp:Button ID="btnEditCategory" runat="server" Text="Edit Category" Style="margin-top: 5px" CssClass="button" OnClick="btnEditCategory_Click" Visible="False" />
                    <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" Style="margin-top: 5px"
                        CssClass="btn btn-primary" OnClick="btnAddCategory_Click" Visible="false" />
                    <asp:Button ID="btnAddSubCategory" runat="server" Text="Add Sub Category" Style="margin-top: 5px"
                        CssClass="btn btn-primary" OnClick="btnAddSubCategory_Click" Visible="false" />
                    <asp:Button ID="btnAddItems" runat="server" Text="Add Items" Style="margin-top: 5px"
                        CssClass="btn btn-primary" OnClick="btnAddItems_Click" Visible="false" />
                    <asp:Button ID="btnSaveOpeningBalance" runat="server" Text="Save" Style="background-color: #4CAF50; margin-top: 5px"
                        CssClass="btn-btn" OnClick="btnSaveOpeningBalance_Click" />
                    <asp:LinkButton ID="lnkOpening" runat="server" OnClick="lnkOpening_click" Visible="false">Back to Opening</asp:LinkButton>
                    <asp:HyperLink class="btn btn-primary" style="background-color:#4CAF50;" NavigateUrl="~/UI/Item/ImportExcelOpeningBalance.aspx" runat="server">Import Excel</asp:HyperLink>
                </div>
                <div class="col-sm-7" style="border: 1px solid gray">
                    <div class="page_title">
                        <asp:Label runat="server">Items</asp:Label>
                        <uc1:ItemNav ID="ItemNav" runat="server" />
                    </div>

                    <div class="itemGridDiv" style="overflow: scroll; height: 350px; width: 100%;">
                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False"
                            
                            CssClass="sGrid"
                            DataKeyNames="ItemID"
                            Width="100%">
                            <Columns>
                                <%--   <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif"
                                    SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />--%>
                                <asp:BoundField DataField="UNIT_ID" HeaderText="Unit Id"/>
                                 <asp:TemplateField HeaderText="Add Additional Information?">
                                            
                                            <ItemTemplate >
                                                <asp:CheckBox ID="chkExcel" runat="server" OnCheckedChanged="ChckedChanged" AutoPostBack="true"/>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" />
                                <asp:BoundField DataField="hs_code" HeaderText="HS Code" />
                                <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                                <asp:BoundField DataField="ITEM_SPECIFICATION" HeaderText="Item Specification" Visible="false" />
                                <asp:BoundField DataField="PROP1_REQUIRED" HeaderText="Property1" Visible="false" />
                                <asp:BoundField DataField="PROP2_REQUIRED" HeaderText="Property2" Visible="false" />
                                <asp:BoundField DataField="PROP3_REQUIRED" HeaderText="Property3" Visible="false" />
                                <asp:BoundField DataField="PROP4_REQUIRED" HeaderText="Property4" Visible="false" />
                                <asp:BoundField DataField="PROP5_REQUIRED" HeaderText="Property5" Visible="false" />
                                <asp:TemplateField HeaderText="Item Qty.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQuantity" Text='<%#Eval("item_qty") %>' runat="server" DataFormatString="{0:n}" CssClass="input-short-bst" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="ftbGridQuantity"
                                                    runat="server" Enabled="True" TargetControlID="txtQuantity" 
                                                    ValidChars=".0123456789">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Unit Price.">
                                    <ItemTemplate>
                                         <asp:TextBox ID="txtUnitPrice" Text='<%#Eval("unit_price") %>' runat="server" DataFormatString="{0:n}" CssClass="input-short-bst" AutoPostBack="true" OnTextChanged="txtUnitPrice_TextChanged"></asp:TextBox>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="ftbGridUnitPrice"
                                                    runat="server" Enabled="True" TargetControlID="txtUnitPrice" 
                                                    ValidChars=".0123456789">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtValue" Text='<%#Eval("item_value") %>' runat="server" DataFormatString="{0:n}" CssClass="input-short-bst"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbGridValue"
                                                    runat="server" Enabled="True" TargetControlID="txtValue" 
                                                    ValidChars=".0123456789">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Balance Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtdate" Text='<%#Eval("opening_balance_date") %>' runat="server" DateFormat="dd/MM/yyyy" CssClass="input-short-bst" OnTextChanged= "txtdate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="ftbGridQuantity"
                                                    runat="server" Enabled="True" TargetControlID="txtValue" 
                                                    ValidChars=".0123456789">
                                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                                        <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtdate" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Purchase Type">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpPurchaseType" runat="server" DateFormat="dd/MM/yyyy" CssClass="input-short-bst" AutoPostBack="true">
                                            <asp:ListItem Value="L">Local</asp:ListItem>
                                            <asp:ListItem Value="I">Import</asp:ListItem>
                                            <asp:ListItem Value="F">Finished Product Production</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:BoundField DataField="item_id" HeaderText="Item Id" />--%>
                            </Columns>
                            <%--  <SelectedRowStyle BackColor="#B5EAAA" Font-Bold="True" ForeColor="#333333" />
                            <EmptyDataTemplate>No Items Found.</EmptyDataTemplate>--%>
                        </asp:GridView>
                    </div>
                    <asp:Label ID="lblTotalRow" runat="server" Text=""></asp:Label>
                </div>
            </div>

             <div class="row" runat="server" id="part_e">
                    <div class="row" style="padding-left: 25px; padding-right: 18px;" runat="server" id="divexcelProp">

                               <div class="test-label">
                                                                             
                                        <asp:Label ID="Label8" runat="server" ForeColor="Green" Font-Bold="true"  >Enter the Additional Property in Excel Header: </asp:Label>
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
                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload and Check" CssClass="btn btn-primary btn-sm" />
                        <asp:Label ID="Label29" runat="server"></asp:Label>
                        <%--<asp:Button ID="btnExcelSave" runat="server" OnClick="btnExcelSave_Click" Text="Save" CssClass="btn-btn"  style="background-color:#4CAF50"/>--%>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
             <div class="row">
        <div class="panel panel-primary">
            <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                <div class="container-fluid">
                  <div class="gridDiv table-responsive paddingsmall" runat="server">
                                <div class="wrapper1">
                                    <div class="div1"></div>
                                 </div>
                              <div class="wrapper2">
                                   <div class="">
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
            <div id="pnAddCategory" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 25%; padding: 1%">
                <div class="row" style="text-align: center">
                    <asp:Label ID="Label3" runat="server" Style="font-size: 30px; font-weight: bold">Add Cateogry</asp:Label><hr />
                </div>

                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="lblCategoryName" runat="server" Text="Category Name :" Style="margin-left: 20%"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" Style="height: 27px; padding: 0px; width: 185px"></asp:TextBox>
                    </div>
                    <div class="col-sm-1" style="padding: 0px">
                        <asp:RequiredFieldValidator ID="rfdCategoryName" runat="server" ErrorMessage="Category Name is mandatory."
                            ToolTip="Category Name is mandatory." ValidationGroup="addCategory"
                            ControlToValidate="txtCategoryName" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="lblCatDesc" runat="server" Text="Description :" Style="margin-left: 39%"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Style="height: 27px; padding: 0px; width: 185px"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-top: 2%">
                    <asp:Button ID="btnSaveCategory" runat="server" Text="Save" CssClass="btn btn-primary" Style="margin-left: 57%"
                        ValidationGroup="addCategory" OnClick="btnSaveCategory_Click" />
                    &nbsp;
    <asp:Button ID="btnCatClear" runat="server" Text="Close" CssClass="btn btn-danger" /><br />
                </div>
                <div class="row">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="addCategory" ForeColor="Red" />
                </div>
            </div>
            <asp:Button ID="btnHiddenForAddCategory" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="modalPopupForAddCategory" runat="server"
                PopupControlID="pnAddCategory"
                TargetControlID="btnHiddenForAddCategory" BackgroundCssClass="mpBack">
            </ajaxToolkit:ModalPopupExtender>

            <div id="pnSubCategory" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 25%; padding: 2%">
                <div class="row" style="text-align: center">
                    <asp:Label runat="server" Style="font-size: 30px; font-weight: bold">Add Sub Cateogry<hr /></asp:Label>
                </div>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="Label1" runat="server" Text="Category Name:" Style="margin-left: 20px"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:DropDownList ID="drpCategory" runat="server" CssClass="form-control" Style="height: 27px; padding: 0px; width: 176px"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="lblSubCategory" runat="server" Text="Sub Category :" Style="margin-left: 27px"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:TextBox ID="txtSubCategory" runat="server" CssClass="form-control" Style="height: 27px; padding: 0px; width: 176px"></asp:TextBox>
                    </div>
                    <div class="col-sm-1" style="padding: 0px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtSubCategory" ErrorMessage="Sub Category Name is mandatory."
                            ToolTip="Sub Category Name is mandatory." ValidationGroup="addSubCategory"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="lblDesc" runat="server" Text="Description :" Style="margin-left: 43px"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:TextBox ID="txtSubDesc" runat="server" CssClass="form-control" Style="height: 27px; padding: 0px; width: 176px"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-top: 2%">
                    <asp:Button ID="btnSaveSubCategory" runat="server" Text="Save" Style="margin-left: 55%" CssClass="btn btn-primary" ValidationGroup="addSubCategory" OnClick="btnSaveSubCategory_Click" />
                    &nbsp;
                     
                    <asp:Button ID="btnSubClear" CssClass="btn btn-danger" runat="server" Text="Close" />
                </div>

                <div class="row" style="margin-top: 2%">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                        ValidationGroup="addSubCategory" ForeColor="Red" />
                </div>
            </div>

            <asp:Button ID="btnHideForSubCategory" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="modalPopupForSubCategory" runat="server" PopupControlID="pnSubCategory"
                TargetControlID="btnHideForSubCategory" BackgroundCssClass="mpBack">
            </ajaxToolkit:ModalPopupExtender>
            <div id="pnItem" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 50%; padding: 2%">
                <div class="row" style="text-align: center">
                    <asp:Label runat="server" Style="font-size: 30px; font-weight: bold">Add New Item</asp:Label>
                    <hr />
                </div>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="lblItemCategory" runat="server" Text="Category Name:"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpItemCategory" runat="server" class="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2" style="padding: 0px">
                            <asp:RequiredFieldValidator ID="rfvItemCategory" runat="server"
                                ControlToValidate="drpItemCategory"
                                ErrorMessage="Item category name is mandatory." SetFocusOnError="True"
                                ToolTip="Item category name is mandatory." ValidationGroup="addItem">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="padding: 0px">
                            <asp:Label ID="lblTypeofMsnt" runat="server" Text="Measurement Type:"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpTypeofMsnt" runat="server" CssClass="form-control" Style="width: 115%; padding: 0px; height: 27px" OnSelectedIndexChanged="drpTypeofMsnt_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-1" style="padding: 0px">
                            <asp:RequiredFieldValidator ID="rfvMsntType" runat="server"
                                ControlToValidate="drpTypeofMsnt" ErrorMessage="Mesurement type is mandatory."
                                SetFocusOnError="True" ToolTip="Mesurement type is mandatory."
                                ValidationGroup="addItem">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="lblItemSubCategory" runat="server" Text="Sub-category:" Style="margin-left: 12%"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpItemSubCategory" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="padding: 0px">
                            <asp:Label ID="lblUnit" runat="server" Text="Unit :" Style="margin-left: 68%"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpUnit" runat="server" Style="width: 115%; padding: 0px; height: 27px" onchange="setQuantityLevel();" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-1" style="padding: 0px">
                            <asp:RequiredFieldValidator ID="rfvUnit" runat="server"
                                ControlToValidate="drpUnit" ErrorMessage="Item Unit is mandatory."
                                SetFocusOnError="True" ToolTip="Item Unit is mandatory."
                                ValidationGroup="addItem">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="lblItemName" runat="server" Text="Item Name :" Style="margin-left: 25%"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                        <div class="col-sm-2" style="padding: 0px">
                            <asp:RequiredFieldValidator ID="rfvItemName" runat="server"
                                ControlToValidate="txtItemName" ErrorMessage="Item Name is mandatory."
                                ToolTip="Item Name is mandatory." ValidationGroup="addItem"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="padding: 0px">
                            <asp:Label ID="lblStockAlertQty" runat="server" Text="HS Code Heading :" Style="margin-left: 3%"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtHSHeading" runat="server" CssClass="form-control" Style="width: 115%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                        <div class="col-sm-1" style="padding: 0px">
                            <asp:Label ID="lblMsUnit" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="lblSpecification" runat="server" Text="Specification :" Style="margin-left: 13%"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtSpecification" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                        <div class="col-sm-2" style="padding: 0px"></div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="padding: 0px">
                            <asp:Label ID="lblReOrderQty" runat="server" Text="HS Code Suffix :" TabIndex="9" Style="margin-left: 16%"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtHSSuffix" runat="server" CssClass="form-control" Style="width: 115%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                        <div class="col-sm-1" style="padding: 0px">
                            <asp:Label ID="lblMsUnit2" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="lblBrandName" runat="server" Text="Brand Name :" Style="margin-left: 13%"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtBrandName" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                        <div class="col-sm-2" style="padding: 0px"></div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="padding: 0px">
                            <asp:Label ID="lblSpecification0" runat="server" Text="Product Type:" Style="margin-left: 15px"></asp:Label>
                        </div>
                        <div class="col-sm-3" style="padding: 0px">
                            <asp:RadioButton ID="rdItem" runat="server" Checked="True" GroupName="itemType" onclick="disablePercent(this);" Text="Item" OnCheckedChanged="rdService_CheckedChanged" AutoPostBack="true" /><br />
                            <asp:RadioButton ID="rdService" runat="server" GroupName="itemType" onclick="disablePercent(this);" Text="Service" OnCheckedChanged="rdService_CheckedChanged" AutoPostBack="true" /><br />
                            <asp:RadioButton ID="rdUtility" runat="server" GroupName="itemType" onclick="enablePercent(this);" Text="Utility" OnCheckedChanged="rdService_CheckedChanged" AutoPostBack="true" />
                        </div>
                        <div class="col-sm-5" style="padding: 0px">
                            <asp:DropDownList ID="drpProductType" runat="server" CssClass="form-control" Style="padding: 0px; height: 27px">
                                <asp:ListItem Selected="True" Value="R">Raw Material</asp:ListItem>
                                <asp:ListItem Value="F">Goods</asp:ListItem>
                                <asp:ListItem Value="P">Finished Product</asp:ListItem>
                                <asp:ListItem Value="C">Finished Product (Production)</asp:ListItem>
                                <asp:ListItem Value="W">Real-estate Property</asp:ListItem>
                                <%--// Wealth = Land And Building--%>
                            </asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="padding: 0px">
                            <asp:Label runat="server" Style="margin-left: 27%;">Item Property:</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:Panel ID="PnlCust" runat="server" CssClass="PnlDesign">
                                <asp:CheckBoxList ID="drpItemProperty" runat="server" Style="width: 100%"></asp:CheckBoxList>
                            </asp:Panel>
                        </div>
                        <div class="col-sm-1" style="padding: 0px"></div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4 text-right">
                            <asp:Label ID="Label233" runat="server" Text="SKU :"></asp:Label>
                            <asp:Label ID="lblReOrderQty0" runat="server" Text="Rebatable :"></asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox runat="server" ID="txtSKUCode" CssClass="form-control" Style="height: 27px" MaxLength="10" />
                            <asp:DropDownList ID="drpVATRebate" runat="server" CssClass="form-control" Style="width: 100%; height: 27px; padding: 0px">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                                <asp:ListItem>70</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>90</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2" style="padding-top: 3%">
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="%"></asp:Label>

                        </div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="padding: 0px">
                            <asp:CheckBox ID="chkProOne" runat="server" />
                            <asp:CheckBox ID="chkProTwo" runat="server" />
                            <asp:CheckBox ID="chkProThree" runat="server" />
                            <asp:CheckBox ID="chkProFour" runat="server" />
                            <asp:CheckBox ID="chkProFive" runat="server" />
                            <asp:HiddenField ID="hnItemID" runat="server" />
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:CheckBox ID="chkIsExpiryDtRequired" runat="server" Text="Expiry Date Required" /><br />
                            <asp:CheckBox ID="chkIsExempted" runat="server" Text="Exempted" /><br />
                            <asp:CheckBox ID="chkIsRebatable" runat="server" Text="Rebatable" /><br />
                            <asp:CheckBox ID="chkIsVDS" runat="server" Text="VDS" />
                            <asp:CheckBox ID="chkIsSupplierRequired" runat="server" Text="Supplier Required" Visible="False" />
                        </div>
                        <div class="col-sm-1" style="padding: 0px"></div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <asp:Button ID="btnSave" runat="server" Style="background-color: #4CAF50; margin-left: 42%" CssClass="btn-btn" OnClick="btnSaveItem_Click" Text="Save" ValidationGroup="addItem" />
                    <asp:Button ID="btnItemSCancel" runat="server" CssClass="btn btn-danger" Text="Close" />
                </div>
                <div class="row" style="margin-top: 2%">
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="addItem" ForeColor="Red" />
                </div>
            </div>

            <asp:Panel ID="Panel1" CssClass="popupBlock" runat="server">
                <uc2:MsgBox ID="msgBox" runat="server" style="margin-top: 110%" />
            </asp:Panel>

            <ajaxToolkit:CascadingDropDown ID="cddItemCategory"
                runat="server"
                TargetControlID="drpItemCategory"
                Category="Category"
                PromptText="Select Category...."
                LoadingText="Please wait ..."
                ServicePath="~/WebService.asmx"
                ServiceMethod="GetCategory">
            </ajaxToolkit:CascadingDropDown>
            <ajaxToolkit:CascadingDropDown ID="cddItemSubCategory"
                runat="server"
                TargetControlID="drpItemSubCategory"
                ParentControlID="drpItemCategory"
                Category="Sub Category"
                LoadingText="Please wait ..."
                ServicePath="~/WebService.asmx"
                ServiceMethod="GetSubCategoryByCategory">
            </ajaxToolkit:CascadingDropDown>


            <asp:Button ID="btnHideForAddItem" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="modalPopupForAddItem" runat="server"
                PopupControlID="pnItem"
                TargetControlID="btnHideForAddItem" BackgroundCssClass="mpBack">
            </ajaxToolkit:ModalPopupExtender>

        </ContentTemplate>
        <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
            </Triggers>
    </asp:UpdatePanel>
   <%-- <div class="row">
           <div class="col-md-6">
                            <asp:FileUpload ID="FileUpload1" runat="server" Style="background: #E0EBF5" />
                            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload and Check" CssClass="btn btn-primary btn-sm" />
                            <asp:Label ID="Label11" runat="server"></asp:Label>
                            <asp:Button ID="btnExcelSave" runat="server" OnClick="btnExcelSave_Click" Text="Save" CssClass="btn btn-primary btn-sm" />
                        </div>
    </div>--%>

<%--  <div class="gridDiv table-responsive paddingsmall">
        <div class="wrapper1">
                        <div class="div1"></div>
                    </div>
                    <div class="wrapper2">
                    <div class="div2">
                                <asp:GridView ID="gvExcelFile" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                  DataKeyNames="ItemID"  OnRowDataBound="gvExcelFile_OnRowDataBound" BackColor="White"
                                 BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" Width="100%">
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
       </div>--%>
    <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 13.06.2021
            </div>    

</asp:Content>
