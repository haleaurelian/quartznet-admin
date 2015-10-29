<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CurrentStatus
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Current Status for <%=ViewData["groupName"] %></h2>
    <%Html.RenderPartial("/Views/Group/CurrentStatus.ascx", ViewData); %>
</asp:Content>
