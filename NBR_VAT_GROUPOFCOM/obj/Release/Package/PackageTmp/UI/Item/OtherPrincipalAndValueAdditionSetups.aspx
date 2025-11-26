<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="OtherPrincipalAndValueAdditionSetups.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Item.OtherPrincipalAndValueAdditionSetups" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%-- <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>--%>
    <link href="../../Scripts/select2.min.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <link href="../../Styles/panel.css" rel="stylesheet" />
    <style type="text/css">
        .style2 {
        }

        .hiddencol {
            display: none;
        }

        .style3 {
            text-align: right;
        }

        .GridHeader {
            text-align: center !important;
        }

        .style4 {
            border-left: 1px solid #336699;
            border-right: 1px solid #336699;
            border-top: 1px solid #336699;
            font-size: 18px;
            font-family: SolaimanLipi;
            font-weight: bold;
            color: #4CAF50;
            text-align: center;
            border-bottom: 2px solid #336699;
            padding-bottom: 6px;
            padding-top: 6px;
            border-top-right-radius: 4px;
            border-bottom-right-radius: 0px;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 0px;
            background: rgb(245,246,246);
            background: -moz-linear-gradient(top, rgba(245,246,246,1) 0%, rgba(219,220,226,1) 21%, rgba(184,186,198,1) 49%, rgba(221,223,227,1) 80%, rgba(245,246,246,1) 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(245,246,246,1)), color-stop(21%,rgba(219,220,226,1)), color-stop(49%,rgba(184,186,198,1)), color-stop(80%,rgba(221,223,227,1)), color-stop(100%,rgba(245,246,246,1))); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, rgba(245,246,246,1) 0%,rgba(219,220,226,1) 21%,rgba(184,186,198,1) 49%,rgba(221,223,227,1) 80%,rgba(245,246,246,1) 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, rgba(245,246,246,1) 0%,rgba(219,220,226,1) 21%,rgba(184,186,198,1) 49%,rgba(221,223,227,1) 80%,rgba(245,246,246,1) 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, rgba(245,246,246,1) 0%,rgba(219,220,226,1) 21%,rgba(184,186,198,1) 49%,rgba(221,223,227,1) 80%,rgba(245,246,246,1) 100%); /* IE10+ */
            background: rgb(245,246,246); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f5f6f6', endColorstr='#f5f6f6',GradientType=0 );
            text-transform: capitalize;
        }

        .input_item {
            text-align: right;
        }

        .longTextBox {
            text-align: right;
        }

        .smallSizeDropdownList {
            width: 100px;
        }

        .hiddencol {
            display: none;
        }

        .page_large {
            width: 1198px !important;
            margin: 15px auto 0px 80px !important;
            border: 1px solid #496077;
            -moz-box-shadow: 0 0 16px rgba(0, 0, 0, 0.5);
            -webkit-box-shadow: 0 0 16px rgba(0, 0, 0, 0.5);
            box-shadow: 0 0 16px rgba(0, 0, 0, 0.5);
            background-color: #FFF;
        }

        /*Tab*/

        ul.tab {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            /*border-bottom: 1px solid #ccc;*/
            background-color: #fff;
        }

            /* Float the list items side by side */
            ul.tab li {
                float: left;
                border-left: 1px solid #ccc;
            }

                /* Style the links inside the list items */
                ul.tab li a {
                    display: inline-block;
                    color: black;
                    text-align: center;
                    padding: 5px 6px;
                    text-decoration: none;
                    transition: 0.3s;
                    font-size: 17px;
                    border-bottom: 1px solid #ccc;
                }

                    /* Change background color of links on hover */
                    ul.tab li a:hover {
                        background-color: #ccc;
                    }

                    /* Create an active/current tablink class */
                    ul.tab li a:focus, .active {
                        background-color: #fff;
                        color: #337ab7!important;
                        border-bottom: 1px solid #fff;
                        border-top: 2px solid #91191E;
                        border-bottom: none !important;
                        /*border-left: 1px solid #4CAF50;*/
                        /*border-right: 1px solid #4CAF50;*/
                    }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
        }

        /*End Tab Style*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function openTab(evt, tabName) {
            debugger;
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(tabName).style.display = "block";

            // alert(document.getElementById(tabName));
            if (evt.currentTarget) {
                evt.currentTarget.className += " active";
            }
            else {
                evt.target.className += " active";
            }
            window.localStorage.setItem('activeTab', tabName) 
        }
        $(document).ready(function () {
            var location = window.localStorage.getItem('activeTab');          
            //openTab(event, location);
            $('#link1').trigger('click');
            if (location == 'valueAdditionNonItem') {
                $('#link1').trigger('click');
            }
            if (location == 'valueAdditionItem') {
                $('#link2').trigger('click')             
            }
        });
    </script>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" id="pHead" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 30px; padding-top: 0px">Other Principal And Value Addition Setup</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row" style="margin-top: 10px">
                        <ul class="tab">
                            <li><a href="javascript:void(0)" id="link1" class="tablinks active" onclick="openTab(event, 'valueAdditionNonItem')">Other Principal inputs</a></li>
                            <li><a href="javascript:void(0)" id="link2" class="tablinks " onclick="openTab(event, 'valueAdditionItem')">Value Addition</a></li>
                        </ul>
                        <%-- <asp:HiddenField ID="hfTab" runat="server" />--%>
                        <asp:Label ID="cID" CssClass="hiddencol" runat="server" Text="0,00,000.00" Style="float: right; margin-top: -2%; padding-right: 8%; font-weight: bold; color: red" />
                        <asp:Label runat="server" CssClass="hiddencol" Text="Compare : " Style="float: right; margin-top: -2%; margin-right: 15%; font-weight: bold; color: red" />
                    </div>
                    <div class="row" style="margin-top: 0px; width: 100%">
                        <div id="valueAdditionNonItem" class="tabcontent" style="width: auto;display:block">
                            <div class="row">
                                <div class="col-md-4">

                                    <%--<div id="valueAdditionNonItem" class="tabcontent" style="width: 40%;">
                                <asp:Panel ID="Panel5" runat="server" Height="100%" ScrollBars="Vertical">--%>
                                    <table class="brd_tbl_input1">
                                        <tr>
                                            <td class="grid_row_style">
                                                <asp:Label ID="Label1" runat="server"
                                                    Text="একক পণ্য উৎপাদনে প্রতিটি খাতের মূল্য সংযোজনের পরিমাণ"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style3">
                                                <asp:GridView ID="gvValueAdditionNonItem" runat="server" AutoGenerateColumns="False"
                                                    DataKeyNames="code_id_d" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" Visible="False">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("code_id_d") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIDN1" runat="server" Text='<%# Bind("code_id_d") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত পণ্য ছাড়া">
                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="নির্বাচন করুন">
                                                            <EditItemTemplate>
                                                                <asp:CheckBox ID="CheckBox" runat="server" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Center" />
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <HeaderStyle Height="25px" />
                                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                                    <EmptyDataTemplate>
                                                        No Data Found.
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--</asp:Panel>
                            </div> --%>
                                </div>
                                <div class="col-md-4" style="text-align: center; padding-top: 350px">
                                    <asp:Button ID="ButtonSelect" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50;width:120px;height:50px" Text="Select" OnClick="btnSelect_Click_NonItem" />
                                </div>
                                <div class="col-md-4">
                                    <table class="brd_tbl_input" id="selected_table_non_item">
                                        <tr>
                                            <td class="grid_row_style">
                                                <asp:Label ID="Label2" runat="server"
                                                    Text="নির্বাচিত একক মূল্য সংযোজনের খাত / আইটেমর নাম"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style3">
                                                <asp:GridView ID="slValueAdditionNonItem" runat="server" AutoGenerateColumns="false" AutoPostBack="True" OnSelectedIndexChanged="slValueAddition_SelectedIndexChanged_NonItem"  Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="মূল্য সংযোজনের খাত">
                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblId1" runat="server" Text='<% #Bind("code_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="code_d1" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCode_id_d1" runat="server" AutoPostBack="true" Text='<% #Bind("code_id_d") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Visibility Status" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblvStatus1" runat="server" AutoPostBack="true" Text='<% #Bind("vstatus") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="দেখতে চান ? ">
                                                             <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnStatus1" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50;width:50px;height:30px;" Text='<% #Eval("vstatus").ToString() == "V" ? "Hide" : "View" %>' CommandName="Select" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>                    
                                        </tr>
                                    </table>
                                    <div class="btnArea" style="margin-top:10px;">
                                         <asp:Button ID="ButtonSave" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50; width:100px;height:35px;" Text="Save" OnClick="btnSave_Click_NonItem" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="valueAdditionItem" class="tabcontent" style="width: auto">

                            <div class="row">
                                <div class="col-md-4">

                                    <%--<div id="valueAdditionNonItem" class="tabcontent" style="width: 40%;">
                                <asp:Panel ID="Panel5" runat="server" Height="100%" ScrollBars="Vertical">--%>
                                    <table class="brd_tbl_input">
                                        <tr>
                                            <td class="grid_row_style">
                                                <asp:Label ID="Label6" runat="server"
                                                    Text="একক মূল্য সংযোজনের খাত / আইটেমর নাম"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style3">
                                                <asp:GridView ID="gvValueAddition" runat="server" AutoGenerateColumns="False"
                                                    DataKeyNames="code_id_d" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" Visible="False">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("code_id_d") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID2" runat="server" Text='<%# Bind("code_id_d") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত">
                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="নির্বাচন করুন">
                                                            <EditItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Center" />
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <HeaderStyle Height="25px" />
                                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                                    <EmptyDataTemplate>
                                                        No Data Found.
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--</asp:Panel>
                            </div> --%>
                                </div>
                                <div class="col-md-4" style="text-align: center; padding-top: 350px">
                                    <asp:Button ID="btnSelect" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50;width:120px;height:50px" Text="Select" OnClick="btnSelect_Click" />
                                </div>
                                <div class="col-md-4">
                                    <table class="brd_tbl_input" id="selected_table">
                                        <tr>
                                            <td class="grid_row_style">
                                                <asp:Label ID="Label77" runat="server"
                                                    Text="নির্বাচিত একক মূল্য সংযোজনের খাত / আইটেমর নাম"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style3">
                                                <asp:GridView ID="slValueAddition" runat="server" AutoGenerateColumns="false" AutoPostBack="True" OnSelectedIndexChanged="slValueAddition_SelectedIndexChanged"  Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="মূল্য সংযোজনের খাত">
                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblId" runat="server" AutoPostBack="true" Text='<% #Bind("code_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="code_d" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCode_id_d" runat="server" AutoPostBack="true" Text='<% #Bind("code_id_d") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Visibility Status" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblvStatus" runat="server" AutoPostBack="true" Text='<% #Bind("vstatus") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="দেখতে চান ? ">
                                                             <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnStatus" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50;width:50px;height:30px;" Text='<% #Eval("vstatus").ToString() == "V" ? "Hide" : "View" %>' CommandName="Select" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>                    
                                        </tr>
                                    </table>
                                    <div class="btnArea" style="margin-top:10px;">
                                         <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50; width:100px;height:35px;" Text="Save" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  <%--   <uc2:MsgBox ID="msgBox" runat="server" />--%>

        <uc1:MsgBoxs runat="server" ID="msgBox" />

    </div>
</asp:Content>
