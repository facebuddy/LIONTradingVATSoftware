<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_woTemplate, App_Web_bxnrqbtx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container-fluid">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel panel-group">
                    <div class="panel panel-primary">
                        <div class="panel panel-heading text-center" style="font-family:Tahoma; font-size:18px;" ><b>Template Creation for Work Order</b></div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label">Organization : </label>
                                        <asp:Label runat="server" ID="lblOrganization" CssClass="col-sm-8 text-left" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-3 control-label">Address : </label>
                                        <asp:Label runat="server" ID="lblOrgAddress" CssClass="col-sm-9 text-left" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-3 control-label">BIN : </label>
                                        <asp:Label runat="server" ID="lblOrgBIN" CssClass="col-sm-9 text-left" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label">Branch Name : </label>
                                        <div class="col-sm-7">
                                             <asp:DropDownList runat="server" ID="ddlOrgBranch" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgBranch_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                       
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-3 control-label">Address : </label>
                                        <asp:Label runat="server" ID="lblOrgBranchAddress" CssClass="col-sm-9 text-left" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-3 control-label">BIN : </label>
                                        <asp:Label runat="server" ID="lblOrgBranchBIN" CssClass="col-sm-9 text-left" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label">Template Number : </label>
                                        <div class="col-sm-7">
                                             <asp:TextBox runat="server" ID="txtTempNo" CssClass="form-control" ></asp:TextBox>
                                        </div>
                                       
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-4 control-label">Effective Date To : </label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtEffectiveDate" CssClass="form-control" style="font-size:11pt" />
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtEffectiveDate"/>
                                        </div>
                                        
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-3 control-label">Year : </label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control" />
                                        </div>
                                        <div class="col-sm-4"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                 <div class="col-md-4"></div>
                                <div class="col-md-4"></div>
                                <div class="col-md-4">
                                    <asp:Button runat="server" ID="btnSaveWOTemplate" Text="Save WO Template" CssClass="btn-btn" Style="background-color:#4CAF50;float:right" OnClick="btnSaveWOTemplate_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border" style="font-size:16px">পণ্য উৎপাদনে ব্যবহার্য উপকরন / কাঁচামাল ও প্যাকিং সামগ্রীর নাম ও বিবরণ</legend>
                                    <div class="row">
                                        <asp:GridView runat="server" ID="gvRawItem" AutoGenerateColumns="False" Width="96%" style="margin:2%" ShowFooter="True"
                                            OnSelectedIndexChanged="gvRawItem_SelectedIndexChanged"
                                            OnRowDataBound="gvRawItem_RowDataBound"
                                            OnRowDeleting="gvRawItem_RowDeleting" 
                                            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                                            <HeaderStyle  CssClass="GridViewHeaderStyle" />
                                            <AlternatingRowStyle BackColor="#DCDCDC" />
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/Images/Trash.gif" />
                                                <asp:TemplateField HeaderText="Category">
                                                    <ItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Item">
                                                    <ItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlItem" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Unit">
                                                    <ItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlUnit" CssClass="form-control"></asp:DropDownList>
                                                    </ItemTemplate>
                                                     <FooterStyle HorizontalAlign="Right" />
                                                         <FooterTemplate>
                                                             <asp:TextBox ID="txtAddRowNo" runat="server" Width="50px"></asp:TextBox>
                                                         </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <FooterTemplate>
                                                             <asp:Button ID="btnNewRow" runat="server" CssClass="button" onclick="ButtonAdd_Click" Text="New Row" />
                                                         </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                    
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rate">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtRate" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discount">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtTax" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#000065" />
                                        </asp:GridView>
                                        <input id="scrollPos" runat="server" type="hidden" value="0" />
                                        <input id="scrollPosLeft" runat="server" type="hidden" value="0" />
                                        <asp:ObjectDataSource ID="dsCategory" runat="server" SelectMethod="getAllItemCategoryWithBlankRowForBOM" TypeName="SetItemBLL">
                                        </asp:ObjectDataSource>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="panel panel-primary">
                                <div class="panel panel-body">
                                    <div class="row">
                                        <asp:GridView runat="server" ID="gvAllTemplate" Width="100%" AutoGenerateColumns="False" DataKeyNames="template_id"
                                            OnRowDeleting="gvAllTemplate_RowDeleting" 
                                            OnRowDataBound="gvAllTemplate_RowDataBound" 
                                            CssClass="mydatagrid" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" CellPadding="4">
                                            <Columns>
                                                <asp:BoundField HeaderText="Template No" DataField="TemplateNo" />
                                                <asp:BoundField HeaderText="Template Year" DataField="TemplateYear" />
                                                <asp:BoundField HeaderText="Effective Date" DataField="EffectiveDate" />
                                               <%--<asp:TemplateField HeaderText="Template No">
                                                   <ItemTemplate>
                                                       <asp:Label runat="server" ID="lblTemplateNo" Text='<%# Eval("TemplateNo") %>' />
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Template Year">
                                                   <ItemTemplate>
                                                       <asp:Label runat="server" ID="lblTemplateYear" Text='<%# Eval("TemplateYear") %>' />
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Effective Date">
                                                   <ItemTemplate>
                                                       <asp:Label runat="server" ID="lblTemplateEffectiveDate" Text='<%# Eval("EffectiveDate") %>' />
                                                   </ItemTemplate>
                                               </asp:TemplateField>--%>
                                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="true" />
                                            </Columns>
                                            
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                 <uc2:MsgBox ID="msgBox" runat="server" style="background:#0094ff"/>
            </ContentTemplate>
        </asp:UpdatePanel>
       <%-- <div class="row">
            <asp:GridView runat="server" ID="gvAllTemplate" Width="100%" AutoGenerateColumns="False" DataKeyNames="template_id"
                OnRowDeleting="gvAllTemplate_RowDeleting" 
                OnRowDataBound="gvAllTemplate_RowDataBound"
                OnSelectedIndexChanged="gvAllTemplate_SelectedIndexChanged" 
                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="true" />
                    <asp:TemplateField HeaderText="Template No">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTemplateNo" Text='<%# Eval("TemplateNo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Template Year">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTemplateYear" Text='<%# Eval("TemplateYear") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Effective Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTemplateEffectiveDate" Text='<%# Eval("EffectiveDate") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="true" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>--%>
    </div>
</asp:Content>
