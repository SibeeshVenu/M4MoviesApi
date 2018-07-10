using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Movie.Api.Contracts
{
    [Serializable]
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(PropertyName = "watchListMovieId")]
        public long WatchListMovieId { get; set; }

        [JsonProperty(PropertyName ="id")]
        public long MovieId { get; set; }

        [DataType(DataType.Text), MaxLength(50), Required]
        [JsonProperty(PropertyName = "title")]
        public string MovieName { get; set; }

        [DataType(DataType.Text), MaxLength(750)]
        [JsonProperty(PropertyName = "overview")]
        public string MovieDescription { get; set; }

        [DataType(DataType.Text), MaxLength(750)]
        [JsonProperty(PropertyName = "comments")]
        public string Comments { get; set; }

        [DataType(DataType.ImageUrl), MaxLength(500), Required]
        [JsonProperty(PropertyName = "poster_path")]
        public string MovieImage { get; set; }
        
        [JsonProperty(PropertyName = "vote_average")]
        public double AverageVote { get; set; }

        [JsonProperty(PropertyName = "vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "isWatchList")]
        public bool IsWatchList { get; set; }

        [JsonProperty(PropertyName = "userid")]
        public long UserId { get; set; }
    }
}
