using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformersShop.Migrations
{
    public partial class BetterProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5c798e15-0405-4089-af5d-c4888ab16796");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acab9182-1db7-494d-99ab-8653d8d547b1", "AQAAAAEAACcQAAAAEAPNNmEjkbiVg02oVUUdal8ur/3lLoaglnhx+khWrkqDQHbyfrZO/A+Yjq41QHzdOA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dinobot");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Picture" },
                values: new object[] { "Optimus Prime is the noble and heroic leader of the Autobots, a faction of sentient robots from the planet Cybertron. He transforms into a red and blue semi-truck and is known for his strong sense of justice, unwavering courage, and self-sacrifice. Optimus Prime believes in freedom for all sentient beings and is a skilled and powerful warrior. He is often seen wielding his iconic energy axe and Ion Blaster in battle. Optimus Prime's leadership, wisdom, and compassion make him a beloved and respected figure among the Autobots and their allies.", "Optimus Prime", "https://c4.wallpaperflare.com/wallpaper/768/872/3/transformers-robot-wallpaper-preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name", "Picture" },
                values: new object[] { 1, "Bumblebee is one of the most well-known and endearing Autobots. He transforms into a yellow compact car, often depicted as a Volkswagen Beetle or a Chevrolet Camaro in various adaptations. Bumblebee is characterized by his loyalty, bravery, and resourcefulness. Despite his smaller size compared to other Autobots, Bumblebee is a fierce and agile fighter, often taking on scouting and espionage missions due to his speed and stealth. He has a strong bond with the humans he befriends, particularly with characters like Sam Witwicky in the live-action films.", "Bumblebee", "https://i.pinimg.com/736x/86/e9/35/86e9359600ada784d2712321b4c2b1a9.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Megatron is the ruthless and powerful leader of the Decepticons, the main antagonists of the Transformers universe. He transforms into various forms depending on the adaptation, including a Walther P38 pistol, a tank, or a Cybertronian jet. Megatron's primary goal is to conquer Cybertron and, eventually, the universe, believing that peace can only be achieved through tyranny. He is a formidable combatant with immense strength, advanced weaponry, and a keen tactical mind. Megatron's leadership is marked by fear and oppression, making him a formidable foe to Optimus Prime and the Autobots.", "Megatron" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Picture" },
                values: new object[] { "Sideswipe is a sleek and stylish Autobot known for his speed, agility, and combat prowess. He typically transforms into a red or silver sports car, such as a Lamborghini or a Chevrolet Corvette, depending on the adaptation. Sideswipe is a skilled warrior who enjoys the thrill of battle and has a competitive nature. He is often depicted as a fearless and daring fighter, willing to take risks to achieve victory. Sideswipe's combat skills are complemented by his twin arm-mounted blades or swords, making him a formidable opponent in close-quarters combat. He is also known for his witty and sometimes cocky personality, adding a dynamic edge to the Autobot team.", "Sideswipe", "https://wallpapercave.com/wp/wp3466400.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Picture", "StockCount" },
                values: new object[] { 5, 3, "Grimlock is the fierce and powerful leader of the Dinobots, a subgroup of Autobots. He transforms into a mechanical Tyrannosaurus Rex, making him one of the most imposing and fearsome Transformers. Grimlock is characterized by his immense strength, combat prowess, and a stubborn, often rebellious personality. Unlike most Autobots, Grimlock prefers brute force over strategic planning and is known for his straightforward, no-nonsense approach to battle. He often wields an energy sword and a double-barreled rocket launcher in his robot form.\r\n\r\nDespite his gruff demeanor and limited speech capabilities (often speaking in broken sentences like \"Me Grimlock, king!\"), Grimlock possesses a strong sense of loyalty to his fellow Dinobots and the Autobots. He has a deep disdain for the Decepticons and relishes in the opportunity to fight them. Grimlock's leadership of the Dinobots is marked by his protective nature towards his team, and while he may question Optimus Prime's decisions at times, he ultimately respects him as a leader.\r\n\r\nGrimlock's unique transformation and his raw, primal power make him a standout character in the Transformers universe, often providing a mix of muscle and unpredictability to the Autobot ranks.", "Grimlock", "https://i.pinimg.com/736x/c4/fb/9c/c4fb9c7c55f74fa4141a4b144f2b5f7e.jpg", 10 });

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "31e574dd-4188-41e2-abbf-b460e44e12f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "49080b32-597e-4edd-9835-7421c2966df7", "AQAAAAEAACcQAAAAEDKAiUW8X7LC3homvs/tHzPD7OVE2IE24LCxOFdjV/GRtmRxhZrF35VDzZBjydBd7g==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Other");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Picture" },
                values: new object[] { "Description for Transformer 1", "Transformer 1", "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/9ece39f6-6737-42b8-b282-f99688062708/d6e4o93-ff76b235-071a-47e8-b3d0-9b02147fbd0c.jpg/v1/fill/w_525,h_350,q_70,strp/tf_fanart___autobots_vacation_ver2_by_goddessmechanic_d6e4o93-350t.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTMzIiwicGF0aCI6IlwvZlwvOWVjZTM5ZjYtNjczNy00MmI4LWIyODItZjk5Njg4MDYyNzA4XC9kNmU0bzkzLWZmNzZiMjM1LTA3MWEtNDdlOC1iM2QwLTliMDIxNDdmYmQwYy5qcGciLCJ3aWR0aCI6Ijw9ODAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.vdyCpLE2-clAoreexFRcOwy12j2HnSDxKoenEOZltSQ" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name", "Picture" },
                values: new object[] { 3, "Description for Transformer 2", "Transformer 2", "https://media.tenor.com/r06Prd4E5i0AAAAe/transformers-funny.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description for Transformer 3", "Transformer 3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Picture" },
                values: new object[] { "Description for Transformer 4", "Transformer 4", "https://i.pinimg.com/originals/9f/bf/05/9fbf05e55cabc5e5ba61e5df243561d5.gif" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
