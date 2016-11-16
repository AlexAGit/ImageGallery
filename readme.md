##### 1. How long did you spend on the coding test?

> I've spent two and a half hours because I wanted to see it in a real life scenario and wanted to create a very small UI for it.

##### 2. What would you change / implement in your application given more time?

> I would try to make the repository testable. Also I could handle the exceptions that the retriever might get from the client. Also add some more tests to cover those scenarios.

##### 3. Did you use IOC? Please explain your reasons either way.

> I thought that the data retrievers could be of different types (internet or cached locally or database even) so I opted for the creation of IDataRetriever. 
> Also because of the common structure of the response I made the Response to have the Data property of a generic type in order to be able to accomodate other types of response structures.

##### 4. How would you debug an issue in production code?

> In production it is not recommended to debug. You can either check the application log or the operating system events to detect the problem. If that does not help trying to reproduce a similar environment on a development machine and debugging could provide the answer. These kind of environments need to be in place and kept up to date with the production environment.

##### 5. What improvements would you make to the cat API?

> I would add security, pagination information, more detailed image information. 

##### 6. What are you two favourite frameworks for .Net?

> ASP. NET MVC and ASP .NET Web API

##### 7. What is your favourite new feature in .Net?

> Await, async, parallel, volatile which make working with threads easier.

##### 8. Describe yourself in JSON.

> [{
	"firstName": "Ionut",
	"middleName": "Alexandru",
	"lastName": "Achim",
	"gender": "male",
	"qualities": [		
		"team player",
		"quick thinker",
		"always up for new challenges"
	]
}]