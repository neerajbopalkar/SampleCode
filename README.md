
# Sample Code!

# Table of Contents
- [ASP.Net Core web apis](#webapis)
-  [ASP.Net Core MVC](#ASPNetCoreMVC)
-  [ASP.NET MVC 5](#aspnetmvc5)
-  [SQL Server](#sqlserver)
-  [OWASP](#owasp)
-  [Performance, Security & Scalability](#performance)
-  [Check code changes](#review)
-  [References](#references)


<div id="webapis">

## `ASP.NET` Core web apis - V3.1  
    1.1 Configure ASP.NET request pipeline - *add Log4Net*  
    1.2 Creating the API & managing resources  - *Get, Post methods, model validation and returning proper status codes*  
    1.3 Working with services & DI  - *Registering and Injecting logger and custom services*  
    1.4 Environment specific config files    
    1.5 Exception handling

<div id="aspnetcoremvc">

## `ASP.NET` Core MVC - V3.0 [Images - [See here](02.AspDotNetCoreMvc/Readme.md)]
   
   *Reference - PluralSight Course by Gill Cleeren*

    **Overview**

    1. Ecommerce Web App       
    2. Login/Logout    
    3. Shopping Cart
    4. Checkout for
    5. Authentication

    **Technical aspects covered**

    1. Setting up MVC App & Creating listing page using hard coded data:
        1. MVC webapp  
        2. _Layout, _ViewStart for templates and razor syntax
        3. ViewModel & strongly typed views
        4. DI container usage for injecting services (e.g. repository) for loosely coupled design. Different types of registrations such as singleton & transient
        5. Using Libman for managing client side libraries - bootstrap & jquery
        6. Setting up HTTP Request pipeline and adding middlewares
    2. Working with real data using EF Core
        1. Nuget packages addition & model, DB context creation
        2. Creating database using code first
        3. Using add-migration and update-database commands to - create tables & populate data
        4. modifying the model and update the database
    3. Adding navigation to the site
    4. Improving views in the application
    5. Creating order form
    6. Adding login capabilities to the site
    
<div id="aspnetmvc5"/>

## `ASP.NET` MVC 5 (Web application and Web APIs)

[Repo of Mosh]( https://github.com/mosh-hamedani/vidly-mvc-5)

    1. fundamental features:  
        1. routing, 
        2. MVC architecture, 
        3. Action Results, 
        4. Razor syntax and
        5. partial views
    2. Working with data: 
        1. EF, 
        2. code first and database first, 
        3. change model, 
        4. seeding database, 
        5. querying
    3. Building forms:
        1. Markup and UI controls
        2. model binding
        3. Saving data
    4. Validations:
        1. Annotations and custom validations
        2. Anti-forgery tokens
    5. Web APIs
        1. Build APIs and DTO
        2. Auto Mapper
    6. Client side development
        1. Calling API with JQuery
        2. Data tables with AJAX source
    7. Authentication & Authorization:
        1. ASP.NET Identity
        2. OAuth
        3. Social logins
    8. Performance optimization
        1. Profile & debug with Glimpse
        2. Outputcache
        3. Async
    9. Deployment
        1. Application and database
        2. Custom error pages
        3. Logging unhandled exceptions
        4. 

<div id="sqlserver"/>

## SQL Server

Install SQL Server Express & SSMS: [Here](https://www.microsoft.com/en-in/sql-server/sql-server-downloads) 

Install SSMS: [Here](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

Install Test DB NorthWind: [Here](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs)

Tutorials on NorthWind: [Here](https://www.w3schools.com/sql/sql_update.asp)

<div id="owasp"/>

## OWASP Top 10 
1. Identify the [OWASP](https://owasp.org/www-project-top-ten/) top 10 threats
2. Explain the impact per threat for your business
3. Understand how the OWASP top 10 threats can be executed by attackers
4. Understand how the OWASP top 10 threats may be mitigated

<div id="performance"/>

## Performance, scalability & security

Performance is an indication of the responsiveness of a system to execute any action **within a given time interval**, 

Scalability is ability of a system either to handle increases in load **without impact on performance** 

<div id="review"/>

## Review history

See the differences between two commits - [Details](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/about-comparing-branches-in-pull-requests#three-dot-and-two-dot-git-diff-comparisons)

Current repo example: [Here](https://github.com/neerajbopalkar/SampleCode/compare/ebe5a2f78038cb93c8171e2137181e991f1e4de4..d369071bea86b2bc6bd91d6daed9f6813f6d457a)

<div id="references"/>

## *References:*
1. [Performance and Scalability patterns](https://docs.microsoft.com/en-us/azure/architecture/patterns/category/performance-scalability)

2. [Performance Vs Scalability](https://www.dynatrace.com/news/blog/performance-vs-scalability/)

3. [ASP.NET Performance](https://docs.microsoft.com/en-us/aspnet/mvc/overview/performance/)        
    1. Using Asynchronous Methods in ASP.NET MVC 5
    2. Profile and debug your ASP.NET MVC app with Glimpse
    3. Bundling and Minification

4. [10 Best Practices to Secure ASP.NET Core MVC Web Applications | Syncfusion Blogs](https://www.syncfusion.com/blogs/post/10-practices-secure-asp-net-core-mvc-app.aspx)

5. [Security, Authentication, and Authorization with ASP.NET MVC](https://docs.microsoft.com/en-us/aspnet/mvc/overview/security/)
    
    1. Facebook, Twitter, LinkedIn and Google OAuth2 Sign-on (C#)
    2. Log in, email confirmation and password reset (C#)
    3. SMS and email Two-Factor Authentication
    4. XSRF/CSRF Prevention in ASP.NET MVC and Web Pages
    5. Preventing Open Redirection Attacks (C#)

6. [Security - OWASP .NET Framework Guidance](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html#net-framework-guidance)
7. [Security - OWASP Top 10 ASP.NET MVC Guidance](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html#asp-net-mvc-guidance)

8. [In GitHub, is there a way to see all (recent) commits on all branches?](https://stackoverflow.com/questions/33926874/in-github-is-there-a-way-to-see-all-recent-commits-on-all-branches)
    
9. Creating own OAuth 2 Authorization Server - Creating **identity** server 
    
    Code - [here](https://github.com/IdentityServer/IdentityServer3.Samples) & 
    
    Overview [here](http://docs.identityserver.io/en/release/intro/big_picture.html#)


<!-- ![Alt text](Images/Tulips.jpg?raw=true "Tulipse") -->