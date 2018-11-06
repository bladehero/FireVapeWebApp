using AutoMapper;
using BLL.DTO;
using BLL.Extensions;
using BLL.Interfaces;
using DAL.Components;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ProducerService : BaseService, ICrudService<ProducerDTO>
    {
        private IMapper producerMapper;

        public ProducerService(string connectionString) : base(connectionString)
        {
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
        }

        public long Add(ProducerDTO item)
        {
            var producer = producerMapper.Map<Producer>(item);
            return Database.Producers.Insert(producer);
        }
        public IEnumerable<ProducerDTO> FindAll()
        {
            return producerMapper.MapCollection<Producer, ProducerDTO>(Database.Producers.FindAll());
        }
        public ProducerDTO FindById(int? id)
        {
            return producerMapper.Map<ProducerDTO>(Database.Producers.FindById(id));
        }
        public bool Remove(ProducerDTO item)
        {
            return RemoveById(item.Id);
        }
        public bool RemoveById(int? id)
        {
            return Database.Producers.Delete(id);
        }
        public bool Update(ProducerDTO item)
        {
            var producer = producerMapper.Map<Producer>(item);
            return Database.Producers.Update(producer);
        }
    }
}
