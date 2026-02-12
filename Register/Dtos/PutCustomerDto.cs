using System.ComponentModel.DataAnnotations;

namespace Register.Dtos
{
    public record PutCustomerDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Description { get; init; }
        [Required]
        public DateTime CreatedDate { get; init; }

        public PutCustomerDto(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.CreatedDate = DateTime.Now;
        }
    }
}
