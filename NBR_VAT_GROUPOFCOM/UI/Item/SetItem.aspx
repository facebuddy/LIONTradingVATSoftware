<%@ page title="Set Items" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_SetItem, App_Web_jwpupl0k" enableeventvalidation="false" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
        <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/bootstrap/bootstrap.css" />
    <link href="../../Styles/panel.css" rel="stylesheet" />  
    <link href="../../Styles/str.css" rel="stylesheet" />
  

    <style type="text/css">
        hr {
            padding: 0px;
            margin-top: 0px;
            margin-bottom: 5px;
        }
          .hiddencol {
            display: none;
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
        span.select2-container
         {
            z-index: 10050;
         }
        .form {
 
              width: 100%;
              height: 34px;
              padding: 6px 12px;
              font-size: 14px;
              line-height: 1.42857143;
              color: #555;
              background-color: #fff;
              background-image: none;
              border: 1px solid #ccc;
              border-radius: 4px;
              -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
              box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
              -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
              -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
               transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
              }
       
    </style>
    <script type="text/javascript">
       
       
        function Confirm() {
           
            var confirm_value = "";
            document.getElementById("<%=chkTaxrate.ClientID%>").value = "";
            
                confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to set Tax rate?"))
                {
                    confirm_value.value = "Yes";
                    document.getElementById("<%=chkTaxrate.ClientID%>").value = "Yes";
                }
                else
                {
                    confirm_value.value = "No";
                    document.getElementById("<%=chkTaxrate.ClientID%>").value = "No";
                }
                             
             
            }

     
 
        $(document).ready(function () {
           // $("#<%= gvItem.ClientID %>").tablesorter();
        });
       // var prm = Sys.WebForms.PageRequestManager.getInstance();
     //   prm.add_endRequest(function () {
           // $("#<%= gvItem.ClientID %>").tablesorter();
      //  });
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
      //  function SetScroolBar() {
      //      document.getElementById("divForMaster").scrollTop = document.getElementById("<%= scrollPos.ClientID %>").value;
       // }
        $(document).ready(function () {
          //  SetScroolBar();
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
                    <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" Style="margin-top: 5px;background-color:#4CAF50;color:black"
                        CssClass="btn btn-primary"  OnClick="btnAddCategory_Click" />
                    <asp:Button ID="btnAddSubCategory" runat="server" Text="Add Sub Category" Style="margin-top: 5px;background-color:#4CAF50;color:black;"
                        CssClass="btn btn-primary" OnClick="btnAddSubCategory_Click" />
                    <asp:Button ID="btnAddItems" runat="server"  Text="Add Items" Style="margin-top: 5px; background-color:#4CAF50;"
                        CssClass="btn btn-primary" OnClick="btnAddItems_Click" />
                    <asp:LinkButton ID="lnkOpening" runat="server" OnClick="lnkOpening_click" Visible="false">Back to Opening</asp:LinkButton>
                    <asp:HyperLink class="btn btn-primary" style="background-color:#4CAF50;" NavigateUrl="~/UI/Item/importItemFromExcel.aspx" runat="server">Import Excel</asp:HyperLink>
                </div>
                <div class="col-sm-7" style="border: 1px solid gray">
                    <div class="page_title">
                        <asp:Label runat="server">Items</asp:Label>
                        <uc1:ItemNav ID="ItemNav" runat="server" />
                    </div>

                    <div class="itemGridDiv" style="overflow: scroll; height: 550px; width: 100%;">
                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False"
                            CssClass="sGrid" OnPreRender="gvItem_PreRender"
                            OnRowDataBound="gvItem_RowDataBound" DataKeyNames="ITEM_ID" 
                            OnRowDeleting="gvItem_RowDeleting" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvItem_PageIndexChanging"  PagerStyle-CssClass="gvpager"
                            OnSelectedIndexChanged="gvItem_SelectedIndexChanged" Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif"
                                    SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" />
                                <asp:BoundField DataField="hs_code" HeaderText="HS Code" />
                                <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                                <asp:BoundField DataField="ITEM_SPECIFICATION" HeaderText="Item Specification" />
                                <asp:BoundField DataField="PROP1_REQUIRED" HeaderText="Property1" Visible="true" />
                                <asp:BoundField DataField="PROP2_REQUIRED" HeaderText="Property2" Visible="true" />
                                <asp:BoundField DataField="PROP3_REQUIRED" HeaderText="Property3" Visible="true" />
                                <asp:BoundField DataField="PROP4_REQUIRED" HeaderText="Property4" Visible="true" />
                                <asp:BoundField DataField="PROP5_REQUIRED" HeaderText="Property5" Visible="true" />
                            </Columns>
                            <SelectedRowStyle BackColor="#B5EAAA" Font-Bold="True" ForeColor="#333333" />
                            <EmptyDataTemplate>No Items Found.</EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                    <asp:Label ID="lblTotalRow" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div id="pnAddCategory" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 25%; padding: 1%">
                <div class="row" style="text-align: center">
                    <asp:Label ID="Label3" runat="server" Style="font-family:Tahoma; font-size:18px; font-weight: bold">Add Category</asp:Label><hr />
                </div>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="Label6" runat="server" Text="Category Name :" Style="margin-left: 20%"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:DropdownList ID="drpSearchCategory" runat="server" CssClass="form-control select2" Style="height: 27px; padding: 0px; width: 185px"></asp:DropdownList>
                    </div>
                    </div>
                  <div class="row" style="margin-top: 2%;text-align:right">
                    <asp:Button ID="btnSearchCategory" runat="server" Text="Search" CssClass="btn btn-primary" style="margin-right:15px;"  OnClick="btnSearchCategory_Click" />
                   
                  </div>
                <hr/>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="lblCategoryName" runat="server" Text="Category Name :" Style="margin-left: 20%"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" Style="height: 27px; padding: 0px; width: 185px"></asp:TextBox>
                    <asp:TextBox ID="txtcatgID" runat="server" CssClass="hiddencol"></asp:TextBox>
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
                <div class="row" style="margin-top: 2%;text-align:right">
                    <asp:Button ID="btnSaveCategory" runat="server" Text="Save" CssClass="btn-btn"
                              style="background-color:#4CAF50;" 
                        ValidationGroup="addCategory" OnClick="btnSaveCategory_Click" />
                         <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="btn-btn"
                              style="background-color:#4CAF50;"  Visible="false"
                         OnClick="btndeleteCategory_Click" />                   
                         <asp:Button ID="btnCatClear" runat="server" Text="Close" CssClass="btn-btn"
                              style="background-color:#ED5E65;"/>
                </div>
                <div class="row">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="addCategory" ForeColor="Red" />
                </div>
            </div>

            <%-- <asp:Panel ID="pnItemEntry" runat="server">
        <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input" style="width:95%">              
                <tr>
                <td align="center" class="title_header" height="32">
                
                    <br />
                    <br />
                
                    <table align="center">              
                                <tr>
                                    <td align="left" height="32" >
                                        
                                        <asp:TreeView ID="tvwCategory" runat="server" Font-Names="Verdana" 
                                            Font-Size="10pt" Height="350px" ShowLines="True" Style="z-index: 100; overflow:scroll;
                                            left: 38px; top: 226px" Width="400px" 
                                            onselectednodechanged="tvwCategory_SelectedNodeChanged" 
                                            onscroll="keepScrollPosition();" Font-Bold="False" ForeColor="Black">
                                            <SelectedNodeStyle Font-Bold="True" ForeColor="Black" />
                                        </asp:TreeView>                                        
                                        <input id="scrollPos" runat="server" type="hidden" value="0" />
                                        </td>
                                </tr>
                                <tr>
                                    <td class="entry_link_area" width="380px">
                                       
                                                <asp:HiddenField ID="hnCategoryID" runat="server" />
                                                <asp:HiddenField ID="hnCategoryLevel" runat="server" />
                                                <asp:HiddenField ID="hnParentID" runat="server" />
                                                <asp:Button ID="btnEditCategory" runat="server" Text="Edit Category" 
                                                    CssClass="button" onclick="btnEditCategory_Click" 
                                                    Visible="False" />
                                                <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" 
                                                    CssClass="button" onclick="btnAddCategory_Click"  data-toggle="modal" data-target="#myModal"/>
                                            <asp:Button ID="btnAddSubCategory" runat="server" Text="Add Sub Category"  
                                                    CssClass="button" onclick="btnAddSubCategory_Click" />
                                            <asp:Button ID="btnAddItems" runat="server" Text="Add Items"  
                                                    CssClass="button" onclick="btnAddItems_Click" data-toggle="modal" data-target="#myModal"/>
                                            <asp:LinkButton ID="lnkOpening" runat="server" OnClick="lnkOpening_click" Visible="false" >Back to Opening</asp:LinkButton>
                                    </td>
                                </tr>     
                     </table>                
                
                </td>
                
                <td align="center" style="border:1px solid Black;border-width:1px;width:60%" height="32" valign="top">
                    
                    <table align="center" width="100%"  >              
                                <tr>
                                    <td align="center" class="page_title" colspan="6" height="32">
                                        Items <uc1:ItemNav ID="ItemNav" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="itemGridDiv" style="overflow:scroll; height:350px; width:100%;">
                                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
                                                CssClass="sGrid" onprerender="gvItem_PreRender" 
                                                onrowdatabound="gvItem_RowDataBound" DataKeyNames="ITEM_ID" 
                                                onrowdeleting="gvItem_RowDeleting" 
                                                onselectedindexchanged="gvItem_SelectedIndexChanged" Width="100%" >
                                                <Columns>
                                                 <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                            ShowDeleteButton="True" />
                                                      <asp:BoundField DataField="hs_code" HeaderText="HS Code" />
                                                      <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" />
                                                      <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                                                      <asp:BoundField DataField="PROP1_REQUIRED" HeaderText="" Visible="False" />
                                                      <asp:BoundField DataField="PROP2_REQUIRED" HeaderText="" Visible="False" />
                                                      <asp:BoundField DataField="PROP3_REQUIRED" HeaderText="" Visible="False" />
                                                      <asp:BoundField DataField="PROP4_REQUIRED" HeaderText="" Visible="False" />
                                                      <asp:BoundField DataField="PROP5_REQUIRED" HeaderText="" Visible="False" />
                                                </Columns>
                                                <SelectedRowStyle BackColor="#B5EAAA" Font-Bold="True" ForeColor="#333333" />
                                                <EmptyDataTemplate>
                                                    No Items Found.
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <asp:Label ID="lblTotalRow" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                    </table>                
                </td>
                
                </tr>                
                </table>
    </asp:Panel>--%>

            <%--<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
     <div class="modal-content">
      <div class="modal-header">
      <button type="button" class="close" data-dismiss="modal">&times;</button>
       <div class="modal-title">Add Cateogry</div>
      </div>
      <div class="modal-body">
      <table class="brd_tbl_input" style="border-color: #4CAF50; border-width: medium;">
        <tr>
                <td class="input_item">
                    <asp:Label ID="lblCategoryName" runat="server" Text="Category Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="longTextBox" 
                        Width="220px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfdCategoryName" runat="server" 
                        ErrorMessage="Category Name is mandatory." 
                        ToolTip="Category Name is mandatory." ValidationGroup="addCategory" 
                        ControlToValidate="txtCategoryName" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="lblCatDesc" runat="server" Text="Description :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="longTextBox" 
                        Width="220px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td colspan="3" align="center" valign="middle" height="35px">
                    <asp:Button ID="btnSaveCategory" runat="server" Text="Save"  CssClass="button"
                        ValidationGroup="addCategory" OnClick="btnSaveCategory_Click" UseSubmitBehavior="false" />
                       &nbsp;
                    <asp:Button ID="btnCatClear" data-dismiss="modal" runat="server" Text="Close"  CssClass="button" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ValidationGroup="addCategory" ForeColor="Red" />
                </td>
            </tr>

      </table>
      </div>
    </div>
  </div>
</div>
            --%>
            <%-- <asp:Panel ID="pnAddCategory" CssClass="popupBlock" runat="server" style="display:none">--%>
            <%--<asp:Panel ID="pnAddCategory" CssClass="popupBlock" runat="server" style="background:#CCCCCC;  box-shadow: 10px 10px 5px #888888;">
        <table class="brd_tbl_input"  
            style="border-color: #4CAF50; border-width: medium;">
            <tr>
                <td class="page_title" align="center" height="32" colspan="3">
                    Add Cateogry</td>
            </tr>
            <tr>
                <td class="input_item">
                    <asp:Label ID="lblCategoryName" runat="server" Text="Category Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="longTextBox" 
                        Width="220px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfdCategoryName" runat="server" 
                        ErrorMessage="Category Name is mandatory." 
                        ToolTip="Category Name is mandatory." ValidationGroup="addCategory" 
                        ControlToValidate="txtCategoryName" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="input_item" align="right">
                    <asp:Label ID="lblCatDesc" runat="server" Text="Description :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="longTextBox" 
                        Width="220px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td colspan="3" align="center" valign="middle" height="35px">
                    <asp:Button ID="btnSaveCategory" runat="server" Text="Save"  CssClass="button"
                        ValidationGroup="addCategory" onclick="btnSaveCategory_Click" />
                       &nbsp;
                    <asp:Button ID="btnCatClear" runat="server" Text="Close"  CssClass="button" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ValidationGroup="addCategory" ForeColor="Red" />
                </td>
            </tr>
        </table>
    </asp:Panel>--%>
            <asp:Button ID="btnHiddenForAddCategory" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="modalPopupForAddCategory" runat="server"
                PopupControlID="pnAddCategory"
                TargetControlID="btnHiddenForAddCategory" BackgroundCssClass="mpBack">
            </ajaxToolkit:ModalPopupExtender>

            <div id="pnSubCategory" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 25%; padding: 2%" >
                <div class="row" style="text-align: center">
                    <asp:Label runat="server" Style="font-family:Tahoma; font-size:18px; font-weight: bold">Add Sub Category<hr /></asp:Label>
                </div>
                      <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="Label7" runat="server" Text="Sub Category :" Style="margin-left: 20%"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:DropDownList ID="drpSearchSubcatg" runat="server" CssClass="form-control select2" Style="height: 27px; padding: 0px; width: 185px"></asp:DropDownList>
                    </div>
                    </div>
                  <div class="row" style="margin-top: 2%;text-align:right">
                    <asp:Button ID="btnSearchSubcatg" runat="server" Text="Search" CssClass="btn btn-primary" style="margin-right:15px;"  OnClick="btnSearchSubcatg_Click" />
                   
                  </div>
                <hr/>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="Label1" runat="server" Text="Category Name:" Style="margin-left: 20px"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:DropDownList ID="drpCategory" runat="server" CssClass="form-control select2" Style="height: 27px; padding: 0px; width: 176px"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-5" style="padding: 0px">
                        <asp:Label ID="lblSubCategory" runat="server" Text="Sub Category :" Style="margin-left: 27px"></asp:Label>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <asp:TextBox ID="txtSubCategory" runat="server" CssClass="form-control" Style="height: 27px; padding: 0px; width: 176px"></asp:TextBox>
                         <asp:TextBox ID="txtSubCategoryId" runat="server" CssClass="hiddencol"></asp:TextBox>
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
                <div class="row" style="margin-top: 2%;text-align:right">
                    <asp:Button ID="btnSaveSubCategory" runat="server" Text="Save"  CssClass="btn-btn"
                              style="background-color:#4CAF50;" ValidationGroup="addSubCategory" OnClick="btnSaveSubCategory_Click" />
                   <asp:Button ID="btndeleteSubCategory" runat="server" Text="Delete" CssClass="btn-btn"
                              style="background-color:#4CAF50;" Visible="false"
                         OnClick="btndeleteSubCategory_Click" /> 
                   <asp:Button ID="btnSubClear" CssClass="btn-btn"
                              style="background-color:#ED5E65;" runat="server" Text="Close" />
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
            
            <div id="pnItem" cssclass="popupBlock" runat="server" style="background: #CCCCCC; box-shadow: 10px 10px 5px #888888; width: 60%;height:80%; padding: 2%;z-index: 10; overflow-y: scroll;">
                <div class="row" style="text-align: center">
                    <asp:Label runat="server" Style="font-family:Tahoma; font-size:18px; font-weight: bold;padding: 0px;">Add New Item</asp:Label>
                    <hr style="margin:10px;" />
                </div>
                 <div class="row">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="Label2" runat="server" Style="margin-left: 25%">Item Name :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropdownList ID="drpSearchItem" runat="server" CssClass="form-control select2" Style="width: 100%; padding: 0px; height: 27px"></asp:DropdownList>
                            <asp:TextBox ID="txtSearchItmId" runat="server" CssClass="hiddencol"></asp:TextBox>

                      <%-- <ajaxToolkit:ListSearchExtender ID="search" runat="server" TargetControlID="txtSearchItem"></ajaxToolkit:ListSearchExtender>--%>
                             </div>
                        <div class="col-sm-2" style="padding: 0px">
                           <asp:Button runat="server" ID="btnSearch" Style="background-color: #3B7CB5;" Text="Search" OnClick="btnSearch_Click"/>
                        </div>
                    </div>
                </div>
                 <hr  style="margin:10px;" />
                <div class="row" style="margin-top: 2%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="lblItemCategory" runat="server" Style="text-align:right"><span class="required"> * </span>Category Name :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpItemCategory" runat="server" class="form-control select2" Style="width: 133%; padding: 0px; height: 27px"></asp:DropDownList>
                        </div>
                        <%--<div class="col-sm-2" style="padding: 0px">
                            <asp:RequiredFieldValidator ID="rfvItemCategory" runat="server"
                                ControlToValidate="drpItemCategory"
                                ErrorMessage="Item category name is mandatory." SetFocusOnError="True"
                                ToolTip="Item category name is mandatory." ValidationGroup="addItem">*</asp:RequiredFieldValidator>
                            
                        </div>--%>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="text-align:right">
                            <asp:Label ID="lblTypeofMsnt" runat="server">Measurement Type: </asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpTypeofMsnt" runat="server" CssClass="form-control select2" Style="width: 115%; padding: 0px; height: 27px" OnSelectedIndexChanged="drpTypeofMsnt_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="lblItemSubCategory" runat="server" Style="margin-left: 10%"><span class="required"> * </span>Sub-category :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpItemSubCategory" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="text-align:right">
                            <asp:Label ID="lblUnit" runat="server" Style="margin-left: 58%;"><span class="required"> * </span>Unit :</asp:Label>
                        </div>
                        <%--<asp:Label ID="lblUnit" runat="server" Style="margin-left: 68%"><span class="required"> * </span>Unit :</asp:Label></div>--%>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpUnit" runat="server" Style="width: 115%; padding: 0px; height: 27px" onchange="setQuantityLevel();" CssClass="form-control select2">
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
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="lblItemName" runat="server" Style="margin-left: 25%"><span class="required"> * </span>Item Name :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                       <%-- <div class="col-sm-2" style="padding: 0px">
                            <asp:RequiredFieldValidator ID="rfvItemName" runat="server"
                                ControlToValidate="txtItemName" ErrorMessage="Item Name is mandatory."
                                ToolTip="Item Name is mandatory." ValidationGroup="addItem"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>--%>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="text-align:right">
                            <asp:Label ID="lblStockAlertQty" runat="server" Style="margin-left: 3%"><span class="required"> * </span>HS Code Heading :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtHSHeading" runat="server" CssClass="form-control" Style="width: 115%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                         <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:DropDownList>
                        </div>
                        <div class="col-sm-1" style="padding: 0px">
                            <asp:Label ID="lblMsUnit" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="lblSpecification" runat="server" Style="margin-left: 20%">Specification :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtSpecification" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                        <div class="col-sm-2" style="padding: 0px"></div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="text-align:right">
                            <asp:Label ID="lblReOrderQty" runat="server" TabIndex="9" Style="margin-left: 16%"><span class="required"> * </span>HS Code Suffix :</asp:Label>
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
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="lblBrandName" runat="server" Style="margin-left: 22%">Brand Name :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtBrandName" runat="server" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                        <div class="col-sm-2" style="padding: 0px"></div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="text-align:right">
                            <asp:Label ID="Label4" runat="server" TabIndex="9" Style="margin-left: 40%">Model No :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox ID="txtModelNo" runat="server" CssClass="form-control" Style="width: 115%; padding: 0px; height: 27px"></asp:TextBox>
                        </div>
                        <div class="col-sm-1" style="padding: 0px">
                            <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="Label233" runat="server" Style="margin-left: 2%"><span class="required"> * </span>SKU/Pro. Code :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox runat="server" ID="txtSKUCode" CssClass="form-control" Style="width: 133%; padding: 0px; height: 27px" />
                        </div>
                       
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="text-align:right">
                            <asp:Label ID="lblReOrderQty0" runat="server" Style="margin-left: 22%">Rebatable(%) :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:DropDownList ID="drpVATRebate" runat="server" CssClass="form-control" Style="width: 115%; padding: 0px; height: 27px">
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
                        <div class="col-sm-1" style="padding: 0px">
                            <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 1%">
                     <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="Label9" runat="server" Style="margin-left: 50%">Weight :</asp:Label>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <asp:TextBox runat="server" ID="txtWeight" class="form" Style="width:40%;height: 27px"/>
                            <asp:DropDownList runat="server" class="form select2" ID="drpWeightUnit" Style="width:40%;height: 27px"></asp:DropDownList>
                        </div>

                        <div class="col-sm-2" style="padding: 0px">
                        </div>
                    </div>

                   
                    
                </div>
                <div class="row" style="margin-top: 1%">
                 <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4" style="text-align:right">
                            <asp:Label ID="lblSpecification0" runat="server" Style="margin-left: 16%"><span class="required"> * </span>Product Type :</asp:Label>
                        </div>
                        <div class="col-sm-3" style="padding: 0px">
                            <asp:RadioButton ID="rdItem" runat="server" Checked="True" GroupName="itemType" onclick="disablePercent(this);" Text="Item" OnCheckedChanged="rdService_CheckedChanged" AutoPostBack="true" /><br />
                            <asp:RadioButton ID="rdService" runat="server" GroupName="itemType" onclick="disablePercent(this);" Text="Service" OnCheckedChanged="rdService_CheckedChanged" AutoPostBack="true" /><br />
                            <asp:RadioButton ID="rdUtility" runat="server" GroupName="itemType" onclick="enablePercent(this);" Text="Utility" OnCheckedChanged="rdService_CheckedChanged" AutoPostBack="true" />
                        </div>
                        <div class="col-sm-5" style="padding: 0px">
                            <asp:DropDownList ID="drpProductType" runat="server" CssClass="form-control" Style="padding: 0px; height: 27px" AutoPostBack="true" OnSelectedIndexChanged="drpProductType_SelectedIndexChanged">
                                 <asp:ListItem Value="">--select--</asp:ListItem>
                                <asp:ListItem Value="R">Raw Material</asp:ListItem>
                                <asp:ListItem Value="F">Goods</asp:ListItem>
                                <asp:ListItem Value="P">Finished Product</asp:ListItem>
                                <asp:ListItem Value="C">Finished Product (Production)</asp:ListItem>
                                <asp:ListItem Value="W">Real-estate Property</asp:ListItem>
                                <asp:ListItem Value="M">Medicine</asp:ListItem>
                                <asp:ListItem Value="A">Asset</asp:ListItem>
                                <asp:ListItem Value="S">Set</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpServiceType" runat="server" CssClass="form-control" Style="padding: 0px; height: 27px">
                                <asp:ListItem Value="">--select--</asp:ListItem>
                                 <asp:ListItem Value="2">Service</asp:ListItem>
                                <asp:ListItem Value="1">Service (Finished Production)</asp:ListItem>                               
                                <asp:ListItem Value="3">Service (Raw Material)</asp:ListItem>
                            </asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-5" style="text-align:right">
                            <asp:Label runat="server" Style="margin-left: 22%;">Item Property :</asp:Label>
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
                    <div class="col-sm-12" style="padding: 0px; font-size: 13px;">
                        <asp:CheckBox ID="chkIsExempted" runat="server" Text="Exempted" />
                        <asp:CheckBox ID="chkIsTruncated" runat="server" Text="Reduced" />
                        <asp:CheckBox ID="chkIsTarrif" runat="server" Text="Fixed Vat" />
                        <asp:CheckBox ID="chkIsExpiryDtRequired" runat="server" Text="Expiry Date Required" />
                        <asp:CheckBox ID="chkZeroRate" runat="server" Text="Zero Rate" />
                        <asp:CheckBox ID="chkMrp" runat="server" Text="MRP" />
                        <asp:CheckBox ID="chkIsRebatable" runat="server" Text="Rebatable" />
                        <asp:CheckBox ID="chkIsVDS" runat="server" Text="VDS" />
                        <asp:CheckBox ID="chkIsSupplierRequired" runat="server" Text="Supplier Required" Visible="False" />
                        <hr style="margin:2px;"/>
                    </div>
                </div>
                <div class="row" >
                    <asp:TextBox ID="chkTaxrate" runat="server"  CssClass="hiddencol"></asp:TextBox>
                    <div class="col-sm-12" style="padding: 0px; margin:0px;">
                        <asp:CheckBox ID="chkIsAllBssUnit" runat="server" Text="Is Applicable All Business Unit?" />
                    </div>
                     <div class="col-sm-12" style="padding: 0px; margin:0px;">
                        <asp:CheckBox ID="chkIsPriceDec" runat="server" Text="Is Applicable for Price Declaration?" />
                    </div>
                     <div class="col-sm-12" style="padding: 0px; margin:0px;">
                        <asp:CheckBox ID="chkIsHCS" runat="server" Text="Is Applicable for Health Care Surcharge?" />
                    </div>
                      <div class="col-sm-12" style="padding: 0px; margin:0px;">
                        <asp:CheckBox ID="chkItemSet" runat="server" Text="Is Applicable for Item Set?" />
                    </div>
                      <div class="col-sm-12" style="padding: 0px; margin:0px;">
                        <asp:CheckBox ID="chkReusable" runat="server" Text="Is Reusable?" />
                    </div>
                </div>
                <%--<div class="row" style="margin-top: 1%">--%>
                <div class="row">
                    <div class="col-sm-6" style="padding: 0px">
                        <div class="col-sm-4 text-right">
                            <%-- <asp:Label ID="Label233" runat="server">SKU/Pro. Code :</asp:Label>--%>
                            <%-- <asp:Label ID="Label233" runat="server"><span class="required"> * </span>SKU/Pro. Code :</asp:Label>--%>
                            <%-- <asp:Label ID="lblReOrderQty0" runat="server" Text="Rebatable :"></asp:Label>--%>
                        </div>
                        <div class="col-sm-6" style="padding: 0px">
                            <%-- <asp:TextBox runat="server" ID="txtSKUCode" CssClass="form-control" Style="height: 27px" MaxLength="10" />--%>
                            <%-- <asp:DropDownList ID="drpVATRebate" runat="server" CssClass="form-control" Style="width: 100%; height: 27px; padding: 0px">
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
                            </asp:DropDownList>--%>
                        </div>
                        <div class="col-sm-2" style="padding-top: 0%">
                            <br />
                            <%--<asp:Label ID="Label2" runat="server" Text="%"></asp:Label>--%>
                        </div>
                        <div class="col-sm-6 text-right">
                            <%-- <asp:CheckBox ID="chkIsRebatable" runat="server" Text="Rebatable" />
                            <asp:CheckBox ID="chkIsVDS" runat="server" Text="VDS" />--%>
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
                            <%-- <asp:CheckBox ID="chkIsExempted" runat="server" Text="Exempted" /><br />
                            <asp:CheckBox ID="chkIsTruncated" runat="server" Text="Reduced" /><br />
                            <asp:CheckBox ID="chkIsTarrif" runat="server" Text="Fixed Vat" /><br />
                            <asp:CheckBox ID="chkIsExpiryDtRequired" runat="server" Text="Expiry Date Required" /><br />
                            <asp:CheckBox ID="chkZeroRate" runat="server" Text="Zero Rate" /><br />
                            <asp:CheckBox ID="chkMrp" runat="server" Text="MRP" /><br />
                            <asp:CheckBox ID="chkIsSupplierRequired" runat="server" Text="Supplier Required" Visible="False" />--%>
                        </div>
                        <div class="col-sm-1" style="padding: 0px"></div>
                    </div>
                </div>
                <div class="row" style="margin: 0%">
                    <asp:Button ID="btnSave" runat="server" Style="background-color: #4CAF50; margin-left: 42%" CssClass="btn-btn" OnClick="btnSaveItem_Click" Text="Save"  ValidationGroup="addItem"/>
                    <asp:Button ID="btnItemSCancel" runat="server" Style="background-color: #4CAF50;" CssClass="btn-btn" Text="Close" />
                </div>
                <div class="row" style="margin-top: 0%">
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" Style="background-color: #008CBA;" ValidationGroup="addItem" ForeColor="Red" />
                </div>
            </div>
             <asp:Button ID="btnHideForAddItem" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="modalPopupForAddItem" runat="server"
                PopupControlID="pnItem"
                TargetControlID="btnHideForAddItem" BackgroundCssClass="mpBack">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel1" CssClass="popupBlock" runat="server">
                <uc2:MsgBox ID="msgBox" runat="server" style="margin-top:510%" />
            </asp:Panel>


      <!-- Yes No Modal Panel Start-->
                                   
     <asp:Panel ID="pnYesNoModal" runat="server" Width="700" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
    <%--<asp:Panel ID="pnYesNoModal" runat="server" CssClass="input-table col-md-5 center paddinglrb popupBlock" Visible="false">--%>
        <div class="panel panel-primary panel-primary-custom">
            <div class="panel-heading panel-heading-custom">
                <div class="col-md-6 col-sm-6 col-xs-12"><h4 style="float:left">Confirmation</h4></div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:Button ID="btnOK" runat="server" Text="Reload" Style="background-color: #4CAF50" class="btn-btn" OnClick="btnOkToReload" />
                    <asp:Button ID="btnNoCancel" runat="server" Text="Cancel" Style="background-color: #4CAF50" class="btn-btn" OnClick="btnCancelToSaveInvoice "/>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class='panel-body'>
                <div id="div_model_content">
                    <b><asp:Label ID="lblMessage" runat="server" Text="This item already exists in delete mode. Do you want to reload it?"></asp:Label></b>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnHideButton" runat="server" Text="Close" CssClass="hide"  />
    
    <ajaxToolkit:ModalPopupExtender ID="mpeYesNoModal" runat="server" 
        PopupControlID="pnYesNoModal" TargetControlID="btnHideButton" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>

   <asp:Panel ID="PanelTax" runat="server" Width="350" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
   
        <div class="panel panel-primary panel-primary-custom">
            <div class="panel-heading panel-heading-custom">  
                <b><asp:Label ID="lblMessageTax" runat="server" ></asp:Label></b>                         
                
                <div class="clearfix"></div>

            </div>
           <div class="panel-body">
               <div>
                   Do you want to set Tax Rate?
                    <asp:Button ID="btOKtoTax" runat="server" Text="Yes" class="button_sub" OnClick="btnOkToReloadTaxrate" /> 
                    <asp:Button ID="btnNoTax" runat="server" Text="No" class="button_sub" OnClick="btnNoToReloadTaxrate" /> 
                </div>
           </div>
        </div>
    </asp:Panel>
            <asp:Button ID="bthidden" runat="server" Text="Close" CssClass="hide"  />
    
    <ajaxToolkit:ModalPopupExtender ID="mpeTaxPanel" runat="server" 
        PopupControlID="PanelTax" TargetControlID="bthidden" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>
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
            <%-- <ajaxToolkit:CascadingDropDown ID="cddMsntUnitType" 
                                       runat="server" 
                                       TargetControlID="drpTypeofMsnt" 
                                       Category="msntType" 
                                       PromptText="Select Measurement Unit...." 
                                       LoadingText="Please wait ..." 
                                       ServicePath="~/WebService.asmx" 
                                       ServiceMethod="GetTypeofMesurement">
        </ajaxToolkit:CascadingDropDown>
    <ajaxToolkit:CascadingDropDown ID="cddMsntUnit" 
                                       runat="server" 
                                       TargetControlID="drpUnit" 
                                       ParentControlID="drpTypeofMsnt" 
                                       Category="Unit" 
                                       PromptText="Select Unit...." 
                                       LoadingText="Please wait ..." 
                                       ServicePath="~/WebService.asmx" 
                                       ServiceMethod="GetUnitByMsntType">
        </ajaxToolkit:CascadingDropDown>--%>


           
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

