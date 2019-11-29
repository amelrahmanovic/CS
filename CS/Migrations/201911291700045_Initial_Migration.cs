namespace CS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        object_name = c.String(),
                        capacity_provider_id = c.Int(nullable: false),
                        date_from = c.DateTime(nullable: false),
                        date_to = c.DateTime(nullable: false),
                        is_active = c.Boolean(nullable: false),
                        amount = c.Single(nullable: false),
                        currency = c.String(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Capacity_provider", t => t.capacity_provider_id, cascadeDelete: true)
                .Index(t => t.capacity_provider_id);
            
            CreateTable(
                "dbo.Capacity_provider",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        city = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        contract_number = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "capacity_provider_id", "dbo.Capacity_provider");
            DropIndex("dbo.Bookings", new[] { "capacity_provider_id" });
            DropTable("dbo.Capacity_provider");
            DropTable("dbo.Bookings");
        }
    }
}
