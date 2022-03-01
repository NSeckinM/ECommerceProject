using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync() || await dbContext.Brands.AnyAsync() || await dbContext.Products.AnyAsync() || await dbContext.Pictures.AnyAsync()) return;

            Category cat1 = new Category() { CategoryName = "Telefon" };
            Category cat2 = new Category() { CategoryName = "Bilgisayar,Tablet" };
            Category cat3 = new Category() { CategoryName = "Ev Elektroniği" };
            Category cat4 = new Category() { CategoryName = "Bilgisayar Parçaları" };
            Category cat5 = new Category() { CategoryName = "Foto,Kamera" };
            Category cat6 = new Category() { CategoryName = "Mutfak Aletleri" };

            dbContext.AddRange(cat1, cat2, cat3, cat4, cat5, cat6);

            Brand brand1 = new Brand() { BrandName = "Samsung" };
            Brand brand2 = new Brand() { BrandName = "Apple" };
            Brand brand3 = new Brand() { BrandName = "Fujifilm" };
            Brand brand4 = new Brand() { BrandName = "Fakir" };
            Brand brand5 = new Brand() { BrandName = "LG" };
            Brand brand6 = new Brand() { BrandName = "Xiaomi" };
            Brand brand7 = new Brand() { BrandName = "Asus" };

            dbContext.AddRange(brand1, brand2, brand3, brand4, brand5, brand6, brand7);

            Product p1 = new() { ProductName = "İphone Pro 13 Max", Description = "256 Gb Akıllı Telefon Mavi", Price = 16000.00m, Category = cat1, Brand = brand2 };
            Product p2 = new() { ProductName = "Xiaomi Poco X3 Pro", Description = "256 Gb Akıllı Telefon Siyah", Price = 5749.00m, Category = cat1, Brand = brand6 };
            Product p3 = new() { ProductName = "Asus Zenbook Pro Duo", Description = "Oled 11.Nesil Core i7 11800H-16Gb-1Tb-15.6", Price = 55992.00m, Category = cat2, Brand = brand7 };
            Product p4 = new() { ProductName = "Samsung Notebook 9 Pro", Description = "1.Nesil Core i5 1135G7-8Gb-512Gb Ssd-14", Price = 15000.00m, Category = cat2, Brand = brand1 };
            Product p5 = new() { ProductName = "AU7100 UHD 4K Smart TV", Description = "Geniş renk skalası,Hd görünüm", Price = 15800.00m, Category = cat3, Brand = brand1 };
            Product p6 = new() { ProductName = "Xiaomi Mi Robot Vacuum Mop Pro ", Description = "Siyah Akıllı Robot Süpürge", Price = 4357.00m, Category = cat3, Brand = brand6 };
            Product p7 = new() { ProductName = "Samsung 860 EVO 2.5 SSd", Description = "Solid State Disk 500GB", Price = 1500.00m, Category = cat4, Brand = brand1 };
            Product p8 = new() { ProductName = "Xiaomi Mi Mouse", Description = "Wireless Mouse Gen 2", Price = 200.00m, Category = cat4, Brand = brand6 };
            Product p9 = new() { ProductName = "Fujifilm Instax Mini 9", Description = "Fotoğraf Makinası", Price = 16000.00m, Category = cat5, Brand = brand3 };
            Product p10 = new() { ProductName = "Fakir Mr.Chef Quadro ", Description = "1000 W Blender Seti", Price = 300.00m, Category = cat6, Brand = brand4 };
            Product p11 = new() { ProductName = "LG GC-Q22FTQKL InstaView ", Description = "Gardırop Tipi Buzdolabı", Price = 28120.00m, Category = cat6, Brand = brand5 };

            dbContext.AddRange(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11);

           Picture pic1 = new() { PictureUri = "AppleTel1.jpg", Product = p1 };
            Picture pic2 = new() { PictureUri = "AppleTel2.jfif", Product = p1 };
            Picture pic3 = new() { PictureUri = "AppleTel3.jfif", Product = p1 };
            Picture pic4 = new() { PictureUri = "XiaomiTel1.jpg", Product = p2 };
            Picture pic5 = new() { PictureUri = "XiaomiTel2.jpg", Product = p2 };
            Picture pic6 = new() { PictureUri = "XiaomiTel3.png", Product = p2 };
            Picture pic7 = new() { PictureUri = "AsusPc1.jpg", Product = p3 };
            Picture pic8 = new() { PictureUri = "AsusPc2.jpg", Product = p3 };
            Picture pic9 = new() { PictureUri = "AsusPc3.jpg", Product = p3 };
            Picture pic10 = new() { PictureUri = "AsusPc4.jpg", Product = p3 };
            Picture pic11 = new() { PictureUri = "SamsungPc1.jpeg", Product = p4 };
            Picture pic12 = new() { PictureUri = "SamsungPc2.jfif", Product = p4 };
            Picture pic13 = new() { PictureUri = "SamsungPc3.jpg", Product = p4 };
            Picture pic14 = new() { PictureUri = "SamsungTv1.webp", Product = p5 };
            Picture pic15 = new() { PictureUri = "SamsungTv2.webp", Product = p5 };
            Picture pic16 = new() { PictureUri = "XiaomiMop1.jpg", Product = p6 };
            Picture pic17 = new() { PictureUri = "XiaomiMop2.jpg", Product = p6 };
            Picture pic18 = new() { PictureUri = "XiaomiMop3.webp", Product = p6 };
            Picture pic19 = new() { PictureUri = "ssd1.jpg", Product = p7 };
            Picture pic20 = new() { PictureUri = "ssd2.jpg", Product = p7 };
            Picture pic21 = new() { PictureUri = "MiMouse1.jpg", Product = p8 };
            Picture pic22 = new() { PictureUri = "MiMouse2.jpg", Product = p8 };
            Picture pic23 = new() { PictureUri = "MiMouse3.png", Product = p8 };
            Picture pic24 = new() { PictureUri = "InstaFoto1.jpg", Product = p9 };
            Picture pic25 = new() { PictureUri = "InstaFoto2.jpg", Product = p9 };
            Picture pic26 = new() { PictureUri = "InstaFoto3.jpg", Product = p9 };
            Picture pic27 = new() { PictureUri = "Fakir1.jpg", Product = p10 };
            Picture pic28 = new() { PictureUri = "fakir2.jpg", Product = p10 };
            Picture pic29 = new() { PictureUri = "LgDolap1.jpg", Product = p11 };
            Picture pic30 = new() { PictureUri = "LgDolap2.jpg", Product = p11 };
            Picture pic31 = new() { PictureUri = "LgDolap3.jpg", Product = p11 };

            dbContext.AddRange(pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, pic11, pic12, pic13, pic14, pic15, pic16, pic17, pic18, pic19, pic20, pic21, pic22, pic23, pic24, pic25, pic26, pic27, pic28, pic29, pic30, pic31);

            await dbContext.SaveChangesAsync();



        }
    }
}
