using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTO
{
    public class LibraryDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
    }
}
