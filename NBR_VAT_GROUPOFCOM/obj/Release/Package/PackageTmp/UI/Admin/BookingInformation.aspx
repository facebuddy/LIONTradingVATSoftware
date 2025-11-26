<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="BookingInformation, App_Web_z1w3wddp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <style>
        .mmm{
            background:#808080;
            text-align:center;
            font-weight:bold; 
            font-size:15pt; 
            color:#fff
        }
    </style>
    <script>
        function timeSetup(id) {
            var current = new Date();
            var ampm = current.getHours() > 12 ? "PM" : "AM";
            var date = id.value + '  ' + current.getHours() + ":" + current.getMinutes() + ":" + current.getSeconds() + " " + ampm;
            id.value = date;
        }
    </script>
     <script type="text/javascript">
         function Confirm(msg) {
             if (confirm("Are you sure? "+msg) == true)
                 return true;
             else
                 return false;
         }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="panel-group">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="text-align: center; font-size: 15px; font-weight: bold;">Room Booking Information Setup</div>
                        <div class="panel-body">
                            <fieldset class="scheduler-border" runat="server" id="master">
                                <legend class="scheduler-border">Master Information</legend>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Customer Name :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList runat="server" ID="ddlCustomerName" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Register No :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbRegisterBookNumber" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Room No :</label>
                                            <div class="col-sm-7">
                                                <%--<asp:DropDownList runat="server" ID="ddlHotelRoomNo" CssClass="form-control" />--%>
                                                <asp:TextBox runat="server" ID="tbRoomNo" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Room Rate :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbHotelRoomRate" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">No Of Person :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbNoOfPerson" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">No Of Days :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbNoOfStayDays" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">No Of XPerson :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbNoOfExtraPerson" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">XPerson Bill (Daily) :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbXpersonBillDaily" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Special Discount :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbSpecialDiscount" CssClass="form-control" placeholder="write percent(%) (exmp: 10)" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Check in DateTime :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbCheckInDT" CssClass="form-control" onchange="timeSetup(this)" />
                                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="tbCheckInDT" Format="dd/MM/yyyy" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Check out DateTime :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbCheckOutDT" CssClass="form-control" onchange="timeSetup(this)"/>
                                                <ajaxToolkit:CalendarExtender runat="server" ID="ace2" TargetControlID="tbCheckOutDT" Format="dd/MM/yyyy" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                       <%--<asp:Button ID="btnDaysExtends" runat="server" Style="float: right" CssClass="btn btn-primary btn-sm" Text="Day Extend" OnClick="btnDaysExtends_Click"  />--%>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="scheduler-border" runat="server" id="detail">
                                <legend class="scheduler-border">Details Information (Person)</legend>
                                <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Person Name :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbPersonName" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Person Address :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbPersonAddress" CssClass="form-control" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Purpose of Visit :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbVisitPurpose" CssClass="form-control" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Mobile No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbMobileNo" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">NID No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbNID" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Passport No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbPassportNo" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Gender :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="ddlGender" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Religion :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="ddlReligion" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Country :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Nationality :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbNationality" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Age :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbAge" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Comming From :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbCommingFrom" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Flight/Vehicle Type :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbVehicleType" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Flight/Vehicle No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="tbVehicleNo" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnSave" runat="server" Style="float: right" CssClass="btn btn-primary btn-sm" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnClear" runat="server" Style="float: right; margin-right: 1px" CssClass="btn btn-danger btn-sm" Text="Clear" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnRefresh" runat="server" Style="float: right; margin-right: 1px" CssClass="btn btn-success btn-sm" Text="Refresh" OnClick="btnRefresh_Click" />
                                    <asp:Button ID="btnAddRow" runat="server" Style="float: right; margin-right: 1px" CssClass="btn btn-info btn-sm" Text="Add" OnClick="btnAddRow_Click" />
                                </div>
                            </div>
                            </fieldset>
                            <div class="row" runat="server" id="extendedDiv">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-4">
                                     <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Extended Days :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="tbExtendedDays" CssClass="form-control" />
                                                <asp:HiddenField runat="server" ID="hfBookingID" />
                                            </div>
                                        </div>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnDaysExtends" runat="server" Style="float: left" CssClass="btn btn-primary btn-sm" Text="Extends" OnClick="btnDaysExtends_Click" />
                                </div>
                                <div class="col-sm-3"></div>
                            </div>

                            


                            <div class="row" style="margin-top: 1%">
                                <asp:GridView ID="gvPersonList" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" CellPadding="3" CellSpacing="2"
                                    DataKeyNames="RowNo" Width="100%" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager"
                                    OnRowDeleting="gvPersonList_RowDeleting">
                                    <Columns>
                                        <asp:BoundField HeaderText="Name" DataField="PersonName" />
                                        <asp:BoundField HeaderText="Address" DataField="PersonAddress" />
                                        <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
                                        <asp:BoundField HeaderText="Gender" DataField="Gender" />
                                        <asp:BoundField HeaderText="Religion" DataField="Religion" />
                                        <asp:BoundField HeaderText="Come From" DataField="CommingFrom" />
                                        <asp:CommandField HeaderText="Remove" ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <uc2:MsgBox ID="msgBox" runat="server" />
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            <div class="row mmm">
                                <p>Booking Information</p>
                            </div>
                            <div class="row">
                                <asp:GridView ID="gvBookingList" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" CellPadding="3" CellSpacing="2"
                                    DataKeyNames="booking_id" Width="100%" HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager">
                                    <Columns>
                                        <asp:BoundField HeaderText="Room No" DataField="room_no" />
                                        <asp:BoundField HeaderText="Register No" DataField="register_no" />
                                        <asp:BoundField HeaderText="No of Days" DataField="no_of_days" />
                                        <asp:BoundField HeaderText="No of Person" DataField="no_of_person" />
                                        <asp:BoundField HeaderText="Check Out Date" DataField="check_out_datetime" />
                                        <asp:BoundField HeaderText="Customer" DataField="customer_name" />
                                        <asp:BoundField HeaderText="Mobile" DataField="customer_mobile" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" ID="lbCancelButton" OnClick="lbCancelButton_Click"
                                                     Text="Cancel" ForeColor="Black" CommandArgument='<%# Eval("booking_id") %>' OnClientClick="return Confirm(' You Want to Cancel this Booking.');" ></asp:LinkButton>
                                                |
                                                <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" ID="lbExtenndButton" OnClick="lbExtenndButton_Click" Text="Day Extend" ForeColor="Black" CommandArgument='<%# Eval("booking_id") %>'></asp:LinkButton>
                                                |
                                                <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="lbCheckOutButton" OnClick="lbCheckOutButton_Click"
                                                     Text="Check Out" ForeColor="Black" CommandArgument='<%# Eval("booking_id") %>' OnClientClick="return Confirm(' You Want to Checkout this Booking.');"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:CommandField HeaderText="" ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
