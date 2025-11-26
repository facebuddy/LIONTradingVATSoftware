<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="SupplDutyAdjApp_7_1, App_Web_znns2ib5" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register src="../../UserControls/Sale.ascx" tagname="sale" tagprefix="uc1" %>--%>
<%@ Register Src="../../UserControls/Production.ascx" TagName="production" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <style type="text/css">
        .style1dr
        {
            height: 20px;
        }
        .style2
        {
            height: 25px;
        }
        .style3
        {
            height: 24px;
        }
        
       
    </style>
    <style media="print">
        .noPrint
        {
            display: none;
        }
        @media print
        {
            table
            {
                width: 100%;
            }
            tr, td
            {
            }
            .full_width
            {
                width: 100%;
            }
        }
        .yesPrint
        {
            display: block !important;
        }
        input[type=text], select, textarea, .text_box
        {
            border: none;
        }
    </style>
    <script>
         function addSD(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAdjustableSDTk.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var sd = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvImportItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                
                sd += parseFloat(jsGvChallanItem.rows[rowIndex].cells[10].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                sd -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[10].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=txtAdjustableSDTk.ClientID%>").value = parseFloat(Number(sd)).toFixed(2);
            document.getElementById("<%=txtAdjustableSDTk.ClientID%>").style.background = "#cfc";


         }

         function addrefundSD(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=lblrefundSDTK.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var sd = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvExportItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                var ab = parseFloat(jsGvChallanItem.rows[rowIndex].cells[10].innerHTML.toString());
              
              
                sd += parseFloat(jsGvChallanItem.rows[rowIndex].cells[10].innerHTML.toString());
               
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                sd -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[10].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=lblrefundSDTK.ClientID%>").value = parseFloat(Number(sd)).toFixed(2);
            document.getElementById("<%=lblrefundSDTK.ClientID%>").style.background = "#cfc";


        }
         function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvImportItem.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked != IsChecked) {
                        items[i].click();
                    }
                }
            }

         }
        function SelectAllCheckboxesSpecificexp(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvExportItem.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked != IsChecked) {
                        items[i].click();
                    }
                }
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right:0%; padding-left:0%">
      <div class="panel-group">
        <div class="panel panel-primary">
           <div class="panel-heading" style="text-align:center;font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">সম্পূরক শুল্ক  সমন্বয়ের আবেদনপত্র (মূসক-৭.১)</div>
            <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
                <div class="row" style="background-color:#E0EBF5">
                    <div class="col-sm-4">
                        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                         <asp:Literal ID="lt_companyName" runat="server"></asp:Literal>
                    </div>
                    <div class="col-sm-6">
                         <asp:Label class="col-sm-2" ID="Label2" runat="server" Text="Address:"></asp:Label>
                         <asp:Literal ID="It_companyAddress" runat="server"></asp:Literal>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="Label8" runat="server" Text="BIN:"></asp:Label>
                        <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-3 col-xs-3 col-lg-2">
                        <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                        <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                        <asp:Label ID="lblOrgAddress" runat="server" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-body" style="padding-right: 0px; padding-bottom: 0px;margin-bottom:10px;">
                            <div class="container-fluid"> 
                <div class="row" style="margin-top:10px">
                    <div class="col-sm-4">
                      <div class="col-sm-4">                          
                        <asp:Label ID="Label10" class="present-address-lbl" runat="server" Text=""><span class="required"  style="color:red"> * </span>From Date:</asp:Label>
                      </div>
                      <div class="col-sm-8">
                           <asp:TextBox CssClass="form-control" runat="server" ID="txtFromdate" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromdate" />
                       
                     </div>
                    </div>
                    <div class="col-sm-4">
                      <div class="col-sm-4">
                        <asp:Label ID="Label11" runat="server"  Text="" class="present-address-lbl"><span class="required"  style="color:red"> * </span>To Date:</asp:Label>
                           
                      </div>
                      <div class="col-sm-8">
                          <asp:TextBox CssClass="form-control" runat="server" ID="txtTodate" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTodate" />
                        
                      </div>
                    </div>
                       <div class="col-sm-4">
                      <div class="col-sm-4">
                        <asp:Button runat="server" CssClass="btn-btn" style="background-color:#3B7CB5;" Text="Search" ID="btnSearch" OnClick="btnSearch_Click"/>
                           </div>
                         </div>
                     
                    </div>
                    </div>    
                      </div>
                     
                    </div>
                </div>
                <div class="row" style="margin-top:10px">
                    <div class="col-sm-4">
                      <div class="col-sm-6">                          
                     <asp:Label ID="Label3" class="present-address-lbl"   style="text-align:right" runat="server"> <span class="required"  style="color:red"> * </span>Application Date:</asp:Label>

                      </div>
                      <div class="col-sm-6">
                           <asp:TextBox CssClass="present-address-tb" runat="server" ID="txtApplicationDate" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtApplicationDate" />
                       
                     </div>
                    </div>
                    <div class="col-sm-4">
                      <div class="col-sm-6">
                    <asp:Label ID="Label4" runat="server"  Text=""   style="text-align:right" class="present-address-lbl"> <span class="required"  style="color:red"> * </span>Export Date:</asp:Label>
                           
                      </div>
                      <div class="col-sm-6">
                          <asp:TextBox CssClass="present-address-tb" runat="server" style="width:150px" ID="txtExportDate" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtExportDate" />
                        
                      </div>
                    </div>
                </div>
                <div class="row" style="margin-top:10px">
                   <div class="col-sm-4">
                      <div class="col-sm-6">                          
                          <asp:Label ID="Label6" runat="server"   style="text-align:right" Text="" class="present-address-lbl"> <span class="required"  style="color:red"> * </span>Adjustable SD:</asp:Label>
                      </div>
                      <div class="col-sm-6">
               <asp:TextBox runat="server" ID="txtAdjustableSDTk" placeholder="সমন্বয়যোগ্য সম্পূরক শুল্কের পরিমান (টাকায়)" class="present-address-tb" ></asp:TextBox>

                                                   
                     </div>
                    </div>
                      <div class="col-sm-4">
                        <asp:TextBox runat="server" ID="txtAdjustableSDInword" placeholder="in word" style="width:250px"  class="present-address-tb"></asp:TextBox>
                    </div>
                </div>


                  <div class="row" style="margin-top:10px">
                   <div class="col-sm-4">
                      <div class="col-sm-6">                          
                         <asp:Label ID="Label12"   style="text-align:right" runat="server" Text="" class="present-address-lbl"> <span class="required"  style="color:red"> * </span>Refund SD:</asp:Label>
                      </div>
                      <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="lblrefundSDTK" placeholder="রপ্তানিকৃত পণ্যে আমদানি পর্যায়ে পরিশোধিত সম্পূরক শুল্কের পরিমান (টাকায়)" class="present-address-tb" ></asp:TextBox>
                                                   
                     </div>
                    </div>
                      <div class="col-sm-4">
                        <asp:TextBox runat="server" ID="lblrefundSDWord" placeholder="in word" style="width:250px"   class="present-address-tb"></asp:TextBox>
                    </div>
                </div>

                

           
                <div class="row" style="margin-top:10px">
                    <div class="col-sm-8">
                         <div class="col-sm-6">
                        <asp:Label ID="Label7" runat="server" Text="Import Item Description:" class="present-address-lbl"></asp:Label>
                       <div class="col-sm-6">
                         <asp:DropDownList ID="drpImportItemDescription" runat="server" Visible="true" class="present-address-tb" style="width:142%" AutoPostBack="True" OnSelectedIndexChanged="drpImportItemDescription_SelectedIndexChanged"></asp:DropDownList>
                    </div> 

                         </div>
                         </div>
                </div>
                <div class="row" runat="server" id="part_a">
                    <div class="panel panel-primary">
                        <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
                            <div class="container-fluid">
                                <div class="row" style="margin-top:1%">
                               <%-- <table cellspacing="0" cellpadding = "0" rules="all" border="1" 
                                         style="font-family:Arial;font-size:10pt;width:100%;color:white;
                                         border-collapse:collapse;height:100%;">
                                    <tr style="background-color:Green;">
                                        <td style ="width:2%; background-color:Green;"><asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)" ToolTip="Check to Select All Item" /></td>
                                         <asp:Label runat="server" ID="gvHeader" />
                                    </tr>
                                </table>--%>
                                    <asp:GridView ID="gvImportItem" runat="server" AutoGenerateColumns="False"  onselectedindexchanged="gvImportItem_SelectedIndexChanged" Width="100%" 
                                  onprerender="gvImportItem_PreRender" onrowdatabound="gvImportItem_RowDataBound"  onrowdeleting="gvImportItem_RowDeleting" ShowHeaderWhenEmpty="true">
                                  <Columns>
                                      <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                            <HeaderTemplate >
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)" ToolTip="Check to Select All Item" />
                                               <%-- <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)" ToolTip="Check to Select All Item" />--%>
                                            </HeaderTemplate>
                                            <ItemTemplate >
                                                <asp:CheckBox ID="chkChallan" runat="server" onclick="addSD(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:BoundField ItemStyle-Width="8%" DataField="challan_no" HeaderText="Bill of Entry No" />
                                      <asp:BoundField ItemStyle-Width="10%" DataField="date_challan"  HeaderText="Bill of Entry Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                      <asp:BoundField ItemStyle-Width="18%" DataField="hs_code" HeaderText="HS Code"/>
                                      <asp:BoundField ItemStyle-Width="15%" DataField="item_name" HeaderText="Item" />
                                      <asp:BoundField  DataField="Property1" HeaderText="Property1" Visible="False" />
                                      <asp:BoundField DataField="Property2" HeaderText="Property2" Visible="False" />
                                      <asp:BoundField DataField="Property3" HeaderText="Property3" Visible="False" />
                                      <asp:BoundField DataField="Property4" HeaderText="Property4" Visible="False" />
                                      <asp:BoundField DataField="Property5" HeaderText="Property5" Visible="False" />
                                      <asp:BoundField ItemStyle-Width="3%" DataField="quantity" HeaderText="Quantity"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="unit_code" HeaderText="Unit"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="purchase_unit_price" HeaderText="Unit Price"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="CD" HeaderText="CD"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="RD" HeaderText="RD"/>
                                      <asp:BoundField ItemStyle-Width="12%" DataField="SD" HeaderText="SD" DataFormatString="{0:0.00#}"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="VAT" HeaderText="VAT"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="AIT" HeaderText="AIT"/>
                                      <asp:BoundField ItemStyle-Width="9%" DataField="total_price" HeaderText="Total"/>
                                     <%-- <asp:BoundField ItemStyle-Width="8%" DataField="challan_no"/>
                                      <asp:BoundField ItemStyle-Width="10%" DataField="date_challan" DataFormatString="{0:dd/MM/yyyy}" />
                                      <asp:BoundField ItemStyle-Width="18%" DataField="hs_code" HeaderText="HS Code"/>
                                      <asp:BoundField ItemStyle-Width="15%" DataField="item_name" HeaderText="Item" />
                                      <asp:BoundField  DataField="Property1" HeaderText="Property1" Visible="False" />
                                      <asp:BoundField DataField="Property2" HeaderText="Property2" Visible="False" />
                                      <asp:BoundField DataField="Property3" HeaderText="Property3" Visible="False" />
                                      <asp:BoundField DataField="Property4" HeaderText="Property4" Visible="False" />
                                      <asp:BoundField DataField="Property5" HeaderText="Property5" Visible="False" />
                                      <asp:BoundField ItemStyle-Width="3%" DataField="quantity"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="unit_code"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="purchase_unit_price"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="CD"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="RD"/>
                                      <asp:BoundField ItemStyle-Width="12%" DataField="SD"  DataFormatString="{0:0.00#}"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="VAT"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="AIT"/>--%>
                               <%--       <asp:BoundField ItemStyle-Width="3%" DataField="ATV"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="TTI"/>--%>
                                      <%--<asp:BoundField ItemStyle-Width="9%" DataField="total_price"/>--%>
                                      <%--<asp:BoundField DataField="challan_no" HeaderText="Bill of Entry No" />
                                      <asp:BoundField DataField="date_challan" HeaderText="Bill of Entry Date" />
                                      <asp:BoundField DataField="hs_code" HeaderText="HS Code"/>
                                      <asp:BoundField DataField="item_name" HeaderText="Item" />
                                      <asp:BoundField DataField="Property1" HeaderText="Property1" Visible="False" />
                                      <asp:BoundField DataField="Property2" HeaderText="Property2" Visible="False" />
                                      <asp:BoundField DataField="Property3" HeaderText="Property3" Visible="False" />
                                      <asp:BoundField DataField="Property4" HeaderText="Property4" Visible="False" />
                                      <asp:BoundField DataField="Property5" HeaderText="Property5" Visible="False" />
                                      <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                                      <asp:BoundField DataField="unit_code" HeaderText="Unit" />
                                      <asp:BoundField DataField="purchase_unit_price" HeaderText="Unit Price" />
                                      <asp:BoundField DataField="CD" HeaderText="CD" />
                                      <asp:BoundField DataField="RD" HeaderText="RD" />
                                      <asp:BoundField DataField="SD" HeaderText="SD" />
                                      <asp:BoundField DataField="VAT" HeaderText="VAT" />
                                      <asp:BoundField DataField="AIT" HeaderText="AIT" />
                                      <asp:BoundField DataField="ATV" HeaderText="ATV" />
                                      <asp:BoundField DataField="TTI" HeaderText="TTI" />
                                      <asp:BoundField DataField="total_price" HeaderText="Total" />--%>
                                     <%-- <asp:BoundField DataField="IsSrcTAXDeduct" HeaderText="Src TAX Deducted" />--%>
                                     <%-- <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />--%>
                                      </Columns>
                                      <HeaderStyle Height="25px" />
                                      <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                      </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                </div>
                 <div class="row" style="margin-top:10px">
                    <div class="col-sm-8">
                         <div class="col-sm-6">
                        <asp:Label ID="Label9" runat="server" Text="Export Item Description:" class="present-address-lbl"></asp:Label>
                        <div class="col-sm-6">
                             <asp:DropDownList ID="drpExportItemDescription" class="present-address-tb" runat="server" Visible="true" style="width:142%" AutoPostBack="true" OnSelectedIndexChanged="drpExportItemDescription_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                             </div> 

                         </div>
                         </div>
                
                <div class="row" runat="server" id="part_b" style="margin-top:10px">
                    <div class="panel panel-primary">
                        <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
                            <div class="container-fluid">
                                <div class="row" style="margin-top:1%">
                              <%-- <table cellspacing="0" cellpadding = "0" rules="all" border="1" 
                                         style="font-family:Arial;font-size:10pt;width:100%;color:white;
                                         border-collapse:collapse;height:100%;">
                                    <tr style="background-color:Green;">
                                        <td style ="width:2%; background-color:Green;"><asp:CheckBox ID="chlallex" runat="server" onclick="SelectAllCheckboxesSpecificexp(this)" ToolTip="Check to Select All Item" /></td>
                                         <asp:Label runat="server" ID="gvheader1"/>
                                    </tr>
                                </table>--%>
                                    <asp:GridView ID="gvExportItem" runat="server" AutoGenerateColumns="False" onselectedindexchanged="gvExportItem_SelectedIndexChanged" Width="100%" 
                                 onprerender="gvExportItem_PreRender" onrowdatabound="gvExportItem_RowDataBound"  onrowdeleting="gvExportItem_RowDeleting" ShowHeaderWhenEmpty="true">
                                      <Columns>
                                      <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                            <HeaderTemplate >
                                                <asp:CheckBox ID="chlallex" runat="server" onclick="SelectAllCheckboxesSpecificexp(this)" ToolTip="Check to Select All Item" />
                                               <%-- <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)" ToolTip="Check to Select All Item" />--%>
                                            </HeaderTemplate>
                                            <ItemTemplate >
                                                <asp:CheckBox ID="chkChallanex" runat="server" onclick="addrefundSD(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:BoundField ItemStyle-Width="8%" DataField="challan_no" HeaderText="Challan No" />
                                      <asp:BoundField ItemStyle-Width="10%" DataField="date_challan"  HeaderText="Challan Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                      <asp:BoundField ItemStyle-Width="18%" DataField="hs_code" HeaderText="HS Code"/>
                                      <asp:BoundField ItemStyle-Width="15%" DataField="item_name" HeaderText="Item" />
                                      <asp:BoundField  DataField="Property1" HeaderText="Property1" Visible="False" />
                                      <asp:BoundField DataField="Property2" HeaderText="Property2" Visible="False" />
                                      <asp:BoundField DataField="Property3" HeaderText="Property3" Visible="False" />
                                      <asp:BoundField DataField="Property4" HeaderText="Property4" Visible="False" />
                                      <asp:BoundField DataField="Property5" HeaderText="Property5" Visible="False" />
                                      <asp:BoundField ItemStyle-Width="3%" DataField="quantity" HeaderText="Quantity"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="unit_code" HeaderText="Unit"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="actual_price" HeaderText="Unit Price"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="CD" HeaderText="CD"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="RD" HeaderText="RD"/>
                                      <asp:BoundField ItemStyle-Width="12%" DataField="SD" HeaderText="SD" DataFormatString="{0:0.00#}"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="VAT" HeaderText="VAT"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="AIT" HeaderText="AIT"/>
                                      <asp:BoundField ItemStyle-Width="9%" DataField="total_price" HeaderText="Total"/>
                                    <%--  <asp:BoundField ItemStyle-Width="16%" DataField="challan_no"/>
                                      <asp:BoundField ItemStyle-Width="10%" DataField="date_challan" DataFormatString="{0:dd/MM/yyyy}" />
                                      <asp:BoundField ItemStyle-Width="18%" DataField="hs_code" HeaderText="HS Code"/>
                                      <asp:BoundField ItemStyle-Width="15%" DataField="item_name" HeaderText="Item" />
                                      <asp:BoundField  DataField="Property1" HeaderText="Property1" Visible="False" />
                                      <asp:BoundField DataField="Property2" HeaderText="Property2" Visible="False" />
                                      <asp:BoundField DataField="Property3" HeaderText="Property3" Visible="False" />
                                      <asp:BoundField DataField="Property4" HeaderText="Property4" Visible="False" />
                                      <asp:BoundField DataField="Property5" HeaderText="Property5" Visible="False" />
                                      <asp:BoundField ItemStyle-Width="3%" DataField="quantity"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="unit_code"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="actual_price"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="CD"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="RD"/>
                                      <asp:BoundField ItemStyle-Width="12%" DataField="SD"  DataFormatString="{0:0.00#}"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="VAT"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="AIT"/>--%>
                                    <%--  <asp:BoundField ItemStyle-Width="3%" DataField="ATV"/>
                                      <asp:BoundField ItemStyle-Width="3%" DataField="TTI"/>--%>
                                     <%-- <asp:BoundField ItemStyle-Width="3%" DataField="total"/>--%>
                                      <%--<asp:BoundField DataField="challan_no" HeaderText="Bill of Entry No" />
                                      <asp:BoundField DataField="date_challan" HeaderText="Bill of Entry Date" />
                                      <asp:BoundField DataField="hs_code" HeaderText="HS Code"/>
                                      <asp:BoundField DataField="item_name" HeaderText="Item" />
                                      <asp:BoundField DataField="Property1" HeaderText="Property1" Visible="False" />
                                      <asp:BoundField DataField="Property2" HeaderText="Property2" Visible="False" />
                                      <asp:BoundField DataField="Property3" HeaderText="Property3" Visible="False" />
                                      <asp:BoundField DataField="Property4" HeaderText="Property4" Visible="False" />
                                      <asp:BoundField DataField="Property5" HeaderText="Property5" Visible="False" />
                                      <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                                      <asp:BoundField DataField="unit_code" HeaderText="Unit" />
                                      <asp:BoundField DataField="purchase_unit_price" HeaderText="Unit Price" />
                                      <asp:BoundField DataField="CD" HeaderText="CD" />
                                      <asp:BoundField DataField="RD" HeaderText="RD" />
                                      <asp:BoundField DataField="SD" HeaderText="SD" />
                                      <asp:BoundField DataField="VAT" HeaderText="VAT" />
                                      <asp:BoundField DataField="AIT" HeaderText="AIT" />
                                      <asp:BoundField DataField="ATV" HeaderText="ATV" />
                                      <asp:BoundField DataField="TTI" HeaderText="TTI" />
                                      <asp:BoundField DataField="total_price" HeaderText="Total" />--%>
                                     <%-- <asp:BoundField DataField="IsSrcTAXDeduct" HeaderText="Src TAX Deducted" />--%>
                                     <%-- <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />--%>
                                      </Columns>
                                  
                                      </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                </div>
                <div class="row">
                    <asp:Label runat="server" >Attach Import Document:</asp:Label>
                   <asp:FileUpload ID="FileUpload1" name="FileUpload1" runat="server" />
                   <asp:Button  runat=server Text="Download" OnClick="File_download"/> 
                </div>
                  <div class="row" style="text-align:right">
                       <asp:Button CssClass="btn-btn" runat=server ID="btnsave" Text="Save" style="background-color:#4CAF50;" OnClick="btnsave_Click"/> 
                   <asp:Button  CssClass="btn-btn" runat=server ID="btnshow" style="background-color:#5CB85C;" Text="Show Report" OnClick="btnshow_Click"/> 

                </div>
                 <div class="row" style="margin-top: 1%">
                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid" id="SupplDutyAdjAppPrint" style="display:block">
          <table style="border:none;width: 100%">
                <tr>
                    <th colspan="2" scope="colgroup" style="text-align: center; font-size: 14px; border:none"
                    </th>
                </tr>
      <tr>
<td> <img src="../../Images/bdlogo.png" style="height:50px;margin-left:80px;margin-top:-100px" ></img></td>
    
  <td>
         <div class="row" style="margin-right:220px">
        <p style="text-align:center">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
        <p style="text-align:center"><b>জাতীয় রাজস্ব বোর্ড</b></p>
        <p style="text-align:right"><b style="border:1px solid #000">মূসক-৭.১</b></p>
        <p style="text-align:center"><b>সম্পূরক শুল্ক সমন্বয়ের আবেদনপত্র</b> </p>
        <p style="text-align:center">[বিধি ৪৫ এর উপ-বিধি (১) দ্রষ্টব্য]</p>
      </div>    
      </td>
    
      </table>

    
      <div class="row" style="margin:10px">
        <p>আবেদনকারী ব্যক্তির নামঃ<asp:Label runat="server" ID="lblpersonName"></asp:Label></p>
        <p>আবেদনকারী ব্যক্তির বিআইএনঃ<asp:Label runat="server" ID="lblbin"></asp:Label></p>
        <p>আবেদনকারী ব্যক্তির ঠিকানাঃ<asp:Label runat="server" ID="lblAddress"></asp:Label> </p>
      </div>
      <div class="row" style="margin:10px">
          <p>আবেদনের তারিখঃ<asp:Label runat="server" ID="lblApplictnDate"></asp:Label></p>
          <p>পণ্য রপ্তানির তারিখঃ <asp:Label runat="server" ID="lblExpoortDate"></asp:Label></p>
      </div>
      <div class="row" style="margin:10px">
         <table class="table table-bordered" style="background:none">
            <tr>
              <td colspan="2" style="height:50px">সমন্বয়যোগ্য সম্পূরক শুল্কের পরিমাণ (টাকায়):<asp:Label runat="server" ID="lblSd"></asp:Label></td>
              <td colspan="2">রপ্তানিকৃত পণ্যে আমদানি পর্যায়ে পরিশোধিত সম্পূরক শুল্কের পরিমাণ (টাকায়):<asp:Label runat="server" ID="lblExportsd"></asp:Label></td>
            </tr>
            <tr>
              <td colspan="4" style="height:30px">আমদানি পণ্যের বিবরণঃ</td>
            </tr>
            <tr>
              <td style="text-align:center">বিল অব এন্ট্রি নম্বর ও তারিখ </td>
              <td style="text-align:center">এইসএস কোড </td>
              <td style="text-align:center">পণ্যের বিবরণ </td>
              <td style="text-align:center">পরিমাণ</td>
            </tr>
            <tr><asp:Label runat="server" ID="lblImportProductDetails" /></tr>
            <tr>
            <td colspan="2">আমদানি দলিলাদি সংযোজনী</td>
            <td colspan="2">
              <p>১। রিলিজ অর্ডারসহ বিল অব এন্ট্রি</p>
              <p>২। শুল্ক কর্মকর্তা কর্তৃক প্রত্যায়িত ইনভয়েস। প্যাকিংলিস্ট</p>
              <p>৩। বিল অব লোডিং/এয়ারওয়ে বিল/ডাকের দলিল</p>
            </td>
            </tr>
            <tr>
              <td colspan="4" style="height:30px">রপ্তানি পণ্যের বিবরণঃ</td>
            </tr>
            <tr>
             <td style="text-align:center">বিল অব এন্ট্রি নম্বর ও তারিখ </td>
             <td style="text-align:center">এইসএস কোড </td>
             <td style="text-align:center">পণ্যের বিবরণ </td>
             <td style="text-align:center">পরিমাণ</td>
            </tr>
            <tr><asp:Label runat="server" ID="lblExportProductDetails" /></tr>
            <tr>
              <td colspan="2">রপ্তানি দলিলাদি সংযোজনী</td>
              <td colspan="2">
                <p>১। বিল অব এক্সপোর্ট; </p>
                <p>২। বিল অব লোডিংম বা এয়ারওয়ে বিল বা রিসিট (প্রযোজ্য ক্ষেত্রে); ও </p>
                <p>৩। বোইদেশিক মুদ্রা প্রত্যাবাসান সনদ (Proceed Realization Certificate- PRC)</p>
              </td>
            </tr>
         </table>
      </div>
      <div class="row" style="margin:10px; border:1px solid #000">
         <p>আমরা ঘোষণা করিতেছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।</p>
         <div class="col-sm-6">
            <p>তারিখঃ .......</p>
         </div>
         <div class="col-sm-6">
             <p style="text-align:center">আবেদনকারীর স্বাক্ষর</p>
             <p style="text-align:center">নামঃ</p>
             <p style="text-align:center">পদবিঃ</p>
         </div>
           <div style="text-align:right;font-size:11px;">
              System Generated (KGCVAT)
         </div>
      </div>
    </div>
</div>
     <uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>