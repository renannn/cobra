using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Cobra.Infrastructure.Migrations
{
    public partial class Startup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AppDataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XmlData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSqlCache",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ExpiresAtTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SlidingExpirationInSeconds = table.Column<long>(type: "bigint", nullable: true),
                    AbsoluteExpiration = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSqlCache", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_company_settings",
                schema: "dbo",
                columns: table => new
                {
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ramal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneObservation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneTypeId = table.Column<short>(type: "smallint", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPFResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimentoResponsavel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelefoneResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamalResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneObservationResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneTypeIdResponsavel = table.Column<short>(type: "smallint", nullable: false),
                    ImageLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_addresses_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_addresses_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_banks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_brands",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temporary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temporary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_conditions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_countries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<short>(type: "smallint", nullable: false),
                    InternationalPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_emails_types",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_emails_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_payment_method_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_payment_method_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_phone_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_phone_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_regional_state",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_regional_state", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_general_settings",
                schema: "dbo",
                columns: table => new
                {
                    TermsOfUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_notification_settings",
                schema: "dbo",
                columns: table => new
                {
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    MerchantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_roles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonType = table.Column<short>(type: "smallint", nullable: false),
                    MainDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RGIE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPFCNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailPublic = table.Column<bool>(type: "bit", nullable: false),
                    BlockedState = table.Column<byte>(type: "tinyint", nullable: false),
                    LastVisitDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_images_brands",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_images_brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_images_brands_tbl_domains_brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_models",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_models_tbl_domains_brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_models_tbl_domains_category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_field_payment_method_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxLenght = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethodTypeId = table.Column<short>(type: "smallint", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_domains_field_payment_method_type", x => x.Id);
                    table.ForeignKey(
                        name: "ctx_teste_domains_field_payment_method_type",
                        column: x => x.PaymentMethodTypeId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_payment_method_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_domains_cities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneCode = table.Column<int>(type: "int", nullable: false),
                    Temporary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_domains_cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_domains_cities_tbl_domains_regional_state_Sigla",
                        column: x => x.Sigla,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_regional_state",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_menu",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_menu_tbl_roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "tbl_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_roles_clains",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_role_claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_roles_clains_tbl_roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "tbl_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppLogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppLogItems_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_testimonies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    Ratting = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_testimony", x => x.Id);
                    table.ForeignKey(
                        name: "cnst_testimonies_receiver_user",
                        column: x => x.ReceiverUserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "cnst_testimonies_sender_user",
                        column: x => x.SenderUserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_buylists",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceptionAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceptionAddressObservation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buylist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_buylists_payments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_users_buylists_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_payments_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_clains",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_user_claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_clains_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_emails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailTypeId = table.Column<short>(type: "smallint", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_emails_tbl_domains_emails_types_EmailTypeId",
                        column: x => x.EmailTypeId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_emails_types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_emails_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_logins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users_logins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_tbl_users_logins_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_messages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_send = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_message", x => x.Id);
                    table.ForeignKey(
                        name: "cnst_users_messages_receiver_user",
                        column: x => x.ReceiverUserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "cnst_users_messages_sender_user",
                        column: x => x.SenderUserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_payment_methods",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodTypeId = table.Column<short>(type: "smallint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BankId = table.Column<short>(type: "smallint", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_users_payment_methods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_payment_methods_tbl_domains_banks_PaymentMethodTypeId",
                        column: x => x.PaymentMethodTypeId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_payment_methods_tbl_domains_payment_method_type_PaymentMethodTypeId",
                        column: x => x.PaymentMethodTypeId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_payment_method_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_users_payment_methods_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_phones",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<short>(type: "smallint", nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    PhoneTypeId = table.Column<short>(type: "smallint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_phones_tbl_domains_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_phones_tbl_domains_phone_type_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_phone_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_users_phones_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_roles",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_tbl_users_roles_tbl_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "tbl_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_users_roles_tbl_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_tokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessTokenExpiresDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessTokenHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenIdHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiresDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users_tokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_tbl_users_tokens_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_used_passwords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_used_passwords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_used_passwords_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_images_models",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_images_models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_images_models_tbl_models_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "dbo",
                        principalTable: "tbl_models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_models_prices",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimalValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    MaximalValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DisplayValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id__models_prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_models_prices_tbl_domains_conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_models_prices_tbl_models_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "dbo",
                        principalTable: "tbl_models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_addresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    AddressTypeId = table.Column<short>(type: "smallint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_addresses_tbl_domains_addresses_type_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_addresses_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_users_addresses_tbl_domains_cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_addresses_tbl_domains_regional_state_Sigla",
                        column: x => x.Sigla,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_regional_state",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_users_addresses_tbl_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_submenu",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_submenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_submenu_tbl_menu_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "dbo",
                        principalTable: "tbl_menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_buylist_product_withdrawal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BuyListID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buylist_product_withdrawal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_buylist_product_withdrawal_tbl_users_buylists_BuyListID",
                        column: x => x.BuyListID,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_buylists_inspections",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    BuyListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buylist_inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_inspections_tbl_users_buylists_BuyListId",
                        column: x => x.BuyListId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_buylists_itens",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    BuyListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buylist_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_itens_tbl_domains_conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_conditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_itens_tbl_models_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "dbo",
                        principalTable: "tbl_models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_itens_tbl_users_buylists_BuyListId",
                        column: x => x.BuyListId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_buylists_messagens",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buylists_messagens", x => x.Id);
                    table.ForeignKey(
                        name: "cnst_users_buylists_messagens_receiver_user",
                        column: x => x.ReceiverUserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "cnst_users_buylists_messagens_sender_user",
                        column: x => x.SenderUserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_messagens_tbl_users_buylists_BuyListId",
                        column: x => x.BuyListId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_payment_methods_values",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentFieldMethodTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_users_payment_methods_values", x => x.Id);
                    table.ForeignKey(
                        name: "ctx_teste_renan",
                        column: x => x.PaymentMethodId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_payment_methods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_payment_methods_values_tbl_domains_field_payment_method_type_PaymentFieldMethodTypeId",
                        column: x => x.PaymentFieldMethodTypeId,
                        principalSchema: "dbo",
                        principalTable: "tbl_domains_field_payment_method_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_buylists_inspections_itens",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyListItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buylist_inspections_itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_inspections_itens_tbl_users_buylists_inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists_inspections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_buylist_product_withdrawal_item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BuyListItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductWithdrawalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buylist_product_withdrawal_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_buylist_product_withdrawal_item_tbl_buylist_product_withdrawal_ProductWithdrawalId",
                        column: x => x.ProductWithdrawalId,
                        principalTable: "tbl_buylist_product_withdrawal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_buylist_product_withdrawal_item_tbl_users_buylists_itens_BuyListItemId",
                        column: x => x.BuyListItemId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists_itens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_images_buyLists_itens",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyListItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_images_buyLists_itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_images_buyLists_itens_tbl_users_buylists_itens_BuyListItemId",
                        column: x => x.BuyListItemId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists_itens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_users_buylists_itens_messagens",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyListItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_users_buylists_itens_messagens", x => x.Id);
                    table.ForeignKey(
                        name: "cnst_messages_buylists_itens_receiver_user",
                        column: x => x.ReceiverUserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "cnst_messages_buylists_itens_sender_user",
                        column: x => x.SenderUserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_users_buylists_itens_messagens_tbl_users_buylists_itens_BuyListItemId",
                        column: x => x.BuyListItemId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists_itens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_images_inspections_itens_images",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_images_inspections_itens_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_images_inspections_itens_images_tbl_users_buylists_inspections_itens_InspectionItemId",
                        column: x => x.InspectionItemId,
                        principalSchema: "dbo",
                        principalTable: "tbl_users_buylists_inspections_itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_buylist_product_withdrawal_item_serial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductWithdrawalItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_buylist_product_withdrawal_item_serial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_buylist_product_withdrawal_item_serial_tbl_buylist_product_withdrawal_item_ProductWithdrawalItemId",
                        column: x => x.ProductWithdrawalItemId,
                        principalTable: "tbl_buylist_product_withdrawal_item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_images_product_withdrawal_serials",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByBrowserName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_images_product_withdrawal_serials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_images_product_withdrawal_serials_tbl_buylist_product_withdrawal_item_serial_SerialItemId",
                        column: x => x.SerialItemId,
                        principalTable: "tbl_buylist_product_withdrawal_item_serial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppLogItems_UserId",
                table: "AppLogItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_buylist_product_withdrawal_BuyListID",
                table: "tbl_buylist_product_withdrawal",
                column: "BuyListID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_buylist_product_withdrawal_item_BuyListItemId",
                table: "tbl_buylist_product_withdrawal_item",
                column: "BuyListItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_buylist_product_withdrawal_item_ProductWithdrawalId",
                table: "tbl_buylist_product_withdrawal_item",
                column: "ProductWithdrawalId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_buylist_product_withdrawal_item_serial_ProductWithdrawalItemId",
                table: "tbl_buylist_product_withdrawal_item_serial",
                column: "ProductWithdrawalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_domains_cities_Sigla",
                schema: "dbo",
                table: "tbl_domains_cities",
                column: "Sigla");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_domains_field_payment_method_type_PaymentMethodTypeId",
                schema: "dbo",
                table: "tbl_domains_field_payment_method_type",
                column: "PaymentMethodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_images_brands_BrandId",
                schema: "dbo",
                table: "tbl_images_brands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_images_buyLists_itens_BuyListItemId",
                schema: "dbo",
                table: "tbl_images_buyLists_itens",
                column: "BuyListItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_images_inspections_itens_images_InspectionItemId",
                schema: "dbo",
                table: "tbl_images_inspections_itens_images",
                column: "InspectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_images_models_ModelId",
                schema: "dbo",
                table: "tbl_images_models",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_images_product_withdrawal_serials_SerialItemId",
                schema: "dbo",
                table: "tbl_images_product_withdrawal_serials",
                column: "SerialItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_menu_RoleId",
                schema: "dbo",
                table: "tbl_menu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_models_BrandId",
                schema: "dbo",
                table: "tbl_models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_models_CategoryId",
                schema: "dbo",
                table: "tbl_models",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_models_prices_ConditionId",
                schema: "dbo",
                table: "tbl_models_prices",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_models_prices_ModelId",
                schema: "dbo",
                table: "tbl_models_prices",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "tbl_roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roles_clains_RoleId",
                schema: "dbo",
                table: "tbl_roles_clains",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_submenu_MenuId",
                schema: "dbo",
                table: "tbl_submenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_testimonies_ReceiverUserId",
                schema: "dbo",
                table: "tbl_user_testimonies",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_testimonies_SenderUserId",
                schema: "dbo",
                table: "tbl_user_testimonies",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "tbl_users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "tbl_users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_addresses_AddressTypeId",
                schema: "dbo",
                table: "tbl_users_addresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_addresses_CityId",
                schema: "dbo",
                table: "tbl_users_addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_addresses_Sigla",
                schema: "dbo",
                table: "tbl_users_addresses",
                column: "Sigla");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_addresses_UserId",
                schema: "dbo",
                table: "tbl_users_addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_UserId",
                schema: "dbo",
                table: "tbl_users_buylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_inspections_BuyListId",
                schema: "dbo",
                table: "tbl_users_buylists_inspections",
                column: "BuyListId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_inspections_itens_InspectionId",
                schema: "dbo",
                table: "tbl_users_buylists_inspections_itens",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_itens_BuyListId",
                schema: "dbo",
                table: "tbl_users_buylists_itens",
                column: "BuyListId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_itens_ConditionId",
                schema: "dbo",
                table: "tbl_users_buylists_itens",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_itens_ModelId",
                schema: "dbo",
                table: "tbl_users_buylists_itens",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_itens_messagens_BuyListItemId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                column: "BuyListItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_itens_messagens_ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_itens_messagens_SenderUserId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_messagens_BuyListId",
                schema: "dbo",
                table: "tbl_users_buylists_messagens",
                column: "BuyListId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_messagens_ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_buylists_messagens",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_messagens_SenderUserId",
                schema: "dbo",
                table: "tbl_users_buylists_messagens",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_payments_UserId",
                schema: "dbo",
                table: "tbl_users_buylists_payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_clains_UserId",
                schema: "dbo",
                table: "tbl_users_clains",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_emails_EmailTypeId",
                schema: "dbo",
                table: "tbl_users_emails",
                column: "EmailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_emails_UserId",
                schema: "dbo",
                table: "tbl_users_emails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_logins_UserId",
                schema: "dbo",
                table: "tbl_users_logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_messages_ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_messages",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_messages_SenderUserId",
                schema: "dbo",
                table: "tbl_users_messages",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_payment_methods_PaymentMethodTypeId",
                schema: "dbo",
                table: "tbl_users_payment_methods",
                column: "PaymentMethodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_payment_methods_UserId",
                schema: "dbo",
                table: "tbl_users_payment_methods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_payment_methods_values_PaymentFieldMethodTypeId",
                schema: "dbo",
                table: "tbl_users_payment_methods_values",
                column: "PaymentFieldMethodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_payment_methods_values_PaymentMethodId",
                schema: "dbo",
                table: "tbl_users_payment_methods_values",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_phones_CountryId",
                schema: "dbo",
                table: "tbl_users_phones",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_phones_PhoneTypeId",
                schema: "dbo",
                table: "tbl_users_phones",
                column: "PhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_phones_UserId",
                schema: "dbo",
                table: "tbl_users_phones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "cst_user_role_unique",
                schema: "dbo",
                table: "tbl_users_roles",
                columns: new[] { "user_id", "role_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_roles_role_id",
                schema: "dbo",
                table: "tbl_users_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_used_passwords_UserId",
                schema: "dbo",
                table: "tbl_users_used_passwords",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDataProtectionKeys");

            migrationBuilder.DropTable(
                name: "AppLogItems");

            migrationBuilder.DropTable(
                name: "AppSqlCache");

            migrationBuilder.DropTable(
                name: "tbl_company_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_general_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_images_brands",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_images_buyLists_itens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_images_inspections_itens_images",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_images_models",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_images_product_withdrawal_serials",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_models_prices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_notification_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_roles_clains",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_submenu",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_user_testimonies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_addresses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_buylists_itens_messagens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_buylists_messagens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_buylists_payments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_clains",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_emails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_logins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_messages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_payment_methods_values",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_phones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_tokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_used_passwords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_buylists_inspections_itens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_buylist_product_withdrawal_item_serial");

            migrationBuilder.DropTable(
                name: "tbl_menu",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_addresses_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_cities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_emails_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_payment_methods",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_field_payment_method_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_countries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_phone_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_buylists_inspections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_buylist_product_withdrawal_item");

            migrationBuilder.DropTable(
                name: "tbl_roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_regional_state",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_banks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_payment_method_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_buylist_product_withdrawal");

            migrationBuilder.DropTable(
                name: "tbl_users_buylists_itens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_conditions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_models",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users_buylists",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_brands",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_domains_category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_users",
                schema: "dbo");
        }
    }
}
