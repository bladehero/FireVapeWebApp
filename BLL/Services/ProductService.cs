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
                cfg.CreateMap<ComponentTypeDTO, ComponentType>().AfterMap((cdto, c) =>
                {
                    c.ModifiedBy = cdto.ModifiedByClient.Id;
                    c.CreatedBy = cdto.CreatedByClient.Id;
                });
            }).CreateMapper();
            producerMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Producer, ProducerDTO>().AfterMap((p, pdto) =>
                {
                    pdto.ModifiedByClient = IdentityMapper.GetClientById(p.ModifiedBy);
                    pdto.CreatedByClient = IdentityMapper.GetClientById(p.CreatedBy);
                });
                cfg.CreateMap<ProducerDTO, Producer>().AfterMap((pdto, p) =>
                {
                    p.ModifiedBy = pdto.ModifiedByClient.Id;
                    p.CreatedBy = pdto.CreatedByClient.Id;
                });
            }).CreateMapper();
            productMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().AfterMap((p, pdto) =>
                {
                    pdto.ModifiedByClient = IdentityMapper.GetClientById(p.ModifiedBy);
                    pdto.CreatedByClient = IdentityMapper.GetClientById(p.CreatedBy);
                    pdto.Producer = producerMapper.Map<ProducerDTO>(Database.Lineages.FindById(p.ProducerId));
                    pdto.ComponentType = componentTypeMapper.Map<ComponentTypeDTO>(Database.Lineages.FindById(p.TypeId));
                });
                cfg.CreateMap<ProductDTO, Product>().AfterMap((pdto, p) =>
                {
                    p.ModifiedBy = pdto.ModifiedByClient.Id;
                    p.CreatedBy = pdto.CreatedByClient.Id;
                    p.ProducerId = pdto.Producer.Id;
                    p.TypeId = pdto.ComponentType.Id;
                });
            }).CreateMapper();
        }

        public long Add(ProductDTO item)
        {
            var product = productMapper.Map<Product>(item);
            return Database.Products.Insert(product);
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
        public bool Remove(ProductDTO item)
        {
            return RemoveById(item.Id);
        }
        public bool RemoveById(int? id)
        {
            return Database.Products.Delete(id);
        }
        public bool Update(ProductDTO item)
        {
            var product = productMapper.Map<Product>(item);
            return Database.Products.Update(product);
        }
    }
}
