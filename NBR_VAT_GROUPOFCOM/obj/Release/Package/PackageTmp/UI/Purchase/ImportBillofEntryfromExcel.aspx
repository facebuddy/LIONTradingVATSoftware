<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Purchase_ImportBillofEntryfromExcel, App_Web_attcokcq" %>


<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Item.ascx" TagName="ItemNav" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/bootstrap/bootstrap.css" />
    <style type="text/css">
        hr {
            padding: 0px;
            margin-top: 0px;
            margin-bottom: 5px;
        }

        .PnlDesign {
            border: solid 1px #000000;
            height: 100px;
            width: 115%;
            overflow: scroll;
            background-color: #EAEAEA;
            font-size: 15px;
            font-family: Arial;
        }

        .txtbox {
            background-image: url(../images/drpdwn.png);
            background-position: right top;
            background-repeat: no-repeat;
            cursor: pointer;
            cursor: hand;
        }

        
        .wrapper1, .wrapper2 { width: 100%; overflow-x: scroll; overflow-y: hidden; }
        .wrapper1 { height: 20px; }
        .div1 { height: 20px; }
        .div2 { overflow:none; }

    </style>

        <script>
            $(function () {
                $('.wrapper1').on('scroll', function (e) {
                    $('.wrapper2').scrollLeft($('.wrapper1').scrollLeft());
                });
                $('.wrapper2').on('scroll', function (e) {
                    $('.wrapper1').scrollLeft($('.wrapper2').scrollLeft());
                });
            });
            $(window).on('load', function (e) {
                $('.div1').width($('table').width());
                $('.div2').width($('table').width());
            });
        </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
                <div class="row" runat="server" id="form">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        <asp:FileUpload ID="FileUpload1" runat="server" Style="background: #E0EBF5" />
                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload and Check" CssClass="btn btn-primary btn-sm" />
                        <asp:Label ID="Label29" runat="server"></asp:Label>
                       <asp:Button ID="btnExcelSave" runat="server" OnClick="btnExcelSave_Click" Text="Save" CssClass="btn-btn"  style="background-color:#4CAF50"/>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
                <br />
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                <div class="container-fluid">
                  <div class="gridDiv table-responsive paddingsmall" runat="server">
                                <div class="wrapper1">
                                    <div class="div1"></div>
                                 </div>
                              <div class="wrapper2">
                                   <div class="div2">
                                <asp:GridView ID="gvExcelFile" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid"
                            DataKeyNames="ItemID" Width="100%" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" OnRowDataBound="gvExcelFile_OnRowDataBound" >
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="rowNo" Value='<%# Eval("rowNo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>  
                                   </div>
                                </div>
                           </div>
                </div>
            </div>
        </div>
    </div>
 <asp:Panel ID="pnYesNoModal" runat="server" Width="350" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
   
        <div class="panel panel-primary panel-primary-custom">
            <div class="panel-heading panel-heading-custom">  
                <b><asp:Label ID="lblMessage" runat="server" ></asp:Label></b>                         
                
                <div class="clearfix"></div>

            </div>
            <div class="panel-body">
               <div style="text-align:center">
                    <asp:Button ID="btnOK" runat="server" Text="OK" class="button_sub" Width="60px" OnClick="btnOkToReload" />                    
                </div>
           </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnHideButton" runat="server" Text="Close" CssClass="hide"  />
    
    <ajaxToolkit:ModalPopupExtender ID="mpeYesNoModal" runat="server" 
        PopupControlID="pnYesNoModal" TargetControlID="btnHideButton" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>
    <uc2:MsgBox ID="msgBox" runat="server" OnClick="btnOkToReload" />
</asp:Content>


