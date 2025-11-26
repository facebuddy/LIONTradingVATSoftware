<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Import_AIT_Refund_4_1, App_Web_znns2ib5" %>
<%@ Register src="~/UserControls/MsgBox.ascx" tagname="MsgBox" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <style type="text/css">
    .print
    {
        background:#ff00ff;
    }
    </style>
    <style media="print">
        .noPrint
        {
            display: none;
        }
        .hiddencol{
            display:none;
        }
        @media print
        {
            body
            {
                
            }
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
            border: 1px solid gray;
        }
    </style>
    <style>
        .style1
        {
        }
        .style2
        {
            height: 25px;
        }
        hr
        {
            background:#000000;
        }

        table.topborder { border:none; width:100%; font-size:12px;}
        table.topborder tr {border-top:1px solid black;}

        </style>
         <script type = "text/javascript">

              function PrintPanel() {
                 var panel = document.getElementById("<%=printReport.ClientID %>");
                  var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
                  //printWindow.document.write('<html><head><title>আমদানি পর্যায়ে পরিশোধিত অগ্রীম কর ফেরত প্রাপ্তির আবেদন  (মূসক-৪.১)</title>');
                  printWindow.document.write('<html><head><title></title>');
                 printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
                  //            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
                 printWindow.document.write('<style> td, tr, table{border-collapse:collapse;} table{width:100%}</style>');
                 printWindow.document.write('<style>table.topborder { border:none; width:100%; font-size:12px;} table.topborder tr {border-top:1px solid black;}</style>'); //sabbir 15/2/20
                 printWindow.document.write('</head>');
                  //printWindow.document.write('<body>');
                 printWindow.document.write('<body style="margin: 10px; font-size:x-small;">');
                 printWindow.document.write(panel.innerHTML);
                 printWindow.document.write('</body>');
                 printWindow.document.write('</html>');
                 printWindow.document.close();
                 setTimeout(function () {
                     printWindow.print();
                 }, 500);
                 return false;  
             }  
    </script>
    <script type="text/javascript">
        function addVat(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAdvancePaymentTax.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[5].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[5].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=txtAdvancePaymentTax.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
            document.getElementById("<%=txtAdvancePaymentTax.ClientID%>").style.background = "#cfc";


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container-fluid">
        <div class="panel-group">
        <div class="panel panel-primary">
           <div class="panel-heading" style="text-align:center;font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">আমদানি পর্যায়ে পরিশোধিত অগ্রীম কর ফেরত</div>
                <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
                               <div class="row hiddencol" style="background-color:#E0EBF5">
                                <div class="col-sm-4">
                                    <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                                     <asp:Literal ID="lblOrgName" runat="server"></asp:Literal>
                                </div>
                                <div class="col-sm-6">
                                     <asp:Label class="col-sm-2" ID="Label2" runat="server" Text="Address:"></asp:Label>
                                     <asp:Literal ID="lblOrgAddress" runat="server"></asp:Literal>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Label ID="Label8" runat="server" Text="BIN:"></asp:Label>
                                    <asp:Label ID="lblOrgTIN" runat="server"></asp:Label>
                                </div>
                                <div class="col-sm-3 col-xs-3 col-lg-2">
                                    <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                                    <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                                </div>
                           </div>
                               <div class="row" style="margin-top:1%">
                          
                                 <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                           <asp:Label class="col-sm-4 control-label" ID="Label11" runat="server" style="text-align:right;"><span class="required"> * </span>Date From:</asp:Label>
                                       <div class="col-sm-8">
                                          <asp:TextBox ID="dtpDateFrom" runat="server" class="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                         <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom"/>
                                         <asp:Label ID="lblfromDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                               
                                      </div>
                                   </div>
                                </div>                       
                                 <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                           <asp:Label class="col-sm-4 control-label" ID="Label12" runat="server" style="text-align:right;"><span class="required"> * </span>Date To:</asp:Label>
                                       <div class="col-sm-8">
                                         <asp:TextBox ID="dtpDateTo" runat="server"  class="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                         <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo"/>
                                        <asp:Label ID="lblToDate" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                               
                                      </div>
                                   </div>
                                </div>                      
                                 <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                       <asp:Label class="col-sm-4 control-label" ID="Label9" runat="server" style="text-align:right;">Bill of Entry No:</asp:Label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="drpBillofEntryNo" runat="server" onselectedindexchanged="drpBillofEntryNo_SelectedIndexChanged" CssClass="form-control select2"  AutoPostBack="True" >
                                            </asp:DropDownList>                               
                                         </div>
                                    </div>
                                 </div>
                               </div>
                               <div class="row">                      
                                
                                <div class="col-sm-4">
                                  <div class="form-group form-group-sm">
                                       <asp:Label class="col-sm-4 control-label" ID="Label10" runat="server" style="text-align:right;">Bill of Entry Date:</asp:Label>
                                        <div class="col-sm-8">
                                           <asp:TextBox ID="lblBillofEntryDate" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy">                             
                                          </asp:TextBox>
                                       <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="lblBillofEntryDate"/>                           
                                         </div>
                                  </div>
                               </div>   
                                <div class="col-sm-4">
                                  <div class="form-group form-group-sm">
                                       <asp:Label class="col-sm-4 control-label" ID="Label3" runat="server" style="text-align:right;">Supplier Country:</asp:Label>
                                        <div class="col-sm-8">
                                           <asp:TextBox ID="lblSupplierCountry" class="form-control"  runat="server">
                                           </asp:TextBox>                         
                                         </div>
                                  </div>
                               </div>    
                                <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                       <asp:Label class="col-sm-4 control-label" ID="Label13" runat="server" style="text-align:right;">Tax Payment Date:</asp:Label>
                                        <div class="col-sm-8">
                                            <asp:TextBox runat=server ID="txtTaxPaymentDate" class="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTaxPaymentDate"/>                           
                                         </div>
                                    </div>
                                 </div>
                           </div>
                               <div class="row">

                               
                                 <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                       <asp:Label class="col-sm-4 control-label" ID="Label14" runat="server" style="text-align:right;">Release Order No:</asp:Label>
                                        <div class="col-sm-8">
                                           <asp:TextBox runat=server ID="txtReleaseOrderNo" class="form-control"></asp:TextBox>                         
                                         </div>
                                    </div>
                                 </div>
                                 <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                       <asp:Label class="col-sm-4 control-label" ID="Label4" runat="server" style="text-align:right;">Release Order Date:</asp:Label>
                                        <div class="col-sm-8">
                                          <asp:TextBox runat=server ID="txtReleaseOrderDate" class="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                      <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="txtReleaseOrderDate"/>                         
                                         </div>
                                    </div>
                                 </div>
                                     <div class="col-sm-4">
                                   <div class="form-group form-group-sm">
                                       <asp:Label class="col-sm-4 control-label" ID="Label5" runat="server" style="text-align:right;"><span class="required"> * </span>Advance Payment:</asp:Label>
                                    <div class="col-sm-8">
                                          <asp:TextBox runat=server ID="txtAdvancePaymentTax" class="form-control"></asp:TextBox>                               
                                      </div>
                                    </div>
                               </div> 
                            </div>   
                               <div class="row">
                                   <div class="col-sm-4">
                                      <div class="form-group form-group-sm">
                                       <asp:Label class="col-sm-4 control-label" ID="Label21" runat="server" style="text-align:right;"><span class="required"> * </span>Adjustment Tax Period:</asp:Label>
                                        <div class="col-sm-8">
                                          <asp:DropDownList ID="drpsubmissionDate"  CssClass="form-control select2" runat="server" />
                               
                                         </div>
                                        </div>
                                      </div> 
                                   <div class="col-sm-4"> 
                                   </div>
                               <div class="col-sm-4">                              
                               <asp:Button ID="btnSearch" runat="server" style="background-color:#3B7CB5; float:right" OnClick="btnSearch_OnClick" Text="Search" CssClass="btn-btn"/>                               
                              <asp:Button runat="server" ID="reportBTN" style="background-color:#5CB85C;float:right;" Text="Show Report" CssClass="btn-btn" OnClick = "reportBTN_OnClick" />
                              <asp:Button runat="server" ID="saveBTN" style="background-color:#4CAF50;float:right;" Text="Save" CssClass="btn-btn" OnClick="saveBTN_OnClick" />
                      
                              </div> 
                        
                              </div>                               
                        
                        
                                
                    
                    
                    
                    <div class="col-sm-4" style="padding:0px;">
                                    <asp:Label ID="lblProp1" runat="server" Text="Property 1:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpProp1" runat="server" AutoPostBack="True" 
                                          onselectedindexchanged="drpProp1_SelectedIndexChanged" Visible="False"   Width="100px">
                            </asp:DropDownList>
                            <asp:Label ID="lblProp2" runat="server" Text="Property 2" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpProp2" runat="server" AutoPostBack="True" 
                                          onselectedindexchanged="drpProp2_SelectedIndexChanged" Visible="False"  Width="100px">
                             </asp:DropDownList>
                             <asp:Label ID="lblProp3" runat="server" Text="Property 3" Visible="False"></asp:Label>
                             <asp:DropDownList ID="drpProp3" runat="server" AutoPostBack="True" 
                                          onselectedindexchanged="drpProp3_SelectedIndexChanged" Visible="False" 
                                          Width="100px">
                                      </asp:DropDownList>
                             <asp:Label ID="lblProp4" runat="server" Text="Property 4" Visible="False"></asp:Label>
                             <asp:DropDownList ID="drpProp4" runat="server" AutoPostBack="True" 
                                          onselectedindexchanged="drpProp4_SelectedIndexChanged" Visible="False" 
                                          Width="100px">
                                      </asp:DropDownList>
                            <asp:Label ID="lblProp5" runat="server" Text="Property 5" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpProp5" runat="server" AutoPostBack="True" 
                                          onselectedindexchanged="drpProp5_SelectedIndexChanged" Visible="False" Width="100px">
                            </asp:DropDownList>
                    
                                </div>
                           </div>
                           <div class="row" style="margin-top:2%">
                             <div class="panel panel-primary">
                                <div class="panel-body" style="padding-top:0px; padding-bottom:0px">
                                    <div class="container-fluid">
                                        <div class="row" style="margin-top:1%">
                                        <div>
                                        <div id="table" runat="server" visible="false">
                                           <table cellspacing="0" cellpadding = "0" rules="all" border="1" id="tblHeader" 
                                                 style="font-family:Arial;font-size:10pt;width:100%;color:white;
                                                 border-collapse:collapse;height:100%;">
                                            <tr>
                                               <td style="width:5.3%"></td>
                                               <td style="width:5.1%"></td>
                                               <td style="width:5%"></td>
                                               <td style="width:3.55%"></td>
                                                <td style="width:3.55%"></td>
                                                 <td style="width:3.55%"></td>
                                               <td style="width:5.6%;border-right:1px solid black"></td>
                                               <td style="width:4.3%;text-align:center;border:1px solid black;border-left:1px solid black;visibility:hidden;"><asp:CheckBox ID="chkCD" runat="server" OnCheckedChanged="chkCD_OnClick" AutoPostBack="true" /></td>
                                               <td style="width:3.4%;text-align:center;border:1px solid black;visibility:hidden;"><asp:CheckBox ID="chkRD" runat="server" OnCheckedChanged="chkCD_OnClick" AutoPostBack="true"/></td>
                                               <td style="width:3.1%;text-align:center;border:1px solid black;visibility:hidden;">   <asp:CheckBox ID="chkSD" runat="server" OnCheckedChanged="chkCD_OnClick" AutoPostBack="true"/></td>
                                               <td style="width:4.4%;text-align:center;border:1px solid black;visibility:hidden;"> <asp:CheckBox ID="chkVAT" runat="server" OnCheckedChanged="chkCD_OnClick" AutoPostBack="true"/></td>
                                               <td style="width:2.2%;visibility:hidden;"></td>
                                                <td style="width:2.5%;text-align:center;border:1px solid black"> <asp:CheckBox ID="chkAT" runat="server" OnCheckedChanged="chkCD_OnClick" AutoPostBack="true" /></td>
                                               <td style="width:4.4%;text-align:center;border:1px solid black;visibility:hidden;"> <asp:CheckBox ID="chkAIT" runat="server" OnCheckedChanged="chkCD_OnClick" AutoPostBack="true"/></td>
                                               <td style="width:3%;text-align:center;border:1px solid black;visibility:hidden;"> <asp:CheckBox ID="chkATV" runat="server" OnCheckedChanged="chkCD_OnClick" AutoPostBack="true"/></td>
                                               <td style="width:2.7%;text-align:center;border:1px solid black;visibility:hidden;"> <asp:CheckBox ID="chkTTI" runat="server" OnCheckedChanged="chkCD_OnClick" AutoPostBack="true" /></td>
                                       
                                               <td style="width:12%;text-align:center;"></td>
                                                <td style="width:59%"></td>
                                               <td style="width:9%"></td>
                                               <td style="width:2%"></td>
                                                <td style="width:2%"></td>
                                               <td style="width:2%"></td>
                                               <td style="width:2%"></td>
                                               <td style="width:8%"></td>
                                               <td></td>
                                            </tr>
                                        </table>
                                        </div>
                                        <div>
                                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
                                                DataKeyNames="RowNo" onselectedindexchanged="gvItem_SelectedIndexChanged" 
                                                Width="100%" CssClass="sGrid" onprerender="gvItem_PreRender" onrowdatabound="gvItem_RowDataBound"  
                                                onrowdeleting="gvItem_RowDeleting" ShowHeaderWhenEmpty="True" 
                                                BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3" CellSpacing="2">
                                       
                                          <Columns>
                                          <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:HiddenField ID="challan_id" Value='<%# Eval("challan_id") %>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                              <%--<asp:BoundField DataField="boeno" HeaderText="BoENo" ItemStyle-Width="5%" />
                                              <asp:BoundField DataField="item" HeaderText="Item" ItemStyle-Width="5.19%" />
                                              <asp:BoundField DataField="quantity" HeaderText="Quantity" ItemStyle-Width="5%"/>
                                              <asp:BoundField DataField="unit" HeaderText="Unit" ItemStyle-Width="3.55%"/>
                                              <asp:BoundField DataField="unit_price" HeaderText="Unit Price" ItemStyle-Width="6%"/>
                                              <asp:BoundField DataField="cd" HeaderText="CD" ItemStyle-Width="4.6%"/>
                                              <asp:BoundField DataField="rd" HeaderText="RD" ItemStyle-Width="3.55%"/>
                                              <asp:BoundField DataField="sd" HeaderText="SD" ItemStyle-Width="3%"/>
                                              <asp:BoundField DataField="vat" HeaderText="VAT" ItemStyle-Width="4.5%"/>                                                                           
                                               <asp:BoundField DataField="at" HeaderText="AT" ItemStyle-Width="2.8%"/>
                                              <asp:BoundField DataField="ait" HeaderText="AIT" ItemStyle-Width="4.5%"/>
                                              <asp:BoundField DataField="atv" HeaderText="ATV" ItemStyle-Width="3.5%" Visible="false" />
                                              <asp:BoundField DataField="tti" HeaderText="TTI" ItemStyle-Width="2.8%" Visible="false" />
                                              <asp:BoundField DataField="sub_total" HeaderText="Assessable Value" ItemStyle-Width="12%"/>
                                              <asp:BoundField DataField="other_cost" HeaderText="Penalties" ItemStyle-Width="5%"/>
                                              <asp:BoundField DataField="document_fee" HeaderText="Document Fee" ItemStyle-Width="9%"/>
                                              <asp:BoundField DataField="country" HeaderText="Country" ItemStyle-Width="2%"/>
                                              <asp:BoundField DataField="psi" HeaderText="PSI" ItemStyle-Width="2%"/>
                                              <asp:BoundField DataField="cnf_commission" HeaderText="C&F Commission" ItemStyle-Width="2%"/>
                                              <asp:BoundField DataField="cnf_vat" HeaderText="C&F Vat" ItemStyle-Width="2%"/>
                                              <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-Width="8%"/>
                                              <asp:TemplateField>--%>
                                              <asp:BoundField DataField="boeno" HeaderText="BoENo"/>
                                              <asp:BoundField DataField="item" HeaderText="Item"/>
                                              <asp:BoundField DataField="quantity" HeaderText="Quantity"/>
                                              <asp:BoundField DataField="unit" HeaderText="Unit"/>
                                              <asp:BoundField DataField="unit_price" HeaderText="Unit Price"/>
                                              <asp:BoundField DataField="cd" HeaderText="CD"/>
                                              <asp:BoundField DataField="rd" HeaderText="RD"/>
                                              <asp:BoundField DataField="sd" HeaderText="SD"/>
                                              <asp:BoundField DataField="vat" HeaderText="VAT"/>                                                                           
                                               <asp:BoundField DataField="at" HeaderText="AT"/>
                                              <asp:BoundField DataField="ait" HeaderText="AIT"/>
                                              <asp:BoundField DataField="atv" HeaderText="ATV" Visible="false" />
                                              <asp:BoundField DataField="tti" HeaderText="TTI" Visible="false" />
                                              <asp:BoundField DataField="sub_total" HeaderText="Assessable Value"/>
                                              <asp:BoundField DataField="other_cost" HeaderText="Penalties" />
                                              <asp:BoundField DataField="document_fee" HeaderText="Document Fee"/>
                                              <asp:BoundField DataField="country" HeaderText="Country" />
                                              <asp:BoundField DataField="psi" HeaderText="PSI" />
                                              <asp:BoundField DataField="cnf_commission" HeaderText="C&F Commission" />
                                              <asp:BoundField DataField="cnf_vat" HeaderText="C&F Vat" />
                                              <asp:BoundField DataField="total" HeaderText="Total"/>
                                              <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:HiddenField ID="item_id" Value='<%# Eval("item_id") %>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:HiddenField ID="RowNo" Value='<%# Eval("RowNo") %>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                              </Columns>
                                              <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                              <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" 
                                                ForeColor="White" />
                                              <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                              <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" 
                                                ForeColor="#8C4510" />
                                              <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                                              </asp:GridView>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                           </div>
                        </div>
                    </div>
                   </div>
    <div runat="server" id="printReport"  style="width:100%;height:auto;font-family:Nikosh" visible= "true">
            <div class="row">                
                <div style="font-size: 14px">
                    
                    <p style="text-align: right; padding: 5px;">
                        
                       <%-- <b style="border: 1px solid gray; margin-right: 17px;">মূসক-৪.১</b>--%>
                    </p>
                    <p style="text-align: center; font-size: 12px; margin: 2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                    <p style="text-align: center; font-size: 12px; margin: 2px;">জাতীয় রাজস্ব বোর্ড</p>
                    <p style="text-align:center"> আমদানি পর্যায়ে পরিশোধিত অগ্রীম কর ফেরত</p>
                  
                </div>

            </div>

            
        <%--<div class="row">
             <p style="border-top:1px solid black;margin-top:25px">আবেদনকারীর নাম <b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgNameRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">নৈমিত্তিক ব্যবসায় সনাক্তকরণ সংখ্যা<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgBINRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">ঠিকানা<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgAddressRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">বিল অব এন্ট্রি নম্বর<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblBillofEntryNoRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">বিল অব এন্ট্রির তারিখ<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblBillofEntryDateRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">যে দেশ হইতে পণ্য আমদানি করা হয়েছে<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblSupplierCountryRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">আমদানিকৃত পণ্যের বিবরণ<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblItemRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">পরিশোধিত অগ্রিম মূসক<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblAdvanceTaxRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">মূসক পরিশোধের তারিখ<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblAdvanceTaxPaymentDateRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px">রিলিজ অর্ডারের নম্বর<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblReleaseOrderNoRP" /></p>
            <p style="border-top:1px solid black;border-bottom:1px solid black;margin-top:5px">রিলিজ অর্ডারের তারিখ<b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblReleaseOrderDateRP" /></p>
            <p style="border-top:1px solid black;margin-top:20px"></p>
            <p style="margin-top:5px">ঘোষণা</p>
            <p style="margin-top:5px">আমি ঘোষণা করিতেছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।</p>
            <p style="margin-top:5px">নাম<b style="margin-left: 4.55%;">:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblEmployeeName" /></p>
            <p style="margin-top:5px">পদবি <b style="margin-left: 3.59%;">:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblEmployeeDesignation" /></p>
            <p style="margin-top:5px">স্বাক্ষর ও সীল   &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</p>
        </div>--%>

        
<%--        <div class="row" style="font-size:12px">
             <p style="border-top:1px solid black;margin-top:25px"><span style="margin-right: 18.9em;">আবেদনকারীর নাম</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgNameRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px"><span style="margin-right: 11.75em;">নৈমিত্তিক ব্যবসায় সনাক্তকরণ সংখ্যা</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgBINRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px"><span style="margin-right: 24em;">ঠিকানা</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgAddressRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px"><span style="margin-right: 19.05em;">বিল অব এন্ট্রি নম্বর</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblBillofEntryNoRP" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            
                
                    তারিখ:<asp:Label style="font-weight:bold" runat="server" ID="lblBillofEntryDateRP" />
            </p>
            <p style="border-top:1px solid black;margin-top:5px"><span style="margin-right: 9.6em;">যে দেশ হইতে পণ্য আমদানি করা হইয়াছে</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblSupplierCountryRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px"><span style="margin-right: 15.5em;">আমদানিকৃত পণ্যের বিবরণ</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblItemRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px"><span style="margin-right: 12em;">পরিশোধিত আগাম মূসকের পরিমাণ</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblAdvanceTaxRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px"><span style="margin-right: 14.5em;">আগাম কর পরিশোধের তারিখ</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblAdvanceTaxPaymentDateRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px"><span style="margin-right: 18em;">রিলিজ অর্ডারের নম্বর</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblReleaseOrderNoRP" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                তারিখ:<asp:Label style="font-weight:bold" runat="server" ID="lblReleaseOrderDateRP" />
            </p>            
            <p style="border-top:1px solid black;margin-top:5px">ঘোষণা</p>
            <p style="margin-top:5px">আমি ঘোষণা করিতেছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।</p>
            <p style="margin-top:5px">নাম<b style="margin-left: 7%;">:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblEmployeeName" /></p>
            <p style="margin-top:5px">পদবি <b style="margin-left: 6%;">:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblEmployeeDesignation" /></p>
            <p style="margin-top:5px">স্বাক্ষর ও সীল   &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</p>
        </div>--%>

        <%-- <div class="col-sm-4" style="padding:0px"> </div> --%>


         <%-- <div class="row" style="font-size:12px">
            <p style="border-top:1px solid black;margin-top:25px; margin-left:0px;"><span style="margin-right: 18.9em;">আবেদনকারীর নাম</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgNameRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;"><span style="margin-right: 11.75em;">নৈমিত্তিক ব্যবসায় সনাক্তকরণ সংখ্যা</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgBINRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;"><span style="margin-right: 24em;">ঠিকানা</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblOrgAddressRP" /></p>

            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;"><div class="col-sm-4" style="padding-left:0px;display: inline-block;" ><span>বিল অব এন্ট্রি নম্বর</span><b style="padding-left: 50px;">: </b><asp:Label style="font-weight:bold;" runat="server" ID="lblBillofEntryNoRP" /></div> <span>তারিখ:</span><asp:Label style="font-weight:bold" runat="server" ID="lblBillofEntryDateRP" />
            </p>          

            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;"><span style="margin-right: 9.6em;">যে দেশ হইতে পণ্য আমদানি করা হইয়াছে</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblSupplierCountryRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;"><span style="margin-right: 15.5em;">আমদানিকৃত পণ্যের বিবরণ</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblItemRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;"><span style="margin-right: 12em;">পরিশোধিত আগাম মূসকের পরিমাণ</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblAdvanceTaxRP" /></p>
            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;"><span style="margin-right: 14.5em;">আগাম কর পরিশোধের তারিখ</span><b>:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblAdvanceTaxPaymentDateRP" /></p>
            
            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;"><div class="col-sm-4"  style="padding-left:0px;display: inline-block;" ><span>রিলিজ অর্ডারের নম্বর</span><b style="padding-left: 50px;">: </b><asp:Label style="font-weight:bold;" runat="server" ID="lblReleaseOrderNoRP" /></div><span>তারিখ:</span><asp:Label style="font-weight:bold" runat="server" ID="lblReleaseOrderDateRP" />
            </p>  
            
             
                        
            <p style="border-top:1px solid black;margin-top:5px; margin-left:0px;">ঘোষণা</p>
            <p style="margin-top:5px; margin-left:0px;">আমি ঘোষণা করিতেছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।</p>
            <p style="margin-top:5px; margin-left:0px;">নাম<b style="margin-left: 7%;">:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblEmployeeName" /></p>
            <p style="margin-top:5px; margin-left:0px;">পদবি <b style="margin-left: 6%;">:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblEmployeeDesignation" /></p>
            <p style="margin-top:5px; margin-left:0px;">স্বাক্ষর ও সীল   &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</p>
        </div>--%>



        <%--<table style="border:none; width:100%; font-size:12px;">--%>
        <table class="topborder">
            <tr style="border-top:1px solid black;">
                <td>আবেদনকারীর নাম</td>
                <td> : </td>
                <td colspan="2"><asp:Label style="font-weight:bold" runat="server" ID="lblOrgNameRP" /></td>
              
            </tr>

            <tr style="border-top:1px solid black;">
                <td>নৈমিত্তিক ব্যবসায় সনাক্তকরণ সংখ্যা</td>
                <td> : </td>
                <td colspan="2"><asp:Label style="font-weight:bold" runat="server" ID="lblOrgBINRP" /></td>

            </tr>

            <tr style="border-top:1px solid black;">
                <td>ঠিকানা</td>
                <td> : </td>
                <td colspan="2"><asp:Label style="font-weight:bold" runat="server" ID="lblOrgAddressRP" /></td>


            </tr>

            <tr style="border-top:1px solid black;">
                <td>বিল অব এন্ট্রি নম্বর</td>
                <td> : </td>
                <td><asp:Label style="font-weight:bold;" runat="server" ID="lblBillofEntryNoRP" /></td>

                <td>তারিখ: <asp:Label style="font-weight:bold" runat="server" ID="lblBillofEntryDateRP" /></td>

            </tr>

            <tr style="border-top:1px solid black;">
                <td>যে দেশ হইতে পণ্য আমদানি করা হইয়াছে</td>
                <td> : </td>
                <td colspan="2"><asp:Label style="font-weight:bold" runat="server" ID="lblSupplierCountryRP" /></td>            

            </tr>

            <tr style="border-top:1px solid black;">
                <td>আমদানিকৃত পণ্যের বিবরণ</td>
                <td> : </td>
                <td colspan="2"><asp:Label style="font-weight:bold" runat="server" ID="lblItemRP" /></td>

                

            </tr>

            <tr style="border-top:1px solid black;">
                <td>পরিশোধিত আগাম মূসকের পরিমাণ</td>
                <td> : </td>
                <td colspan="2"><asp:Label style="font-weight:bold" runat="server" ID="lblAdvanceTaxRP" /></td>


            </tr>

            <tr style="border-top:1px solid black;">
                <td>আগাম কর পরিশোধের তারিখ</td>
                <td> : </td>
                <td colspan="2"><asp:Label style="font-weight:bold" runat="server" ID="lblAdvanceTaxPaymentDateRP" /></td>                

            </tr>


            <tr style="border-top:1px solid black;">
                <td>রিলিজ অর্ডারের নম্বর</td>
                <td> : </td>
                <td><asp:Label style="font-weight:bold;" runat="server" ID="lblReleaseOrderNoRP" /></td>

                <td>তারিখ: <asp:Label style="font-weight:bold" runat="server" ID="lblReleaseOrderDateRP" /></td>

            </tr>

            
            
            <tr style="border-top:1px solid black;">

            <td colspan="4">ঘোষণা
                <p style="margin-top:5px; margin-left:0px;">আমি ঘোষণা করিতেছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বোতভাবে সম্পূর্ণ, সত্য ও নির্ভুল।</p>
                <p style="margin-top:5px; margin-left:0px;">নাম<b style="margin-left: 48px;">:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblEmployeeName" /></p>
                <p style="margin-top:5px; margin-left:0px;">পদবি <b style="margin-left:40px;">:</b> &nbsp<asp:Label style="font-weight:bold" runat="server" ID="lblEmployeeDesignation" /></p>
                <p style="margin-top:5px; margin-left:0px;">স্বাক্ষর ও সীল   &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</p>
            </td>
               
            </tr>

        </table>

          <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>

    </div>
    <asp:Button runat="server" style="float:right;" CssClass="btn btn-info" Text="Print" ID="btnPrint" Visible= "true" OnClientClick="return PrintPanel()" />
    </div>
    <uc2:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>
