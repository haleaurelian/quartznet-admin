<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Quartz.ICalendar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Next 30 valid days</legend>
        <%DateTime dtTemp = DateTime.Now;
            for (int i = 0; i < 31; i++)
          { 
          dtTemp = Model.GetNextIncludedTimeUtc(dtTemp);
        %>
        <p>
            <%=Html.Encode(dtTemp.ToLocalTime()) %>
        </p>
          
        <%} %>
    </fieldset>
    <p>
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

