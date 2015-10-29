<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<QuartzAdmin.web.Models.InstanceModel>" %>
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $("#addRowsButton").click(function() {

                var lastKeyField = $('#instancePropsTable tr:last td:first input:first');
                var lastIndex = lastKeyField.attr('id').split('-')[1];
                var nextIndex = parseInt(lastIndex) + 1;
                //alert(nextIndex);
                $('#instancePropsTable tr:last').after('<tr><td><input type="text" id="InstancePropertyKey-' + nextIndex + '" name="InstancePropertyKey-' + nextIndex + '"/></td><td><input type="text" id="InstancePropertyValue-' + nextIndex + '" name="InstancePropertyValue-' + nextIndex + '" /> <a href="javascript:void(0);" class="delRowBtn">x</a></td></tr>');
                return false;

            });

            $(".delRowBtn").live("click", function() {
                var parentRow = $(this).closest("tr");
                parentRow.remove();
                return false;
            });

        });
    </script>

        <label>Quartz Properties <a href="#" id="addRowsButton" title="Add row">+</a></label>
        
        <table id="instancePropsTable">
            <tr>
                <th>
                    Prop Name
                </th>
                <th>
                    Prop Value
                </th>
            </tr>
            <%
                if (Model==null || Model.InstanceProperties==null || Model.InstanceProperties.Count == 0)
                {
                    %>
                    <tr>
                        <td><%=Html.TextBox("InstancePropertyKey-1", "quartz.scheduler.instanceName")%></td>
                        <td><%=Html.TextBox("InstancePropertyValue-1", "SampleQuartzScheduler") %></td>
                    </tr>
                    <tr>
                        <td><%=Html.TextBox("InstancePropertyKey-2", "quartz.threadPool.type")%></td>
                        <td><%=Html.TextBox("InstancePropertyValue-2", "Quartz.Simpl.SimpleThreadPool, Quartz") %></td>
                    </tr>
                    <tr>
                        <td><%=Html.TextBox("InstancePropertyKey-3", "quartz.scheduler.proxy")%></td>
                        <td><%=Html.TextBox("InstancePropertyValue-3", "true") %></td>
                    </tr>
                    <tr>
                        <td><%=Html.TextBox("InstancePropertyKey-4", "quartz.scheduler.proxy.address")%></td>
                        <td><%=Html.TextBox("InstancePropertyValue-4", "tcp://localhost:555/QuartzScheduler") %></td>
                    </tr>
                    
                    <%
                }
                else
                {
                    int cnt = 1;
                    foreach (QuartzAdmin.web.Models.InstancePropertyModel prop in Model.InstanceProperties)
                    {%>
            <tr>
                <td>
                    <%=Html.TextBox(string.Format("InstancePropertyKey-{0}", cnt), prop.PropertyName)%>
                </td>
                <td>
                    <%=Html.TextBox(string.Format("InstancePropertyValue-{0}", cnt), prop.PropertyValue)%>
                    <a href="#" class="delRowBtn">x</a>
                </td>
            </tr>
            <%
                cnt++;
                    }
                }%>
        </table>

