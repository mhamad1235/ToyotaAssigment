namespace ShareableURLs.DTOs;

public class ProductDTO
{
    public long ID { get; set; }
    public string Name { get; set; } = default!;
    public long BrandID { get; set; }
    public long CategoryID { get; set; }
    public BrandDTO Brand { get; set; } = default!;
    public CategoryDTO Category { get; set; } = default!;
}