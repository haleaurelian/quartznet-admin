# Release 0.1 #
  * Add / edit instance (MD)
  * Connect to the instance (TJT)
  * View jobs / triggers (MD)
  * Execute existing job (TJT)
  * "Plumbing"
    * Persistence mechanism
    * Error handling
    * Logging


# Release 0.2 #
  * Schedule existing job
    * Rich ajax ui for all scheduling options
    * Assign multiple triggers to jobs
  * Silverlight timeline control
  * Security features
    * Membership providers
      * AD
      * SQLite
      * SQL Server
    * Establish role based security
      * Read only for history
      * Who has access to an instance
      * Scheduling and restarting jobs
      * Instance admin
  * Theme of the app
    * CSS based positioning
    * Reskinning of site should be through CSS
    * Logo
    * Make it look pretty
  * Plumbing
    * Refine low level services
    * Error handling
    * Logging
    * View / administer roles / permission mapping

# Release 0.3 #
  * Quartz extensions
    * View job history
      * Custom Quartz plugin
    * Custom designer functionality for defining job setup
    * How do we "publish" a job to a running instance
    * Command line tool for deployment to QuartzAdmin (includes push to instances)
  * Silverlight timeline change schedule functionality