<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuartzAdmin.web.Models.InstanceModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%=Model.InstanceName%> Details</h2>

    <fieldset>
        <p>
            InstanceID:
            <%= Html.Encode(Model.InstanceID) %>
        </p>
        <p>
            InstanceName:
            <%= Html.Encode(Model.InstanceName) %>
        </p>
        <p>
            Properties:
            <ul>
                <%foreach (QuartzAdmin.web.Models.InstancePropertyModel prop in Model.InstanceProperties)
                  {%>
                
                    <li><%=prop.PropertyName %> - <%=prop.PropertyValue %></li>
                <%} %>
            </ul>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id=Model.InstanceName }) %> |
        <%=Html.ActionLink("Delete", "Delete", new { id=Model.InstanceName }) %> |
        <%=Html.ActionLink("Back to List", "Index", "Home") %>
    </p>

</asp:Content>

