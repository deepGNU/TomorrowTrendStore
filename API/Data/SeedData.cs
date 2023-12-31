using API.Models.Enums;
using API.Models;
using API.Services;

namespace API.Data
{
    public class SeedData
    {
        static readonly Random random = new();

        // Creates and returns nine users. Use these to login!
        public static List<User> GetUsers()
        {
            List<User> users = new()
            {
                // Creating three Admin users.
                new User
                {
                    Id = 1,
                    Type = UserType.Admin,
                    Username = "AdaCoder",
                    FirstName = "Ada",
                    LastName = "Lovelace",
                    Email = "ada@example.com",
                    PhoneNumber = "888888888",
                    PasswordHash = PasswordHashingService.HashPassword("admin1"),
                    ProfileImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvUBANt6N-ada-lovelace-coding.png",
                },

                new User
                {
                    Id = 2,
                    Type = UserType.Admin,
                    Username = "AnalyticalAlan",
                    FirstName = "Alan",
                    LastName = "Turing",
                    Email = "alan@example.com",
                    PhoneNumber = "999999999",
                    PasswordHash = PasswordHashingService.HashPassword("admin2"),
                    ProfileImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvU3Sp34D-alan-turing-doing-math.png",
                },

                new User
                {
                    Id = 3,
                    Type = UserType.Admin,
                    Username = "BabbageEngineer",
                    FirstName = "Charles",
                    LastName = "Babbage",
                    Email = "charles@example.com",
                    PhoneNumber = "777777777",
                    PasswordHash = PasswordHashingService.HashPassword("admin3"),
                    ProfileImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTzyWF9X-charles-babbage%20building-analytical-engine.png",
                }
            };

            for (int i = 1; i <= 3; i++)
            {
                users.Add(new User
                {
                    Id = 3 + i,
                    Type = UserType.Worker,
                    Username = $"worker{i}",
                    FirstName = $"Worker{i}",
                    LastName = $"LastName{i}",
                    Email = $"worker{i}@example.com",
                    PhoneNumber = $"9876543{i}",
                    PasswordHash = PasswordHashingService.HashPassword($"worker{i}"),
                    ProfileImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTy4qQ8x-865056_electronic%20store%20worker%20_xl-1024-v1-0.png",
                });
            }

            // Creating and adding three Customer users.
            for (int i = 1; i <= 3; i++)
            {
                users.Add(new User
                {
                    Id = 6 + i,
                    Type = UserType.Customer,
                    Username = $"customer{i}",
                    FirstName = $"Customer{i}",
                    LastName = $"LastName{i}",
                    Email = $"customer{i}@example.com",
                    PhoneNumber = $"1234567{i}",
                    PasswordHash = PasswordHashingService.HashPassword($"customer{i}"),
                    ProfileImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTtNgM2b-773905_guy%20with%20sunglasses%20_xl-1024-v1-0.png",
                });
            }

            return users;
        }

        public static List<ProductCategory> GetProductCategories()
        {
            List<ProductCategory> categories = new()
            {
                new ProductCategory { Id = 1, Name = "Computers", ParentCategoryId = null },
                new ProductCategory { Id = 2, Name = "Smartphones", ParentCategoryId = null },
                new ProductCategory { Id = 3, Name = "Laptops", ParentCategoryId = 1 },
                new ProductCategory { Id = 4, Name = "Desktops", ParentCategoryId = 1 },
                new ProductCategory { Id = 5, Name = "Accessories", ParentCategoryId = null }
            };

            return categories;
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductCategoryId = 2, // Smartphones
                    Name = "Quantum X Smartphone",
                    ShortDescription = "Experience the power of quantum computing in your pocket!",
                    LongDescription = "The Quantum X Smartphone isn't just a step ahead in mobile technology; it's a leap into the future. Integrated with groundbreaking quantum computing capabilities, this phone offers unparalleled processing speeds, making every task from web browsing to complex computations startlingly fast. The quantum processor is not only efficient but also significantly enhances the device's security, leveraging quantum encryption to protect your data like never before. The sleek, ultramodern design is complemented by an advanced AI assistant that learns and adapts to your preferences, ensuring a personalized experience. With an extended battery life that defies expectations and a camera system utilizing quantum algorithms for perfect shots, the Quantum X Smartphone redefines the boundaries of what a smartphone can do.",
                    Stock = 100,
                    Price = 799.99M,
                    AverageRating = 4M,
                    IsFeatured = true,
                    NumberOfRatings = 1,
                    ImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTp2qPay-quantum-smartphone.png"
                },

                new Product
                {
                    Id = 2,
                    ProductCategoryId = 2, // Smartphones
                    Name = "Retro Flip Phone",
                    ShortDescription = "A blast from the past with modern features and a flip design!",
                    LongDescription = "The Retro Flip Phone combines the nostalgic charm of the classic flip phone design with the cutting-edge technology of today. This device is a stylish nod to the past, featuring a tactile flipping mechanism that is satisfying to use. The exterior displays a sleek, retro-inspired look, while the interior boasts a modern touchscreen interface alongside traditional keypad options. The Retro Flip Phone caters to those who seek simplicity without sacrificing modern functionalities such as high-quality cameras, fast 4G LTE connectivity, and access to all your favorite apps. It's the perfect blend of old-school cool and contemporary tech, designed for users who appreciate simplicity and style.",
                    Stock = 50,
                    Price = 299.99M,
                    AverageRating = 5M,
                    IsFeatured = true,
                    NumberOfRatings = 1,
                    ImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTgfbD9J-retro-flip-phone.png"
                },

                new Product
                {
                    Id = 3,
                    ProductCategoryId = 3, // Laptops
                    Name = "FusionBook Pro",
                    ShortDescription = "The laptop that fuses work and play seamlessly.",
                    LongDescription = "The FusionBook Pro is the ultimate laptop for those who demand versatility without compromise. It expertly blends powerful performance with an elegant design, making it ideal for both professional and personal use. The laptop features a high-performance processor and advanced graphics card, handling demanding software applications and high-end gaming with ease. Its innovative design includes a high-resolution, edge-to-edge display that offers stunning visuals, whether you're working on a presentation or watching your favorite movie. The FusionBook Pro also includes enhanced audio capabilities for an immersive experience and a battery that lasts all day, ensuring that work and play can continue uninterrupted.",
                    Stock = 75,
                    Price = 1499.99M,
                    AverageRating = 0M,
                    IsFeatured = true,
                    NumberOfRatings = 0,
                    ImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTn6fy2p-fusionbook-pro.png"
                },

                new Product
                {
                    Id = 4,
                    ProductCategoryId = 3, // Laptops
                    Name = "Stealth Ninja Laptop",
                    ShortDescription = "Designed for covert operations with silent keystrokes and ninja speed.",
                    LongDescription = "The Stealth Ninja Laptop is the epitome of discretion and performance. Designed specifically for users who require both privacy and speed, this laptop features a unique, ultra-quiet keyboard that allows for silent typing, perfect for working in quiet environments or during covert operations. Its matte black finish and compact design make it inconspicuous and easy to carry. Underneath its stealthy exterior lies a powerful processor and ample memory, providing lightning-fast speeds and seamless multitasking capabilities. Enhanced security features, including biometric authentication and robust encryption, protect sensitive information, making the Stealth Ninja Laptop a top choice for professionals in security-sensitive fields.",
                    Stock = 30,
                    Price = 1999.99M,
                    AverageRating = 4M,
                    IsFeatured = true,
                    NumberOfRatings = 1,
                    ImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTm1zM9j-stealth-ninja-laptop.png"
                },

                new Product
                {
                    Id = 5,
                    ProductCategoryId = 5, // Accessories
                    Name = "Zephyr Wireless Earbuds",
                    ShortDescription = "Earbuds so light they might just make you float!",
                    LongDescription = "The Zephyr Wireless Earbuds redefine the listening experience with their feather-light design and exceptional sound quality. These earbuds are so light and comfortable that you might forget you're wearing them, but their sound performance will quickly remind you. They offer crystal-clear audio with deep bass and rich treble, immersing you in your music like never before. The earbuds feature cutting-edge wireless technology, ensuring a stable connection without the hassle of cords. With an intuitive touch interface, you can control your music, take calls, and access your voice assistant with ease. The Zephyr Wireless Earbuds also boast a long-lasting battery life, and their sleek, ergonomic design ensures they stay securely in place, whether you're relaxing at home or on the move.",
                    Stock = 200,
                    Price = 89.99M,
                    AverageRating = 0M,
                    IsFeatured = false,
                    NumberOfRatings = 0,
                    ImageURL = "https://upcdn.io/W142iFr/raw/uploads/2023/12/31/4kvTjZbRGL-zephyr-earbuds.png"
                }
            };
        }

        public static List<OrderLine> GetOrderLines()
        {
            List<OrderLine> orderLines = new()
            {
                new OrderLine
                {
                    Id = 1,
                    ShopOrderId = 1,
                    ProductId = 1,
                    Quantity = 1,
                    Price = 799.99M
                },

                new OrderLine
                {
                    Id = 2,
                    ShopOrderId = 2,
                    ProductId = 2,
                    Quantity = 1,
                    Price = 299.99M
                },

                new OrderLine
                {
                    Id = 3,
                    ShopOrderId = 3,
                    ProductId = 4,
                    Quantity = 1,
                    Price = 1999.99M
                }
            };

            return orderLines;
        }

        public static List<ShopOrder> GetShopOrders()
        {
            List<ShopOrder> shopOrders = new()
            {
                new ShopOrder
                {
                    Id = 1,
                    UserId = 7,
                    Status = Status.Delivered.ToString(),
                    OrderDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                    TotalPrice = 799.99M
                },

                new ShopOrder
                {
                    Id = 2,
                    UserId = 8,
                    Status = Status.Delivered.ToString(),
                    OrderDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                    TotalPrice = 299.99M
                },

                new ShopOrder
                {
                    Id = 3,
                    UserId = 9,
                    Status = Status.Delivered.ToString(),
                    OrderDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                    TotalPrice = 1999.99M
                }
            };

            return shopOrders;
        }

        public static List<UserAddress> GetUserAddresses()
        {
            List<UserAddress> userAddresses = new()
            {
                new UserAddress
                {
                    Id = 1,
                    UserId = 1,
                    AddressLine = "123 Computing Street",
                    City = "London",
                    PostalCode = "SW1A 1AA",
                    Country = CountryCode.UnitedKingdom
                },

                new UserAddress
                {
                    Id = 2,
                    UserId = 2,
                    AddressLine = "456 Code Avenue",
                    City = "Cambridge",
                    PostalCode = "CB2 1TN",
                    Country = CountryCode.UnitedKingdom
                },

                new UserAddress
                {
                    Id = 3,
                    UserId = 3,
                    AddressLine = "789 Analytical Drive",
                    City = "London",
                    PostalCode = "WC2B 6JR",
                    Country = CountryCode.UnitedKingdom
                },

                new UserAddress
                {
                    Id = 4,
                    UserId = 4,
                    AddressLine = "321 Rue de Paris",
                    City = "Paris",
                    PostalCode = "75001",
                    Country = CountryCode.France
                },

                new UserAddress
                {
                    Id = 5,
                    UserId = 5,
                    AddressLine = "123 Hauptstraße",
                    City = "Berlin",
                    PostalCode = "10115",
                    Country = CountryCode.Germany
                },

                new UserAddress
                {
                    Id = 6,
                    UserId = 6,
                    AddressLine = "789 Tech Street",
                    City = "New York",
                    PostalCode = "10001",
                    Country = CountryCode.UnitedStates
                },

                new UserAddress
                {
                    Id = 7,
                    UserId = 7,
                    AddressLine = "456 Sydney Road",
                    City = "Sydney",
                    PostalCode = "2000",
                    Country = CountryCode.Australia
                },

                new UserAddress
                {
                    Id = 8,
                    UserId = 8,
                    AddressLine = "987 Maple Lane",
                    City = "Toronto",
                    PostalCode = "M5J 2N8",
                    Country = CountryCode.Canada
                },

                new UserAddress
                {
                    Id = 9,
                    UserId = 9,
                    AddressLine = "654 Britannia Street",
                    City = "London",
                    PostalCode = "WC1X 9JP",
                    Country = CountryCode.UnitedKingdom
                }
            };

            return userAddresses;
        }

        public static List<UserReview> GetUserReviews()
        {
            List<UserReview> userReviews = new()
            {
                new UserReview
                {
                    Id = 1,
                    UserId = 7,
                    ProductId = 1,
                    Rating = 4,
                    Comment = "The Quantum X Smartphone is impressive, especially the quantum computing capabilities!"
                },

                new UserReview
                {
                    Id = 2,
                    UserId = 8,
                    ProductId = 2,
                    Rating = 5,
                    Comment = "I love the Retro Flip Phone. It combines nostalgia with modern features!"
                },

                new UserReview
                {
                    Id = 3,
                    UserId = 9,
                    ProductId = 4,
                    Rating = 4,
                    Comment = "The Stealth Ninja Laptop lives up to its name. It's fast and silent!"
                }
            };

            return userReviews;
        }
    }
}
