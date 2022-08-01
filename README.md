# flight-booking
Angular - asp.net core project to book flights and following flights

## Table of content
Version      | Autor        | Comments                 |
------------ | -------------|--------------------------|
v 0.1 | Jeroen Branders  | Initial version of this Repo
v 0.2 | Jeroen Branders | Tracking progress and described what I learned in the Challenge

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

https://github.com/tutorialseu/ang-asp-21dc-flight-booking-portal
