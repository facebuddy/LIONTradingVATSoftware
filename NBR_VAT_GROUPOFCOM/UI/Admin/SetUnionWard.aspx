<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_z1w3wddp" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <link href="../../Styles/panel.css" rel="stylesheet" />
<style>

    .hiddencol{
        display:none;
    }

</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
             <div class="panel panel-primary">
        <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px;font-weight: bold;">
            Set Union/Ward
        </div>
        <div class="panel-body">
            <div class="row">
               <%-- <div class="col-md-2"></div>--%>
                <div class="col-md-4">
                    <div class="form-group form-group-sm">
                        <asp:Label ID="lblDistrictName0" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>Union/Ward Name :</asp:Label>
                        <div class="col-sm-7">
                            <asp:TextBox ID="txtUnionWardName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                 <div class="col-md-4">
                    <div class="form-group form-group-sm">
                        <asp:Label ID="Label1" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>Police Station :</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList ID="drpPoliceStation" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group form-group-sm">
                        <asp:Label ID="Label2" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required">*</span>Upazila Name :</asp:Label>
                        <div class="col-sm-7">
                            <asp:DropDownList ID="drpUpazilaName" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
               <%-- <div class="col-md-4"></div>--%>
            </div>
            <%--<div class="row">
                <div class="col-md-2"></div>
               
                <div class="col-md-4"></div>
            </div>--%>
            <%-- <div class="row">
                <div class="col-md-2"></div>
                
                <div class="col-md-4"></div>
            </div>--%>
            <div class="row">
              <%--  <div class="col-md-2"></div>--%>
                <div class="col-md-4">
                    <div class="form-group form-group-sm">
                        <asp:Label ID="Label3" CssClass="col-sm-5 control-label text-right" runat="server" Text="Is Union :"></asp:Label>
                        <div class="col-sm-7">
                            <%--<asp:CheckBoxList ID="chkUnionConfirmation" runat="server" RepeatColumns="2" Style="width:255px"> </asp:CheckBoxList>--%>
                        <asp:RadioButtonList ID="chkUnionConfirmation" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" style="margin-left:30px" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                             </div>
                    </div>
                </div>
                 <div class="col-md-8" style="text-align:right">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Style="background-color:#4CAF50;margin-left:16.5%;" CssClass="btn-btn" OnClick="btnSave_Click" />
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" style="background-color:#4CAF50;" CssClass="btn-btn" OnClick="btnRefresh_Click" />
                    <asp:Button ID="btnShowUnionWard" runat="server" Text="Show Union/Ward List" Style="background-color:#5CB85C;" CssClass="btn-btn" OnClick="btnShowUnionWard_Click" />

                </div>
               <%-- <div class="col-md-4"></div>--%>
            </div>
            <div class="row" style="margin-top: 0px; margin-bottom: 5px">
                <div class="col-md-3"></div>
               
                <div class="col-md-3"></div>
            </div>
        </div>
    </div>
               <div class="panel panel-primary">
                <div class="panel-body">
                   <div class="col-md-6">
                                    <div class="form-group form-group-sm">                                        
                                        <label class="col-sm-5 control-label text-right"> Union/Ward Name :</label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList ID="drpUnion" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>
                                           
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" Style="background-color:#3B7CB5;" OnClick="btnSearch_Click" Text="Search" />
                                        </div>
                                    </div>
                                </div>
                    
                 </div>
            </div>
    <div class="panel panel-primary">
        <div class="panel panel-body">
            <asp:GridView ID="dgvUnionWard" runat="server" AutoGenerateColumns="False"
                    CssClass="mydatagrid" DataKeyNames="union_ward_id" Width="100%"
                HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="dgvUnionWard_PageIndexChanging"
                    OnRowDataBound="dgvUnionWard_RowDataBound"
                    OnRowDeleting="dgvUnionWard_RowDeleting"
                    OnSelectedIndexChanged="dgvUnionWard_SelectedIndexChanged">
                    <Columns>
                         <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                         <asp:BoundField DataField="union_ward_id" HeaderText="Union/Ward Name" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField DataField="union_ward_name" HeaderText="Union/Ward Name" />
                        <asp:BoundField DataField="psName" HeaderText="Police Station" />
                        <asp:BoundField DataField="uName" HeaderText="Upazila" />
                        <asp:BoundField DataField="isUnion" HeaderText="Is Union" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
        </div>
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

