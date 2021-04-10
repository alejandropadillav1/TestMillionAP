# Test Real Estate API

A large Real Estate company requires creating an API to obtain information about properties in the United States, this is in a database as shown in the image, its task is to create a set of services:

Developed by Alejandro P

- a) Create Property Building 

This is a http post, to create new property building (Property Table), you can complete the following attributes. If the Owner Id doesn't exist, it will create automatically
with a default attribute, you can edit these following parameters into a Update View property.

### IMPORTANT NOTE : If you want to create a PropertyTraceAsync using with /api/RealEstate/CreatePropertyTraceBuilding Method with the default Id Property, simply untick the Send Empty Value into a IdProperty and IdPropertyTrace Attribute in order to create its Property trace in a Swagger UI.

- b) Add Image from property.

Http post, you can add the image and convert a byte array. If the Property Id doesn't exist, it will create automatically with a default attribute.

- c) Change Price

Http put, if the Id Property exist, it could update the price, if not, it should throw an exception as expected.

- d) Update Views property

http put, check if the Id Property exist, it will update the general property, property trace and the owner.

- e) List property with filters.

It should be a optional statement, because of the frontend almost all of the control will have a robust and faster filter Grid Controll. By the way I implement the Year's filter.


## Additional considerations.
- SOLID Principles incluided
- Dependency Injection Pattern -  Scoped.
- Async/await incluided
- Clean Code.
- High Availability
- Application Insight Azure is included in order to monitor the performance and finding out the bottle-neck.
- NUnitTest included with each parameters.
- Security will be include in a next phase (The best option is using with JWT Bearer Authentication)
    
    
## Installation Instructions
- Clone the Git into a local folder.
- Start the TestMillionAP solution for Visual Studio.
- Change the ConnectString into a appsettings.json into a TestMillionAP project, make sure that you are going to connect through SQL Server.
- Optional: For this solution doesn't required to restore a SQL Server backup, because of when you start the project and put any information with the 
  correct ConnectionString, there will automatically create a clean database with several characteristic, if you need to restore, you can find out this bak into
  a repository. (Database folder).
- When you start the project, it should launch the web page redirected to Swagger and enjoy it.

    

