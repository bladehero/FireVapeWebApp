using AutoMapper;
using BLL.DTO;
using BLL.Extensions;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Liquids;
using System.Collections.Generic;

namespace BLL.Services
{
    public class LiquidService : BaseService, ICrudService<LiquidDTO>
    {
        private IMapper lineageMapper;
        private IMapper liquidMapper;

        public LiquidService(string connectionString) : base(connectionString)
        {
            lineageMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Lineage, LineageDTO>().BeforeMap((l, ldto) =>
                {
                    ldto.ModifiedByClient = IdentityMapper.GetClientById(l.ModifiedBy);
                    ldto.CreatedByClient = IdentityMapper.GetClientById(l.CreatedBy);
                });
                cfg.CreateMap<LineageDTO, Lineage>().BeforeMap((ldto, l) =>
                {
                    l.ModifiedBy = ldto.ModifiedByClient.Id;
                    l.CreatedBy = ldto.CreatedByClient.Id;
                });
            }).CreateMapper();
            liquidMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Liquid, LiquidDTO>().BeforeMap((l, ldto) =>
                {
                    ldto.ModifiedByClient = IdentityMapper.GetClientById(l.ModifiedBy);
                    ldto.CreatedByClient = IdentityMapper.GetClientById(l.CreatedBy);
                    ldto.Lineage = lineageMapper.Map<LineageDTO>(Database.Lineages.FindById(l.LineageId));
                });
                cfg.CreateMap<LiquidDTO, Liquid>().BeforeMap((ldto, l) =>
                {
                    l.ModifiedBy = ldto.ModifiedByClient.Id;
                    l.CreatedBy = ldto.CreatedByClient.Id;
                    l.LineageId = ldto.Lineage.Id;
                });
            }).CreateMapper();
        }

        public long Add(LiquidDTO item)
        {
            var liquid = liquidMapper.Map<Liquid>(item);
            return Database.Liquids.Insert(liquid);
        }
        public IEnumerable<LiquidDTO> FindAll()
        {
            return liquidMapper.MapCollection<Liquid, LiquidDTO>(Database.Liquids.FindAll());
        }
        public LiquidDTO FindById(int? id)
        {
            return liquidMapper.Map<LiquidDTO>(Database.Liquids.FindById(id));
        }
        public bool Remove(LiquidDTO item)
        {
            return RemoveById(item.Id);
        }
        public bool RemoveById(int? id)
        {
            return Database.Liquids.Delete(id);
        }
        public bool Update(LiquidDTO item)
        {
            var liquid = liquidMapper.Map<Liquid>(item);
            return Database.Liquids.Update(liquid);
        }
    }
}
