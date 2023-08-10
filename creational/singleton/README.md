## Singleton

The Singleton pattern was developed to provide a common way of providing a single instance of an object throughout the whole application lifetime. So, as long as the application is not restarted, this instance must be the same regardless of how many times you instantiate it.

## Drawbacks

Sometimes, with poor implementation, the Singleton pattern can actually become an anti-pattern , the reasons are:

* It is really difficult to test if you are not using Dependency Injection, because it is statically created, so you can’t manually control it, as a result, you can’t mock it.
* It can lead to memory leaks if dependencies are not properly disposed after usage