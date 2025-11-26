<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardVTR.Master" AutoEventWireup="true" CodeBehind="Vat6.3Report.aspx.cs" Inherits="NBR_VAT_GROUPOFCOM.Reports.Vat6__3Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <style>
        .m
        {
            text-align:right;
            padding-right:5px;
        }
        
        
        table.allSolid { border: 1.5px solid black;}
        table.allSolid th { border: 1.5px solid black;text-align:center;}
        table.allSolid td { border: 1.5px solid black;}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 
       <div  class="row">
              <div class="col-md-12">
                    <div class="form-group form-group-sm">
                        <div class="col-md-4">
                            <label class="col-sm-5 comntrol-label">Date From:</label>
                            <div class="col-sm-7">
                                <asp:TextBox CssClass="form-control" runat="server" style="width:200px;" ID="dtpDateFrom" DateFormat="dd/MM/yyyy" ng-model="Entity.StartDate" />
                                <cc1:CalendarExtender ID="cc11" runat="server" Format="yyyy-MM-dd" TargetControlID="dtpDateFrom" />
                            </div>

                        </div>
                        <div class="col-md-3">
                            <label class="col-sm-4 comntrol-label">Date To:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateTo"  ng-model="Entity.EndDate"  DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="dtpDateTo" />
                            </div>

                        </div>
                        <div class="col-md-2">
                        
                            <asp:LinkButton ID="btnShow" runat="server"  OnClick="btnShow_OnClick" CssClass="btn btn-success btn-sm"><i class="fa fa-search-plus"></i>  Report</asp:LinkButton>
                           
                        </div>
                    </div>

          </div>
       </div>
     <div style="margin-bottom:200px;" class="col-md-12">
                            <div class="form-group form-group-sm">
                                <div class="table-responsive">
                                   <%--<table border="1" class="table" style="width: 100%; border-collapse: collapse">--%>
                                       <table class="allSolid" style="font-size:11px; width:100%; border-collapse: collapse;">
                                        <thead>
                                            <tr  style="border: 2px solid;">

                                           

                                                
                                                <th>ক্রমিক নং</th>
                                                <th>চালান নং</th>                                                
                                                <th>তারিখ</th>
                                                <th>কাস্টমার </th>
                                                <th>মূল্য</th>
                                                 <th style="min-width:60px;">Action</th>

                                            </tr>
                                        </thead>
                                        <tbody>                                          
                                            <tr>
                                                <asp:Label runat="server" ID="lblReportHtml" />
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                      
                       </div>
      

    <script>

        $(document).ready(function () {
            

            $(".btn").click(function () {
                var $row = $(this).closest("tr");    // Find the row
                var text = $row.find(".id").text(); // Find the text

                if (text != "")
                {
                    return window.open("http://report.time-zone.biz/MushakPrint?invoice_no=" + text, '_blank', 'height=800,width=1000');
                }
     






                // Let's test it out
               // alert(text);
            });

        });
    </script>
      









  
 



</asp:Content>
