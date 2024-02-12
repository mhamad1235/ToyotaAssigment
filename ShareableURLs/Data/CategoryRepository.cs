using ShareableURLs.DTOs;

namespace ShareableURLs.Data;

public class CategoryRepository
{
    public static List<CategoryDTO> FakeCategories = new List<CategoryDTO>()
    {
        new CategoryDTO { ID = 1, Name = "Phone" },
        new CategoryDTO { ID = 2, Name = "Laptop" },
        new CategoryDTO { ID = 3, Name = "Monitor" },
    };

    public CategoryRepository()
    {
        foreach (var category in FakeCategories)
        {
            category.Products = ProductRepository
                .FakeProducts
                .Where(product => product.CategoryID == category.ID)
                .ToList();
        }
    }

    public List<CategoryDTO> List()
    {
        return FakeCategories;
    }

    public CategoryDTO? Find(long id)
    {
        return FakeCategories.FirstOrDefault(x => x.ID == id);
    }
}