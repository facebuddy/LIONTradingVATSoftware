<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="VDSIssue.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.VDSIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc2" TagName="MsgBoxs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
 
    <style type="text/css">
        .style1 {
            text-align: right;
        }
        .hiddencol{
            display:none;
        }
    </style>
    <script type="text/javascript">
        $(function () {
           // $("#txtFormDate").datepicker();
        });

        function addVat(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=lblAmount.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvChallanItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[8].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[8].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=lblAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(8);
            document.getElementById("<%=lblAmount.ClientID%>").style.background = "#cfc";


        }

        function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvChallanItem.ClientID%>");
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
        
        function SelectAllCheckboxesSpecificParty(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=grdparty.ClientID%>");
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


        function clearChkBox(radioBtnNonChallan) {

            var isRadioBtnNonChallan = radioBtnNonChallan.checked;

            var jsGvItem = document.getElementById("<%=gvChallanItem.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    if (items[i].checked == isRadioBtnNonChallan) {
                        items[i].click();
                    }
                }
            }

        }

        function calledFn() {
            alert("code fired");
        }

    </script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=report.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            //            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head>');
            printWindow.document.write('<body style="margin: 50px;font-family: "Times New Roman", Times, serif; font-size:16px">');
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold;">
                            <%--  উৎসে মূসক কর্তনের প্রত্যয়ন পত্র (মূসক-১২খ)--%>
                            উৎসে কর কর্তন সনদ পত্র (মূসক-৬.৬)
                        </div>
                        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                            <div class="row" style="background-color: #FFD9C3;">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Name :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Literal ID="lblOrgName" runat="server"></asp:Literal>
                                            <asp:Label runat="server" ID="orgVDS" Visible="false" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Address :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Literal ID="lblOrgAddress" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. BIN :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpBranchName" runat="server" CssClass="form-control" AutoPostBack="True"
                                                OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Party Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpParty" runat="server" CssClass="form-control select2" AutoPostBack="True"
                                                OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtPartyName" runat="server" Visible="False" CssClass="present-address-tb"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Party Address :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox class="form-control" ID="txtAddress" runat="server" placeholder="address here"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Party BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtPartyBIN" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtForeignAmount_FilteredTextBoxExtender1"
                                        runat="server" Enabled="True" TargetControlID="txtPartyBIN" ValidChars="0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">VDS Certificate No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtSTDCertificate" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            <asp:HiddenField runat="server" ID="hdBookId" />
                                            <asp:HiddenField runat="server" ID="hdPageNo" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Certificate Issue Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txtCertificateDate" CssClass="form-control" Format="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtCertificateDate" />
                                            <asp:Label runat="server" ID="lblAmount" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Ref.Challan No ৬.৩ :</label>
                                        <div class="col-sm-7">
                                            <%--<asp:TextBox runat="server" ID="txtChallanNumber" class="form-control" OnTextChanged="txtChallanNumber_TextChanged" AutoPostBack="true"></asp:TextBox>--%>
                                        
                                        <asp:DropDownList runat="server" ID="drpChallanNumber" class="form-control" OnSelectedIndexChanged="drpChallanNumber_OnSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <asp:TextBox runat="server" ID="trchallanID" CssClass="hiddencol"></asp:TextBox>
                                             <asp:TextBox runat="server" ID="trchallanDate" CssClass="hiddencol"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <fieldset class="scheduler-border">
                                        <legend title="" class="scheduler-border">কর মেয়াদ</legend>
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label2" runat="server" Text="Date From :" CssClass="col-sm-5 control-label text-right"></asp:Label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="dtpDateFrom" runat="server" class="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom" />
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label1" runat="server" Text="Date To :" class="col-sm-5 control-label text-right"></asp:Label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="dtpDateTo" runat="server" class="form-control" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                                            </div>
                                        </div>
                                          <div class="col-sm-4">
                                            <asp:Label ID="Label4" runat="server" Text="Party Name :" class="col-sm-5 control-label text-right"></asp:Label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpPartySearch" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpPartySearch_SelectedIndexChanged"> </asp:DropDownList>
                                                
                                            </div>
                                        </div>
                                         <div class="col-sm-4">
                                            <asp:Label ID="Label5" runat="server" Text="VDS Certificate No :" class="col-sm-5 control-label text-right"></asp:Label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpCerficateNo" runat="server"  class="form-control"></asp:DropDownList>
                                                
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="row" style="text-align:right;margin-top:10px;">
                                <div class="col-md-12">
                                    <asp:Button ID="btnSearch" runat="server" Style="background-color:#337AB7;float: right" OnClick="btnSearch_Click" Text="Search" CssClass="btn-btn" />
                                    <asp:Button ID="btnShow" runat="server" Style="background-color:#5CB85C;float: right" OnClick="btnShow_Click" Text="Show Report" CssClass="btn-btn" />
                                    <asp:Button ID="btnSave" runat="server" Style="background-color:#4CAF50;float: right" OnClick="btnSave_Click" Text="Save" CssClass="btn-btn" />
                               <asp:TextBox CssClass="btn-btn" ID="precisionTxtBox" runat="server" placeholder="Precision" style="width:80px;float: right"></asp:TextBox>
                                     </div>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="precisionTxtBox" runat="server"
                                ErrorMessage="Precision has to be a number between 0 to 12"
                                ForeColor="Red"
                                ValidationExpression="\d+">
                            </asp:RegularExpressionValidator> 
                            </div>
                                </div>
                           <div class="row" style="margin-top: 1%; padding: 0%">
                                <asp:GridView ID="grdparty" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="100%"
                                    HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="YellowGreen">
                                  
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderTemplate>
                                              <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecificParty(this)"
                                                    ToolTip="Check to Select All Item" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="challan_no" HeaderText="Challan No"/>
                                         <asp:BoundField DataField="trns_treasury_detail_id"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                                        <asp:BoundField DataField="challan_date" HeaderText="Challan Date"/>
                                        <asp:BoundField DataField="item_name" HeaderText="Item"/>
                                        <asp:BoundField DataField="party_id"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount" DataFormatString="{0:#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField DataField="total_vat" HeaderText="Total Vat" DataFormatString="{0:#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField DataField="vds_amount" HeaderText="VDS Amount" DataFormatString="{0:#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField DataField="trdate"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                                            
                                    </Columns>
                                </asp:GridView>

                            </div>
                            <div class="row hiddencol" style="margin-top: 1%; padding: 0%">
         <%--                       <div style="background-color: Green; height: 30px; width: 100%; margin: 0; padding: 0">
                                    <table cellspacing="0" cellpadding="0" rules="all" border="1" id="tblHeader" style="font-family: Arial; font-size: 10pt; width: 100%; color: white; border-collapse: collapse; height: 100%;">
                                        <tr>
                                            <th>
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)"
                                                    ToolTip="Check to Select All Item" />
                                            </th>
                                            <th style="width: 15%; text-align: center">Challan No
                                            </th>
                                            <th style="width: 10%; text-align: center">Challan Date
                                            </th>
                                            <th style="width: 20%; text-align: center">Item
                                            </th>
                                            <th style="width: 15%; text-align: center">Party Name & Address
                                            </th>
                                            <th style="width: 10%; text-align: center">Party BIN
                                            </th>
                                            <th style="width: 10%; text-align: center">Total Amount
                                            </th>
                                            <th style="width: 10%; text-align: center">Total Vat
                                            </th>
                                            <th style="width: 10%; text-align: center">VDS Amount
                                            </th>
                                        </tr>
                                    </table>
                                </div>--%>
                                <asp:GridView ID="gvChallanItem" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="100%"
                                    HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="YellowGreen" OnRowDataBound="gvChallan_RowDataBound">
                                  
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderTemplate>
                                              <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)"
                                                    ToolTip="Check to Select All Item" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="challan_no" HeaderText="Challan No"/>
                                         <asp:BoundField DataField="challan_id"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                                        <asp:BoundField DataField="challan_date" HeaderText="Challan Date"/>
                                        <asp:BoundField DataField="item_name" HeaderText="Item"/>
                                        <asp:BoundField DataField="party_id"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                                        <asp:BoundField DataField="party" HeaderText="Party Name & Address"/>
                                        <asp:BoundField DataField="party_bin" HeaderText="Party BIN"/>
                                        <asp:BoundField DataField="total_amount" HeaderText="Total Amount" DataFormatString="{0:#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField DataField="total_vat" HeaderText="Total Vat" DataFormatString="{0:#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                        <asp:BoundField DataField="vds_amount" HeaderText="VDS Amount" DataFormatString="{0:#0.00}" ItemStyle-HorizontalAlign="Right"/>
                                         <asp:BoundField DataField="trns_treasury_detail_id"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"/>
                                        <asp:TemplateField HeaderText="HS Code" >
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HSCode" Value='<%# Eval("hs_code") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TR Challan" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="TRChallan" Value='<%# Eval("tr_challan_no") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="Remarks" Value='<%# Eval("remarks") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div runat="server" class="container-fluid" id="report" visible="true" style="font-family:Nikosh">
                        
                        <div style="font-size: 16px">
                            <p style="text-align: right; padding: 5px;">
                                <b style="border: 1px solid gray; margin-right: 17px;">মূসক-৬.৬</b>
                            </p>
                            <p style="text-align: center; font-size: 12px; margin: 2px;">গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</p>
                            <p style="text-align: center; font-size: 12px; margin: 2px;">জাতীয় রাজস্ব বোর্ড,ঢাকা</p>
                            <p style="text-align: center; font-size: 12px; margin: 2px;"><strong>উৎসে কর কর্তন সনদ পত্র</strong></p>
                            <p style="text-align: center; font-size: 12px; margin: 2px;">[বিধি ৪০ এর উপ-বিধি (১) এর দফা (চ) দ্রষ্টব্য]</p>
                        </div>


                        <div style="font-size:12px">
                            <div class="row" style="margin-top: 1%; font-size: 16px">
                            <table style="border: none; width: 100%">
                                <tr>
                                    <th colspan="2" scope="colgroup" style="text-align: center; font-size: 14px; border: none"></th>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../Images/bdlogo.png" style="height: 50px; margin-left: 80px; margin-top: -100px"></img></td>

                                    <td></td>

                            </table>

                        </div>
                        <div class="row" style="margin-top: 1%">
                            <p style="text-align: center">
                                উৎসে কর কর্তনকারী সত্তার নাম :<asp:Label runat="server" ID="OrgName" />
                            </p>
                            <%--<p style="text-align: center">
                                
                            </p>--%>
                            <p style="text-align: center">
                                উৎসে কর কর্তনকারী সত্তার ঠিকানা : 
                                 <asp:Label runat="server" ID="OrgAddress" />
                                <%--  <asp:Label runat="server" ID="OrgBin" />--%>
                            </p>
                            <%--<p style="text-align: center;">
                               
                            </p>--%>
                            <p style="text-align: center">
                                উৎসে কর কর্তনকারী সত্তার বিআইএন (প্রযোজ্য ক্ষেত্রে) : <asp:Label runat="server" ID="OrgBin" />
                            </p>
                           <%-- <p style="text-align: center;">
                               
                            </p>--%>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group form-group-sm">
                                    <%--  <label class="col-sm-5 control-label">ঠিকানা :</label>--%>
                                    <div class="col-sm-7">
                                        <%--<asp:Label runat="server" ID="OrgAddress" />--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group form-group-sm">
                                    <%--<label class="col-sm-5 control-label">ইস্যুর তারিখ :</label>--%>
                                    <label class="col-sm-5 control-label">জারির তারিখ :</label>
                                    <div class="col-sm-7">
                                        <asp:Label runat="server" ID="issuesDate" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group form-group-sm">
                                    <%--<label class="col-sm-5 control-label">সার্টিফিকেট নম্বর :</label>--%>
                                    <label class="col-sm-5 control-label">উৎসে কর কর্তন সনদপত্র নং :</label>
                                    <div class="col-sm-7">
                                        <asp:Label runat="server" ID="lblTaxDeductedCertificateNo" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group form-group-sm">
                                    <%--   <label class="col-sm-5 control-label">মূসক নিবন্ধন নম্বর (যদি থাকে) :</label>--%>
                                    <div class="col-sm-7">
                                        <%-- <asp:Label runat="server" ID="MushokRegNo" />--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6"></div>
                        </div>

                        <div class="col-md-12">
                         <%--   আমি--%>
                <%--    <asp:Label Style="font-weight: bold" runat="server" ID="EmployeeName" Text=" মোল্লা নাসির উদ্দীন " />--%>
                           <%-- এই মর্মে প্রত্যয়ন করিতেছি যে, মূল্য সংযোজন কর (মূসক) আইন ও বিধি অনুযায়ী নিন্মে উল্লিখিত সরবরাহকারীর নিকট হতে উৎসে মূসক কর্তন করা হইয়াছে। বিস্তারিত নিম্নে উল্লেখ করা হইল:--%>
                            এই মর্মে প্রত্যয়ন করিতেছি যে,  আইনের ধারা ৪৯ অনুযায়ী উৎসে কর কর্তনযোগ্য সরবরাহ হইতে প্রযোজ্য মূল্য সংযোজন কর বাবদ উৎসে কর কর্তন করা হইল | কর্তনকৃত মূল্য সংযোজন করের অর্থ বুক ট্রান্সফার /ট্রেজারি চালান /দাখিলপত্রে বৃদ্ধিকারী সমন্বয়ের মাধ্যমে সরকারি কোষাগারে জমা প্রদান করা হইয়াছে | কপি এতদসংগে সংযুক্ত করা হইল (প্রযোজ্য ক্ষেত্রে )
                            <br /><br />
                        </div>
                        <div class="row" style="margin-top: 3%; width: 100%; background: none">
                            <table class="table table-responsive" style="width: 100%; text-align: center; background: none" border="1">
                                <thead>
                                    <tr>
                                        <%--<th>ক্রমিক নং</th>--%>
                                        <%-- <th rowspan="2" style="text-align: center; font-weight: normal">সরবরাহকারীর নাম ও ঠিকানা </th>--%>
                                        <%--  <th rowspan="2" style="text-align: center; font-weight: normal">সরবরাহকারীর</th>--%>
                                        <%-- <th>সরবরাহকারীর ব্যবসায়ী সনাক্তকরণ নম্বর</th>--%>
                                        <%--  <th rowspan="2" style="text-align: center; font-weight: normal">সংশ্লিষ্ট কর চালানপত্র</th>--%>
                                        <%-- <th>মোট সরবরাহ মূল্য (টাকা)</th>--%>
                                        <%-- <th>মূসকের পরিমান (টাকা)</th>--%>
                                        <%--  <th>উৎসে কর্তনকৃত মূসকের পরিমান (টাকা)</th>--%>
                                        <%-- <th>২[প্রযোজ্য সেবা খাত ও কোড]</th>--%>
                                        <%-- <th>ট্রেজারিতে/অনলাইনে কর জমা প্রদানের/বুক ট্রান্সফারের চালান/রিসিপ্ট/সনদ নং ও তারিখ</th>--%>
                                        <%-- <th>মন্তব্য</th>--%>
                                        <th style="text-align: center;" rowspan="2">ক্রমিক নং</th>
                                        <th style="text-align: center;"  colspan="2">সরবরাহকারীর</th>
                                        <th style="text-align: center;"  colspan="2">সংশ্লিষ্ট কর চালানপত্র</th>
                                        <th style="text-align: center;"  rowspan="2">মোট সরবরাহ মূল্য (টাকা)</th>
                                        <th style="text-align: center;"  rowspan="2">মূসকের পরিমান (টাকা)</th>
                                        <th style="text-align: center;"  rowspan="2">উৎসে কর্তনকৃত মূসকের পরিমান (টাকা)</th>
                                    </tr>
                                    <tr>

                                        <td style="text-align: center;" >নাম</td>
                                        <td style="text-align: center;" >বিআইএন</td>
                                        <td style="text-align: center;" >নম্বর</td>
                                        <td style="text-align: center;" >ইস্যুর তারিখ</td>
                                    </tr>

                                </thead>
                                <tbody>
                                    <tr>
                                        <asp:Label runat="server" ID="lblSTDC" />
                                    </tr>
                                </tbody>

                            </table>
                        </div>
                       
                        <div class="row">
                            <div class="col-md-12">
                                <br />
                                <br />
                                ক্ষমতাপ্রাপ্ত কর্মকর্তার -<br />
                                <br />
                                স্বাক্ষর :<br />
                                নাম : <span id="lblDutyOfficerName" runat="server"></span>
                                <br />
                                <br />
                                <br />
                                <div style="border-top:1px solid black;display: inline-block">
                                    <sup>১</sup>মূসক ও সম্পূরক শুল্ক (যদি থাকে) সহ মূল্য
                                </div>
                                <br />
                                 <br />
                                <div style="display: inline-block">
                                   <label>বিদ্রঃ</label>
                                    <label >ট্রেজারী চালান নম্বর :</label><span id="trch" runat="server"></span>
                                     <label>ট্রেজারী চালান তারিখ :</label><span id="trDate" runat="server"></span>
                                     <label>ব্যাঙ্ক :</label><span  runat="server" id="trBank"></span>
                                     <label>ব্রাঞ্চ :</label><span runat="server" id="trBranch"></span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12" style="margin-top: 5px">
                                <div class="form-group form-group-sm">
                                    <asp:Label runat="server" Text="System User: "></asp:Label>
                                    <asp:Label runat="server" ID="lblUser"></asp:Label>
                                    <asp:Label runat="server" ID="lblPrintDateTime" Style="float: right"></asp:Label>
                                    <asp:Label runat="server" ID="Label3" Style="float: right" Text="Print DateTime: "></asp:Label>&nbsp&nbsp
                                </div>
                            </div>
                        </div>
                      <div style="text-align:right;font-size:11px;">
                          System Generated (KGCVAT)
                      </div>
                            </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" Style="float: right"
                Text="Print" OnClientClick="return PrintPanel();" />
       <%--     <uc2:MsgBox ID="msgBox" runat="server" />--%>
            <uc2:MsgBoxs runat="server" id="msgBox" />

            <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 12.05.2021
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
