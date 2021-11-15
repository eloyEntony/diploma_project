using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValues_ProductAttributes_AttributeId",
                table: "ProductAttributeValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeValues",
                table: "ProductAttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributeValues_AttributeId",
                table: "ProductAttributeValues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductAttributeValues");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductAttributeValues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductAttributeValues");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductAttributeValues");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductAttributeValues");

            migrationBuilder.AlterColumn<long>(
                name: "AttributeId",
                table: "ProductAttributeValues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeValues",
                table: "ProductAttributeValues",
                columns: new[] { "AttributeId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValues_ProductAttributes_AttributeId",
                table: "ProductAttributeValues",
                column: "AttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValues_ProductAttributes_AttributeId",
                table: "ProductAttributeValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeValues",
                table: "ProductAttributeValues");

            migrationBuilder.AlterColumn<long>(
                name: "AttributeId",
                table: "ProductAttributeValues",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProductAttributeValues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductAttributeValues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductAttributeValues",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductAttributeValues",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProductAttributeValues",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeValues",
                table: "ProductAttributeValues",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeValues_AttributeId",
                table: "ProductAttributeValues",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValues_ProductAttributes_AttributeId",
                table: "ProductAttributeValues",
                column: "AttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
