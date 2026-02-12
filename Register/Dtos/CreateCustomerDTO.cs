using System.ComponentModel.DataAnnotations;

namespace Register.Dtos
{
    public record CreateCustomerDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Description { get; init; }
        public DateTime CreatedDate { get; init; }

        public CreateCustomerDTO(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.CreatedDate = DateTime.Now;
        }

    }
}
