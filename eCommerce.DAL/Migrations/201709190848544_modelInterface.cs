namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelInterface : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_OrderId" });
            CreateIndex("dbo.BasketVouchers", "BasketId");
            AddForeignKey("dbo.BasketVouchers", "BasketId", "dbo.Baskets", "BasketId", cascadeDelete: true);
            DropColumn("dbo.OrderItems", "Order_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "Order_OrderId", c => c.Int());
            DropForeignKey("dbo.BasketVouchers", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketVouchers", new[] { "BasketId" });
            CreateIndex("dbo.OrderItems", "Order_OrderId");
            AddForeignKey("dbo.OrderItems", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
