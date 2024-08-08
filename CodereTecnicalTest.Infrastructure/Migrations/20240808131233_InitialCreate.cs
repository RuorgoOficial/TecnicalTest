using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodereTecnicalTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timezone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Externals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvrage = table.Column<int>(type: "int", nullable: true),
                    thetvdb = table.Column<int>(type: "int", nullable: true),
                    imdb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Externals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    original = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Previousepisodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previousepisodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    average = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    days = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Selves",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    href = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selves", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: true),
                    officialSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Networks_Countries_countryid",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    selfid = table.Column<int>(type: "int", nullable: false),
                    previousepisodeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.id);
                    table.ForeignKey(
                        name: "FK_Links_Previousepisodes_previousepisodeid",
                        column: x => x.previousepisodeid,
                        principalTable: "Previousepisodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Selves_selfid",
                        column: x => x.selfid,
                        principalTable: "Selves",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    runtime = table.Column<int>(type: "int", nullable: true),
                    averageRuntime = table.Column<int>(type: "int", nullable: true),
                    premiered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ended = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    officialSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scheduleid = table.Column<int>(type: "int", nullable: false),
                    ratingid = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    networkid = table.Column<int>(type: "int", nullable: true),
                    webChannelid = table.Column<int>(type: "int", nullable: true),
                    dvdCountryid = table.Column<int>(type: "int", nullable: true),
                    externalsid = table.Column<int>(type: "int", nullable: false),
                    imageid = table.Column<int>(type: "int", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated = table.Column<int>(type: "int", nullable: false),
                    _linksid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shows_Countries_dvdCountryid",
                        column: x => x.dvdCountryid,
                        principalTable: "Countries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Shows_Externals_externalsid",
                        column: x => x.externalsid,
                        principalTable: "Externals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Images_imageid",
                        column: x => x.imageid,
                        principalTable: "Images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Shows_Links__linksid",
                        column: x => x._linksid,
                        principalTable: "Links",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Networks_networkid",
                        column: x => x.networkid,
                        principalTable: "Networks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Shows_Networks_webChannelid",
                        column: x => x.webChannelid,
                        principalTable: "Networks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Shows_Ratings_ratingid",
                        column: x => x.ratingid,
                        principalTable: "Ratings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Schedules_scheduleid",
                        column: x => x.scheduleid,
                        principalTable: "Schedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreShow",
                columns: table => new
                {
                    genresid = table.Column<int>(type: "int", nullable: false),
                    showsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreShow", x => new { x.genresid, x.showsid });
                    table.ForeignKey(
                        name: "FK_GenreShow_Genres_genresid",
                        column: x => x.genresid,
                        principalTable: "Genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreShow_Shows_showsid",
                        column: x => x.showsid,
                        principalTable: "Shows",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreShow_showsid",
                table: "GenreShow",
                column: "showsid");

            migrationBuilder.CreateIndex(
                name: "IX_Links_previousepisodeid",
                table: "Links",
                column: "previousepisodeid");

            migrationBuilder.CreateIndex(
                name: "IX_Links_selfid",
                table: "Links",
                column: "selfid");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_countryid",
                table: "Networks",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_Shows__linksid",
                table: "Shows",
                column: "_linksid");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_dvdCountryid",
                table: "Shows",
                column: "dvdCountryid");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_externalsid",
                table: "Shows",
                column: "externalsid");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_imageid",
                table: "Shows",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_networkid",
                table: "Shows",
                column: "networkid");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ratingid",
                table: "Shows",
                column: "ratingid");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_scheduleid",
                table: "Shows",
                column: "scheduleid");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_webChannelid",
                table: "Shows",
                column: "webChannelid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreShow");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Externals");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Networks");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Previousepisodes");

            migrationBuilder.DropTable(
                name: "Selves");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
