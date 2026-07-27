# Day 2 – Advanced LINQ & Deferred Execution

##  Overview
This project demonstrates advanced LINQ operations in C#, including grouping, joining, flattening collections, and deferred execution.

##  Learning Objectives
- Understand deferred vs. immediate execution.
- Group data using `GroupBy`.
- Combine collections using `Join`.
- Flatten nested collections with `SelectMany`.
- Understand deferred execution behavior in LINQ.

## Topics Covered
- GroupBy
- Join
- SelectMany
- Deferred Execution
- LINQ Method Syntax

## Hands-On Lab

### 1. Create Related Collections
Created two related collections:
- Customers
- Orders

The relationship is based on `CustomerId`.

### 2. GroupBy
Grouped orders by customer and calculated the total order amount for each customer.

### 3. Join
Joined customers with orders to display customer names alongside their order amounts.

### 4. SelectMany
Flattened nested order collections into a single sequence.

### 5. Deferred Execution
Demonstrated that a LINQ query is executed only when enumerated, not when it is defined.

##  Technologies
- C#
- .NET
- LINQ
- VS Code

## What I Learned
- How to use advanced LINQ operators.
- The difference between grouping and joining data.
- How `SelectMany` flattens nested collections.
- The concept of deferred execution and when LINQ queries actually execute.