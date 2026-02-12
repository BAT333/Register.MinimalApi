using Microsoft.AspNetCore.Mvc;
using Register.Dtos;
using Register.Services;
using System.Runtime.CompilerServices;

namespace Register.Extensions
{
    public static class CustomerExtensions
    {

        public static void AddEndPointsCustomer(this WebApplication app)
        {

            var group = app.MapGroup("/customer");

            group.MapGet("/", ([FromServices] CustomerService service, [FromQuery] int skip = 0, [FromQuery] int take = 10) =>
            {
                var test = service.Get(skip, take);

                return Results.Ok(test);
            });
            group.MapGet("/{id:int}", ([FromServices] CustomerService service, int id) =>
            {
                var tes = service.GetById(id);
                if (tes != null) return Results.Ok(tes);
                return Results.NotFound();

            }).WithName("GetById");

            group.MapPost("/", ([FromServices] CustomerService service, [FromBody] CreateCustomerDTO dto) =>
            {
                var readDto = service.Post(dto);
                return Results.CreatedAtRoute("GetById", new { id = readDto.Id }, readDto);
            });


            group.MapPut("/{id:int}", ([FromServices] CustomerService service, int id, [FromBody] PutCustomerDto dto) =>
            {
                var test = service.Put(id, dto);
                if (test) return Results.NoContent();
                return Results.BadRequest();

            });
            group.MapPatch("/{id:int}", ([FromServices] CustomerService service, int id, [FromBody] PatchCustomerDto dto) =>
            {

                var test = service.Patch(id, dto);
                if (test) return Results.NoContent();
                return Results.BadRequest();

            });
            group.MapDelete("/{id:int}", ([FromServices] CustomerService service, int id) =>
            {
                var tast = service.Delete(id);

                if (tast) return Results.NoContent();

                return Results.BadRequest();

            });

        }
    }
}
