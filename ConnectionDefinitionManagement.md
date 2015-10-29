**Story:** Creating a connection definition

  * As Operations
  * I want to create pre-configured connection definitions
  * So that I can quickly connect to Quartz instances.

  1. Scenario: Accessing the "Create Connection" page
    * Given that all requirements for creating a connection definition have been met
    * When the user selects "Create Connection" from the "Connection List" page
    * Then the "Create Connection" page is displayed
    * and the "Connection Name" field is displayed
    * and the "Connection Type" drop down is displayed with a default value of "Database"
    * and the database connection parameter template is displayed.
  1. Scenario: Saving a connection definition
    * Given that all requirements for creating a connection definition have been met
    * and the user has specified valid values for all of the fields
    * When the user attempts to save a new connection definition
    * Then the new connection definition is saved
    * and the "Connection List" page is displayed.

**Story:** Required connection name

  * As Operations
  * I want each connection definition to have a human-readable name
  * So that I can easily identify connection definitions.

  1. Scenario: Saving a connection definition without a name
    * Given that all requirements for creating a connection definition have been met
    * and the user did not specify a name on the "Create Connection" page
    * When the user attempts to save a new connection definition
    * Then the new connection definition is not saved
    * and the user is notified that they must specify a name.

**Story:** Unique connection name

  * As Operations
  * I want each connection definition to have a unique name
  * So that the connection name can be used as an identifier.

  1. Scenario: Saving a connection definition with an existing name
    * Given that all requirements for creating a connection definition have been met
    * and the user specified a name that is already in use on the "Create Connection" page
    * When the user attempts to save a new connection definition
    * Then the new connection definition is not saved
    * and the user is notified that the specified name is already in use.

**Story:** Database connection parameter template

  * As Operations
  * I want the system to provide a template for entering database connection parameters
  * So that I do not have to look up the required parameter keys when defining a new connection.

  1. Scenario: Specifying database connection parameters
    * Given that all requirements for creating a connection definition have been met
    * When the user selects "Database" as the connection type on the "Create Connection" page
    * Then the following fields are displayed... (TBD, should include Instance Name)

**Story:** Remoting connection parameter template

  * As Operations
  * I want the system to provide a template for entering remoting connection parameters
  * So that I do not have to look up the required parameter keys when defining a new connection.

  1. Scenario: Specifying remoting connection parameters
    * Given that all requirements for creating a connection definition have been met
    * When the user selects "Remoting" as the connection type on the "Create Connection" page
    * Then the following fields are displayed... (TBD, should include Instance Name)

**Story:** Custom connection parameters

  * As Operations
  * I want the ability to enter a custom set of connection parameters
  * So that I can handle situations where the templates are not appropriate.

  1. Scenario: Specifying custom connection parameters
    * Given that all requirements for creating a connection definition have been met
    * When the user selects "Custom" as the connection type on the "Create Connection" page
    * Then a set of n (TBD) key and value fields are displayed on the page.

**Story:** Valid connection parameters

  * As Operations
  * I want to validate a connection definition before it is saved
  * So that I am sure that the connection information is complete and accurate.

  1. Scenario: Saving a valid connection definition
    * Given that all requirements for creating a connection definition have been met
    * and the user has specified valid connection parameters
    * When the user attempts to save the new connection definition
    * Then the system is able to connect to the Quartz instance
    * and the new connection definition is saved.
  1. Scenario: Saving an invalid connection definition
    * Given that all requirements for creating a connection definition have been met
    * and the user has specified invalid connection parameters
    * When the user attempts to save the new connection definition
    * Then the system is not able to connect to the Quartz instance
    * and the new connection definition is saved
    * and the user is notified that the system could not connect to the instance with the specified connection parameters.


---


**Story:** Modifying a connection definition

  * As Operations
  * I want to be able to modify an existing connection definition
  * So that I can rename it or change the connection parameters if the associated Quartz instance changes.

  1. Scenario: Accessing the "Edit Connection" page
    * Given that all requirements for modifying a connection definition have been met
    * When the user selects "Edit Connection" from the "Connection List" page
    * Then the "Edit Connection" page is displayed
    * and the "Connection Name" field is displayed and populated with the current value
    * and the "Connection Type" drop down is displayed with the current connection type selected
    * and the appropriate parameter template is displayed and populated with the current values.
  1. Scenario: Saving a valid modified connection definition
    * Given that all requirements for modifying a connection definition have been met
    * and the user has specified valid values for all of the fields
    * When the user attempts to save a modified connection definition
    * Then the modified connection definition is saved
    * and the "Connection List" page is displayed.
  1. Scenario: Validating a modified connection definition
    * When the user attempts to save a modified connection definition
    * Then all of the validation rules described in the "Creating a Connection Definition" stories are applied as if the connection definition was new.