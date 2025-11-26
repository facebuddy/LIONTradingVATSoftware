<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_znns2ib5" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="panel panel-group">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;">
                        VAT Area Setup
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Commissonerate Name :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpCommName" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="drpCommName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Division Name :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpDivisionName" runat="server" CssClass="form-control select2" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpDivisionName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Circle Name :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpCircleName" runat="server" CssClass="form-control select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Area Name :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtAreaName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Area Code :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtAreaCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Phone # :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtAreaPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Address :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtAreaAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Upazilla Name :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpUpazillaName" runat="server" CssClass="form-control select2" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpUpazillaName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Union/Ward Name :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpUnionWardName" runat="server" CssClass="form-control select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"></label>
                                    <div class="col-sm-7">
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"></label>
                                    <div class="col-sm-7">
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;float: right" OnClick="btnSave_Click" Text="Save" />
                                <asp:Button ID="btnRefresh" runat="server"  CssClass="btn-btn" Style="background-color:#4CAF50;float: right" OnClick="btnRefresh_Click" Text="Refresh" />
                                <asp:Button ID="btnShowAreaList" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;float: right" OnClick="btnShowAreaList_Click" Text="Show Area List" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-primary">
                    <div class="panel panel-body">
                        <asp:GridView ID="dgvVatArea" runat="server" AutoGenerateColumns="False"
                            CssClass="mydatagrid" DataKeyNames="area_id" Width="100%"
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            PageSize="10" AllowPaging="true" OnPageIndexChanging="dgvVatArea_PageIndexChanging"
                            OnRowDeleting="dgvVatArea_RowDeleting"
                            OnSelectedIndexChanged="dgvVatArea_SelectedIndexChanged">
                            <Columns>
                                 <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                              SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:BoundField DataField="area_id" HeaderText="Area ID" Visible="False" />
                                <asp:BoundField DataField="area_name" HeaderText="Area Name" />
                                <asp:BoundField DataField="area_code" HeaderText="Area Code">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cName" HeaderText="Circle" />
                                <asp:BoundField DataField="address" HeaderText="Address">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="phone_no" HeaderText="Phone" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="uName" HeaderText="Upazilla">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="uwName" HeaderText="Union/Ward">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                           
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif"
                                    ShowDeleteButton="True" />
                            </Columns>
                            <HeaderStyle Height="25px" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                            <EmptyDataTemplate>
                                No Items Found.
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
              
    <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 20.06.2021
            </div>    

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

