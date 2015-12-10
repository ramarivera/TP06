namespace EJ02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion03 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Personas", newName: "Persona");
            RenameTable(name: "dbo.Telefonoes", newName: "Telefono");
            MoveTable(name: "dbo.Persona", newSchema: "TDP");
            MoveTable(name: "dbo.Telefono", newSchema: "TDP");
            DropForeignKey("dbo.Telefonoes", "Persona_PersonaId", "dbo.Personas");
            DropIndex("TDP.Telefono", new[] { "Persona_PersonaId" });
            RenameColumn(table: "TDP.Telefono", name: "Persona_PersonaId", newName: "Persona");
            AlterColumn("TDP.Telefono", "Persona", c => c.Int(nullable: false));
            CreateIndex("TDP.Telefono", "Persona");
            AddForeignKey("TDP.Telefono", "Persona", "TDP.Persona", "PersonaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("TDP.Telefono", "Persona", "TDP.Persona");
            DropIndex("TDP.Telefono", new[] { "Persona" });
            AlterColumn("TDP.Telefono", "Persona", c => c.Int());
            RenameColumn(table: "TDP.Telefono", name: "Persona", newName: "Persona_PersonaId");
            CreateIndex("TDP.Telefono", "Persona_PersonaId");
            AddForeignKey("dbo.Telefonoes", "Persona_PersonaId", "dbo.Personas", "PersonaId");
            MoveTable(name: "TDP.Telefono", newSchema: "dbo");
            MoveTable(name: "TDP.Persona", newSchema: "dbo");
            RenameTable(name: "dbo.Telefono", newName: "Telefonoes");
            RenameTable(name: "dbo.Persona", newName: "Personas");
        }
    }
}
