using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CFDatabaseAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feedback_companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "varchar(200)", nullable: false),
                    companycode = table.Column<string>(type: "varchar(50)", nullable: false),
                    industry = table.Column<string>(type: "varchar(100)", nullable: false),
                    companysize = table.Column<string>(type: "varchar(50)", nullable: false),
                    website = table.Column<string>(type: "varchar(255)", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedback_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: "GETDATE()"),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedback_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "varchar(20)", nullable: false),
                    roleid = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_users_feedback_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "feedback_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedback_departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    departmentname = table.Column<string>(type: "varchar(100)", nullable: false),
                    departmentcode = table.Column<string>(type: "varchar(20)", nullable: false),
                    manageruserid = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_departments_feedback_companies_companyid",
                        column: x => x.companyid,
                        principalTable: "feedback_companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_departments_feedback_users_manageruserid",
                        column: x => x.manageruserid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedback_feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    subject = table.Column<string>(type: "varchar(200)", nullable: false),
                    description = table.Column<string>(type: "varchar(2000)", nullable: false),
                    priority = table.Column<string>(type: "varchar(20)", nullable: false),
                    feedbackstatus = table.Column<string>(type: "varchar(20)", nullable: false),
                    category = table.Column<string>(type: "varchar(100)", nullable: false),
                    assignedtouserid = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_feedbacks_feedback_users_assignedtouserid",
                        column: x => x.assignedtouserid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_feedbacks_feedback_users_customerid",
                        column: x => x.customerid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedback_useraddresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    addresstype = table.Column<string>(type: "varchar(20)", nullable: false),
                    address = table.Column<string>(type: "varchar(500)", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", nullable: false),
                    state = table.Column<string>(type: "varchar(100)", nullable: false),
                    postalcode = table.Column<string>(type: "varchar(20)", nullable: false),
                    country = table.Column<string>(type: "varchar(100)", nullable: false),
                    isprimary = table.Column<byte>(type: "tinyint", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_useraddresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_useraddresses_feedback_users_userid",
                        column: x => x.userid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback_userprofiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    firstname = table.Column<string>(type: "varchar(100)", nullable: false),
                    lastname = table.Column<string>(type: "varchar(100)", nullable: false),
                    phonenumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    profileimageurl = table.Column<string>(type: "varchar(200)", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_userprofiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_userprofiles_feedback_users_userid",
                        column: x => x.userid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback_useremployments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    departmentid = table.Column<int>(type: "int", nullable: true),
                    jobtitle = table.Column<string>(type: "varchar(100)", nullable: false),
                    employeeid = table.Column<string>(type: "varchar(50)", nullable: false),
                    startdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_useremployments", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_useremployments_feedback_companies_companyid",
                        column: x => x.companyid,
                        principalTable: "feedback_companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_useremployments_feedback_departments_departmentid",
                        column: x => x.departmentid,
                        principalTable: "feedback_departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_useremployments_feedback_users_userid",
                        column: x => x.userid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback_feedbackcomments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feedbackid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "varchar(1000)", nullable: false),
                    isinternal = table.Column<byte>(type: "tinyint", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 0),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    modefiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modefieddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_feedbackcomments", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_feedbackcomments_feedback_feedbacks_feedbackid",
                        column: x => x.feedbackid,
                        principalTable: "feedback_feedbacks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedback_feedbackcomments_feedback_users_userid",
                        column: x => x.userid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "feedback_roles",
                columns: new[] { "id", "createdbyuserid", "description", "modefiedbyuserid", "name", "status" },
                values: new object[,]
                {
                    { 1, 1, "End-users who can submit feedback", 1, "Customer", 1 },
                    { 2, 1, "Team members who handle feedback", 1, "Support", 1 },
                    { 3, 1, "System administrators", 1,"Admin", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_departments_companyid",
                table: "feedback_departments",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_departments_manageruserid",
                table: "feedback_departments",
                column: "manageruserid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbackcomments_feedbackid",
                table: "feedback_feedbackcomments",
                column: "feedbackid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbackcomments_userid",
                table: "feedback_feedbackcomments",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_assignedtouserid",
                table: "feedback_feedbacks",
                column: "assignedtouserid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_customerid",
                table: "feedback_feedbacks",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_useraddresses_userid",
                table: "feedback_useraddresses",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_useremployments_companyid",
                table: "feedback_useremployments",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_useremployments_departmentid",
                table: "feedback_useremployments",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_useremployments_userid",
                table: "feedback_useremployments",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userprofiles_userid",
                table: "feedback_userprofiles",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feedback_users_roleid",
                table: "feedback_users",
                column: "roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedback_feedbackcomments");

            migrationBuilder.DropTable(
                name: "feedback_useraddresses");

            migrationBuilder.DropTable(
                name: "feedback_useremployments");

            migrationBuilder.DropTable(
                name: "feedback_userprofiles");

            migrationBuilder.DropTable(
                name: "feedback_feedbacks");

            migrationBuilder.DropTable(
                name: "feedback_departments");

            migrationBuilder.DropTable(
                name: "feedback_companies");

            migrationBuilder.DropTable(
                name: "feedback_users");

            migrationBuilder.DropTable(
                name: "feedback_roles");
        }
    }
}
