namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieDetails : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, AddDate, Stock) VALUES ('Hangover',1,'20120602','20120606',4)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, AddDate, Stock) VALUES ('Die Hard',2,'20120602','20130606',2)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, AddDate, Stock) VALUES ('The Terminator',2,'20120602','20100606',1)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, AddDate, Stock) VALUES ('Toy Story',3,'20120602','20030906',0)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, AddDate, Stock) VALUES ('Titanic',4,'20120602','20120811',22)");
        }
        
        public override void Down()
        {
        }
    }
}
