<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="UnitConversion.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Item.UnitConversion" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery.tablePagination.0.1.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.tablesorter.js"></script>
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= gvUnit.ClientID %>").tablesorter();
            $('#<%= gvUnit.ClientID %>').tablePagination({
                firstArrow: (new Image()).src = "../Content/Images/first.gif",
                prevArrow: (new Image()).src = "../Content/Images/prev.gif",
                lastArrow: (new Image()).src = "../Content/Images/last.gif",
                nextArrow: (new Image()).src = "../Content/Images/next.gif"
            });
        }
);

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $("#<%= gvUnit.ClientID %>").tablesorter();
            $('#<%= gvUnit.ClientID %>').tablePagination({
                firstArrow: (new Image()).src = "../Content/Images/first.gif",
                prevArrow: (new Image()).src = "../Content/Images/prev.gif",
                lastArrow: (new Image()).src = "../Content/Images/last.gif",
                nextArrow: (new Image()).src = "../Content/Images/next.gif"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
       <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
          
                 
                <div class="panel panel-primary">
            <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;
                height: 30px; padding-top: 0px">
                            <b>Set Unit Conversion</b>
                        </div>
            <div class="panel-body">
                            <div class="row">
                               <%-- <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Unit Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpDetailCode" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDetailCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="row" style="margin-top: 0.5%">
                               <%-- <div class="col-md-2"></div>--%>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Unit Type :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpDetailCode" CssClass="form-control select2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDetailCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <div class="col-sm-4">
                                           <%--  <asp:Label ID="txtValueFrom" Style="float: right;padding-top: 8%;" runat="server">1</asp:Label>--%>
                                            <asp:TextBox CssClass="form-control" ID="txtValueFrom" runat="server" value="1" style="text-align:center"></asp:TextBox>
                                        </div>
                                      
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpUnitFrom" CssClass="form-control select2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpUnitFrom_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-sm-1" style="padding-top: 2%;">
                                            <asp:Label ID="lblCurrencyID7" runat="server" Text="="></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="txtValueTo" CssClass="col-sm-5 form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpUnitTo" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2"> <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></div>
                            </div>
                            <div class="row" style="margin-top:1%">
                                <div class="col-sm-9"></div>
                                <div class="col-sm-3">
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn-btn" Style="background-color:#4CAF50;" />
                                    <%--<asp:Button ID="btnUpdate" runat="server" OnClick="btnSave_Click" Text="Update" CssClass="btn btn-primary" />--%>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn-btn" Style="background-color:#4CAF50;" />
                                    <asp:Button ID="btnShowHideData" runat="server" Text="Show All Records" OnClick="btnShowHideData_Click" CssClass="btn-btn" Style="background-color:#5CB85C;width:130px"/>
                                </div>
                                <div class="col-sm-3"></div>
                            </div>
                            <div class="row" style="margin-top: 2%">
                                <%--<div class="col-md-4"></div>--%>
                            
                                    
                                        <asp:GridView ID="gvUnit" runat="server" AllowSorting="True"  CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                                AutoGenerateColumns="False" 
                                               
                                                onrowdeleting="gvUnit_RowDeleting" 
                                                onselectedindexchanged="gvUnit_SelectedIndexChanged" 
                                                onrowdatabound="gvProperty_RowDataBound" 
                                                DataKeyNames="MEASUREMENT_ID_D,CONVERSION_ID" 
                                                EmptyDataText="No Records Found!" >
                                                <Columns>
                                                     <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                                     <asp:BoundField DataField="VALUE_FROM" HeaderText="From Value" DataFormatString="{0:0}"  >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="UNIT_NAME_FROM" HeaderText="Unit From" />
                                                    <asp:BoundField DataField="VALUE_TO" HeaderText="To Value" DataFormatString="{0:0.####}" />
                                                    <asp:BoundField DataField="UNIT_NAME_TO" HeaderText="Unit To" />
                                                   
                                                </Columns>
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <HeaderStyle Height="32px" BackColor="#A55129" Font-Bold="True" ForeColor="White"/>
                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                            </asp:GridView>
                                  
                               
                            </div>
                        </div>
        </div>
          
        </div>
       <%--   <uc2:MsgBox ID="msgBox" runat="server" />--%>
            <uc1:MsgBoxs runat="server" id="msgBox" />

        </ContentTemplate>
    </asp:UpdatePanel>
     </div>
</asp:Content>

