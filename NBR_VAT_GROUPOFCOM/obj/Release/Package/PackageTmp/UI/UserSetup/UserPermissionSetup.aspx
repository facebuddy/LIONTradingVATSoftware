<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="UserPermissionSetup.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.UserSetup.UserPermissionSetup" %>

<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>



<%--<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
  <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .full_body_readyform
        {
            font-size: medium;
            font-family: Vani;
            width: 98%;
            padding: 3PX;
            border: 1px solid black;
        }
        
        
        .full_width_upermission
        {
            width: 55%;
            border: 1px solid black;
            padding: 10px;
            text-align: left;
            margin: 5px 0px;
            float: left;
        }
        
        .full_width_uspermission2
        {
            width: 40%;
            border: 1px solid black;
            padding: 10px;
            text-align: left;
            margin: 5px 0px;
            float: left;
        }
        
        .clear_fix
        {
            clear: both;
        }
    
        .style1
        {
            width: 106px;
        }
    
    </style>
    <script language="javascript" type="text/javascript">


        function OnTreeClick(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            if (isChkBoxClick) {
                var parentTable = GetParentByTagName("table", src);
                var nxtSibling = parentTable.nextSibling;
                //check if nxt sibling is not null & is an element node
                if (nxtSibling && nxtSibling.nodeType == 1) {
                    if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
                    {
                        //check or uncheck children at all levels
                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
                    }
                }
                //check or uncheck parents at all levels
                CheckUncheckParents(src, src.checked);
            }
        }


        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                childChkBoxes[i].checked = check;
            }
        }

        function CheckUncheckParents(srcChild, check) {
            var parentDiv = GetParentByTagName("div", srcChild);
            var parentNodeTable = parentDiv.previousSibling;
            if (parentNodeTable) {
                var checkUncheckSwitch;
                if (check) //checkbox checked
                {
                    var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                    if (isAllSiblingsChecked)
                        checkUncheckSwitch = true;
                    else
                        return; //do not need to check parent if any(one or more) child not checked
                }
                else //checkbox unchecked
                {
                    checkUncheckSwitch = true; //false;
                }

                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0];
                    parentNodeChkBox.checked = checkUncheckSwitch;
                    //do the same recursively
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }
        }

        function AreAllSiblingsChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) {
                    //check if the child node is an element node
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return true/ false
                        if (!prevChkBox.checked) {
                            return true; //  false;
                        }
                    }
                }
            }
            return true;
        }

        //utility function to get the container of an element by tagname
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            return parent;
        }
    </script>
   
            <div class="container-fluid">
              <%--  <div class="input-table tablefull center paddinglrb marginbottomsmall">
                    <div class="my_details_contact">--%>
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;
                height: 30px; padding-top: 0px">
                            <b>User Menu Permission</b>
                        </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-2" style="text-align:right">
                             Employee Name <span style='font-size:20px;'>:</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeName" runat="server" class="form-input-Test"  style="margin-top:5px"
                                        placeholder="Enter Employee Name" Width="200px"></asp:TextBox>
                              
                            </div>
                              <div class="col-sm-2">
                                   <asp:LinkButton ID="btnSearch" runat="server" style="background-color:#3B7CB5; width:100px" CssClass="btn btn-success btn-sm" ValidationGroup="validUser" OnClick="btnSearch_Click"><i class="fa fa-search"></i>  Search</asp:LinkButton>
                              <%--  <asp:Button ID="" runat="server" CssClass="test-btn-primary" style="margin-top:5px;width:100px"
                                        Text="" ValidationGroup="validUser" onclick="" />--%>

                            </div>
                              </div>
                            </div>
                           
                      <%--  <h2>
                            User Menu Permission:</h2>--%>
                    <%--    <table class="tablefull" style = "width : 400px; border-style: none;">
                            <tr>
                                <td class="input_item2">
                                    <asp:Label ID="Label3" runat="server" Text="Organigation :" Visible="False"></asp:Label>
                                </td>
                                <td class="input_field">
                                    <asp:DropDownList ID="DrpOrganization" runat="server" Visible="False">
                                    </asp:DropDownList>
                                </td>
                                <td class="input_item2">
                                </td>
                                <td class="style1">
                                </td>
                            </tr>
                            <tr>
                             
                                <td class="input_item2>
                                 <label class="control-label col-sm-5" style = "font-weight:bold">
                                    Employee name:</label>

                                    </td>
                                <td class="input_field" colspan="3">
                                    <asp:TextBox ID="txtEmployeeName" runat="server" class="form-input-Test"  style="margin-top:5px"
                                        placeholder="Enter Employee Name" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                  
                                </td>
                            </tr>
                         
                            <tr>
                                <td class="input_item_auto">
                                    &nbsp;
                                </td>
                                <td class="input_field">
                                    &nbsp;
                                </td>
                                <td class="input_item_auto">
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    &nbsp;</td>
                            </tr>
                        </table>--%>
                        <%--<div class="table_header" colspan="2">
                            <h3 style="margin-bottom: 19px">
                                Set User Menu Permission
                            </h3>
                        </div>--%>
                        <div class="clearfix">
                        </div>
                    </div>
                </div>
    <div class="container-fluid">
        <div class="panel panel-primary">
    <div class="panel-heading" style="text-align: center; font-size: 25px; font-weight: bold;
                height: 30px; padding-top: 0px">
                            <b>  Set User Menu Permission</b>
                        </div>
                <div class="full_body_readyform">
                    <div class="clear_fix">
                    </div>
                    <div class="full_width_upermission">
                        <asp:Panel ID="pnInput" CssClass="input-table tablefull center paddinglrb" runat="server">
                            <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True"
                                CssClass="table" DataKeyNames="employee_id" AllowPaging="True" 
                                onpageindexchanging="gvUser_PageIndexChanging" 
                                onselectedindexchanged="gvUser_SelectedIndexChanged" BackColor="White" 
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <Columns>
                                    <asp:BoundField DataField="employee_name" HeaderText="Employee Name" />
                                    <asp:BoundField DataField="login_id" HeaderText="Login Id" />
                                    <asp:BoundField DataField="designation_name" HeaderText="Designation" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </asp:Panel>
                        <div style="text-align:right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn-btn"
                              style="background-color:#4CAF50;" ValidationGroup="validDept" onclick="btnSubmit_Click" />
                        </div>
                         <div style = "width:auto; padding-left:3%";">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </div>
                                    
                    </div>
                    <div class="full_width_uspermission2">
                        <asp:TreeView ID="tvwUserPermission" runat="server" ShowCheckBoxes="All" ExpandDepth="0"
                            ShowLines="True" TabIndex="0">
                            <SelectedNodeStyle BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" />
                        </asp:TreeView>
                    </div>
                    <div class="clear_fix">
                    </div>
                </div>
            </div>
         </div>
<%--    <uc2:MsgBox ID="msgBox" runat="server" />--%>

    <uc1:MsgBoxs runat="server" ID="msgBox" />
</asp:Content>
