<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuartzAdmin.web.Models.InstanceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Connect
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Current Status of Scheduled Jobs</h3>
    <%
        ViewDataDictionary vdd = new ViewDataDictionary();
        vdd.Add("instanceName", Model.Instance.InstanceName);
        Html.RenderPartial("~/Views/Instance/CurrentStatus.ascx", vdd);
     %>


    <h3>List of registered jobs</h3>
    
    <div id="regJobsContainer">
    
    <table id="regJobsTable">
        <thead>
        <tr>
            <th></th>
            <th>
                Name
            </th>
            <th>
                Group
            </th>
            <th>
                FullName
            </th>
            <th>
                Description
            </th>
            <th>
                RequestsRecovery
            </th>
            <th>
                Volatile
            </th>
            <th>
                Durable
            </th>
            <th>
                Stateful
            </th>
        </tr>
        </thead>
        <tbody>

    <% foreach (var item in Model.Jobs) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", "Job", new { instanceName = Model.Instance.InstanceName, groupName = item.Group, itemName = item.Name }, null)%> |
                <%= Html.ActionLink("Details", "Details", "Job", new { instanceName = Model.Instance.InstanceName, groupName = item.Group, itemName = item.Name }, null)%>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.Group) %>
            </td>
            <td>
                <%= Html.Encode(item.FullName) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
            <td>
                <%= Html.Encode(item.RequestsRecovery) %>
            </td>
            <td>
                <%= Html.Encode(item.Volatile) %>
            </td>
            <td>
                <%= Html.Encode(item.Durable) %>
            </td>
            <td>
                <%= Html.Encode(item.Stateful) %>
            </td>
        </tr>
    
    <% } %>
        </tbody>
    </table>
    </div>
    
    <script type="text/javascript">
        YAHOO.util.Event.addListener(window, "load", function() {
            EnhanceFromMarkup = new function() {
            var myColumnDefs = [
                {key: "Action", width:"300"},
            { key: "Name", label: "Name", sortable: true },
            { key: "Group", label: "Group", sortable: true },
            { key: "FullName", label: "FullName", sortable: true },
            { key: "Description", label: "Description", sortable: true },
            { key: "RequestsRecovery", label: "RequestsRecovery", sortable: true },
            { key: "Volatile", label: "Volatile", sortable: true },
            { key: "Durable", label: "Durable", sortable: true },
            { key: "Stateful", label: "Stateful", sortable: true }
        ];


                this.myDataSource = new YAHOO.util.DataSource(YAHOO.util.Dom.get("regJobsTable"));
                this.myDataSource.responseType = YAHOO.util.DataSource.TYPE_HTMLTABLE;
                this.myDataSource.responseSchema = {
                    fields: [
                        { key: "Action", label: "" },
                        { key: "Name", label: "Name" },
                        { key: "Group", label: "Group" },
                        { key: "FullName", label: "FullName" },
                        { key: "Description", label: "Description" },
                        { key: "RequestsRecovery", label: "RequestsRecovery" },
                        { key: "Volatile", label: "Volatile" },
                        { key: "Durable", label: "Durable" },
                        { key: "Stateful", label: "Stateful" }
                    ]
                };

                this.myDataTable = new YAHOO.widget.DataTable("regJobsContainer", myColumnDefs, this.myDataSource,{});
            };
        });    
    </script>

</asp:Content>

