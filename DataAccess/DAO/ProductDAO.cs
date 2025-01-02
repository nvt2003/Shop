

using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        private readonly ShopDBContext _context;
        private readonly IMapper _mapper;
        public ProductDAO(ShopDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProductBasicViewModel> GetProducts(int page, int pageSize)
        {
            var products = _context.Products
                .Where(p=>p.DeletedAt==null)
                .Skip(page*pageSize).Take(pageSize).ToList();
            var productBsVws = _mapper.Map<List<ProductBasicViewModel>>(products);
            return productBsVws;
        }
        public ProductViewModel GetProductById(int id)
        {
            var product = _context.Products.AsNoTracking()
                .Include(p=>p.Category)
                .Include(p=>p.Inventory)
                .Include(p=>p.TypeAttribute)
                .Include(p=>p.SizeAttribute)
                .Include(p=>p.ColorAttribute)
                .FirstOrDefault(p=>p.Id == id);
            var productVM = _mapper.Map<ProductViewModel>(product);
            return productVM;
        }
        public ProductDTO CreateProduct(ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                _context.Products.Add(product);
                _context.SaveChanges();
                return productDTO;
            }catch(Exception ex)
            {
                return new ProductDTO();
            }
        }
        public ProductDTO UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                _context.Products.Update(product);
                _context.SaveChanges();
                return productDTO;
            }
            catch (Exception ex)
            {
                return new ProductDTO();
            }
        }

        public bool HideProduct(int id)
        {
            try
            {
                Product product = _context.Products.FirstOrDefault(p=>p.Id==id);
                if (product == null) { return false; }
                product.DeletedAt = DateTime.Now;
                _context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
