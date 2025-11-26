
<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="PartySetup.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Others.PartySetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>






<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="Server">
  
    <style type="text/css">
        .style1 {
            height: 23px;
        }

        .style2 {
        }

        .style3 {
            width: 77px;
        }

        .style4 {
            width: 117px;
            height: 23px;
        }

        .style5 {
            width: 77px;
            height: 23px;
        }

        .PnlDesign {
            border: solid 0.5px #E0E0E0;
            height: 100px;
            width: 100%;
            overflow: scroll;
            background-color: White;
            font-size: 11px;
            font-family: Arial;
        }

        .hide {
            /*display: none;*/
            color:white;
        }
         .hiddencol {
            display: none;
        }

        .wrapper1, .wrapper2 { width: 100%; overflow-x: scroll; overflow-y: hidden; }
        .wrapper1 { height: 20px; }
        .div1 { height: 20px; }
        .div2 { overflow:none; }

    </style>

    <script>
        $(function () {
            $('.wrapper1').on('scroll', function (e) {
                $('.wrapper2').scrollLeft($('.wrapper1').scrollLeft());
            });
            $('.wrapper2').on('scroll', function (e) {
                $('.wrapper1').scrollLeft($('.wrapper2').scrollLeft());
            });
        });
        $(window).on('load', function (e) {
            $('.div1').width($('table').width());
            $('.div2').width($('table').width());
        });
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">Party/Client Profile Setup</div>
                <div class="panel-body">
                    <div class="row" runat="server" id="Div4">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label"><span class="required">*</span>Registration Type :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="drpRegistrationType" OnSelectedIndexChanged="drpRegistrationType_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="1">Regular Registered (VAT)</asp:ListItem>
                                        <asp:ListItem Value="4">Registered For Turnover</asp:ListItem>
                                        <asp:ListItem Value="5">Not Registered</asp:ListItem>
                                          <%--add by the instruction of ruhul vai 06/01/2020--%>
                                         <%--<asp:ListItem Value="6">Registration is not Eligable</asp:ListItem>--%> <%--commence on08/01/2020 by the instruction of ruhul vai--%>
                                         <asp:ListItem Value="7">Procurement Provider</asp:ListItem>
                                        <asp:ListItem Value="8">Trader</asp:ListItem>
                                       <%--  <asp:ListItem Value="9">Self Registered</asp:ListItem>--%><%--commence on08/01/2020 by the instruction of ruhul vai--%>
                                      <%--add by the instruction of ruhul vai 06/01/2020 end--%>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label"><span class="required">*</span>Party Name :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPartyName" />
                                    <asp:Label ID="lblPartyID" runat="server" Visible="false" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    <div class="row" runat="server" id="part_a" visible="false">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
<%--                                 <label class="col-sm-5 control-label">Party BIN :</label>--%>
                   <asp:label ID="labelpartyBIN" runat="server" CssClass="control-label col-sm-5">Party BIN :</asp:label>

                                <div class="col-sm-7">
                                   <asp:TextBox runat="server" CssClass="form-control" ID="txtPartyBIN" MaxLength="14" placeholder="13 digit BIN"/>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtPartyBIN"
                                                        ValidChars="-0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:Label ID="Label1" runat="server" Visible="false" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <%-- <label class="col-sm-5 control-label">Phone/Mobile :</label>--%>
                                <%--<label class="col-sm-5 control-label">National Id No :</label>--%>
                                   <asp:label ID="lblNID" runat="server" CssClass="control-label col-sm-5">National Id No :</asp:label>
                                <div class="col-sm-7">
                                    <%--   <asp:TextBox runat="server" CssClass="form-control" ID="txtPhone" />--%>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNationalIdNo" MaxLength="17" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="txtExchangeRate_FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtNationalIdNo"
                                                        ValidChars="0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                     </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>

                    <div class="row" runat="server" id="Div5">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label"><span class="required">*</span>Business Info :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="drpBusinessInfo" AutoPostBack="true" OnSelectedIndexChanged="drpBusinessInfo_SelectedIndexChanged" />
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Phone/Mobile :</label>
                                <div class="col-sm-7">
                                   <asp:TextBox runat="server" CssClass="form-control" ID="txtPhone" />
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                        runat="server" Enabled="True" TargetControlID="txtPhone" 
                                                        ValidChars="0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                              <%-- <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPhone"

                                     MaskType ="Number" Mask="999-9999-9999" MessageValidatorTip="true"  ClearMaskOnLostFocus="False" >
                                  </ajaxToolkit:MaskedEditExtender>--%>
                                     </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>



                    <%--  <div class="row" runat="server" id="Div7">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Major Area of Economic Activity :</label>
                            </div>
                        </div>
                    </div>

                    <div class="row" runat="server" id="Div8">
                        <div class="col-sm-2"></div>
                        <div class="col-md-8">
                            <div class="form-group form-group-sm">
                                <asp:DropDownList ID="drpTypeofBusiness" runat="server" ReadOnly="true" class="form-input" Height="20px"
                                    data-toggle="dropdown" Visible="false">
                                </asp:DropDownList>
                                <asp:Panel ID="Panel1" runat="server" CssClass="PnlDesign">
                                    <asp:CheckBoxList ID="chklistTypeofBusiness" runat="server" OnSelectedIndexChanged="chklistTypeofBusiness_Changed"
                                        AutoPostBack="true" Style="width: 100%">
                                    </asp:CheckBoxList>
                                </asp:Panel>

                            </div>
                        </div>
                    </div>--%>


                    <%-- <div class="row" runat="server" id="Div7">
                        <div class="col-sm-2"></div>
                       <div class="dropdown col-sm-8">
                                    <asp:DropDownList ID="drpTypeofBusiness" runat="server" ReadOnly="true" class="form-input" height = "20px"
                                        data-toggle="dropdown" Visible = "false">
                                    </asp:DropDownList>
                                      <asp:Panel ID="Panel1" runat="server" CssClass="PnlDesign">
                                    <asp:CheckBoxList ID="chklistTypeofBusiness" runat="server" style="width:100%" >
                                    </asp:CheckBoxList>
                                    </asp:Panel>
                                    
                                </div>
                          
                        <div class="col-sm-2"></div>
                    </div>--%>
            

                    <div class="row" runat="server" id="part_b" visible="false">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                             <label class="col-sm-5 control-label">Email :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                        runat="server" Enabled="True" TargetControlID="txtEmail" FilterType="Numbers, LowercaseLetters, Custom"
                                        ValidChars=".@">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label">Web :</label>
                                <div class="col-sm-7">
                                   <asp:TextBox runat="server" CssClass="form-control" ID="txtWeb" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    <div class="row" runat="server" id="part_d" visible="false">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Owner Name :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtOwnerName" />
                                    <asp:Label ID="Label2" runat="server" Visible="false" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">VDS :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="drpVDS" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    <div class="row" runat="server" id="part_c" visible="false">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Ultimate Destination :</label>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUltimateDesignation" />
                                    <asp:Label ID="Label5" runat="server" Visible="false" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label"><span class="required">*</span>Party Type :</label>
                                <div class="col-sm-7">
                                    <asp:RadioButton id="isImporter" runat="server" GroupName="partyType" Text="Importer"></asp:RadioButton>
                                    <asp:RadioButton id="isVendor" runat="server" GroupName="partyType" Text="Vendor"></asp:RadioButton>
                                    <asp:RadioButton id="isCustomer" runat="server" GroupName="partyType" Text="Customer"></asp:RadioButton><br />
                                    <asp:RadioButton id="isVc" runat="server" GroupName="partyType" Text="Vendor&Customer"></asp:RadioButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    
                    <div class="row" runat="server" id="part_f" visible="false">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Party Address :</label>
                                <div class="col-sm-7">
                                    <%--<asp:TextBox runat="server" CssClass="form-control" ID="txtPartyAddress" TextMode="MultiLine" />--%>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPartyAddress" />
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Credit Limit :</label>
                                <div class="col-sm-7">
                                    <%--<asp:TextBox runat="server" CssClass="form-control" ID="txtPartyAddress" TextMode="MultiLine" />--%>
                                    <asp:TextBox runat="server" CssClass="form-control onlyFloat" ID="txtcreditlmt" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row" runat="server" id="Div7">
                        <div class="col-sm-2"></div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                   <label class="col-sm-5 control-label">Major Area of Economic Activity :</label>
                                <div class="col-sm-7">
                                   <asp:DropDownList ID="drpTypeofBusiness" runat="server" ReadOnly="true" class="form-input" Height="20px"
                                    data-toggle="dropdown" Visible="false">
                                </asp:DropDownList>
                                <asp:Panel ID="Panel1" runat="server" CssClass="PnlDesign">
                                    <asp:CheckBoxList ID="chklistTypeofBusiness" runat="server" OnSelectedIndexChanged="chklistTypeofBusiness_Changed"
                                        AutoPostBack="true" Style="width: 100%" RepeatDirection="Horizontal" RepeatColumns="2">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Party Code :</label>
                                <div class="col-sm-7">
                                    <%--<asp:TextBox runat="server" CssClass="form-control" ID="txtPartyAddress" TextMode="MultiLine" />--%>
                                    <asp:TextBox runat="server" CssClass="form-control onlyFloat" ID="txtPartyCode" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Upazila :</label>
                                <div class="col-sm-7">
                                    <%--<asp:TextBox runat="server" CssClass="form-control" ID="txtPartyAddress" TextMode="MultiLine" />--%>
                                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="drpUpazila"> </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4" id="divAreaOfMfg" runat="server" Visible="False">
                            <div class="form-group form-group-sm">
                               <label class="col-sm-5 control-label">Area of Manufacturing :</label>
                                <div class="col-sm-7">
                                     <asp:DropDownList runat="server" CssClass="form-control" ID="drpAreaOfMfg" />
                                </div>
                            </div>
                        </div>
                        
                       <%-- <div class="col-sm-2"></div>--%>
                    </div>
                   
                    <div class="row" runat="server" id="part_e" visible="false">
                        <div class="col-sm-2"></div>
                        <div class="col-md-2">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-10 control-label">VDS Deducted :</label>
                                <div class="col-sm-2">
                                    <asp:CheckBox runat="server" ID="chkVDS" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-10 control-label">Excise Duty :</label>
                                <div class="col-sm-2">
                                    <asp:CheckBox runat="server" ID="chkExciseDuty" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-10 control-label">Development Surcharge :</label>
                                <div class="col-sm-2">
                                    <asp:CheckBox runat="server" ID="chkDevelopmentSurCharge" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-10 control-label">Information Technology :</label>
                                <div class="col-sm-2">
                                    <asp:CheckBox runat="server" ID="chkInformationTechology" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    <div class="row" runat="server" id="Div2" visible="false">
                        <div class="col-sm-2"></div>
                        <div class="col-md-2">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-10 control-label">Health Safety? :</label>
                                <div class="col-sm-2">
                                    <asp:CheckBox runat="server" ID="chkHealthSafety" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-10 control-label">Environment Safety? :</label>
                                <div class="col-sm-2">
                                    <asp:CheckBox runat="server" ID="chkEnvironmentSafety" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                        <div class="col-sm-2"></div>
                        <div class="col-sm-2"></div>
                    </div>
                    <div class="row" runat="server" id="part_g" visible="false">
                        <div class="col-sm-4"></div>
                        <div class="col-sm-6">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
                            <asp:Button ID="btnShow" runat="server" CssClass="btn-btn" Style="background-color:#5CB85C;" Text="Show all Party" OnClick="btnShow_Click" />
                            <asp:Button ID="btnRefresh" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;" Text="Refresh" OnClick="btnRefresh_Click" />
                             <%--<asp:Button ID="btnBack" runat="server" CssClass="btn-btn" Style="background-color:#4CAF50;" Text="Back" OnClick="btnRefresh_Click" />--%>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    <div class="row" runat="server" id="part_h" visible="false">
                        <div class="col-sm-3"></div>
                        <div class="col-md-6">
                            <asp:FileUpload ID="FileUpload1" runat="server" Style="background: #E0EBF5" />
                            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload and Check" CssClass="btn btn-primary btn-sm" />
                            <asp:Label ID="Label11" runat="server"></asp:Label>
                            <asp:Button ID="btnExcelSave" runat="server" OnClick="btnExcelSave_Click" Text="Save" CssClass="btn btn-primary btn-sm" Style="background-color:#4CAF50;"/>
                        </div>
                        <div class="col-sm-3"></div>
                    </div>
                
                    <br/>
                    <br/>
                
                    <div class="row">
                        <div class="col-md-4 col-md-offset-4">
                            <div class="col-sm-6">
                                <asp:RadioButton runat="server" ID="chkManualInput" Text="  Manual Input" GroupName="party" OnCheckedChanged="chkManualInput_OnCheckedChanged" AutoPostBack="true" Checked="true" />
                            </div>
                            <div class="col-sm-6">
                                <asp:RadioButton runat="server" ID="chkExcelImport" Text="  Import from Excel" GroupName="party" OnCheckedChanged="chkExcelImport_OnCheckedChanged" AutoPostBack="true" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-body">
                    <div class="wrapper1">
                        <div class="div1"></div>
                    </div>
                    <div class="wrapper2">
                    <div class="div2">
                    <asp:GridView ID="gvExcelFile" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid"
                            DataKeyNames="PartyID" Width="100%" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" OnRowDataBound="gvExcelFile_OnRowDataBound" >
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="rowNo" Value='<%# Eval("rowNo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    </div>

                </div>
            </div>

            <div class="panel panel-primary" visible="false" id="partyDetailsDiv" runat="server">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 id="partyHeader" runat="server"></h4>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <b>Party Name :</b>
                            <span id="detailsPartyName" runat="server">N/A</span>
                        </div>
                        <div class="col-md-12">
                            <b>Party Address :</b>
                            <span id="detailsPartyAddress" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Party BIN :</b>
                            <span id="detailsPartyTin" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>NID :</b>
                            <span id="detailsPartyNid" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Owner Name :</b>
                            <span id="detailsOwnerName" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Business Type :</b>
                            <span id="detailsBusinessType" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Phone :</b>
                            <span id="detailsPhone" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Email :</b>
                            <span id="detailsEmail" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Web :</b>
                            <span id="detailsWeb" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Major Area of Economic Activity :</b>
                            <span id="detailsMajorAreaOfEcnActivity" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Vendor :</b>
                            <span id="detailsVendor" runat="server">N/A</span>
                        </div>
                        <div class="col-md-3">
                            <b>Customer :</b>
                            <span id="detailsCustomer" runat="server">N/A</span>
                        </div>
                    </div>
                </div>
            </div>
             <div class="panel panel-primary">
                <div class="panel-body">
                   <div class="col-md-6">
                                    <div class="form-group form-group-sm">                                        
                                        <label class="col-sm-5 control-label text-right">Party Name :</label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList ID="drpParty" runat="server" CssClass="form-control select2">
                                            </asp:DropDownList>
                                           
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" runat="server" CssClass="btn-btn" Style="background-color:#3B7CB5;" OnClick="btnSearch_Click" Text="Search" />
                                        </div>
                                    </div>
                                </div>
                    
                 </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-body">
                    <div class="">
                        <asp:GridView ID="gvShowParty" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid"
                            DataKeyNames="party_id" Width="100%"
                            OnSelectedIndexChanged="gvItem_SelectedIndexChanged"
                            OnRowDeleting="gvItem_RowDeleting"
                            OnRowDataBound="gvShowParty_RowDataBound"
                            OnRowCommand="gvShowParty_RowCommand"
                            HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                            AllowPaging="true" PageSize="10" OnPageIndexChanging="gvShowParty_PageIndexChanging">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                <asp:BoundField DataField="party_id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                                <asp:BoundField HeaderText="Party Name" DataField="party_name" />
                                <asp:BoundField HeaderText="Party Address" DataField="party_address" />
                                <asp:BoundField HeaderText="Party BIN" DataField="party_bin" />
                                <asp:BoundField HeaderText="Owner Name" DataField="owner_name" />
                                <asp:BoundField HeaderText="Phone" DataField="phone" />
                                <asp:BoundField HeaderText="VDS" DataField="is_vds_deduct" />
                                <asp:BoundField HeaderText="Vendor" DataField="is_vendor" />
                                <asp:BoundField HeaderText="Customer" DataField="is_customer" />
                                <asp:BoundField HeaderText="Importer" DataField="is_importer" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Details" runat="server" CommandName="Details" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

         <asp:Panel ID="pnYesNoModal" runat="server" Width="700" CssClass="modal_custom" BorderWidth="2px" BorderColor="Blue">
    <%--<asp:Panel ID="pnYesNoModal" runat="server" CssClass="input-table col-md-5 center paddinglrb popupBlock" Visible="false">--%>
        <div class="panel panel-primary panel-primary-custom">
            <div class="panel-heading panel-heading-custom">
                <div class="col-md-6 col-sm-6 col-xs-12"><h4 style="float:left">Confirmation</h4></div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:Button ID="btnOK" runat="server" Text="Reload" Style="background-color: #4CAF50" class="btn-btn" OnClick="btnOkToReload" />
                    <asp:Button ID="btnNoCancel" runat="server" Text="Cancel" Style="background-color: #4CAF50" class="btn-btn" OnClick="btnCancelToSaveInvoice "/>
                    <asp:HiddenField ID="deletedParty"  runat="server"/>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class='panel-body'>
                <div id="div_model_content">
                    <b><asp:Label ID="lblMessage" runat="server" Text="This party already exists in deleted state. Do you want to reload it?"></asp:Label></b>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnHideButton" runat="server" Text="Close" CssClass="hide"  />
    
    <ajaxToolkit:ModalPopupExtender ID="mpeYesNoModal" runat="server" 
        PopupControlID="pnYesNoModal" TargetControlID="btnHideButton" BackgroundCssClass="mpBack">
    </ajaxToolkit:ModalPopupExtender>
<%--    <uc1:MsgBox runat="server" id="msgBox" />--%>
    <uc1:MsgBoxs runat="server" id="msgBox" />
</asp:Content>


