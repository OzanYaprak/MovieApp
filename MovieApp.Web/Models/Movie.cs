using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Models
{
    public class Movie
    {
        public int MovieID { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage ="Film başlığı eklenmeli !")]
        [StringLength(50,MinimumLength =5, ErrorMessage ="Film başlığı 5-50 karakter aralığında olmalıdır.")] //bu kısımlar data annotations oluyor (display name, required kısımları vb.)
        public string Title { get; set; }

        [Required(ErrorMessage = "Film açıklaması eklenmeli !")]
        public string Description { get; set; }

        public string Director { get; set; }

        public string[] Casts { get; set; }

        [Required(ErrorMessage = "Film fotoğrafı eklenmeli !")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Kategori kısmı boş geçilemez !")]
        public int? GenreID { get; set; }

    }
}
