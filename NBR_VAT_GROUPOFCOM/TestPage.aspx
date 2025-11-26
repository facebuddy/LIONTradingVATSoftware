<%@ page language="C#" autoeventwireup="true" inherits="TestPage, App_Web_10xevz1n" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">  
    <div>  
      
        Import Excel File:  
        <asp:FileUpload ID="FileUpload1" runat="server" />  
        <br />  
        <br />  
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />  
        <br />  
        <br /> 
        <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print" />  
        <br />  
        <br />  
        <asp:Label ID="Label1" runat="server"></asp:Label>  
        <br />  
        <asp:GridView ID="gvExcelFile"  runat="server" AutoGenerateColumns="false" CellPadding="4" OnRowDataBound="Test_OnRowDataBound" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:HiddenField ID="itemID" Value='<%# Eval("ItemID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="UnitID" Value='<%# Eval("UnitID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
               <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="SizeID" Value='<%# Eval("SizeID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="ColorID" Value='<%# Eval("ColorID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="GradeID" Value='<%# Eval("GradeID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="CompanyID" Value='<%# Eval("CompanyID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="SpecificationID" Value='<%# Eval("SpecificationID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="CDStatus" Value='<%# Eval("CDStatus") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="RDStatus" Value='<%# Eval("RDStatus") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="SDStatus" Value='<%# Eval("SDStatus") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="VATStatus" Value='<%# Eval("VATStatus") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="AT_Status" Value='<%# Eval("AT_Status") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="AITStatus" Value='<%# Eval("AITStatus") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="ATVStatus" Value='<%# Eval("ATVStatus") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="TTIStatus" Value='<%# Eval("TTIStatus") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>


               <%-- <asp:BoundField HeaderText="Item" DataField="ItemName" />
                <asp:BoundField HeaderText="Unit" DataField="UnitName" />
                <asp:BoundField HeaderText="Size" DataField="Size" />
                <asp:BoundField HeaderText="Color" DataField="Color" />
                <asp:BoundField HeaderText="Grade" DataField="Grade" />
                <asp:BoundField HeaderText="Company" DataField="Company" />
                <asp:BoundField HeaderText="Specification" DataField="Specification" />
                <asp:BoundField HeaderText="CD(%)" DataField="CD" />
                <asp:BoundField HeaderText="RD(%)" DataField="RD" />
                <asp:BoundField HeaderText="SD(%)" DataField="SD" />
                <asp:BoundField HeaderText="VAT(%)" DataField="VAT" />
                <asp:BoundField HeaderText="AT(%)" DataField="AT_" />
                <asp:BoundField HeaderText="AIT(%)" DataField="AIT" />
                <asp:BoundField HeaderText="ATV(%)" DataField="ATV" />
                <asp:BoundField HeaderText="TTI(%)" DataField="TTI" />
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" />
                <asp:BoundField HeaderText="Total Price" DataField="TotalPrice" />
                <asp:BoundField HeaderText="SD" DataField="TotalSD" />
                <asp:BoundField HeaderText="VAT" DataField="TotalVAT" />
                <asp:BoundField HeaderText="Total Tax" DataField="TotalTax" />--%>
            </Columns>  
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />  
            <SortedAscendingCellStyle BackColor="#EDF6F6" />  
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
            <SortedDescendingCellStyle BackColor="#D6DFDF" />  
            <SortedDescendingHeaderStyle BackColor="#002876" />  
        </asp:GridView>  
      
    </div>  
    </form>   
</body>
</html>
