<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Default2, App_Web_0aej32q1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <script type="text/javascript">
        function dateValidation(ID) {
            var Date = ID.value;
            var arr = Date.split("/");
            var d = arr[0];
            var m = arr[1];
            var y = arr[2];
            if (d.length === 1)
                d = '0' + d;
            if (m.length === 1)
                m = '0' + m;
            var date = d + '/' + m + '/' + y;
            console.log(date);
            ID.value = date;

        }

        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class=" panel-group">
                    <div class="panel panel-primary">
                        <div class=" panel-heading text-center">
                            <p>চালানভিত্তিতে রপ্তানি প্রত্যর্পণ গ্রহণের জন্য তথ্য সরবরাহ </p>
                        </div>
                        <div class="panel panel-body">
                            <div class="row" style="margin-top: -1%; background: #FFD9C3">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Organization Name :</label>
                                        <div class="col-sm-7">
                                            <asp:Label runat="server" CssClass="control-label text-left" ID="lblOrgName"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Organization Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label runat="server" CssClass="control-label text-left" ID="lblOrgAddress"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Organization BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Label runat="server" CssClass="control-label text-left" ID="lblOrgBIN"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 0.5%;">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Branch Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="form-control" Style="height: 27px; text-align: left" AutoPostBack="True" OnSelectedIndexChanged="ddlBranchName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Branch Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label runat="server" ID="lblBranchAddress"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Branch BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Label runat="server" ID="lblBranchBIN"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 0.5%;">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">পণ্যের ধরণ :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItemType" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">বিক্রয় চালান নং :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlSaleChallanNo" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSaleChallanNo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">পণ্যের নাম :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItem" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="hfSalesItemQuantity" />
                                            <asp:HiddenField runat="server" ID="hfPUnitID" />
                                            <asp:HiddenField runat="server" ID="hfPUnitName" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">মূল্য ঘোষণা নম্বর :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlPriceDeclarationNo" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPriceDeclarationNo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">ব্যবহৃত পণ্যের নাম :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlIngrediants" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIngrediants_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">আবেদনের তারিখ :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="dtpDateApply" CssClass="form-control" onchange="dateValidation(this);" Style="font-size: 11pt" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender runat="server" ID="cc1" TargetControlID="dtpDateApply" Animated="true" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">পণ্যের বিবরণ :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblItemDescription" runat="server" CssClass="form-control"></asp:Label>
                                            <asp:HiddenField runat="server" ID="hfItemID" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">সামঞ্জস্যপূর্ণ কোড :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblHSCode" runat="server" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">একক প্রতি মূল্য :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblUnitPrice" runat="server" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">ব্যবহৃত পরিমাণের মূল্য :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtUsedItemPrice" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">পরিমাণ :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblItemQty" runat="server" CssClass="form-control"></asp:Label>
                                            <asp:Label ID="lblItemUnit" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">মূল্য সংযোজন কর :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblVAT" runat="server" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">আমদানি শুল্ক :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblImportTax" runat="server" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">সম্পুরক শুল্ক :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblSd" runat="server" CssClass="form-control"></asp:Label>
                                            <asp:HiddenField ID="hfDetailId" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">পণ্যের একক :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblIngreItemUnit" CssClass="form-control" runat="server"></asp:Label>
                                            <asp:HiddenField runat="server" ID="hfunitID" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-7 col-md-offset-5">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-md-offset-6">
                                    <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="btn btn-info btn-sm" OnClick="btnAddItem_Click" />
                                    <asp:Button ID="btnAddItem0" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" OnClick="btnAddItem0_Click" />
                                    <asp:Button ID="btnApply" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="btnApply_Click" />
                                    <asp:Button ID="btnApply0" runat="server" Text="Refresh" CssClass="btn btn-success btn-sm" OnClick="btnApply0_Click" />
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning btn-sm" OnClientClick="return PrintPanel();" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 1%">
                                <asp:GridView runat="server" ID="gvIngrediants" Width="100%" DataKeyNames="ItemID" AutoGenerateColumns="false" CssClass="mydatagrid"
                                    PagerStyle-CssClass="gvpager" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows"
                                    OnRowDataBound="gvIngrediants_RowDataBound"
                                    OnRowDeleting="gvIngrediants_RowDeleting"
                                    OnSelectedIndexChanged="gvIngrediants_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField HeaderText="ক্রমিক সংখ্যা" DataField="RowNo" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="gvItemID" Value='<%# Eval("ItemID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="পণ্যের বিবরণ" DataField="ItemName" />
                                        <%--<asp:TemplateField HeaderText="পণ্যের বিবরণ">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="gvItemName" Text='<%# Eval("ItemName") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="gvUnitID" Value='<%# Eval("UnitID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="একক" DataField="UnitName" />
                                        <%--<asp:TemplateField HeaderText="একক">
                                            <ItemTemplate>
                                                    <asp:Label ID="gvUnit" Text='<%# Eval("UnitName") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:BoundField HeaderText="সামঞ্জস্যপূর্ণ কোড" DataField="HSCode" />
                                        <%--<asp:TemplateField HeaderText="সামঞ্জস্যপূর্ণ কোড">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="gvItemHsCode" Text='<%# Eval("HSCode") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="পরিমাণ">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="gvQuantity" Text='<%# Eval("Quantity") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="একক প্রতি মূল্য">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="gvUnitPriceBDT" Text='<%# Eval("UnitPrice") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ব্যবহৃত পরিমাণের মূল্য">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="gvUsedItemPrice" Text='<%# Eval("UsedQuantityPrice") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="আমদানি শুল্ক">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="gvImportTax" Text='<%# Eval("ImportTax") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="সম্পূরক শুল্ক">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="gvSD" Text='<%# Eval("SD") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="মূল্য সংযোজন কর">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="gvVAT" Text='<%# Eval("VAT") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        Data Not Found
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <%-- <asp:GridView ID="dgvItems" runat="server" 
                                    CssClass="sGrid" Width="100%" AutoGenerateColumns="False" DataKeyNames="" HorizontalAlign="Center" >
                                    <Columns>
                                        <asp:BoundField HeaderText="ক্রমিক সংখ্যা" DataField="RowNo" />
                                        <asp:BoundField HeaderText="পণ্যের ধরণ" DataField="ItemType" />
                                        <asp:BoundField HeaderText="পণ্যের বিবরণ" DataField="ItemName" />
                                        <asp:BoundField HeaderText="সামঞ্জস্যপূর্ণ কোড" DataField="ItemHsCode" />
                                        <asp:BoundField DataField="Quantity" HeaderText="পরিমাণ" />
                                        <asp:BoundField DataField="UnitPriceBDT" HeaderText="একক প্রতি মূল্য" />
                                        <asp:BoundField DataField="UsedItemPrice" HeaderText="ব্যবহৃত পরিমাণের মূল্য" />
                                        <asp:BoundField DataField="ImportTax" HeaderText="আমদানি শুল্ক" />
                                        <asp:BoundField DataField="SD" HeaderText="সম্পূরক ও অন্যান্য শুল্ক" />
                                        <asp:BoundField DataField="VAT" HeaderText="মূল্য সংযোজন কর" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif" ShowSelectButton="True" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                    <EditRowStyle HorizontalAlign="Center" />
                                </asp:GridView>--%>
                            </div>

                        </div>

                    </div>
                    <div class="panel panel-default">
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Panel ID="pnlContents" runat="server">


                                        <div class="row">
                                            <p style="text-align: center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                                            <p style="text-align: center; margin-top: -1%">জাতীয় রাজস্ব বোর্ড </p>
                                            <p style="text-align: center; margin-top: -1%">ঢাকা।</p>
                                            <p style="text-align: center; margin-top: -1%">
                                                চালানভিত্তিতে রপ্তানি প্রত্যর্পণ গ্রহণের জন্য তথ্য সরবরাহ
                                            </p>
                                            <p style="text-align: center; margin-top: -1%">
                                                [বিধি ৩০(৬) দ্রষ্টব্য ]
                                            </p>

                                            <p style="border: 1px solid #000; float: right; margin-right: 15px">
                                                মূসক-<b><span lang="BN-BD">২৪ </span></b>.
                                            </p>
                                            <p style="text-align: center; margin-top: -1%">(প্রতিটি পণ্যের জন্য পৃথকভাবে আবেদন করিতে হইবে)</p>
                                        </div>
                                        <div class="row">

                                            <table style="width: 90%; margin: 14px; border: 0px">

                                                <tr style="background-color: White">

                                                    <td style="width: 25%">আবেদনের তারিখ:</td>

                                                    <td style="width: 35%; text-align: left">
                                                        <asp:Label ID="lblApplyDate" runat="server" Text=""></asp:Label>
                                                    </td>

                                                    <td style="width: 20%">নিবদ্ধন নম্বর:</td>

                                                    <td style="width: 20%">
                                                        <asp:Label ID="lblOrganizationBIN" runat="server" Text=""></asp:Label>
                                                </tr>
                                              
                                                <tr style="background-color: White">

                                                    <td style="width: 25%">প্রতিষ্ঠানের নাম:</td>

                                                    <td style="width: 35%">
                                                        <asp:Label ID="lblOrganizationName" runat="server" Text=""></asp:Label>
                                                    </td>

                                                    <td style="width: 20%">এলাকা কোড:</td>

                                                    <td style="width: 20%">
                                                        <asp:Label ID="lblAreaCode" runat="server" Text=""></asp:Label>
                                                    </td>

                                                </tr>

                                                <tr style="background-color: White">

                                                    <td style="width: 25%">প্রতিষ্ঠানের ঠিকানা:</td>

                                                    <td style="width: 35%">
                                                        <asp:Label ID="lblOrganizationAddress" runat="server" Text=""></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr style="background-color: White">

                                                    <td style="width: 25%">পণ্যের নাম:</td>

                                                    <td style="width: 35%">
                                                        <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
                                                    </td>

                                                    <td style="width: 20%">পণ্যের একক:</td>

                                                    <td style="width: 20%">
                                                        <asp:Label ID="lblProductUnit" runat="server" Text=""></asp:Label></td>

                                                </tr>

                                            </table>
                                        </div>

                                        <table border="1" class="table table-bordered" style="width: 100%; border-collapse: collapse">
                                            <tr style="background-color: White">
                                                <td colspan="9" style="text-align: center; font-family: Arial; font-weight: bold">প্রতি একক উৎপাদনে ব্যবহৃত কাঁচামাল/মোড়কের বিবরণ 
                                                </td>
                                            </tr>
                                            <tr style="background-color: White">
                                                <td style="width: 5%; text-align: center">
                                                    <strong>ক্র: নং</strong>
                                                </td>
                                                <td style="width: 15%; text-align: center">
                                                    <strong>পণ্যের নাম ও বিবরণ</strong>
                                                </td>
                                                <td style="width: 10%; text-align: center">
                                                    <strong>সামঞ্জস্যপূর্ণ কোড</strong>
                                                </td>
                                                <td style="width: 10%; text-align: center">
                                                    <strong>পরিমান </strong>
                                                </td>
                                                <td style="width: 10%; text-align: center">
                                                    <strong>একক প্রতি মূল্য</strong>
                                                </td>
                                                <td style="width: 10%; text-align: center">
                                                    <strong>ব্যবহৃত পরিমানের মূল্য </strong>
                                                </td>
                                                <td style="width: 10%; text-align: center">
                                                    <strong>আমদানি শুল্ক</strong>
                                                </td>
                                                <td style="width: 10%; text-align: center">
                                                    <strong>সম্পূরক ও অন্যান্য শুল্ক</strong>
                                                </td>
                                                <td style="width: 10%; text-align: center">
                                                    <strong>মূল্য সংযোজন কর</strong>
                                                </td>
                                            </tr>
                                            <tr style="background-color: White">
                                                <asp:Label runat="server" ID="lblInfoShow"></asp:Label>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <p style="font-weight: bold">সংযোজনী :</p>
                                                    <p style="margin-top: -2%;">
                                                        ১।  কাঁচামাল/মোড়ক ক্রয়/আমদানি সংক্রান্ত দলিল <asp:Label runat="server" Style="border:1px solid #000;height: 20px;" width="35px" />  সংখ্যা <asp:Label runat="server" Style="border:1px solid #000;height: 20px;" width="35px" /> 
                                                        <br />
                                                        আমি ঘোষণা করিতেছি যে, ঘোষণায় প্রদত্ত সকল তথ্য সত্য ও সঠিক।
                                                    </p>

                                                    <p>
                                                        তারিখ:  <asp:Label runat="server" ID="lblDateha" />
                                                    </p>
                                                    <p style="float: right; padding-right: 1%">
                                                        করদাতার স্বাক্ষর
                                                    </p>
                                                </td>
                                                <td colspan="5">
                                                    <p style="font-weight: bold">(স্থানীয় মূল্য সংযোজন কর কার্যালয় পূরণ করিবে)</p>
                                                    <p style="margin-top: -2%;">
                                                        ১। আবেদন ........................ তারিখে গ্রহণ করা হইল।
                                                        <br />
                                                        ২। আবেদন ........................ তারিখে পরিদপ্তরে প্রেরণ করা হইল।  
                                                    </p>
                                                    <p>
                                                        তারিখ: 
                                                    </p>
                                                    <p style="float: right; padding-right: 1%">
                                                        [রাজস্ব কর্মকর্তার] স্বাক্ষর
                                                    </p>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="row">
                                            <p style="text-align: center; font-weight: bold;">
                                                (পরিদপ্তরের ব্যবহারের জন্য)
                                            </p>
                                        </div>
                                        <div class="row" style="border: 1px solid #000; margin-left: 0.05%; margin-right: 0.05%">
                                            <p style="margin-top: 0.5%">
                                                ১। প্রয়োজনীয় পরীক্ষায় প্রত্যর্পণ প্রদানযোগ্য বিবেচিত হইলো <asp:Label runat="server" Style="border:1px solid #000;height: 13px;" width="15px" />
                                                <br>
                                                ২। প্রতি একক রপ্তানির জন্য মোট .......................... টাকা কর রেয়াত/প্রত্যর্পণ হিসাবে নির্ধারণ করা হইল।
                                                <br>
                                                ৩। নথি নং ................................ মাধ্যমে তাহাকে বিষয়াবলি অবহিত করা হইল ও প্রত্যর্পণের পরিমান নির্ধারণের জন্য আবেদনের জন্য অনুরোধ করা হইল। 
                                            </p>
                                            <p>
                                                তারিখ: 
                                            </p>
                                            <p style="float: right; padding-right: 1%">
                                                ক্ষমতাপ্রাপ্ত কর্মকর্তার স্বাক্ষর
                                            </p>
                                        </div>
                                    </asp:Panel>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

