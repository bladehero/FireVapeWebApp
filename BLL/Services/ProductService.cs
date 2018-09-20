using AutoMapper;
using BLL.DTO;
using BLL.Extensions;
using BLL.Interfaces;
using DAL.Components;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ProductService : BaseService, IProductService<ProductDTO>
    {
        private IMapper componentTypeMapper;
        private IMapper producerMapper;
        private IMapper productMapper;

        public ProductService(string connectionString) : base(connectionString)
        {
            componentTypeMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ComponentType, ComponentTypeDTO>().AfterMap((c, cdto) =>
                {
                    cdto.ModifiedByClient = IdentityMapper.GetClientById(c.ModifiedBy);
                    cdto.CreatedByClient = IdentityMapper.GetClientById(c.CreatedBy);
                });
            }).CreateMapper();
            producerMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Producer, ProducerDTO>().AfterMap((p, pdto) =>
                {
                    pdto.ModifiedByClient = IdentityMapper.GetClientById(p.ModifiedBy);
                    pdto.CreatedByClient = IdentityMapper.GetClientById(p.CreatedBy);
                });
            }).CreateMapper();
            productMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().AfterMap((p, pdto) =>
                {
                    pdto.ModifiedByClient = IdentityMapper.GetClientById(p.ModifiedBy);
                    pdto.CreatedByClient = IdentityMapper.GetClientById(p.CreatedBy);
                    pdto.Producer = producerMapper.Map<ProducerDTO>(Database.Lineages.FindById(p.ProducerId));
                    pdto.ComponentTypeDTO = componentTypeMapper.Map<ComponentTypeDTO>(Database.Lineages.FindById(p.TypeId));
                });
            }).CreateMapper();
        }

        public IEnumerable<ProductDTO> FindAll()
        {
            return productMapper.MapCollection<Product, ProductDTO>(Database.Products.FindAll());
        }

        public ProductDTO FindById(int? id)
        {
            return productMapper.Map<ProductDTO>(Database.Products.FindById(id));
        }

        public IEnumerable<ProductDTO> FindByTypeId(int? id)
        {
            return productMapper.MapCollection<Product, ProductDTO>(Database.Products.FindByTypeId(id));
        }
    }
}
