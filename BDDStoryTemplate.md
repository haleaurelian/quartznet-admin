# Introduction #

One of the goals of this project is to utilize the Behavior Driven Development (BDD) methodology for analysis and design. A key practice in BDD is to capture the definition of features in the form of stories. A story describes the scope of a feature, why it is beneficial, who it benefits, and its acceptance criteria.  A feature is considered complete when all of the acceptance criteria has been met.

It is highly recommened that you read the following two articles if you are not familiar with this process:

  * [Introducing BDD](http://dannorth.net/introducing-bdd)
  * [What's in a story?](http://dannorth.net/whats-in-a-story)


# Story Template #

For this project, we will use the standard BDD story template:

1) Title

> Story: _one line describing the story_

2) Narative

> As a _role_<br>
<blockquote>I want <i>feature</i><br>
So that <i>benefit</i></blockquote>

3) Acceptance criteria<br>
<br>
<blockquote>Scenario 1: <i>brief description that differentiates the scenario from others</i><br>
Given <i>context</i><br>
And <i>some more context</i>...<br>
When <i>event</i><br>
Then <i>outcome</i><br>
And <i>another outcome</i>...</blockquote>

<blockquote>Scenario 2: ...</blockquote>

For example:<br>
<br>
<blockquote>Story: Defining a connection</blockquote>

<blockquote>As a system administrator<br>
I want to save a validated connection definition to a quartz instance<br>
So that I know the connection data is valid and I can assign security to the definition<br></blockquote>

<blockquote>Scenario 1: Valid remoting URL<br>
Given the remoting endpoint is available<br>
When the definition contains a valid remoting URL<br>
Then the system successfully creates a remote object to validate the URL<br>
and the definition is stored<br>
and the user is notified that the definition was stored<br></blockquote>

<blockquote>Scenario 2: Invalid remoting URL<br>
When the definition contains an invalid remoting URL<br>
Then the system fails to create a remote object while trying to valid the URL<br>
and the definition is not stored<br>
and the user is notified that the specified remoting URL could not be validated<br>
and the user is notified that the definition was not stored<br>