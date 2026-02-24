using Register.Context;
using Register.Dtos;


namespace Register.Services
{
    internal class CustomerService
    {
        private readonly RegisterContext _context;

        public CustomerService(RegisterContext context)
        {
            _context = context;
        }
        internal PaginationResponseDTO<ReadCustomerDto> Get(int skip, int take)
        {
            skip = Math.Max(skip, 0);
            take = Math.Clamp(take, 0, 100);
            int total = 0;
            var customers = this._context.customers.ToList();
            total = customers.Count();
            var Items  = customers.Select(customer => new ReadCustomerDto(customer.Id, customer.Name, customer.Description, customer.CreatedDate)
                ).Skip(skip).Take(take).ToList();

            return new PaginationResponseDTO<ReadCustomerDto>(total, Items);
        }

        internal bool Delete(int id)
        {
            var customer = this._context.customers.Find(id);
            if (customer == null) return false;
            this._context.Remove(customer);
            this._context.SaveChanges();
            return true;
        }

        internal ReadCustomerDto? GetById(int id)
        {
            var customer = this._context.customers.Find(id);
            if (customer == null) return null;
            return new ReadCustomerDto(customer.Id, customer.Name, customer.Description, customer.CreatedDate);
        }

        internal ReadCustomerDto Post(CreateCustomerDTO dto)
        {
            Model.Customer customer = new Model.Customer(dto.Name, dto.Description, dto.CreatedDate);
            this._context.customers.Add(customer);
            this._context.SaveChanges();
            return new ReadCustomerDto(customer.Id, customer.Name, customer.Description, customer.CreatedDate);
        }

        internal bool Put(int id, PutCustomerDto dto)
        {
            var customer = this._context.customers.Find(id);

            if (customer == null) return false;

            customer = new Model.Customer(dto.Name, dto.Description, dto.CreatedDate);
            this._context.SaveChanges();

            return true;
        }

        internal bool Patch(int id, PatchCustomerDto dto)
        {
            var customer = this._context.customers.Find(id);

            if (customer == null) return false;

            customer.update(dto.Name, dto.Description, dto.CreatedDate);

            this._context.SaveChanges();

            return true;
        }
    }
}
