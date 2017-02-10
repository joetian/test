namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Customers] ON");
            Sql("INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscriberToNewsLetter], [MembershipTypeId], [Birthday]) VALUES (1, N'Joseph Tian', 0, 1, NULL)");
            Sql("INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscriberToNewsLetter], [MembershipTypeId], [Birthday]) VALUES (2, N'Mark Ducun', 1, 2, N'1999-09-09 00:00:00')");
            Sql("INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscriberToNewsLetter], [MembershipTypeId], [Birthday]) VALUES (3, N'Alice Funcy', 1, 3, N'1988-08-08 00:00:00')");
            Sql("SET IDENTITY_INSERT [dbo].[Customers] OFF");

            Sql("SET IDENTITY_INSERT [dbo].[Movies] ON");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [Name]) VALUES (3, N'2015-01-01 00:00:00', N'2017-02-07 00:00:00', 6, 1, N'Hangover')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [Name]) VALUES (4, N'2015-02-02 00:00:00', N'2017-02-07 00:00:00', 5, 2, N'Die Hard')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [Name]) VALUES (5, N'2016-03-03 00:00:00', N'2017-02-07 00:00:00', 4, 3, N'The Terminator')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [Name]) VALUES (6, N'2016-04-04 00:00:00', N'2017-02-07 00:00:00', 12, 4, N'Toy Story')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [Name]) VALUES (7, N'2015-05-05 00:00:00', N'2017-02-07 00:00:00', 22, 5, N'Titanic')");
            Sql("SET IDENTITY_INSERT [dbo].[Movies] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
