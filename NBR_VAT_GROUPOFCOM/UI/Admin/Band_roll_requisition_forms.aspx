<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Band_roll_requisition_forms.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.UI.Admin.Band_roll_requisition_forms" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MsgBoxs.ascx" TagPrefix="uc1" TagName="MsgBoxs" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
   
  <%--   <link rel="stylesheet" href="/resources/demos/style.css">
    <link href="../../Styles/Main.css" rel="stylesheet" />
    <link href="../../Styles/Box_Border.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/str.css" rel="stylesheet" />
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/panel.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.4.4.min.js"></script>--%>
    <style type="text/css">
        .style1 {
            text-align: right;
        }

        .input_field {
            text-align: right;
        }

        .FixedHeader {
            position: fixed;
            font-weight: bold;
            text-align: center;
        }

        .grid_header {
            background-image: none;
            color: #000 !important;
            border: 1px solid #c9c9c9;
            font-family: arial,Helvetica,sans-serif;
            font-size: 15px;
            font-weight: 700;
            height: 20px;
            text-align: center;
        }

        .label {
            color: #000;
            font-size: 13px !important;
            font-family: arial,Helvetica,sans-serif;
        }
    </style>

    <script type="text/javascript">
        
    </script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=cpPrint.ClientID %>");
            var printWindow = window.open('', '', 'left=1,top=0,height=auto,width=auto,toolbar=0,scrollbars=1,status=0,dir=ltr');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />');
            //            printWindow.document.write('<link rel="stylesheet" type="text/css" href="../Styles/print.css" />');
            printWindow.document.write('</head>');
            printWindow.document.write('<body style="margin: 50px; font-family: "Times New Roman", Times, serif; font-size:18px">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="panel-group">
                    <div class="panel panel-primary">
                        
                        <div class="panel-heading" style="text-align: center;font-family:Tahoma; font-size:18px; font-weight: bold; height: 30px; padding-top: 0px">
                            Bandroll Requisition Form
                        </div>
                        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                            <div class="row" style="background-color: #FFD9C3; ">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Name :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="org_name" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Address :</label>
                                        <div class="col-sm-7 m">    
                                            <asp:Label ID="org_address" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. BIN :</label>
                                        <div class="col-sm-7 m">
                                            <asp:Label ID="lblOrgBIN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Name :</label>
                                        <div class="col-sm-7">
                                             <asp:DropDownList ID="drpBranchName" runat="server" OnSelectedIndexChanged="drpBranchName_SelectedIndexChanged" AutoPostBack="true"
                                            CssClass="form-control">
                                        </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch Address :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                   
                                     <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label text-right">Org. Branch BIN :</label>
                                        <div class="col-sm-7">
                                            <asp:Label ID="lblBranchBin" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            


                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                   <%--  <label class="col-sm-5 control-label">Challan No :</label>--%>
                                         <label ID="label211" class="control-label col-sm-5"><span class="required"> * </span>Reference No :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtRefNo" CssClass="form-control" Style="height: 27px" runat="server"  AutoPostBack="true"  PlaceHolder="Type Reference No." />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        <label class="col-sm-5 control-label">Reference Date :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtRefDate" Style="width: 50%; float: left" CssClass="form-control" runat="server" DateFormat="dd/MM/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtRefDate" />
                                            <asp:DropDownList ID="drpChDtHr" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                                            <asp:DropDownList ID="drpChDtMin" Style="width: 25%; float: left" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                       <%-- <label class="col-sm-5 control-label">Finish Product(Pr) :</label>--%>
                                           <label ID="label11" class="control-label col-sm-5"><span class="required"> * </span>Finish Product(Pr) :</label>
                                        <div class="col-sm-7">
                                            <asp:DropDownList ID="drpFinishProduct" CssClass="form-control select2" runat="server" Style="height: 27px; text-align: left" OnSelectedIndexChanged="drpFinishProduct_Click" AutoPostBack="true" >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                               
                                
                            </div>

                            
                            <div class="row">
                                   
                                  <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                        
                                           <label ID="label2" class="control-label col-sm-5"><span class="required"> * </span>Bandroll Quantity :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" Style="height: 27px;" ID="txtPQuantity" CssClass="form-control" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtLCAmount_FilteredTextBoxExtender1"
                                                        runat="server" Enabled="True" TargetControlID="txtPQuantity"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                             </div>
                                    </div>
                                </div>
                               
                                  <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                               <label ID="lblPrice" class="control-label col-sm-5"><span class="required"> * </span>Bandroll Adjustment :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server" >
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                             <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                               <label ID="designLabel" class="control-label col-sm-5"><span class="required"> * </span>Design :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpdesignType" CssClass="form-control select2" runat="server" Style="height: 27px; text-align: left" AutoPostBack="true" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
 
                             
                                
                               </div>

                            
                            
                            <div class="row">
                                
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                           <%-- <label class="col-sm-5 control-label">Finish Product(Pr) :</label>--%>
                                               <label ID="FilterLabel" class="control-label col-sm-5"><span class="required"></span>Filter Type :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpFilterType" Enabled="false" CssClass="form-control select2" runat="server" Style="height: 27px; text-align: left" AutoPostBack="true" >
                                                    <asp:ListItem Value="-99">Select Filter</asp:ListItem>
                                                    <asp:ListItem Value="1">With Filter</asp:ListItem>
                                                    <asp:ListItem Value="2">Without Filter</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                       <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                               <label ID="StickLabel" class="control-label col-sm-5"><span class="required"> * </span>Stick Type :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpStickType" CssClass="form-control select2" runat="server" Style="height: 27px; text-align: left" AutoPostBack="true" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                
                                   
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                               <label ID="brsdLabel" class="control-label col-sm-5"><span class="required"> * </span>Band-roll & Stamp :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpbrsdType" CssClass="form-control select2" runat="server" Style="height: 27px; text-align: left" AutoPostBack="true" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
 

                               </div>



                            <div class="row">
                                   <div class="col-md-4">
                                    <div class="form-group form-group-sm">
                                    <%--    <label class="col-sm-5 control-label">Price Decl. No :</label>--%>
                                        <label ID="txtRemark" class="control-label col-sm-5">Remarks :</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" Style="height: 27px" runat="server" AutoPostBack="true"  PlaceHolder="Remarks" />
                                        </div>
                                    </div>
                                </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                               <label ID="PacketLabel" runat="server" class="control-label col-sm-5">Packet Type :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="drpPacketType" CssClass="form-control select2" runat="server" Style="height: 27px; text-align: left" AutoPostBack="true" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    
                                   
                                
                                        

                               </div>



                               <div class="row" style="text-align:right">
                                <div class="test-btn">
                                    <asp:Button ID="printBTN" runat="server" class="btn-btn" OnClick="btnPrint_Click"
                                        Text="Show Report" style="background-color:#5CB85C;margin-top: 15px" />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnAdd" runat="server" class="btn-btn" style="background-color:#B681B7;margin-top: 15px;" OnClick="btnAddItem_Click" Enabled="true"
                                        Text="Add Item"  />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnSave" runat="server" style="background-color:#4CAF50;margin-top: 15px" class="btn-btn" Text="Save" OnClick="btnSave_Click"
                                        />
                                </div>
                                <div class="test-btn">
                                    <asp:Button ID="btnClear" runat="server" style="background-color: #4CAF50;margin-top: 15px" class="btn-btn" OnClick="btnClear_Click"
                                        Text="Refresh"  />
                                </div>
                            </div>
                            <div class="row" style="margin: 10px">
                                <div class="panel panel-primary">
                                     <div class="panel-body">
                                         <div class="table table-responsive">
                                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid"
                                    HeaderStyle-CssClass="gvheader" RowStyle-CssClass="gvrows" PagerStyle-CssClass="gvpager" ShowHeaderWhenEmpty="true"
                                     style="width: 100%;" OnRowDeleting="gvItem_RowDeleting">
                                                <Columns>
                                                 
                                                  
                                                    <asp:BoundField HeaderText="বিড়ির ব্রান্ড নাম " DataField="BrandName" HeaderStyle-ForeColor="White" />
                                                    <asp:BoundField HeaderText="প্যাকেটের ধরণ" DataField="Property4_Text" HeaderStyle-ForeColor="White" />
                                                    <asp:BoundField HeaderText="ব্যান্ডরোলের ধরণ" DataField="Property3_Text"  HeaderStyle-ForeColor="White"/>
                                                     <asp:BoundField HeaderText="ব্যান্ডরোলের  সংখ্যা" DataField="Quantity"  HeaderStyle-ForeColor="White"/>
                                                    <asp:BoundField HeaderText="ব্যান্ডরোল সংশ্লিষ্ট রাজস্বের পরিমাণ" DataField="bandrollAdjAmount"  HeaderStyle-ForeColor="White"/>
                                                    <asp:BoundField HeaderText="মন্তব্য" DataField="Remark"  HeaderStyle-ForeColor="White"/>
                                                    <%-- <asp:BoundField HeaderText="Mfg. Date" DataField="MfgDate"  Visible="False" />
                                                     <asp:BoundField HeaderText="Expiry Date" DataField="DeliveryDate"  Visible="False"  />--%>
                                                    
                                                 <%--   <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Trash.gif" ShowDeleteButton="True" />--%>
                                                </Columns>
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <HeaderStyle Height="25px" BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                <RowStyle BorderStyle="Solid" BorderWidth="1px" BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                            </asp:GridView>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        <%--    <uc2:MsgBox ID="msgBox" runat="server" />--%>
                            <uc1:MsgBoxs runat="server" ID="msgBox" />
                        </div>
                    </div>
                </div>
       <div id="cpPrint" class="container-fluid" style="margin-top: 2%;font-family:Nikosh" runat="server" visible="true">          
     <div class="row" style=" font-size: 16px;">
             <p style="text-align: center">             
             <p></p>  
             <p> <strong style="text-align: center; float: right;font-size:20px">চাহিদাপত্র 'ফরম-খ'</strong> </p>  
                <br />
             <p>সম্ভাব্য চাহিদা সংক্রান্ত পত্র নং <asp:Label runat="server" ID="savedRefNo" Text="....................."/>  তারিখ  <asp:Label runat="server" ID="savedRefDate" Text="....................."/> অর্থবছর <asp:Label runat="server" ID="savedRefYear" Text="....................."/> মাসের নাম <asp:Label runat="server" ID="savedRefMonth" Text="....................."/> </p>     
                 <p>
                 </p>
                 <p>
                 </p>
                 <p>
                 </p>
                 <p>
                 </p>
                 <p>
                 </p>
         </p>    
       
     

                <caption>
                    <br />
                    <br />
                
                            <p style="text-align: center">
                                <p>
                                    প্রাপকঃ</p>
                                <p>
                                    জনাব,
                                    <asp:Label ID="savedRefName" runat="server" Text="..............................................................." />
                                </p>
                                <p>
                                    দি সিকিউরিটি প্রিন্টিং করপোরেশন (বাংলাদেশ) লিঃ, গাজীপুর-১৭০৩
                                </p>
                                <br />
                                <p>
                                    বিষয়ঃ <b>ব্যান্ডরোলের জন্য নিবন্ধিত উৎপাদকের সম্ভাব্য মাসিক চাহিদাপত্র</b>
                                </p>
                                <p>
                                </p>
                                <p>
                                </p>
                                <p>
                                </p>
                                <p>
                                </p>
                                <p>
                                </p>
                            </p>
                  
                </caption>


   
                       
                          
                          
                        
                          
                    </div>
                    <div style="font-size:12px">
                   
                    <div class="row" style="margin-top: 3%">
                        <table class="table table-bordered" style="width: 100%; text-align: center; background: none; border-collapse: collapse">
                            <tr>
                                <td style="border: 1px solid gray">ক্রমিক নং
                                </td>
                                <td style="border: 1px solid gray">বিড়ির ব্রান্ড নাম 
                                </td>
                                 <td style="border: 1px solid gray">  প্যাকেটের ধরণ
                                </td>
                               <td style="border: 1px solid gray">  ব্যান্ডরোলের ধরণ
                                </td>
                                <td style="border: 1px solid gray">ব্যান্ডরোলের  সংখ্যা 
                                </td>
                                <td style="border: 1px solid gray">ব্যান্ডরোল সংশ্লিষ্ট রাজস্বের পরিমাণ 
                                </td>
                                <td style="border: 1px solid gray">মন্তব্য
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid gray">(১)
                                </td>
                                <td style="border: 1px solid gray">(২)
                                </td>
                                <td style="border: 1px solid gray">(৩)
                                </td>
                                <td style="border: 1px solid gray">(৪)
                                </td>
                                <td style="border: 1px solid gray">(৫)
                                </td>
                                <td style="border: 1px solid gray">(৬)
                                </td>
                                <td style="border: 1px solid gray">(৭)
                                </td>
                            </tr>
                            <tr>
                                <asp:Label runat="server" ID="HaiMan"></asp:Label>
                            </tr>
                        </table>
                    </div>

                     <div class="row" style="margin-top: 4%">
                        <p style="margin-left: 35%">প্রতিষ্ঠান ও কর্তৃপক্ষের স্বাক্ষর ও তারিখ: <asp:Label runat="server" ID="orgAuthSignSill" /></p>
                          <p style="margin-left: 35%">নাম ও পদবি: <asp:Label runat="server" ID="lblDutyOfficer" /></p>
                         <p style="margin-left: 35%">প্রতিষ্ঠানের নাম ও ঠিকানা: <asp:Label runat="server" ID="orgNameAddress" /></p>
                         <p style="margin-left: 35%">মূসক নিবন্ধন নং:<asp:Label runat="server" ID="orgBIN" /></p>
                            <br />
                         <p style="margin-left: 35%">সংশ্লিষ্ট সার্কেলের রাজস্ব কর্মকর্তার নাম, স্বাক্ষর, সীল ও তারিখ</p>
                    </div>
                   
                        <br />
                </div>
                    </div>
                <asp:Button ID="btnPrintReport" runat="server" CssClass="btn btn-info" Style="float: right"
                    Text="Print" OnClientClick="return PrintPanel();" Visible="false" />
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>
