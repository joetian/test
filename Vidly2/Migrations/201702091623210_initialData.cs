namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonth, Discount) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonth, Discount) VALUES (2,30,1,10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonth, Discount) VALUES (3,90,3,15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonth, Discount) VALUES (4,300,3,20)");
            Sql("UPDATE MembershipTypes SET Name='Pay As You Go' WHERE Id=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET Name='Quarterly1' WHERE Id=3");
            Sql("UPDATE MembershipTypes SET Name='Quarterly2' WHERE Id=4");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ('Fiction')");
        }
        
        public override void Down()
        {
        }
    }
}
