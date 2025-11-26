<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_OrganizationManagementSetup, App_Web_z1w3wddp" %>

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
                            <b>Organization Management Setup</b>
                        </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">

                                    <label class="col-sm-5 control-label text-right"><span class="required">* </span>Master Organization Name:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text"
                                            class="form-input" ID="txtOrgName" placeholder="Enter Name" onkeypress="return isAlfa(event)"></asp:TextBox>
                                    </div>

                                </div>
                              
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>BIN Type:</label>
                                    <div class="col-sm-7">
                                         <asp:RadioButtonList ID="chkBinType" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                         <asp:ListItem Text="Single BIN" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="Multi BIN"  Value="0"></asp:ListItem>
                                         </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">
                                    <label class="col-sm-5 control-label text-right"><span class="required">*</span>Admin User Type:</label>
                                    <div class="col-sm-7">
                                         <asp:RadioButtonList ID="chkAdminType" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                         <asp:ListItem Text="Single Admin" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="BIN wise Admin"  Value="0"></asp:ListItem>
                                         </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                             
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group form-group-sm">

                                    <label class="col-sm-5 control-label text-right"><span class="required">* </span>Number of User:</label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" type="text"
                                            class="form-input" ID="txtNoofUser"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                            runat="server" Enabled="True" TargetControlID="txtNoofUser"
                                            ValidChars="0123456789">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>

                                </div>

                            </div>
                             <div class="col-md-4">
                              
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn-btn" Style="background-color: #4CAF50;" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                       
                    </div>

                </div>


                <div style = "width:auto; padding-left:3%";">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <uc2:MsgBox ID="msgBox" runat="server" />
                </div>
               <div style = "width:auto; padding-left:3%; color :Red";">
                 <asp:Label ID="lblSave" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                </div>
                
            </div>



           
                
    </div>
   
</asp:Content>

