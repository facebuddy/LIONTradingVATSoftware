<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="Reports_XMLgenerate, App_Web_pj2ymx2u" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/str.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap/bootstrap.css" />
    </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <div class="panel panel-primary">
        <div class="panel-heading" style="text-align: center;  font-family:Tahoma; font-size:18px; font-weight: bold; height: 35px; padding-top: 0px">মূল্য সংযোজন কর দাখিলপত্র (মূসক-৯.১)</div>
        <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
            <div class="row" style="margin-top: 0.5%">
                <div class="col-md-12">
                    <div class="form-group form-group-sm">
                        <div class="col-md-4">
                            <label class="col-sm-5 comntrol-label">Date From:</label>
                            <div class="col-sm-7">
                                <asp:TextBox CssClass="form-control" runat="server" Width="40%" ID="dtpDateFrom" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="cc11" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateFrom" />
                            </div>

                        </div>
                        <div class="col-md-3">
                            <label class="col-sm-4 comntrol-label">Date To:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control" runat="server" Width="50%" ID="dtpDateTo" DateFormat="dd/MM/yyyy" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="dtpDateTo" />
                            </div>

                        </div>
                        <div class="col-md-5">
                           
                            <asp:LinkButton ID="btnShow" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnShow_OnClick"><i class="fa fa-file-excel-o"></i>  Generate XML</asp:LinkButton>
                         
                          <asp:Label runat="server" ID ="lblStatus" ></asp:Label>
                        </div>
                    </div>

                </div>
                
            </div>
        </div>
    </div>
    

    <script>
        function export_table_to_xml() {
            var html = document.querySelectorAll("table");
            var filename = "table.xml";
            var xmlString = "<root>";
            var cnt = html.length;
            var re = new RegExp("&nbsp;", 'g');
            for (var i = 0; i < cnt; i++) {
                var inputs = html[i].querySelectorAll("input");
                for (var j = 0; j < inputs.length; j++) {
                    var inpValue = html[i].querySelectorAll("input")[0].value;
                    var para = document.createElement("span");
                    var node = document.createTextNode(inpValue);
                    para.appendChild(node);
                    html[i].querySelectorAll("input")[0].remove();
                }
                var brs = html[i].querySelectorAll("br");
                for (var j = 0; j < brs.length; j++) {
                    html[i].querySelectorAll("br")[0].remove();
                }
                xmlString += html[i].outerHTML.replace(re, " ");
            }
            xmlString += "</root>";

            download_xml(xmlString, filename);
        }

        function download_xml(xml, filename) {
            var xmlFile;
            var downloadLink;
            xmlFile = new Blob([xml], { type: "text/plain;" });
            downloadLink = document.createElement("a");
            downloadLink.download = filename;
            downloadLink.href = window.URL.createObjectURL(xmlFile);
            downloadLink.style.display = "none";
            document.body.appendChild(downloadLink);
            downloadLink.click();
            window.location = "";
        }
    </script>
</asp:Content>