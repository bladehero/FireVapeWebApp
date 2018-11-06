using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Extensions;
using FireVapeApplication.Controllers;
using FireVapeApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FireVapeApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComponentController : BaseController
    {
        static IMapper _componentMapper;
        static ComponentController()
        {
            _componentMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ComponentDTO, ComponentVM>()
                .ForMember(dest => dest.ComponentType, opt => opt.MapFrom(src => src.ComponentType.Type))
                .ForMember(dest => dest.ComponentTypeId, opt => opt.MapFrom(src => src.ComponentType.Id))
                .ForMember(dest => dest.CreatedByClient, opt => opt.MapFrom(src => $"{src.CreatedByClient.FirstName} {src.CreatedByClient.LastName}"))
                .ForMember(dest => dest.CreatedByClientId, opt => opt.MapFrom(src => src.CreatedByClient.Id))
                .ForMember(dest => dest.ModifiedByClient, opt => opt.MapFrom(src => $"{src.ModifiedByClient.FirstName} {src.ModifiedByClient.LastName}"))
                .ForMember(dest => dest.ModifiedByClientId, opt => opt.MapFrom(src => src.ModifiedByClient.Id))
                .ForMember(dest => dest.Producer, opt => opt.MapFrom(src => $"{src.Producer.Name}({ (string.IsNullOrWhiteSpace(src.Producer.Country) ? "Неизвестно" : src.Producer.Country) })"))
                .ForMember(dest => dest.ProducerId, opt => opt.MapFrom(src => src.Producer.Id));
            }).CreateMapper();
        }
        ICrudService<ComponentDTO> _componentService;
        ICrudService<ProducerDTO> _producerService;
        ICrudService<ComponentTypeDTO> _typeService;
        public ComponentController(IAccountService accountService, ICrudService<ComponentDTO> componentService, 
            ICrudService<ProducerDTO> producerService, ICrudService<ComponentTypeDTO> typeService) : base(accountService)
        {
            _componentService = componentService;
            _producerService = producerService;
            _typeService = typeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var components = _componentMapper.MapCollection<ComponentDTO, ComponentVM>(_componentService.FindAll());

            return PartialView(components);
        }

        [HttpGet]
        public IActionResult Search()
        {
            var producers = _producerService.FindAll();
            var types = _typeService.FindAll();

            ViewBag.Producers = new SelectList(producers, "Id", "Name");
            ViewBag.ComponentTypes = new SelectList(types, "Id", "Type");

            return PartialView();
        }

        [HttpPost]
        public IActionResult Search(SearchComponentVM model)
        {
            return PartialView();
        }
    }
}