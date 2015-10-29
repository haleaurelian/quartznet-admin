**Story:** Viewing job summary

  * As Operations
  * I want to be able to view a summary of jobs for a Quartz instance
  * So that I can quickly see the status of all jobs.

  1. Scenario: Accessing the "Job Summary" page
    * Given that all requirements for connecting to a Quartz instance have been met,
    * When the user selects a connection definition from the "Connection List" page
    * Then the "Job Summary" page is displayed.

**Story:** Job summary data

  * As Operations
  * I want each job summary entry to contain
    * Job Name
    * Group Name
    * Description
    * Previous Execution Time
    * Next Execution Time
  * So that I can view the most common information about the job without loading its details.

  1. Scenario: Summarizing a job that has no group
    * Given that a job is not assigned to a group
    * When the job is displayed in the job summary
    * Then the value "(Default)" is used for the group name
  1. Scenario: Summarizing a job that has no description
    * Given that a job does not have a description
    * When the job is displayed in the job summary
    * Then the description value appears blank.
  1. Scenario: Summarizing a job that has never executed
    * Given that a job has never executed
    * When the job is displayed in the job summary
    * Then the value "n/a" is used for the previous execution time.
  1. Scenario: Summarizing a job that will not be executed again
    * Given that a job will not be executed again
    * When the job is displayed in the job summary
    * Then the value "n/a" is used for the next execution time.
  1. Scenario: Formatting Previous and Next Execution Time
    * Given that a job has a previous or next execution time
    * When the job is displayed in the job summary
    * Then the previous and next execution time will be displayed in the format 01/01/2009 12:00pm.

**Story:** Sorting jobs

  * As Operations
  * I want to be able to sort the job summary by job name, previous execution time, or next execution time in both ascending and descending order
  * So that I can find jobs quickly by name, or easily analyze the job execution schedule.

  1. Scenario: Selecting the sorted property
    * Given that the job summary is not currently sorted by a given property
    * When the user clicks on the header for the property
    * Then the job summary is resorted by the property in ascending order
    * and an icon appears next to the property header to indicate that it is being sorted in ascending order.
  1. Scenario: Selecting the sort direction
    * Given that the job summary is currently sorted by a given property
    * When the user clicks on the header for the property
    * Then the job summary is resorted using the same property in the reverse order
    * and an icon appears next to the property header to indicate whether it is being sorted in ascending or descending order.
  1. Scenario: Sorting a job that has never executed
    * Given that one or more jobs exist that have never been executed
    * When the user sorts the job summary by previous execution time
    * Then the jobs that have never been executed are sorted to the top (in ascending order) or the bottom (in descending order) of the summary.
  1. Scenario: Sorting a job that will not be executed again
    * Given that one or more jobs exist that will not be executed again
    * When the user sorts the job summary by next execution time
    * Then the jobs that will not be executed again are sorted to the top (in ascending order) or the bottom (in descending order) of the summary.
  1. Scenario: Secondary sorting for time properties
    * When the job summary data is sorted by previous or next execution time
    * Then a secondary sort by name will be applied so that jobs without time data or jobs with identical time data will be sorted.

**Story:** Grouping jobs

  * As Operations
  * I want to be able to optionally group the job summary by group name
  * So that I can view related job information together.

  1. Scenario: Enabling grouping
    * Given that the job summary is not currently grouped
    * When the user enables the grouping option on the “Job Summary” page
    * Then the job summaries within the same group are displayed together under a group header
    * and the current sorting options are applied on a per group basis.
  1. Scenario: Disabling grouping
    * Given that the job summary is currently grouped
    * When the user disabled the grouping option on the “Job Summary” page
    * Then the job summaries appear as a single list
    * and the current sorting options are applied to the entire list.

**Story:** Sorting groups

  * As Operations
  * I want groups to be sorted alphabetically, with the default group always appearing first
  * So that it is easy to find the desired group.

  1. Scenario: Sorting the default group
    * Given that jobs exist in the default group
    * When the grouping option is enabled on the “Job Summary” page
    * Then the first group heading will be labeled “(Default)”.

**Story:** Default sorting and grouping

  * As Operations
  * I want job summary information to be ungrouped and sorted by ascending job name by default
  * So that it is easy to find a job by name.