Overview
This backend application is developed using C# and ASP.NET Core to power a blogging platform. It manages users, blog posts, and comments. The application is designed to be scalable, secure, and easy to extend.

Technologies
Programming Language: C#
Framework: ASP.NET Core
Database Management System: Entity Framework Core
Data Transfer Objects (DTOs): Used for transferring data between the frontend and backend efficiently and securely.
Application Structure

1. Models
The application uses several models to represent the core entities of the blog platform. Each model corresponds to a table in the database, and their relationships are defined as follows:

User
Properties:
UserId: int (Primary Key)
Username: string
Email: string
PasswordHash: string
ProfilePictureUrl: string
Bio: string
Relationships:
One User can create multiple Posts.
One User can create multiple Comments.

Post
Properties:
PostId: int (Primary Key)
Title: string
Content: string
DatePublished: DateTime
AuthorId: int (Foreign Key to User)
Relationships:
One Post belongs to one User (Author).
One Post can have multiple Comments.

Comment
Properties:
CommentId: int (Primary Key)
Content: string
DatePublished: DateTime
AuthorId: int (Foreign Key to User)
PostId: int (Foreign Key to Post)
Relationships:
One Comment belongs to one Post.
One Comment belongs to one User (Author).

2. Entity Relationships Overview
User to Post: One-to-Many
User to Comment: One-to-Many
Post to Comment: One-to-Many

Additional Information
DTOs: Data Transfer Objects are used throughout the application to encapsulate data and ensure security by preventing over-posting attacks.
Entity Framework Core: Manages database access and migrations.
