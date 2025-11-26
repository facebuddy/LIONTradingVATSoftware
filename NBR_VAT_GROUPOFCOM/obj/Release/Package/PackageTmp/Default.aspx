<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

    </div>

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
												<%--	<input class="form-check-input" type="checkbox" id="flexSwitchCheckChecked" checked>--%>
												<%--	<label class="form-check-label" for="flexSwitchCheckChecked">Remember Me</label>--%>
												</div>
                                                     <asp:Label ID="lblErrorMsg" runat="server" CssClass="text-danger"></asp:Label>
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


<%--         <p>
        KGCVAT is a comprehensive software application as per VAT and SD Act 2012 and underlying Rules from the National Board of Revenue (NBR), Bangladesh for automating the VAT processing and reporting obligations of large VAT paying companies. 
       The KGCVAT application takes care of all NBR required forms from Mushok 4.3 through Mushok 9.1 and the related reports. This specialized software application caters to all major industry categories in manufacturing, export, import and services.
   <br />
        <br />
        ভ্যাটপ্রম্পট (KGCVAT) সফটওয়্যারটি ভ্যাট ও এসডি আইন ২০১২ এবং তদাধীন জাতীয় রাজস্ব বোর্ডের বিধি অনুযায়ী তৈরি, যা বৃহৎ ভ্যাটপ্রদানকারী ব্যবসায়ী প্রতিষ্ঠান সমূহের ভ্যাট প্রদান সম্পর্কিত সমুদয় ব্যবস্থাপনা ও রিপোর্টিং-এর কার্যাদি স্বয়ংক্রিয়ভাবে সম্পাদন করে।
        মূসক ৪.৩ হতে ৯.১ পর্যন্ত এন.বি.আর.-এর যাবতীয় ফর্ম পূরন ও রিপোর্ট তৈরীর কাজ ভ্যাটপ্রম্পট  নির্বিঘ্নে করে দেয়। এই বিশেষায়িত সফটওয়্যার অ্যাপ্লিকেশন ম্যানুফ্যাকচারিং, রপ্তানী, আমদানী এবং সেবাসহ সকল ধরনের ব্যবসার জন্য প্রযোজ্য।
    </p>--%>



</asp:Content>
