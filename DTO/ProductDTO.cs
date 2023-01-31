namespace DTO
{
    public class ProductDTO
    {
            public string Name { get; set; } = null!;
            public int CategoryId { get; set; }
            public string Author { get; set; } = null!;
  
      
        public double Price { get; set; }
            public string? Description { get; set; }
            public string ImageUrl { get; set; } = null!;

        public string CategoryName { get; set; }

    }
}