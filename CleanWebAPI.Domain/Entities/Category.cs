namespace CleanWebAPI.Domain.Entities;

public class Category
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;

	// Relation: En kategori har en lista med produkter
	public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}