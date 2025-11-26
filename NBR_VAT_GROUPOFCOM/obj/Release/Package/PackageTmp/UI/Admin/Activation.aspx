<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Admin_Activation, App_Web_z1w3wddp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../Styles/panel.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
     <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
          <b>Current Active User: </b><asp:Label runat="server" id="totaluser" EnableViewState="false"></asp:Label>
        </div>
        <div class="panel-body">
            
                <legend>
                    <h3><b>Enter activation code</b></h3>
                    <p>Activation code format : XXXX-XXXX-XXXX-XXXX</p>
                </legend>

                <div class="form-group">
		
                    <label for="name" class="col-sm-4 control-label">User Name: </label>                       
		
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtUsername" runat="server" class="form-control"/>                      
			            
		            </div>
                    <div class="col-sm-2">
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                            runat="server" />
                    </div>
                    
	            </div>

                <div class="form-group">
		
                    <label for="orgname" class="col-sm-4 control-label">Organization Name : </label>                       
		
                    <div class="col-sm-4">
            
                        <asp:TextBox ID="txtOrgname" runat="server" class="form-control"/>                                              
			
		            </div>
                    <div class="col-sm-2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtOrgname"
                            runat="server" />         
                    </div>
                    
	            </div>

                <div class="form-group">
		
                    <label for="licensekey" class="col-sm-4 control-label">License Key : </label>                       
		
                    <div class="col-sm-4">
            
                        <asp:TextBox ID="txtLicensekey" runat="server" class="form-control"/>
                        
		            </div>

                    <div class="col-sm-2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtLicensekey"
                            runat="server" />         
                    </div>

	            </div>

                <div class="form-group">
		            <div class="col-sm-offset-4 col-sm-6">
                        <asp:Button class="btn btn-success btn-lg" ID="Button1" Text="Activate Now" runat="server" OnClick="Activate" />		
		            </div>
	            </div>

                <legend>
                                    
                </legend>
                <div class="raw">
                    No Activation code?<br />
                    If you do not have an activate code you can purchase
                    from license provider vendor.<br />
                    Please contact Technohaven Company Ltd. <br />

                    web:www.techonaven.com Ph:+(8802)-964-1266
                </div>
      </div>
    
</div>
<uc2:MsgBox ID="msgBox" runat="server" />
</asp:Content>