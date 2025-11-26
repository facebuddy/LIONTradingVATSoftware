<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="VMSXML_VMSXML, App_Web_ypkbpeo4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/ReportsNav.ascx" TagName="ReportsNav" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../Scripts/jquery-ui.min.js"></script>
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel panel-primary">
                    <div class="panel-heading text-center" style="font-weight:bold">VMS CSV & XML</div>
                    <div class="panel panel-body">
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-6">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right" for="xml-for">XML/CSV For :</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList CssClass="form-control" ID="drpVATFormName" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpVATFormName_SelectedIndexChanged">
                                            <%--<asp:ListItem>VAT_11</asp:ListItem>
                                            <asp:ListItem>VAT_18</asp:ListItem>
                                            <asp:ListItem>VAT_19</asp:ListItem>--%>
                                            <asp:ListItem>VAT_6.3</asp:ListItem>
                                          <%--  <asp:ListItem>VAT_18</asp:ListItem>--%>
                                            <asp:ListItem>VAT_9.1</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label runat="server" ID="lblFormName" Text="NA"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-6">
                                <div class="form-group form-group-sm">
                                    <label class="control-label col-sm-5 text-right" for="xml-for">Session Value :</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox CssClass="form-control" ID="txtSessionValue" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtSessionValue_filter" runat="server" FilterType="Numbers" TargetControlID="txtSessionValue" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4"></div>
                        </div>
                        <div class="clearfix"></div>
                        <asp:Panel ID="pnlVAT11" runat="server">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right" for="xml-for">কর মেয়াদ :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="dtpDateFrom" runat="server" DateFormat="dd/mm/yyyy" Style="width: 120px; float: left" CssClass="form-control" />
                                            <cc1:CalendarExtender runat="server" ID="ddf" TargetControlID="dtpDateFrom" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                            <asp:Label ID="Label7" runat="server" Text="হইতে" Style="float: left; padding-left: 3%; padding-right: 3%"></asp:Label>
                                            <asp:TextBox ID="dtpDateTo" runat="server" DateFormat="dd/mm/yyyy" Style="width: 120px; float: left" CssClass="form-control"></asp:TextBox>
                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="dtpDateTo" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                            <asp:Label ID="Label6" runat="server" Text="পর্যন্ত" Style="float: left; padding-left: 3%"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right" for="xml-for">ক্রেতার নাম :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList CssClass="form-control" ID="ddlCustomer" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right" for="xml-for">চালানপত্রের ক্রমিক সংখ্যা :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtChallanId" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlVAT18" runat="server">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right" for="xml-for">From Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right" for="xml-for">To Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtToDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right" for="xml-for">Organization :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList CssClass="form-control" ID="drpOrganization" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlVAT19" runat="server">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Year :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList CssClass="form-control" ID="drpYear" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Month :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList CssClass="form-control" ID="drpMonth" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-6">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Organization :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList CssClass="form-control" ID="drpOrganization0" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                            </div>
                        </asp:Panel>
                        <div class="clearfix"></div>
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-6">
                                <asp:Button ID="GenerateXML" runat="server" Text="Generate XML" CssClass="btn btn-primary btn-md" OnClick="GenerateXML_Click" Style="float: right;" />
                                <asp:Button ID="btnGenerateCSV" runat="server" Text="Generate CSV" CssClass="btn btn-warning btn-md" OnClick="btnGenerateCSV_Click" Style="float: right;" />
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <uc2:MsgBox ID="msgBox" runat="server" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GenerateXML" />
            <asp:PostBackTrigger ControlID="btnGenerateCSV" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

