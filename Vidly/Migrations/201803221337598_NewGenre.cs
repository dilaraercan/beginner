namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewGenre : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genres SET GenreName ='Comedy' WHERE Id = 1");
            Sql("UPDATE Genres SET GenreName ='Action' WHERE Id = 2");
            Sql("UPDATE Genres SET GenreName ='Family' WHERE Id = 3");
            Sql("UPDATE Genres SET GenreName ='Romance' WHERE Id = 4");
            Sql("UPDATE Genres SET GenreName ='Thrill' WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
