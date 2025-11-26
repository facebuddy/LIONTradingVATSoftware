
 <%@ page title="" theme="Theme1" language="C#" masterpagefile="~/LoginMasterPage.master" autoeventwireup="true" CodeBehind="Logins1.aspx.cs" Inherits="Logins" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .bkg {
            background-image: url('/Images/cbai.jpg');
            background-repeat: no-repeat;
            background-attachment: fixed;
        }
        /*mainDiv {
        background-image:url('/Images/cbai.jpg');
        background-repeat:no-repeat;
        background-attachment:fixed;
    }*/
        .mqmm{
            height:450px;
            width:100%;
            background-repeat:no-repeat;
        }
        .mqmm1{
            background-color: transparent;
            color: white;
            font-weight: bold;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">







     <div class="card">
							<div class="card-body">
								<div class="border p-4 rounded">
									
								
									<div class="login-separater text-center mb-4"> <span>OR SIGN IN WITH EMAIL</span>
										<hr/>
									</div>
									<div class="form-body">
										<div class="row g-3">
											<div class="col-12">
												<label for="inputEmailAddress" class="form-label">Email Address</label>
												  <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control mqmm1" placeholder="User Name"></asp:TextBox>
											</div>
											<div class="col-12">
												<label for="inputChoosePassword" class="form-label">Enter Password</label>
												<div class="input-group" id="show_hide_password">
													   <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mqmm1" placeholder="Password" TextMode="Password"></asp:TextBox>
                                                    <a href="javascript:;" class="input-group-text bg-transparent"><i class='bx bx-hide'></i></a>
												</div>
											</div>
											<div class="col-md-6">
												<div class="form-check form-switch">
                                                     <asp:Label ID="Label1" runat="server" CssClass="text-danger"></asp:Label>
													<input class="form-check-input" type="checkbox" id="flexSwitchCheckChecked" checked>
													<label class="form-check-label" for="flexSwitchCheckChecked">Remember Me</label>
												</div>
											</div>
											
											<div class="col-12">
												<div class="d-grid">
                                                 
													   <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" OnClick="btnLogin_Click" Text="Login" />
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>










</asp:Content>

