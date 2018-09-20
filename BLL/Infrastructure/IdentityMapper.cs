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
            return clientMapper.Map<ClientDTO>(unitOfWork.Clients.FindById(id));
        }

        public IdentityMapper(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            roleMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleDTO>();
            }).CreateMapper();
            clientMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, ClientDTO>().AfterMap((c, cdto) =>
                {
                    cdto.Role = roleMapper.Map<RoleDTO>(unitOfWork.Clients.FindById(c.RoleId));
                });
            }).CreateMapper();
        }
    }
}
