

<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="PriceDeclaration.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Item.PriceDeclaration" %>

<%--<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
    <%-- <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>--%>
 <%--   <link href="../../Scripts/select2.min.css" rel="stylesheet" />
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>
    <link href="../../Styles/panel.css" rel="stylesheet" />--%>
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
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }

        function on(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9\b]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
        function RegainFocus() {
            if ((document.getElementById("txt").value).length == 0) {
                document.getElementById("txt").focus();
                alert("The textbox should not be empty");
            }
        }
    </script>

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




        function convertUnit(selectedgrid) {
            var convert_val = 1.0;
            var row = selectedgrid.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            var fromUnit = row.cells[11].getElementsByTagName("select")[0].value;
            var toUnit = row.cells[10].getElementsByTagName("select")[0].value;
            var convert_val = 1.0;

            if (fromUnit !== "-99" && toUnit !== "-99") {
                $.ajax({
                    url: "wsPriceDeclaration.asmx/GetItemUnitConversionValue",
                    cache: "false",
                    async: "false",
                    data: "{ fUnit: '" + fromUnit + "',tUnit: '" + toUnit + "'}",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                }).done(function (response) {
                    if (response.errors) {

                        alert(response.errors);

                    }

                    else {
                        //  convert_val=1.0;                 						    
                        convert_val = response.d;
                        //  row.cells[11].getElementsByTagName('input')[0].value=(row.cells[11].getElementsByTagName('input')[0].value) * convert_val;	  
                        //  console.log(row.cells[11].getElementsByTagName('input')[0].value);


                    }
                });
            }



        }
        function parseFloatIgnoreCommas(number) {
            var numberNoCommas = number.replace(/,/g, '');
            return parseFloat(numberNoCommas);
        }

        function addCommas(nStr) {
            nStr += '';
            x = nStr.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            }
            return x1 + x2;
        }
        function wastageinfopct(selectedgrid) {
            var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
            var rowCount = jsGvItem.rows.length;
            var grossUsed = 0;
            var wastagePct = 0;
            var wastageAmt = 0;
            var netUsed = 0;
            var rows = selectedgrid.parentNode.parentNode;
            if (rows.cells.length > 2) {
                if (parseFloat(rows.cells[8].getElementsByTagName('input')[0].value) >= 0 && parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) > 0) {

                    grossUsed = parseFloat(rows.cells[5].getElementsByTagName('input')[0].value);
                    wastage = parseFloat(rows.cells[8].getElementsByTagName('input')[0].value);
                    wastageAmt = parseFloat((wastage / grossUsed) * 100).toFixed(4);
                    rows.cells[7].getElementsByTagName('input')[0].value = wastageAmt;
                    netUsed = parseFloat(grossUsed - wastage).toFixed(4);
                    rows.cells[9].getElementsByTagName('input')[0].value = netUsed;


                }
                var quanatityTotal = 0;
                for (var i = 1; i < rowCount - 1; i++) {
                    if (jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value != "") {
                        var rowPrice = parseFloat(jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value);
                        quanatityTotal = quanatityTotal + rowPrice;
                    }

                }

                var wastageTotal = 0;
                for (var i = 1; i < rowCount - 1; i++) {
                    if (jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value != "") {
                        var rowPrice = parseFloat(jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value);
                        wastageTotal = wastageTotal + rowPrice;


                    }

                }

                var itemQuantityTotal = 0;
                for (var i = 1; i < rowCount - 1; i++) {
                    if (jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value != "") {
                        var rowPrice = parseFloat(jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value);
                        itemQuantityTotal = itemQuantityTotal + rowPrice;
                    }
                }


                var totalPrice = 0;
                for (var i = 1; i < rowCount - 1; i++) {
                    if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                        //var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                        var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
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
                        // alert(totalVAT);
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
                <%--   document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = parseFloat(totalValueAddition).toFixed(4);--%>




              <%--  var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
                var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
                if (sd > 0) {
               document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
                }
                else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

                document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(4);--%>

                document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

                document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
                document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

                // Total Price Without Other --------------------------------------

              <%--  document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(Number(totalPrice)).toFixed(4);
                document.getElementById("<%=txtTotalExpenses.ClientID%>").value = parseFloat(Number(totalVAT)).toFixed(4);
                document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
                document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);--%>
            }
            else {

                rows.cells[7].getElementsByTagName('input')[0].value = "0.00";
                rows.cells[9].getElementsByTagName('input')[0].value = "0.00";
            }
        }

        function wastageinfo(selectedgrid) {
            var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
           var rowCount = jsGvItem.rows.length;
           var grossUsed = 0;
           var wastagePct = 0;
           var wastageAmt = 0;
           var netUsed = 0;
           var rows = selectedgrid.parentNode.parentNode;
           if (rows.cells.length > 2) {
               if (parseFloat(rows.cells[7].getElementsByTagName('input')[0].value) >= 0) {
                   grossUsed = parseFloat(rows.cells[5].getElementsByTagName('input')[0].value);
                   wastagePct = parseFloat(rows.cells[7].getElementsByTagName('input')[0].value);
                   wastageAmt = parseFloat((grossUsed * wastagePct) / 100).toFixed(4);
                   rows.cells[8].getElementsByTagName('input')[0].value = wastageAmt;
                   netUsed = parseFloat(grossUsed - wastageAmt).toFixed(4);
                   rows.cells[9].getElementsByTagName('input')[0].value = netUsed;
               }
               var quanatityTotal = 0;
               for (var i = 1; i < rowCount - 1; i++) {
                   if (jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value != "") {
                       var rowPrice = parseFloat(jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value);
                       quanatityTotal = quanatityTotal + rowPrice;
                   }

               }

               var wastageTotal = 0;
               for (var i = 1; i < rowCount - 1; i++) {
                   if (jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value != "") {
                       var rowPrice = parseFloat(jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value);
                       wastageTotal = wastageTotal + rowPrice;


                   }

               }

               var itemQuantityTotal = 0;
               for (var i = 1; i < rowCount - 1; i++) {
                   if (jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value != "") {
                       var rowPrice = parseFloat(jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value);
                       itemQuantityTotal = itemQuantityTotal + rowPrice;
                   }
               }


               var totalPrice = 0;
               for (var i = 1; i < rowCount - 1; i++) {
                   if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                       //var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                       var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
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
                        // alert(totalVAT);
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
                <%--   document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = parseFloat(totalValueAddition).toFixed(4);--%>




               <%-- var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
                var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
                if (sd > 0) {
                    //document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT).toFixed(2);
                    document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
                }
                else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }


               

                document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(4);--%>

                document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

                document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
                document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

                // Total Price Without Other --------------------------------------
                //document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(2);
              <%--  document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(Number(totalPrice)).toFixed(4);
                document.getElementById("<%=txtTotalExpenses.ClientID%>").value = parseFloat(Number(totalVAT)).toFixed(4);
                document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
                document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);--%>
            }
            else {

                rows.cells[8].getElementsByTagName('input')[0].value = "0.00";
                rows.cells[9].getElementsByTagName('input')[0].value = "0.00";
            }
        }

        function unitChange(selectedgrid) {
            var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
            var rowCount = jsGvItem.rows.length;

            var rows = selectedgrid.parentNode.parentNode;

            if (rows.cells.length > 2) {

                //if (parseFloat(rows.cells[11].getElementsByTagName('input')[0].value) > 0) {
                if (parseFloat(rows.cells[12].getElementsByTagName('input')[0].value) > 0) {
                    var fromUnit = rows.cells[11].getElementsByTagName("select")[0].value;
                    var toUnit = rows.cells[6].getElementsByTagName("select")[0].value;
                    var convert_val = 1.0;
                    var a = 0.0;
                    var b = 0.0;
                    var wast = 0.0;

                    if (fromUnit !== "-99" && toUnit !== "-99") {
                        $.ajax({
                            url: "wsPriceDeclaration.asmx/GetItemUnitConversionValue",
                            cache: "false",
                            async: "false",
                            data: "{ fUnit: '" + fromUnit + "',tUnit: '" + toUnit + "'}",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (response) {
                                convert_val = response.d;
                                //rows.cells[12].getElementsByTagName('input')[0].value = (parseFloat(rows.cells[9].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)) * convert_val;
                                //rows.cells[12].getElementsByTagName('input')[0].value = (parseFloat((rows.cells[10].getElementsByTagName('input')[0].value) * convert_val) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)).toFixed(4);
                                rows.cells[13].getElementsByTagName('input')[0].value = (parseFloat((rows.cells[10].getElementsByTagName('input')[0].value) * convert_val) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)).toFixed(4);

                                var netMullo = 0;
                                var existingNetMullo = 0;
                                var result = 0;
                                var gggg = document.getElementById("<%=gvItems.ClientID%>");
                                if (convert_val != 1) {
                                    //rows.cells[13].getElementsByTagName('input')[0].value = parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[10].getElementsByTagName('input')[0].value) / convert_val / parseFloat(rows.cells[9].getElementsByTagName('input')[0].value);
                                    //rows.cells[13].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[11].getElementsByTagName('input')[0].value) / parseFloat((rows.cells[10].getElementsByTagName('input')[0].value) * convert_val).toFixed(4)).toFixed(4);
                                    //alert(rows.cells[13].getElementsByTagName('input')[0].value);
                                    //Total value & proposed value calculation when change unit
                                    rows.cells[14].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[12].getElementsByTagName('input')[0].value) / parseFloat((rows.cells[10].getElementsByTagName('input')[0].value) * convert_val).toFixed(4)).toFixed(4);

                                    for (var i = 1; i < rowCount - 1; i++) {
                                        //if (gggg.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                        if (gggg.rows[i].cells[14].getElementsByTagName('input')[0].value != "") {
                                            //var rowPrice = parseFloat(gggg.rows[i].cells[13].getElementsByTagName('input')[0].value).toFixed(4);
                                            var rowPrice = parseFloat(gggg.rows[i].cells[14].getElementsByTagName('input')[0].value).toFixed(4);
                                            //alert(rowPrice);
                                            result += rowPrice;
                                            document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(result).toFixed(4);
                                            document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(result).toFixed(4);
                                        }
                                    }
                                    var quanatityTotal = 0;
                                    for (var m = 1; m < rowCount - 1; m++) {
                                        if (jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value);
                                            quanatityTotal = quanatityTotal + rowPrice;
                                        }

                                    }

                                    var wastageTotal = 0;
                                    for (var l = 1; l < rowCount - 1; l++) {
                                        if (jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value);
                                            wastageTotal = wastageTotal + rowPrice;
                                        }

                                    }

                                    var itemQuantityTotal = 0;
                                    for (var o = 1; o < rowCount - 1; o++) {
                                        if (jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value);
                                            itemQuantityTotal = itemQuantityTotal + rowPrice;
                                        }
                                    }

                                    var totalPrice = 0;
                                    for (var i = 1; i < rowCount - 1; i++) {
                                        //if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                                        //var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                                        if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
                                            totalPrice = totalPrice + rowPrice;
                                        }
                                    }

                                    var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

                                    var rowCountVat = jsGvVat.rows.length;
                                    var totalVAT = 0;
                                    for (var j = 1; j < rowCountVat; j++) {
                                        if (jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value);
                                            totalVAT = totalVAT + rowPrice;
                                        }
                                    }
                                    //Value Addition Non Item
                                    var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
                                    var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
                                    var totalValueAddition = 0;
                                    for (var k = 1; k < rowCountValueAdditionNonItem; k++) {

                                        if (jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value);
                                            totalValueAddition = totalValueAddition + rowPrice;
                                        }
                                        //abc();
                                    }

             //////////////////////
           <%-- for (var r = 1; r < rowCount - 1; r++) {
            var tradingPricePerc = 0;
            var propVal = 0;
            var tradingPrcPlusHundred = 0;
            var result = 0;
            var result1 = 0;
            var proposedValue = 0;
            tradingPricePerc = parseFloat(document.getElementById("<%=txtTradePricePct.ClientID%>").value);
            
            propVal = parseFloat(totprptice);           
            tradingPrcPlusHundred = tradingPricePerc + 100;           
            result = parseFloat((parseFloat(tradingPricePerc) / parseFloat(tradingPrcPlusHundred)) * parseFloat(propVal)).toFixed(4);          
            result1 = parseFloat(propVal).toFixed(4) - result;           
            document.getElementById("<%=txtTradePriceValue.ClientID%>").value = parseFloat(result1).toFixed(4);
            }--%>

                                    //////////////////////


                                    var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
                                    var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
                                    if (sd > 0) {
                                        document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
             }
             else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

                                    document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(4);
                                    abc();
                                    document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

                                    document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
                                    document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

                                    // Total Price Without Other --------------------------------------
                                    document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas(parseFloat(Number(totalPrice)).toFixed(4));
                                    document.getElementById("<%=txtTotalExpenses.ClientID%>").value = addCommas(parseFloat(Number(totalVAT)).toFixed(4));
                                    document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = addCommas(parseFloat(totalValueAddition).toFixed(4));
                                    document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
                                    document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

                                    if (sd > 0) {
                                        document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                 document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
             }
             //08-03-2020
             else {
                 var fsonkha = "";
                 var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                 //alert(sonkha);
                 if (sonkha == "") {
                     fsonkha = 1;
                 }
                 else {
                     fsonkha = sonkha;
                 }
                 if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);

                 }
                 else {
                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);

                                        }
                                    }

                                    //
                                }
                                else {
                                    //rows.cells[13].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[11].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[10].getElementsByTagName('input')[0].value)).toFixed(4);
                                    //alert(rows.cells[13].getElementsByTagName('input')[0].value);
                                    rows.cells[14].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[12].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[10].getElementsByTagName('input')[0].value)).toFixed(4);

                                    for (var i = 1; i < rowCount - 1; i++) {
                                        //if (gggg.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                        if (gggg.rows[i].cells[14].getElementsByTagName('input')[0].value != "") {
                                            //var rowPrice = parseFloat(gggg.rows[i].cells[13].getElementsByTagName('input')[0].value);
                                            var rowPrice = parseFloat(gggg.rows[i].cells[14].getElementsByTagName('input')[0].value);
                                            //alert(rowPrice);
                                            result += rowPrice;
                                            document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(result).toFixed(4);

                                        }
                                    }
                                    var quanatityTotal = 0;
                                    for (var m = 1; m < rowCount - 1; m++) {
                                        if (jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value);
                                            quanatityTotal = quanatityTotal + rowPrice;
                                        }

                                    }

                                    var wastageTotal = 0;
                                    for (var l = 1; l < rowCount - 1; l++) {
                                        if (jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value);
                                            wastageTotal = wastageTotal + rowPrice;
                                        }

                                    }

                                    var itemQuantityTotal = 0;
                                    for (var o = 1; o < rowCount - 1; o++) {
                                        if (jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value);
                                            itemQuantityTotal = itemQuantityTotal + rowPrice;
                                        }
                                    }

                                    var totalPrice = 0;
                                    for (var i = 1; i < rowCount - 1; i++) {
                                        //if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                                        //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                                        if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
                                            totalPrice = totalPrice + rowPrice;
                                        }
                                    }

                                    var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

                                    var rowCountVat = jsGvVat.rows.length;
                                    var totalVAT = 0;
                                    for (var j = 1; j < rowCountVat; j++) {
                                        if (jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value);
                                            totalVAT = totalVAT + rowPrice;
                                        }
                                    }
                                    //Value Addition Non Item
                                    var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
                                    var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
                                    var totalValueAddition = 0;
                                    for (var k = 1; k < rowCountValueAdditionNonItem; k++) {

                                        if (jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value);
                                            totalValueAddition = totalValueAddition + rowPrice;
                                        }
                                        //abc();
                                    }

             //////////////////////
           <%-- for (var r = 1; r < rowCount - 1; r++) {
                var tradingPricePerc = 0;
                var propVal = 0;
                var tradingPrcPlusHundred = 0;
                var result = 0;
                tradingPricePerc = document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value;
                propVal = document.getElementById("<%=txtProposedPrice.ClientID%>").value;
                tradingPrcPlusHundred = tradingPricePerc + 100;
                result = ((parseFloat(tradingPricePerc) / parseFloat(tradingPrcPlusHundred)) * parseFloat(propVal)).toFixed(4);
                document.getElementById("<%=txtTradePriceValue.ClientID%>").value = result;
            }--%>

             //////////////////////

            <%--document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = parseFloat(totalValueAddition).toFixed(4);--%>
                                    var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
                                    var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
                                    if (sd > 0) {
                                        document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
             }
             else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

                                    document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(4);
                                    abc();
                                    document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

                                    document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
                                    document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

                                    // Total Price Without Other --------------------------------------
                                    document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas(parseFloat(Number(totalPrice)).toFixed(4));
                                    document.getElementById("<%=txtTotalExpenses.ClientID%>").value = addCommas(parseFloat(Number(totalVAT)).toFixed(4));
                                    document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = addCommas(parseFloat(totalValueAddition).toFixed(4));
                                    document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
                                    document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

                                    if (sd > 0) {
                                        document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                 document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
             }
             //08-03-2020
             else {
                 var fsonkha = "";
                 var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                 //alert(sonkha);
                 if (sonkha == "") {
                     fsonkha = 1;
                 }
                 else {
                     fsonkha = sonkha;
                 }
                 if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);
                 }
                 else {
                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);

                                        }
                                    }

                                }
                            },
                            error: function (err) {
                                alert(response.errors);
                            }
                        });

                    }

                    //ddlunitsec not selected

                    else {


                        var result = 0;
                        //rows.cells[12].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[10].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)).toFixed(4);
                        //rows.cells[13].getElementsByTagName('input')[0].value = parseFloat((parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[11].getElementsByTagName('input')[0].value)) / convert_val / parseFloat(rows.cells[10].getElementsByTagName('input')[0].value)).toFixed(4);

                        rows.cells[13].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[10].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)).toFixed(4);
                        rows.cells[14].getElementsByTagName('input')[0].value = parseFloat((parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[12].getElementsByTagName('input')[0].value)) / convert_val / parseFloat(rows.cells[10].getElementsByTagName('input')[0].value)).toFixed(4);

                        var gggg = document.getElementById("<%=gvItems.ClientID%>");
                        for (var i = 1; i < rowCount - 1; i++) {
                            if (gggg.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                var rowPrice = parseFloat(gggg.rows[i].cells[13].getElementsByTagName('input')[0].value);

                                result += rowPrice;
                                document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(result).toFixed(4);

                            }
                        }
                        var quanatityTotal = 0;
                        for (var m = 1; m < rowCount - 1; m++) {
                            if (jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value != "") {
                                var rowPrice = parseFloat(jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value);
                                quanatityTotal = quanatityTotal + rowPrice;
                            }

                        }

                        var wastageTotal = 0;
                        for (var l = 1; l < rowCount - 1; l++) {
                            if (jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value != "") {
                                var rowPrice = parseFloat(jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value);
                                wastageTotal = wastageTotal + rowPrice;
                            }

                        }

                        var itemQuantityTotal = 0;
                        for (var o = 1; o < rowCount - 1; o++) {
                            if (jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value != "") {
                                var rowPrice = parseFloat(jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value);
                                itemQuantityTotal = itemQuantityTotal + rowPrice;
                            }
                        }

                        var totalPrice = 0;
                        for (var i = 1; i < rowCount - 1; i++) {
                            //if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                            //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                            if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
                                totalPrice = totalPrice + rowPrice;
                            }
                        }

                        var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

                        var rowCountVat = jsGvVat.rows.length;
                        var totalVAT = 0;
                        for (var j = 1; j < rowCountVat; j++) {
                            if (jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value != "") {
                                var rowPrice = parseFloat(jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value);
                                totalVAT = totalVAT + rowPrice;
                            }
                        }
                        //Value Addition Non Item
                        var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
                        var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
                        var totalValueAddition = 0;
                        for (var k = 1; k < rowCountValueAdditionNonItem; k++) {

                            if (jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value != "") {
                                var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value);
                                totalValueAddition = totalValueAddition + rowPrice;
                            }
                            //abc();
                        }


                        var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
                        var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
                        if (sd > 0) {
                            document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
             }
             else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

                        document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(4);
                        abc();
                        document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

                        document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
                        document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

                        // Total Price Without Other --------------------------------------
                        document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas(parseFloat(Number(totalPrice)).toFixed(4));
                        document.getElementById("<%=txtTotalExpenses.ClientID%>").value = addCommas(parseFloat(Number(totalVAT)).toFixed(4));
                        document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = addCommas(parseFloat(totalValueAddition).toFixed(4));
                        document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
                        document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

                        if (sd > 0) {
                            document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                 document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
             }
             //08-03-2020
             else {
                 var fsonkha = "";
                 var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                 //alert(sonkha);
                 if (sonkha == "") {
                     fsonkha = 1;
                 }
                 else {
                     fsonkha = sonkha;
                 }
                 if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);
                 }
                 else {
                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);

                            }
                        }
                    }

                }

            }
            myFunction();

        }


        function calValuaddpct(selectedgrid) {
            var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
             var rowCount = jsGvItem.rows.length;

             var rows = selectedgrid.parentNode.parentNode;
             var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

             var rowCountVat = jsGvVat.rows.length;
             var totalVAT = 0;
             var totprptice = 0;
             var prprice = 0;
             var othrprice = 0;
            
            var totalpct = 0;
            var rowPrice = 0;
             if (parseFloat(document.getElementById("<%=txtTotalPrice.ClientID%>").value) > 0) {
                 prprice = parseFloatIgnoreCommas(document.getElementById("<%=txtTotalPrice.ClientID%>").value);
                 //alert(prprice);
             }
             if (parseFloat(document.getElementById("<%=nonItemTotalExpense.ClientID%>").value) > 0) {
                 othrprice = parseFloatIgnoreCommas(document.getElementById("<%=nonItemTotalExpense.ClientID%>").value);
                 //alert(prprice);
             }
             for (var i = 1; i < rowCountVat; i++) {
                 //alert(jsGvVat.rows[i].cells[2].getElementsByTagName('input')[0].id);

                 if (jsGvVat.rows[i].cells[2].getElementsByTagName('input')[0].value != "") {
                    <%--prprice = document.getElementById("<%=txtProposedPrice.ClientID%>").value;--%>
                     var pct = parseFloat(jsGvVat.rows[i].cells[2].getElementsByTagName('input')[0].value);
                     rowPrice = pct * prprice / 100;
                     jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value = parseFloat(Number(rowPrice)).toFixed(4);
                     totalVAT = totalVAT + rowPrice;
                     totprptice = totalVAT + prprice + othrprice;
                    
                     
                    
                     totalpct = totalpct + pct;
                     //alert(totalpct);
                     //jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value = parseFloat(Number(rowprice)).toFixed(4);
                     //alert(totprptice);
                     //debugger;
                 }

             }

           
             document.getElementById("<%=txtTotalExpenses.ClientID%>").value = addCommas(parseFloat(Number(totalVAT)).toFixed(4));
             document.getElementById("<%=txtTotalvladpct.ClientID%>").value = addCommas(parseFloat(Number(totalpct)).toFixed(4));

             abc();
             //alert(totalVAT);
             //alert(prprice);
             //alert(totprptice);
             var quanatityTotal = 0;
             for (var i = 1; i < rowCount - 1; i++) {
                 //if (jsGvItem.rows[i].cells[4].getElementsByTagName('input')[0].value != "") {
                 //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[4].getElementsByTagName('input')[0].value);
                 if (jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value);
                     quanatityTotal = quanatityTotal + rowPrice;
                 }

             }

             var wastageTotal = 0;
             for (var i = 1; i < rowCount - 1; i++) {
                 if (jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value);
                     wastageTotal = wastageTotal + rowPrice;


                 }

             }

             var itemQuantityTotal = 0;
             for (var i = 1; i < rowCount - 1; i++) {
                 if (jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value);
                     itemQuantityTotal = itemQuantityTotal + rowPrice;
                 }
             }


             var totalPrice = 0;
             for (var i = 1; i < rowCount - 1; i++) {
                 if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);

                     totalPrice = totalPrice + rowPrice;
                     // alert(totalPrice);
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
         <%--   document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = parseFloat(totalValueAddition).toFixed(2);--%>

             document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);
             document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
             document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);
             document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas(parseFloat(Number(totalPrice)).toFixed(4));


             if (document.getElementById("<%=lblHSCode.ClientID%>").innerText == "2402.20.00" || document.getElementById("<%=lblHSCode.ClientID%>").innerText == "2402.90.00") {

                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtRetailPrice.ClientID%>").value).toFixed(4);
              document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value).toFixed(4);
              document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedVATPrice.ClientID%>")).toFixed(4);
              document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedSDPrice.ClientID%>")).toFixed(4);
              document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedPrice.ClientID%>")).toFixed(4);
              document.getElementById("<%=txthlthcharge.ClientID%>").value = parseFloat(document.getElementById("<%=txthlthcharge.ClientID%>")).toFixed(4);
          }
          else {


              document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(totprptice).toFixed(4);
              //alert(document.getElementById("<%=txtProposedPrice.ClientID%>").value); 
              var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
              var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
              if (sd > 0) {
                  document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
          }
          else {
              document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0;
              }

              document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
              document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

              if (sd > 0) {
                //document.getElementById("<%=txtWholeSalePrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100 + ((totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100) * vat / 100)).toFixed(2);
                document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);

                //document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100) * vat / 100).toFixed(2);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
            }
            //08-03-2020
            else {
                var fsonkha = "";
                var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                //alert(sonkha);
                if (sonkha == "") {
                    fsonkha = 1;
                }
                else {
                    fsonkha = sonkha;
                }
                if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                    document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);
                 }
                 else {
                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                         document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);

                     }
                 }
             }
         }


        function calValuadd(selectedgrid) {
          var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
          var rowCount = jsGvItem.rows.length;

          var rows = selectedgrid.parentNode.parentNode;
          var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

          var rowCountVat = jsGvVat.rows.length;
          var totalVAT = 0;
          var totprptice = 0;
          var prprice = 0;
          var othrprice = 0;
            var pct = 0;
            var totalpct = 0;
          if (parseFloat(document.getElementById("<%=txtTotalPrice.ClientID%>").value) > 0) {
              prprice = parseFloatIgnoreCommas(document.getElementById("<%=txtTotalPrice.ClientID%>").value);
              //alert(prprice);
          }
          if (parseFloat(document.getElementById("<%=nonItemTotalExpense.ClientID%>").value) > 0) {
              othrprice = parseFloatIgnoreCommas(document.getElementById("<%=nonItemTotalExpense.ClientID%>").value);
              //alert(prprice);
          }
          for (var i = 1; i < rowCountVat; i++) {
              //alert(jsGvVat.rows[i].cells[2].getElementsByTagName('input')[0].id);

              if (jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value != "")
              {
                    <%--prprice = document.getElementById("<%=txtProposedPrice.ClientID%>").value;--%>
                  var rowPrice = parseFloat(jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value);
                  totalVAT = totalVAT + rowPrice;
                  totprptice = totalVAT + prprice + othrprice;
                  pct = rowPrice * 100 / prprice;
                  jsGvVat.rows[i].cells[2].getElementsByTagName('input')[0].value = parseFloat(Number(pct)).toFixed(4);
                  totalpct = totalpct + pct;
                  //alert(totprptice);
                  //debugger;
              }

          }
           

          document.getElementById("<%=txtTotalExpenses.ClientID%>").value = addCommas(parseFloat(Number(totalVAT)).toFixed(4));
            document.getElementById("<%=txtTotalvladpct.ClientID%>").value = addCommas(parseFloat(Number(totalpct)).toFixed(4));

          abc();
          //alert(totalVAT);
          //alert(prprice);
          //alert(totprptice);
          var quanatityTotal = 0;
          for (var i = 1; i < rowCount - 1; i++) {
              //if (jsGvItem.rows[i].cells[4].getElementsByTagName('input')[0].value != "") {
              //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[4].getElementsByTagName('input')[0].value);
              if (jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value != "") {
                  var rowPrice = parseFloat(jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value);
                  quanatityTotal = quanatityTotal + rowPrice;
              }

          }

          var wastageTotal = 0;
          for (var i = 1; i < rowCount - 1; i++) {
              if (jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value != "") {
                  var rowPrice = parseFloat(jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value);
                  wastageTotal = wastageTotal + rowPrice;


              }

          }

          var itemQuantityTotal = 0;
          for (var i = 1; i < rowCount - 1; i++) {
              if (jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value != "") {
                  var rowPrice = parseFloat(jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value);
                  itemQuantityTotal = itemQuantityTotal + rowPrice;
              }
          }


          var totalPrice = 0;
          for (var i = 1; i < rowCount - 1; i++) {
              if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                  var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);

                  totalPrice = totalPrice + rowPrice;
                  // alert(totalPrice);
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
         <%--   document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = parseFloat(totalValueAddition).toFixed(2);--%>

          document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);
          document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
          document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);
          document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas(parseFloat(Number(totalPrice)).toFixed(4));


          if (document.getElementById("<%=lblHSCode.ClientID%>").innerText == "2402.20.00" || document.getElementById("<%=lblHSCode.ClientID%>").innerText == "2402.90.00") {

              document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtRetailPrice.ClientID%>").value).toFixed(4);
              document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value).toFixed(4);
              document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedVATPrice.ClientID%>")).toFixed(4);
              document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedSDPrice.ClientID%>")).toFixed(4);
              document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedPrice.ClientID%>")).toFixed(4);
              document.getElementById("<%=txthlthcharge.ClientID%>").value = parseFloat(document.getElementById("<%=txthlthcharge.ClientID%>")).toFixed(4);
          }
          else {


              document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(totprptice).toFixed(4);
              //alert(document.getElementById("<%=txtProposedPrice.ClientID%>").value); 
              var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
              var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
              if (sd > 0) {
                  document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
          }
          else {
              document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0;
              }

              document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
              document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

              if (sd > 0) {
                //document.getElementById("<%=txtWholeSalePrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100 + ((totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100) * vat / 100)).toFixed(2);
                document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);

                //document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100) * vat / 100).toFixed(2);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
            }
            //08-03-2020
            else {
                var fsonkha = "";
                var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                //alert(sonkha);
                if (sonkha == "") {
                    fsonkha = 1;
                }
                else {
                    fsonkha = sonkha;
                }
                if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                    document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);
                 }
                 else {
                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);

                    }
                }
            }
        }

        function calotheradd(selectedgrid) {
            var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
            var rowCount = jsGvItem.rows.length;

            var rows = selectedgrid.parentNode.parentNode;
            var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

            var rowCountVat = jsGvVat.rows.length;
            var totalVAT = 0;
            var totprptice = 0;
            var prprice = 0;
            var valueaddprice = 0;
            if (parseFloat(document.getElementById("<%=txtTotalPrice.ClientID%>").value) > 0) {
                prprice = parseFloatIgnoreCommas(document.getElementById("<%=txtTotalPrice.ClientID%>").value);
               // alert(parseFloat(document.getElementById("<%=txtTotalPrice.ClientID%>").value));
            }
            if (parseFloat(document.getElementById("<%=txtTotalExpenses.ClientID%>").value) > 0) {
                valueaddprice = parseFloatIgnoreCommas(document.getElementById("<%=txtTotalExpenses.ClientID%>").value);
                // alert(valueaddprice);
            }
       
            <%-- prprice = document.getElementById("<%=txtProposedPrice.ClientID%>").value;
            alert(prprice);
            totprptice = prprice + Number(totalVAT);
            alert(totprptice);--%>
            //Value Addition Non Item
            var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
            var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
            var totalValueAddition = 0;
            for (var i = 1; i < rowCountValueAdditionNonItem; i++) {

                if (jsGvValueAdditionNonItem.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[i].cells[1].getElementsByTagName('input')[0].value);
                    totalVAT = totalVAT + rowPrice;
                    totprptice = totalVAT + prprice + valueaddprice;
                    
                }
            }
          
           <%-- document.getElementById("<%=txtTotalExpenses.ClientID%>").value = parseFloat(Number(totalVAT)).toFixed(4);--%>
            document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = addCommas(parseFloat(Number(totalVAT)).toFixed(4));


            abc();
            //alert(totalVAT);
            //alert(prprice);
            //alert(totprptice);
            var quanatityTotal = 0;
            for (var i = 1; i < rowCount - 1; i++) {
                //if (jsGvItem.rows[i].cells[4].getElementsByTagName('input')[0].value != "") {
                //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[4].getElementsByTagName('input')[0].value);
                if (jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value);
                    quanatityTotal = quanatityTotal + rowPrice;
                }

            }

            var wastageTotal = 0;
            for (var i = 1; i < rowCount - 1; i++) {
                if (jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value);
                    wastageTotal = wastageTotal + rowPrice;


                }

            }

            var itemQuantityTotal = 0;
            for (var i = 1; i < rowCount - 1; i++) {
                if (jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value);
                    itemQuantityTotal = itemQuantityTotal + rowPrice;
                }
            }


            var totalPrice = 0;
            for (var i = 1; i < rowCount - 1; i++) {
                if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);

                    totalPrice = totalPrice + rowPrice;
                    // alert(totalPrice);
                }
            }

            //Value Addition  Item
            var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAddition.ClientID%>");
            var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
            var totalValueAddition = 0;
            for (var i = 1; i < rowCountValueAdditionNonItem; i++) {

                if (jsGvValueAdditionNonItem.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[i].cells[1].getElementsByTagName('input')[0].value);
                    totalValueAddition = totalValueAddition + rowPrice;
                }
            }

         <%--   document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = parseFloat(totalValueAddition).toFixed(2);--%>
            document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

            document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
            document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

            // Total Price Without Other --------------------------------------
            //document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(2);
            document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas((parseFloat(Number(totalPrice)).toFixed(4)));




            if (document.getElementById("<%=lblHSCode.ClientID%>").innerText == "2402.20.00" || document.getElementById("<%=lblHSCode.ClientID%>").innerText == "2402.90.00")
            {

                document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtRetailPrice.ClientID%>").value).toFixed(4);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value).toFixed(4);
                document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedVATPrice.ClientID%>")).toFixed(4);
                document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedSDPrice.ClientID%>")).toFixed(4);
                document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(document.getElementById("<%=txtProposedPrice.ClientID%>")).toFixed(4);
                 document.getElementById("<%=txthlthcharge.ClientID%>").value = parseFloat(document.getElementById("<%=txthlthcharge.ClientID%>")).toFixed(4);
            }
            else {
                document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(totprptice).toFixed(4);

                var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
                var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
                if (sd > 0) {

                    document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
                }
                else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }





                //document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT) * sd / 100).toFixed(2);
                document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

                //document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100).toFixed(2);
                document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

                if (sd > 0) {
                    //document.getElementById("<%=txtWholeSalePrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100 + ((totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100) * vat / 100)).toFixed(2);
                    document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);

                    //document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + (totalPrice + totalVAT) * sd / 100) * vat / 100).toFixed(2);
                    document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
                }
                    //08-03-2020
                else {
                    var fsonkha = "";
                    var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                    //alert(sonkha);
                    if (sonkha == "") {
                        fsonkha = 1;
                    }
                    else {
                        fsonkha = sonkha;
                    }
                    if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                        document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                        document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);

                    }
                    else {
                        document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                        document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);

                    }
                }
            }
        }
   function showPrice(selectedgrid) {
            var jsGvItem = document.getElementById("<%=gvItems.ClientID%>");
            var rowCount = jsGvItem.rows.length;
            var rows = selectedgrid.parentNode.parentNode;


        if (rows.cells.length > 2) {
               
            //if (parseFloat(rows.cells[11].getElementsByTagName('input')[0].value) > 0) {
            if (parseFloat(rows.cells[12].getElementsByTagName('input')[0].value) > 0) {
                    var fromUnit = rows.cells[11].getElementsByTagName("select")[0].value;
                    var toUnit = rows.cells[6].getElementsByTagName("select")[0].value;
                    var convert_val = 1.0;
                    var a = 0.0;
                    var b = 0.0;
                    var wast = 0.0;

                    if (fromUnit !== "-99" && toUnit !== "-99") {
                        $.ajax({
                            url: "wsPriceDeclaration.asmx/GetItemUnitConversionValue",
                            cache: "false",
                            async: "false",
                            data: "{ fUnit: '" + fromUnit + "',tUnit: '" + toUnit + "'}",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (response) {
                                convert_val = response.d;
                                //rows.cells[12].getElementsByTagName('input')[0].value = (parseFloat(rows.cells[9].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)) * convert_val;
                                //rows.cells[12].getElementsByTagName('input')[0].value = (parseFloat((rows.cells[10].getElementsByTagName('input')[0].value) * convert_val) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)).toFixed(4);
                                rows.cells[13].getElementsByTagName('input')[0].value = (parseFloat((rows.cells[10].getElementsByTagName('input')[0].value) * convert_val) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)).toFixed(4);
                                var netMullo = 0;
                                var existingNetMullo = 0;
                                var result = 0;                               
                                var gggg = document.getElementById("<%=gvItems.ClientID%>");
                                if (convert_val != 1) {
                                    //rows.cells[13].getElementsByTagName('input')[0].value = parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[10].getElementsByTagName('input')[0].value) / convert_val / parseFloat(rows.cells[9].getElementsByTagName('input')[0].value);
                                    //rows.cells[13].getElementsByTagName('input')[0].value =parseFloat(parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[11].getElementsByTagName('input')[0].value) / parseFloat((rows.cells[10].getElementsByTagName('input')[0].value) * convert_val)).toFixed(4);
                                    //alert(rows.cells[13].getElementsByTagName('input')[0].value);
                                    //Total value & proposed value calculation when change unit
                                    rows.cells[14].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[12].getElementsByTagName('input')[0].value) / parseFloat((rows.cells[10].getElementsByTagName('input')[0].value) * convert_val)).toFixed(4);
                                    for (var i = 1; i < rowCount - 1; i++) {
                                         if (gggg.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                             var rowPrice = parseFloat(gggg.rows[i].cells[13].getElementsByTagName('input')[0].value).toFixed(4);
                                             //alert(rowPrice);
                                             result += rowPrice;
                                             document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(result).toFixed(4);
                                            <%-- document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(result).toFixed(4)--%>;
                                            
            
                                             
                                         }
                                     }
                                    
                                    var quanatityTotal = 0;
                             for (var m = 1; m < rowCount - 1; m++) {
                                 if (jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value != "") {
                                     var rowPrice = parseFloat(jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value);
                                     quanatityTotal = quanatityTotal + rowPrice;
                                 }

                             }

                             var wastageTotal = 0;
                             for (var l = 1; l < rowCount - 1; l++) {
                                 if (jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value != "") {
                                     var rowPrice = parseFloat(jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value);
                                     wastageTotal = wastageTotal + rowPrice;
                                 }

                             }

                             var itemQuantityTotal = 0;
                             for (var o = 1; o < rowCount - 1; o++) {
                                 if (jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value != "") {
                                     var rowPrice = parseFloat(jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value);
                                     itemQuantityTotal = itemQuantityTotal + rowPrice;
                                 }
                             }

                             var totalPrice = 0;
                             for (var i = 1; i < rowCount - 1; i++) {
                                 //if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                                 //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                                 if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                     var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
                                 
                                 totalPrice = totalPrice + rowPrice;
                                 }
                             }

                             var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

                            var rowCountVat = jsGvVat.rows.length;
                            var totalVAT = 0;
                            for (var j = 1; j < rowCountVat; j++) {
                                if (jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value != "") {
                                    var rowPrice = parseFloat(jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value);
                                    totalVAT = totalVAT + rowPrice;
                                }
                            }
             //Value Addition Non Item
            var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
            var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
            var totalValueAddition = 0;
            for (var k = 1; k < rowCountValueAdditionNonItem; k++) {

                if (jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value);
                    totalValueAddition = totalValueAddition + rowPrice;
                   
                }
                //
            }
 

            
             var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
             var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
             if (sd > 0) {
                 document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
            }
            else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

            document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(4);
                                    abc();
             document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

             document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
             document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

             // Total Price Without Other --------------------------------------
          document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas(parseFloat(Number(totalPrice)).toFixed(4));
          document.getElementById("<%=txtTotalExpenses.ClientID%>").value = addCommas(parseFloat(Number(totalVAT)).toFixed(4));
           document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = addCommas(parseFloat(totalValueAddition).toFixed(4));
             document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
             document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

             if (sd > 0) {
                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
            }
             //08-03-2020
             else {
                 var fsonkha = "";
                 var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                 //alert(sonkha);
                 if (sonkha == "") {
                     fsonkha = 1;
                 }
                 else {
                     fsonkha = sonkha;
                 }
                 if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);
                 }
                 else {
                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
            
                 }
                }

                                     //
                                 }
                                 else {
                                    //rows.cells[13].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[11].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[10].getElementsByTagName('input')[0].value)).toFixed(4);
                                    //alert(rows.cells[13].getElementsByTagName('input')[0].value);
                                    rows.cells[14].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[12].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[10].getElementsByTagName('input')[0].value)).toFixed(4);
                                    for (var i = 1; i < rowCount - 1; i++) {
                                         //if (gggg.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                         //    var rowPrice = parseFloat(gggg.rows[i].cells[13].getElementsByTagName('input')[0].value);
                                             //alert(rowPrice);
                                        if (gggg.rows[i].cells[14].getElementsByTagName('input')[0].value != "") {
                                            var rowPrice = parseFloat(gggg.rows[i].cells[14].getElementsByTagName('input')[0].value);
                                        result += rowPrice;
                                             document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(result).toFixed(4);
                                            
                                         }
                                     }
                  var quanatityTotal = 0;
             for (var m = 1; m < rowCount - 1; m++) {
                 if (jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value);
                     quanatityTotal = quanatityTotal + rowPrice;
                 }

             }

             var wastageTotal = 0;
             for (var l = 1; l < rowCount - 1; l++) {
                 if (jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value);
                     wastageTotal = wastageTotal + rowPrice;
                 }

             }

             var itemQuantityTotal = 0;
             for (var o = 1; o < rowCount - 1; o++) {
                 if (jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value);
                     itemQuantityTotal = itemQuantityTotal + rowPrice;
                 }
             }

             var totalPrice = 0;
             for (var i = 1; i < rowCount - 1; i++) {
                 //if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                 //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                 if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
                     totalPrice = totalPrice + rowPrice;
                 }
             }

             var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

            var rowCountVat = jsGvVat.rows.length;
            var totalVAT = 0;
            for (var j = 1; j < rowCountVat; j++) {
                if (jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value);
                    totalVAT = totalVAT + rowPrice;
                }
            }
             //Value Addition Non Item
            var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
            var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
            var totalValueAddition = 0;
            for (var k = 1; k < rowCountValueAdditionNonItem; k++) {

                if (jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value);
                    totalValueAddition = totalValueAddition + rowPrice;
                }
                //abc();
            }
            
        
             var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
             var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
             if (sd > 0) {
                 document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
            }
            else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

            document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(4);
                                    abc();
             document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

             document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
             document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

             // Total Price Without Other --------------------------------------
             document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(Number(totalPrice)).toFixed(4);
             document.getElementById("<%=txtTotalExpenses.ClientID%>").value = parseFloat(Number(totalVAT)).toFixed(4);
             document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = parseFloat(totalValueAddition).toFixed(4);
             document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
             document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

             if (sd > 0) {
                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                 document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);
             }
            //08-03-2020
             else {
                 var fsonkha = "";
                 var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                 //alert(sonkha);
                 if (sonkha == "") {
                     fsonkha = 1;
                 }
                 else {
                     fsonkha = sonkha;
                 }
                 if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                    document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat*fsonkha)).toFixed(4);
                 }
                 else {
                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
            
                 }
                }

                                }
                             },
                             error: function (err) {
                                 alert(response.errors);
                             }
                         });

                    }


          //ddlunitsec not selected

                    else {
                     
                        var result = 0;
                        //rows.cells[12].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[10].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)).toFixed(4);
                        //rows.cells[13].getElementsByTagName('input')[0].value = parseFloat((parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[11].getElementsByTagName('input')[0].value)) / convert_val / parseFloat(rows.cells[10].getElementsByTagName('input')[0].value)).toFixed(4);
                        rows.cells[13].getElementsByTagName('input')[0].value = parseFloat(parseFloat(rows.cells[10].getElementsByTagName('input')[0].value) / parseFloat(rows.cells[5].getElementsByTagName('input')[0].value)).toFixed(4);
                        rows.cells[14].getElementsByTagName('input')[0].value = parseFloat((parseFloat(rows.cells[5].getElementsByTagName('input')[0].value) * parseFloat(rows.cells[12].getElementsByTagName('input')[0].value)) / convert_val / parseFloat(rows.cells[10].getElementsByTagName('input')[0].value)).toFixed(4);

                        var gggg = document.getElementById("<%=gvItems.ClientID%>");
                        for (var i = 1; i < rowCount - 1; i++) {
                                         //if (gggg.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                                         //    var rowPrice = parseFloat(gggg.rows[i].cells[13].getElementsByTagName('input')[0].value);
                                             if (gggg.rows[i].cells[14].getElementsByTagName('input')[0].value != "") {
                                                 var rowPrice = parseFloat(gggg.rows[i].cells[14].getElementsByTagName('input')[0].value);
                                             result += rowPrice;
                                             document.getElementById("<%=txtTotalPrice.ClientID%>").value = parseFloat(result).toFixed(4);
                                             
                                         }
                                     }
                  var quanatityTotal = 0;
             for (var m = 1; m < rowCount - 1; m++) {
                 if (jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[m].cells[5].getElementsByTagName('input')[0].value);
                     quanatityTotal = quanatityTotal + rowPrice;
                 }

             }

             var wastageTotal = 0;
             for (var l = 1; l < rowCount - 1; l++) {
                 if (jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[l].cells[8].getElementsByTagName('input')[0].value);
                     wastageTotal = wastageTotal + rowPrice;
                 }

             }

             var itemQuantityTotal = 0;
             for (var o = 1; o < rowCount - 1; o++) {
                 if (jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[o].cells[9].getElementsByTagName('input')[0].value);
                     itemQuantityTotal = itemQuantityTotal + rowPrice;
                 }
             }

             var totalPrice = 0;
             for (var i = 1; i < rowCount - 1; i++) {
                 //if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                 //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                 if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                     var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
                     totalPrice = totalPrice + rowPrice;
                 }
             }

             var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

            var rowCountVat = jsGvVat.rows.length;
            var totalVAT = 0;
            for (var j = 1; j < rowCountVat; j++) {
                if (jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvVat.rows[j].cells[1].getElementsByTagName('input')[0].value);
                    totalVAT = totalVAT + rowPrice;
                }
            }
             //Value Addition Non Item
            var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
            var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
            var totalValueAddition = 0;
            for (var k = 1; k < rowCountValueAdditionNonItem; k++) {

                if (jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value);
                    totalValueAddition = totalValueAddition + rowPrice;
                }
                //abc();
            }
            
        
             var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
             var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
             if (sd > 0) {
                 document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
            }
            else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

            document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(Number(totalPrice + totalValueAddition + totalVAT)).toFixed(4);
                        abc();
             document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);

             document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
             document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);

             // Total Price Without Other --------------------------------------
            document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas(parseFloat(Number(totalPrice)).toFixed(4));
            document.getElementById("<%=txtTotalExpenses.ClientID%>").value =addCommas( parseFloat(Number(totalVAT)).toFixed(4));
            document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = addCommas(parseFloat(totalValueAddition).toFixed(4));
             document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
             document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

             if (sd > 0) {
                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
             }
//08-03-2020
             else {
                 var fsonkha = "";
                 var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                 alert(sonkha);
                 if (sonkha == "") {
                     fsonkha = 1;
                 }
                 else {
                     fsonkha = sonkha;
                 }
                 if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat(Number(vat * fsonkha)).toFixed(4);
                 }
                 else {
                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
            
                 }
                }
                    }
                
                    rows.cells[7].getElementsByTagName('input')[0].value = "0.0000";
                    rows.cells[8].getElementsByTagName('input')[0].value = "0.00";
                    rows.cells[9].getElementsByTagName('input')[0].value = "0.00";
                    //var ddl = rows.cells[6].getElementsByTagName('input')[0].value;
                    //var SelVal = ddl.options[ddl.selectedIndex].text;
                    //alert(SelVal);
                }
                else {
                   
                rows.cells[6].getElementsByTagName('select')[0].value = "-99";  //to chance gross unit by sabbir 10/6/20
            rows.cells[7].getElementsByTagName('input')[0].value = "0.00";
            rows.cells[8].getElementsByTagName('input')[0].value = "0.00";
            rows.cells[9].getElementsByTagName('input')[0].value = "0.00";
            //rows.cells[6].getElementsByTagName('input')[0].value="";
            //alert("ac");
            var cell = rows.cells[6].getElementsByTagName('input')[0].value;
            var dropdownSelectedValue = cell.childNodes[0].value;
            alert(dropdownSelectedValue);
            //var ddl = rows.cells[6].getElementsByTagName('input')[0].value;
            //var SelVal = ddl.options[ddl.selectedIndex].text;
            //alert(SelVal);
            //rows.cells[6].getElementsByTagName('input')[0].value= "-99";
           
            var quanatityTotal = 0;
            for (var i = 1; i < rowCount - 1; i++) {
                if (jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvItem.rows[i].cells[5].getElementsByTagName('input')[0].value);
                    quanatityTotal = quanatityTotal + rowPrice;
                }

            }
            var wastageTotal = 0;
            for (var i = 1; i < rowCount - 1; i++) {
                if (jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvItem.rows[i].cells[8].getElementsByTagName('input')[0].value);
                    wastageTotal = wastageTotal + rowPrice;
                }
            }

            var itemQuantityTotal = 0;
            for (var i = 1; i < rowCount - 1; i++) {
                if (jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvItem.rows[i].cells[9].getElementsByTagName('input')[0].value);
                    itemQuantityTotal = itemQuantityTotal + rowPrice;
                }
            }

            var totalPrice = 0;
            for (var i = 1; i < rowCount - 1; i++) {
                //if (jsGvItem.rows[i].cells[12].getElementsByTagName('input')[0].value != "") {
                //    var rowPrice = parseFloat(jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value);
                if (jsGvItem.rows[i].cells[13].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvItem.rows[i].cells[14].getElementsByTagName('input')[0].value);
                    totalPrice = totalPrice + rowPrice;
                }
            }
            var jsGvVat = document.getElementById("<%=gvValueAddition.ClientID%>");

            var rowCountVat = jsGvVat.rows.length;
            var prprice = 0;
            var totalVAT = 0;
            if (parseFloat(document.getElementById("<%=txtTotalPrice.ClientID%>").value)>0) {
                prprice = parseFloat(document.getElementById("<%=txtTotalPrice.ClientID%>").value);
                //alert(prprice);
            }
           
            for (var i = 1; i < rowCountVat; i++) {
                //alert(jsGvVat.rows[i].cells[2].getElementsByTagName('input')[0].id);
               
                if (jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value != "") {
                    <%--prprice = document.getElementById("<%=txtProposedPrice.ClientID%>").value;--%>
                    var rowPrice = parseFloat(jsGvVat.rows[i].cells[1].getElementsByTagName('input')[0].value);
                    totalVAT = totalVAT + rowPrice;
                    totprptice = totalVAT + prprice;
                    //alert(totprptice);
                   
                }
                 
            }          
                 //Value Addition Non Item
            var jsGvValueAdditionNonItem = document.getElementById("<%=gvValueAdditionNonItem.ClientID%>");
            var rowCountValueAdditionNonItem = jsGvValueAdditionNonItem.rows.length;
            var totalValueAddition = 0;
            for (var k = 1; k < rowCountValueAdditionNonItem; k++) {

                if (jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value != "") {
                    var rowPrice = parseFloat(jsGvValueAdditionNonItem.rows[k].cells[1].getElementsByTagName('input')[0].value);
                    totalValueAddition = totalValueAddition + rowPrice;
                }
                //abc();
            }   
                document.getElementById("<%=txtSumQuantityTotal.ClientID%>").value = parseFloat(Number(quanatityTotal)).toFixed(4);
                document.getElementById("<%=txtSumWastage.ClientID%>").value = parseFloat(Number(wastageTotal)).toFixed(4);
                document.getElementById("<%=txtSumItemQuantity.ClientID%>").value = parseFloat(Number(itemQuantityTotal)).toFixed(4);
                document.getElementById("<%=txtTotalPrice.ClientID%>").value = addCommas(parseFloat(Number(totalPrice)).toFixed(4));
                var sd = document.getElementById("<%=txtSDRate.ClientID%>").value;
             var vat = document.getElementById("<%=txtVATRate.ClientID%>").value;
             if (sd > 0) {
                 document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition).toFixed(4);
            }
            else { document.getElementById("<%=txtProposedSDPrice.ClientID%>").value = 0; }

                document.getElementById("<%=txtTotalExpenses.ClientID%>").value = addCommas(parseFloat(Number(totalVAT)).toFixed(4));           
            document.getElementById("<%=txtProposedPrice.ClientID%>").value = parseFloat(totprptice).toFixed(4);           
                document.getElementById("<%=nonItemTotalExpense.ClientID%>").value = addCommas(parseFloat(totalValueAddition).toFixed(4));
             document.getElementById("<%=txtSD.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);
             document.getElementById("<%=txtProposedVATPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100).toFixed(4);

             if (sd > 0) {
                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
            }
             //08-03-2020
             else {
                 var fsonkha = "";
                 var sonkha = document.getElementById("<%=txtsongkha.ClientID%>").value;
                 //alert(sonkha);
                 if (sonkha == "") {
                     fsonkha = 1;
                 }
                 else {
                     fsonkha = sonkha;
                 }
                 if (document.getElementById("<%=fVAT.ClientID%>").innerText == " Per Unit.") {

                     document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + Number(vat * fsonkha)).toFixed(4);
                     document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value =parseFloat(Number(vat * fsonkha)).toFixed(4);
                 }
                 else {
                 document.getElementById("<%=txtRetailPrice.ClientID%>").value = parseFloat(totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100 + ((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100)).toFixed(4);
                document.getElementById("<%=txtCurrentVATPrice.ClientID%>").value = parseFloat((totalPrice + totalVAT + totalValueAddition + (totalPrice + totalVAT + totalValueAddition) * sd / 100) * vat / 100).toFixed(4);
            
                 }
                }

                }
           
           
             }
       //abc();
            }
        
           function abc() {
            //alert("Test");
            var tradingPricePerc = 0;
            var propVal = 0;
            var tradingPrcPlusHundred = 0;
            var result = 0;
            var result1 = 0;
            var proposedValue = 0;
           
            tradingPricePerc = parseFloat(document.getElementById("<%=txtTradePricePct.ClientID%>").value);
              
            propVal = parseFloat(document.getElementById("<%=txtProposedPrice.ClientID%>").value);  
              
            tradingPrcPlusHundred = tradingPricePerc + 100;           
            result = parseFloat((parseFloat(tradingPricePerc) / parseFloat(tradingPrcPlusHundred)) * parseFloat(propVal)).toFixed(4);          
          
            result1 = parseFloat(propVal).toFixed(4) - result;
            if (tradingPricePerc != 0) {
                document.getElementById("<%=txtTradePriceValue.ClientID%>").value = parseFloat(result1).toFixed(4);
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
            document.getElementById("<%= txtNBRSD.ClientID%>").value = parseFloat(NBRSDAmount).toFixed(4);

            var NBRVATChargablePric = parseFloat((totalNBRVAT + Number(NBRActualPrice)) + Number(NBRSDAmount)).toFixed(4);
            document.getElementById("<%= txtNBRVATChargeablePrice.ClientID%>").value = NBRVATChargablePric;

            document.getElementById("<%= txtNBRWholeSalePrice.ClientID%>").value = parseFloat((Number(NBRVATChargablePric) + (Number(NBRVATChargablePric) * 15 / 100))).toFixed(4);
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

           // alert(document.getElementById(tabName));

            evt.currentTarget.className += " active";
        }

        function myFunction() {
            var fID = document.getElementById("<%= txtmVatablePrice.ClientID%>").value;
            var tID = document.getElementById("<%= txtWholeSalePrice.ClientID%>").value;
            var cID = document.getElementById("<%= cID.ClientID%>");
            if (fID > 0 || fID != undefined) {
                var a = parseFloat(fID - tID).toFixed(2);
                cID.innerHTML = a;
            }
        }
        //End Tab
     

    </script>
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center;font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">উপকরণ - উৎপাদ সহগ (Input-Output Coefficient) ঘোষণা (৪.৩)</div>
                        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                            <div class="row hiddencol" style="background: #FFD9C3">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Organization :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblOrganization" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblOrgAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Branch Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpBranchName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">পণ্য ক্যাটাগরী :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItemCategory" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">পণ্য সাব-ক্যাটাগরী :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItemSubCategory" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>পণ্য :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                ControlToValidate="ddlItem" ErrorMessage="Please select Product." Style="color: Red"
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4  hiddencol">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">বৎসর :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">কার্যকর তারিখ :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtActiveDate" runat="server" onkeydown="return (event.keyCode!=13);" onkeyup="FormatIt(this);"
                                                MaxLength="10" CssClass="form-control" Style="font-size: 11pt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtActiveDate" />
                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtActiveDate"
                                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                        ErrorMessage="Invalid date format(DD/MM/YYYY)." CssClass="litMessage" />--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>মূল্য ঘোষণা নম্বর :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtPriceDeclaretionNo" runat="server" CssClass="form-control"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                ControlToValidate="txtPriceDeclaretionNo"  Style="color: Red"
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                            <%--ErrorMessage="Please fill declaretion number(মূল্য ঘোষণা নম্বরঃ )."--%>
                                           <%-- <asp:Label ID="lblHSCode" runat="server" Visible="false"></asp:Label>&nbsp;<asp:Label ID="lblUnit" runat="server" Visible="false"></asp:Label>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">সংখ্যা :</label>
                                        <div class="col-sm-7">
                                          <asp:TextBox ID="txtsongkha" runat="server" CssClass="form-control" OnTextChanged="txtsongkha_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="txtQuantityTotal_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtsongkha"
                                                                            ValidChars="0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>

                                 </div>
                            <div class="row" style="margin-top: 0px" runat="server" visible="false" id="divStick">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">প্রতি প্যাকেট শলাকা:</label>
                                        <div class="col-sm-7">
                                         <asp:DropDownList runat="server" ID="drpProperty" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="drpProprty_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <asp:Label ID="lblstickQuantity" runat="server" CssClass="hiddencol" ></asp:Label> 
                                    </div>
                            </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"> স্বাস্থ্য সুরক্ষা সারচার্জ:</label>
                                        <div class="col-sm-7">
                                         <asp:TextBox ID="txthlthcharge" runat="server"  CssClass="form-control"></asp:TextBox>
                                        <asp:Label ID="lblhlthcharge" runat="server" Text="" /><asp:Label ID="Label32" runat="server" Text="%"></asp:Label>
                                        </div>
                                         
                                    </div>
                            </div>
                                 </div>
                           <%-- <div class="row">
                                
                            </div>--%>
                            <div class="row" style="margin-top: 0px">
                               
                               
                                    <div class="col-sm-5" >
                                        <fieldset class="scheduler-border" style="width: 100%">
                                            <legend class="scheduler-border" style="color: Green; font-weight: normal">সম্পূরক শুল্ক আরোপযোগ্য মূল্য</legend>
                                            <div class="col-sm-4">
                                                <asp:Label ID="Label3" runat="server" Text="বর্তমান"></asp:Label><br />
                                                <asp:TextBox ID="txtCurrentSDPrice" onkeypress="return on(event)" runat="server" Style="width: 70%" placeholder="0.00"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4">
                                                <asp:Label ID="Label4" runat="server" Text="প্রস্তাবিত"></asp:Label><br />
                                                <asp:TextBox ID="txtProposedSDPrice" onkeypress="return on(event)" runat="server" Style="width: 70%" placeholder="0.00"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4">
                                        <asp:Label ID="Label5" runat="server" Text="সম্পূরক শুল্ক"></asp:Label>
                                        <asp:TextBox ID="txtSDRate" runat="server" Style="width:24px; height: 20px" CssClass="text_box" Enabled="False" ReadOnly="True">0</asp:TextBox>
                                        <asp:TextBox ID="txtSD" onkeypress="return on(event)" runat="server" Style="width: 70%" placeholder="0.00"></asp:TextBox>
                                    </div>
                                        </fieldset>
                                    </div>
                                        <div class="col-sm-4">
                                    <fieldset class="scheduler-border" style="width: 100%">
                                        <legend class="scheduler-border" style="color: Green; font-weight: normal">ভ্যাট আরোপযোগ্য মূল্য</legend>
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label1" runat="server" Text="বর্তমান"></asp:Label>
                                         <%--   <asp:TextBox ID="TextBox3" runat="server" Style="width: 24px; height: 20px" Enabled="False" ReadOnly="True">0</asp:TextBox>--%>
                                            <asp:TextBox ID="TextBox4" onkeypress="return on(event)" runat="server" Style="width: 90%" placeholder="0.00"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label63" runat="server" Text="প্রস্তাবিত"></asp:Label>
                                            <asp:TextBox ID="txtProposedVATPrice" onkeypress="return on(event)" runat="server" Style="width: 90%" placeholder="0.00"></asp:TextBox>
                                        </div>
                                         <div class="col-sm-4">
                                            <asp:Label ID="Label62" runat="server" Text="ভ্যাট"></asp:Label>
                                            <asp:TextBox ID="txtVATRate" runat="server" Style="width: 50px; height: 20px" Enabled="False" ReadOnly="True">0</asp:TextBox>
                                            <asp:TextBox ID="txtCurrentVATPrice" onkeypress="return on(event)" runat="server" Style="width: 90%" placeholder="0.00"></asp:TextBox>
                                        <asp:Label ID="fVAT" runat="server" CssClass="hiddencol"></asp:Label>
                                         </div>
                                    </fieldset>
                                </div>
                                <div class="col-sm-3">
                                    <fieldset class="scheduler-border" style="width: 100%">
                                        <legend class="scheduler-border" style="color: Green; font-weight: normal">শুল্ক ও করসহ বিক্রয়মূল্য</legend>
                                        <div class="col-sm-6">
                                            <asp:Label ID="Label64" runat="server" Text="পাইকারী"></asp:Label><br />
                                            <asp:TextBox ID="txtWholeSalePrice" onkeypress="return on(event)" onchange="myFunction()" runat="server" Style="width: 90%" placeholder="0.00"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Label ID="Label65" runat="server" Text="খুচরা মূল্য"></asp:Label>
                                            <asp:TextBox ID="txtRetailPrice" runat="server" Style="width: 90%"
                                                placeholder="0.00" OnTextChanged="txtRetailPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                    </fieldset>
                                </div>
                              
                               
                            </div>
  
                            <div class="row" style="margin-top:10px">
                                <div class="col-sm-3">
                                     <div class="form-group form-group-sm">
                                         <label class="col-sm-5 control-label text-right">প্রস্তাবিত মূল্য :</label>
                                        <%--<asp:Label ID="Label80" runat="server" class="col-sm-5 control-label text-right" Text="প্রস্তাবিত মূল্য :"></asp:Label>--%>
                                        <div class="col-sm-7">
                                         <asp:TextBox ID="txtProposedPrice"  CssClass="form-control" onkeypress="return on(event)" runat="server" Style="width: 90%" placeholder="0.00"></asp:TextBox>
                                    </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Trade Price(%) :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtTradePricePct" runat="server" Style="width: 90%" ReadOnly="True"  CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Trade Price (TP) :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtTradePriceValue" runat="server" Style="width: 90%"  CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                           <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">এগ্রিমেন্ট নং :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtAgreementNo" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:Label ID="lblHSCode" runat="server" CssClass="hiddencol"></asp:Label>&nbsp;<asp:Label ID="lblUnit" runat="server" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row hiddencol">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">হিসাব</legend>
                                    <div class="col-md-3">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Unit Price :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtmUnitPrice" CssClass="form-control" runat="server" placeholder="0.00" AutoPostBack="true" OnTextChanged="txtmUnitPrice_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-3 control-label text-right">Vat : </label>
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="txtmVat" CssClass="form-control" runat="server" placeholder="0.00"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3" style="padding-left: 0px; padding-top: 1.5%; font-weight: bold">
                                                <asp:Label ID="lblmVatPercent" runat="server" Text="0" />
                                                <asp:Label ID="Label17" runat="server" Text="%" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-3 control-label text-right">SD :</label>
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="txtmSD" CssClass="form-control" runat="server" placeholder="0.00"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-3" style="padding-left: 0px; padding-top: 1.5%; font-weight: bold">
                                                <asp:Label ID="lblmSDPercent" runat="server" Text="0" />
                                                <asp:Label ID="Label19" runat="server" Text="%" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Total Price :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtmVatablePrice" CssClass="form-control" runat="server" placeholder="0.00" AutoPostBack="true" OnTextChanged="txtmVatablePrice_TextChanged"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>

                            <div class="row" style="margin-top: 10px">
                                <ul class="tab">
                                    <li><a href="javascript:void(0)" class="tablinks active" onclick="openTab(event, 'Ingradients')">Principal Inputs</a></li>
                                    <li><a href="javascript:void(0)" class="tablinks" onclick="openTab(event, 'valueAdditionNonItem')">Other Principal inputs</a></li>
                                    <li><a href="javascript:void(0)" class="tablinks " onclick="openTab(event, 'valueAdditionItem')">Value Addition</a></li>

                                </ul>
                                <asp:HiddenField ID="hidTAB" runat="server" />
                                  <%-- <asp:HiddenField ID="hfTab" runat="server" />--%>
                                <asp:Label ID="cID" CssClass="hiddencol" runat="server" Text="0,00,000.00" Style="float: right; margin-top: -2%; padding-right: 8%; font-weight: bold; color: red" />
                                <asp:Label runat="server" CssClass="hiddencol" Text="Compare : " Style="float: right; margin-top: -2%; margin-right: 15%; font-weight: bold; color: red" />
                            </div>
                            <div class="row" style="margin-top: 0px; width: 100%">
                                <div id="Ingradients" class="tabcontent" style="display: block;">
                                    <asp:Panel ID="pnDetails" runat="server" Width="">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <fieldset>
                                                    <legend style="font-size: 16px">একক পণ্য উৎপাদনে ব্যবহার্য উপকরন / কাঁচামাল ও প্যাকিং সামগ্রীর নাম ও বিবরণ (অবচয়সহ)</legend>
                                            <div id="HeaderDiv"></div>
                                                    <div class="col-sm-12" style="text-align:right">   
                                                            <asp:CheckBox id="isAvg" runat="server"  Text="Average Price" OnCheckedChanged="unCheckisAvg_Changed" AutoPostBack="true"></asp:CheckBox>
                                                            <asp:CheckBox id="isLast" runat="server" Text="Last Challan" OnCheckedChanged="unCheckisLast_Changed" AutoPostBack="true"></asp:CheckBox>
                                                            <asp:CheckBox id="isManual" runat="server"  Text="Manual" OnCheckedChanged="unCheckisManual_Changed" AutoPostBack="true"></asp:CheckBox>
                                                            
                                                    </div>
                                                    <div id="detailDivArea" style="overflow: auto; padding-left: 1.5%; border: 0px solid olive; width: 100%; height: 100%;" onscroll="Onscrollfnction();">

                                                        <asp:GridView ID="gvItems" ShowFooter="True" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" OnRowDeleting="gvItems_RowDeleting">
                                                             <HeaderStyle CssClass="GridViewHeaderStyle" />                                                           
                                                          <Columns>
                                                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" HeaderStyle-BackColor="#6F7A93" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" FooterStyle-CssClass="hiddencol"/>
                                                              <asp:TemplateField HeaderText="সাব-ক্যাটাগরী" HeaderStyle-CssClass="GridHeader" ControlStyle-Width="70px" HeaderStyle-BackColor="#6F7A93">
                                                                  <ItemTemplate>
                                                                      <asp:DropDownList ID="drpCategory" runat="server" CssClass="smallSizeDropdownList" Height="29px" DataTextField="category_name" DataValueField="category_id" AutoPostBack="true" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" DataSourceID="odsItemCategory">
                                                                      </asp:DropDownList>
                                                                     <asp:Label ID="lblDrpCategory" runat="server" Visible="false"></asp:Label>
                                                                  </ItemTemplate>
                                                                  <ItemStyle Width="35px" />
                                                              </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="উপকরণ/কাঁচামাল" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#6F7A93">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="drpItemName" runat="server" style="width:200px" Height="29px"
                                                                            CssClass="smallSizeDropdownList select2" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="drpItemName_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:Label ID="lblItemUnitId" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblItemUnit" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="220px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="মজুদ" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#6F7A93">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtAvailableStock" ReadOnly="true" runat="server" CssClass="stdTextBox" Height="29px" Text="0.00">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAvailableStock_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtAvailableStock"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="একক(মজুদ)"  HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#6F7A93">
                                                                    <FooterTemplate>
                                                                        <asp:Button ID="btnNewRow" runat="server" CssClass="button"
                                                                            OnClick="ButtonAdd_Click" Text="New Row" />
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                      
                                                                         <asp:DropDownList ID="ddlUnitChallan" Height="29px"   runat="server" Width="100%">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1"  Height="29px"  runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText=" গ্রস ব্যবহার" ControlStyle-Width="100px" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#a1c270">
                                                                
                                                                     <ItemTemplate>
                                                                        <asp:TextBox ID="txtQuantityTotal" runat="server" CssClass="stdTextBox"  Height="29px"  Text="0.00%"
                                                                            Width="65px"  OnTextChanged="txtQuantityTotal_TextChanged" AutoPostBack="True"></asp:TextBox>
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
                                                         
                                                               <asp:TemplateField HeaderText="একক (গ্রস ব্যবহার)" ControlStyle-Width="65px" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#a1c270">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlUnitSec" runat="server" Width="100%"  Height="29px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnitSec_SelectedIndexChanged" >
                                                                        </asp:DropDownList>                                                                    
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>                                                                    
                                                                    </EditItemTemplate>                                                                  
                                                                </asp:TemplateField>
                                                             
                                                                <asp:TemplateField HeaderText="অপচয় %" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#a1c270">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtWastageParcent" runat="server" CssClass="stdTextBox" Height="29px" Text="0.00%" onchange="wastageinfo(this)"
                                                                            onkeypress="return on(event)" Width="65px"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtWastageParcent_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtWastageParcent"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="45px" />
                                                                </asp:TemplateField>
                                                             
                                                                <asp:TemplateField HeaderText="অপচয়" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#a1c270">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="stdTextBox" Height="29px" 
                                                                            Text="0.00" Width="75px"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtPrice_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtPrice"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtWastage" runat="server" CssClass="stdTextBox" Height="29px"  Text="0.00" onchange="wastageinfopct(this)"  onkeypress="return on(event)"
                                                                            Width="75px"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtWastage_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtWastage"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>
                                                              
                                                                <asp:TemplateField HeaderText="নীট ব্যবহার" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#a1c270">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtItemQuantity" Enabled="false" runat="server" Height="29px" Width="65px">0.00</asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtItemQuantity_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtItemQuantity"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                             
                                                                <asp:TemplateField HeaderText="চালান পরিমান " ControlStyle-Width="110px" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#CBAA90">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtChallanQuantity" runat="server" CssClass="stdTextBox" Text="0.00" Width="65px" Height="29px" OnTextChanged="txtChallanQuantity_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtChallanQuantity_FilteredTextBoxExtender" 
                                                                            runat="server" Enabled="True" TargetControlID="txtChallanQuantity"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="45px" />
                                                                </asp:TemplateField>
                                                             
                                                               <asp:TemplateField HeaderText="একক(উপকরণের একক)"  HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#CBAA90">
                                                                   
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlUnit"  runat="server" Width="100%"  Height="29px"  AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" Height="29px"  runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="চালান মূল্য" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#CBAA90">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtChallanPrice" runat="server" CssClass="stdTextBox" Height="29px" Text="0.00" Width="100px" OnTextChanged="txtChallanPrice_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtChallanPrice_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtChallanPrice"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>
                                                              
                                                                <asp:TemplateField HeaderText="উৎপাদন সংখ্যা" ControlStyle-Width="110px" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#CBAA90">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtProductionQuantity"  runat="server"  Height="29px"  CssClass="stdTextBox" Text="0.00"  OnTextChanged="txtProductionQuantity_TextChanged" AutoPostBack="True"
                                                                            Width="65px"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtProductionQuantity_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtProductionQuantity"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>                                                              
                                                                <asp:TemplateField HeaderText="মূল্য" ControlStyle-Width="110px" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#a1c270">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQuantity"  runat="server" CssClass="stdTextBox" Text="0.00" Height="29px"  Width="65px"  OnTextChanged="txtQuantity_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtQuantity_FilteredTextBoxExtender"
                                                                            runat="server" Enabled="True" TargetControlID="txtQuantity"
                                                                            ValidChars=".0123456789">
                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="চালান সূত্র" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#CBAA90">
                                                                    <ItemTemplate>
                                                                       <asp:DropDownList ID="txtReference" CssClass="smallSizeDropdownList" Height="29px"  runat="server" DataTextField="challan_no" DataValueField="challan_id"
                                                                            OnSelectedIndexChanged="drpChallanNo_SelectedIndexChanged" AutoPostBack="true">
                                                                        </asp:DropDownList>

                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="মন্তব্য" HeaderStyle-CssClass="GridHeader" HeaderStyle-BackColor="#6F7A93">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="stdTextBox" Height="31px"  TextMode="MultiLine" Rows="1" Columns="1"  Text="" ToolTip="মন্তব্য"
                                                                            Width="100px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="65px" />
                                                                </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="RNO" HeaderStyle-CssClass="GridHeader hiddencol" HeaderStyle-BackColor="#6F7A93" ItemStyle-CssClass="hiddencol" FooterStyle-CssClass="hiddencol">
                                                              <ItemTemplate>
                                                                  <asp:TextBox ID="txtRowNO" runat="server" CssClass="stdTextBox" Text="0.00">
                                                                  </asp:TextBox>
                                                              </ItemTemplate>
                                                              <ItemStyle Width="65px" />                                                              
                                                          </asp:TemplateField>
                                                            </Columns>

                                                            <HeaderStyle CssClass="header" />
                                                        </asp:GridView>
                                                        <input id="scrollPos" runat="server" type="hidden" value="0" />
                                                        <input id="scrollPosLeft" runat="server" type="hidden" value="0" />
                                                       <%-- <asp:ObjectDataSource ID="odsItemCategory" runat="server" SelectMethod="getAllItemCategoryWithBlankRowForBOM2" TypeName="SetItemBLL"></asp:ObjectDataSource>--%>
                                                    <asp:ObjectDataSource ID="odsItemCategory" runat="server" SelectMethod="getAllItemCategoryPD" TypeName="SetItemBLL"></asp:ObjectDataSource>
                                                         </div>
                                                </fieldset>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>

                                </div>
                            <div id="valueAdditionNonItem"  style="width: 40%;">
                                    <asp:Panel ID="Panel5" runat="server" Height="100%" ScrollBars="Vertical">
                                        <table class="brd_tbl_input">
                                            <tr>
                                                <td class="grid_row_style1">
                                                    <asp:Label ID="Label6" runat="server"
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
                                                            <%--[ 30-08-2021 Edited By: Parves]--%>
                                                            <asp:TemplateField HeaderText="Status" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBoxNonItem" runat="server" Text='<%# Bind("vStatus") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblvStatus1" runat="server" Text='<%# Bind("vStatus") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--[ 30-08-2021 Edited By: Parves]--%>
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
                                                                        onblur="calotheradd(this)" Width="50px">0.00</asp:TextBox>
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
                  
                            <div id="valueAdditionItem" class="tabcontent" style="width: 40%;">
                                    <asp:Panel ID="Panel4" runat="server" Height="100%" ScrollBars="Vertical">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <fieldset>

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
                                                                         <%--[ 29-08-2021 Edited By: Parves]--%>
                                                                        <asp:TemplateField HeaderText="Status" Visible="False">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("vStatus") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblvStatus" runat="server" Text='<%# Bind("vStatus") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--[ 29-08-2021 Edited By: Parves]--%>
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
                                                                                <asp:TextBox ID="txtValueAddition" runat="server" CssClass="text_box" Style="width: 100px" onFocusOut="calValuadd(this)" Width="50px">0.00</asp:TextBox>

                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtValueAddition_FilteredTextBoxExtender"
                                                                                    runat="server" Enabled="True" TargetControlID="txtValueAddition"
                                                                                    ValidChars=".0123456789">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Center" />
                                                                            <ItemStyle CssClass="grid_item" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>

                                                                          <asp:TemplateField HeaderText="মূল্য সংযোজনের পরিমাণ (%)">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtValueAdditionpct" runat="server"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalValueAdditionpct" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtValueAdditionpct" runat="server" CssClass="text_box" Style="width: 100px" onFocusOut="calValuaddpct(this)" Width="50px">0.00</asp:TextBox>

                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtValueAdditionpct_FilteredTextBoxExtender"
                                                                                    runat="server" Enabled="True" TargetControlID="txtValueAdditionpct"
                                                                                    ValidChars=".0123456789">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
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
                                                </fieldset>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 10px">
                                <div class="col-sm-6" style="margin-left: 39px">

                                    <asp:Label ID="Label13" runat="server" Width="100px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" Text="গ্রস ব্যবহার"
                                        Font-Bold="True" ReadOnly="True" Style="text-align: center; margin-left: 3px"></asp:Label>

                                    <asp:Label ID="Label14" runat="server" Width="100px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True" Text="অপচয়" Style="text-align: center"></asp:Label>

                                    <asp:Label ID="Label15" runat="server" Width="100px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True" Text="নীট ব্যবহার" Style="text-align: center"></asp:Label>
                                    <asp:Label ID="Label16" runat="server" Width="100px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True" Text="মূল্য" Style="text-align: center"></asp:Label>

                                </div>


                            </div>
                            <updatepanel>
                                
                            <div class="row" style="margin-top: 10px">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label81" runat="server" Text="মোট ="></asp:Label>
                                    <asp:TextBox ID="txtSumQuantityTotal" runat="server" Width="100px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSumWastage" runat="server" Width="100px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSumItemQuantity" runat="server" Width="100px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                    <%--                    <asp:TextBox ID="txtTotalPrice1" runat="server" Width="75px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px" 
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtTotalPrice" runat="server" Width="100px" BackColor="Transparent" BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True"></asp:TextBox>

                                </div>
                                 <div class="col-sm-2">
                                    <asp:Label ID="Label11" runat="server" Text="Other Principal Inputs:" style="text-align:right"></asp:Label>
                                    <asp:TextBox ID="nonItemTotalExpense" runat="server" BackColor="Transparent"  BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True" Width="100px"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label10" runat="server" Text="Value Addition:" style="text-align:right"></asp:Label>
                                    <asp:TextBox ID="txtTotalExpenses" runat="server" BackColor="Transparent"  BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True" Width="100px"></asp:TextBox>
                                 </div>
                                  <div class="col-sm-2">
                                    <asp:Label ID="Label2" runat="server" Text="Value Addition %:" style="text-align:right"></asp:Label>
                                    <asp:TextBox ID="txtTotalvladpct" runat="server" BackColor="Transparent"  BorderColor="#0099CC" BorderStyle="Solid" BorderWidth="1px"
                                        Font-Bold="True" ReadOnly="True" Width="100px"></asp:TextBox>
                                 </div>   
                               
                            </div>
                            <div class="row" style="text-align:right;margin-top:5px">
                                 <div class="col-sm-11">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50;" Text="Save Declaration" OnClick="btnSave_Click"/>
                                    <asp:Button ID="btnRefreshChallan1" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50" Text="Refresh" OnClick="btnRefreshChallan1_Click" />
                                <asp:HyperLink class="btn-btn" style="background-color:#4CAF50;text-align:center" Height="25px" Width="100px" NavigateUrl="~/UI/Item/ImportPricrDeclarationFromExcel.aspx" runat="server">Import Excel</asp:HyperLink>
                                      </div>
                                    </div>
                                </updatepanel>
                          
                            <div class="panel-group" style="margin-top:5px;">
                    <div class="panel panel-primary">
                      <div class="row" style="margin-top:5px;margin-bottom:5px">
                      <div class="col-sm-6">
                         <label>পণ্য :</label>                                     
                             <asp:DropDownList ID="drpSearchItem"  Width="200px" runat="server" CssClass="form-control select2" AutoPostBack="True">
                            </asp:DropDownList>                                          
                           <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" Style="background-color: #3B7CB5;" Text="Search" OnClick="btnSearch_Click" />
                         </div>
                                   </div>
                         </div>
                    </div>
                            <div class="row" style="margin-top: 10px">
                                <asp:GridView ID="gvDeclaretion" runat="server" AutoGenerateColumns="False"
                                    CssClass="sGrid"
                                    DataKeyNames="price_id" Width="100%"
                                    OnSelectedIndexChanged="gvDeclaretion_SelectedIndexChanged"
                                    AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True"
                                    OnPageIndexChanging="gvDeclaretion_PageIndexChanging" PageSize="20">
                                    <Columns>


                                        <asp:BoundField DataField="price_declaration_no"
                                            HeaderText="Price Declaration No">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle CssClass="grid_item_header" />
                                            <ItemStyle CssClass="grid_item" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="date_effective"
                                            HeaderText="Effective Date">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle CssClass="grid_item_header" />
                                            <ItemStyle CssClass="grid_item" />
                                        </asp:BoundField>


                                        <asp:BoundField DataField="category_name" HeaderText="Sub Category">
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
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle CssClass="grid_item_header" />
                                            <ItemStyle CssClass="grid_item" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="retail_prc_sd_vat" HeaderText="Retail Price"
                                            ItemStyle-Wrap="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle CssClass="grid_item_header" />
                                            <ItemStyle CssClass="grid_item" />
                                        </asp:BoundField>

                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True"
                                        ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                    <EmptyDataTemplate>
                                        No Items Found.
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>

                            </div>
                            <div class="" style="margin-top: 0px; visibility: hidden">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label78" runat="server" Text="জাতীয় রাজস্ব বোর্ড ্তৃক অনুমোদিত মূল্য"></asp:Label>
                                    <asp:Label ID="Label12" runat="server" Text="একক পণ্য উৎপাদনে প্রতিটি খাতের অনুমোদিত মূল্য সংযোজনের পরিমাণ"></asp:Label>
                                    <asp:Label ID="Label79" runat="server" Font-Bold="True" Text="মূল্য ঘোষণা নং :"></asp:Label>
                                    <asp:Label ID="lblPriceDeclarationNo" runat="server" Font-Bold="True"></asp:Label>
                                    <asp:HiddenField ID="hfPriceId" runat="server" />
                                    <asp:Label ID="lblDesc3" runat="server" Text="মূল্য ঘোষণার তারিখ :"></asp:Label>
                                    <asp:Label ID="dtpNBRApproveDate" runat="server" DateFormat="dd/MM/yyyy" Width="130px"></asp:Label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:GridView ID="gvNBRValueAddition" runat="server" AutoGenerateColumns="False"
                                        CssClass="grid" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID0" runat="server"></asp:Label>
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
                                </div>
                            </div>
                            <div class="" style="margin-top: 0px; visibility: hidden">
                                <asp:Label ID="lblDesc7" runat="server" Font-Bold="True" Text="অনুমোদিত মূল্য"></asp:Label>
                                <asp:Label ID="lblDesc8" runat="server" Font-Bold="True" Text="প্রস্তাবিত মূল্য"></asp:Label>
                                <asp:Label ID="lblDesc0" runat="server" Text="মূল্য :"></asp:Label>
                                <asp:TextBox ID="txtNBRPrice" runat="server" CssClass="longTextBox" Width="65px"></asp:TextBox>
                                <asp:Label ID="lblPrice" runat="server" BorderColor="#00CCFF" BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                                <asp:HiddenField ID="hfNBRPrice" runat="server" />
                                <asp:Label ID="lblSubCategory" runat="server" Text="সম্পূরক শুল্ক আরোপযোগ্য মূল্য :"></asp:Label>
                                <asp:TextBox ID="txtNBRSDChargablePrice" runat="server" CssClass="longTextBox" Width="65px"></asp:TextBox>
                                <asp:Label ID="lblNBRSDChargablePrice" runat="server" BorderColor="#00CCFF" BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                                <asp:Label ID="lblSubCategory0" runat="server" Text="সম্পূরক শুল্ক :"></asp:Label>
                                <asp:TextBox ID="txtNBRSD" runat="server" CssClass="longTextBox" Width="65px"></asp:TextBox>
                                <asp:HiddenField ID="hfNBRSD" runat="server" />
                                <asp:Label ID="lblNBRSD" runat="server" BorderColor="#00CCFF" BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                            </div>
                            <div class="" style="margin-top: 0px; visibility: hidden">
                                <asp:Label ID="lblDesc4" runat="server" Font-Bold="True" Text="অনুমোদিত মূল্য"></asp:Label>
                                <asp:Label ID="lblDesc5" runat="server" Font-Bold="True" Text="প্রস্তাবিত মূল্য"></asp:Label>
                                <asp:Label ID="lblDesc" runat="server" Text="ভ্যাট আরোপযোগ্য মূল্য :"></asp:Label>
                                <asp:TextBox ID="txtNBRVATChargeablePrice" runat="server" CssClass="longTextBox" Width="65px"></asp:TextBox>
                                <asp:Label ID="lblNBRVATChargeablePrice" runat="server" BorderColor="#00CCFF" BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtNBRSDChargablePrice"
                                    ErrorMessage="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" SetFocusOnError="True"
                                    ToolTip="সম্পূরক শুল্ক আরোপযোগ্য মূল্য" ValidationGroup="addSubCategory">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblDesc1" runat="server" Text="পাইকারী মূল্য :"></asp:Label>
                                <asp:TextBox ID="txtNBRWholeSalePrice" runat="server" CssClass="longTextBox" Width="65px"></asp:TextBox>
                                <asp:Label ID="lblNBRWholeSalePrice" runat="server" BorderColor="#00CCFF" BorderStyle="Solid" BorderWidth="1px" Width="80px"></asp:Label>
                                <asp:Label ID="lblDesc2" runat="server" Text="খুচরা মূল্য :"></asp:Label>
                                <asp:TextBox ID="txtNBRRetailPrice" runat="server" CssClass="longTextBox" Width="65px"></asp:TextBox>
                                <asp:Label ID="lblNBRRetailPrice" runat="server" BorderColor="#00CCFF" BorderStyle="Solid" BorderWidth="1px" CssClass="label" Width="80px"></asp:Label>
                                <asp:Label ID="lblPriceId" runat="server" Visible="False"></asp:Label>
                            </div>
                            <div class="" style="margin-top: 0px; visibility: hidden">
                                <asp:Button ID="btnApprove" runat="server" Text="Save" CssClass="button"
                                    ValidationGroup="addSubCategory" OnClick="btnApprove_Click" />
                                &nbsp;
                                 <asp:Button ID="btnSubClear" CssClass="button" runat="server" Text="Close"
                                     OnClick="btnSubClear_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="addSubCategory" ForeColor="Red" />
                                <asp:Button ID="btnHiddenForApprovePrice" runat="server" Style="display: none" />
                                <ajaxToolkit:ModalPopupExtender ID="modalPopupForApprovePrice" runat="server" PopupControlID="pnlApprovePrice"
                                    TargetControlID="btnHiddenForApprovePrice" BackgroundCssClass="mpBack">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:Label ID="Label58" runat="server" Text="Unit"></asp:Label>
                                <asp:DropDownList ID="drpUnit" runat="server" Width="100px"></asp:DropDownList>
                                <asp:Label ID="Label53" runat="server" Text="Property 1"></asp:Label>
                                <asp:DropDownList ID="ddlItem6" runat="server" Width="100px"></asp:DropDownList>
                                <asp:Label ID="Label54" runat="server" Text="Property 2"></asp:Label>
                                <asp:DropDownList ID="ddlItem7" runat="server" Width="100px"></asp:DropDownList>
                                <asp:Label ID="Label55" runat="server" Text="Property 3"></asp:Label>
                                <asp:DropDownList ID="ddlItem8" runat="server" Width="100px"></asp:DropDownList>
                                <asp:Label ID="Label56" runat="server" Text="Property 4"></asp:Label>
                                <asp:DropDownList ID="ddlItem9" runat="server" Width="100px"></asp:DropDownList>
                                <asp:Label ID="Label57" runat="server" Text="Property 5"></asp:Label>
                                <asp:DropDownList ID="ddlItem10" runat="server" Width="100px"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
             <%--   <uc2:MsgBox ID="msgBox" runat="server" />--%>
                <uc1:MsgBoxs runat="server" ID="msgBox" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="row">
            <div class="col-sm-12">
                <asp:FileUpload ID="FileUpload1" runat="server" Style="background: #E0EBF5" />
                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload Excel" class="btn-btn" Style="background-color: #4CAF50;" />
                <asp:Label ID="Label29" runat="server"></asp:Label>
            </div>
        </div>
    </div>


</asp:Content>
