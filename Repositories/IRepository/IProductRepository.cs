

using BusinessObjects.DTOs;

namespace Repositories.IRepository
{
    public interface IProductRepository
    {
        List<ProductBasicViewModel> GetProducts(int page, int pageSize);
        ProductViewModel GetProductById(int id);
        ProductDTO CreateProduct(ProductDTO productDTO);
        ProductDTO UpdateProduct(ProductDTO productDTO);
        bool HideProduct(int id);
    }
}
