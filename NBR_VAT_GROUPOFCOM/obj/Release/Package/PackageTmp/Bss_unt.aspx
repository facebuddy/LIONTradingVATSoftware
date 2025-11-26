<%@ page title="" language="C#" masterpagefile="~/LoginMasterPage.master" autoeventwireup="true" inherits="Bss_unt, App_Web_1kre2rwf" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Styles/str.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="mainDiv" class="container-fluid">
        <div class="row" >
                
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-4" style="margin-left:-30px">
                    <div class="form-group form-group-sm">
                        <asp:Label class="col-sm-5 control-label text-right" runat="server">Business Unit:</asp:Label>
                    </div>
                <div class="col-sm-3">
                    <asp:DropDownList ID="drpSchema" runat="server" CssClass="form-control" AutoPostBack="True" style="width:220px" OnSelectedIndexChanged="drpSchema_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-4" style="margin-left:-30px">
                    <div class="form-group form-group-sm">
                        <asp:Label class="col-sm-5 control-label text-right" runat="server">Business Unit Branch:</asp:Label>
                    </div>
                    <div class="col-sm-7">
                        <asp:DropDownList ID="drpBusinessUnitBranch" runat="server" CssClass="form-control" style="width:220px" >
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-4" style="margin-left:-30px">
                    <div class="form-group form-group-sm">
                        <asp:Label class="col-sm-5 control-label text-right" runat="server" Visible="False">Business Unit:</asp:Label> 
                    </div>
                    <div class="col-sm-7">
                       <asp:Button runat="server" id="btnBusinessUnit" OnClick="btnBusinessUnit_Click" CssClass="btn-btn" style="background-color: #2E86C1;width:220px" Text="Go To"/>
                    </div>
                </div>
            </div>
          </div>
      

          <uc2:MsgBox ID="msgBox" runat="server" />

       

    </div>



</asp:Content>

