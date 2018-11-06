using System.ComponentModel.DataAnnotations;

namespace FireVapeApplication.ViewModels
{
    public class SearchComponentVM
    {
        [Display(Name="Наименование")]
        public string Name { get; set; }
        [Display(Name = "Производитель")]
        public string Producer { get; set; }
        [Display(Name = "Категория")]
        public int ComponentType { get; set; }
        [Display(Name = "Кол-во на складе")]
        public int Count { get; set; }
        [Display(Name = "С удаленными")]
        public bool WithDeleted { get; set; }
    }
}
