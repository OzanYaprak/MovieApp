using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MovieApp.Web.Entity
{
    public class Movie
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)] // EĞER ID PARAMETRESİ DATABASE TARAFINDAN VERİLMESİNİ İSTEMİYORSAK YAZILABİLİNİR.


        [Key]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public string ImageURL { get; set; }

        [Required]
        public List<Genre> Genres { get; set; }
        
    }
}
