<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="GoodsNservice, App_Web_qr4mw4bg" %>

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
        <div class="panel-heading">Goods/Service Management</div>
        <div class="panel-body">
            <div class="list-group col-md-3 col-sm-4 col-xs-12">
                <a class="list-group-item active">Goods/Service Setup</a>


                <asp:HyperLink class="list-group-item"   ID="HyperLink4" NavigateUrl="~/UI/Item/SetItem.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>Goods/Service Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink12" NavigateUrl="~/UI/Item/Itm_OpeningInfo.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Goods Opening Balance</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink14" NavigateUrl="~/UI/Item/Item_Tax_Values_New.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Tax Rate Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink3" NavigateUrl="~/UI/Item/SetUnit.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Goods Unit Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink5" NavigateUrl="~/UI/Item/SetUintConversion.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Unit Conversion</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink15" NavigateUrl="~/UI/Item/setItemOrder.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Set Item Order</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink1" NavigateUrl="~/UI/Item/SetProperty.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Property Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink18" NavigateUrl="~/UI/Item/GiftItemSetUp.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Gift Item Setup</asp:HyperLink>

                 <asp:HyperLink class="list-group-item"   ID="HyperLink21" NavigateUrl="~/UI/Item/ItemSetSetup.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Set Item Setup</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink19" NavigateUrl="~/UI/Item/OtherPrincipalAndValueAdditionSetup.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i>Other Principle / Value Addition Setup</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink2" NavigateUrl="~/UI/Item/Item_Tax_Values.aspx" runat="server">Tax Rate</asp:HyperLink>--%>

               



            </div>
            <div class="list-group col-md-3 col-sm-4 col-xs-12">
                <a class="list-group-item active">Requisition Setup</a>
                <asp:HyperLink class="list-group-item"   ID="HyperLink2" NavigateUrl="~/UI/Admin/woTemplate.aspx" runat="server" Visible = "true"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Work Order Template</asp:HyperLink>
               <asp:HyperLink class="list-group-item"   ID="HyperLink16" NavigateUrl="~/UI/Item/GoodsRequisitionToVendor.aspx" runat="server" Visible = "true"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Goods Requisition for Vendor</asp:HyperLink>

                

            </div>
            <div class="list-group col-md-3 col-sm-4 col-xs-12">
                <a class="list-group-item active">Others Setup</a>
                
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink60" NavigateUrl="~/UI/Item/PriceDeclaration_M1.aspx" runat="server">উপকরণ/উৎপাদ সম্পর্ক বা সহগ মূল্যভিত্তি ঘোষনাপত্র (মূসক-১)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink6" NavigateUrl="~/UI/Item/PriceDeclaration_M1.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> উপকরণ - উৎপাদ সহগ (Input-Output Coefficient) ঘোষণা (৪.৩)</asp:HyperLink>

                 <asp:HyperLink class="list-group-item"   ID="HyperLink20" NavigateUrl="~/UI/Item/PricedecComparison.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Price declaration comparison 4.3</asp:HyperLink>
                <asp:HyperLink class="list-group-item"   ID="HyperLink7" NavigateUrl="~/UI/Item/ItemPriceDeclaration_1KA.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> VAT Form-1KA</asp:HyperLink>


                <asp:HyperLink class="list-group-item"   ID="HyperLink8" NavigateUrl="~/UI/Item/ItemPriceDeclaration_1KHA.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> VAT Form-1KHA</asp:HyperLink>


                <asp:HyperLink class="list-group-item"   ID="HyperLink9" NavigateUrl="~/UI/Item/ItemPriceDeclaration_1GA.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> VAT Form-1GA</asp:HyperLink>

                
                <asp:HyperLink class="list-group-item"   ID="HyperLink10" NavigateUrl="~/UI/Item/ItemPriceDeclaration_1GHA.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> VAT Form-1GHA</asp:HyperLink>

                
                <asp:HyperLink class="list-group-item"   ID="HyperLink11" NavigateUrl="UI/Item/PriceDeclarartionByTrader.aspx" runat="server" Visible="false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Price Dclr. By traders</asp:HyperLink>


                <%--<asp:HyperLink class="list-group-item" ID="HyperLink17" NavigateUrl="~/UI/Others/Dispose.aspx" runat="server">অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ (মূসক-২৬)</asp:HyperLink>--%>
                <asp:HyperLink class="list-group-item"   ID="HyperLink17" NavigateUrl="~/UI/Others/Dispose.aspx" runat="server"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ</asp:HyperLink>
                <%--<asp:HyperLink class="list-group-item" ID="HyperLink12" NavigateUrl="~/Reports/Mushok4_3.aspx" runat="server">উপকরণ - উৎপাদন সহগ (Input-Output Coefficient) ঘোষণা (৪.৩)</asp:HyperLink>--%>

                
                <asp:HyperLink class="list-group-item"   ID="HyperLink13" NavigateUrl="~/UI/Item/SetRawMaterial.aspx" runat="server" Visible = "false"><i class="fa fa-arrow-circle-right" style="color:green;" aria-hidden="true"></i> Raw Material Setup</asp:HyperLink>

                

            </div>
           <%-- <div class="col-lg-12 col-md-12 col-sm-12">
                <h4>Goods/Service Management section is divided into 3 sub-categories. They are</h4>
                <ul>
                    <li><b>Goods/Service Setup:</b>  Here users would be able to define/edit new products and their properties. Also the respective tax rates of products can be set from here.</li>
                    <li><b>Goods Unit Setup:</b>  Product or Service unit can be created and users would have the ease of converting those units.</li>
                    <li><b>Others Setup:</b>  Here the user will be able to declare the price of the product via various sub-categories of Musak 4.3. Also users would be able to dispose any wasted products.	</li>
                </ul>


            </div>--%>

        </div>
    </div>


</asp:Content>