using System.ComponentModel.DataAnnotations;

namespace Entity;

public class CardEvent
{
    [Key]
    public Guid SessionId { get; set; }
    
    [Required(ErrorMessage = "OrderType is required")]
    public string OrderType { get; set; }

    [Required(ErrorMessage = "Card is required")]
    [RegularExpression(@"^\d{4}\*\*\d{4}$", ErrorMessage = "Card must be in the format xxxx**xxxx")]
    public string Card { get; set; }

    [Required(ErrorMessage = "EventDate is required")]
    public DateTime EventDate { get; set; }

    [Required(ErrorMessage = "WebsiteUrl is required")]
    [Url(ErrorMessage = "WebsiteUrl must be a valid URL")]
    public string WebsiteUrl { get; set; }
}