namespace ShareableURLs.DTOs;

public class CategoryDTO
{
    public long ID { get; set; }
    public string Name { get; set; } = default!;
    public List<ProductDTO> Products { get; set; } = new();
}