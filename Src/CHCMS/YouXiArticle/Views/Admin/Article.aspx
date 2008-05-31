<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="YouXiArticle.Views.Admin.Article" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/Editor/fckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="form1" runat="server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="YouXiArticle.Models.ArticleDataContext" 
        Select="new (Title, ID, Body, AddTime)" TableName="Article" 
        Where="NavigationID == @NavigationID">
        <WhereParameters>
            <asp:QueryStringParameter Name="NavigationID" QueryStringField="id" 
                Type="Int64" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="LinqDataSource1" ForeColor="#333333" 
        GridLines="None" AllowPaging="True">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                 <%#Html.ActionLink<AdminController>(c => c.Article(Request.QueryLong("ID"),(long)Eval("ID")), "编辑")%>
                    <%#Html.ActionLink<AdminController>(c => c.DelArticle((long)Eval("ID")), "删除")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" 
                SortExpression="Title" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" />
            <asp:BoundField DataField="AddTime" HeaderText="AddTime" ReadOnly="True" 
                SortExpression="AddTime" />
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    </form>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>
            <%
                if (Request.QueryLong("ModifyID") != 0)
                { 
            %>
            正在修改"<%=ViewData["Title"]%>"文章,
            <%=Html.ActionLink<AdminController>(c => c.Article(Request.QueryLong("ID"), 0), "新建")%>
            <%
                }
    else
    {
            %>正在添加新的文章<%
                          }
            %>
        </legend>
        <%
            using (Html.Form<AdminController>(c => c.AddArticle(Request.QueryLong("ModifyID")), FormMethod.Post))
            { 
        %>
        <%=Html.Hidden("NavigationID")%><br />
        标题：<%=Html.TextBox("Title") %><br />
        内容：<%=Html.FckTextBox("Body",ViewData["Body"]) %>
        作者:<%=Html.TextBox("Author") %>
        <br />
        <%=Html.SubmitButton("提交") %>
        <%
            }
        %>
    </fieldset>
</asp:Content>
