using AutoMapper;
using BLL.DTO;
using BLL.Extensions;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Liquids;
using System.Collections.Generic;

namespace BLL.Services
{
    public class LiquidService : BaseService, IProductService<LiquidDTO>
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
            }).CreateMapper();
            liquidMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Liquid, LiquidDTO>().BeforeMap((l, ldto) =>
                {
                    ldto.ModifiedByClient = IdentityMapper.GetClientById(l.ModifiedBy);
                    ldto.CreatedByClient = IdentityMapper.GetClientById(l.CreatedBy);
                    ldto.Lineage = lineageMapper.Map<LineageDTO>(Database.Lineages.FindById(l.LineageId));
                });
            }).CreateMapper();
        }

        public IEnumerable<LiquidDTO> FindAll()
        {
            return liquidMapper.MapCollection<Liquid, LiquidDTO>(Database.Liquids.FindAll());
        }
        public LiquidDTO FindById(int? id)
        {
            return liquidMapper.Map<LiquidDTO>(Database.Liquids.FindById(id));
        }
        public IEnumerable<LiquidDTO> FindByTypeId(int? id)
        {
            return liquidMapper.MapCollection<Liquid, LiquidDTO>(Database.Liquids.FindByLineage(id));
        }
    }
}
