using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CFDatabaseAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feedback_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    colorcode = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedback_companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    website = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    phonenumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedback_priorities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    priorityname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    prioritylevel = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    colorcode = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_priorities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedback_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolename = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedback_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    colorcode = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    isdefault = table.Column<byte>(type: "tinyint", nullable: false),
                    isfinalstatus = table.Column<byte>(type: "tinyint", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedback_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    passwordhash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    phonenumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    lastloginat = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedback_departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_departments_feedback_companies_companyid",
                        column: x => x.companyid,
                        principalTable: "feedback_companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "feedback_systemprojects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    version = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_systemprojects", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_systemprojects_feedback_companies_companyid",
                        column: x => x.companyid,
                        principalTable: "feedback_companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "feedback_userprofiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    jobtitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    department = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    bio = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    profileimageurl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_userprofiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_userprofiles_feedback_companies_companyid",
                        column: x => x.companyid,
                        principalTable: "feedback_companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_feedback_userprofiles_feedback_users_userid",
                        column: x => x.userid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback_userroles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    roleid = table.Column<int>(type: "int", nullable: false),
                    assignedat = table.Column<DateTime>(type: "datetime", nullable: false),
                    assignedbyuserid = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_userroles", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_userroles_feedback_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "feedback_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedback_userroles_feedback_users_assignedbyuserid",
                        column: x => x.assignedbyuserid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_userroles_feedback_users_userid",
                        column: x => x.userid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback_feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(max)", nullable: false),
                    submittedbyuserid = table.Column<int>(type: "int", nullable: false),
                    assignedtouserid = table.Column<int>(type: "int", nullable: true),
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    priorityid = table.Column<int>(type: "int", nullable: false),
                    statusid = table.Column<int>(type: "int", nullable: false),
                    systemprojectid = table.Column<int>(type: "int", nullable: true),
                    affectedversion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    submittedat = table.Column<DateTime>(type: "datetime", nullable: false),
                    resolvedat = table.Column<DateTime>(type: "datetime", nullable: true),
                    resolutionnotes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_feedbacks_feedback_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "feedback_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_feedbacks_feedback_priorities_priorityid",
                        column: x => x.priorityid,
                        principalTable: "feedback_priorities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_feedbacks_feedback_statuses_statusid",
                        column: x => x.statusid,
                        principalTable: "feedback_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_feedbacks_feedback_systemprojects_systemprojectid",
                        column: x => x.systemprojectid,
                        principalTable: "feedback_systemprojects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_feedback_feedbacks_feedback_users_assignedtouserid",
                        column: x => x.assignedtouserid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_feedback_feedbacks_feedback_users_submittedbyuserid",
                        column: x => x.submittedbyuserid,
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
                    userprofileid = table.Column<int>(type: "int", nullable: false),
                    streetaddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    stateprovince = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    postalcode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_useraddresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_useraddresses_feedback_userprofiles_userprofileid",
                        column: x => x.userprofileid,
                        principalTable: "feedback_userprofiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback_useremployments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userprofileid = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    departmentid = table.Column<int>(type: "int", nullable: true),
                    startdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    enddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_useremployments", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_useremployments_feedback_departments_departmentid",
                        column: x => x.departmentid,
                        principalTable: "feedback_departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_feedback_useremployments_feedback_userprofiles_userprofileid",
                        column: x => x.userprofileid,
                        principalTable: "feedback_userprofiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback_attachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feedbackid = table.Column<int>(type: "int", nullable: false),
                    filename = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    filepath = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    mimetype = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    filesize = table.Column<long>(type: "bigint", nullable: false),
                    uploadedbyuserid = table.Column<int>(type: "int", nullable: false),
                    uploadedat = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_attachments", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_attachments_feedback_feedbacks_feedbackid",
                        column: x => x.feedbackid,
                        principalTable: "feedback_feedbacks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedback_attachments_feedback_users_uploadedbyuserid",
                        column: x => x.uploadedbyuserid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedback_internalnotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feedbackid = table.Column<int>(type: "int", nullable: false),
                    createdbyuser = table.Column<int>(type: "int", nullable: false),
                    notecontent = table.Column<string>(type: "varchar(max)", nullable: false),
                    isvisible = table.Column<byte>(type: "tinyint", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_internalnotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_internalnotes_feedback_feedbacks_feedbackid",
                        column: x => x.feedbackid,
                        principalTable: "feedback_feedbacks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedback_internalnotes_feedback_users_createdbyuser",
                        column: x => x.createdbyuser,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedback_statushistories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feedbackid = table.Column<int>(type: "int", nullable: false),
                    oldstatusid = table.Column<int>(type: "int", nullable: true),
                    newstatusid = table.Column<int>(type: "int", nullable: false),
                    changedbyuserid = table.Column<int>(type: "int", nullable: false),
                    changereason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    notes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    changedat = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    isdelete = table.Column<byte>(type: "tinyint", nullable: false),
                    createdbyuserid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    modifiedbyuserid = table.Column<int>(type: "int", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback_statushistories", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_statushistories_feedback_feedbacks_feedbackid",
                        column: x => x.feedbackid,
                        principalTable: "feedback_feedbacks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedback_statushistories_feedback_statuses_newstatusid",
                        column: x => x.newstatusid,
                        principalTable: "feedback_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_statushistories_feedback_statuses_oldstatusid",
                        column: x => x.oldstatusid,
                        principalTable: "feedback_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_statushistories_feedback_users_changedbyuserid",
                        column: x => x.changedbyuserid,
                        principalTable: "feedback_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });


            migrationBuilder.InsertData(
                table: "feedback_users",
                columns: new[] { "firstname", "lastname", "email", "passwordhash", "status", "isdelete", "createdbyuserid","modifiedbyuserid" },
                values: new object[,]
                {
                    { "System", "Admin", "admin@email.com", BCrypt.Net.BCrypt.HashPassword("Admin123"), (byte)1, (byte)0, 1, 1 },
                    { "Normal", "User", "user@email.com", BCrypt.Net.BCrypt.HashPassword("User123"), (byte)1, (byte)0, 1, 1 },
                    { "Customer", "Support", "support@email.com",  BCrypt.Net.BCrypt.HashPassword("Support123"), (byte)1, (byte)0, 1, 1 },

                });

            migrationBuilder.InsertData(
                table: "feedback_categories",
                columns: new[] { "categoryname", "colorcode", "createdbyuserid",  "description", "isdelete", "modifiedbyuserid", "status" },
                values: new object[,]
                {
                    { "Bug Report", "#DC2626", 1,  "Software bugs and issues", (byte)0, 1,  (byte)1 },
                    { "Feature Request", "#059669", 1,  "New feature suggestions", (byte)0, 1,  (byte)1 },
                    { "Performance", "#D97706", 1,  "Performance related issues", (byte)0, 1,  (byte)1 },
                    { "User Interface", "#7C3AED", 1,  "UI/UX related feedback", (byte)0, 1,  (byte)1 },
                    { "Documentation", "#0891B2", 1,  "Documentation improvements", (byte)0, 1,  (byte)1 },
                    { "General", "#6B7280", 1,  "General feedback and suggestions", (byte)0, 1,  (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "feedback_priorities",
                columns: new[] { "colorcode", "createdbyuserid", "description", "isdelete", "modifiedbyuserid", "prioritylevel", "priorityname", "status" },
                values: new object[,]
                {
                    { "#DC2626", 1,  "Critical issue requiring immediate attention", (byte)0, 1,  1, "Critical", (byte)1 },
                    { "#EA580C", 1,  "High priority issue", (byte)0, 1,  2, "High", (byte)1 },
                    { "#D97706", 1,  "Medium priority issue", (byte)0, 1,  3, "Medium", (byte)1 },
                    { "#65A30D", 1,  "Low priority issue", (byte)0, 1,  4, "Low", (byte)1 },
                    { "#0891B2", 1,  "Feature enhancement request", (byte)0, 1,  5, "Enhancement", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "feedback_roles",
                columns: new[] { "createdbyuserid", "description", "isdelete", "modifiedbyuserid", "rolename", "status" },
                values: new object[,]
                {
                    { 1,  "System Administrator with full access", (byte)0, 1,  "Admin", (byte)1 },
                    { 1,  "Support staff who handle feedback", (byte)0, 1,  "Support", (byte)1 },
                    { 1,  "Customer who can submit feedback", (byte)0, 1,  "Customer", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "feedback_statuses",
                columns: new[] { "colorcode", "createdbyuserid", "description", "isdefault", "isdelete", "isfinalstatus", "modifiedbyuserid", "status", "statusname" },
                values: new object[,]
                {
                    { "#3B82F6", 1,  "New feedback submitted", (byte)1, (byte)0, (byte)0, 1,  (byte)1, "Open" },
                    { "#F59E0B", 1,  "Feedback is being worked on", (byte)0, (byte)0, (byte)0, 1,  (byte)1, "In Progress" },
                    { "#8B5CF6", 1,  "Waiting for review", (byte)0, (byte)0, (byte)0, 1,  (byte)1, "Pending Review" },
                    { "#10B981", 1,  "Feedback has been resolved", (byte)0, (byte)0, (byte)1, 1,  (byte)1, "Resolved" },
                    { "#6B7280", 1,  "Feedback is closed", (byte)0, (byte)0, (byte)1, 1,  (byte)1, "Closed" },
                    { "#EF4444", 1,  "Feedback was rejected", (byte)0, (byte)0, (byte)1, 1,  (byte)1, "Rejected" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_attachments_feedbackid",
                table: "feedback_attachments",
                column: "feedbackid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_attachments_uploadedbyuserid",
                table: "feedback_attachments",
                column: "uploadedbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_categories_status_isdelete",
                table: "feedback_categories",
                columns: new[] { "status", "isdelete" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_companies_status_isdelete",
                table: "feedback_companies",
                columns: new[] { "status", "isdelete" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_departments_companyid",
                table: "feedback_departments",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_departments_status_isdelete",
                table: "feedback_departments",
                columns: new[] { "status", "isdelete" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_assignedtouserid_statusid",
                table: "feedback_feedbacks",
                columns: new[] { "assignedtouserid", "statusid" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_categoryid_priorityid",
                table: "feedback_feedbacks",
                columns: new[] { "categoryid", "priorityid" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_priorityid",
                table: "feedback_feedbacks",
                column: "priorityid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_status_isdelete",
                table: "feedback_feedbacks",
                columns: new[] { "status", "isdelete" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_statusid_submittedat",
                table: "feedback_feedbacks",
                columns: new[] { "statusid", "submittedat" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_submittedbyuserid_submittedat",
                table: "feedback_feedbacks",
                columns: new[] { "submittedbyuserid", "submittedat" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_feedbacks_systemprojectid",
                table: "feedback_feedbacks",
                column: "systemprojectid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_internalnotes_createdbyuser",
                table: "feedback_internalnotes",
                column: "createdbyuser");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_internalnotes_feedbackid",
                table: "feedback_internalnotes",
                column: "feedbackid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_priorities_status_isdelete",
                table: "feedback_priorities",
                columns: new[] { "status", "isdelete" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_roles_rolename",
                table: "feedback_roles",
                column: "rolename",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feedback_statuses_status_isdelete",
                table: "feedback_statuses",
                columns: new[] { "status", "isdelete" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_statushistories_changedbyuserid",
                table: "feedback_statushistories",
                column: "changedbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_statushistories_feedbackid_changedat",
                table: "feedback_statushistories",
                columns: new[] { "feedbackid", "changedat" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_statushistories_newstatusid",
                table: "feedback_statushistories",
                column: "newstatusid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_statushistories_oldstatusid",
                table: "feedback_statushistories",
                column: "oldstatusid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_systemprojects_companyid",
                table: "feedback_systemprojects",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_systemprojects_status_isdelete",
                table: "feedback_systemprojects",
                columns: new[] { "status", "isdelete" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_useraddresses_userprofileid",
                table: "feedback_useraddresses",
                column: "userprofileid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feedback_useremployments_departmentid",
                table: "feedback_useremployments",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_useremployments_userprofileid",
                table: "feedback_useremployments",
                column: "userprofileid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userprofiles_companyid",
                table: "feedback_userprofiles",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userprofiles_status_isdelete",
                table: "feedback_userprofiles",
                columns: new[] { "status", "isdelete" });

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userprofiles_userid",
                table: "feedback_userprofiles",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userroles_assignedbyuserid",
                table: "feedback_userroles",
                column: "assignedbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userroles_roleid",
                table: "feedback_userroles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userroles_userid_roleid",
                table: "feedback_userroles",
                columns: new[] { "userid", "roleid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feedback_users_email",
                table: "feedback_users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feedback_users_status_isdelete_createddate",
                table: "feedback_users",
                columns: new[] { "status", "isdelete", "createddate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedback_attachments");

            migrationBuilder.DropTable(
                name: "feedback_internalnotes");

            migrationBuilder.DropTable(
                name: "feedback_statushistories");

            migrationBuilder.DropTable(
                name: "feedback_useraddresses");

            migrationBuilder.DropTable(
                name: "feedback_useremployments");

            migrationBuilder.DropTable(
                name: "feedback_userroles");

            migrationBuilder.DropTable(
                name: "feedback_feedbacks");

            migrationBuilder.DropTable(
                name: "feedback_departments");

            migrationBuilder.DropTable(
                name: "feedback_userprofiles");

            migrationBuilder.DropTable(
                name: "feedback_roles");

            migrationBuilder.DropTable(
                name: "feedback_categories");

            migrationBuilder.DropTable(
                name: "feedback_priorities");

            migrationBuilder.DropTable(
                name: "feedback_statuses");

            migrationBuilder.DropTable(
                name: "feedback_systemprojects");

            migrationBuilder.DropTable(
                name: "feedback_users");

            migrationBuilder.DropTable(
                name: "feedback_companies");
        }
    }
}
