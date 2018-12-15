# EixampleDotnet

An alternative to ASP.NET Boilerplate

## Multi-Tenant Angular &amp; ASP.NET WebAPI 2 template

**Tenant is resolved by wildcard subdomain automatically**

`ASP.NET WebAPI 2`, `Entity Framework 6`, `OWIN`, `Autofac`, `AutoMapper`, `SQL Server`, `Swashbuckle`, `Angular 6`, `Bootstrap 4`

If you are looking for .NET Core edition - check the repository named **eixample** (lowercase).

![video](https://media.giphy.com/media/fxejF70APnbvSa8oyT/giphy.gif)

## Table of Contents

 - [Benefits](#benefits)  
 - [About](#about)  
 - [Features](#features)  
 - [Setup](#setup)  
 - [Developing Apps](#developing-apps)  
   - [Generating Proxies](#generating-proxies)
   - [Roles & Permissions](#roles-and-permissions)
     - [Guidelines](#guidelines)
   - [Front-End](#front-end)
     - [User / Session Data](#user-data)
     - [Template](#template)  
 - [<b>Screenshots</b>](#screenshots)   

<a name="benefits"/>

## Benefits

 - functionality identical to [ASP.NET Boilerplate](https://aspnetboilerplate.com/) reproduced in accordance with [YAGNI & KISS](https://www.itexico.com/blog/software-development-kiss-yagni-dry-3-principles-to-simplify-your-life) principle
 - ability to deal with pure `ASP.NET / ASP.NET Core` framework
 - ability to use whatever libraries you want (and related docs) - no having to deal with `Abp.*` wrappers
 - ability to easily tweak any part of the app
 - easy way of learning multi-tenant application design

<a name="about"/>

## About

Eixample is

 - a building basis for multi-tenant SPA apps
 - designed to be minimal and straightforward
 - to be considered as unofficial Visual Studio template

Eixample does NOT

 - dictate how you should code your app
 - need documentation <br> (you only deal with native docs of the packages used by the application)

Eixample allows you

 - to deal with pure `ASP.NET framework` and design / redesign your app including the core functionality the way you like, which means more freedom and control
 - to upgrade original packages outright <br> (no extra difficulties as with upgrading from ABP 1.x.x to ABP 4.x.x.)

Back-end & front-end are stored separately.

<a name="features"/>

## Features

 - Multi-Tenancy
 - Wildcard subdomain support (tenant resolved by subdomain automatically)
 - Audit (both for EF 6.x and EF Core)
 - Mapping (AutoMapper)
 - Service Layer / DI (Autofac)
 - PostgreSQL (snake_case names)
 - SQL Server
 - EF 6.x Dynamic Filters
 - Soft Delete
 - Seed Data
 - OWIN (WebAPI 2 edition)
 - NSwag / Swashbuckle (automatic HTTP proxies generation for the front-end)
 - JWT Authentication
 - SPA front-end (Angular)
 - ng-bootstrap (Bootstrap 4)
 - SB-Admin-BS4-Angular-6 template with lazy-loading
 - toastr alerts (incl. exception handling)
 - basic login / signup functionality
 - demo functionality (demonstrates auditing for EF entities)
 - one user per many tenants (as with *.stackexchange.com)

<a name="setup"/>

## Setup

The setup is pretty straightforward if you are familiar with `Entity Framework Code First` approach & `Node.js`.

Add to hosts:

```
127.0.0.1       eixample
127.0.0.1       restaura.eixample
127.0.0.1       galeriasenda.eixample
```

Open back-end solution in Visual Studio, make sure the connection string is correct.

Go to `Package Manager Console` and run the following command against Entity Framework project:

```
Update-Database
```

Note that Seed Data doesn't work with SQL Server 2017 without explicitly stating `DateTime` fields are of `datetime2` type e.g.

```
[Column(TypeName = "datetime2")]
```

Go to *angular* folder & run the following commands:

```
npm install
ng serve --host eixample --disable-host-check --port 4000
```

Access the website 

```
http://restaura.eixample:4000
http://galeriasenda.eixample:4000/
```

Note that `restaura` & `galeriasenda` are subdomains in this case.

Default login details:

```
username: admin
password: 123qwe
```

You can of course create your own user on *Register* page.

Verified with:
```
Angular CLI: 7.1.2
Node: 10.14.1
OS: win32 x64
npm v6.4.1
```

<a name="developing-apps"/>

## Developing Apps

<a name="generating-proxies"/>

### Generating Proxies

As you add or modify your API controllers you need to **regenerate** typescript HTTP proxies for the Angular app.

1. go to `./angular/nswag` folder
2. run `refresh.bat` file
3. `./angular/src/shared/service-proxies/service-proxies.ts` gets updated

Note that we have `headers.js` file in `./angular/nswag` folder. This script is required to amend proxies file by adding `Authorization` header needed for JWT Authentication.

For more info on `NSwag` refer the [following page](https://www.npmjs.com/package/nswag).

<hr>

<a name="roles-and-permissions"/>

### Roles & Permissions

Please note that the project is decidedly lacking permission system which comes complete with ABP framework.

The reason is - there are several designs:

 - roles & permissions are shared across all tenants
 - each tenant has its own set of roles & permissions
 - roles without permissions
 - roles & permissions are not required at all

It's best not to overcomplicate the project with certain implementation.

This part is covered by [ASP.NET docs](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api) and is completely in your hands.

<a name="guidelines"/>

#### Guidelines

On the internet you can find many tutorials covering Roles & Permissions in ASP.NET - hence no problem implementing / overriding the default functionality the way you need.

For instance - [this stackoverflow post](https://stackoverflow.com/q/21542642/5374333) or the following [thread on reddit.com](https://www.reddit.com/r/dotnet/comments/3yrpo7/aspnet_identity_to_configure_permissions/).

If you are to impement the permission system - consider coding a bunch of Stored Procedures for maximum performance.

<hr>

<a name="front-end"/>

### Front-End

<a name="user-data"/>

#### User / Session Data

The data related to current user / session is lazy-loaded via a resolver - `UserDataResolver`.

`app-routing.module.ts`

```
const routes: Routes = [
    { path: '', loadChildren: './layout/layout.module#LayoutModule', canActivate: [AppRouteGuard], resolve: { resolver: UserDataResolver } },
```

See `app-routing.module.ts`, `user-data-resolver.ts`, `user-data.service.ts` for more info.

The shared service `UserData` is injected into other components interested in user / session data.


As mentioned above - when Roles & Permissions are implemented you can pass related info to front-end in this hook. Thus we are replicating the [following part of ABP](https://aspnetboilerplate.com/Pages/Documents/Authorization#client-side-javascript-) section *Client Side (JavaScript)*.


<a name="template"/>

#### Template

The currently used template is titled [SB-Admin-BS4-Angular-6](https://startangular.com/product/sb-admin-bootstrap-4-angular-6/).

Note that you're not limited by it in any way - if you have experience with `Angular` you can switch to any other template no matter what it is based on - be it `ng-boostrtap` or `Angular Material` or any other framework.

As you already might have guessed nothing stops you from dropping `Angular` and implement your front-end using `Vue.js`, `React`, etc.

<a name="screenshots"/>

## Screenshots

![image](https://i.imgur.com/lXvTQV1.png)

![image](https://i.imgur.com/6MGtPTl.png)

![image](https://i.imgur.com/vH95EyC.png)

![image](https://i.imgur.com/mrs5iQA.png)