
using System.Text.Json.Serialization;

namespace Tilde.MT.TranslationSystemService.Models
{
    public class APIResponse
    {
        /// <summary>
        /// Error information
        /// </summary>
        [JsonPropertyName("error")]
        public Error Error { get; set; }
    }
}
