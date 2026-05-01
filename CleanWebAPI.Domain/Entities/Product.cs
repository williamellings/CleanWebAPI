namespace CleanWebAPI.Domain.Entities;

public class Product
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public decimal Price { get; set; }

	// Foreign Key: Koppling till kategorin
	public Guid CategoryId { get; set; }
	public virtual Category Category { get; set; } = null!;
}