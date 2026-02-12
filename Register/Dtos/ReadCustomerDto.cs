using System.ComponentModel.DataAnnotations;

namespace Register.Dtos
{
    public record ReadCustomerDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime CreatedDate { get; init; }

        public ReadCustomerDto(int id, string name, string description, DateTime createdDate)
        {
            this.Id = id; 
            this.Name = name;
            this.Description = description;
            this.CreatedDate = createdDate;
        }
    }
}
