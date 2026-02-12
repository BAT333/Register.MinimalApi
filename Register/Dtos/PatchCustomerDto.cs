using System.ComponentModel.DataAnnotations;

namespace Register.Dtos
{
    public record PatchCustomerDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Description { get; init; }
        public DateTime CreatedDate { get; init; }

        public PatchCustomerDto(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.CreatedDate = DateTime.Now;
        }
    }
}
