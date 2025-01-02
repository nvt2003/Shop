

using BusinessObjects.DTOs;
using DataAccess.DAO;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class ProductAttributeRepository:IProductAttributeRepository
    {
        private readonly ProductAttributeDAO _productAttributeDAO;
        public ProductAttributeRepository(ProductAttributeDAO productAttributeDAO)
        {
            _productAttributeDAO = productAttributeDAO;
        }

        public ProductAttributeDTO CreateProductAttribute(ProductAttributeDTO productAttributeDTO)
        {
            return _productAttributeDAO.CreateProductAttribute(productAttributeDTO);
        }

        public ProductAttributeDTO GetProductAttributeById(int Id)
        {
            return _productAttributeDAO.GetProductAttributeById(Id);
        }

        public List<ProductAttributeDTO> GetProductAttributes(int page, int pageSize)
        {
            return _productAttributeDAO.GetProductAttributes(page, pageSize);
        }

        public bool HideProductAttribute(int Id)
        {
            return _productAttributeDAO.HideProductAttribute(Id);
        }

        public ProductAttributeDTO UpdateProductAttribute(ProductAttributeDTO productAttributeDTO)
        {
            return _productAttributeDAO.UpdateProductAttribute(productAttributeDTO);
        }
    }
}
