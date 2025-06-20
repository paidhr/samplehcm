## Decisions and Assumptions

- I chose to use **Entity Framework Core InMemory** for this prototype to simplify development and make it easy to run without a SQL Server instance.
- For production, a relational database (SQL Server or PostgreSQL) would be used to ensure **ACID transactions** and **data integrity** for payroll data.
- The Employee and BankAccount entities were designed as a **one-to-one relationship**. This initially caused JSON cycles when serializing — I used `ReferenceHandler.IgnoreCycles` to handle this.
- I assumed that salary components (base salary, bonus, deductions) can vary between payroll periods, so I designed Salary as a **separate entity linked to Payroll** (one-to-one).
- Leave requests can be submitted by employees and approved/rejected by managers. I kept the LeaveRequest entity simple for this prototype.
- Tax rates are currently stored in memory — in production, they should be in a database table with effective dates.

## SQL vs NoSQL

I chose a **relational SQL approach** because:

- Payroll requires strong **consistency** and **relationships** (e.g., Employee → Payroll → Salary → Tax).
- SQL makes it easy to run complex queries (e.g., for reports, tax audits, payslip generation).
- NoSQL would make it harder to maintain transactional integrity for payroll runs.

To scale, I would:

- Add indexes on EmployeeId and PayrollId.
- Archive old payrolls to history tables.
- Use database partitioning if needed for very large datasets.

## ORM (EF Core)

I used **Entity Framework Core** because:

- It simplifies model definition via code-first.
- Provides **automatic migrations** when using a relational DB.
- Allows strong typing and LINQ queries in C#.
- InMemory provider is perfect for testing.

## Weaknesses

- The InMemory version is not thread-safe for concurrent writes — this is fine for prototype but would not work under real concurrency.
- The PayrollService is currently synchronous for tax calculation — could move long-running calculations to background jobs.
- Tax rates are hardcoded — should be moved to database configuration.
- No concurrency control yet for leave balances.

## Performance Considerations

- For scaling, I would add:

    - Indexes on EmployeeId, PayrollId.
    - Caching for tax rates.
    - Background jobs for payroll runs.
    - Bulk inserts/updates for processing large payroll batches.