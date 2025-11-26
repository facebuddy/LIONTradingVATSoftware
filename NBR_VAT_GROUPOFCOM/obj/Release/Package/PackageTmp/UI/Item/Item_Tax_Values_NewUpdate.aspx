<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Item_Tax_Values_NewUpdate.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Item.Item_Tax_Values_NewUpdate" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function a() {
            alert("ModalPanel");
        }
    </script>

  <%--  <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/Mktdr_Custom.css" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>--%>

    <style media="print">
        .noPrint {
            display: none;
        }

        @media print {
            table {
                width: 100%;
            }

            tr, td {
            }

            .full_width {
                width: 100%;
            }
        }

        .yesPrint {
            display: block !important;
        }

        input[type=text], select, textarea, .text_box {
            border: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }
    </script>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                    Set TAX Rate
                </div>

                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                    <div class="row" style="margin-top: 1%">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label ID="label9" runat="server" Text="Category Name:" class="control-label col-sm-5" />
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-input"
                                        data-toggle="dropdown" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" Height="33px">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label ID="label1" runat="server" Text="Sub Category:" class="control-label col-sm-5" />
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpSubCategory" runat="server" class="form-input"
                                        data-toggle="dropdown" AutoPostBack="True"
                                        Height="33px"
                                        OnSelectedIndexChanged="drpSubCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                             <%--   <asp:Label ID="label10" runat="server" Text="Item Name:" class="control-label col-sm-5" />--%>
                                <asp:Label ID="label10" runat="server" class="control-label col-sm-5"><span class="required"> * </span>Item Name:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="ddlItemName" runat="server" class="form-input select2"
                                        data-toggle="dropdown"
                                        OnSelectedIndexChanged="ddlItemName_SelectedIndexChanged" Height="33px"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label ID="label16" runat="server" class="control-label col-sm-5"><span class="required"> * </span>Effective Date:</asp:Label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" onkeydown="return (event.keyCode!=13);" Height="34px"
                                        onkeyup="FormatIt(this);" MaxLength="10" ID="txtDate" placeholder="Enter here"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDate"
                                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                        ErrorMessage="Invalid date format." CssClass="litMessage" />
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <fieldset class="scheduler-border">
                            <div class="col-sm-6">
                                <div class="form-group">

                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" Style="margin-left: 45px; width:370px"
                                            ID="txtUnitName" Visible="false"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-sm-6" Visible="false" runat="server" id="hltcharge">
                                <div class="form-group">
                                    <div class="col-sm-7">
                                        <label>Health Care Surcharge</label>
                                        <asp:TextBox runat="server" ID="txthealthSurcharge" ></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            
                        </fieldset>
                    </div>
                </div>


                <div class="panel-body" style="padding-top: 0px; padding-bottom: 5px">
                 
                   
                    <div class="row">
                        <table style="width: 100%">
                            <tr style="height: auto">
                               
                                <td rowspan="2" style="width: 30%; padding-bottom: 5px">
                                     <asp:CheckBox runat="server" ID="chkFxdCD" style="margin-left:10px" /> Is Fixed CD ?
                                    <asp:GridView ID="dgvItemTaxCategoryFalse" runat="server" AutoGenerateColumns="False"
                                        CssClass="sGrid" DataKeyNames="tax_id" Width="95%" CellPadding="3" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                        <Columns>
                                            <asp:BoundField DataField="tax_code" HeaderText="Tax Code" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" CssClass="grid_item" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Rate ( % )">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTaxVavue" runat="server" Width="60px" Style="text-align: center"
                                                        Text="0" Height="18px" MaxLength="6" />
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtTaxVavue_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="txtTaxVavue"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="grid_item" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                        <EmptyDataTemplate>
                                            <%-- No Items Found.--%>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </td>
                            
                                <td style="width: 35%; vertical-align: top;">Fixed VAT :
                                    <asp:GridView ID="dgvItemTaxPer" runat="server" AutoGenerateColumns="False"
                                        CssClass="sGrid" DataKeyNames="tax_id" Width="95%" CellPadding="3" BackColor="White"
                                        BorderColor="#4CAF50" BorderStyle="None" BorderWidth="1px">
                                        <Columns>
                                            <asp:BoundField DataField="unit_name" HeaderText="Unit" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" CssClass="grid_item" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Per">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPer" Text='<%#Eval("per") %>' runat="server" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbGridtxtPer"
                                                        runat="server" Enabled="True" TargetControlID="txtPer"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="VAT Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQuantity" Text='<%#Eval("vat_amount") %>' runat="server" DataFormatString="{0:n}" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbGridQuantity"
                                                        runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                        <EmptyDataTemplate>
                                            <%-- No Items Found.--%>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </td>
                                <td  style="width: 35%; vertical-align: top;" class="hiddencol">
                                    <asp:GridView  ID="dgvItemLimit" runat="server" AutoGenerateColumns="False"
                                        CssClass="sGrid" DataKeyNames="tax_id" Width="95%" CellPadding="3" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                        <Columns>
                                            <%-- <asp:BoundField DataField="unit_name" HeaderText="Unit" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" CssClass="grid_item" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Lower Limit">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtLowerLimit" Text='<%#Eval("lower_limit") %>' runat="server" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtLowerLimit_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="txtLowerLimit"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Upper Limit">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtUpperLimit" Text='<%#Eval("upper_limit") %>' runat="server" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtUpperLimit_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="txtUpperLimit"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField  HeaderText="VAT Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQuantity" Text='<%#Eval("vat_amount") %>' runat="server" DataFormatString="{0:n}" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbGridQuantity"
                                                        runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                        <EmptyDataTemplate>
                                            <%-- No Items Found.--%>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </td>

                                  
                           </tr>
                              <tr style="height: auto">
                               
                                  <td  style="width: 35%; vertical-align: top;">বিড়ি/ সিগারেট :
                                     <asp:GridView ID="grdTobacco" runat="server" AutoGenerateColumns="False"
                                        CssClass="sGrid" DataKeyNames="tax_id" Width="95%" CellPadding="3" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                        <Columns>
                                            <%-- <asp:BoundField DataField="unit_name" HeaderText="Unit" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" CssClass="grid_item" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Lower Limit">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtLowerLimit" Text='<%#Eval("lower_limit") %>' runat="server" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtLowerLimit_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="txtLowerLimit"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Upper Limit">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtUpperLimit" Text='<%#Eval("upper_limit") %>' runat="server" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtUpperLimit_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="txtUpperLimit"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField  HeaderText="VAT Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQuantity" Text='<%#Eval("vat_amount") %>' runat="server" DataFormatString="{0:n}" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbGridQuantity"
                                                        runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField  HeaderText="SD Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtSDQuantity" Text='<%#Eval("sd_amount") %>' runat="server" DataFormatString="{0:n}" CssClass="input-short-bst"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbSDGridQuantity"
                                                        runat="server" Enabled="True" TargetControlID="txtSDQuantity"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                        <EmptyDataTemplate>
                                            <%-- No Items Found.--%>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </td>

                              </tr>
                                                           
                        </table>

                    </div>

                    
                    <div class="row" style="margin-top: 1%">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label id="label2" class="control-label col-sm-5"><span class="required">* </span>Transaction Type (TT) :</label>
                                <%--  <asp:Label ID="label2" runat="server" Text="Transaction Type:" class="control-label col-sm-5" />--%>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpTransactionType" runat="server" CssClass="form-control select2" OnSelectedIndexChanged="drpTransactionType_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Imported</asp:ListItem>
                                        <asp:ListItem Value="2">Local Purchase</asp:ListItem>
                                        <asp:ListItem Value="3">Sale</asp:ListItem>
                                        <asp:ListItem Value="4">Trade Price</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                       <div class="col-sm-4" runat="server" id="lblLevel">
                            <div class="form-group">
                                <label id="label2" class="control-label col-sm-5">Level :</label>
                                <%--  <asp:Label ID="label2" runat="server" Text="Transaction Type:" class="control-label col-sm-5" />--%>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpLevel" runat="server" CssClass="form-control select2">
                                       
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="col-sm-4" runat="server" id="lblPacket">
                            <div class="form-group">
                                <label id="label2" class="control-label col-sm-5">Packet Category :</label>
                                <%--  <asp:Label ID="label2" runat="server" Text="Transaction Type:" class="control-label col-sm-5" />--%>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpPacketType" runat="server" CssClass="form-control select2">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Witn Filter</asp:ListItem>
                                        <asp:ListItem Value="2">Without Filter</asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="col-sm-3" style="visibility: hidden;">
                            <div class="form-group">
                                <asp:Label ID="label6" runat="server" Text="Effective Date:" class="control-label col-sm-5" />
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-input" onkeydown="return (event.keyCode!=13);" Height="34px"
                                        onkeyup="FormatIt(this);" MaxLength="10" ID="TextBox1" placeholder="Enter here"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDate"
                                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                        ErrorMessage="Invalid date format." CssClass="litMessage" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <%-- <div class="row" >
                          <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required"> * </span>Registration Type :</label>
                                         <asp:Label runat="server" ID="Label5" Visible="false" Text="false" />
                                        <div class="col-sm-7">
                                           <asp:DropDownList ID="drpRegType" runat="server" CssClass="form-control" >
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Regular Registered(Vat)</asp:ListItem>
                                                <asp:ListItem Value="4">Registered ForTurnover</asp:ListItem>
                                                <asp:ListItem Value="5">Not Registered</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                    </div>--%>
                    <div class="row" style="text-align: right">
                        
                       <asp:HyperLink class="btn-btn" style="background-color:#4CAF50;text-align:center" Height="25px" Width="100px" NavigateUrl="~/UI/Item/ImportTaxRateExcel.aspx" runat="server">Import Excel</asp:HyperLink>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50; float: right"
                            Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnShowList" runat="server" CssClass="btn-btn"
                            Style="background-color: #5CB85C; float: right;" Text="Show Item Tax List"
                            OnClick="btnShowList_Click" />
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color: #5CB85C; float: right"
                            OnClick="btnRefresh_Click" Text="Refresh" />
                   
                       </div>
                    <div class="row" runat="server" visible="false">
                         <div class="col-md-12">
                                        <div class="col-sm-3"></div>
                                        <div class="col-md-6">
                                            <asp:FileUpload ID="FileUpload1" runat="server" Style="background: #E0EBF5" />
                                         <%--   <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload and Check" CssClass="btn btn-primary btn-sm" />--%>
                                            <asp:Label ID="Label33" runat="server"></asp:Label>
                                            <%--<asp:Button ID="btnExcelSave" runat="server" OnClick="btnExcelSave_Click" Text="Save" CssClass="btn btn-primary btn-sm" />--%>
                                        </div>
                                        <div class="col-sm-3"></div>
                                    </div></div>
                    <div class="row">
                        <asp:GridView ID="gvItemTaxValues" runat="server" Style="width: 97%; margin-left: 15px"
                            CssClass="sGrid" Width="81%" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px">
                            <Columns>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                            <EmptyDataTemplate>
                                <%-- No Items Found.--%>
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>
                    <div class="row" id="dvdgvCountry">
                        <asp:GridView ID="dgvCountry" runat="server" AutoGenerateColumns="False" Style="width: 97%; margin-left: 15px"
                            DataKeyNames="item_id" CssClass="sGrid"
                            OnRowDeleting="dgvCountry_RowDeleting" Width="100%"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" AllowPaging="True"
                            OnPageIndexChanging="dgvCountry_PageIndexChanging"
                            OnSelectedIndexChanged="dgvCountry_SelectedIndexChanged" PageSize="15"
                            AutoGenerateSelectButton="True">
                            <Columns>
                                <asp:BoundField DataField="hs_code" HeaderText="HS Code">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="item_name" HeaderText="Item Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="unit_code" HeaderText="Unit Code">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd" HeaderText="CD">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="rd" HeaderText="RD">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sd" HeaderText="SD">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vat" HeaderText="VAT">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AT_" HeaderText="AT">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ait" HeaderText="AIT">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="atv" HeaderText="ATV" Visible="false">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tti" HeaderText="TTI" Visible="false">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>

                                <%--  <asp:BoundField DataField="annx_1" HeaderText="Annx.-1">
                                    <HeaderStyle CssClass="grid_item_header" Wrap="False" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="trade_price" HeaderText="Trade Price">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="trns_type" HeaderText="Transaction Type" Visible="true">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True"
                                    Visible="False">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True"
                                    Visible="False">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                            <EmptyDataTemplate>
                                <%-- No Items Found.--%>
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>
                    <%--20-OCT-2019--PER--%>
                    <div class="row">
                        <asp:GridView ID="GridViewPer" runat="server" AutoGenerateColumns="False" Style="width: 97%; margin-left: 15px"
                            DataKeyNames="item_id" CssClass="sGrid"
                            Width="100%" OnSelectedIndexChanged="GridViewPer_SelectedIndexChanged"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" AllowPaging="True" PageSize="15"
                            AutoGenerateSelectButton="True">
                            <Columns>
                                <asp:BoundField DataField="hs_code" HeaderText="HS Code">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="item_name" HeaderText="Item Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="unit_code" HeaderText="Unit Code">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="per" HeaderText="Per">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tax_value" HeaderText="Tax">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="trns_type" HeaderText="Transaction Type" Visible="true">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True"
                                    Visible="False">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True"
                                    Visible="False">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                            <EmptyDataTemplate>
                                <%-- No Items Found.--%>
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>
                    <%--20-OCT-2019--UPPER LIMIT,LOWER LIMIT--%>
                    <div class="row">
                        <asp:GridView ID="GridViewUpperLower" runat="server" AutoGenerateColumns="False" Style="width: 97%; margin-left: 15px"
                            DataKeyNames="item_id" CssClass="sGrid"
                            Width="100%" OnSelectedIndexChanged="GridViewUpperLower_SelectedIndexChanged"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" AllowPaging="True" PageSize="15"
                            AutoGenerateSelectButton="True">
                            <Columns>
                                <asp:BoundField DataField="hs_code" HeaderText="HS Code">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="item_name" HeaderText="Item Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="unit_code" HeaderText="Unit Code">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="lower_limit" HeaderText="Lower Limit">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="upper_limit" HeaderText="Upper Limit">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tax_value" HeaderText="Tax">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="trns_type" HeaderText="Transaction Type" Visible="true">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True"
                                    Visible="False">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True"
                                    Visible="False">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                            <EmptyDataTemplate>
                                <%-- No Items Found.--%>
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>

                     <%--29-Spt-2020--UPPER LIMIT,LOWER LIMIT Tobacco--%>

                    <div class="row">
                        <asp:GridView ID="GridTobacco" runat="server" AutoGenerateColumns="False" Style="width: 97%; margin-left: 15px"
                            DataKeyNames="item_id" CssClass="sGrid"
                            Width="100%" OnSelectedIndexChanged="GridViewUpperLower_SelectedIndexChanged"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" AllowPaging="True" PageSize="15"
                            AutoGenerateSelectButton="True">
                            <Columns>
                                <asp:BoundField DataField="hs_code" HeaderText="HS Code">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="item_name" HeaderText="Item Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="unit_code" HeaderText="Unit Code">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="lower_limit" HeaderText="Lower Limit">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="upper_limit" HeaderText="Upper Limit">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tax_value" HeaderText="VAT">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="tax_value" HeaderText="SD">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="trns_type" HeaderText="Transaction Type" Visible="true">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True"
                                    Visible="False">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True"
                                    Visible="False">
                                    <HeaderStyle CssClass="grid_item_header" />
                                    <ItemStyle CssClass="grid_item" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                            <EmptyDataTemplate>
                                <%-- No Items Found.--%>
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </div>
                    <div class="gridDiv table-responsive paddingsmall">
                                <asp:GridView ID="gvExcelFile" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                  DataKeyNames="ItemID"  OnRowDataBound="gvExcelFile_RowDataBound" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
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
    <uc1:MsgBoxs runat="server" id="msgBox" />
    <%--<uc2:MsgBox ID="msgBox" runat="server" />--%>
 <%--   <uc2:MsgBox ID="msgBox" runat="server" />--%>
</asp:Content>
