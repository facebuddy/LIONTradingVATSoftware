<%@ page language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="OrgSetup, App_Web_1kre2rwf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
     <style>
        .list-group-item:not(.active) { background-color: #ffffff; }
        .list-group-item:not(.active):hover { background-color: #f2f2f2 !important; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <div class="panel panel-default">
        <div class="panel-heading"> Organization Setup Panel</div>
        <div class="panel-body">
            <div class="list-group col-md-2 col-sm-4">
                <a class="list-group-item active">Organization Setup</a>
 <asp:HyperLink class="list-group-item"   ID="HyperLink38" NavigateUrl="~/UI/Admin/OrganizationManagementSetup.aspx" runat="server" ><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Master Organization Setup</asp:HyperLink>
 <asp:HyperLink class="list-group-item"   ID="HyperLink39" NavigateUrl="~/UI/Admin/OrganizationSetup.aspx" runat="server" ><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Organization Setup</asp:HyperLink>
   </div>
              </div>
           </div>
                
                 </asp:Content>

