using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Extensions;
using BLL.Interfaces;
using DAL.Components;

namespace BLL.Services
{
    public class ComponentService : BaseService, ICrudService<ComponentDTO>
    {
        private IMapper componentTypeMapper;
        private IMapper producerMapper;
        private IMapper componentMapper;

        public ComponentService(string connection) : base(connection)
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
                cfg.CreateMap<Component, ComponentDTO>().AfterMap((c, cdto) =>
                {
                    cdto.ModifiedByClient = IdentityMapper.GetClientById(c.ModifiedBy);
                    cdto.CreatedByClient = IdentityMapper.GetClientById(c.CreatedBy);
                    cdto.Producer = producerMapper.Map<ProducerDTO>(Database.Lineages.FindById(c.ProducerId));
                    cdto.ComponentType = componentTypeMapper.Map<ComponentTypeDTO>(Database.ComponentTypes.FindById(c.TypeId));
                });
                cfg.CreateMap<ComponentDTO, Component>().AfterMap((cdto, c) =>
                {
                    c.ModifiedBy = cdto.ModifiedByClient.Id;
                    c.CreatedBy = cdto.CreatedByClient.Id;
                    c.ProducerId = cdto.Producer.Id;
                    c.TypeId = cdto.ComponentType.Id;
                });
            }).CreateMapper();
        }

        public long Add(ComponentDTO item)
        {
            var component = componentMapper.Map<Component>(item);
            return Database.Components.Insert(component);
        }
        public IEnumerable<ComponentDTO> FindAll()
        {
            return componentMapper.MapCollection<Component, ComponentDTO>(Database.Components.FindAll());
        }
        public ComponentDTO FindById(int? id)
        {
            return componentMapper.Map<ComponentDTO>(Database.Components.FindById(id));
        }
        public bool Remove(ComponentDTO item)
        {
            return RemoveById(item.Id);
        }
        public bool RemoveById(int? id)
        {
            return Database.Components.Delete(id);
        }
        public bool Update(ComponentDTO item)
        {
            var component = componentMapper.Map<Component>(item);
            return Database.Components.Update(component);
        }
    }
}
