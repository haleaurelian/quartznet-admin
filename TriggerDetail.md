**Story:** Viewing triggers details

  * As Operations
  * I want to be able to view these trigger details
    * Trigger Name
    * Group Name
    * Calendar Name
    * Description
    * End Time
    * Final Fire Time
    * Has Millisecond Precision
    * Job Data Map (TBD)
    * Misfire Instruction
    * Priority
    * Start Time
    * Trigger Listener Names
    * Volatile
    * Next Fire Time
    * Previous Fire Time
    * TBD: Fields from subclasses (cron expression, etc.)
  * So that I can diagnose problems with the trigger.

  1. Scenario: Accessing the “View Trigger” page
    * Given that all requirements for viewing a trigger have been met
    * When the user selects “View Trigger” from the trigger summary on the “View Job” page
    * Then the “View Trigger” page is displayed.

  1. Scenario: Displaying Job Data Map
    * When the job data map contains a value type or string
    * Then the value is displayed.