using ShareableURLs.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ShareableURLs.Data
{
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
           
            FakeCategories = (
                from category in FakeCategories
                join product in ProductRepository.FakeProducts on category.ID equals product.CategoryID into products
                select new CategoryDTO
                {
                    ID = category.ID,
                    Name = category.Name,
                    Products = products.ToList()
                }
            ).ToList();
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
}
