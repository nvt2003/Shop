

using BusinessObjects.DTOs;
using DataAccess.DAO;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductDAO _productDAO;
        public ProductRepository(ProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public ProductDTO CreateProduct(ProductDTO productDTO)
        {
            return _productDAO.CreateProduct(productDTO);
        }

        public bool HideProduct(int id)
        {
            return _productDAO.HideProduct(id);
        }

        public ProductViewModel GetProductById(int id)
        {
            return _productDAO.GetProductById(id);
        }

        public List<ProductBasicViewModel> GetProducts(int page, int pageSize)
        {
            return _productDAO.GetProducts(page, pageSize);
        }

        public ProductDTO UpdateProduct(ProductDTO productDTO)
        {
            return _productDAO.UpdateProduct(productDTO);
        }
    }
}
