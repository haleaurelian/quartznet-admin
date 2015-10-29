<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QuartzAdmin.web.Models.InstanceModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                InstanceID
            </th>
            <th>
                InstanceName
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.InstanceName }) %> |
                <%= Html.ActionLink("Details", "Details", new { id = item.InstanceName })%> | 
                <%= Html.ActionLink("Delete", "Delete", new { id = item.InstanceName })%>
            </td>
            <td>
                <%= Html.Encode(item.InstanceID) %>
            </td>
            <td>
                <%= Html.Encode(item.InstanceName) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

