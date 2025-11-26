<%@ page title="" theme="Theme1" language="C#" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="Reports_SourceTaxDeductedCertificate_Receive_6_6, App_Web_o1josinq" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/Main.css" rel="Stylesheet" type="text/css" />
    <link href="../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../Styles/str.css" rel="stylesheet" />
    <style type="text/css">
        .style1 {
            text-align: right;
        }
        .hiddencol{
            display:none;
        }
        .required {              /*ehsan*/
  color: red;
  width:100%;
}

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <uc2:MsgBox runat="server" ID="msgBox" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">Receive/উৎসে কর কর্তন সনদপত্র (মূসক-৬.৬)</div>
                        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                            <div class="row hiddencol" style="background-color: #FFD9C3">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Supplier Name :</label>
                                        <div class="col-sm-7">
                                            <asp:Literal ID="lblOrgName" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Supplier Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Literal ID="lblOrgAddress" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Supplier BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Literal ID="lblOrgBIN" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row hiddencol">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Branch Name :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpBranchName" runat="server" OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged" AutoPostBack="true"
                                            CssClass="form-control">
                                        </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Branch Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Branch BIN :</label>
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
                                             <asp:DropDownList ID="drpParty" runat="server" CssClass="form-control select2"
                                            AutoPostBack="True" OnSelectedIndexChanged="drpParty_SelectedIndexChanged">
                                        </asp:DropDownList>
                                            <asp:TextBox ID="txtPartyName" runat="server" Visible="False" CssClass="present-address-tb" placeholder="enter company name"></asp:TextBox>
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
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>VDS Certificate No :</label>
                                        <div class="col-sm-7">
                                             <asp:TextBox runat="server" Style="background: #D7FBB1;" ID="txtSTDCertificate" CssClass="form-control" placeholder="Enter Certificate No"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>VDS Amount :</label>
                                        <div class="col-sm-7">
                                             <asp:TextBox runat="server" Style="background: #D7FBB1;" ID="txtVDSAmount" CssClass="form-control" placeholder="Enter VDS Amount"></asp:TextBox>
                                          <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                        runat="server" Enabled="True" TargetControlID="txtVDSAmount" ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Certificate Date :</label>
                                        <div class="col-sm-7">
                                             <asp:TextBox runat="server" Style="background: #D7FBB1;" ID="txtCertificateDate" CssClass="form-control" Format="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtCertificateDate" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Ref.Challan No ৬.৩ :</label>
                                        <div class="col-sm-7">
                                             <asp:DropDownList runat="server" Style="background: #D7FBB1;" ID="drpChallanNo" CssClass="form-control select2" OnSelectedIndexChanged="drpChallanNo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <%-- <asp:TextBox runat="server" Style="background: #D7FBB1;" ID="txtChallanNo" CssClass="form-control" OnTextChanged="txtChallanNo_TextChanged" AutoPostBack="true"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Challan Date :</label>
                                        <div class="col-sm-7">
                                           <asp:TextBox ID="txtChallanDate" CssClass="form-control" Style="width: 50%; float: left" runat="server" DateFormat="dd/MM/yyyy" ReadOnly="false"></asp:TextBox>
                                           <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChallanDate"/>
                                            <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpChDtHr_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server"  AutoPostBack="True"
                                            OnSelectedIndexChanged="drpChDtMin_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right"><span class="required">* </span>Account Code :</label>
                                        <div class="col-sm-7">
                                           <asp:TextBox ID="txtAccountCode" CssClass="form-control" runat="server"></asp:TextBox>
                                           
                                        </div>
                                    </div>
                                </div>
                            </div>

                             <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Tax Deposit Book Transfer Serial No:</label>
                                        <div class="col-sm-7">
                                             <asp:TextBox runat="server" ID="txtTransferNo" CssClass="form-control"></asp:TextBox>
                                            <%-- <asp:TextBox runat="server" Style="background: #D7FBB1;" ID="txtChallanNo" CssClass="form-control" OnTextChanged="txtChallanNo_TextChanged" AutoPostBack="true"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                </div>
                                    <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Tax Deposit Date:</label>
                                        <div class="col-sm-7">
                                             <asp:TextBox runat="server" Style="background: #D7FBB1;" ID="txtDepoDate" CssClass="form-control" Format="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDepoDate" />
                                        </div>
                                    </div>
                                </div>

                                  <div class="col-sm-4">
                              <div class="form-group form-group-sm">
                               <asp:Label class="col-sm-5 control-label" ID="Label21" runat="server" style="text-align:right;"><span class="required"> * </span>Adjustment Tax Period:</asp:Label>
                                <div class="col-sm-7">
                                  <asp:DropDownList ID="drpsubmissionDate"  CssClass="form-control" runat="server"/>
                               
                                 </div>
                                </div>
                              </div>
                               
                            </div>

                            <div class="row" style="margin-top: 10px">
                                                           
                             
                                <div class="test-label">
                                    <asp:Label ID="Label10" runat="server" Text="মোট মূল্য:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtAmount" CssClass="category" runat="server" placeholder="টাকায়"></asp:TextBox><br />
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                        runat="server" Enabled="True" TargetControlID="txtAmount" ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     </div>
                                <div class="test-label">
                                    <asp:Label ID="Label37" runat="server" Text="মোট মূসক:" Style="margin-left: -7px;" /><br />
                                    <asp:TextBox ID="txtTax" CssClass="category" runat="server" AutoPostBack="True" placeholder="টাকায়"></asp:TextBox><br />
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                        runat="server" Enabled="True" TargetControlID="txtTax" ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     </div>

                                <%--new fields--%>
                                <div class="test-label">
                                    <asp:Label ID="Label1" runat="server" Text="পরিশোধিত মূল্য:" Style="margin-left: 0px;" /><br />
                                    <asp:TextBox ID="txtPaidAmount" CssClass="category" runat="server" placeholder="টাকায়"></asp:TextBox><br />
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                        runat="server" Enabled="True" TargetControlID="txtAmount" ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     </div>
                                <div class="test-label">
                                    <asp:Label ID="Label2" runat="server" Text="পরিশোধিত মূসক:" Style="margin-left: -7px;" /><br />
                                    <asp:TextBox ID="txtReceivedVds" CssClass="category" runat="server" AutoPostBack="True" placeholder="টাকায়"></asp:TextBox><br />
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                        runat="server" Enabled="True" TargetControlID="txtTax" ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     </div>
                                <div class="test-label">
                                    <asp:Label ID="Label3" runat="server" Text="প্রাপ্য পরিশোধিত মূসক:" Style="margin-left: -7px;" /><br />
                                    <asp:TextBox ID="txtReceivableVds" CssClass="category" runat="server" AutoPostBack="True" placeholder="টাকায়"></asp:TextBox><br />
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                        runat="server" Enabled="True" TargetControlID="txtTax" ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     </div>

                                <div class="test-label" style="display:none;">
                                    <asp:Label ID="Label4" runat="server" Text="" Style="margin-left: -7px;" /><br />
                                    <asp:TextBox ID="txtVdsIDs" runat="server" Text="" Style="margin-left: 0px;" />
                                     </div>
                                <%--end new fields--%>

                                <div class="test-label">
                                    <asp:Label ID="Label11" runat="server" Text="" Style="margin-left: 0px;" /><br />
                                    <asp:Button ID="btnAdd" class="btn-btn" Style="background-color:#B681B7;margin-left: 2px; margin-top: 0px;" runat="server" AutoPostBack="True" Text="Add Item" OnClick="btnAdd_Click"></asp:Button>
                                </div>
                                <div class="test-label">
                                    <asp:Label ID="Label13" runat="server" Text="" Style="margin-left: 0px;" /><br />
                                    <asp:Button ID="btnSave" class="btn-btn" Style="background-color:#4CAF50;margin-left: 2px; margin-top: 0px; width: 150%;" runat="server" AutoPostBack="True" Text="Save" OnClick="btnSave_Click"></asp:Button>
                                </div>
                            </div>
                            

               <%--fileupload_body--%>
                <br />
                <div class="row" style="margin-top:5px;padding-left:15px;">
                    <asp:FileUpload id="FileUploadControl" AllowMultiple="true"  style="width:80%;float:left;border:groove;" runat="server" />                  
                    <br />
                    <asp:Label runat="server" id="StatusLabel" text="" />
                </div>
                <%--fileupload_body--%>

                            <div class="row" style="margin-top: .5%">
                                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="sGrid"
                                    DataKeyNames="RowNO" Width="100%" OnRowDeleting="gvItem_RowDeleting">
                                    <Columns>
                                        <asp:BoundField HeaderText="Category" DataField="Category" Visible="true" />
                                        <asp:BoundField HeaderText="Sub Category" DataField="SubCategory" Visible="true" />
                                        <asp:BoundField HeaderText="Item" DataField="Item" />
                                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                        <asp:BoundField HeaderText="Unit" DataField="Unit" />
                                        <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" DataFormatString="{0:n2}"/>
                                        <asp:BoundField DataField="TotalPrice" HeaderText="মোট মূল্য" DataFormatString="{0:n2}"/>
                                        <asp:BoundField DataField="TotalVat" HeaderText="মূসকের পরিমান" DataFormatString="{0:n2}"/>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                    </Columns>
                                    <HeaderStyle Height="25px" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </div>

                <%--stdUpload--%>
                 <br />
                <div class="container-fluid">
                <div class="panel panel-primary">
            
                        <div class="panel-heading" style="text-align: center; font-size: 25px; font-weight: bold;
                    height: 30px; padding-top: 0px">
                                <b>Uploaded Files</b>
                            </div>
                    <div class="full_body_readyform">
                    <div class="clear_fix">
                    </div>

                    <asp:Panel ID="pnInput" CssClass="input-table tablefull center paddinglrb" Height="250px" runat="server"  ScrollBars="Vertical">
                    <asp:GridView ID="Gv_imgs" CssClass="table" runat="server" AutoGenerateColumns="false" ShowHeader="true"  AutoGenerateSelectButton="True" BackColor="White" 
                           DataKeyNames="imageUrl" onselectedindexchanged="Gv_imgs_SelectedIndexChanged"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >  
                      <Columns>   
                          <asp:BoundField DataField="challanNo" HeaderText="Ref. Challan No." />  
                           <asp:BoundField DataField="imageName" HeaderText="File Name" /> 
                          <asp:BoundField DataField="certificateDate" HeaderText="Certificate Date" />  
                            <asp:ImageField DataImageUrlField="imageUrl" ControlStyle-Height="75" ControlStyle-Width="75" HeaderText="Images" />  
                      </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />  
                    </asp:GridView>
                        </asp:Panel>

                    </div>
                </div>
                </div>
                <%--stdUpload--%>


                        </div>
                    </div>
                </div>
            </div>
            <br /><br />  <br />

            <div style="text-align:center;font-size:11px;">
               Edited on 17.06.2021
            </div>    

             <%--<uc2:MsgBox runat="server" ID="msgBox" />--%>
        </ContentTemplate>

        <%-- as the files are not being loaded--%>
        <Triggers>
                <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
        <%-- as the files are not being loaded--%>


    </asp:UpdatePanel>
</asp:Content>
