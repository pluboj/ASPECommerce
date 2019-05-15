using System;
using System.Collections.Generic;
using System.Linq;
using ASP.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP.Data
{
    public static class DbContextExtentions
    {
        public static UserManager<AppUser> UserManager
        { get; set; }

        public static void EnsureSeeded(this Context context) 
        {
            var user = new AppUser
            {
                FirstName = "James",
                LastName = "Smith",
                UserName = "jsmith@jamesemail.com",
                Email = "jsmith@jamesemail.com",
                EmailConfirmed = true,
                LockoutEnabled = false
            };

             UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();

            AddProducts(context);
        }

        private static void AddColoursFeaturesAndStorage(Context context)
        {
            if (context.Colours.Any() == false)
            {
                var colours = new List<string>() { "Black", "White", "Gold", "Silver", "Grey", "Spacegrey", "Red", "Pink" };

                colours.ForEach(c => context.Add(new Colour
                {
                Name = c
                }));

                context.SaveChanges();
            }

            if (context.Features.Any() == false)
            {
                var features = new List<string>() { "3G", "4G", "Bluetooth", "WiFi", "Fast charge", "GPS", "NFC" };

                features.ForEach(f => context.Add(new Feature
                {
                Name = f
                }));

                context.SaveChanges();
            }

            if (context.Storage.Any() == false)
            {
                var storage = new List<int>() { 4, 8, 16, 32, 64, 128, 256 };

                storage.ForEach(s => context.Storage.Add(new Storage
                {
                Capacity = s
                }));

                context.SaveChanges();
            }
        }

        private static void AddOperatingSystemsAndBrands(Context context)
        {
            if (context.OS.Any() == false)
            {
                var os = new List<string>() { "Android", "iOS", "Windows" };

                os.ForEach(o => context.OS.Add(new OS
                {
                Name = o
                }));

                context.SaveChanges();
            }

            if (context.Brands.Any() == false)
            {
                var brands = new List<string>() { "Acme", "Globex", "Soylent", "Initech", "Umbrella" };

                brands.ForEach(b => context.Brands.Add(new Brand
                {
                Name = b
                }));

                context.SaveChanges();
            }
        }

        public static void AddProducts(Context context)
        {
            if ( context.Products.Any() == false )
            {
                var products = new List<Product>()
                {
                    new Product
                    {
                        Name = "Samsung Galaxy S8",
                        Slug = "samsung-galaxy-s8",
                        Thumbnail = "http://placehold.it/200x300",
                        ShortDescription =
                            "Samsung Galaxy S8 Android smartphone with true edge to edge display",
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.",
                        ScreenSize = 5M,
                        TalkTime = 8M,
                        StandbyTime = 36M,
                        Brand = context.Brands.Single(b => b.Name == "Acme"),
                        OS = context.OS.Single(os => os.Name == "Android"),
                        Images = new List<Image>
                        {
                            new Image { Url = "/assets/images/gallery1.jpeg" },
                            new Image { Url = "/assets/images/gallery2.jpeg" },
                            new Image { Url = "/assets/images/gallery3.jpeg" },
                            new Image { Url = "/assets/images/gallery4.jpeg" },
                            new Image { Url = "/assets/images/gallery5.jpeg" },
                            new Image { Url = "/assets/images/gallery6.jpeg" }
                        },
                        ProductFeatures = new List<ProductFeature>
                        {
                            new ProductFeature
                            {
                                Feature = context.Features.Single(f => f.Name == "GPS")
                            }
                        },
                        ProductVariants = new List<ProductVariant>
                        {
                            new ProductVariant
                            {
                                Colour = context.Colours.Single(c => c.Name == "Gold"),
                                Storage = context.Storage.Single(s => s.Capacity == 64),
                                Price = 369M
                            }
                        }
                    }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}