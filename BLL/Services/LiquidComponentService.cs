using AutoMapper;
using BLL.DTO;
using BLL.Extensions;
using BLL.Interfaces;
using DAL.Components;
using System.Collections.Generic;

namespace BLL.Services
{
    class LiquidComponentService : BaseService, ICrudService<LiquidComponentDTO>
    {
        private IMapper componentTypeMapper;
        private IMapper producerMapper;
        private IMapper componentMapper;

        public LiquidComponentService(string connection) : base(connection)
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
            componentMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LiquidComponent, ComponentDTO>().AfterMap((c, cdto) =>
                {
                    cdto.ModifiedByClient = IdentityMapper.GetClientById(c.ModifiedBy);
                    cdto.CreatedByClient = IdentityMapper.GetClientById(c.CreatedBy);
                    cdto.Producer = producerMapper.Map<ProducerDTO>(Database.Lineages.FindById(c.ProducerId));
                    cdto.ComponentType = componentTypeMapper.Map<ComponentTypeDTO>(Database.Lineages.FindById(c.TypeId));
                });
                cfg.CreateMap<ComponentDTO, LiquidComponent>().AfterMap((cdto, c) =>
                {
                    c.ModifiedBy = cdto.ModifiedByClient.Id;
                    c.CreatedBy = cdto.CreatedByClient.Id;
                    c.ProducerId = cdto.Producer.Id;
                    c.TypeId = cdto.ComponentType.Id;
                });
            }).CreateMapper();
        }

        public long Add(LiquidComponentDTO item)
        {
            var component = componentMapper.Map<LiquidComponent>(item);
            return Database.LiquidComponents.Insert(component);
        }
        public IEnumerable<LiquidComponentDTO> FindAll()
        {
            return componentMapper.MapCollection<LiquidComponent, LiquidComponentDTO>(Database.LiquidComponents.FindAll());
        }
        public LiquidComponentDTO FindById(int? id)
        {
            return componentMapper.Map<LiquidComponentDTO>(Database.LiquidComponents.FindById(id));
        }
        public bool Remove(LiquidComponentDTO item)
        {
            return RemoveById(item.Id);
        }
        public bool RemoveById(int? id)
        {
            return Database.Components.Delete(id);
        }
        public bool Update(LiquidComponentDTO item)
        {
            var component = componentMapper.Map<LiquidComponent>(item);
            return Database.LiquidComponents.Update(component);
        }
    }
}
