<%@ page title="Set Item Property" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_SetProperty, App_Web_jwpupl0k" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register src= "~/UserControls/Item.ascx" tagname="ItemNav" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.tablePagination.0.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <link href="../../Styles/panel.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/bootstrap/bootstrap.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= gvProperty.ClientID %>").tablesorter();
            $('#<%= gvProperty.ClientID %>').tablePagination({
                firstArrow: (new Image()).src = "../Content/Images/first.gif",
                prevArrow: (new Image()).src = "../Content/Images/prev.gif",
                lastArrow: (new Image()).src = "../Content/Images/last.gif",
                nextArrow: (new Image()).src = "../Content/Images/next.gif"
            });
        }
);

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $("#<%= gvProperty.ClientID %>").tablesorter();
            $('#<%= gvProperty.ClientID %>').tablePagination({
                firstArrow: (new Image()).src = "../Content/Images/first.gif",
                prevArrow: (new Image()).src = "../Content/Images/prev.gif",
                lastArrow: (new Image()).src = "../Content/Images/last.gif",
                nextArrow: (new Image()).src = "../Content/Images/next.gif"
            });
        });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="Container-fluid">
     <div class="panel-group">
     <div class="panel panel-primary">
       <div class="panel-heading" style="text-align:center; font-family:Tahoma; font-size:18px;font-weight:bold; height:30px; padding-top:0px">Set Properties</div>
         <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
            <div class="row" style="margin-top:2%">
               <div class="col-sm-3">
               <asp:Label ID="lblCurrencyID3" runat="server" Text="" CssClass="present-address-lbl" style="margin-left:7px">Property Type <span style='font-size:20px;'>:</span></asp:Label>
               <asp:DropDownList ID="drpDetailCode" runat="server" AutoPostBack="True" CssClass="present-address-tb select2" style="margin-left:20%; width:50%"
                        onselectedindexchanged="drpDetailCode_SelectedIndexChanged">
               </asp:DropDownList>
             </div>
             <div class="col-sm-3">
              <asp:Label ID="lblUnitName" runat="server" Text="" CssClass="present-address-lbl"><span class="required">*</span>Property Name <span style='font-size:20px;'>:</span> </asp:Label>
              <asp:TextBox ID="txtPropertyName" runat="server" CssClass="present-address-tb" style="margin-left:20%; width:50%" ></asp:TextBox>
              </div>
                 <div class="col-sm-3">
              <asp:Label ID="lblUnitCode" runat="server" Text="" CssClass="present-address-lbl" style="margin-left:3px"><span class="required">*</span>Property Code <span style='font-size:20px;'>:</span> </asp:Label>
              <asp:TextBox ID="txtPropertyCode" runat="server" style="margin-left:20%; width:50%" CssClass="present-address-tb"></asp:TextBox>
              </div>
                    <div class="col-sm-3">
              <asp:Label ID="Label1" runat="server" Text="" CssClass="present-address-lbl" style="margin-left:3px">Quantity <span style='font-size:20px;'>:</span> </asp:Label>
              <asp:TextBox ID="txtQuantity" runat="server" style="margin-left:20%; width:50%" CssClass="present-address-tb"></asp:TextBox>
              </div>
            </div>
            <%--<div class="row" style="margin-top:1%">
            <div class="col-sm-3"></div>
           
              <div class="col-sm-3"></div>
            </div>
            <div class="row" style="margin-top:1%">
            <div class="col-sm-3"></div>
           
              <div class="col-sm-3"></div>
            </div>--%>
            <div class="row" style="margin-top:1%; margin-bottom:1%">
            <div class="col-sm-3"></div>
                  <asp:LinkButton ID="lnkOpening" runat="server" OnClick="lnkOpening_click" Visible="false" >Back to Opening</asp:LinkButton>
                  <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
              <div class="col-sm-8" style="text-align:right">
                  <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" CssClass="btn-btn" Style="background-color:#4CAF50;margin-left:195px" />
                  <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"  CssClass="btn-btn" Style="background-color:#4CAF50;"/>
                  <asp:Button ID="btnShowHideData" runat="server" Text="Show Property List" onclick="btnShowHideData_Click"  CssClass="btn-btn" Style="background-color:#5CB85C;"/>
              </div>
              <div class="col-sm-3"></div>
            </div>
          </div>
         </div>
        </div>
   </div>
       <%-- <table align="center" id="tblCurrencyConvertion"  bgcolor="WhiteSmoke" border="0" cellpadding="1" cellspacing="3" class="brd_tbl_input" runat="server">
            <tr>
                <td colspan="2" height="30" class="page_title">
                    Set Properties<uc1:ItemNav ID="ItemNav" runat="server" /></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="input_item">
                    <asp:Label ID="lblCurrencyID3" runat="server" Text="Property Type :"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:DropDownList ID="drpDetailCode" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="drpDetailCode_SelectedIndexChanged" Width="220px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="input_item" >
                    <asp:Label ID="lblUnitName" runat="server" Text="Property Name :"></asp:Label>
                </td>
                <td style="text-align: left">
        <asp:TextBox ID="txtPropertyName" runat="server" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="input_item" >
                    <asp:Label ID="lblUnitCode" runat="server" Text="Property Code :"></asp:Label>
                </td>
                <td style="text-align: left" >
        <asp:TextBox ID="txtPropertyCode" runat="server" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                <asp:LinkButton ID="lnkOpening" runat="server" OnClick="lnkOpening_click" Visible="false" >Back to Opening</asp:LinkButton>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
                        height="30px" CssClass="button" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                        onclick="btnCancel_Click" Height="30px" CssClass="button" />
                    <asp:Button ID="btnShowHideData" runat="server" Text="Show Property List" 
                        onclick="btnShowHideData_Click" height="30px" CssClass="button" />
                </td>
            </tr>
            
            </table>--%>

            <div class="gridDiv">

            <asp:GridView ID="gvProperty" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False"  DataKeyNames="PROPERTY_ID" 
                        onrowdeleting="gvUnit_RowDeleting" 
                        onselectedindexchanged="gvUnit_SelectedIndexChanged" 
                        onrowdatabound="gvProperty_RowDataBound" 
                        EmptyDataText="No Record Found!" CssClass="table table-bordered" 
                    style="background:none">
                        <Columns>
                             <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                            <asp:BoundField DataField="PROPERTY_ID" HeaderText="Property ID" 
                                Visible="False" />
                            <asp:BoundField DataField="PROPERTY_NAME" HeaderText="Property Name" />
                            <asp:BoundField DataField="PROPERTY_CODE" HeaderText="Property Code" 
                                DataFormatString="{0:f}" />
                            <asp:BoundField DataField="PROPERTY_TYPE_M" HeaderText="Master Code" 
                                DataFormatString="{0:f}" Visible="False" />
                            <asp:BoundField DataField="CODE_NAME" 
                                HeaderText="Property Type" />

                            <asp:BoundField DataField="quantity" 
                                            HeaderText="Quantity" />
                            <asp:BoundField DataField="DATE_INSERT" HeaderText="Date Insert" 
                                Visible="False" DataFormatString="{0:dd-MMM-yyyy}" />
                              <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
            </div>
    <uc2:Msgbox ID="msgBox" runat="server" />

<asp:Panel ID="pnAddDeletedProperty" CssClass="popupBlock" runat="server" style="display:none">
        <table class="input_table">
            <tr>
                <td class="title_header" align="center" height="32">
                    Previously Deleted</td>
            </tr>
            <tr>
                <td class="input_Item">
                    <asp:Label ID="lblCategoryName" runat="server" 
                        
                        Text="This property added and deleted previously. Are you want to recreate it?"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="inputItem">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="middle" height="35px">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" onclick="btnYes_Click" />
                    <asp:Button ID="btnNo" runat="server" Text="No" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="btnHideForDeletedProperty" runat="server" style="display:none"/>
     <ajaxtoolkit:modalpopupextender ID="modalPopupForDeletedIProperty" runat="server"
        PopupControlID="pnAddDeletedProperty" 
        TargetControlID="btnHideForDeletedProperty" BackgroundCssClass="mpBack">
</ajaxtoolkit:modalpopupextender>
</asp:Content>

