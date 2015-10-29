**Story:** Execute existing job

  * As Operations
  * I want to execute an existing job immediately
  * So that I can run jobs on demand

  1. Scenario: Execute a job
    * Given a quartz instance is running
    * When I select a job to execute
    * Then the job should be run in the quartz instance
  1. Scenario: Execute a job with JobData
    * Given a quartz instance is running
    * When I select a job to execute
    * And pass data to it
    * Then the job should be run in the quartz instance, with the data in the JobData map