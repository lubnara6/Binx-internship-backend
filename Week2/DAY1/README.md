# Day 1 - Generics and Advanced Collections

## Overview

This project demonstrates how to use generics and advanced collection interfaces in C# by building a reusable generic repository.

## Learning Objectives

* Understand why generics provide type safety.
* Create generic classes using type parameters.
* Apply generic constraints.
* Use `IReadOnlyList<T>` to prevent direct modification.
* Use a predicate to search for items.

## Generic Repository

The `Repository<T>` class includes the following methods:

* `Add(T item)` adds a new item to the repository.
* `GetAll()` returns all items as an `IReadOnlyList<T>`.
* `Find(Predicate<T> predicate)` returns the first item that matches a condition.

The repository uses the following constraint:

```csharp
where T : class
```

This constraint ensures that the repository only works with reference types such as `Product` and `Order`.

## Domain Models

The repository is tested using two different classes:

* `Product`
* `Order`

This demonstrates that the same generic repository can work with different data types without duplicating code.

## Read-Only Collection

The `GetAll()` method returns:

```csharp
IReadOnlyList<T>
```

This allows the caller to read the items but prevents adding or removing items directly.

## Run the Project

```bash
dotnet run
```

## Expected Features

* Add products and orders.
* Display all stored items.
* Search for a specific product.
* Search for a specific order.
* Protect the returned collection from direct modification.
