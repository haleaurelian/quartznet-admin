**Story:** Viewing job details

  * As Operations
  * I want to be able to view these job details
    * Job Name
    * Group Name
    * Job Type
    * Description
    * Durable
    * Job Data Map
    * Job Listener Names
    * Requests Recovery
    * Stateful
    * Volatile
    * Trigger Summary
  * So that I can diagnose problems with the job.

  1. Scenario: Accessing the "View Job" page
    * Given that all requirements for viewing a job have been met
    * When the user selects "View Job" from the "Job Summary" page
    * Then the "View Job" page is displayed.
  1. Scenario: Displaying Job Data Map
    * When the job data map contains a value type or string
    * Then the value is displayed.

**Story:** Viewing trigger summary

  * As Operations
  * I want to be able to view a summary of triggers for a Quartz instance
  * So that I can quickly see the job’s execution schedule.

**Story:** Trigger summary information

  * As Operations
  * I want each trigger summary entry to contain
    * Trigger Name
    * Group Name
    * Description
    * Previous Execution Time
    * Next execution time
  * So that I can view the most common information about the trigger without loading its details.

  1. Scenario: Summarizing a trigger that has no group
    * Given that a trigger is not assigned to a group
    * When the trigger is displayed in the trigger summary
    * Then the value "(Default)" is used for the group name
  1. Scenario: Summarizing a trigger that has no description
    * Given that a trigger does not have a description
    * When the trigger is displayed in the trigger summary
    * Then the description value appears blank.
  1. Scenario: Summarizing a trigger that has never executed
    * Given that a trigger has never executed
    * When the trigger is displayed in the trigger summary
    * Then the value "n/a" is used for the previous execution time.
  1. Scenario: Summarizing a trigger that will not be executed again
    * Given that a trigger will not be executed again
    * When the trigger is displayed in the trigger summary
    * Then the value "n/a" is used for the next execution time.
  1. Scenario: Formatting Previous and Next Execution Time
    * Given that a trigger has a previous or next execution time
    * When the trigger is displayed in the trigger summary
    * Then the previous and next execution time will be displayed in the format 01/01/2009 12:00pm.