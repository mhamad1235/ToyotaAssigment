using ShareableURLs.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ShareableURLs.Data
{
    public class ProductRepository
    {
        public static List<ProductDTO> FakeProducts = new List<ProductDTO>()
        {
            new ProductDTO { ID = 1, Name = "iPhone 15 Pro Max", BrandID = 1, CategoryID = 1 },
            new ProductDTO { ID = 2, Name = "iPhone 13", BrandID = 1, CategoryID = 1 },
            new ProductDTO { ID = 3, Name = "Samsung Galaxy S22", BrandID = 2, CategoryID = 1 },
            new ProductDTO { ID = 4, Name = "Samsung Galaxy Note", BrandID = 2, CategoryID = 1 },
            new ProductDTO { ID = 5, Name = "Lenovo K10 Note", BrandID = 3, CategoryID = 1 },
            new ProductDTO { ID = 6, Name = "Lenovo A6 Note", BrandID = 3, CategoryID = 1 },

            new ProductDTO { ID = 7, Name = "Apple Macbook Pro", BrandID = 1, CategoryID = 2 },
            new ProductDTO { ID = 8, Name = "Apple Mac Air", BrandID = 1, CategoryID = 2 },
            new ProductDTO { ID = 9, Name = "Samsung Galaxy Book3 360 13.3", BrandID = 2, CategoryID = 2 },
            new ProductDTO { ID = 10, Name = "Samsung Galaxy Book3 Pro 360", BrandID = 2, CategoryID = 2 },
            new ProductDTO { ID = 11, Name = "Lenovo Legion Pro 7i Gen 8", BrandID = 3, CategoryID = 2 },
            new ProductDTO { ID = 12, Name = "Lenovo ThinkPad E14 Gen 4", BrandID = 3, CategoryID = 2 },

            new ProductDTO { ID = 13, Name = "Apple Pro Display XDR", BrandID = 1, CategoryID = 3 },
            new ProductDTO { ID = 14, Name = "Apple Studio Display", BrandID = 1, CategoryID = 3 },
            new ProductDTO { ID = 15, Name = "Samsung 27\" ViewFinity S80UA 4K UHD IPS HDR10 Monitor with USB-C, Speakers and Ergonomic Stand", BrandID = 2, CategoryID = 3 },
            new ProductDTO { ID = 16, Name = "Samsung 27\" Odyssey G55C QHD 165Hz 1ms(MPRT) Curved Gaming Monitor", BrandID = 2, CategoryID = 3 },
            new ProductDTO { ID = 17, Name = "Lenovo ThinkVision 14 inch Portable Monitor - M14", BrandID = 3, CategoryID = 3 },
            new ProductDTO { ID = 18, Name = "Lenovo 23.8 inch Gaming Monitor - G24e-20", BrandID = 3, CategoryID = 3 },
        };

        public ProductRepository()
        {
            // Join FakeProducts with FakeBrands and FakeCategories based on BrandID and CategoryID
            FakeProducts = (
                from product in FakeProducts
                join brand in BrandRepository.FakeBrands on product.BrandID equals brand.ID
                join category in CategoryRepository.FakeCategories on product.CategoryID equals category.ID
                select new ProductDTO
                {
                    ID = product.ID,
                    Name = product.Name,
                    BrandID = product.BrandID,
                    CategoryID = product.CategoryID,
                    Brand = brand,
                    Category = category
                }
            ).ToList();
        }

        public List<ProductDTO> List()
        {
            return FakeProducts;
        }

        public ProductDTO? Find(long id)
        {
            return FakeProducts.FirstOrDefault(x => x.ID == id);
        }
    }
}
