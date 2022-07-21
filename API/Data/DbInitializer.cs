using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});
            }
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Amazon Fire",
                    Description =
                        "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
                    Price = 2985,
                    PictureUrl = "/images/products/Amazon Fire.jpg",
                    Brand = "Amazon",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Lenovo IdeaPad Miix 700",
                    Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.",
                    Price = 12999,
                    PictureUrl = "/images/products/Lenovo IdeaPad Miix 700.jpg",
                    Brand = "Lenovo",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Amazon Fire HD 8",
                    Description =
                        "Amazon's latest Fire HD 8 tablet is a great value for media consumption.",
                    Price = 4950,
                    PictureUrl = "/images/products/Amazon Fire HD 8.jpg",
                    Brand = "Amazon",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPhone 12 Pro Max",
                    Description =
                        "The iPhone 12 is a new iPhone model developed by Apple Inc. It is part of a device family that was announced during a special event on October 13, 2020 to succeed the iPhone 11 line.",
                    Price = 129900,
                    PictureUrl = "/images/products/Apple iPhone 12 Pro Max.jpg",
                    Brand = "Apple",
                    Type = "Phone",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Xiaomi Redmi Note 9 Pro",
                    Description =
                        "Dual SIM, 128GB, 6GB RAM, 4G, Tropical Green",
                    Price = 12999,
                    PictureUrl = "/images/products/Xiaomi Redmi Note 9 Pro.jpg",
                    Brand = "Xiaomi",
                    Type = "Phone",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Lenovo Tab P11 Plus",
                    Description =
                        "Octa-Core, 11 inches 2K IPS, 6GB RAM, 128GB, WiFi, Slate Grey",
                    Price = 25999,
                    PictureUrl = "/images/products/Lenovo Tab P11 Plus.jpg",
                    Brand = "Lenovo",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Samsung Galaxy S21",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 82000,
                    PictureUrl = "/images/products/Samsung Galaxy S21.jpg",
                    Brand = "Samsung",
                    Type = "Phone",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPhone 13 Pro",
                    Description =
                        "128GB, 5G, Graphite",
                    Price = 126900,
                    PictureUrl = "/images/products/Apple iPhone 13 Pro.jpg",
                    Brand = "Apple",
                    Type = "Phone",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Xiaomi Pad 5",
                    Description =
                        "Octa-Core, 11 inches, 6GB RAM, 128GB, Wi-Fi, Cosmic Gray",
                    Price = 26999,
                    PictureUrl = "/images/products/Xiaomi Pad 5.jpg",
                    Brand = "Xiaomi",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Motorola G60s",
                    Description =
                        "Dual SIM, 128GB, 6GB RAM, Blue",
                    Price = 15999,
                    PictureUrl = "/images/products/Motorola G60s.jpg",
                    Brand = "Motorola",
                    Type = "Phone",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Samsung Galaxy Tab A7",
                    Description =
                        "Octa-Core, 10.4 inches, 3GB RAM, 32GB, 4G, Gray",
                    Price = 38777,
                    PictureUrl = "/images/products/Samsung Galaxy Tab A7.jpg",
                    Brand = "Samsung",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPad 8 (2020)",
                    Description =
                        "10.2 inches, 32GB, Wi-Fi, Space Grey",
                    Price = 30900,
                    PictureUrl = "/images/products/Apple iPad 8 (2020).jpg",
                    Brand = "Apple",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}