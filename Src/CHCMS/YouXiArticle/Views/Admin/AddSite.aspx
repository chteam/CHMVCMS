<%@ Page Title="添加子站" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="AddSite.aspx.cs" Inherits="YouXiArticle.Views.Admin.AddSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        using (Html.Form<AdminController>(c => c.AddSitePost(), FormMethod.Post))
        { 
    %>
    域名：<%=Html.TextBox("Domain") %><br />
    网站标题：<%=Html.TextBox("Title") %><br />
    风格文件：<%=Html.TextBox("StylePath") %><br />
    <%=Html.SubmitButton("提交") %>
    <%
        }
    %>
</asp:Content>
