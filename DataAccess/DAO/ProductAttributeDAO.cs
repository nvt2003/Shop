

using AutoMapper;
using Azure;
using BusinessObjects;
using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ProductAttributeDAO
    {
        private readonly ShopDBContext _context;
        private readonly IMapper _mapper;
        public ProductAttributeDAO(ShopDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProductAttributeDTO> GetProductAttributes(int page, int pageSize)
        {
            var list = _context.ProductAttributes.Where(pa=>pa.DeletedAt==null)
                .Skip(page*pageSize).Take(pageSize)
                .ToList();
            var listDto = _mapper.Map<List<ProductAttributeDTO>>(list);
            return listDto;
        }
        public ProductAttributeDTO GetProductAttributeById(int id)
        {
            var pa = _context.ProductAttributes.AsNoTracking()
                .FirstOrDefault(pa => pa.Id==id);
            var paDto = _mapper.Map<ProductAttributeDTO>(pa);
            return paDto;
        }
        public ProductAttributeDTO CreateProductAttribute(ProductAttributeDTO productAttributeDTO)
        {
            try
            {
                ProductAttribute pa = _mapper.Map<ProductAttribute>(productAttributeDTO);
                _context.ProductAttributes.Add(pa);
                _context.SaveChanges();
                return productAttributeDTO;
            }catch (Exception ex)
            {
                return new ProductAttributeDTO();
            }
        }
        public ProductAttributeDTO UpdateProductAttribute(ProductAttributeDTO productAttributeDTO)
        {
            try
            {
                ProductAttribute pa = _mapper.Map<ProductAttribute>(productAttributeDTO);
                _context.ProductAttributes.Update(pa);
                _context.SaveChanges();
                return productAttributeDTO;
            }
            catch (Exception ex)
            {
                return new ProductAttributeDTO();
            }
        }
        public bool HideProductAttribute(int id)
        {
            try
            {
                ProductAttribute pa = _context.ProductAttributes.FirstOrDefault(pa=>pa.Id==id);
                if (pa ==null) return false;
                pa.DeletedAt = DateTime.Now;
                _context.ProductAttributes.Update(pa);
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
