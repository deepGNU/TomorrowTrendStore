using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AverageRating", "ImageURL", "IsFeatured", "LongDescription", "Name", "NumberOfRatings", "Price", "ProductCategoryId", "ShortDescription", "Stock" },
                values: new object[,]
                {
                    { 1, 4m, "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTp2qPay-quantum-smartphone.png", true, "The Quantum X Smartphone isn't just a step ahead in mobile technology; it's a leap into the future. Integrated with groundbreaking quantum computing capabilities, this phone offers unparalleled processing speeds, making every task from web browsing to complex computations startlingly fast. The quantum processor is not only efficient but also significantly enhances the device's security, leveraging quantum encryption to protect your data like never before. The sleek, ultramodern design is complemented by an advanced AI assistant that learns and adapts to your preferences, ensuring a personalized experience. With an extended battery life that defies expectations and a camera system utilizing quantum algorithms for perfect shots, the Quantum X Smartphone redefines the boundaries of what a smartphone can do.", "Quantum X Smartphone", 1, 799.99m, 2, "Experience the power of quantum computing in your pocket!", 100 },
                    { 2, 5m, "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTgfbD9J-retro-flip-phone.png", true, "The Retro Flip Phone combines the nostalgic charm of the classic flip phone design with the cutting-edge technology of today. This device is a stylish nod to the past, featuring a tactile flipping mechanism that is satisfying to use. The exterior displays a sleek, retro-inspired look, while the interior boasts a modern touchscreen interface alongside traditional keypad options. The Retro Flip Phone caters to those who seek simplicity without sacrificing modern functionalities such as high-quality cameras, fast 4G LTE connectivity, and access to all your favorite apps. It's the perfect blend of old-school cool and contemporary tech, designed for users who appreciate simplicity and style.", "Retro Flip Phone", 1, 299.99m, 2, "A blast from the past with modern features and a flip design!", 50 },
                    { 3, 0m, "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTn6fy2p-fusionbook-pro.png", true, "The FusionBook Pro is the ultimate laptop for those who demand versatility without compromise. It expertly blends powerful performance with an elegant design, making it ideal for both professional and personal use. The laptop features a high-performance processor and advanced graphics card, handling demanding software applications and high-end gaming with ease. Its innovative design includes a high-resolution, edge-to-edge display that offers stunning visuals, whether you're working on a presentation or watching your favorite movie. The FusionBook Pro also includes enhanced audio capabilities for an immersive experience and a battery that lasts all day, ensuring that work and play can continue uninterrupted.", "FusionBook Pro", 0, 1499.99m, 3, "The laptop that fuses work and play seamlessly.", 75 },
                    { 4, 4m, "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTm1zM9j-stealth-ninja-laptop.png", true, "The Stealth Ninja Laptop is the epitome of discretion and performance. Designed specifically for users who require both privacy and speed, this laptop features a unique, ultra-quiet keyboard that allows for silent typing, perfect for working in quiet environments or during covert operations. Its matte black finish and compact design make it inconspicuous and easy to carry. Underneath its stealthy exterior lies a powerful processor and ample memory, providing lightning-fast speeds and seamless multitasking capabilities. Enhanced security features, including biometric authentication and robust encryption, protect sensitive information, making the Stealth Ninja Laptop a top choice for professionals in security-sensitive fields.", "Stealth Ninja Laptop", 1, 1999.99m, 3, "Designed for covert operations with silent keystrokes and ninja speed.", 30 },
                    { 5, 0m, "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTjZbRGL-zephyr-earbuds.png", false, "The Zephyr Wireless Earbuds redefine the listening experience with their feather-light design and exceptional sound quality. These earbuds are so light and comfortable that you might forget you're wearing them, but their sound performance will quickly remind you. They offer crystal-clear audio with deep bass and rich treble, immersing you in your music like never before. The earbuds feature cutting-edge wireless technology, ensuring a stable connection without the hassle of cords. With an intuitive touch interface, you can control your music, take calls, and access your voice assistant with ease. The Zephyr Wireless Earbuds also boast a long-lasting battery life, and their sleek, ergonomic design ensures they stay securely in place, whether you're relaxing at home or on the move.", "Zephyr Wireless Earbuds", 0, 89.99m, 5, "Earbuds so light they might just make you float!", 200 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
