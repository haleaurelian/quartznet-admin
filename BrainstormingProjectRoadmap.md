# Approach #

  * BDD - Behavior driven design
  * MVC - Model View Controller pattern
  * TDD - Test driven development
  * Many small releases

# Features #
  * Connect via remoting to multiple instances of Quartz
    * Instance information stored in database
    * Assembly containing job definition will have to be stored as part of quartz admin, maybe in DB and dynamically loaded into app domain
  * View Jobs and Triggers configured in an instance
    * Ajax and YUI grid to display and update automatically
  * Run job immediately
  * Schedule job
    * We might need to push an assembly to the quartz instance via remoting to schedule a new job type
    * This could entail creating a quartz wrapper to expose the methods we need
    * Very dynamic AJAX UI needed to handle all the scheduling options available in Quartz CRON implementation
  * View job history
    * Ajax and YUI grid to display and update automatically
  * View job schedule
    * Silverlight timeline control
    * Allow viewing of jobs schedules across multiple instances
    * Can be filtered by instance, job, time frame, maybe more
    * Possibly allow dynamic rescheduling of job by dragging on the timeline
  * Data access will not be limited to a particular RDMS
    * Initial support will be for MSSQL and SQLLite
    * Current direction for data layer is [Castle ActiveRecord](http://www.castleproject.org/activerecord/index.html) (based on NHibernate)
  * XHTML compliant layout, CSS positioning
  * Multiple authentication options using MembershipProvider model
    * Forms based
    * Windows based
    * None