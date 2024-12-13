
# Public Transport App (PTA)

## Overview
A simple desktop app useful for increase remote access to tickets from everywhere, and also to determine which 
Transport way to choose when someone is abroad.

## Table of 

- [Windows Presentation Foundation](#WPF)
- [Connected Classes](#Connected-Classes)
- [Linq to SQL](#Linq)
- [Running the project](#Project-run)

## WPF
Windows Presentation Foundation (WPF) is a UI Framework designed for clients desktop apps. Its main functionality resides in the 
advantages of modern graphical specific hardware. The programmer could design not only the logic, but the actual interface using 
XAML (Extensible Application Markup Language) language for declaring a declarativ model for application programs.
The code-behind is the logic backend of every WPF application and is generally developed using C# language due to its user friendly 
design, being in the middle of friendly user programming languages from the stack.

## Connected Classes 
Every object class that is reffering to the specific database in use is called a class provider. For SQL Server app, there are several 
providers as:
- DbCommand - a set of .NET components, inherited from SqlCommand class provider, used to create specific SQL commands on the DB, such
as inserts, deletions, updates, or select operations.
- ExecuteNonQuery - the previous declared command can be executed based on different output criteria. For this application, this method
was used because its output reflects the number of rows affected on that DB table.

## Linq 
Linq to objects is a part of Linq technology (Language Interpreted Query) designed for .NET Framework. This is an alternative to
connected classes for manipulating database content via a more logic programming way, using different programming languages, such 
as C# (for Microsoft Sql Server) or Virtual Basic. This method creates a class architecture in memory coming to minimize user work
by reffering the tables as classes and implementing specific methods to manage them.

## Project run
To run the project just take the next steps:
- clone the project repository using: git clone <repo_link>
- modify the connection string from ...
- modify the primary video path from VideoPlayerControl.xaml.cs file in two places
