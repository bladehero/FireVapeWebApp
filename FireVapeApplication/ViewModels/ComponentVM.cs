using System;
using System.ComponentModel.DataAnnotations;

namespace FireVapeApplication.ViewModels
{
    public class ComponentVM
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Время создания")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Время изменения")]
        public DateTime ModifiedAt { get; set; }
        public int? ProducerId { get; set; }
        [Display(Name = "Производитель")]
        public string Producer { get; set; }
        public int? ComponentTypeId { get; set; }
        [Display(Name = "Категория")]
        public string ComponentType { get; set; }
        public int Count { get; set; }
        [Display(Name = "Себестоимость")]
        public double Cost { get; set; }
        public int? CreatedByClientId { get; set; }
        [Display(Name = "Создано")]
        public string CreatedByClient { get; set; }
        public int? ModifiedByClientId { get; set; }
        [Display(Name = "Изменено")]
        public string ModifiedByClient { get; set; }
        public bool IsDeleted { get; set; }
    }
}
