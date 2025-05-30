# sample-hcm
# Design a sample HCM App

This assessment aims to test your knowledge of system design and database modeling skills. The objective is to design a database and the corresponding .NET model entities. The database should support operations related to employee management, payroll processing, and compensation, and the .NET application should handle these operations effectively.

One of the central parts of the assessment will be designing a SQL model. You can use your preferred tool, but below are some suggested options. We suggest that you spend time installing and familiarizing yourself with the selected tool before starting the assessment

*Suggested Tools*:

- Loom: https://loom.com
- Draw SQL: https://drawsql.app/diagrams
- Whimsical: https://whimsical.com
- Draw IO: https://draw.io
- DB Diagram: https://dbdiagram.io
- Visual Studio Code: https://code.visualstudio.com/download
- Entity Framework Core: https://learn.microsoft.com/en-us/ef/core/
- Postman: https://www.postman.com/

## SQL Strategy and Architecture for a Payroll Solution

In this assessment, you will be submitting your solution using git. To do so, you will need to clone this repo, and push all your changes to the dev branch (which is also the default branch). You will be submitting this assessment by creating a pull request between the dev and the main branch. YOU WILL BE REQUIRED TO PERFORM THIS TASK WITHIN 2 HOURS, SHARING A LOOM LINK COVERING YOUR SCREEN SHARE DURING THE ENTIRE SESSION.

### Introduction

For this assessment, you are part of a team that will create a Payroll application for an organization. Your role in this team is to create a Database and .NET Application model that supports all the business requirements of the application.

#### Task 1: Create a Database Model Diagram

Using a database modeler software (you can use one of the suggestions outlined above or whichever tool you feel comfortable with), this task consists of creating a database diagram that meets all the business rules that will be detailed below. Your tool needs to export the diagram as a png or jpg. You can select either a SQL or NoSQL approach for your database model. For this task, you will create a file called **database-model.png** or **database-model.jpg**  and upload it to the provided GitHub repository.

*We suggest that you spend no more than 120 minutes on this task.*

Create a database model diagram that includes the following entities:
- Employee
- Payroll
- Salary
- Leave Request
- Tax
- Bank Account

Your design should include relationships such as:
- One-to-many relationships (e.g., Employee to Payroll, Employee to LeaveRequest)
- One-to-one relationships (e.g., Payroll to Salary)
- Foreign key references to ensure data integrity

The database should support the following features:
- Employee management
- Payroll processing
- Leave requests
- Tax calculations
- Bank account details

Your diagram should be scalable and support the growing number of employees and payroll records, allowing for efficient queries and data retrieval.

#### Task 2: Create .NET Application Model

Once the database model is created, create corresponding .NET Core entities (model classes) for the following:
- Employee
- Payroll
- Salary
- LeaveRequest
- Tax
- BankAccount

Each entity should be mapped to its respective table in the SQL Server database. Consider the following for each model:
- Entity Framework Core: Use EF Core to manage the relationships between these entities.
- Data Annotations: Use data annotations for validation (e.g., [Required], [StringLength], etc.).
- Navigation Properties: Define the navigation properties for relationships between entities (e.g., public ICollection<Payroll> Payrolls {  get; set; } for one-to-many relationships).

#### Task 3: Implementing .NET Core Services for Payroll Processing
For this task, implement the backend services in .NET Core that interact with the database. Focus on the following functionalities:

Employee Management Service:
- Implement CRUD (Create, Read, Update, Delete) operations for employee records.
- Ensure proper validation and data consistency when modifying employee details.

Payroll Processing Service:
- Implement logic for calculating payroll based on employee salary, bonuses, and deductions.
- Implement logic for handling taxes (e.g., tax calculation based on tax brackets).
- Provide methods for generating payslips and marking payroll as processed.

Leave Management Service:
- Implement functionality to create, approve, and reject leave requests.
- Track leave balances and deduct from them accordingly.

Tax Service:
- Implement a service that calculates tax deductions based on employee salary and applicable tax rates.
- Implement a mechanism to store tax rates in the database and apply them to payroll processing.

For each service:
- Use Dependency Injection to inject repositories and other services.
- Use Asynchronous Programming (e.g., async/await) for I/O operations such as database queries.
- Ensure separation of concerns (e.g., controllers should only handle HTTP requests, while services contain the business logic).


#### Task 4: Discuss thought process and database approaches.

The first part of this assessment was creating a database model and the application architecture. For this section, discuss your decisions related to both the database design and the .NET application architecture. 
Please create a markdown file called **notes.md** in the provided GitHub repository. In that file, outline your thought process for designing the database model. In your notes, please address the following:
- Decisions and Assumptions: Why did you choose certain entities and relationships for the database? What assumptions did you make about the requirements (e.g., data consistency, concurrency)?
- SQL vs NoSQL: Justify your choice of SQL Server for this payroll solution. Why is a relational database beneficial for handling payroll data? Discuss how you would handle potential scalability issues with SQL.
- ORM (EF Core): Why did you choose Entity Framework Core as the ORM for interacting with the SQL Server database? How will it help with data management and migrations?
- Weaknesses of Your Approach: Identify any potential weaknesses in your design or .NET architecture, and explain how you would mitigate them (e.g., optimizing SQL queries, using background jobs for payroll processing).
- Performance Considerations: How did you ensure your design will scale as the payroll system grows? Discuss things like indexing, efficient querying, and caching strategies for frequently accessed data.

*We suggest that you spend no more than 60 minutes on this task.*

#### Task 5: Next Steps Architecture Suggestions

The final task is to give some suggestions for the future development of this project. The next step will be a full design of the application, with the trade-off of different architectural drivers as the main activity.

Please create a second file named **proposal.md**. In it, we would like you to add at least one suggestion about how we could design the software to reach each of the architecture drivers named below:
Security:
- Implement Role-Based Access Control (RBAC) for accessing payroll data, ensuring only authorized users can access sensitive information.
- Use JWT (JSON Web Tokens) for securing APIs and ensuring proper authentication and authorization.
- Encrypt sensitive data (e.g., salary information) both in transit (via HTTPS) and at rest (via SQL Server encryption).

Availability:
- Use Load Balancing and Replication to ensure high availability of the payroll system, especially during payroll processing times.
- Implement Database Failover to minimize downtime in case of database failures.

Reliability and Robustness:
- Implement Transaction Management to ensure that payroll data is consistent and no information is lost if a failure occurs during processing.
- Use Unit Testing and Integration Testing to ensure the reliability of payroll calculations, tax deductions, and leave management.
- Implement Background Jobs for long-running tasks like payroll calculations to improve the user experience and offload work from the main thread.

*We suggest that you spend no more than 60 minutes on this task.*

**Submitting Your Solution**
Open a pull request from dev into main once you are ready to submit. Do not merge the pull request.
Add the link to the loom video in the Pull Request description
