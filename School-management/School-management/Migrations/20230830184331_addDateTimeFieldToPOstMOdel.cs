﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_management.Migrations
{
    /// <inheritdoc />
    public partial class addDateTimeFieldToPOstMOdel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePost",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePost",
                table: "Posts");
        }
    }
}
