using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using OUCR202409018.Models.EN;

namespace OUCR202409018.Models.DAL
{
    public class ProductsOUCRDAL
    {
        readonly CRMContext _context;

        public ProductsOUCRDAL(CRMContext cRMContext)
        {
            _context = cRMContext;
        }

        public async Task<int>  Create(ProductsOUCR productsOUCR)
        {
            _context.Add(productsOUCR);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductsOUCR> GetById(int id)
        {
            var producto = await _context.ProductsOUCR.FirstOrDefaultAsync(s => s.Id == id);
            return producto != null ? producto: new ProductsOUCR();
        }

        public async Task<int> Edit(ProductsOUCR productsOUCR)
        {
            int result = 0;

            var productoUpdate = await GetById(productsOUCR.Id);
            if (productoUpdate.Id != 0) 
            {
               
                productoUpdate.NombreOUCR = productsOUCR.NombreOUCR;
                productoUpdate.DescripcionOUCR = productsOUCR.DescripcionOUCR;
                productoUpdate.PrecioOUCR = productsOUCR.PrecioOUCR;
                result = await _context.SaveChangesAsync();
            }
            
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var productoDelete = await GetById(id);

            if (productoDelete.Id > 0 )
            {
                _context.ProductsOUCR.Remove(productoDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        private IQueryable<ProductsOUCR> Query(ProductsOUCR products)
        {
            var query = _context.ProductsOUCR.AsQueryable();   
            if(!string.IsNullOrWhiteSpace(products.NombreOUCR))
                query = query.Where(s => s.NombreOUCR.Contains(products.NombreOUCR));

            return query;
        }

        public async Task<int> CountSearch(ProductsOUCR products)
        {
            return await Query(products).CountAsync();
        }

        public async Task<List<ProductsOUCR>> Search(ProductsOUCR products, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(products);
            query = query.OrderByDescending(s=> s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
