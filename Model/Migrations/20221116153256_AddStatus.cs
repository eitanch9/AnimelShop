using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class AddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Mammal" },
                    { 2, "Bird" },
                    { 3, "Fish" },
                    { 4, "Reptile" },
                    { 5, "Amphibians" },
                    { 6, "Invertebrates" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PictureLink" },
                values: new object[,]
                {
                    { 1, 5, 1, "The dog  is a domesticated descendant of the wolf. Also called the domestic dog, it is derived from the extinct Pleistocene wolf, and the modern wolf is the dog's nearest living relative. The dog was the first species to be domesticated, by hunter-gatherers over 15,000 years ago, before the development of agriculture. Due to their long association with humans, dogs have expanded to a large number of domestic individuals and gained the ability to thrive on a starch-rich diet that would be inadequate for other canids.", "Dog", "Assets\\Dog.jfif" },
                    { 2, 2, 1, "The cat is a domestic species of small carnivorous mammal. It is the only domesticated species in the family Felidae and is commonly referred to as the domestic cat or house cat to distinguish it from the wild members of the family. A cat can either be a house cat, a farm cat, or a feral cat; the feral cat ranges freely and avoids human contact. Domestic cats are valued by humans for companionship and their ability to kill rodents. About 60 cat breeds are recognized by various cat registries.", "Cat", "Assets\\cat.jfif" },
                    { 3, 5, 1, "The proboscis monkey (Nasalis larvatus) or long-nosed monkey is an arboreal Old World monkey with an unusually large nose, a reddish-brown skin color and a long tail. It is endemic to the southeast Asian island of Borneo and is found mostly in mangrove forests and on the coastal areas of the island.", "Proboscis Monkey", "Assets\\ProboscisMonkey.jfif" },
                    { 4, 12, 1, "Dolphins range in size from the 1.7-metre-long (5 ft 7 in) and 50-kilogram (110-pound) Maui's dolphin to the 9.5 m (31 ft 2 in) and 10-tonne (11-short-ton) orca. Various species of dolphins exhibit sexual dimorphism where the males are larger than females. They have streamlined bodies and two limbs that are modified into flippers.", "Dolphin", "Assets\\Dolphin.jfif" },
                    { 5, 3, 1, "The second largest order of mammals after rodents, bats comprise about 20% of all classified mammal species worldwide, with over 1,400 species. These were traditionally divided into two suborders: the largely fruit-eating megabats, and the echolocating microbats. But more recent evidence has supported dividing the order into Yinpterochiroptera and Yangochiroptera, with megabats as members of the former along with several species of microbats.", "Bat", "Assets\\Bat.jpg" },
                    { 6, 3, 2, "The grey parrot (Psittacus erithacus), also known as the Congo grey parrot, Congo African grey parrot or African grey parrot, is an Old World parrot in the family Psittacidae. The Timneh parrot (Psittacus timneh) once was identified as a subspecies of the grey parrot, but has since been elevated to a full species.", "grey parrot", "Assets\\GreyParrot.jpg" },
                    { 7, 12, 2, "Eagle is the common name for many large birds of prey of the family Accipitridae. Eagles belong to several groups of genera, some of which are closely related. Most of the 60 species of eagle are from Eurasia and Africa. Outside this area, just 14 species can be found—2 in North America, 9 in Central and South America, and 3 in Australia.", "Eagle", "Assets\\Eagle.jfif" },
                    { 8, 4, 2, "Corvus is a widely distributed genus of medium-sized to large birds in the family Corvidae. It includes species commonly known as crows, ravens and rooks. The species commonly encountered in Europe are the carrion crow, the hooded crow, the common raven and the rook; those discovered later were named \"crow\" or \"raven\" chiefly on the basis of their size, crows generally being smaller. The genus name is Latin for \"crow\".", "Corvus", "Assets\\Corvus.jpg" },
                    { 9, 15, 2, "Ciconia is a genus of birds in the stork family. Six of the seven living species occur in the Old World, but the maguari stork has a South American range. In addition, fossils suggest that Ciconia storks were somewhat more common in the tropical Americas in prehistoric times.", "Ciconia", "Assets\\Ciconia.jfif" },
                    { 10, 2, 3, "The Atlantic salmon (Salmo salar) is a species of ray-finned fish in the family Salmonidae. It is the third largest of the Salmonidae, behind Siberian taimen and Pacific Chinook salmon, growing up to a meter in length. Atlantic salmon are found in the northern Atlantic Ocean and in rivers that flow into it. Most populations are anadromous, hatching in streams and rivers but moving out to sea as they grow where they mature, after which the adults seasonally move upstream again to spawn.", "Salmon", "Assets\\Salmon.jfif" },
                    { 11, 1, 3, "Tetraodontidae is a family of primarily marine and estuarine fish of the order Tetraodontiformes. The family includes many familiar species variously called pufferfish, puffers, balloonfish, blowfish, blowies, bubblefish, globefish, swellfish, toadfish, toadies, toadle, honey toads, sugar toads, and sea squab.", "Tetraodontidae", "Assets\\Tetraodontidae.jfif" },
                    { 12, 1, 3, "A seahorse (also written sea-horse and sea horse) is any of 46 species of small marine fish in the genus Hippocampus. \"Hippocampus\" comes from the Ancient Greek hippókampos (ἱππόκαμπος), itself from híppos (ἵππος) meaning \"horse\" and kámpos (κάμπος) meaning \"sea monster\" or \"sea animal\"", "Hippocampus", "Assets\\Hippocampus.jpg" },
                    { 13, 3, 3, "The whiptail stingrays are a family, the Dasyatidae, of rays in the order Myliobatiformes. They are found worldwide in tropical to temperate marine waters, and a number of species have also penetrated into fresh water in Africa, Asia, and Australia. Members of this family have flattened pectoral fin discs that range from oval to diamond-like in shape. ", "Dasyatidae", "Assets\\Dasyatidae.jpg" },
                    { 14, 11, 4, "The Pythonidae, commonly known as pythons, are a family of nonvenomous snakes found in Africa, Asia, and Australia. Among its members are some of the largest snakes in the world. Ten genera and 42 species are currently recognized.", "Python Snake", "Assets\\PythonSnake.jfif" },
                    { 15, 5, 4, "Draco volans, also commonly known as the common flying dragon, is a species of lizard in the family Agamidae. The species is endemic to Southeast Asia.", "Draco Volans", "Assets\\DracoVolans.jfif" },
                    { 16, 22, 4, "An alligator is a large reptile in the Crocodilia order in the genus Alligator of the family Alligatoridae. The two extant species are the American alligator (A. mississippiensis) and the Chinese alligator (A. sinensis). Additionally, several extinct species of alligator are known from fossil remains. Alligators first appeared during the Oligocene epoch about 37 million years ago.[", "Alligator", "Assets\\Alligator.jfif" },
                    { 17, 45, 4, "Turtles are an order of reptiles known as Testudines, characterized by a shell developed mainly from their ribs. Modern turtles are divided into two major groups, the Pleurodira (side necked turtles) and Cryptodira (hidden necked turtles), which differ in the way the head retracts. ", "Turtle", "Assets\\Turtle.jfif" },
                    { 18, 2, 5, "A frog is any member of a diverse and largely carnivorous group of short-bodied, tailless amphibians composing the order Anura (ανοὐρά, literally without tail in Ancient Greek). The oldest fossil \"proto-frog\" Triadobatrachus is known from the Early Triassic of Madagascar, but molecular clock dating suggests their split from other amphibians may extend further back to the Permian, 265 million years ago. Frogs are widely distributed, ranging from the tropics to subarctic regions, but the greatest concentration of species diversity is in tropical rainforest.", "Frog", "Assets\\Frog.jfif" },
                    { 19, 1, 5, "Salamanders are a group of amphibians typically characterized by their lizard-like appearance, with slender bodies, blunt snouts, short limbs projecting at right angles to the body, and the presence of a tail in both larvae and adults. All ten extant salamander families are grouped together under the order Urodela. Salamander diversity is highest in eastern North America, especially in the Appalachian Mountains; most species are found in the Holarctic realm, with some species present in the Neotropical realm.", "Salamander", "Assets\\Salamander.jfif" },
                    { 20, 0, 5, "Toad is a common name for certain frogs, especially of the family Bufonidae, that are characterized by dry, leathery skin, short legs, and large bumps covering the parotoid glands.", "Toad", "Assets\\Toad.jfif" },
                    { 21, 20, 6, "Medusozoa is a clade in the phylum Cnidaria, and is often considered a subphylum. It includes the classes Hydrozoa, Scyphozoa, Staurozoa and Cubozoa, and possibly the parasitic Polypodiozoa. Medusozoans are distinguished by having a medusa stage in their often complex life cycle, a medusa typically being an umbrella-shaped body with stinging tentacles around the edge.", "Medusozoa ", "Assets\\Medusozoa.jpg" },
                    { 22, 4, 6, "Crustaceans form a large, diverse arthropod taxon which includes such animals as decapods, seed shrimp, branchiopods, fish lice, krill, remipedes, isopods, barnacles, copepods, amphipods and mantis shrimp. The crustacean group can be treated as a subphylum under the clade Mandibulata. It is now well accepted that the hexapods emerged deep in the Crustacean group, with the completed group referred to as Pancrustacea.", "Crustacea", "Assets\\Crustacea.jpg" },
                    { 23, 13, 6, "Microchaetus rappi, the African giant earthworm, is a large earthworm in the Microchaetidae family, the largest of the segmented worms (commonly called earthworms). It averages about 1.4 m (4.5 ft) in length, but can reach a length of as much as 6.7 m (22 ft) and can weigh over 1.5 kg (3.3 lb).", "Microchaetus rappi", "Assets\\MicrochaetusRappi.jpg" },
                    { 24, 15, 6, "Decapodiformes is a superorder of Cephalopoda comprising all cephalopod species with ten limbs, specifically eight short arms and two long tentacles. It is hypothesized that the ancestral coleoid had five identical pairs of limbs, and that one branch of descendants evolved a modified arm pair IV to become the Decapodiformes, while another branch of descendants evolved and then eventually lost its arm pair II, becoming the Octopodiformes.", "Decapodiformes", "Assets\\Decapodiformes.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "CommentText" },
                values: new object[,]
                {
                    { 1, 1, "It is a type of predator in the canine family" },
                    { 2, 1, "The dogs' sense of smell is particularly developed" },
                    { 3, 1, "The dog is the earliest domesticated animal" },
                    { 4, 1, "Dogs' sense of hearing is much more developed than that of humans" },
                    { 5, 1, "Dogs have two-color vision" },
                    { 6, 2, "The weight of an adult domestic cat varies on average between 4-5 kilograms" },
                    { 7, 2, "The house cat is a domesticated carnivorous mammal" },
                    { 8, 3, "They weigh up to 20 kilograms" },
                    { 9, 3, "The most striking visual characteristic of this monkey is the large and prominent nose of the male" },
                    { 10, 4, "Wild males live to the age of 31 on average and to the age of 50-60 years" },
                    { 11, 4, "The weight of most species is between 60 and 200 kg" },
                    { 12, 4, "The dolphin is considered a human-friendly animal" },
                    { 13, 4, "Dolphins are not monogamous" },
                    { 14, 4, "The main enemies of the dolphins are the sharks" },
                    { 15, 5, "The common fruit fly uses for echolocation the clicking sounds of its tongue against the wall of the pharynx, and not guttural sounds." },
                    { 16, 5, "The only fruit bat found in Israel" },
                    { 17, 6, "Most of the parrot's body is dark gray in color" },
                    { 18, 6, "It is not possible to differentiate between a male and a female in appearance" },
                    { 19, 7, "The eagle eats carrion" },
                    { 20, 7, "The neck of the eagle is long, its body length is 110-114 cm" },
                    { 21, 8, "Its weight is 1.5 kg" },
                    { 22, 8, "The crows are mostly black" },
                    { 23, 9, "The hasida feeds mainly on insects" },
                    { 24, 9, "The hasida migrates to great distances" },
                    { 25, 10, "There is concern about the depletion of the salmon fish population in the Atlantic Ocean" },
                    { 26, 10, "The natural source of salmon is in the northern hemisphere only" },
                    { 27, 11, "Tetraodontidae have four teeth" },
                    { 28, 11, "Considered a delicacy in Japan" },
                    { 29, 12, "Seahorse fertilization is internal fertilization. The number of eggs in a pouch can range from 10-300 eggs." },
                    { 30, 13, "Most species are not threatened nor are they in danger of extinction" },
                    { 31, 13, "Their stinger, located at the base of the tail, is long and razor-sharp and coated with venom." },
                    { 32, 14, "The pythons range from 1 meter to 6 meters" },
                    { 33, 14, "Pythons are a family of non-venomous snakes that kill their prey by suffocating it." },
                    { 34, 15, "Grows to a length of up to 22 cm including the tail" },
                    { 35, 16, "Alligators are characterized by a wider snout than the snouts of members of the crocodile family" },
                    { 36, 16, "The average weight of an American alligator is 270 kilograms" },
                    { 37, 17, "There are about 250 species whose size ranges from 8 centimeters to 2.74 meters" },
                    { 38, 17, "Weights from a few kilograms up to 900 kilograms" },
                    { 39, 17, "Their most prominent feature is a heavy armor covering the back and belly." },
                    { 40, 18, "Characterized by a narrow waist and smooth skin" },
                    { 41, 18, "Approximately 20,000 eggs are laid in each litter" },
                    { 42, 19, "The diet of adult salamanders includes many invertebrates - insects, arthropods and worms" },
                    { 43, 20, "There are color differences between the male and the female" },
                    { 44, 20, "The hind toes have a web" },
                    { 45, 21, "These creatures are often characterized by being made of a jelly-like substance" },
                    { 46, 22, "The sand crab spends most of its time in the sea and feeds mainly on algae, plankton and the remains of small fish found on the seabed" },
                    { 47, 22, "Its body is covered with hard armor that protects it from large fish" },
                    { 48, 23, "Its length is on average about 1.4 m" },
                    { 49, 23, "and can weigh over 1.5 kg" },
                    { 50, 24, "Eventually lost his pair of arms" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
