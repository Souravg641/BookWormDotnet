using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm.Migrations
{
    /// <inheritdoc />
    public partial class CreateCcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributesMasters",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributesMasters", x => x.AttributeId);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryMasters",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryEmailId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiaryBankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryBankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryIFSC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryAccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    BeneficiaryAccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiaryPAN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryMasters", x => x.BeneficiaryId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMasters",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMasters", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypeMasters",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeMasters", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Authentications",
                columns: table => new
                {
                    AuthenticationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentications", x => x.AuthenticationId);
                    table.ForeignKey(
                        name: "FK_Authentications_CustomerMasters_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerMasters",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_CustomerMasters_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerMasters",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyShelfs",
                columns: table => new
                {
                    ShelfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyShelfs", x => x.ShelfId);
                    table.ForeignKey(
                        name: "FK_MyShelfs_CustomerMasters_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerMasters",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageMasters",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageMasters", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_LanguageMasters_ProductTypeMasters_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypeMasters",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMasters",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMasters", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_GenreMasters_LanguageMasters_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguageMasters",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMasters",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductEnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductBasePrice = table.Column<float>(type: "real", nullable: true),
                    ProductSellingPriceCost = table.Column<float>(type: "real", nullable: true),
                    ProductOfferPrice = table.Column<float>(type: "real", nullable: true),
                    ProductOfferPriceExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductDescriptionShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescriptionLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRentable = table.Column<bool>(type: "bit", nullable: true),
                    IsLibrary = table.Column<bool>(type: "bit", nullable: true),
                    RentPerDay = table.Column<float>(type: "real", nullable: true),
                    MinRentDays = table.Column<int>(type: "int", nullable: true),
                    ProductImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMasters", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductMasters_GenreMasters_GenreId",
                        column: x => x.GenreId,
                        principalTable: "GenreMasters",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMasters_LanguageMasters_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguageMasters",
                        principalColumn: "LanguageId");
                    table.ForeignKey(
                        name: "FK_ProductMasters_ProductTypeMasters_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypeMasters",
                        principalColumn: "TypeId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentNumberOfDays = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_ProductMasters_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductMasters",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyShelfProductMaster",
                columns: table => new
                {
                    MyShelvesShelfId = table.Column<int>(type: "int", nullable: false),
                    ProductMasterProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyShelfProductMaster", x => new { x.MyShelvesShelfId, x.ProductMasterProductId });
                    table.ForeignKey(
                        name: "FK_MyShelfProductMaster_MyShelfs_MyShelvesShelfId",
                        column: x => x.MyShelvesShelfId,
                        principalTable: "MyShelfs",
                        principalColumn: "ShelfId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyShelfProductMaster_ProductMasters_ProductMasterProductId",
                        column: x => x.ProductMasterProductId,
                        principalTable: "ProductMasters",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    ProductAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeValue = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.ProductAttributeId);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_AttributesMasters_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributesMasters",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_ProductMasters_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductMasters",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBeneficiaryMasters",
                columns: table => new
                {
                    ProductBeneficiaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductBeneficiaryPercentage = table.Column<float>(type: "real", nullable: false),
                    BeneficiaryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBeneficiaryMasters", x => x.ProductBeneficiaryId);
                    table.ForeignKey(
                        name: "FK_ProductBeneficiaryMasters_BeneficiaryMasters_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "BeneficiaryMasters",
                        principalColumn: "BeneficiaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBeneficiaryMasters_ProductMasters_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductMasters",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoyaltyCalculations",
                columns: table => new
                {
                    RoyaltyCalculationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    RoyaltyCalculationTransactiondate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoyaltyCalculations", x => x.RoyaltyCalculationId);
                    table.ForeignKey(
                        name: "FK_RoyaltyCalculations_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoyaltyCalculations_ProductMasters_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductMasters",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryMasterRoyaltyCalculation",
                columns: table => new
                {
                    BeneficiaryMastersBeneficiaryId = table.Column<int>(type: "int", nullable: false),
                    RoyaltyCalculationsRoyaltyCalculationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryMasterRoyaltyCalculation", x => new { x.BeneficiaryMastersBeneficiaryId, x.RoyaltyCalculationsRoyaltyCalculationId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryMasterRoyaltyCalculation_BeneficiaryMasters_BeneficiaryMastersBeneficiaryId",
                        column: x => x.BeneficiaryMastersBeneficiaryId,
                        principalTable: "BeneficiaryMasters",
                        principalColumn: "BeneficiaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryMasterRoyaltyCalculation_RoyaltyCalculations_RoyaltyCalculationsRoyaltyCalculationId",
                        column: x => x.RoyaltyCalculationsRoyaltyCalculationId,
                        principalTable: "RoyaltyCalculations",
                        principalColumn: "RoyaltyCalculationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authentications_CustomerId",
                table: "Authentications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryMasterRoyaltyCalculation_RoyaltyCalculationsRoyaltyCalculationId",
                table: "BeneficiaryMasterRoyaltyCalculation",
                column: "RoyaltyCalculationsRoyaltyCalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMasters_LanguageId",
                table: "GenreMasters",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageMasters_TypeId",
                table: "LanguageMasters",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MyShelfProductMaster_ProductMasterProductId",
                table: "MyShelfProductMaster",
                column: "ProductMasterProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MyShelfs_CustomerId",
                table: "MyShelfs",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_AttributeId",
                table: "ProductAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "ProductAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBeneficiaryMasters_BeneficiaryId",
                table: "ProductBeneficiaryMasters",
                column: "BeneficiaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBeneficiaryMasters_ProductId",
                table: "ProductBeneficiaryMasters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMasters_GenreId",
                table: "ProductMasters",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMasters_LanguageId",
                table: "ProductMasters",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMasters_TypeId",
                table: "ProductMasters",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_InvoiceId",
                table: "RoyaltyCalculations",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_ProductId",
                table: "RoyaltyCalculations",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentications");

            migrationBuilder.DropTable(
                name: "BeneficiaryMasterRoyaltyCalculation");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "MyShelfProductMaster");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductBeneficiaryMasters");

            migrationBuilder.DropTable(
                name: "RoyaltyCalculations");

            migrationBuilder.DropTable(
                name: "MyShelfs");

            migrationBuilder.DropTable(
                name: "AttributesMasters");

            migrationBuilder.DropTable(
                name: "BeneficiaryMasters");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProductMasters");

            migrationBuilder.DropTable(
                name: "CustomerMasters");

            migrationBuilder.DropTable(
                name: "GenreMasters");

            migrationBuilder.DropTable(
                name: "LanguageMasters");

            migrationBuilder.DropTable(
                name: "ProductTypeMasters");
        }
    }
}
