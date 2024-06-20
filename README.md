# CadenceCollab

## Problem Solved

CadenceCollab is a currently rough draft of a music collaboration platform where users can seemelessly collaborate on songs with other artists. 

Users can collaborate by helping with various musical needs like writing lyrics, editing music files, adding vocals, instrumentation, ect. 

## Technologies Used

- ReactJS
- C#/.NET
- PostgreSQL 16
- HTML5
- CSS3
- Bootstrap
- EFCore
- LINQ

## Database

PostgreSQL using PgAdmin

The Data and Migrations folders in the root directory contain the initial data created for this project.

## Installation and Setup

Clone down this repository. You will need  npm and node installed globally on your machine, as well as PGAdmin to run the database on your machine.

### Installation
>npm install
#### Installation
Navigate to the cloned directory and run the following
```
dotnet user-secrets init
```
```
dotnet user-secrets set 'CPYouDbConnectionString' 'Host=localhost;Port=5432;Username=postgres;Password=<your_postgresql_password>;Database=CPYou'
```
```
dotnet user-secrets set AdminPassword password
```
```
dotnet restore
```
```
dotnet ef migrations add InitialCreate
```
```
dotnet ef database update
```
Then navigate to the client directory and run the following
```
npm install
```
#### Run Database
Run the following command in the project root directory
```
dotnet watch run --launch-profile https
```
#### Run Website
Navigate to the client directory and run the following
```
npm run dev
```

## Future Development
In this rough draft version the core functionality is still under production.
The end goal of this project is to have full functionality allowing people to upload full audio files straight from each users individual DAW, or from simple mp3s, and to have other users capable of dowloading and implementing changes, to then re-upload them for the initial artist to review. 
## WireFrame
[CadenceCollab Project WireFrame](https://miro.com/app/board/uXjVK-_YtS4=/?share_link_id=361459759356)
## ERDiagram
[CadenceCollab ERD](https://dbdiagram.io/d/CadenceCollab-65cf94a4ac844320ae528ce1)
