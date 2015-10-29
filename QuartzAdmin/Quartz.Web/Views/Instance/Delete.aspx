<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuartzAdmin.web.Models.InstanceModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm()) {%>
    <h2>Are you sure you want to delete [<%= Html.Encode(Model.InstanceName) %>]?</h2>

    <p>
        <input type="submit" value="Delete" />
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>
    <% } %>

</asp:Content>

