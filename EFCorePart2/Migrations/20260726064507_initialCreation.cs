using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePart2.Migrations
{
    /// <inheritdoc />
    public partial class initialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Hostel",
                columns: table => new
                {
                    HostelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomberOfSeats = table.Column<int>(type: "int", nullable: false),
                    pinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostel", x => x.HostelId);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Course_id);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    ExamCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.ExamCode);
                    table.ForeignKey(
                        name: "FK_Exam_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculity",
                columns: table => new
                {
                    F_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_no = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculity", x => x.F_id);
                    table.ForeignKey(
                        name: "FK_Faculity_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    S_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    L_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone_number = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HostelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.S_id);
                    table.ForeignKey(
                        name: "FK_Student_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Hostel_HostelId",
                        column: x => x.HostelId,
                        principalTable: "Hostel",
                        principalColumn: "HostelId");
                });

            migrationBuilder.CreateTable(
                name: "Enrolls",
                columns: table => new
                {
                    S_id = table.Column<int>(type: "int", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolls", x => new { x.S_id, x.Course_id });
                    table.ForeignKey(
                        name: "FK_Enrolls_Course_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Course",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolls_Student_S_id",
                        column: x => x.S_id,
                        principalTable: "Student",
                        principalColumn: "S_id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Takes",
                columns: table => new
                {
                    S_id = table.Column<int>(type: "int", nullable: false),
                    ExamCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takes", x => new { x.S_id, x.ExamCode });
                    table.ForeignKey(
                        name: "FK_Takes_Exam_ExamCode",
                        column: x => x.ExamCode,
                        principalTable: "Exam",
                        principalColumn: "ExamCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Takes_Student_S_id",
                        column: x => x.S_id,
                        principalTable: "Student",
                        principalColumn: "S_id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TeachesSubject",
                columns: table => new
                {
                    F_id = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    S_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachesSubject", x => new { x.F_id, x.SubjectID, x.S_id });
                    table.ForeignKey(
                        name: "FK_TeachesSubject_Faculity_F_id",
                        column: x => x.F_id,
                        principalTable: "Faculity",
                        principalColumn: "F_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachesSubject_Student_S_id",
                        column: x => x.S_id,
                        principalTable: "Student",
                        principalColumn: "S_id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TeachesSubject_subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_Course_id",
                table: "Enrolls",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_DepartmentId",
                table: "Exam",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculity_DepartmentId",
                table: "Faculity",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                table: "Student",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_HostelId",
                table: "Student",
                column: "HostelId");

            migrationBuilder.CreateIndex(
                name: "IX_Takes_ExamCode",
                table: "Takes",
                column: "ExamCode");

            migrationBuilder.CreateIndex(
                name: "IX_TeachesSubject_S_id",
                table: "TeachesSubject",
                column: "S_id");

            migrationBuilder.CreateIndex(
                name: "IX_TeachesSubject_SubjectID",
                table: "TeachesSubject",
                column: "SubjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrolls");

            migrationBuilder.DropTable(
                name: "Takes");

            migrationBuilder.DropTable(
                name: "TeachesSubject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Faculity");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Hostel");
        }
    }
}
