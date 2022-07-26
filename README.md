# flight-booking
Angular - asp.net core project to book flights and following flights

## Table of content
Version      | Autor        | Comments                 |
------------ | -------------|--------------------------|
v 0.1 | Jeroen Branders  | Initial version of this Repo
v 0.2 | Jeroen Branders | Tracking progress and described what I learned in the Challenge
v 1.1 | Jeroen Branders | Track progress on learning - Keep up-to-date with Angular

## Day 01 - Day 04 challenge
1) Learning the basic of ASP.NET core and Angular
2) Learn some routing and creating components
   ```javascript
        npx ng g c book-flights --module app
        npx ng-openapi-gen
    ```
3) Create first HTML style in Angular component
4) Automatic generation of Open API classes in Angular 

## Day 04 - Day 07
1) Generate Open API - Configuration in Swahbuckle
2) How to update Open API in Angular
3) Event Hooks & Error handling
4) Lifecycle of the component

## Day 07 - Day 08
1) Life cycle hooks (onInit - ...)
2) Routing and route parameters
3) Setup a flight id param to send with a button
4) HTTP Status codes
   ```javascript
        1xx - Informational
        2xx - Success
        3xx - Redirection
        4xx - Client Error
        5xx - Server Error        
   ```
5) Attributes in Asp.net Core API (produces - ...)
6) Additional info about arrow function in Angular

## Day 09
1) FormBuiler in Angular
2) Mapping data between dto and rm models
3) Learn about static and record type (.NET)
   ```C#
     private static ILis<xx> TestList;
     private record Demo(string First, string Second);
   ```
4) Post form and create find method
5) Usaged of CreatedAtAction mehtod in Asp.net core Web API.

## Day 10
1) Learning how to create a service in Angular (AuthService)
2) Use arrow function
3) Make some navigation to register / login page.
    ```typescript
        import { Injectable } from '@angular/core';

        @Injectable({
          providedIn: 'root'
        })
        export class AuthService {

          constructor() { }

          currentUser?: User;

          loginUser(user: User) {
            console.log("Log in the user with email " + user.email);
            this.currentUser = user;
          }
        }

        interface User {
          email: string;

        }     
   ```
## Day 11
1) Creating new components like Book a Fight and My Bookings
2) Add some global CSS and header and footer styling
![image-progress](https://user-images.githubusercontent.com/78689165/182468280-5bbf049a-c75a-4303-9a05-ae94adf130fd.png)

## Day 12 - Day 13
1) Learning about Validation on Server side
2) Learning form Angular validation and messages
3) What is dirty / touched attributes in Angular?

![dirty-touch](https://user-images.githubusercontent.com/78689165/182949172-af4f8df4-a78c-4847-8203-18d0e849a0ca.png)

4) Learn about Domain Logic and created entities for the Domain
5) Return Readmodels instead of Entities

## Day 14 - Day 15
1) Domain Rule Validation 
   Protecting frontend and backend for malicious and abuse use of it.
   Domain -> flight booking (other wordt Business use case)
          -> Flight with 100 seats completely booked -> can not book again (overbooking => business specific)
2) Creating new entities for persistence of data
3) Dependency injection introduction - build-in ones for .NET Core >=6.0

## Day 16 - Day 17
1) Add package EntityFrameworkCore.InMemory
   ```PowerShell
      Install-Package Microsoft.EntityFrameworkCore.InMemory
   ```
2) Convert entities to dbsets<> and use them in the application
3) Entity framework error handeling
4) Program file added lines
   ```C#
      // Add db context
      builder.Services.AddDbContext<Entities>(options =>
      options.UseInMemoryDatabase(databaseName: "Flights"),
      ServiceLifetime.Singleton);

      builder.Services.AddSingleton<Entities>();

      var app = builder.Build();

      SeedService.Seeding(app);
   ```
4) Race Conditions (Concurrency) -> both booking for 1 seat.
    - Concurrency token
    - Handle DBUpdateConcurrencyException
    - Seat is overbookend now how we can avoid it?
  ![foto1](https://user-images.githubusercontent.com/78689165/183310955-49675cc6-6e5c-4593-bbc2-53c4b1507ad2.png)
  
  ![notbooked](https://user-images.githubusercontent.com/78689165/183310963-bc0c5091-8f59-4ed9-b9f3-e6e49868e8f2.png)


## Coming up some data validation
more to come =)
