<%@ page language="C#" autoeventwireup="true" masterpagefile="~/DashboardVTR.Master" inherits="UI_Sale_Template, App_Web_otqqrkum" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="Server">
    <CKEditor:CKEditorControl ID="CKEditor1" runat="server"></CKEditor:CKEditorControl>
    <div>
         <asp:Label runat="server" ID="lblEditor" />
    </div>

      <asp:Button ID="save" runat="server" OnClick="save_Click" Text="Save" />
   
</asp:Content>