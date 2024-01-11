using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API_for_scheduling.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudienceType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudienceType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    IsEven = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureHours = table.Column<int>(type: "int", nullable: true),
                    PracticHours = table.Column<int>(type: "int", nullable: true),
                    TotalHours = table.Column<int>(type: "int", nullable: true),
                    ConsultationHours = table.Column<int>(type: "int", nullable: true),
                    TypeOfCertification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Audience",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AudienceTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SeatsNumber = table.Column<int>(type: "int", nullable: true),
                    StudentNumber = table.Column<int>(type: "int", nullable: true),
                    AudienceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audience", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Audience_AudienceType_AudienceTypeID",
                        column: x => x.AudienceTypeID,
                        principalTable: "AudienceType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Week",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WeekNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Week", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Week_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Pair",
                columns: table => new
                {
                    PairID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AudienceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pair", x => x.PairID);
                    table.ForeignKey(
                        name: "FK_Pair_Audience_AudienceID",
                        column: x => x.AudienceID,
                        principalTable: "Audience",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Pair_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Pair_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Pair_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeekID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstPairID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SecondPairID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThirdPairID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FourthPairID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FifthPairID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SixthPairID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SeventhPairID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Day_Pair_FifthPairID",
                        column: x => x.FifthPairID,
                        principalTable: "Pair",
                        principalColumn: "PairID");
                    table.ForeignKey(
                        name: "FK_Day_Pair_FirstPairID",
                        column: x => x.FirstPairID,
                        principalTable: "Pair",
                        principalColumn: "PairID");
                    table.ForeignKey(
                        name: "FK_Day_Pair_FourthPairID",
                        column: x => x.FourthPairID,
                        principalTable: "Pair",
                        principalColumn: "PairID");
                    table.ForeignKey(
                        name: "FK_Day_Pair_SecondPairID",
                        column: x => x.SecondPairID,
                        principalTable: "Pair",
                        principalColumn: "PairID");
                    table.ForeignKey(
                        name: "FK_Day_Pair_SeventhPairID",
                        column: x => x.SeventhPairID,
                        principalTable: "Pair",
                        principalColumn: "PairID");
                    table.ForeignKey(
                        name: "FK_Day_Pair_SixthPairID",
                        column: x => x.SixthPairID,
                        principalTable: "Pair",
                        principalColumn: "PairID");
                    table.ForeignKey(
                        name: "FK_Day_Pair_ThirdPairID",
                        column: x => x.ThirdPairID,
                        principalTable: "Pair",
                        principalColumn: "PairID");
                    table.ForeignKey(
                        name: "FK_Day_Week_WeekID",
                        column: x => x.WeekID,
                        principalTable: "Week",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audience_AudienceTypeID",
                table: "Audience",
                column: "AudienceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Day_FifthPairID",
                table: "Day",
                column: "FifthPairID");

            migrationBuilder.CreateIndex(
                name: "IX_Day_FirstPairID",
                table: "Day",
                column: "FirstPairID");

            migrationBuilder.CreateIndex(
                name: "IX_Day_FourthPairID",
                table: "Day",
                column: "FourthPairID");

            migrationBuilder.CreateIndex(
                name: "IX_Day_SecondPairID",
                table: "Day",
                column: "SecondPairID");

            migrationBuilder.CreateIndex(
                name: "IX_Day_SeventhPairID",
                table: "Day",
                column: "SeventhPairID");

            migrationBuilder.CreateIndex(
                name: "IX_Day_SixthPairID",
                table: "Day",
                column: "SixthPairID");

            migrationBuilder.CreateIndex(
                name: "IX_Day_ThirdPairID",
                table: "Day",
                column: "ThirdPairID");

            migrationBuilder.CreateIndex(
                name: "IX_Day_WeekID",
                table: "Day",
                column: "WeekID");

            migrationBuilder.CreateIndex(
                name: "IX_Pair_AudienceID",
                table: "Pair",
                column: "AudienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Pair_GroupID",
                table: "Pair",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Pair_SubjectID",
                table: "Pair",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Pair_TeacherID",
                table: "Pair",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Week_SemesterID",
                table: "Week",
                column: "SemesterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Pair");

            migrationBuilder.DropTable(
                name: "Week");

            migrationBuilder.DropTable(
                name: "Audience");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "AudienceType");
        }
    }
}
