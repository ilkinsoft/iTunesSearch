using System;
using System.ComponentModel;
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
        [DisplayName("User")]
        public virtual ApplicationUser User { get; set; }

        [DisplayName("Clicked Ad Url")]
        public string ClickedAdUrl { get; set; }

        [DisplayName("Interaction Time")]
        public DateTime InteractionTime { get; set; }

        [DisplayName("Device Name")]
        public string DeviceName { get; set; }

        [DisplayName("Ip Address")]
        public string IpAddress { get; set; }

        [DisplayName("Screen Size")]
        public string ScreenSize { get; set; }
    }
}