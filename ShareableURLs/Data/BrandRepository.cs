using ShareableURLs.DTOs;

namespace ShareableURLs.Data;

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
        foreach (var brand in FakeBrands)
        {
            brand.Products = ProductRepository
                .FakeProducts
                .Where(product => product.BrandID == brand.ID)
                .ToList();
        }
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