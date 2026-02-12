using Register.Context;
using Register.Dtos;
using Register.Model;
using System.Threading.Tasks;

namespace Register.Services
{
    internal class CustomerService
    {
        private readonly RegisterContext _context;

        public CustomerService(RegisterContext context)
        {
            _context = context;
        }
        internal List<ReadCustomerDto> Get(int skip, int take)
        {
            skip = Math.Max(skip, 0);
            take = Math.Clamp(take, 0, 100);
            return this._context.customers.Select(test => new ReadCustomerDto(test.Id, test.Name, test.Description, test.CreatedDate)
                ).Skip(skip).Take(take).ToList();

        }

        internal bool Delete(int id)
        {
            var tast = this._context.customers.Find(id);
            if (tast == null) return false;
            this._context.Remove(tast);
            this._context.SaveChanges();
            return true;
        }

        internal ReadCustomerDto? GetById(int id)
        {
            var tast = this._context.customers.Find(id);
            if (tast == null) return null;
            return new ReadCustomerDto(tast.Id, tast.Name, tast.Description, tast.CreatedDate);
        }

        internal ReadCustomerDto Post(CreateCustomerDTO dto)
        {
            Model.Customer test = new Model.Customer(dto.Name, dto.Description, dto.CreatedDate);
            this._context.customers.Add(test);
            this._context.SaveChanges();
            return new ReadCustomerDto(test.Id, test.Name, test.Description, test.CreatedDate);
        }

        internal bool Put(int id, PutCustomerDto dto)
        {
            var tast = this._context.customers.Find(id);

            if (tast == null) return false;

            tast = new Model.Customer(dto.Name, dto.Description, dto.CreatedDate);
            this._context.SaveChanges();

            return true;
        }

        internal bool Patch(int id, PatchCustomerDto dto)
        {
            var tast = this._context.customers.Find(id);

            if (tast == null) return false;

            tast.update(dto.Name, dto.Description, dto.CreatedDate);

            this._context.SaveChanges();

            return true;
        }
    }
}
