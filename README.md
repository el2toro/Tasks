# Tasks

### Projects description

- **Task1**
Contains implementations to calculate area of different geometric figure, also methods to check if a triangle is right or valid.

- **Task2**
Contains SQL Server scripts to create a database, tables and seeds for those tables, also a script to select Products and their Category.

- **Task3**
Contains an implementation to find the smallest indices *start* and *end* in a way that the *sum* between and including them is equal to the input *sum*.

- **Task4**
Contains CRUD operations to manage Eployees.

- **Core**
Contains logging and validation behavior, also CQRS, pagination request and result.

- **Task4.ClientApp**
Angular website that can be [downloaded here](https://github.com/el2toro/Task4.ClientApp)


## Task4 description
### TechStack

**Backend**: .NET 8, C#, EntityFramework, Carter, Mapster \
**FrontEnd**: Angular, Angular Material \
**Database**: SQL Server \
**Patterns**: Mediator, CQRS, Repository 

### Folder structure
DbScripts: inculudes sql server queries related to the task 4 \
Employees: includes endpoints and handlers for CRUD operations \
Exceptions: includes custom exception handler and different kind of exceptions \
Validators: includes request validation rules

## How it works
When a request reach an endpoint, it is forwarded to the right handler via Mediator, then a validation behavior is triggered. After a successfull validation, handle method is entered. Before executing the business logic logging behavior is triggered then the code is executed, after that one more time logging is called to log end of operation. 


## Run Locally

Clone the backend projects

```bash
  git clone https://github.com/el2toro/Tasks.git
```

Go to the downloaded project directory, find *Tasks.sln* file and open it with Visual Stutio.

In the solution find *Task4* --> right click --> *Set as Startup Project*  --> *Start*  (https)

It will be listening at: https://localhost:7033


### Get started with frontend
Clone repository

```bash
  git clone https://github.com/el2toro/Task4.ClientApp.git
```
Go to downloaded project directory

```bash
  cd Task4.ClientApp
```

Install dependencies, make sure your node version is >= 18

```bash
  npm install
```

Start application

```bash
  npm start
```

The app will be running at: http://localhost:4200

