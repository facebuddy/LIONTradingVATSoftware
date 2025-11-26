<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_UserSetup_Add_User, App_Web_swbxplto" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
    <div class="row">
        <%--<fieldset class="scheduler-border">
            <legend class="scheduler-border">Add User</legend>--%>
            <div class="container-fluid">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="text-align: center; font-family:Tahoma; font-size:18px; font-weight: bold;
                height: 30px; padding-top: 0px">
                            <b>Add User</b>
                        </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">

                                    <label class="col-sm-5 control-label text-right"><span class="required">* </span>Employee Name:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text"
                                            class="form-input" ID="txtEmployeeName" placeholder="Enter Name" onkeypress="return isAlfa(event)"></asp:TextBox>
                                    </div>

                                </div>
                                <asp:Label runat="server" ID="EmployeeID" Visible="false" />
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Organization:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpOrganizationID" runat="server" class="form-input select2" AutoPostBack="true"
                                            OnSelectedIndexChanged="drpOrganizationID_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Branch:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpBranchInformation" runat="server" class="form-input select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">

                                    <label class="col-sm-5 control-label text-right">System User:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpIsSyatemUser" runat="server" class="form-control select2" AutoPostBack="true"
                                            OnSelectedIndexChanged="drpIsSyatemUser_SelectedIndexChanged"></asp:DropDownList>
                                    </div>

                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">User Level:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="DrpUserLevel" runat="server" class="form-control select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Employee Status:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="DrpEmployeeStatus" runat="server" class="form-control select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">

                                    <label class="col-sm-5 control-label text-right"><span class="required">* </span>Department:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpDepartment" runat="server" class="form-input select2" AutoPostBack="true" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>

                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Designation:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="drpDesignation" runat="server" class="form-control select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Joining Date:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtJoiningDate" placeholder="Enter Date" Format="dd/MM/yyyy"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtJoiningDate" />
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">

                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Retirement Date:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtRetirementDate" placeholder="Enter Retirement Date"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtRetirementDate" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Cell Phone:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtPhone" FilterType="Numbers" autocomplete="off" MaxLength="15" onkeypress="return isNumberKey(event)"
                                            placeholder="Enter Phone" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right">Email:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtEmail" autocomplete="off" MaxLength="100" placeholder="Enter Email" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                         <div class="row">

                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>NID:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtNID" placeholder="NID must be 10 or 17 digit." MaxLength="17"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Address:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text" class="form-input" ID="txtAddress" placeholder="Enter Address" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                               <div class="form-group form-group-sm">
                                      <label class="col-sm-5 control-label text-right"><span class="required">*</span>Upload Image:</label>
                                  <div class="col-sm-7">
                                        <asp:FileUpload id="FileUploadControl" AllowMultiple="true" Width="100%" style="border:groove;" runat="server" /> 
                                        <asp:Label runat="server" id="StatusLabel"  />
                                      <asp:Label runat="server" ID="path" Visible="false"></asp:Label>
                                  </div>
                               </div>
                               
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Login ID:</label>
                                    <div class="col-sm-7">
                                       <asp:TextBox runat="server"  type="text" class="form-input" ID="txtLoginID" placeholder="Enter Login ID" MaxLength="15"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Login Password:</label>
                                    <div class="col-sm-7">
                                         <asp:TextBox runat="server" type="text" class="form-input" ID="txtLoginPassword"  placeholder="Enter Password" MaxLength="25" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                                 <div class="col-md-4" runat="server" id="divImage" visible="false">   
                                                    <label class="col-sm-5 control-label text-right"></label>
                                    <div class="col-sm-7">
                                                        <asp:Image ID="Image1" runat="server" Height="100" Width="100" /><br />
                                                        
                                                          <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong">Preview</button>--%>

                                        </div>       
                                      </div>
                           
                        </div>
                        <div class="row"> 
                            <div class="col-md-12" style="text-align:right">
                               <asp:Button ID="btnSave" Width="100px"  CssClass="btn-btn" Style="background-color:#4CAF50;float: right;"
                                runat="server" Text="Save" Height="30px" onclick="btnSave_Click" />                            
                                <asp:Button ID="btnUpdate" Width="100px" Style="float: right" CssClass="btn btn-success"
                                runat="server" Text="Update" Height="30px" onclick="btnUpdate_Click" />
                            </div></div>
               </div>
                    
                </div>
                <!-- Modal -->
                                               <%-- <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" style="height:100%;width:100%">
                                                  <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                      <div class="modal-header">
                                                    
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                          <span aria-hidden="true">&times;</span>
                                                        </button>
                                                      </div>
                                                      <div class="modal-body">
                                                        <asp:Image ID="ImageP" runat="server" Height="700" Width="500" />
                                                      </div>
                                                      <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                     
                                                      </div>
                                                    </div>
                                                  </div>
                                                </div>--%>
                <%--<table style="width: 100%">
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Employee Name
                        </td>
                        <td class="style2">
                      <asp:TextBox runat="server" type="text" 
                                style = "width:80%; border-style:solid; height:34px; border-width:2px" 
                                class="form-input" ID="txtEmployeeName" placeholder="Enter Name" onkeypress="return isAlfa(event)"
                       Width="100%" MaxLength="49"></asp:TextBox>
                      <asp:Label runat="server" ID="EmployeeID" Visible="false" />
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            System User
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="drpIsSyatemUser" runat="server" style = "width:80%; border-style:solid; height:34px; border-width:2px" class="form-input" Width="100%">
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Login ID
                        </td>
                        <td class="style2">
                            <asp:TextBox runat="server" style = "width:80%; border-style:solid; height:34px; border-width:2px" type="text" class="form-input" ID="txtLoginID" placeholder="Enter Login ID"
                               Width="100%" MaxLength="15"></asp:TextBox>
                        </td>
                       
                    </tr>
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Login Password
                        </td>
                        <td class="style2">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtLoginPassword"
                                Width="100%" placeholder="Enter Password" MaxLength="25"  style = "width:80%; border-style:solid; height:34px; border-width:2px"
                                TextMode="Password"></asp:TextBox>

                        </td>
                       
                    </tr>

                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Organization
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="drpOrganizationID" runat="server" 
                                style = "width:80%; border-style:solid; height:34px; border-width:2px" 
                                class="form-input" Width="100%" AutoPostBack = "true" 
                                onselectedindexchanged="drpOrganizationID_SelectedIndexChanged">
                            </asp:DropDownList>
                                
                        </td>
                    </tr>

                     <tr>
                        <td style="padding-left: 30px" class="style3">
                            Branch
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="drpBranchInformation" runat="server" style = "width:80%; border-style:solid; height:34px; border-width:2px" class="form-input" Width="100%">
                            </asp:DropDownList>
                                
                        </td>
                    </tr>


                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Department
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="drpDepartment" runat="server" style = "width:80%; border-style:solid; height:34px; border-width:2px" class="form-input" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Designation
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="drpDesignation" runat="server" style = "width:80%; border-style:solid; height:34px; border-width:2px" class="form-input" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            User Level
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="DrpUserLevel" runat="server" style = "width:80%; border-style:solid; height:34px; border-width:2px" class="form-input" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Employee Status
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="DrpEmployeeStatus" 
                            style = "width:80%; border-style:solid; height:34px; border-width:2px" runat="server" class="form-input" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Joining Date
                        </td>
                        <td class="style2">
                   
                    <asp:TextBox runat="server" type="text" class="form-input" ID="txtJoiningDate" placeholder="Enter Date" 
                        style = "width:80%; border-style:solid; height:34px; border-width:2px" Width="100%" Format="dd/MM/yyyy"></asp:TextBox>
                            
                    <ajaxToolkit:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="txtJoiningDate"/>
                 
                        </td>
                       
                    </tr>
                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Retirement Date
                        </td>
                        <td style="width: 69%;">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtRetirementDate"
                                   style = "width:80%; border-style:solid; height:34px; border-width:2px" placeholder="Enter Retirement Date" Width="100%" ></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtRetirementDate"/>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-left: 30px" class="style3">
                            Email
                        </td>
                        <td style="width: 69%;">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtEmail"
                                   style = "width:80%; border-style:solid; height:34px; border-width:2px" 
                                autocomplete="off" MaxLength="100"
                                placeholder="Enter Email" Width="100%" ></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-left: 30px" class="style3">
                          Cell Phone
                        </td>
                        <td style="width: 69%;">
                            <asp:TextBox runat="server" type="text" class="form-input" ID="txtPhone" 
                                   style = "width:80%; border-style:solid; height:34px; border-width:2px" 
                                autocomplete="off" MaxLength="15"  onkeypress="return isNumberKey(event)"
                                placeholder="Enter Phone" Width="100%" ></asp:TextBox>
                               
                        </td>
                       
                    </tr>

                    <tr>
                        <td style="padding-left: 30px" class="style3">
                        </td>
                        <td style="width: 89%; text-align: right">
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="style3" >
                        </td>

                        <td style="width: 70%; text-align: left">
                            <asp:Button ID="btnSave" Width="120px" Style="float: right" class="mktdr-btn-success"
                                runat="server" Text="Save" Height="30px" onclick="btnSave_Click" />
                            <asp:Button ID="btnUpdate" Width="120px" Style="float: right" class="mktdr-btn-success"
                                runat="server" Text="Update" Height="30px" onclick="btnUpdate_Click" />
                        </td>
                    </tr>
                </table>--%>
                 <div style = "width:auto; padding-left:3%";">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <uc2:MsgBox ID="msgBox" runat="server" />
                </div>
               <div style = "width:auto; padding-left:3%; color :Red";">
                 <asp:Label ID="lblSave" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                </div>
                
            </div>



            <asp:GridView ID="gvUserDetail" runat="server" AutoGenerateColumns="False"
                                    CssClass="sGrid" Width="100%" Style="width: 95.5%; margin-left: 29px" 
                    BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    
                onselectedindexchanged="gvUserDetail_SelectedIndexChanged" 
                onpageindexchanging="gvUserDetail_PageIndexChanging" 
                onrowdeleting="gvUserDetail_RowDeleting" PageSize="15" 
                onrowdatabound="gvUserDetail_RowDataBound">
                                    <Columns>
                                        <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" SelectImageUrl="~/Images/Ok.gif"
                            ShowSelectButton="True" />--%>
                                          <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True" />
                                        <asp:BoundField HeaderText="Employee ID" DataField="employee_id"/>
                                        <asp:BoundField HeaderText="Login ID" DataField="login_id" />
                                        <asp:BoundField HeaderText="Name" DataField="employee_name" />
                                        <asp:BoundField HeaderText="Department Name" DataField="department_name" />
                                        <asp:BoundField HeaderText="Designation" DataField="designation_name" />
                                        <asp:BoundField HeaderText="Level" DataField="user_level_status" />
                                        <asp:BoundField HeaderText="Status" DataField="emplyee_status_detail" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
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
                                        
       <%-- </fieldset>--%>

          
                <%-- <div style = "width:auto; padding-left:3%";">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="litMessage"
                       ControlToValidate="txtEmployeeName" ErrorMessage="Employee Name is required."
                       SetFocusOnError="True" ></asp:RequiredFieldValidator>
                  </div>
                 <div style = "width:auto; padding-left:3%";">

                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="litMessage"
                       ControlToValidate="txtLoginID" ErrorMessage="Login Id is required. "
                       SetFocusOnError="True" ></asp:RequiredFieldValidator>
                  </div>
                 <div style = "width:auto; padding-left:3%";">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="litMessage"
                       ControlToValidate="txtLoginPassword" ErrorMessage="Login password is required. "
                       SetFocusOnError="True" ></asp:RequiredFieldValidator>
                  </div>
                 <div style = "width:auto; padding-left:3%";">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="litMessage"
                       ControlToValidate="txtJoiningDate" ErrorMessage="Joining date is required. "
                       SetFocusOnError="True" ></asp:RequiredFieldValidator>
                  </div>
                 <div style = "width:auto; padding-left:3%";">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="litMessage"
                    ControlToValidate="txtEmail" ErrorMessage="Email is required"
                        SetFocusOnError="True" ></asp:RequiredFieldValidator>
                 
                 </div>
                 <div style = "width:auto; padding-left:3%";">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="litMessage"
                       ControlToValidate="txtPhone" ErrorMessage="Phone is required. "
                       SetFocusOnError="True" ></asp:RequiredFieldValidator>
                  </div>
                 <div style = "width:auto; padding-left:3%";">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtJoiningDate"
                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                        ErrorMessage="Invalid date format in Joining Date." CssClass="litMessage" />
                </div>
                 <div style = "width:auto; padding-left:3%";">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRetirementDate"
                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                        ErrorMessage="Invalid date format in Retirement Date." CssClass="litMessage" />
                </div>
                 <div style = "width:auto; padding-left:3%";">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
             ErrorMessage="Invalid Email" ControlToValidate="txtEmail"
             SetFocusOnError="True"
             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="litMessage">
                        </asp:RegularExpressionValidator>
                        </div>--%>
                
    </div>
   
</asp:Content>
