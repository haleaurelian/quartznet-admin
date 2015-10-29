<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QuartzAdmin.web.Models.InstanceModel>>" %>


<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to Quartz Admin</h2>
    <p>
    
        <table>
        <%
        foreach (var instance in Model)
          {%>
            <tr>
                <td><%=instance.InstanceName%></td>
                <td><%=Html.ActionLink("Connect", "Connect", "Instance", new { id = instance.InstanceName }, null)%></td>
                <td><%=Html.ActionLink("View", "Details", "Instance", new{id=instance.InstanceName}, null) %></td>
                <td><%=Html.ActionLink("Edit", "Edit", "Instance", new{id=instance.InstanceName}, null) %></td>
            </tr>
        
        <%} %>        
        </table>
        
    </p>
    <p>
        <%= Html.ActionLink("Create New", "Create", "Instance") %>
    </p>

</asp:Content>
