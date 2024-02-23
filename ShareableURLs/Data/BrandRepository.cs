using ShareableURLs.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ShareableURLs.Data
{
    public class BrandRepository
    {
        public static List<BrandDTO> FakeBrands = new List<BrandDTO>()
        {
            new BrandDTO { ID = 1, Name = "Apple" },
            new BrandDTO { ID = 2, Name = "Samsung" },
            new BrandDTO { ID = 3, Name = "Lenovo" },
        };

        public BrandRepository()
        {
     
            FakeBrands = (
                from brand in FakeBrands
                join product in ProductRepository.FakeProducts on brand.ID equals product.BrandID into products
                select new BrandDTO
                {
                    ID = brand.ID,
                    Name = brand.Name,
                    Products = products.ToList()
                }
            ).ToList();
        }

        public List<BrandDTO> List()
        {
            return FakeBrands;
        }

        public BrandDTO? Find(long id)
        {
            return FakeBrands.FirstOrDefault(x => x.ID == id);
        }


    }
}