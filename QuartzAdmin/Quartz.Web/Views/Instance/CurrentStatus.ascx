<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="triggerStatuses"></div> 

<script type="text/javascript">

    YAHOO.namespace("bdr");
    YAHOO.util.Event.addListener(window, "load", function() {
        YAHOO.bdr.loadStatuses = new function() {
            this.formatJobUrl = function(elCell, oRecord, oColumn, sData) {
                var recordData = oRecord.getData();
                
                elCell.innerHTML = "<a href='<%=ResolveUrl("~/Job/Details/" + ViewData["instanceName"] + "/")%>" + recordData["GroupName"] + "/" + sData + "'>" + sData + "</a>";
            };
            this.formatTriggerUrl = function(elCell, oRecord, oColumn, sData) {
                var recordData = oRecord.getData();
                
                elCell.innerHTML = "<a href='<%=ResolveUrl("~/Trigger/Details/" + ViewData["instanceName"] + "/")%>" + recordData["GroupName"] + "/" + sData + "'>" + sData + "</a>";
            };

            var myColumnDefs = [
            { key: "JobName", label: "Job", sortable: true, formatter: this.formatJobUrl },
            { key: "GroupName" , sortable: true},
            { key: "TriggerName", label: "Trigger", sortable: true, formatter: this.formatTriggerUrl},
            { key: "StateDesc" , sortable: true},
            { key: "NextFireTime" , sortable: true, formatter:YAHOO.bdr.formatDateInDataTable},
            { key: "LastFireTime" , sortable: true, formatter:YAHOO.bdr.formatDateInDataTable}
            /*{key:"Rating.AverageRating", label:"Rating", formatter:YAHOO.widget.DataTable.formatNumber, sortable:true}*/
        ];

            var myDataSource = new YAHOO.util.DataSource("<%=ResolveUrl("~/JobExecution/GetCurrentTriggerStatusList/") %>");
            myDataSource.responseType = YAHOO.util.DataSource.TYPE_JSARRAY;
            myDataSource.connXhrMode = "queueRequests";
            //[{GroupName => big.report.delivery, TriggerName => big.NewApplicationTrigger, JobName => big.NewApplicationJob, State => 0, StateDesc => Normal}]
            myDataSource.responseSchema = {
                //resultsList: "ResultSet.Result",
                //fields: ["Title", "Phone", "City", { key: "Rating.AverageRating", parser: "number" }, "ClickUrl"]
                fields: ["GroupName", "TriggerName", "JobName", "State", "StateDesc", {key:"NextFireTime", parser:"date"}, {key:"LastFireTime", parser:"date"}]
            };

            var myDataTable = new YAHOO.widget.DataTable("triggerStatuses", myColumnDefs,
                myDataSource, 
                { 
                    initialRequest: "<%=ViewData["instanceName"]%>", 
                    dateOptions:{format:'%m/%d/%Y %H:%M'}
                });

            var myCallback = function() {
                this.set("sortedBy", null);
                this.onDataReturnAppendRows.apply(this, arguments);
            };
            
// Set up polling
        var pollingCallback = {
            success: myDataTable.onDataReturnInitializeTable,
            failure: function() {
                YAHOO.log("Polling failure", "error");
            },
            scope: myDataTable
        }
        myDataSource.setInterval(5000, "<%=ViewData["instanceName"]%>", pollingCallback)
        return { 
	            oDS: myDataSource, 
	            oDT: myDataTable 
	        };                
        };
    });
    
    YAHOO.bdr.formatDateInDataTable = function(elCell, oRecord, oColumn, oData)
    {
           //var d = Date.parse(oData);
           //alert(YAHOO.util.Date.format(oData, "%d/%m", "en"));
           //alert(oData);
           if(oData=='Invalid Date'){
            elCell.innerHTML = "";
           }
           else{
                elCell.innerHTML =YAHOO.util.Date.format(oData, {format:"%m/%d/%Y %H:%M"}); 
           }
           
    };
</script>


