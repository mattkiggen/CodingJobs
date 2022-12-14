using System.ComponentModel.DataAnnotations;

namespace CodingJobs.Domain.Models;

public class Address
{
    public int AddressId { get; set; }

    [Required] public string Number { get; set; } = null!;

    [Required] public string Street { get; set; } = null!;

    [Required] public string City { get; set; } = null!;

    [Required] public string Province { get; set; } = null!;

    [Required] public string Country { get; set; } = "South Africa";
}