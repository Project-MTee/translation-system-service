
using System.Text.Json.Serialization;

namespace Tilde.MT.TranslationSystemService.Models
{
    public class Error
    {
        /// <summary>
        /// Error code
        /// </summary>
        /// <example>0</example>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        /// <example></example>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
