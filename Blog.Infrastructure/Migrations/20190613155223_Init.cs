using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Alias = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ParentId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<long>(nullable: false, defaultValue: 0L),
                    LastModifiedDate = table.Column<long>(nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.UniqueConstraint("Unique_Category_Alias", x => x.Alias);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IpAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Alias = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<long>(nullable: false, defaultValue: 0L),
                    LastModifiedDate = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.UniqueConstraint("Unique_Tag_Alias", x => x.Alias);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<long>(nullable: false, defaultValue: 0L),
                    LastModifiedDate = table.Column<long>(nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    ThumbnailImageUrl = table.Column<string>(nullable: true),
                    Recap = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<long>(nullable: false, defaultValue: 0L),
                    LastModifiedDate = table.Column<long>(nullable: false, defaultValue: 0L),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.UniqueConstraint("Unique_Slug", x => x.Slug);
                    table.ForeignKey(
                        name: "FK_Articles_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    ArticleId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    ArticleId = table.Column<string>(nullable: false),
                    TagId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ArticleTags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Recap = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<long>(nullable: false, defaultValue: 0L),
                    ArticleId = table.Column<string>(nullable: true),
                    ReaderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Alias", "CreatedDate", "Description", "LastModifiedDate", "Name", "ParentId" },
                values: new object[] { "289ebc79-5307-4c89-ac1b-025a780eaa73", "TECHNICAL", 1560182949L, "Articles about technical topics", 1560182949L, "Technical", null });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "IpAddress", "Name" },
                values: new object[,]
                {
                    { "27fe5a64-0032-4d11-9225-ecc9d54b8a52", "10.125.21.2", "Xiao Qin Fang" },
                    { "c4fa13de-f446-411c-9ed9-d6a5119b7b96", "120.22.31.55", "Raccoon" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Alias", "CreatedDate", "LastModifiedDate" },
                values: new object[,]
                {
                    { "3a045768-5dfc-4a46-b673-7d10f7da6ee8", "dotnet", 1560182949L, 1560182949L },
                    { "46a0b627-93c7-4b95-a029-b788ad887b1e", "js", 1560182949L, 1560182949L },
                    { "5a10c508-b548-42e7-a968-a487b66c6984", "technical", 1560182949L, 1560182949L }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LastModifiedDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "87913df7-7dc9-45bb-a486-6be3a902f8c0", 0, "58ddc1cc-0426-4657-8da6-6af807a39a27", 1560182949L, "lolgag@9gag.com", false, 1560182949L, false, null, null, null, null, null, false, null, false, null },
                    { "f6eb594c-4c06-4dec-9412-133c2d32a549", 0, "d7a79900-7ca0-447b-9b95-b9c675d927f9", 1560182949L, "tech@reddit.com", false, 1560182949L, false, null, null, null, null, null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedDate", "LastModifiedDate", "Recap", "Slug", "ThumbnailImageUrl", "Title" },
                values: new object[,]
                {
                    { "47eef876-5eb2-442f-913c-6ad098864f9e", "87913df7-7dc9-45bb-a486-6be3a902f8c0", "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit", 1560182949L, 1560182949L, "Angular definitely", "angular-reactjs-and-vuejs-which-to-choose", "https://localhost:7070/api/fileUploader/angular-is-the-best.png", "Angular, ReactJS and VueJs, which to choose?" },
                    { "9a574346-a3a5-4860-a3bd-54be358ba236", "f6eb594c-4c06-4dec-9412-133c2d32a549", "I don't know how it works either", 1560182949L, 1560182949L, ".NET compiler is really complicated", "how-net-compiler-work", "https://localhost:7070/api/fileUploader/netcompiler.png", "How .NET compiler work?" },
                    { "f2e240c4-3e7e-4c87-93ce-c95ffa2941c2", "f6eb594c-4c06-4dec-9412-133c2d32a549", "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga", 1560182949L, 1560182949L, ".NET Core is sky-rocketing", "the-rise-of-net-core", "https://localhost:7070/api/fileUploader/netcore.png", "The rise of .NET Core" },
                    { "4bcfe398-d377-43ce-a134-99f0823511d7", "f6eb594c-4c06-4dec-9412-133c2d32a549", "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur", 1560182949L, 1560182949L, "Rust is becoming another trend", "rust-is-becoming-another-trend", "https://localhost:7070/api/fileUploader/rustland.png", "Rust is becoming another trend" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Alias", "CreatedDate", "Description", "LastModifiedDate", "Name", "ParentId" },
                values: new object[,]
                {
                    { "15838af4-3566-4438-a7fa-5dbc2d97af80", "NET-FRAMEWORK", 1560182949L, "Articles about the .NET/.NET Core framework", 1560182949L, ".NET/.NET Core Framework", "289ebc79-5307-4c89-ac1b-025a780eaa73" },
                    { "f9e04123-f0c7-404f-b7bd-c0c03db0e5c3", "JAVASCRIPT", 1560182949L, "Articles about Javascript and its libraries", 1560182949L, "Javascript", "289ebc79-5307-4c89-ac1b-025a780eaa73" }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategory",
                columns: new[] { "ArticleId", "CategoryId" },
                values: new object[,]
                {
                    { "47eef876-5eb2-442f-913c-6ad098864f9e", "15838af4-3566-4438-a7fa-5dbc2d97af80" },
                    { "9a574346-a3a5-4860-a3bd-54be358ba236", "15838af4-3566-4438-a7fa-5dbc2d97af80" },
                    { "f2e240c4-3e7e-4c87-93ce-c95ffa2941c2", "15838af4-3566-4438-a7fa-5dbc2d97af80" },
                    { "f2e240c4-3e7e-4c87-93ce-c95ffa2941c2", "f9e04123-f0c7-404f-b7bd-c0c03db0e5c3" },
                    { "4bcfe398-d377-43ce-a134-99f0823511d7", "f9e04123-f0c7-404f-b7bd-c0c03db0e5c3" }
                });

            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[,]
                {
                    { "47eef876-5eb2-442f-913c-6ad098864f9e", "5a10c508-b548-42e7-a968-a487b66c6984" },
                    { "9a574346-a3a5-4860-a3bd-54be358ba236", "3a045768-5dfc-4a46-b673-7d10f7da6ee8" },
                    { "9a574346-a3a5-4860-a3bd-54be358ba236", "5a10c508-b548-42e7-a968-a487b66c6984" },
                    { "9a574346-a3a5-4860-a3bd-54be358ba236", "46a0b627-93c7-4b95-a029-b788ad887b1e" },
                    { "f2e240c4-3e7e-4c87-93ce-c95ffa2941c2", "5a10c508-b548-42e7-a968-a487b66c6984" },
                    { "4bcfe398-d377-43ce-a134-99f0823511d7", "3a045768-5dfc-4a46-b673-7d10f7da6ee8" },
                    { "4bcfe398-d377-43ce-a134-99f0823511d7", "46a0b627-93c7-4b95-a029-b788ad887b1e" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "Content", "CreatedDate", "ReaderId", "Recap" },
                values: new object[,]
                {
                    { "a4668006-e3f5-4038-a852-6c764913a976", "47eef876-5eb2-442f-913c-6ad098864f9e", "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam", 1560182949L, "c4fa13de-f446-411c-9ed9-d6a5119b7b96", "This article is useful" },
                    { "4306d506-b505-4581-886f-016eda2bcfa9", "47eef876-5eb2-442f-913c-6ad098864f9e", "Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis", 1560182949L, "27fe5a64-0032-4d11-9225-ecc9d54b8a52", "I prefer Angular" },
                    { "351ecc42-2de5-4835-bdb4-dc0da4233acc", "9a574346-a3a5-4860-a3bd-54be358ba236", "Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain", 1560182949L, "27fe5a64-0032-4d11-9225-ecc9d54b8a52", "It's basic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_CategoryId",
                table: "ArticleCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReaderId",
                table: "Comments",
                column: "ReaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
