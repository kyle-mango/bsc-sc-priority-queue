# 📈 Priority Queue Class Library - Assessment 1 Starting Repo

This repository serves as the starting repository for **Assessment 1** of the **BSc Computing** module **UG409765 - Software Construction** and serves as the foundation for the Priority Queue class library assignment.

## ℹ️ **Overview**
This repository provides the initial codebase for the Priority Queue class library. Students are tasked with completing and extending this codebase by 
implementing four additional Priority Queue data structures, thoroughly testing them, and reflecting on the development process. 

## 🔧 **Repository Structure**

- `PriorityItem.cs`: A class representing individual items within the priority queue. It includes properties for the item and its priority.
- `IPriorityQueue.cs`: An interface defining the required methods for all Priority Queue implementations. This interface must not be modified.
- `QueueOverflowException.cs`:  A custom exception class for handling scenarios where the queue exceeds its defined capacity.
- `QueueUnderflowException.cs`: A custom exception class for handling scenarios where an operation is attempted on an empty queue.
- `SortedArrayPriorityQueue.cs`: A complete implementation of the Priority Queue using a sorted array. This serves as an example and a reference for creating additional implementations.

A small test program is provided as a separate project containing

- `Person.cs`: Modelling a person class to use as the queue subject
- `QueueManager.cs` A driver program implemented as a Windows Form application. It allows users to interact with and test different Priority Queue implementations.

## ✅ **Submission**
1. Clone this repository and work on your private own copy.
2. Use version control to track all changes.
3. Please **do not** create public clones containing solutions.

## ⚠️ **Important Notes**
- Keep track of your development process using Git version control.
- Regularly commit your progress with meaningful and descriptive messages.
- Refer to the assessment brief for detailed requirements and marking criteria.
- Do not in any way share public solutions to this assessment.