<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="Nav.aspx.cs" Inherits="YouXiArticle.Views.Admin.AddNav" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="YouXiArticle.Models.ArticleDataContext" EnableDelete="True" 
        Select="new (ID, Title, Url,HasArticle,HasUrl,Navtype)" TableName="Navigation" Where="SiteID == @SiteID">
        <WhereParameters>
            <asp:QueryStringParameter Name="SiteID" QueryStringField="SiteID" Type="Int64" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" DataSourceID="LinqDataSource1" 
        ForeColor="#333333" GridLines="None" 
       Width="659px">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                <%#Html.ActionLink<AdminController>(c => c.Nav(Request.QueryLong("SiteID"), (long)Eval("ID")), "修改")%>
                    <%#Html.ActionLink<AdminController>(c => c.DeleteNav((long)Eval("ID")), "删除")%>
                    
                    <%#getM(Eval("Navtype"),(long)Eval("ID")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" 
                SortExpression="标题" />
            <asp:BoundField DataField="Url" HeaderText="Url" ReadOnly="True" 
                SortExpression="Url" />
                <asp:TemplateField HeaderText="类型">
                <ItemTemplate>
                <%#Enum.GetName(typeof(NavType ),Eval("Navtype")) %>
                </ItemTemplate>
                </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
        </form>


<fieldset>
<legend>
<%
    if (Request.QueryLong("ModifyID") != 0)
    { 
  %>
  正在修改"<%=ViewData["Title"]%>"栏目,
  <%=Html.ActionLink<AdminController>(c => c.Nav(Request.QueryLong("SiteID"), 0), "新建")%>
  <%
    }
    else
    {
       %>正在添加新的栏目<%
    }
     %>
</legend>
    <%
        using (Html.Form<AdminController>(c => c.AddNav(Request.QueryLong("ModifyID")), FormMethod.Post))
        { 
    %>
    <%=Html.Hidden("SiteID")%><br />
    标题：<%=Html.TextBox("Title")%><br />
    地址：<%=Html.TextBox("Url")%><br />
    <%=Html.Hidden("HasArticle",true)%>
    <%=Html.Hidden("HasUrl",true)%>
    类型:<%=Html.DropDownList("Navtype")%>
    <%=Html.SubmitButton("提交")%>
    <%
        }
    %> 
</fieldset>
</asp:Content>
