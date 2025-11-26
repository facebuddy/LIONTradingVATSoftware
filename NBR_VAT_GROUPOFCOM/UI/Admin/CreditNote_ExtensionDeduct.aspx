

<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="CreditNote_ExtensionDeduct.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.CreditNote_ExtensionDeduct" %>

<%@ Register Assembly="jQueryDatePicker" Namespace="Westwind.Web.Controls" TagPrefix="ww" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register src="../../UserControls/Sale.ascx" tagname="sale" tagprefix="uc1" %>--%>

<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>


<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
  
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
 <%--   <uc2:MsgBox ID="msgBox" runat="server" />--%>
    <uc1:MsgBoxs runat="server" ID="msgBox" />

  <div class="container-fluid" style="padding-right:0%; padding-left:0%">
      <div class="panel-group">
        <div class="panel panel-primary">
           <div class="panel-heading" style="text-align:center;font-family:Tahoma; font-size:18px; font-weight:bold; height:30px; padding-top:0px">বিবিধ সমন্বয়ের জন্য...হ্রাসকারী সমন্বয়</div>
            <div class="panel-body" style="padding-top:0px; padding-bottom:2px">
               <div class="row" style="margin-top:0px">
                    <fieldset class="scheduler-border">
                        <legend class="scheduler-border">প্রদানকারী</legend>
                        <div class="col-sm-4" style="padding:0px">
                          <div class="col-sm-3" style="padding:0px">
                            <asp:Label ID="Label11" style="margin-left:51%" runat="server" Text="নাম:"></asp:Label>
                          </div>
                          <div class="col-sm-9" style="padding:0px">
                             <asp:Literal ID="lblOrgName" runat="server" Text="Bodrullah Khan"></asp:Literal>
                          </div>
                        </div>
                        <div class="col-sm-4" style="padding:0px">
                          <div class="col-sm-2" style="padding:0px">
                             <asp:Label ID="Label2" runat="server" Text="ঠিকানা:"></asp:Label>
                          </div>
                          <div class="col-sm-10" style="padding:0px">
                             <asp:Literal ID="lblOrgAddress" runat="server" Text="Dhanmondi"></asp:Literal>
                          </div>
                        </div>
                        <div class="col-sm-4" style="padding:0px">
                          <div class="col-sm-2" style="padding:0px">
                            <asp:Label ID="Label8"  runat="server" Text="বিআইএন:"></asp:Label>
                          </div>
                          <div class="col-sm-10" style="padding:0px">
                            <asp:Label ID="lblOrgBIN" style="margin-left: 0px;" runat="server" Text="123-123-123"></asp:Label>
                          </div>
                        </div>
                        <div class="col-sm-3 col-xs-3 col-lg-2">
                            <asp:Label ID="Label56" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="drpOrgUnit" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                            <asp:Label ID="lblOrgAddress1" runat="server" Visible="False"></asp:Label>
                        </div>
                        </fieldset>
                    </div>
               <div class="row" style="margin-top:0px;">
                      <fieldset class="scheduler-border">
                        <legend class="scheduler-border">গ্রহণকারী</legend>
                        <div class="col-sm-4" style="padding:0px">
                          <div class="col-sm-2" style="padding:0px">
                            <asp:Label ID="Label3" style="margin-left:74%;margin-top:3px" runat="server" Text=""><span class="required">*</span>নাম:</asp:Label>
                          </div>
                          <div class="col-sm-10" style="padding:0px">
                             <asp:DropDownList ID="drpParty" class="present-address-tb" style="width:60%; height:27px;margin-left:13px;text-align:left" runat="server" placeholder="গ্রহণকারী প্রতিষ্ঠানের নাম লিখুন" OnSelectedIndexChanged="drpParty_IndexChanged" AutoPostBack="true"></asp:DropDownList>
                          </div>
                        </div>
                        <div class="col-sm-4" style="padding:0px">
                          <div class="col-sm-1" style="padding:0px">
                             <asp:Label ID="Label4" runat="server" Text="ঠিকানা:" style="margin-top:3px"></asp:Label>
                          </div>
                          <div class="col-sm-11" style="padding:0px">
                              <asp:TextBox ID="txtReceiverAddress" class="present-address-tb" style="width:60%; height:27px;margin-left:13px;text-align:left" runat="server" placeholder="গ্রহণকারী প্রতিষ্ঠানের ঠিকানা লিখুন"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-sm-4" style="padding:0px">
                          <div class="col-sm-2" style="padding:0px">
                            <asp:Label ID="Label5" runat="server" Text="বিআইএন:" style="margin-top:3px"></asp:Label>
                          </div>
                          <div class="col-sm-10" style="padding:0px">
                           <asp:TextBox ID="txtReceiverBIN" class="present-address-tb" style="width:60%; height:27px;text-align:left" runat="server" placeholder="যদি থাকে বিআইএন নম্বর লিখুন"></asp:TextBox>
                          </div>
                        </div>
                        <div class="col-sm-3 col-xs-3 col-lg-2">
                            <asp:Label ID="Label7" runat="server" Text="Unit:" Visible="False"></asp:Label>
                            <asp:DropDownList ID="DropDownList2" runat="server" Visible="False" Width="50px"></asp:DropDownList>
                            <asp:Label ID="Label9" runat="server" Visible="False"></asp:Label>
                        </div>
                        </fieldset>
                    </div>


                    <div class="row"  style="margin-top:15px">
                      <%--<div class="col-sm-3" style="padding:0px">
                      <asp:Label ID="Label18" runat="server" Text="ক্রেডিট নোট নম্বর:" CssClass="present-address-lbl" style="margin-top:3px"/>
                      <asp:TextBox runat="server" ID="txtCreditNote" CssClass="present-address-tb" style="width:65%;height:27px;margin-left:30%" Enabled="false"/>
                      <asp:Label ID="debitNoteId" runat="server" Visible = "false" />
                      <asp:HiddenField ID = "hdBookId" runat="server" />
                      <asp:HiddenField ID = "hdPageNo" runat="server" />
                    </div>--%>
                            <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label ID="Label18" class="control-label col-sm-5 text-right">সমন্বয় নম্বর:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtCreditNote"></asp:TextBox>
                                    <asp:Label ID="debitNoteId" runat="server" Visible = "false" />
                                    <asp:HiddenField ID = "hdBookId" runat="server" />
                                    <asp:HiddenField ID = "hdPageNo" runat="server" />
                                </div>
                            </div>
                        </div>
                  <%--  <div class="col-sm-3" style="padding:0px">
                      <asp:Label ID="Label19" runat="server" Text="সমন্বয়ের কারণ:" CssClass="present-address-lbl" style="margin-top:3px"/>
                      <asp:DropDownList runat="server" ID="drpOAReason" CssClass="present-address-tb" style="width:65%;height:27px;margin-left:28%;text-align:left" placeholder="সমন্বয়ের  ঘটনাগুলো লিখুন"></asp:DropDownList>
                    </div>--%>
                         <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label ID="Label19" class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>সমন্বয়ের কারণ:</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" class="form-control" ID="drpOAReason" placeholder="সমন্বয়ের  ঘটনাগুলো লিখুন" OnSelectedIndexChanged="drpOAReason_IndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                   <%-- <div class="col-sm-3" style="padding:0px">
                      <asp:Label ID="Label22" runat="server" Text="গ্রহণের তারিখ:" CssClass="present-address-lbl" style="margin-top:3px"/>
                      <asp:TextBox runat="server" ID="txtReceiveDate" CssClass="present-address-tb" style="width:65%;height:27px;margin-left:26%"/>
                    </div>--%>
                         <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label ID="Label22" class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>গ্রহণের তারিখ:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtReceiveDate"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                   <%-- <div class="col-sm-3" style="padding:0px">
                      <asp:Label ID="Label23" runat="server" Text="প্রদানের তারিখ:" CssClass="present-address-lbl" style="margin-top:3px"/>
                      <asp:TextBox runat="server" ID="txtProviderDate" CssClass="present-address-tb" style="width:65%;height:27px; margin-left:27%" />
                    </div>--%>
                    <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label ID="Label23" class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>প্রদানের তারিখ:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtProviderDate"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                        
                        

                 <div class="row"  style="margin-top:5px">
                  <%--  <div class="col-sm-3" style="padding:0px">
                      <asp:Label ID="Label1" runat="server" Text="বিষয়:" CssClass="present-address-lbl" style="margin-left:18.6%;margin-top:3px"/>
                      <asp:TextBox runat="server" ID="txtSubject" CssClass="present-address-tb" style="width:65%;height:27px;margin-left:30%" TextMode="MultiLine" placeholder="সমন্বয়ের বিষয় লিখুন"/>
                    </div>--%>
                       <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label ID="Label233" class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>বিষয়:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtSubject" placeholder="সমন্বয়ের বিষয় লিখুন"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                   <%-- <div class="col-sm-3" style="padding:0px">
                      <asp:Label ID="Label6" runat="server" Text="সূত্র নং:" CssClass="present-address-lbl" style="margin-left:14%; margin-top:3px"/>
                      <asp:TextBox runat="server" ID="txtCaseNo" CssClass="present-address-tb" style="width:65%;height:27px;margin-left:28%" placeholder="কেস নং/আদেশ নং লিখুন"/>
                    </div>--%>
                      <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label ID="Label6" class="control-label col-sm-5 text-right">সূত্র নং:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtCaseNo" placeholder="কেস নং/আদেশ নং লিখুন"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                   <%-- <div class="col-sm-3" style="padding:0px">
                      <asp:Label ID="Label13" runat="server" Text="বর্ণনা:" CssClass="present-address-lbl" style="margin-left:14%; margin-top:3px"/>
                      <asp:TextBox runat="server" ID="txtDescription" CssClass="present-address-tb" style="width:65%;height:27px; margin-left:26%" TextMode="MultiLine" placeholder="কেস নং / আদেশ নং এর বর্ণনা লিখুন"/>
                    </div>--%>
                      <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label ID="Label13" class="control-label col-sm-5 text-right">বর্ণনা:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtDescription" placeholder="কেস নং / আদেশ নং এর বর্ণনা লিখুন "></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--<div class="col-sm-3" style="padding:0px">
                      <asp:Label ID="Label17" runat="server" Text="টাকার পরিমান:" CssClass="present-address-lbl"/>
                      <asp:TextBox runat="server" ID="txtAmount" CssClass="present-address-tb" style="width:65%;height:27px;margin-left:27%" placeholder="সমন্বয়কৃত টাকার পরিমান লিখুন"/>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                             runat="server" Enabled="True" TargetControlID="txtAmount"
                                                             ValidChars=".0123456789">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>--%>
                      <div class="col-md-3">
                            <div class="form-group form-group-sm">
                                <label ID="Label17" class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>টাকার পরিমান:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtAmount" placeholder="সমন্বয়কৃত টাকার পরিমান লিখুন"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                                         runat="server" Enabled="True" TargetControlID="txtAmount"
                                                                         ValidChars=".0123456789">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                        </div>
                 </div>
                  <div class="row"  style="margin-top:5px">
                   <div class="col-sm-3">
                              <div class="form-group form-group-sm">
                               <Label class="control-label col-sm-5 text-right" ID="Label21" runat="server"><span class="required"> * </span>কর মেয়াদ:</Label>
                                <div class="col-sm-7">
                                  <asp:DropDownList ID="drpsubmissionDate"  CssClass="form-control" runat="server" Width="100%"/>
                               
                                 </div>
                                </div>
                              </div>
                        </div>
                  <%--12-MAR-2020 start--%>
                    <div id="divCal" runat="server">
                        <div class="row" style="margin-top: 0px;">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border"><label id="lblCalculation" runat="server"></label></legend>
                            <div class="row" style="margin-top: 1%">
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>VAT Amount :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtVatAmount"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                runat="server" Enabled="True" TargetControlID="txtVatAmount"
                                                ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>No of Days :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtNoOfDays"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                runat="server" Enabled="True" TargetControlID="txtNoOfDays"
                                                ValidChars="0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>Interest (%) :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtInterestPct" OnTextChanged="txtInterestPct_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                runat="server" Enabled="True" TargetControlID="txtInterestPct"
                                                ValidChars="0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>Interest Amount :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtInterestAmount"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                                runat="server" Enabled="True" TargetControlID="txtInterestAmount"
                                                ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 1%">
                                <div class="col-sm-3">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>Particulars :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtParticulars"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    </div>
                    <%--12-MAR-2020 end--%>
                     <%--12-MAR-2020 start by the instruction of ruhul vai--%>
                     <div id="divhomeRent" runat="server">
                        <div class="row" style="margin-top: 0px;">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border"><label id="lblHomeRent" runat="server"></label></legend>
                            <div class="row" style="margin-top: 1%">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>Rent Amount :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtRent" OnTextChanged="txtRent_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                                runat="server" Enabled="True" TargetControlID="txtVatAmount"
                                                ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>                               
                                <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>VAT(%) :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtVATpct" OnTextChanged="txtVATpct_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8"
                                                runat="server" Enabled="True" TargetControlID="txtInterestPct"
                                                ValidChars="0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right"><span class="required" style="color: red">* </span>VAT Amount :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtVATamnt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9"
                                                runat="server" Enabled="True" TargetControlID="txtInterestAmount"
                                                ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>                         
                                                     
                                <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">AIT(%) :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtAITPct" OnTextChanged="txtAITPct_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10"
                                                runat="server" Enabled="True" TargetControlID="txtInterestPct"
                                                ValidChars="0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                   <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">AIT Amount :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtAIT"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                                runat="server" Enabled="True" TargetControlID="txtVatAmount"
                                                ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group form-group-sm">
                                        <label class="control-label col-sm-5 text-right">Particulars :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtPartic"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
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


                 <div class="row"  style="margin-top:5px">
                   <%--<asp:Button ID="Button1" runat="server" CssClass="btn btn" style="float:right;background-color:#337ab7;color:white" Text="Upload" onclick="UploadButton_Click" />--%>
                   <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn" style="float:right;background-color:#4CAF50;color:white" Text="Refresh" onclick="btnRefresh_Click" />

                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" style="float:right" Text="Save" onclick="btnSave_Click"/>
                 </div>


                <%--creditnoteUpload--%>
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
                          <asp:BoundField DataField="adjustmentNo" HeaderText="Adjustment No" />  
                           <asp:BoundField DataField="imageName" HeaderText="File Name" /> 
                          <asp:BoundField DataField="adjustmentDate" HeaderText="Adjustment Date" />  
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
                <%--creditnoteUpload--%>

            </div>
        </div>
       </div>
  </div>
</asp:Content>