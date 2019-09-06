## Phone Book | DotnetCore MVC Application  

#### SQL Database Setup
 - Create a database (MySQL) called PhoneBookDb & Run the sql dump file attached on the project to create the tables.
 - Update the connection string on the api to your server connection string. 

## The PhoneBook Application
The applications adds phonebook entries to a database, the shows the list on the start page. This is achieved by using an api.

## The PhoneBook API 
 The api contains 2 endpoints used in the main mvc app to add and or querry data.
 
 ### Add Entries
 
 - Method: [Post]
 - URL : localhost:[port]/api/entries 
 - Payload: {"Name": "Jon", "PhoneNumber": "2142555"}
 
 
  ### Get Entries
 
 - Method: [Get]
 - URL : localhost:[port]/api/entries?Name=xx&&PhoneNumber=yy
