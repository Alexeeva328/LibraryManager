using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentType = table.Column<int>(type: "integer", nullable: false),
                    OriginalName = table.Column<string>(type: "text", nullable: false),
                    RussianName = table.Column<string>(type: "text", nullable: false),
                    EnglishName = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    MyRating = table.Column<int>(type: "integer", nullable: false),
                    TotalUnits = table.Column<int>(type: "integer", nullable: true),
                    CompletedUnits = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titles_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_TagId",
                table: "Titles",
                column: "TagId");
            
           migrationBuilder.Sql(@"
    INSERT INTO ""Tags"" (""Id"", ""Name"", ""Category"", ""Description"") VALUES
    -- Жанры (Category = 1)
    ('00000000-0000-0000-0000-000000000101', 'Фэнтези',           1, 'Жанр с магией, вымышленными мирами и мифическими существами'),
    ('00000000-0000-0000-0000-000000000102', 'Романтика',         1, 'Истории о любви, романтических отношениях и эмоциональных переживаниях'),
    ('00000000-0000-0000-0000-000000000103', 'Ужасы',             1, 'Жанр, вызывающий страх, тревогу и напряжение через сверхъестественные или психологические элементы'),
    ('00000000-0000-0000-0000-000000000104', 'Детектив',          1, 'Расследования преступлений, загадок и тайн с логическими выводами'),
    ('00000000-0000-0000-0000-000000000105', 'Приключения',       1, 'Путешествия, исследования и опасные экспедиции в поисках приключений'),
    ('00000000-0000-0000-0000-000000000106', 'Комедия',           1, 'Юмористические истории с забавными ситуациями и весёлыми персонажами'),
    ('00000000-0000-0000-0000-000000000107', 'Историческое',      1, 'События, разворачивающиеся в определённый исторический период с элементами эпохи'),
    ('00000000-0000-0000-0000-000000000108', 'Повседневность',    1, 'Истории из обычной жизни с акцентом на быт, отношения и мелкие события'),
    ('00000000-0000-0000-0000-000000000109', 'Психология',        1, 'Глубокое исследование внутреннего мира персонажей, мотивов и душевных состояний'),
    ('00000000-0000-0000-0000-000000000110', 'Драма',             1, 'Эмоциональные истории с напряжёнными конфликтами и серьёзными жизненными ситуациями'),
    
    -- Темы (Category = 2)
    ('00000000-0000-0000-0000-000000000201', 'Магия',             2, 'Использование сверхъестественных сил, заклинаний и волшебства'),
    ('00000000-0000-0000-0000-000000000202', 'Путешествия',       2, 'Перемещения между мирами, странами или локациями с целью приключений или спасения'),
    ('00000000-0000-0000-0000-000000000203', 'Исекай',            2, 'Перенос обычного человека в другой мир с магией или игровой механикой'),
    ('00000000-0000-0000-0000-000000000204', 'Культивация',       2, 'Путь к могуществу через тренировки, самосовершенствование и духовное развитие'),
    ('00000000-0000-0000-0000-000000000205', 'Политика',          2, 'Интриги, борьба за власть, дипломатия и управление государством'),
    ('00000000-0000-0000-0000-000000000206', 'Война',             2, 'Военные конфликты, битвы, стратегии и судьбы солдат на поле боя'),
    ('00000000-0000-0000-0000-000000000207', 'Школа',             2, 'События в учебных заведениях с акцентом на дружбу, любовь и подростковые проблемы'),
    ('00000000-0000-0000-0000-000000000208', 'Бизнес',            2, 'Корпоративные войны, стартапы, сделки и экономические интриги'),
    ('00000000-0000-0000-0000-000000000209', 'Сверхъестественное',2, 'Существа и явления, выходящие за рамки законов природы и науки'),
    ('00000000-0000-0000-0000-000000000210', 'Научная фантастика',2, 'Технологии будущего, космос, роботы и научные достижения за пределами современности'),
    ('00000000-0000-0000-0000-000000000211', 'Современный мир',   2, 'События в современном обществе с реалистичными технологиями и социальными нормами'),
    ('00000000-0000-0000-0000-000000000212', 'Система',           2, 'Игровые интерфейсы, квесты, уровни и навыки как часть сюжета'),
    ('00000000-0000-0000-0000-000000000213', 'Перерождение',      2, 'Возрождение души в новом теле с сохранением воспоминаний предыдущей жизни'),
    ('00000000-0000-0000-0000-000000000214', 'Бессмертие',        2, 'Вечная жизнь, поиски бессмертия и философские вопросы о смерти'),
    ('00000000-0000-0000-0000-000000000215', 'Боевые искусства',  2, 'Рукопашный бой, тренировки, турниры и путь воина'),
    ('00000000-0000-0000-0000-000000000216', 'Повелитель демонов',2, 'Тёмные владыки, демонические силы и борьба со злом'),
    
    -- Настроения (Category = 3)
    ('00000000-0000-0000-0000-000000000301', 'Тёмное',            3, 'Мрачная и гнетущая атмосфера с элементами опасности и отчаяния'),
    ('00000000-0000-0000-0000-000000000302', 'Светлое',           3, 'Добрая и оптимистичная атмосфера с надеждой и положительными эмоциями'),
    ('00000000-0000-0000-0000-000000000303', 'Меланхолия',        3, 'Грустное, задумчивое настроение с нотками тоски и ностальгии'),
    ('00000000-0000-0000-0000-000000000304', 'Напряжённое',       3, 'Атмосфера тревоги, ожидания и эмоционального напряжения'),
    ('00000000-0000-0000-0000-000000000305', 'Уютное',            3, 'Тёплая и комфортная атмосфера, создающая чувство покоя и безопасности'),
    ('00000000-0000-0000-0000-000000000306', 'Трагичное',         3, 'Истории с трагическими событиями, потерями и глубокими страданиями'),
    ('00000000-0000-0000-0000-000000000307', 'Оптимистичное',     3, 'Вера в лучшее, позитивный настрой и счастливые решения проблем'),
    
    -- Типы персонажей (Category = 4)
    ('00000000-0000-0000-0000-000000000401', 'Сильный герой',     4, 'Физически или магически могущественный персонаж, способный на великие дела'),
    ('00000000-0000-0000-0000-000000000402', 'Антигерой',         4, 'Персонаж с сомнительной моралью, который поступает правильно неправильным путём'),
    ('00000000-0000-0000-0000-000000000403', 'Принцесса',         4, 'Благородная и изящная героиня, часто нуждающаяся в защите или спасении'),
    ('00000000-0000-0000-0000-000000000404', 'Злодей',            4, 'Персонаж с негативными чертами, противостоящий главному герою и творящий зло'),
    ('00000000-0000-0000-0000-000000000405', 'Гений',             4, 'Обладатель выдающегося интеллекта, способный решать сложнейшие задачи'),
    ('00000000-0000-0000-0000-000000000406', 'Целеустремлённый',  4, 'Персонаж с сильной волей и ясной целью, не останавливающийся ни перед чем'),
    ('00000000-0000-0000-0000-000000000407', 'Харизматичный',     4, 'Обаятельный и притягательный персонаж, способный вести за собой других'),
    ('00000000-0000-0000-0000-000000000408', 'Загадочный',        4, 'Персонаж с тайной, скрывающий свои истинные намерения и прошлое'),
    ('00000000-0000-0000-0000-000000000409', 'Умный герой',       4, 'Персонаж, решающий проблемы через интеллект, стратегию и планирование'),
    ('00000000-0000-0000-0000-000000000410', 'Глупый герой',      4, 'Наивный или недалёкий персонаж, который компенсирует это силой или везением'),
    
    -- Отношения (Category = 5)
   
    ('00000000-0000-0000-0000-000000000501', 'Враги',                 5, 'Отношения открытой вражды, антагонизма и противостояния'),
    ('00000000-0000-0000-0000-000000000502', 'От ненависти до любви', 5, 'Троп, где персонажи начинают с вражды, но постепенно влюбляются друг в друга'),
    ('00000000-0000-0000-0000-000000000503', 'Дружба',                5, 'Крепкие отношения между друзьями, взаимопомощь и поддержка'),
    ('00000000-0000-0000-0000-000000000504', 'Возлюбленные детства',  5, 'Персонажи, которые любили друг друга с детства и сохранили эти чувства'),
    ('00000000-0000-0000-0000-000000000505', 'Соперники',             5, 'Отношения на основе конкуренции, где соперники могут стать уважать друг друга'),
    
    -- Сеттинги (Category = 6)
    ('00000000-0000-0000-0000-000000000601', 'Средневековье',          6, 'Мир с рыцарями, королевствами, магией и феодальным укладом жизни'),
    ('00000000-0000-0000-0000-000000000602', 'Омегаверс (ABO)',        6, 'Вселенная с иерархией на альф, бет и омег, где запахи и инстинкты играют ключевую роль'),
    ('00000000-0000-0000-0000-000000000603', 'Современность',          6, 'Мир с современными технологиями, городами и социальными нормами'),
    ('00000000-0000-0000-0000-000000000604', 'Космос',                 6, 'Галактики, звёздные войны, космические путешествия и колонизация планет'),
    ('00000000-0000-0000-0000-000000000605', 'Альтернативная история', 6, 'Мир, где исторические события пошли по другому пути, создав альтернативную реальность'),
    ('00000000-0000-0000-0000-000000000606', 'Постапокалипсис',        6, 'Мир после глобальной катастрофы, борьба за выживание и восстановление'),
    ('00000000-0000-0000-0000-000000000607', 'Путешествие во времени', 6, 'Перемещения между временными эпохами со всеми вытекающими последствиями'),
    ('00000000-0000-0000-0000-000000000608', 'Зомби-апокалипсис',      6, 'Мир, захваченный зомби-инфекцией, с постоянной угрозой смерти и выживанием'),
    ('00000000-0000-0000-0000-000000000609', 'Регрессия',              6, 'Возвращение в своё прошлое тело с сохранением памяти о будущем'),
    ('00000000-0000-0000-0000-000000000610', 'Трансмиграция',          6, 'Перенос души или сознания в чужое тело или другой мир'),
    ('00000000-0000-0000-0000-000000000611', 'Выживание',              6, 'Борьба за жизнь в экстремальных условиях, поиск ресурсов и убежища'),
    ('00000000-0000-0000-0000-000000000612', 'Древний Китай',          6, 'Мир с историческими элементами Китая, культивацией и императорскими династиями'),
    
    -- Сюжетные тропы (Category = 7)
    ('00000000-0000-0000-0000-000000000701', 'Медленное развитие (Slow Burn)', 7, 'Отношения, развивающиеся медленно и постепенно, на протяжении многих глав'),
    ('00000000-0000-0000-0000-000000000702', 'Тайна личности',                 7, 'Персонаж скрывает свою истинную личность, прошлое или способности'),
    ('00000000-0000-0000-0000-000000000703', 'Богатый герой',                  7, 'Главный герой обладает огромным богатством, которое становится важной частью сюжета'),
    ('00000000-0000-0000-0000-000000000704', 'Месть',                          7, 'Герой стремится отомстить обидчикам, что является его главной мотивацией'),
    ('00000000-0000-0000-0000-000000000705', 'Амнезия',                        7, 'Герой теряет память, и его прошлое становится центральной загадкой'),
    
    -- Другое (Category = 99)
    ('00000000-0000-0000-0000-000000009901', 'Ранобэ',           99, 'Японские или корейские лайт-новеллы, часто с элементами фэнтези и игр'),
    ('00000000-0000-0000-0000-000000009902', 'Адаптировано',     99, 'Сюжет, основанный на манхве, манге, романе или дораме'),
    ('00000000-0000-0000-0000-000000009903', 'Онгоинг',          99, 'Произведение, которое ещё выходит, и главы публикуются по мере написания'),
    ('00000000-0000-0000-0000-000000009904', 'Завершено',        99, 'История полностью закончена, все главы опубликованы'),
    ('00000000-0000-0000-0000-000000009905', 'Популярное',       99, 'Произведение с высокой популярностью и большим количеством читателей'),
    ('00000000-0000-0000-0000-000000009906', 'Классика',         99, 'Культовое произведение, которое оказало влияние на жанр или приобрело культовый статус');
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
             DELETE FROM ""Tags"" WHERE ""Category"" IN (1, 2, 3, 4, 5, 6, 7, 99);
            ");
            
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
                name: "Titles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
