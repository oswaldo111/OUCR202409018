using CRM.DTOs.ProducOUCRDTOs;
using OUCR202409018.Models.DAL;
using OUCR202409018.Models.EN;
using System.Runtime.CompilerServices;

namespace OUCR202409018.Endpoints
{
    public static class ProductEndpoint
    {
        public static void AddProductEndpoints(this WebApplication app)
        {
            app.MapPost("/product/search", async (SearchQueryProductDTO prodctDTO, ProductsOUCRDAL productDAL) =>
            {
                var Producto = new ProductsOUCR
                {
                    NombreOUCR = prodctDTO.Nombre_Like != null ? prodctDTO.Nombre_Like : string.Empty,
                };

                var productos = new List<ProductsOUCR>();
                int countrow = 0;
                if (prodctDTO.SendRowCount == 2)
                {
                    productos = await productDAL.Search(Producto, skip: prodctDTO.Skip, take: prodctDTO.Take);

                    if (productos.Count > 0)
                        countrow = await productDAL.CountSearch(Producto);
                }
                else
                {
                    productos = await productDAL.Search(Producto, skip: prodctDTO.Skip, take: prodctDTO.Take);
                }

                var productoresult = new SearchResultProductsDTO
                {
                    Data = new List<SearchResultProductsDTO.ProductoOUCRDTO>(),
                    CountRow = countrow
                };

                productos.ForEach(s =>
                {
                    productoresult.Data.Add(new SearchResultProductsDTO.ProductoOUCRDTO
                    {
                        Id = s.Id,
                        NombreOUCR = s.NombreOUCR,
                        DescripcionOUCR = s.DescripcionOUCR,
                        PrecioOUCR = s.PrecioOUCR
                    });
                });
                return productoresult;
            }); 
                
            

            app.MapGet("/product/{id}", async (int id, ProductsOUCRDAL productoDAL) =>
            {
                var producto = await productoDAL.GetById(id);

                var productoResult = new GetIdResultProductDTO
                {
                    Id = producto.Id,
                    NombreOUCR = producto.NombreOUCR,
                    DescripcionOUCR = producto.DescripcionOUCR,
                    PrecioOUCR = producto.PrecioOUCR
                };

                if (productoResult.Id > 0) { return Results.Ok(productoResult); }
                else return Results.NotFound(productoResult);
            });


            app.MapPost("/product", async (CreateProducDTO productoDTO, ProductsOUCRDAL productoDAL) =>
            {
                var producto = new ProductsOUCR
                {
                    NombreOUCR = productoDTO.NombreOUCR,
                    DescripcionOUCR = productoDTO.DescripcionoOUCR,
                    PrecioOUCR = productoDTO.PrecioOUCR
                };

                int result = await productoDAL.Create(producto);

                if(result != 0)
                    return Results.Ok(result);
                else
                {
                    return Results.StatusCode(500);
                }
            });

            app.MapPut("/product", async (EditProductDTO productoDTO, ProductsOUCRDAL productoDAL) =>
            {

                var producto = new ProductsOUCR
                {
                    Id = productoDTO.Id,
                    NombreOUCR = productoDTO.NombreOUCR,
                    DescripcionOUCR = productoDTO.DescripcionOUCR,
                    PrecioOUCR = productoDTO.PrecioOUCR
                };

                Console.WriteLine(producto.Id + "{}{}{}{}{}{}");
                int result = await productoDAL.Edit(producto);
                Console.WriteLine(result + "!!!!!!!!!!!!!");
                if (result != 0) 
                    return Results.Ok(result);
                else 
                    return Results.StatusCode(500);
            });

            app.MapDelete("/product/{id}", async (int id, ProductsOUCRDAL productoDAL) =>
            {
                int reuslt = await productoDAL.Delete(id);
                if (reuslt != 0) return Results.Ok(reuslt);
                else return Results.StatusCode(500);
            });

        }
    }
}
