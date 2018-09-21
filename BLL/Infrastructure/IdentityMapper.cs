using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Identities;

namespace BLL.Infrastructure
{
    public class IdentityMapper
    {
        private IMapper roleMapper;
        private IMapper clientMapper;
        private UnitOfWork unitOfWork;

        public ClientDTO GetClientById(int id)
        {
            var client = unitOfWork.Clients.FindById(id);
            if (client == null)
            {
                return null;
            }
            return clientMapper.Map<ClientDTO>(client);
        }
        public ClientDTO MapToDTO(Client client)
        {
            if (client == null)
            {
                return null;
            }
            return clientMapper.Map<ClientDTO>(client);
        }
        public Client Map(ClientDTO client)
        {
            if (client == null)
            {
                return null;
            }
            return clientMapper.Map<Client>(client);
        }

        public IdentityMapper(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            roleMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleDTO>();
                cfg.CreateMap<RoleDTO, Role>();
            }).CreateMapper();
            clientMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, ClientDTO>().AfterMap((c, cdto) =>
                {
                    cdto.Role = roleMapper.Map<RoleDTO>(unitOfWork.Clients.FindById(c.RoleId));
                });
                cfg.CreateMap<ClientDTO, Client>().AfterMap((cdto, c) =>
                {
                    c.RoleId = cdto.Role.Id;
                });
            }).CreateMapper();
        }
    }
}
