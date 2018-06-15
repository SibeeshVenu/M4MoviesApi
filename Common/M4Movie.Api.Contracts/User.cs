using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Movie.Api.Contracts
{
    [Serializable]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(PropertyName ="id")]
        public long UserId { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [DataType(DataType.ImageUrl), MaxLength(200)]
        [JsonProperty(PropertyName = "image")]
        public string UserImage { get; set; }

        [DataType(DataType.EmailAddress), MaxLength(50), Required]
        [JsonProperty(PropertyName = "email")]
        public string UserEmail { get; set; }

        [DataType(DataType.Password), MaxLength(50), Required]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
