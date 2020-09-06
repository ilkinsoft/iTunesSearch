using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTunesSearch.Models
{
    public class Interaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public string ClickedAdUrl { get; set; }
        public DateTime InteractionTime { get; set; }
        public string DeviceName { get; set; }
        public string ScreenSize { get; set; }
    }
}