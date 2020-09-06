using System.ComponentModel;

namespace iTunesSearch.Models
{
    public class GroupedInteraction
    {
        [DisplayName("Clicked Ad Url")]
        public string ClickedAdUrl { get; set; }

        [DisplayName("Click Count")]
        public int ClickCount { get; set; }
    }
}