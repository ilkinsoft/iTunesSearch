using System;

namespace iTunesSearch.DTO
{
    public class Movie
    {
        public string wrapperType { get; set; }
        public string kind { get; set; }
        public int trackId { get; set; }
        public string artistName { get; set; }
        public string trackName { get; set; }
        public string trackCensoredName { get; set; }
        public string trackViewUrl { get; set; }
        public string previewUrl { get; set; }
        public string artworkUrl30 { get; set; }
        public string artworkUrl60 { get; set; }
        public string artworkUrl100 { get; set; }
        public double collectionPrice { get; set; }
        public double trackPrice { get; set; }
        public double trackRentalPrice { get; set; }
        public double collectionHdPrice { get; set; }
        public double trackHdPrice { get; set; }
        public double trackHdRentalPrice { get; set; }
        public DateTime releaseDate { get; set; }
        public string collectionExplicitness { get; set; }
        public string trackExplicitness { get; set; }
        public int trackTimeMillis { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public string primaryGenreName { get; set; }
        public string contentAdvisoryRating { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
    }
}