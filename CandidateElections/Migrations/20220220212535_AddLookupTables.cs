using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CandidateElections.Migrations
{
    public partial class AddLookupTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campaigns",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdcampana = table.Column<string>(type: "text", nullable: true),
                    dscampana = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_campaigns", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    cddocumento = table.Column<string>(type: "text", nullable: false),
                    cdtipo_documento = table.Column<string>(type: "text", nullable: true),
                    feexpedicion_documento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cdciudad_expedicion_docto = table.Column<string>(type: "text", nullable: true),
                    cdciudad_expedicion_docto1 = table.Column<string>(type: "text", nullable: true),
                    dsnombre_completo = table.Column<string>(type: "text", nullable: true),
                    dsnombre1 = table.Column<string>(type: "text", nullable: true),
                    dsnombre2 = table.Column<string>(type: "text", nullable: true),
                    dsapellido1 = table.Column<string>(type: "text", nullable: true),
                    dsapellido2 = table.Column<string>(type: "text", nullable: true),
                    dstelefono = table.Column<string>(type: "text", nullable: true),
                    dscelular = table.Column<string>(type: "text", nullable: true),
                    dsdireccion = table.Column<string>(type: "text", nullable: true),
                    dsemail = table.Column<string>(type: "text", nullable: true),
                    fenacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sntratamiento_datos = table.Column<string>(type: "text", nullable: true),
                    sncomunicados_email = table.Column<string>(type: "text", nullable: true),
                    sncomunicados_textos = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persons", x => x.cddocumento);
                });

            migrationBuilder.CreateTable(
                name: "tables",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdmesa = table.Column<string>(type: "text", nullable: true),
                    cdciudad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdcandidato = table.Column<string>(type: "text", nullable: true),
                    cddcumento_id = table.Column<string>(type: "text", nullable: true),
                    ptpresupuesto = table.Column<double>(type: "double precision", nullable: false),
                    dspath_foto = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidates", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidates_persons_cddcumento_id",
                        column: x => x.cddcumento_id,
                        principalTable: "persons",
                        principalColumn: "cddocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "voters",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cddocumento_id = table.Column<string>(type: "text", nullable: true),
                    cdcampana_id = table.Column<long>(type: "bigint", nullable: true),
                    cdmesa_asignada_id = table.Column<long>(type: "bigint", nullable: true),
                    snvoto = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_voters", x => x.id);
                    table.ForeignKey(
                        name: "fk_voters_campaigns_cdcampana_id",
                        column: x => x.cdcampana_id,
                        principalTable: "campaigns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_voters_persons_cddocumento_id",
                        column: x => x.cddocumento_id,
                        principalTable: "persons",
                        principalColumn: "cddocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_voters_tables_cdmesa_asignada_id",
                        column: x => x.cdmesa_asignada_id,
                        principalTable: "tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "candidates_votes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdcampana_id = table.Column<long>(type: "bigint", nullable: true),
                    cdcandidato_id = table.Column<long>(type: "bigint", nullable: true),
                    cddocumento_votante_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidates_votes", x => x.id);
                    table.ForeignKey(
                        name: "fk_candidates_votes_campaigns_cdcampana_id",
                        column: x => x.cdcampana_id,
                        principalTable: "campaigns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_candidates_votes_candidates_cdcandidato_id",
                        column: x => x.cdcandidato_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_candidates_votes_persons_cddocumento_votante_id",
                        column: x => x.cddocumento_votante_id,
                        principalTable: "persons",
                        principalColumn: "cddocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "elects",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdcandidato_id = table.Column<long>(type: "bigint", nullable: true),
                    cdcampana_id = table.Column<long>(type: "bigint", nullable: true),
                    cddocumento_id = table.Column<string>(type: "text", nullable: true),
                    feperiodo_inicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    feperiodo_fin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    nmvotos = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elects", x => x.id);
                    table.ForeignKey(
                        name: "fk_elects_campaigns_cdcampana_id",
                        column: x => x.cdcampana_id,
                        principalTable: "campaigns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_elects_candidates_cdcandidato_id",
                        column: x => x.cdcandidato_id,
                        principalTable: "candidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_elects_persons_cddocumento_id",
                        column: x => x.cddocumento_id,
                        principalTable: "persons",
                        principalColumn: "cddocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_candidates_cddcumento_id",
                table: "candidates",
                column: "cddcumento_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidates_votes_cdcampana_id",
                table: "candidates_votes",
                column: "cdcampana_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidates_votes_cdcandidato_id",
                table: "candidates_votes",
                column: "cdcandidato_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidates_votes_cddocumento_votante_id",
                table: "candidates_votes",
                column: "cddocumento_votante_id");

            migrationBuilder.CreateIndex(
                name: "ix_elects_cdcampana_id",
                table: "elects",
                column: "cdcampana_id");

            migrationBuilder.CreateIndex(
                name: "ix_elects_cdcandidato_id",
                table: "elects",
                column: "cdcandidato_id");

            migrationBuilder.CreateIndex(
                name: "ix_elects_cddocumento_id",
                table: "elects",
                column: "cddocumento_id");

            migrationBuilder.CreateIndex(
                name: "ix_voters_cdcampana_id",
                table: "voters",
                column: "cdcampana_id");

            migrationBuilder.CreateIndex(
                name: "ix_voters_cddocumento_id",
                table: "voters",
                column: "cddocumento_id");

            migrationBuilder.CreateIndex(
                name: "ix_voters_cdmesa_asignada_id",
                table: "voters",
                column: "cdmesa_asignada_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidates_votes");

            migrationBuilder.DropTable(
                name: "elects");

            migrationBuilder.DropTable(
                name: "voters");

            migrationBuilder.DropTable(
                name: "candidates");

            migrationBuilder.DropTable(
                name: "campaigns");

            migrationBuilder.DropTable(
                name: "tables");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
