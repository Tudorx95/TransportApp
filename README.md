# Public Transport App

Public Transport is a desktop application designed in .NET Framework, alongside other Microsoft related technologies, 
such as Linq to SQL and SQL Server, that help the citizens to find the best way to navigate in a city and, also, to
offer possibility of buying new tickets in a predefined account.

## Table of Contents

- [ADO.NET](#ADO.NET)
- [Windows Presentation Foundation](#WPF)
- [Connected Classes](#Connected-classes)
- [Linq To SQL](#Linq-To-SQL)
- [Usage](#Run-program)
- [Contributors](#Contributors)

### ADO.NET
ADO.NET (ActiveX Data Objects) is a Microsoft related technology developed for manipulating DB operations. This is a component part of
.NET Framework. As properties, it has:
- DB Connectivity - using different objects (Connection, Command, DataReader)
- Data manipulation in memory - using another objects (DataSet, DataTable) 
- Linq to SQL

### WPF
Windows Presentation Foundation is a combination of logical programming techniques and a pattern related design for UI. 
The logical part is implemented in C# programming language, and the interface is designed using XAML (Extensible Application Markup Language) language.

### Connected Classes
Connected classes are the principal bridge between the app specific objects and the data provider. The provider for this application
is SQL Server which contribute with a multiple methods for DB manipulation. Some of the specific commands include:
- DbConnection - abstract class from ADO.NET, useful for managing connection with the DB
- DbCommand - abstract class from ADO.NET, useful for DB related operations (queries, insert/delete/update operations, stored procedures)
- DbParameter - abstract class from ADO.NET, useful for transmitting a specific object to command

### Linq To SQL 
Linq to SQL is a technology developed by Microsoft that comes to resolve the abstract bridge between the DB implementation and the program
logic. This technique also implements the principal object operations related to the Database and the connection between them. 

### Run program
The program can run by following the next steps:
- clone the repo to your specific folder
- run the executable from TransportApp\WpfApp\WpfApp\bin\Debug\WpfApp


### Contributors
Project was designed by Lepadatu Tudor and Stanciu George Razvan under the guidance of dr. Lect. Conf. Nita Stefania
