using AutoMapper;
using BLL.DTO;
using BLL.Extensions;
using BLL.Interfaces;
using DAL.Components;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ComponentTypeService : BaseService, ICrudService<ComponentTypeDTO>
    {
        private IMapper componentTypeMapper;

        public ComponentTypeService(string connectionString) : base(connectionString)
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
        }

        public long Add(ComponentTypeDTO item)
        {
            var ComponentType = componentTypeMapper.Map<ComponentType>(item);
            return Database.ComponentTypes.Insert(ComponentType);
        }
        public IEnumerable<ComponentTypeDTO> FindAll()
        {
            return componentTypeMapper.MapCollection<ComponentType, ComponentTypeDTO>(Database.ComponentTypes.FindAll());
        }
        public ComponentTypeDTO FindById(int? id)
        {
            return componentTypeMapper.Map<ComponentTypeDTO>(Database.ComponentTypes.FindById(id));
        }
        public bool Remove(ComponentTypeDTO item)
        {
            return RemoveById(item.Id);
        }
        public bool RemoveById(int? id)
        {
            return Database.ComponentTypes.Delete(id);
        }
        public bool Update(ComponentTypeDTO item)
        {
            var ComponentType = componentTypeMapper.Map<ComponentType>(item);
            return Database.ComponentTypes.Update(ComponentType);
        }
    }
}
