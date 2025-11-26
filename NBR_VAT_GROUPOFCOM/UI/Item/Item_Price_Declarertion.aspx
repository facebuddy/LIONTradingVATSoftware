<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="UI_Item_Item_Price_Declarertion, App_Web_jwpupl0k" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="jQueryDatePicker" namespace="Westwind.Web.Controls" tagprefix="ww" %>
<%@ Register src= "~/UserControls/Item.ascx" tagname="ItemNav" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
    <link href="Styles/Main.css" rel="Stylesheet" type="text/css" />
  
    <style type="text/css">
       

        .style2
        {
        }

        .style3
        {
            text-align: right;
        }

        .style4
        {
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

        .input_item
        {
            text-align: right;
        }

        .longTextBox
        {
            text-align: right;
        }
        .smallSizeDropdownList
        {
            width:100px;
        }
        .page_large
        {
            width: 1198px !important;
            margin: 15px auto 0px 80px !important;
            border: 1px solid #496077;
            -moz-box-shadow: 0 0 16px rgba(0, 0, 0, 0.5);
	        -webkit-box-shadow: 0 0 16px rgba(0, 0, 0, 0.5);
	        box-shadow:0 0 16px rgba(0, 0, 0, 0.5);
	        background-color:#FFF;
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
            ul.tab li {float: left; border-left:1px solid #ccc;}

            /* Style the links inside the list items */
            ul.tab li a {
                display: inline-block;
                color: black;
                text-align: center;
                padding: 5px 6px;
                text-decoration: none;
                transition: 0.3s;
                font-size: 17px;
                
                border-bottom:1px solid #ccc;
            }

            /* Change background color of links on hover */
            ul.tab li a:hover {
                background-color: #ccc;
                
            }

            /* Create an active/current tablink class */
            ul.tab li a:focus, .active {
                background-color: #fff;
                color:#337ab7!important;
                border-bottom:1px solid #fff;
                border-top: 2px solid #91191E;
                 border-bottom:none !important;
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    

<script type="text/javascript">
    $(document).ready(function () {
        SetScroolBar();
    });
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        SetScroolBar();
    });
    function keepScrollPosition() {
        var s = document.getElementById("detailDivArea").scrollTop;
        var l = document.getElementById("detailDivArea").scrollLeft;
        document.getElementById("<%= scrollPos.ClientID %>").value = s;
        document.getElementById("<%= scrollPosLeft.ClientID %>").value = l;
    }
    function SetScroolBar() {
        document.getElementById("detailDivArea").scrollTop = document.getElementById("<%= scrollPos.ClientID %>").value;
        document.getElementById("detailDivArea").scrollLeft = document.getElementById("<%= scrollPosLeft.ClientID %>").value;
    }
    function Onscrollfnction() {
        var div = document.getElementById('detailDivArea');
        var div2 = document.getElementById('HeaderDiv');
        //****** Scrolling HeaderDiv along with DataDiv ******
        div2.scrollLeft = div.scrollLeft;
        keepScrollPosition();
        return false;
    }

    function showTotalPrice(txtPriceId) {
        var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
        var rowCount = jsGvItem.rows.length;
        var totalPrice = 0;
        for (var i = 0; i < rowCount - 1; i++) {
            if (jsGvItem.rows[i].cells[7].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvItem.rows[i].cells[7].getElementsByTagName('input')[0].value);
                totalPrice = totalPrice + rowPrice;
            }
        }
        document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = totalPrice;
    }
    function showProposedVatTotal(txtVatId) {
        var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");
        var rowCountVat = jsGvVat.rows.length;
        var totalVAT = 0;
        for (var i = 1; i < rowCountVat - 1; i++) {
            //alert(jsGvVat.rows[i].cells[2].getElementsByTagName('input')[0].id);

            if (jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value);
                totalVAT = totalVAT + rowPrice;
            }
        }
        document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = totalVAT;
    }

    function showPrice(txtPriceId, txtVATId) {
        var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
        var rowCount = jsGvItem.rows.length;

        // Count wastage, price      // txtProductionQuantity, txtQuantity
        for (var i = 1; i < rowCount - 1; i++) {
            jsGvItem.rows[i].cells[6].getElementsByTagName('input')[0].value = parseFloat(jsGvItem.rows[i].cells[3].getElementsByTagName('input')[0].value) * parseFloat(jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value) / 100;
            jsGvItem.rows[i].cells[7].getElementsByTagName('input')[0].value = parseFloat(jsGvItem.rows[i].cells[3].getElementsByTagName('input')[0].value) - parseFloat(jsGvItem.rows[i].cells[6].getElementsByTagName('input')[0].value);

            if (parseFloat(jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value) > 0) {
                jsGvItem.rows[i].cells[10].getElementsByTagName('input')[0].value = (parseFloat(jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value) / parseFloat(jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value));
            }

            if (parseFloat(jsGvItem.rows[i].cells[10].getElementsByTagName('input')[0].value) > 0) {
                jsGvItem.rows[i].cells[11].getElementsByTagName('input')[0].value = parseFloat(jsGvItem.rows[i].cells[3].getElementsByTagName('input')[0].value) * parseFloat(jsGvItem.rows[i].cells[10].getElementsByTagName('input')[0].value);
            }
        }
        // End Count wastage, 

        var quanatityTotal = 0;
        for (var i = 1; i < rowCount - 1; i++) {
            if (jsGvItem.rows[i].cells[3].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvItem.rows[i].cells[3].getElementsByTagName('input')[0].value);
                quanatityTotal = quanatityTotal + rowPrice;
            }
        }

        var wastageTotal = 0;
        for (var i = 1; i < rowCount - 1; i++) {
            if (jsGvItem.rows[i].cells[6].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvItem.rows[i].cells[6].getElementsByTagName('input')[0].value);
                wastageTotal = wastageTotal + rowPrice;

                
            }
           
        }

        var itemQuantityTotal = 0;
        for (var i = 1; i < rowCount - 1; i++) {
            if (jsGvItem.rows[i].cells[7].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvItem.rows[i].cells[7].getElementsByTagName('input')[0].value);
                itemQuantityTotal = itemQuantityTotal + rowPrice;
            }
        }


        var totalPrice = 0;
        for (var i = 1; i < rowCount - 1; i++) {
            if (jsGvItem.rows[i].cells[11].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvItem.rows[i].cells[11].getElementsByTagName('input')[0].value);
                totalPrice = totalPrice + rowPrice;
            }
        }

        var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");
        var rowCountVat = jsGvVat.rows.length;
        var totalVAT = 0;
        for (var i = 1; i < rowCountVat; i++) {
            //alert(jsGvVat.rows[i].cells[2].getElementsByTagName('input')[0].id);

            if (jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value);
                totalVAT = totalVAT + rowPrice;
            }
        }
        //Value Addition Non Item
        var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
        var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
        var totalValueAddition = 0;
        for (var i = 1; i < rowCountValueAdditionNonItem; i++) {
           
            if (jsGvValueAdditionNonItem.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[i].cells[1].getElementsByTagName('input')[0].value);
                totalValueAddition = totalValueAddition + rowPrice;
            }
        }
        document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = parseFloat(totalValueAddition).toFixed(2);
        
        

        var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
        var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
        if (sd > 0) {
            document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT).toFixed(2);
        }
        else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

        document.getElementById("<%=txtProposedPrice.ClientID%>").value = totalPrice + totalVAT;


        document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(2);
        document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(2);
        document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(2);

        document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition)).toFixed(2);
       
       

        document.getElementById("<%=txtTotalExpenses.ClientID%>").value = parseFloat(Number(totalVAT)).toFixed(2);

        document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT) * sd / 100).toFixed(2);

        document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100).toFixed(2);

        if (sd > 0) {
            document.getElementById("<%=txtWholeSalePrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100 + ((totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100) * vat / 100)).toFixed(2);
        }
        else {
            document.getElementById("<%=txtWholeSalePrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100 + ((totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100) * vat / 100)).toFixed(2);
        }
    }


    function showNBRPrice(txtPriceId) {

        var jsGvNBRVat = document.getElementById("<%=gvNBRValueAddition.ClientID%>");
        var rowCountNBRVat = jsGvNBRVat.rows.length;
        var totalNBRVAT = 0;
        for (var i = 1; i < rowCountNBRVat; i++) {

            if (jsGvNBRVat.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                var rowNBRPrice = parseFloat(jsGvNBRVat.rows[i].cells[1].getElementsByTagName('input')[0].value);
                totalNBRVAT = totalNBRVAT + rowNBRPrice;
            }
        }

        var NBRActualPrice = document.getElementById("<%=hfNBRPrice.ClientID%>").value;
        var NBRSDRate = document.getElementById("<%= hfNBRSD.ClientID%>").value;

        document.getElementById("<%=txtNBRPrice.ClientID%>").value = totalNBRVAT + Number(NBRActualPrice);
        if (NBRSDRate > 0) {
            document.getElementById("<%= txtNBRSDChargablePrice.ClientID%>").value = parseFloat(totalNBRVAT + Number(NBRActualPrice)).toFixed(2);
        }
        else {
            document.getElementById("<%= txtNBRSDChargablePrice.ClientID%>").value = 0;
        }

        var NBRSDAmount = (totalNBRVAT + Number(NBRActualPrice)) * Number(NBRSDRate) / 100;
        document.getElementById("<%= txtNBRSD.ClientID%>").value = parseFloat(NBRSDAmount).toFixed(2);

        var NBRVATChargablePric = parseFloat((totalNBRVAT + Number(NBRActualPrice)) + Number(NBRSDAmount)).toFixed(2);
        document.getElementById("<%= txtNBRVATChargeablePrice.ClientID%>").value = NBRVATChargablePric;

        document.getElementById("<%= txtNBRWholeSalePrice.ClientID%>").value = parseFloat((Number(NBRVATChargablePric) + (Number(NBRVATChargablePric) * 15 / 100))).toFixed(2);
    }



    //Tab 

  
    function openTab(evt, tabName) {
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
                

               
                evt.currentTarget.className += " active";
            }
    //End Tab
</script>


    <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" 
        cellspacing="2" class="brd_tbl_input" border="0px" width="100%">
        <tr>
            <td class="page_title" colspan="7" align="center">
                উপকরণ/উৎপাদ সম্পর্ক বা সহগ মূল্যভিত্তি ঘোষনাপত্র<uc1:ItemNav ID="ItemNav" runat="server" /></td>
        </tr>
        <tr>
            <td valign="top" align="right"></td>
            <td></td>
            <td align="right"</td>
            <td align="right" style="text-align: left"></td>
            <td align="right"></td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Label ID="Label29" runat="server" Text="প্রতিষ্ঠানঃ "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlOrganization" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="Label27" runat="server" Text="পণ্য ক্যাটাগরীঃ "></asp:Label>
            </td>
            <td align="right" style="text-align: left">
                <asp:DropDownList ID="ddlItemCategory" runat="server" Width="150px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlItemCategory_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="Label36" runat="server" Text="পণ্যঃ"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlItem" runat="server" Width="150px" AutoPostBack="True" 
                    onselectedindexchanged="ddlItem_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblHSCode" runat="server"></asp:Label>
&nbsp;<asp:Label ID="lblUnit" runat="server"></asp:Label>
            </td>
           
        </tr>
        <tr>
            
            <td align="right">
                <asp:Label ID="Label32" runat="server" Text="বৎসরঃ"></asp:Label>
            </td>
            <td align="right" style="text-align: left">
                <asp:DropDownList ID="ddlYear" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="Label33" runat="server" Text="কার্যকর তারিখঃ"></asp:Label>
            </td>
            <td >
                <ww:jQueryDatePicker ID="dtpActiveDate" runat="server" Width="130px" 
                    DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
            </td>
            <td valign="top" align="right">
                <asp:Label ID="Label30" runat="server" Text="মূল্য ঘোষণা নম্বরঃ"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPriceDeclaretionNo" runat="server" Width="150px" 
                    CssClass="text_box"></asp:TextBox>
            </td>
            <td><asp:Button ID="btnSearchPriceDeclaretionNo" runat="server" Text="Search" style="text-align: left" OnClick="btnSearchPriceDeclaretionNo_Click"/> </td>
        </tr>
        <tr>
            <td valign="top" align="right" colspan="7" style="text-align: center">
                <asp:Panel ID="pnlTaxVAT" runat="server">
                
    <table align="center" class="brd_tbl_input" cellpadding="0" cellspacing="0">
        <tr>
            <td style="background-color: #FCEEDA">
                &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="Label59" runat="server" Text="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            </td>
            <td style="background-color: #FCEEDA">
                &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="Label60" runat="server" Text="ভ্যাট আরোপযোগ্য মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            </td>
            <td colspan="2" style="background-color: #FCEEDA">
                <asp:Label ID="Label61" runat="server" Text="শুল্ক ও করসহ বিক্রয়মূল্য" 
                    CssClass="lebel_title"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="background-color: #FCEEDA">
                <asp:Label ID="Label80" runat="server" Text="প্রস্তাবিত মূল্য"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="বর্তমান"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="প্রস্তাবিত"></asp:Label>
            </td>
            <td style="background-color: #FCEEDA">
                <asp:Label ID="Label2" runat="server" Text="সম্পূরক শুল্ক ="></asp:Label>
                <asp:TextBox ID="txtSDRate" runat="server" Width="23px"
                    CssClass="text_box" Enabled="False" ReadOnly="True">0</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label62" runat="server" Text="বর্তমান ="></asp:Label>
                <asp:TextBox ID="txtVATRate" runat="server" Width="23px"
                    CssClass="text_box" Enabled="False" ReadOnly="True">0</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label63" runat="server" Text="প্রস্তাবিত"></asp:Label>
            </td>
            <td style="background-color: #FCEEDA">
                <asp:Label ID="Label64" runat="server" Text="পাইকারী"></asp:Label>
            </td>
            <td class="style2" style="background-color: #FCEEDA">
                <asp:Label ID="Label65" runat="server" Text="খুচরা মূল্য (যদি থাকে)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtProposedPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txtCurrentSDPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txtProposedSDPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtSD" runat="server" Width="100px"
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txtCurrentVATPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txtProposedVATPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtWholeSalePrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
            <td align="center" style="background-color: #FCEEDA">
                <asp:TextBox ID="txtRetailPrice" runat="server" Width="100px" 
                    CssClass="text_box">0.00</asp:TextBox>
            </td>
        </tr>
    </table>
    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="6"></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="7" align="right">
                <asp:Panel ID="Panel2" runat="server" Width="100%">
                
                    <table align="center" style="width:100%;margin:0px;padding:0px">
                        <tr>
                            <td valign="top" style="width:100%;margin:0px;padding:0px">
                                 <ul class="tab">
                                    <li><a href="javascript:void(0)" class="tablinks active" onclick="openTab(event, 'Ingradients')">Principal Inputs</a></li>
                                    <li><a href="javascript:void(0)" class="tablinks" onclick="openTab(event, 'valueAdditionNonItem')">Other inputs</a></li>
                                    <li><a href="javascript:void(0)" class="tablinks " onclick="openTab(event, 'valueAdditionItem')"> Value Addition</a></li>
                                    
                                  
                                </ul>

                               <div id="Ingradients" class="tabcontent" style="display:block;">
                                   <asp:Panel ID="pnDetails" runat="server" Width="">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        <fieldset>
                                            <legend>একক পণ্য উৎপাদনে ব্যবহার্য উপকরন / কাঁচামাল ও প্যাকিং সামগ্রীর নাম ও বিবরণ (অবচয়সহ)</legend>
                                            <div id="HeaderDiv"></div>
                                
                                            <div id="detailDivArea"  style="overflow: auto; border: 0px solid olive; width: 100%; height: 400px;" onscroll="Onscrollfnction();">
                                    
                                            <asp:GridView ID="gvItems" ShowFooter="True" runat="server" 
                                                    AutoGenerateColumns="False" Width="850px"
                                                    CssClass="mGrid"  onrowdeleting="gvItems_RowDeleting" ShowHeader="true"
                                                    onprerender="gvItems_PreRender" onrowdatabound="gvItems_RowDataBound" >
                                            <HeaderStyle  CssClass="GridViewHeaderStyle" />
                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" 
                                        ShowDeleteButton="True" />
                                                     <asp:TemplateField HeaderText="পণ্য ক্যাটাগরি">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="drpCategory" runat="server" CssClass="smallSizeDropdownList" DataSourceID="odsItemCategory"   DataTextField="category_name" DataValueField="category_id" AutoPostBack="true"  OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblDrpCategory" runat="server" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                         <ItemStyle Width="35px" />
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="পণ্য">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="drpItemName" runat="server" 
                                                                CssClass="smallSizeDropdownList" AutoPostBack="True" 
                                                                onselectedindexchanged="drpItemName_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblItemUnitId" runat="server" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblItemUnit" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                         <ItemStyle Width="175px" />
                                                     </asp:TemplateField>

                                                    <asp:TemplateField HeaderText=" গ্রুস ব্যবহার">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtQuantityTotal" runat="server" CssClass="stdTextBox" Text="0.00%" 
                                                                 Width="65px" onblur="showPrice(this)"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtQuantityTotal_FilteredTextBoxExtender" 
                                                                 runat="server" Enabled="True" TargetControlID="txtQuantityTotal" 
                                                                 ValidChars=".0123456789">
                                                             </ajaxToolkit:FilteredTextBoxExtender>
                                                         </ItemTemplate>
                                                         <ItemStyle Width="65px" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                         <FooterTemplate>
                                                             <asp:TextBox ID="txtAddRowNo" runat="server" Width="50px"></asp:TextBox>
                                                         </FooterTemplate>

                                                     </asp:TemplateField>


                                         
                                                     <asp:TemplateField HeaderText="একক">
                                                         <FooterTemplate>
                                                             <asp:Button ID="btnNewRow" runat="server" CssClass="button" 
                                                                 onclick="ButtonAdd_Click" Text="New Row" />
                                                         </FooterTemplate>
                                                         <ItemTemplate>
                                                             <asp:DropDownList ID="ddlUnit" runat="server" Width="100%">
                                                             </asp:DropDownList>
                                                         </ItemTemplate>
                                                         <EditItemTemplate>
                                                             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                         </EditItemTemplate>
                                                         <ItemStyle Width="65px" />
                                                     </asp:TemplateField>
                                        
                                                     <asp:TemplateField HeaderText="অপচয় %">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtWastageParcent" runat="server" CssClass="stdTextBox" Text="0.00%" onblur="showPrice(this)"
                                                                 Width="65px" AutoPostBack="true"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtWastageParcent_FilteredTextBoxExtender" 
                                                                 runat="server" Enabled="True" TargetControlID="txtWastageParcent" 
                                                                 ValidChars=".0123456789">
                                                             </ajaxToolkit:FilteredTextBoxExtender>
                                                         </ItemTemplate>
                                                         <ItemStyle Width="65px" />
                                                     </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="অপচয়">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtPrice" runat="server" CssClass="stdTextBox" 
                                                                 Text="0.00" Width="75px"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtPrice_FilteredTextBoxExtender" 
                                                                 runat="server" Enabled="True" TargetControlID="txtPrice" 
                                                                 ValidChars=".0123456789">
                                                             </ajaxToolkit:FilteredTextBoxExtender>
                                                         </ItemTemplate>
                                                         <FooterStyle HorizontalAlign="Right" />

                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtWastage" runat="server" CssClass="stdTextBox" Text="0.00" AutoPostBack="true"
                                                                 Width="75px"  onblur="showPrice(this)"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtWastage_FilteredTextBoxExtender" 
                                                                 runat="server" Enabled="True" TargetControlID="txtWastage" 
                                                                 ValidChars=".0123456789">
                                                             </ajaxToolkit:FilteredTextBoxExtender>
                                                         </ItemTemplate>
                                                         <FooterTemplate>
                                                             <asp:Button ID="ButtonAdd" runat="server" CssClass="add_new_row_button" 
                                                                 OnClick="ButtonAdd_Click" Text="New Row" Visible="False" />
                                                         </FooterTemplate>
                                                         <ItemStyle Width="65px" />
                                                     </asp:TemplateField>
                                                    <%--/**********/--%>
                                       
                                                    <asp:TemplateField HeaderText="নীট ব্যবহার">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtItemQuantity" runat="server"  Width="65px" onblur="showPrice(this)">0.00</asp:TextBox>
                                                         </ItemTemplate>
                                            
                                             
                                                     </asp:TemplateField>

                                                    

                                                    <asp:TemplateField HeaderText="চালান মূল্য">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtChallanPrice" runat="server" CssClass="stdTextBox" Text="0.00" onblur="showPrice(this)"
                                                                 Width="65px"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtChallanPrice_FilteredTextBoxExtender" 
                                                                 runat="server" Enabled="True" TargetControlID="txtChallanPrice" 
                                                                 ValidChars=".0123456789">
                                                             </ajaxToolkit:FilteredTextBoxExtender>
                                                         </ItemTemplate>
                                                         <ItemStyle Width="65px" />
                                                     </asp:TemplateField>
                                                    <%--Extra--%>
                                                    <asp:TemplateField HeaderText="চালান পরিমান">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtChallanQuantity" runat="server" CssClass="stdTextBox" Text="0.00" onblur="showPrice(this)"
                                                                 Width="65px"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtChallanQuantity_FilteredTextBoxExtender" 
                                                                 runat="server" Enabled="True" TargetControlID="txtChallanQuantity" 
                                                                 ValidChars=".0123456789">
                                                             </ajaxToolkit:FilteredTextBoxExtender>
                                                         </ItemTemplate>
                                                         <ItemStyle Width="65px" />
                                                     </asp:TemplateField>
                                                    <%--End Extra--%>

                                                     <asp:TemplateField HeaderText="উৎপাদন সংখ্যা">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtProductionQuantity" runat="server" CssClass="stdTextBox" Text="0.00" onblur="showPrice(this)"
                                                                 Width="65px"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtProductionQuantity_FilteredTextBoxExtender" 
                                                                 runat="server" Enabled="True" TargetControlID="txtProductionQuantity" 
                                                                 ValidChars=".0123456789">
                                                             </ajaxToolkit:FilteredTextBoxExtender>
                                                         </ItemTemplate>
                                                         <ItemStyle Width="65px" />
                                                     </asp:TemplateField>
                                        

                                                     <asp:TemplateField HeaderText="মূল্য">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtQuantity" runat="server" CssClass="stdTextBox" Text="0.00" onblur="showPrice(this)"
                                                                 Width="65px"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtQuantity_FilteredTextBoxExtender" 
                                                                 runat="server" Enabled="True" TargetControlID="txtQuantity" 
                                                                 ValidChars=".0123456789">
                                                             </ajaxToolkit:FilteredTextBoxExtender>
                                                         </ItemTemplate>
                                                         <ItemStyle Width="65px" />
                                                     </asp:TemplateField>
                                                    

                                                    <asp:TemplateField HeaderText="চালান সূত্র">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtReference" runat="server" CssClass="stdTextBox" TextMode="MultiLine" Rows="1" Columns="1" Height="16" Text="" ToolTip="আমদানি দলিল বা ক্রয় চালান পত্রের নম্বর ও তারিখ লিখুন"
                                                                 Width="65px"></asp:TextBox>
                                                            
                                                         </ItemTemplate>
                                                         <ItemStyle Width="65px" />
                                                     </asp:TemplateField>
                                        


                                                </Columns>
                                
                                                <HeaderStyle CssClass="header"/>
                                            </asp:GridView>
                                            <input id="scrollPos" runat="server" type="hidden" value="0" />
                                            <input id="scrollPosLeft" runat="server" type="hidden" value="0" />
                                            <asp:ObjectDataSource ID="odsItemCategory" runat="server" SelectMethod="getAllItemCategoryWithBlankRow" TypeName="SetItemBLL">
                                            </asp:ObjectDataSource>
                                        </div>
                                        </fieldset>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>

                               </div>

                                <div id="valueAdditionNonItem" class="tabcontent">
                                   <asp:Panel ID="Panel5" runat="server" Height="420px" ScrollBars="Vertical">
                                    <table class="brd_tbl_input">
                                        <tr>
                                            <td class="grid_row_style">
                                                <asp:Label ID="Label5" runat="server" 
                                                    Text="একক পণ্য উৎপাদনে প্রতিটি খাতের মূল্য সংযোজনের পরিমাণ "></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style3">
                                                <asp:GridView ID="gvValueAdditionNonItem" runat="server" AutoGenerateColumns="False" 
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
                                                        <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত পণ্য ছাড়া">
                                                        <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                        <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblTotalValueAdditionNonItem" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtValueAdditionNonItem" runat="server" CssClass="text_box" 
                                                                    onblur="showPrice(this)" Width="50px">0.00</asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
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
                                </asp:Panel>    
                                </div>

                                 <div id="valueAdditionItem" class="tabcontent">
                                  <asp:Panel ID="Panel4" runat="server" Height="420px" ScrollBars="Vertical">
                                    <table class="brd_tbl_input">
                                        <tr>
                                            <td class="grid_row_style">
                                                <asp:Label ID="Label76" runat="server" 
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
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("code_id_d") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত">
                                                        <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                                                        <ItemStyle CssClass="grid_item" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblTotalValueAddition" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtValueAddition" runat="server" CssClass="text_box" 
                                                                    onblur="showPrice(this)" Width="50px">0.00</asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
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
                                </asp:Panel>         
                                </div>

                            
                            </td>
                            
                        </tr>
                        <tr>
                            <td valign="top">
                                <table border="0px">
                                    <tr>
                                       
                                        <td style="width:197px;"></td>
                                        <td> <asp:Label ID="Label81" runat="server" Text="মোট ="></asp:Label> </td>
                                        <td> <asp:TextBox ID="txtSumQuantityTotal" runat="server" Width="75px" 
                                                BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" 
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width:75px">
                                            &nbsp;</td>
                                        <td style="width:70px">
                                            
                                        </td>
                                        <td style="width:75px">
                                            <asp:TextBox ID="txtSumWastage" runat="server" Width="75px" 
                                                BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" 
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>                                           
                                        </td>
                                        <td style="width:75px">
                                            
                                            <asp:TextBox ID="txtSumItemQuantity" runat="server" Width="75px" 
                                                BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" 
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        <td style="width:66px;"></td>
                                        <td style="width:66px;"></td>
                                        <td style="width:75px">
                                             <asp:TextBox ID="txtTotalPrice" runat="server" Width="75px" BackColor="Transparent" 
                                                BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" 
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                       <td style="text-align:right;">Other Inputs:</td>                                       
                                        <td> 
                                            
                                            <asp:TextBox ID="txtTotalExpenses" runat="server" BackColor="Transparent"  ToolTip="Other Inputs "
                                             BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" 
                                             ReadOnly="True" Width="55px"></asp:TextBox>
                                        </td>
                                        <td>Value Addition:</td> 
                                        <td>
                                             <asp:TextBox ID="nonItemTotalExpense" runat="server" BackColor="Transparent" ToolTip="Value Addition"
                                            BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" 
                                            ReadOnly="True" Width="55px"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>

                                    </tr>
                                </table>
                            </td>
                           
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                                            <asp:Button ID="btnSave" runat="server" CssClass="button" 
                        Text="Save Declaration" onclick="btnSave_Click" />
                                            <asp:Button ID="btnRefreshChallan1" runat="server" CssClass="button" 
                        Text="Refresh" onclick="btnRefreshChallan1_Click" />
                <br />
                   
                   
                                            <%--<asp:Button ID="btnApprovePrice" runat="server" CssClass="button" 
                        Text="Approve NBR Price" onclick="btnApprovePrice_Click" Visible="false" />--%>

            </td>
        </tr>
        <tr>
            <td colspan="7" align="right">
                <br />
                <asp:GridView ID="gvDeclaretion" runat="server" AutoGenerateColumns="False" 
                    CssClass="grid" DataKeyNames="price_id" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="price_id" HeaderText="Price ID" Visible="False" >
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="price_declaration_no" 
                            HeaderText="Price Declaration No" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="date_effective" 
                            HeaderText="Effective Date" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        
                        
                        <asp:BoundField DataField="category_name" HeaderText="Item Category">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="item_name" HeaderText="Item">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hs_code" HeaderText="HS Code">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="price_declaration_year" HeaderText="Year">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                        <asp:BoundField DataField="wholesale_prc_sd_vat" HeaderText="Wholesale Price" 
                            ItemStyle-Wrap="false">
                        <ItemStyle HorizontalAlign="Left"/>
                        <HeaderStyle CssClass="grid_item_header" />
                        <ItemStyle CssClass="grid_item" />
                        </asp:BoundField>
                     
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                    <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Panel ID="pnlApprovePrice" CssClass="popupBlock" runat="server">
        <table class="brd_tbl_input"  
            style="border-color: #4CAF50; border-width: medium;">
            <tr>
                <td class="style4" align="center" height="32" colspan="6">
                    জাতীয় রাজস্ব বোর্ড&nbsp;&nbsp;&nbsp; ্তৃক অনুমোদিত মূল্য&nbsp;</td>
                <td align="center" class="style4" height="32">
                    <asp:Label ID="Label78" runat="server" 
                        Text="একক পণ্য উৎপাদনে প্রতিটি খাতের অনুমোদিত মূল্য সংযোজনের পরিমাণ"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="input_item">
                    <asp:Label ID="Label79" runat="server" Font-Bold="True" Text="মূল্য ঘোষণা নং :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPriceDeclarationNo" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:HiddenField ID="hfPriceId" runat="server" />
                </td>
                <td class="style3">
                    <asp:Label ID="lblDesc3" runat="server" Text="মূল্য ঘোষণার তারিখ :"></asp:Label>
                </td>
                <td colspan="2">
                    <ww:jQueryDatePicker ID="dtpNBRApproveDate" runat="server" 
                        DateFormat="dd/MM/yyyy" Width="130px"></ww:jQueryDatePicker>
                </td>
                <td rowspan="5" valign="top">
                    <asp:GridView ID="gvNBRValueAddition" runat="server" AutoGenerateColumns="False" 
                        CssClass="grid" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID0" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="code_name" HeaderText="মূল্য সংযোজনের খাত">
                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" Width="70%" />
                            <ItemStyle CssClass="grid_item" HorizontalAlign="Right" Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ (টাকা)">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtValueAddition0" runat="server" CssClass="text_box" 
                                        onblur="showNBRPrice(this)" Width="50px" 
                                        Text='<%# Bind("cnfrmd_item_value") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="item_value" HeaderText="বর্তমান মূল্য" />
                        </Columns>
                        <HeaderStyle Height="25px" />
                        <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                        <EmptyDataTemplate>
                            No Data Found.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right" class="input_item" colspan="3">
                    <table class="brd_tbl_input" style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblDesc7" runat="server" Font-Bold="True" Text="অনুমোদিত মূল্য"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDesc8" runat="server" Font-Bold="True" 
                                    Text="প্রস্তাবিত মূল্য"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesc0" runat="server" Text="মূল্য :"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txtNBRPrice" runat="server" CssClass="longTextBox" 
                                    Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblPrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                                <asp:HiddenField ID="hfNBRPrice" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSubCategory" runat="server" 
                                    Text="সম্পূরক শুল্ক আরোপযোগ্য মূল্য :"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:TextBox ID="txtNBRSDChargablePrice" runat="server" CssClass="longTextBox" 
                                    Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblNBRSDChargablePrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSubCategory0" runat="server" Text="সম্পূরক শুল্ক :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNBRSD" runat="server" CssClass="longTextBox" Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:HiddenField ID="hfNBRSD" runat="server" />
                                <asp:Label ID="lblNBRSD" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="input_item" align="right" colspan="3">
                    <table class="brd_tbl_input" style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblDesc4" runat="server" Font-Bold="True" Text="অনুমোদিত মূল্য"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDesc5" runat="server" Font-Bold="True" 
                                    Text="প্রস্তাবিত মূল্য"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesc" runat="server" Text="ভ্যাট আরোপযোগ্য মূল্য :"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txtNBRVATChargeablePrice" runat="server" 
                                    CssClass="longTextBox" Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblNBRVATChargeablePrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtNBRSDChargablePrice" 
                                    ErrorMessage="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" SetFocusOnError="True" 
                                    ToolTip="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" ValidationGroup="addSubCategory">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblDesc1" runat="server" Text="পাইকারী মূল্য :"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txtNBRWholeSalePrice" runat="server" CssClass="longTextBox" 
                                    Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblNBRWholeSalePrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesc2" runat="server" Text="খুচরা মূল্য :"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txtNBRRetailPrice" runat="server" CssClass="longTextBox" 
                                    Width="65px"></asp:TextBox>
                            </td>
                            <td class="style3">
                                <asp:Label ID="lblNBRRetailPrice" runat="server" BorderColor="#00CCFF" 
                                    BorderStyle="Solid" BorderWidth="1px" CssClass="label" Width="80px"></asp:Label>
                                <asp:Label ID="lblPriceId" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr>
                <td colspan="6" align="center" valign="middle" height="35px">
                    <asp:Button ID="btnApprove" runat="server" Text="Save"  CssClass="button"
                        ValidationGroup="addSubCategory" onclick="btnApprove_Click" />
                       &nbsp;
                    <asp:Button ID="btnSubClear"  CssClass="button" runat="server" Text="Close" 
                        onclick="btnSubClear_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                        ValidationGroup="addSubCategory" ForeColor="Red" />
                </td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

        <asp:Button ID="btnHiddenForApprovePrice" runat="server" style="display:none"/>
     <ajaxToolkit:ModalPopupExtender ID="modalPopupForApprovePrice" runat="server" 
        PopupControlID="pnlApprovePrice" 
        TargetControlID="btnHiddenForApprovePrice" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>


    <br />
    <br />
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                    <table align="left" class="brd_tbl_input">
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label58" runat="server" Text="Unit"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label53" runat="server" Text="Property 1"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label54" runat="server" Text="Property 2"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label55" runat="server" Text="Property 3"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label56" runat="server" Text="Property 4"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label57" runat="server" Text="Property 5"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:DropDownList ID="drpUnit" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem6" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem7" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem8" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem9" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlItem10" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>


<uc2:MsgBox ID="msgBox" runat="server" />
    <br />
</asp:Content>

