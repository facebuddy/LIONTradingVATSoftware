<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Item, App_Web_1kre2rwf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading">Goods/Service Management</div>
        <div class="panel-body">
            <div class="list-group col-md-3 col-sm-4 col-xs-12">
                <a class="list-group-item active">Goods/Service Setup</a>


                <asp:HyperLink class="list-group-item" ID="HyperLink4" NavigateUrl="~/UI/Item/SetItem.aspx" runat="server">Goods/Service Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink14" NavigateUrl="~/UI/Item/Item_Tax_Values_New.aspx" runat="server">Tax Rate Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink3" NavigateUrl="~/UI/Item/SetUnit.aspx" runat="server">Goods Unit Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink5" NavigateUrl="~/UI/Item/SetUintConversion.aspx" runat="server">Unit Conversion</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink15" NavigateUrl="~/UI/Item/setItemOrder.aspx" runat="server">Set Item Order</asp:HyperLink>
                <asp:HyperLink class="list-group-item" ID="HyperLink1" NavigateUrl="~/UI/Item/SetProperty.aspx" runat="server">Property Setup</asp:HyperLink>

                <%--<asp:HyperLink class="list-group-item" ID="HyperLink2" NavigateUrl="~/UI/Item/Item_Tax_Values.aspx" runat="server">Tax Rate</asp:HyperLink>--%>

               



            </div>
            <div class="list-group col-md-3 col-sm-4 col-xs-12">
                <a class="list-group-item active">Requisition Setup</a>
                <asp:HyperLink class="list-group-item" ID="HyperLink2" NavigateUrl="~/UI/Admin/woTemplate.aspx" runat="server" Visible = "true">Work Order Template</asp:HyperLink>
               <asp:HyperLink class="list-group-item" ID="HyperLink16" NavigateUrl="~/UI/Item/GoodsRequisitionToVendor.aspx" runat="server" Visible = "true">Goods Requisition for Vendor</asp:HyperLink>

                

            </div>
            <div class="list-group col-md-3 col-sm-4 col-xs-12">
                <a class="list-group-item active">Others Setup</a>
                
                <asp:HyperLink class="list-group-item" ID="HyperLink6" NavigateUrl="~/UI/Item/PriceDeclaration_M1.aspx" runat="server">উপকরণ/উৎপাদ সম্পর্ক বা সহগ মূল্যভিত্তি ঘোষনাপত্র (মূসক-১)</asp:HyperLink>


                <asp:HyperLink class="list-group-item" ID="HyperLink7" NavigateUrl="~/UI/Item/ItemPriceDeclaration_1KA.aspx" runat="server" Visible = "false">VAT Form-1KA</asp:HyperLink>


                <asp:HyperLink class="list-group-item" ID="HyperLink8" NavigateUrl="~/UI/Item/ItemPriceDeclaration_1KHA.aspx" runat="server" Visible = "false">VAT Form-1KHA</asp:HyperLink>


                <asp:HyperLink class="list-group-item" ID="HyperLink9" NavigateUrl="~/UI/Item/ItemPriceDeclaration_1GA.aspx" runat="server" Visible = "false">VAT Form-1GA</asp:HyperLink>

                
                <asp:HyperLink class="list-group-item" ID="HyperLink10" NavigateUrl="~/UI/Item/ItemPriceDeclaration_1GHA.aspx" runat="server" Visible = "false">VAT Form-1GHA</asp:HyperLink>

                
                <asp:HyperLink class="list-group-item" ID="HyperLink11" NavigateUrl="UI/Item/PriceDeclarartionByTrader.aspx" runat="server" Visible = "false">Price Dclr. By traders</asp:HyperLink>


                <asp:HyperLink class="list-group-item" ID="HyperLink12" NavigateUrl="~/UI/Others/Dispose.aspx" runat="server">অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ (মূসক-২৬)</asp:HyperLink>

                
                <asp:HyperLink class="list-group-item" ID="HyperLink13" NavigateUrl="~/UI/Item/SetRawMaterial.aspx" runat="server" Visible = "false">Raw Material Setup</asp:HyperLink>

                

            </div>
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h4>Goods/Service Management section is divided into 3 sub-categories. They are</h4>
                <ul>
                    <li><b>Goods/Service Setup:</b>  Here users would be able to define/edit new products and their properties. Also the respective tax rates of products can be set from here.</li>
                    <li><b>Goods Unit Setup:</b>  Product or Service unit can be created and users would have the ease of converting those units.</li>
                    <li><b>Others Setup:</b>  Here the user will be able to declare the price of the product via various sub-categories of Musak 1. Also users would be able to dispose any wasted products.	</li>
                </ul>


            </div>

        </div>
    </div>


</asp:Content>

