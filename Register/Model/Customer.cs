using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Register.Model
{
    public class Customer
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public Customer()
        {
        }

        public Customer(int id, string name, string description, DateTime createdDate)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.CreatedDate = createdDate;
        }
        public Customer(string name, string description, DateTime createdDate)
        {
            this.Name = name;
            this.Description = description;
            this.CreatedDate = createdDate;
        }

        public void update(string name, string description, DateTime createdDate)
        {
            if (!name.IsNullOrEmpty()) this.Name = name;
            if (!description.IsNullOrEmpty()) this.Description = description;
            if (createdDate != default(DateTime)) this.CreatedDate = createdDate;
        }
    }
}
