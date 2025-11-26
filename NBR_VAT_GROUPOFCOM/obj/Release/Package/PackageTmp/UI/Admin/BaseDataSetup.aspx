

<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="BaseDataSetup.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.BaseDataSetup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<%--<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" Runat="Server">
<%--    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>--%>
    <script type="text/javascript">
        function setLabelText() {
        document.getElementById('<%= txtCodeName.ClientID %>').value = null;
        document.getElementById('<%= txtCodeShortName.ClientID %>').value = null;
        document.getElementById('<%= txtCodeValue.ClientID %>').value = null;
    }
</script>
    <style>
         .hiddencol {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:UpdatePanel runat="server">
       <ContentTemplate>
           <%--div class="container">--%>
              <%-- <div class="panel panel-group">--%>
                   <div class="panel panel-primary">
                       <div class="panel-heading text-center" style="font-family:Tahoma; font-size:18px;"><b> Master Data Setup</b></div>
                       <div class="panel-body">
                           <div class="row" style="margin-top:1%">
                               <div class="col-md-4">
                                   <div class="form-group form-group-sm">
                                       <label class="col-sm-5 control-label text-right">Data Type :</label>
                                       <div class="col-sm-7">
                                           <asp:DropDownList ID="drpCodeType" runat="server" 
                                                onselectedindexchanged="drpCodeType_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control select2">
                                            </asp:DropDownList>
                                       </div>
                                   </div>
                               </div>
                               <div class="col-md-4">
                                   <div class="form-group form-group-sm">
                                       <label class="col-sm-5 control-label text-right"><span style="color:crimson">*</span>Data Description :</label>
                                       <div class="col-sm-7">
                                           <asp:TextBox ID="txtCodeName"  runat="server" CssClass="form-control"></asp:TextBox>
                                       </div>
                                   </div>
                               </div>
                               <div class="col-md-4">
                                   <div class="form-group form-group-sm">
                                       <label class="col-sm-5 control-label text-right" style="padding-left: 0px;"> <span style="color:crimson">*</span>Data Short Description :</label>
                                       <div class="col-sm-7">
                                           <asp:TextBox ID="txtCodeShortName" runat="server" CssClass="form-control"></asp:TextBox>
                                       </div>
                                   </div>
                               </div>
                           </div>
                           <div class="row" style="margin-top:1%">
                                <div class="col-md-6"></div>
                                 <div class="col-md-6" style="text-align:right">
                                      <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" Style="background-color:#3B7CB5;float: right" onclick="btnSearch_Click" Text="Search"  />
                                     <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" onclick="btnSave_Click" Text="Save" ValidationGroup="BaseData" />
                                     <asp:Button ID="btnClear" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" onclick="btnClear_Click" Text="Refresh"/>
                                 </div>
                            <%--     <div class="col-md-4"></div>--%>
                            </div>
                           
                       </div>
                   </div>
               <%--</div>--%>
          <%-- </div>--%>

           <div class="row" style="margin-top:1%">
                              
                               <div class="col-md-12">
                                   <asp:GridView ID="gvBaseData" runat="server" AutoGenerateColumns="False" Width="100%"
                                      
                                       CssClass="sGrid"
                                       OnPreRender="gvBaseData_PreRender" OnRowDataBound="gvBaseData_RowDataBound"
                                       OnRowDeleting="gvBaseData_RowDeleting"
                                       OnSelectedIndexChanged="gvBaseData_SelectedIndexChanged"
                                       DataKeyNames="CODE_ID_M,CODE_ID_D,CODE_VALUE_1ST,CODE_VALUE_2ND,CODE_DATE_1ST,CODE_DATE_2ND" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                        <Columns>
                                             <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                              SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                             <asp:BoundField DataField="CODE_ID_D" HeaderText="" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                                            <asp:BoundField DataField="CODE_NAME" HeaderText="Code Name" />
                                            <asp:BoundField DataField="CODE_SHORT_NAME" HeaderText="Code Short Name" />
                                             <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" 
                            ShowDeleteButton="True" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                </asp:GridView>
                               </div>
                              
                                  
                           </div>
           <uc1:MsgBoxs runat="server" ID="msgBox" />
          <%-- <uc2:MsgBox ID="msgBox" runat="server" />--%>
       </ContentTemplate>
   </asp:UpdatePanel>



   

      <asp:Panel ID="pnGvArea" runat="server">
        <table  align="center" id="tblSetDistrict" border="0" style=" border-color: white;" cellpadding="1" cellspacing="3" runat="server">
           
            <tr>
               <%-- <td align="right" class="style1">
                    <asp:Label ID="lblTypeSrch" runat="server" Text="Data Type :"></asp:Label>
                </td>
                <td class="longDropDownList">
                    <asp:DropDownList ID="drpCodeType" runat="server" Height="22px" onchange = "setLabelText()" 
                        onselectedindexchanged="drpCodeType_SelectedIndexChanged" 
                        AutoPostBack="True" CssClass="longDropDownList" Width="175px">
                    </asp:DropDownList>
                </td>--%>
                <td align="left">
                    &nbsp;</td>

                     <td align="right" class="style1">
                         <asp:Label ID="Label1" runat="server" Text="Numeric Data Value :" Visible="false"></asp:Label>
                </td>
                <td class="longDropDownList">
                    <asp:TextBox ID="txtCodeValue" runat="server" CssClass="longTextBox" Visible="false"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:RegularExpressionValidator ID="regExCdVal" runat="server" 
                        ControlToValidate="txtCodeValue" ErrorMessage="Code Value is not valid." 
                        SetFocusOnError="True" ToolTip="Code Value is not valid." 
                        ValidationExpression="^\d*([.]\d{0,6})?|[.]\d+$" ValidationGroup="BaseData">*</asp:RegularExpressionValidator>
                </td>
               
            </tr>
             <tr>
               <%-- <td align="right" class="style1">
                    <asp:Label ID="lblCodeName" runat="server" Text="Data Description  :"></asp:Label>
                </td>
                <td class="longDropDownList">
                   <asp:TextBox ID="txtCodeName" runat="server" CssClass="longTextBox" 
                        Width="170px"></asp:TextBox>
                </td>--%>
                <td align="left">
                    &nbsp;</td>
<td align="right" class="style1">
                         <asp:Label ID="Label2" runat="server" Text="Numeric Data Value 2nd :" Visible="false"></asp:Label>
                 </td>
                <td class="longDropDownList">
                    <asp:TextBox ID="txtCodeValue2nd" runat="server" CssClass="longTextBox" Visible="false"></asp:TextBox>
                 </td>
                <td align="left">
                    <asp:RegularExpressionValidator ID="regExCdVal2nd" runat="server" 
                        ControlToValidate="txtCodeValue2nd" ErrorMessage="Code value is not valid." 
                        SetFocusOnError="True" ToolTip="Code value is not valid." 
                        ValidationExpression="^\d*([.]\d{0,6})?|[.]\d+$" ValidationGroup="BaseData">*</asp:RegularExpressionValidator>
                 </td>

               
            </tr>
              
           
        
             <tr>
               <%-- <td align="right" class="style1">
                    <asp:Label ID="lblCodeShortName" runat="server" 
                        Text="Data Short Description  :"></asp:Label>
                </td>
                <td class="longDropDownList">
                    <asp:TextBox ID="txtCodeShortName" runat="server" CssClass="longTextBox" 
                        Width="170px"></asp:TextBox>
                </td>--%>
              <%-- <td align="left">
                        <ajaxToolkit:FilteredTextBoxExtender ID="Filt" 
                    runat="server" Enabled="True" TargetControlID="txtCodeValue" 
                    ValidChars=".0123456789"> </ajaxToolkit:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="frvCodeName" runat="server" 
                        ControlToValidate="txtCodeName"  
                        SetFocusOnError="True" ToolTip="CodeName is mandatory." 
                        ValidationGroup="BaseData">*</asp:RequiredFieldValidator>
                 </td>--%>
              <td align="right" class="style1">
                         <asp:Label ID="Label4" runat="server" Text="Date From :" Visible="false"></asp:Label>
                 </td>
                <td class="longDropDownList">
                    <asp:TextBox ID="txtCodeDate" runat="server" DateFormat="dd/MM/yyyy" Visible="false"></asp:TextBox>
                 </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
              <tr>
                <td align="right" class="style1">
                    &nbsp;</td>
                <td class="longDropDownList">
                    &nbsp;</td>
              <%-- <td align="left">
                        <ajaxToolkit:FilteredTextBoxExtender ID="Filt1" 
                    runat="server" Enabled="True" TargetControlID="txtCodeValue2nd" 
                    ValidChars=".0123456789"> </ajaxToolkit:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="frvCdShortName" runat="server" 
                        ControlToValidate="txtCodeShortName" 
                        SetFocusOnError="True" 
                        ToolTip="Code Short Name is mandatory" ValidationGroup="BaseData">*</asp:RequiredFieldValidator>
                  </td>--%>
              <td align="right" class="style1">
                         <asp:Label ID="Label5" runat="server" Text="Date To :" Visible="false"></asp:Label>
                  </td>
                <td class="longDropDownList">
                    <asp:TextBox ID="txtCodeDate2nd" runat="server" DateFormat="dd/MM/yyyy" Visible="false"></asp:TextBox>
                  </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hdCodeIdD" runat="server" />
                </td>
                <td align="right" class="longDropDownList">
                    <asp:Label ID="Label3" runat="server" Text="Parent Data :" Visible="False"></asp:Label>
                    <asp:DropDownList ID="drpParent" runat="server" AutoPostBack="True" 
                        CssClass="longDropDownList" Height="22px" 
                        onselectedindexchanged="drpParent_SelectedIndexChanged" Visible="False" 
                        Width="70px">
                    </asp:DropDownList>
                </td>
                <td align="left">
                    &nbsp;</td>
                <td align="right" class="style1">
                        
                 </td>
                <td align="right" class="longDropDownList">
                   <%-- <asp:Button ID="btnSearch" runat="server" CssClass="button" Height="28px" 
                        onclick="btnSearch_Click" style="margin-left: 0px" Text="Search" 
                        Width="70px" />
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Height="28px" 
                        onclick="btnSave_Click" style="margin-left: 0px" Text="Save" 
                        ValidationGroup="BaseData" Width="60px" />
                    <asp:Button ID="btnClear" runat="server" CssClass="button" Height="28px" 
                        onclick="btnClear_Click" Text="Clear" Width="60px" />--%>
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
             <tr>
            <td align="center" colspan="9">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ValidationGroup="BaseData" Height="43px" Width="272px" />
                <asp:HiddenField ID="hdCodeType" runat="server" />
                <asp:HiddenField ID="hdParentMCodeID" runat="server" />
            </td>
        </tr>
        </table>
          <br />

            <div class="gridDiv" align="center">

                <%--<asp:GridView ID="gvBaseData" runat="server" AutoGenerateColumns="False" 
                    AutoGenerateDeleteButton="True" AutoGenerateSelectButton="True" 
                    CssClass="sGrid" EnableModelValidation="True" 
                    onprerender="gvBaseData_PreRender" onrowdatabound="gvBaseData_RowDataBound" 
                    onrowdeleting="gvBaseData_RowDeleting" 
                    onselectedindexchanged="gvBaseData_SelectedIndexChanged" 
                    
                    DataKeyNames="CODE_ID_M,CODE_ID_D,CODE_VALUE_1ST,CODE_VALUE_2ND,CODE_DATE_1ST,CODE_DATE_2ND">
                    <Columns>
                        <asp:BoundField DataField="CODE_NAME" HeaderText="Code Name" />
                        <asp:BoundField DataField="CODE_SHORT_NAME" HeaderText="Code Short Name" />
                    </Columns>
                    <SelectedRowStyle BackColor="#B5EAAA" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>--%>

            </div>
      </asp:Panel>
    <script language="javascript">
        Sys.UI.Point = function Sys$UI$Point(x, y) {

            x = Math.round(x);
            y = Math.round(y);

            var e = Function._validateParams(arguments, [
                {name: "x", type: Number, integer: true},
                {name: "y", type: Number, integer: true}
            ]);
            if (e) throw e;
            this.x = x;
            this.y = y;
        }
    </script>

     </asp:Content>



