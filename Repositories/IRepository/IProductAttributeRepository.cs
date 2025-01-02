

using BusinessObjects.DTOs;

namespace Repositories.IRepository
{
    public interface IProductAttributeRepository
    {
        List<ProductAttributeDTO> GetProductAttributes(int page, int pageSize);
        ProductAttributeDTO GetProductAttributeById(int Id);
        ProductAttributeDTO CreateProductAttribute(ProductAttributeDTO productAttributeDTO);
        ProductAttributeDTO UpdateProductAttribute(ProductAttributeDTO productAttributeDTO);
        bool HideProductAttribute(int Id);
    }
}
