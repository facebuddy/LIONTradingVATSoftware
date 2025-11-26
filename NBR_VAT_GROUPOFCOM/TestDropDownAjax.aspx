<%@ page title="Test DropDown Ajax" language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="TestDropDownAjax, App_Web_1kre2rwf" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ddl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/bootstrap/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var category = $('#ddlCategory');
            var subCategory = $('#ddlSubCategory');
            var itemDD = $('#ddlItem');

            $.ajax({
                url: 'WebService.asmx/GetItemCategoryNew',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    category.append($('<option/>', { value: -1, text: 'Select Category' }));
                    subCategory.append($('<option/>', { value: -1, text: 'Select SubCategory' }));
                    itemDD.append($('<option/>', { value: -1, text: 'Select Item' }));
                    itemDD.prop('disabled', true);
                    subCategory.prop('disabled', true);
                    $(data).each(function (index, item) {
                        category.append($('<option/>', { value: item.Id, text: item.Name }));
                    });
                },
                error: function (err) {
                    alert(err);
                }
            });
            //category.change(function () {
            //    var ddlCat = $("[id*=ddlCategory]");
            //    if ($(this).val() == "-1") {
            //        subCategory.empty();
            //        itemDD.empty();
            //        subCategory.append($('<option/>', { value: -1, text: 'Select Item' }));
            //        itemDD.append($('<option/>', { value: -1, text: 'Select Item' }));
            //        subCategory.val('-1');
            //        subCategory.prop('disabled', true);
            //        itemDD.val('-1');
            //        itemDD.prop('disabled', true);
            //    }
            //    else {
            //        $.ajax({
            //            url: 'WebService.asmx/GetItemSubCategoryNew',
            //            method: 'post',
            //            dataType: 'json',
            //            data: { CategoryNId: ddlCat.val() },
            //            success: function (data) {
            //                alert("Data Found");
            //                //itemDD.empty();
            //                //itemDD.append($('<option/>', { value: -1, text: 'Select Item' }));
            //                //$(data).each(function (index, item) {
            //                //    itemDD.append($('<option/>', { value: item.Id, text: item.Name }));
            //                //});
                            
            //                //itemDD.val('-1');
            //                //itemDD.prop('disabled', false);
            //            },
            //            error: function (err) {
            //                alert("Data Not Found  " + ddlCat.val());
            //            }
            //        });
            //    }
            //});
            category.change(function () {
                if ($(this).val() == "-1") {
                    itemDD.empty();
                    itemDD.append($('<option/>', { value: -1, text: 'Select Item' }));
                    itemDD.val('-1');
                    itemDD.prop('disabled', true);
                }
                else {
                    $.ajax({
                        url: "/WebService.asmx/GetItemByCategoryNew",
                        method: 'post',
                        dataType: 'json',
                        data: { CategoryNId: $(this).val() },
                        success: function (data) {
                            //alert("Data Found");
                            itemDD.empty();
                            itemDD.append($('<option/>', { value: -1, text: 'Select Item' }));
                            $(data).each(function (index, item) {
                                itemDD.append($('<option/>', { value: item.Id, text: item.Name }));
                            });

                            itemDD.val('-1');
                            itemDD.prop('disabled', false);
                        },
                        error: function (err) {
                            alert("Data Not Found");
                        }
                    });
                }
            });
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid" style="padding-right: 0%; padding-left: 0%">
        <div class="panel-group">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center; font-size: 21px; font-weight: bold; height: 30px; padding-top: 0px">Test</div>
                <div class="panel-body" style="padding-top: 0px; padding-bottom: 0px">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Category :</label>
                                <div class="col-sm-7">
                                    <select id="ddlCategory" class="form-control"></select>
                                </div>
                            </div>
                        </div>
                           <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Sub Category :</label>
                                <div class="col-sm-7">
                                    <select ID="ddlSubCategory" class="form-control"></select>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Item :</label>
                                <div class="col-sm-7">
                                    <select ID="ddlItem" class="form-control"></select>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Category :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="ddlnCategory" runat="server" CssClass="form-control" ></asp:DropDownList>
                                    <ddl:CascadingDropDown ID="drpCategory" TargetControlID="ddlnCategory" PromptText="Select Category" PromptValue="" ServicePath="WebService.asmx" ServiceMethod="GetCategory" runat="server" Category="CATEGORY_ID" LoadingText="Loading..." />
                                </div>
                            </div>
                        </div>
                           <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Sub Category :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="ddlnSubCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <ddl:CascadingDropDown ID="drpSubCategory" TargetControlID="ddlnSubCategory" PromptText="Select SubCategory" PromptValue="" ServicePath="WebService.asmx" ServiceMethod="GetSubCategoryByCategory" runat="server" Category="CATEGORY_ID" LoadingText="Loading..." />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group form-group-sm">
                                <label class="col-sm-5 control-label">Item :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="ddlnItem" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <ddl:CascadingDropDown ID="drpItem" TargetControlID="ddlnItem" PromptText="Select Item" PromptValue="" ServicePath="WebService.asmx" ServiceMethod="GetItemByCategory" runat="server" Category="CategoryNId" LoadingText="Loading..." />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
