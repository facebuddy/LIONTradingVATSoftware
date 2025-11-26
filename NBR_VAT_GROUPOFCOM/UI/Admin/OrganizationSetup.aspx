<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_OrganizationSetup, App_Web_bxnrqbtx" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../../Styles/panel.css" />
    <link href="../../Styles/Box_Border.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .style2 {
            width: 80%;
        }

        .style3 {
            width: 32%;
        }
    </style>
    <script type="text/javascript">
        function FormatIt(obj) {


            if (obj.value.length == 2) // Day
                obj.value = obj.value + "/";
            if (obj.value.length == 5) // month
                obj.value = obj.value + "/";
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }



        function isAlfa(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   

        <div class="container-fluid">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-family: Tahoma; font-size: 18px; font-weight: bold; height: 30px; padding-top: 0px">
                    <b>Organization Setup</b>
                </div>
                <div class="col-md-12">
                      <label style="color: #005ce6"> Organization Setup</label>
                  </div>
                  <br />
                <div class="row">
                     <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Master Organization:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpOrganizationID" runat="server" class="form-input select2" AutoPostBack="true">
                                            
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                    <div class="col-md-4">
                        <div class="form-group form-group-sm">

                            <label class="col-sm-5 control-label text-right"><span class="required">* </span>Organization Name:</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" type="text"
                                    class="form-input" ID="txtCompName" placeholder="Enter Name" onkeypress="return isAlfa(event)"></asp:TextBox>
                            </div>

                        </div>

                    </div>
                    
                       <div class="col-md-4">
                        <div class="form-group form-group-sm">

                            <label class="col-sm-5 control-label text-right"><span class="required">* </span>Organization BIN:</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" type="text"
                                    class="form-input" ID="txtOrbBIN" placeholder="Enter BIN"></asp:TextBox>
                            </div>

                        </div>

                    </div>
                  
                </div>                
                <div class="row">  
                     <div class="col-md-4">
                        <div class="form-group form-group-sm">

                            <label class="col-sm-5 control-label text-right"><span class="required">* </span>Business Type Name:</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" type="text"
                                    class="form-input" ID="txtbuTypeName" placeholder="Enter Business Type Name" onkeypress="return isAlfa(event)"></asp:TextBox>
                            </div>

                        </div>

                    </div>
                      <div class="col-md-4">
                        <div class="form-group form-group-sm">

                            <label class="col-sm-5 control-label text-right"><span class="required">* </span>Economic Process Activity:</label>
                            <div class="col-sm-7">
                                <asp:TextBox runat="server" type="text"
                                    class="form-input" ID="txtEcoAct" placeholder="Enter Name" onkeypress="return isAlfa(event)"></asp:TextBox>
                            </div>

                        </div>

                    </div>

                </div>
                <div class="row">
                             <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color: #005ce6"> CONTACT INFORMATION</label>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>Factory/Business Operations Address :</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtregaddress" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div>
                                                <div class="col-md-6">
                                                    <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>e-Mail:</asp:label>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox ID="txt_Email" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>District:</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList ID="drpDistrict" runat="server" class="form-control select2" AutoPostBack="True" onselectedindexchanged="drpBranchDistrict_SelectedIndexChanged1">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">Fax Number (if any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txt_Fax" runat="server" class="form-control onlyMobile" MaxLength="15" data-error="txt_FaxErrmsg"></asp:TextBox>
                                                    <span id="txt_FaxErrmsg" style="color:red"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>Police Station:</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList ID="drpThana" runat="server" class="form-control select2" data-toggle="dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div>
                                                <div class="col-md-6">
                                                    <asp:label runat="server" class="control-label col-sm-5">Web Address (if any):</asp:label>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox ID="txt_Website" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>Post Code:</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:DropDownList ID="drpPostCode" runat="server" class="form-control select2"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">Registered HQ Address [If different than address of D1](If any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="hqaddress" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-1">
                                                    <asp:CheckBox ID="isD10sameAsD1" runat="server" AutoPostBack="true" ToolTip="Check if same as D1" OnCheckedChanged="isD10sameAsD1_CheckedChanged" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">Land Telephone Number (if any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txtLand_Phone_no1" runat="server" class="form-control onlyMobile" data-error="txtLand_Phone_no1Msg" MaxLength="15"></asp:TextBox>
                                                    <span id="txtLand_Phone_no1Msg" style="color:red;"></span>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5">Registered HQ Address outside Bangladesh[for 100% foreign ownership](if any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="registered" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:label runat="server" class="control-label col-sm-5"><span class="required" style="color:red"> * </span>Mobile Telephone Number (if any):</asp:label>
                                                <div class="col-sm-6">
                                                    <asp:TextBox ID="txt_Mobile_no1" runat="server" class="form-control onlyMobile" MaxLength="11" data-error="txt_Mobile_no1Errmsg"></asp:TextBox>
                                                    <span id="txt_Mobile_no1Errmsg" style="color:red"></span>
                                                </div>
                                            </div>
                                            <div runat="server" visible="false"> 
                                                <div class="col-md-6">
                                                    <asp:label runat="server" class="control-label col-sm-5">HQ Address outside Bangladesh[for 100% foreign ownership](if any):</asp:label>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox ID="hqforeign" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>                  

                               </div> 
                <div class="row">
                     <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color: #005ce6"> LIST OF BRANCH UNITS YOU WISH TO BRING UNDER CENTRAL REGISTRATION</label>
                                        </div>
                                        <br />
                                        <div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label34" CssClass="col-sm-5 control-label text-right" runat="server" Text=""><span class="required" style="color:red"> * </span>Branch Address:</asp:Label>
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label36" runat="server" Text="" class="col-sm-5 control-label text-right"><span class="required" style="color:red"> * </span>Branch Name:</asp:Label>
                                                    <div class="col-sm-7 " style="padding:0px">
                                                        <asp:TextBox ID="txtBranch" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label42" runat="server" Text="Category:" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtCtg" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label43" runat="server" Text="Annual Turnover:" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtTurnover" runat="server" class="form-control onlyFloat" MaxLength="12" data-error="txtTurnoverErrmsg"></asp:TextBox>
                                                        <span id="txtTurnoverErrmsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label2" runat="server" Text="BIN (If any):" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7" style="padding:0px">
                                                        <asp:TextBox ID="txtBIN" runat="server" class="form-control onlyNumber" MaxLength="13" data-error="txtBINMsg"></asp:TextBox>
                                                        <span id="txtBINMsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:HiddenField runat="server" ID="gveconomicIndex"/>
                                                <asp:Button ID="btneconomic" class="btn-btn" Style="background-color:#05f1f5;color:black;float: right" runat="server" Text="Add" OnClick="btnbranch_Click" CausesValidation="False" />
                                                <asp:Button ID="btneconomicUpdate" class="btn btn-info btn-sm" Style="float: right" runat="server" Text="Update" OnClick="btneconomicUpdate_OnClick" CausesValidation="False" Visible="False" />
                                            </div>
                                        </div>
                                        
                                    </div>                      
                     <div class="container-fluid">
                                        <div class="col-md-12">
                                            <label style="color:#3366cc">AUTHORIZED PERSONS INFORMATION FOR ONLINE ACTIVITY</label>
                                        </div>
                                        <br />
                                        <div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label68" CssClass="col-sm-5 control-label text-right" runat="server" Text="Name" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label69" runat="server" Text="Designation" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7 ">
                                                        <asp:TextBox ID="txtdesignation" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label70" runat="server" Text="NID" class="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtnid" runat="server" class="form-control onlyNumber" MaxLength="18" data-error="txtnidMsg"></asp:TextBox>
                                                        <span id="txtnidMsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label71" runat="server" Text="Mobile No" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control onlyMobile" MaxLength="11" data-error="txtmobileMsg"></asp:TextBox>
                                                        <span id="txtmobileMsg" style="color:red"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label72" runat="server" Text="E-mail" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <asp:Label ID="label73" runat="server" Text="Purpose" CssClass="col-sm-5 control-label text-right" />
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="txtpurpose" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:HiddenField runat="server" ID="gvAuthorizePersonIndex"/>
                                                <asp:Button ID="btnauthPerson" class="btn-btn" Style="background-color:#05f1f5;color:black; float: right;margin-right:15px" runat="server" Text="Add" OnClick="btnauthPerson_Click" />
                                                <asp:Button ID="btnauthPersonUpdate" class="btn btn-info btn-sm" Style="float: right;margin-right:15px" runat="server" Text="Update" OnClick="btnauthPersonUpdate_OnClick" Visible="False" />
                                            </div>

                                            <asp:GridView ID="gveconomic" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gveconomic_OnSelectedIndexChanging" OnRowDeleting="gveconomic_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
                                                <asp:BoundField HeaderText="Branch Address" DataField="Org_branch_address" />
                                                <asp:BoundField HeaderText="Branch Name" DataField="Branch_unit_name" />
                                                <asp:BoundField HeaderText="Category" DataField="Branch_reg_category" />
                                                <asp:BoundField HeaderText="Annual Turnover" DataField="Branch_turnover" />
                                                <asp:BoundField HeaderText="BIN (If any)" DataField="Branch_unit_bin" />
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
                                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                            <%-- <EmptyDataTemplate>
                                                No Items Found.
                                            </EmptyDataTemplate>--%>
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                                            <asp:GridView ID="gvAuthorizePerson" runat="server" AutoGenerateColumns="False" CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" OnSelectedIndexChanging="gvAuthorizePerson_OnSelectedIndexChanging" OnRowDeleting="gvAuthorizePerson_RowDeleting" OnRowDataBound="gvAuthorizePerson_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Name" DataField="Name" />
                                                    <asp:BoundField HeaderText="Designation" DataField="Designation" />
                                                    <asp:BoundField HeaderText="NID" DataField="NID" />
                                                    <asp:BoundField HeaderText="Mobile No" DataField="Mobile" />
                                                    <asp:BoundField HeaderText="E-mail" DataField="Email" />
                                                    <asp:BoundField HeaderText="Purpose" DataField="Purpose" />
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" />
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                                <%-- <EmptyDataTemplate>
                                                    No Items Found.
                                                </EmptyDataTemplate>--%>
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                     </div>
                <br />
                <div class="row">
                     <div class="col-md-12">
                        <asp:Button ID="btnsave" class="btn-btn" Style="background-color:#4CAF50;float: right;margin-right:15px" runat="server" Text="Save" OnClick="btnsave_Click" />
                     </div>
                 </div>
     </div>        
 </div>



    <div>

            <asp:GridView ID="gvorg" runat="server" AutoGenerateColumns="False"
                                    CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    
                onselectedindexchanged="gvorg_SelectedIndexChanged"                
                onrowdatabound="gvorg_RowDataBound">
                                    <Columns>
                                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
                                          <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                        <asp:BoundField HeaderText="Organization Id" DataField="organization_id"/>
                                         <asp:BoundField HeaderText="Organization Name" DataField="organization_name"/>
                                        <asp:BoundField HeaderText="Organization BIN" DataField="registration_no" />
                                        <asp:BoundField HeaderText="Business Type Name" DataField="business_type_name" />
                                        <asp:BoundField HeaderText="Economic Process Activity" DataField="economic_process_activity_name" />
                                       <%-- <asp:BoundField HeaderText="Designation" DataField="designation_name" />
                                        <asp:BoundField HeaderText="Level" DataField="user_level_status" />
                                        <asp:BoundField HeaderText="Status" DataField="emplyee_status_detail" />--%>
                                       <%-- <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />--%>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle Height="25px" BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" ForeColor="#000066" />
                                    <%-- <EmptyDataTemplate>
                        No Items Found.
                    </EmptyDataTemplate>--%>
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>

    </div>
     <uc2:MsgBox ID="msgBox" runat="server" />  
</asp:Content>
