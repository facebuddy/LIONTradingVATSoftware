<%@ page title="" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" theme="Theme1" inherits="UI_Others_Treasury_Deposit, App_Web_0aej32q1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Others.ascx" TagName="others" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/admin.ascx" TagName="admin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1 {
            text-align: right;
        }

        .input_field {
            text-align: right;
        }

        .grid_header {
            background-image: none;
            color:#000 !important;         
            border: 1px solid #c9c9c9;
            
            font-family: arial,Helvetica,sans-serif;
            font-size: 15px;
            font-weight:700;
            height: 35px;
            text-align: center;
        }
        .label {
            color:#000;
            font-size:15px !important;
            font-family: arial,Helvetica,sans-serif;
        }


    </style>

    <%--For Print Only--%>
    <style media="print">
    .noPrint{ display: none;}
    @media print { table{width:100%;} tr,td {padding:5px;}
    .full_width{
        width: 100%;
    }
    } 
    .yesPrint{ display: block !important; }
    input[type=text],select,textarea,.text_box
    {
        border:none;
    }
            
</style>
 <%--End For Print Only--%>
    <script type="text/javascript">
        function addVat(chkB) {
            var rowIndex = chkB.parentElement.parentElement.rowIndex;

            var presentValue = document.getElementById("<%=txtAmount.ClientID%>").value;
            if (presentValue == "") {
                presentValue = 0;
            }
            var vat = parseFloat(presentValue);

            var jsGvChallanItem = document.getElementById("<%=gvChallanItem.ClientID%>");


            var IsChecked = chkB.checked;
            if (IsChecked) {
                vat += parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#cfc';
            } else if (presentValue > 0) {
                vat -= parseFloat(jsGvChallanItem.rows[rowIndex].cells[2].innerHTML.toString());
                chkB.parentElement.parentElement.style.backgroundColor = '#fff';
            }

            document.getElementById("<%=txtAmount.ClientID%>").value = parseFloat(Number(vat)).toFixed(2);
            document.getElementById("<%=txtAmount.ClientID%>").style.background = "#cfc";


        }

        function SelectAllCheckboxesSpecific(spanChk) {

            var IsChecked = spanChk.checked;

            var Chk = spanChk;


            var jsGvItem = document.getElementById("<%=gvChallanItem.ClientID%>");
            var items = jsGvItem.getElementsByTagName('input');

            //var rowCount = jsGvItem.rows.length;

            for (var i = 1; i < items.length; i++) {
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>


            <div class="noPrint">
                <table align="center" bgcolor="WhiteSmoke" border="0" cellpadding="0" cellspacing="3"
                    class="brd_tbl_input" border="0px">
                    <tr>

                        <td><a href="Treasury_Deposit_show.aspx" class="btn btn-success">Insert TR Challan</a> </td>
                        <td class="page_title" colspan="4" align="center">Treasury Deposit(টি.আর. ফর্ম নং-৬)<uc1:admin ID="admin" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td rowspan="10" style="border: 1px solid #000;">
                            <asp:RadioButton ID="radio_challan_list" Text="Sales Challan List" Checked="True" GroupName="vat_type" runat="server" OnCheckedChanged="radio_challan_list_CheckedChanged" AutoPostBack="true" />
                            <asp:RadioButton ID="radio_non_challan" Text="Non Sale Challan Issue " GroupName="vat_type" runat="server" OnCheckedChanged="radio_non_challan_CheckedChanged" AutoPostBack="true" onclick="clearChkBox(this)" />
                            <h4><u>Challan Selection From: </u></h4>
                            <div style="overflow: auto; border: 0px solid olive; width: 100%; height: 270px;">

                                <asp:GridView ID="gvChallanItem" runat="server" AutoGenerateColumns="False" CssClass="mGrid" ShowHeader="true">
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAllCheckboxesSpecific(this)" ToolTip="Check to Select All Item" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChallan" runat="server" onclick="addVat(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Challan No" DataField="challan_no" />
                                        <asp:BoundField HeaderText="Vat" DataField="vat" />
                                        <asp:BoundField HeaderText="Sale Price" DataField="sale_price" />
                                    </Columns>
                                </asp:GridView>

                                <asp:Label ID="lbl_nonChallan" runat="server" Visible="false" Font-Size="18px">You Have Selected Non Challan Vat Type</asp:Label>

                            </div>




                        </td>
                        <td class="style1">
                            <asp:Label Visible="false" ID="Label8" runat="server" Text="Challan No/ Scroll No :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox Visible="false" ID="txtChallanNo" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="style1">
                            <asp:Label ID="Label14" runat="server" Text="Challan Date :"></asp:Label>
                        </td>
                        <td style="width: 177px;">
                            <ww:jQueryDatePicker ID="dtpUnloadRealDate2" runat="server" Width="60px" Enabled="false"
                                DateFormat="dd/MM/yyyy"></ww:jQueryDatePicker>
                            <asp:DropDownList ID="drpChDtHr" runat="server" Enabled="false">
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpChDtMin" runat="server" Enabled="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="style1">
                            <asp:Label ID="Label9" runat="server" Text="Bank :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpBankName" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="drpBankName_SelectedIndexChanged" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label16" runat="server" Text="Branch :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpBankBranch" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align: right">
                            <asp:Label ID="Label3" runat="server" Text="A/C Code No :"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtCodeNo" runat="server" Width="150px"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtCodeNo"
                                Mask="9 - 9999 - 9999 - 9999" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align: right">
                            <asp:Label ID="Label2" runat="server" Text="Bearer's Name &amp; Address :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBearerNameAddress" runat="server" Width="150px"
                                TextMode="MultiLine" Height="30px"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="Label27" runat="server" Text="Behalf of :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpOrgName" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="drpOrgName_SelectedIndexChanged" Width="104px">
                            </asp:DropDownList>
                            <asp:Button ID="btnNewOrg" runat="server" CssClass="button" Height="25px"
                                OnClick="btnNewOrg_Click" Text="New" />
                            <br />
                            <asp:TextBox ID="txtBehalfOf" runat="server" Width="150px" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" valign="top">
                            <asp:Label ID="Label33" runat="server" Text="Address :"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtAddress1" runat="server" Rows="1" TextMode="MultiLine"
                                Width="150px"></asp:TextBox>
                            <br />
                        </td>
                        <td class="input_field">
                            <asp:Label ID="Label5" runat="server" Text="Designation :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesignation" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align: right">
                            <asp:Label ID="Label35" runat="server" Text="Deposit Description :"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDepositDescription" runat="server" Width="385px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="4">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" valign="top">
                            <asp:Label ID="Label18" runat="server" Text="Instrument Type :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpInstrumentType" runat="server" Width="150px" AutoPostBack="True"
                                OnSelectedIndexChanged="drpInstrumentType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="input_field">
                            <asp:Label ID="Label21" runat="server" Text="Amount :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAmount" runat="server" Width="150px" Text="0.00" Enabled="false"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="txtAmount_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtAmount" ValidChars=".0123456789" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" valign="top">
                            <asp:Label ID="lblInsDescription" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInstrumentDescription" runat="server" Rows="1"
                                TextMode="MultiLine" Width="150px"></asp:TextBox>
                        </td>
                        <td class="input_field">
                            <asp:Label ID="Label37" runat="server" Text="Challan for :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpChallanType" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align: right">
                            <asp:Label ID="Label36" runat="server" Text="Unit :" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUnit" runat="server" Width="150px" Visible="False"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="right" colspan="4">
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:Button ID="btnAddItem" runat="server" CssClass="button" OnClick="btnAddItem_Click"
                                    Text="Add Item" />
                                <asp:Button ID="btnRefresh" runat="server" CssClass="button"
                                    OnClick="btnRefresh_Click" Text="Refresh" />
                                <asp:Button ID="btnSave" runat="server" CssClass="button"
                                    OnClick="btnSave_Click" Text="Save" />
                                <asp:Button ID="btnShowItemList" runat="server" CssClass="button" Text="Show List"
                                    OnClick="btnShowItemList_Click" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                </table>
                <asp:GridView ID="dgvTreasuryDeposit" runat="server" AutoGenerateColumns="False"
                    CssClass="sGrid"
                    DataKeyNames="orgName,orgAddress,orgId,challanTyped,branchId" Width="100%"
                    ShowHeaderWhenEmpty="True" OnRowDataBound="dgvTreasuryDeposit_RowDataBound"
                    OnRowDeleting="dgvTreasuryDeposit_RowDeleting"
                    OnSelectedIndexChanged="dgvTreasuryDeposit_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="C G Number" DataField="ChallanNo" />
                        <asp:BoundField HeaderText="Challan Date" DataField="StrDate" />
                        <asp:BoundField HeaderText="Bank" DataField="BankName">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Branch" DataField="BranchName" />
                        <asp:BoundField HeaderText="Account No" DataField="CodeNo">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Bearer Name &amp; Address" ItemStyle-Wrap="false"
                            DataField="BearerNameAddress">
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Behalf Of" DataField="OrgName">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Designation" DataField="Designation">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Address" DataField="OrgAddress" />
                        <asp:BoundField HeaderText="Deposit Description"
                            DataField="DepositDescription" />
                        <asp:BoundField HeaderText="Instrument Type" DataField="InstrumentType" />
                        <asp:BoundField HeaderText="Instrument Description"
                            DataField="InstrumentDescription" />
                        <asp:BoundField HeaderText="Amount" DataField="amount" />
                        <asp:BoundField HeaderText="Unit" DataField="unit" Visible="False" />
                        <asp:BoundField DataField="ChallanType" HeaderText="Challan Type" />
                        <%--<asp:BoundField DataField="Challan_numbers" HeaderText="Challlan Numbers" />--%>

                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Height="25px" />
                    <RowStyle BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />

                </asp:GridView>

            </div>
           

            <asp:Panel CssClass="yesPrint" ID="pnGvArea" runat="server" Visible="false">
                <div style="text-align: center">

                    <center>
                        <asp:Label style="font-size:15px;" ID="lblHeader" runat="server" Text="চালান ফরম"></asp:Label><br />
                        <asp:Label style="font-size:15px;" ID="lblFrom" runat="server" Text="টি, আর ফরম নং ৬ (এস, আর ৩৭ দ্রষ্টব্য)"></asp:Label><br />
                        <asp:Label style="font-size:15px;" ID="lblChallanNo" runat="server" Text="চালান নং.......................... তারিখ.......................... "></asp:Label><br />
                        <asp:Label style="font-size:15px;" ID="lblDepositChallan" runat="server" Text="বাংলাদেশ ব্যাংক/সোনালী ব্যাংকের..........ঢাকা.........জেলার......মতিঝিল......শাখায় টাকা জমা দেওয়ার  চালান ।" ></asp:Label><br /> 
                         
                    </center>
                    </div>


                    <table class="tablefull">
                        <tr>
                            <td class="auto-style1">কোড নং  


                            </td>
                            <td colspan="5" class="auto-style1">
                                <div class="div_box">
                                    <asp:Label ID="code1" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="div_space">&nbsp;&nbsp;-&nbsp;&nbsp;</div>
                                <div class="div_box">
                                    <asp:Label ID="code2" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="div_box">
                                    <asp:Label ID="code3" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="div_box">
                                    <asp:Label ID="code4" runat="server" Text=""></asp:Label></div>
                                <div class="div_box">
                                    <asp:Label ID="code5" runat="server" Text=""></asp:Label></div>
                                <div class="div_space">&nbsp;&nbsp;-&nbsp;&nbsp;</div>
                                <div class="div_box">
                                    <asp:Label ID="code6" runat="server" Text=""></asp:Label></div>
                                <div class="div_box">
                                    <asp:Label ID="code7" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="div_box">
                                    <asp:Label ID="code8" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="div_box">
                                    <asp:Label ID="code9" runat="server" Text=""></asp:Label></div>
                                <div class="div_space">&nbsp;&nbsp;-&nbsp;&nbsp;</div>
                                <div class="div_box">
                                    <asp:Label ID="code10" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="div_box">
                                    <asp:Label ID="code11" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="div_box">
                                    <asp:Label ID="code12" runat="server" Text=""></asp:Label></div>
                                <div class="div_box">
                                    <asp:Label ID="code13" runat="server" Text=""></asp:Label></div>
                            </td>



                        </tr>
                    </table>

                 <table class="table_report">
                    <thead>
                        <tr>
                            <th colspan="4">জমা প্রদানকারী কর্তৃক পূরণ করিতে হইবে </th>
                        
                            <th colspan="2">টাকার অংক</th>
                        
                            <th rowspan="2">বিভাগের নাম এবং চালানের পৃষ্ঠাংকনকারী কর্মকর্তার নাম, পদবী ও দপ্তর </th>
                        </tr>
                        <tr>
                            <th>যাহার মারফত প্রদত্ত হইল তাহার নাম ও ঠিকানা।</th>
                            <th>যে ব্যত্তির/প্রতিষ্ঠানের পক্ষ হইতে টাকা প্রদত্ত হইল তাহার নাম, পদবী ও ঠিকানা।</th>
                            <th>কি বাবদ জমা দেওয়া হইল তাহার বিবরণ</th>
                            <th>মুদ্রা ও নোটের বিবরণ/ ড্রাফ্‌ট, পে-অডার ও চেকের বিবরণ</th>
                            <th>টাকা</th>
                            <th>পয়সা</th>
                        
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal ID="ltTRReportBody" runat="server"></asp:Literal>
                        <tr>
                            <td colspan="4" style="border-right:1px solid #fff;">তারিখ ........................</td>
                            <td colspan="3"><center>ম্যানেজার<br />বাংলাদেশ ব্যাংক/সোনালী ব্যাংক </center></td>
                        </tr>
                    </tbody>
                </table>
            <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblNote" runat="server" Text="নোট :"></asp:Label></td>

                        <td>
                            <asp:Label ID="lblOne" runat="server" Text="১ । সংশ্লিষ্ট দপ্তরের সহিত যোগাযোগ করিয়া সঠিক কোড নম্বর জানিয়া লইবেন ।" ></asp:Label>
                        </td>


                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lblTwo" runat="server" Text="২ ।* যে সকল ক্ষেত্রে কর্মকর্তা কর্তৃক পৃষ্টাংকন প্রয়োজন,সে সকল  ক্ষেত্রে প্রযোজ্য হইবে । "></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server"  Text="বাঃসঃমুঃ -২০০৮/০৯-৪৮৬৬ কম (ডি)-১০০ বই , ২০০৯ ।"></asp:Label>
                        </td>
                    </tr>
                </table>
                <center><a href="#" onclick="window.print();  return false;"  data-toggle="tooltip" title="Print Page" class="btn btn-danger noPrint"><i class="fa fa-print"></i> Print</a></center>


            </asp:Panel>
            <uc2:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--   <uc1:others ID="others" runat="server" />--%>
</asp:Content>
