<%@ Page Title="添加子站" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="AddSite.aspx.cs" Inherits="YouXiArticle.Views.Admin.AddSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        using (Html.Form<AdminController>(c => c.AddSitePost(), FormMethod.Post))
        { 
    %>
    域名：<%=Html.TextBox("Domain") %><br />
  
    <%--风格文件：<%=Html.TextBox("StylePath") %><br />--%>
   游戏类型： <%=Html.DropDownList("GameType")%><br />
   游戏名称：<%=Html.TextBox("Title") %><br /> 
   题材种类：<%=Html.DropDownList("GameStory") %><br />
   英文简称:<%=Html.TextBox("English") %><br />
   索引：<%=Html.DropDownList("Letter") %><br />
   游戏产地：<%=Html.DropDownList("GameArea") %><br />
   客服热线：<%=Html.TextBox("Telphone") %><br />
游戏画面：<%=Html.DropDownList("GameView") %><br /> 
研发公司：<%=Html.TextBox("Developer") %><br />
运营公司：<%=Html.TextBox("RunCompany") %><br />
游戏状态：<%=Html.DropDownList("GameStatus") %><br />
测试时间：<%=Html.TextBox("TextTime") %>2008-02-02<br />
测试名称:<%=Html.TextBox("TestName")%>如，激情内测<br />
官方网站:<%=Html.TextBox("Website","http://")%><br />
官方论坛:<%=Html.TextBox("BBsSite","http://")%><br />
游戏图片:<%=Html.TextBox("GamePic")%><br />
游戏简介:<%=Html.TextArea("Summary","")%><br />
基本配置:<%=Html.FckTextBox("BaseConfig","CPU:<br />内存:<br />显卡:<br />")%><br />
推荐配置:<%=Html.FckTextBox("PushConfig", "CPU:<br />内存:<br />显卡:<br />")%><br />


<%--运营公司：GameCompany	bigint	Checked--%><br />
    <%=Html.SubmitButton("提交") %>
    <%
        }
    %>
</asp:Content>
