
using System.Text.Json.Serialization;

namespace Tilde.MT.TranslationSystemService.Models
{
    public class LanguageDirection
    {
        /// <summary>
        /// Source language code
        /// </summary>
        /// <example>en</example>
        [JsonPropertyName("srcLang")]
        public string SourceLanguage { get; set; }

        /// <summary>
        /// Target language code
        /// </summary>
        /// <example>et</example>
        [JsonPropertyName("trgLang")]
        public string TargetLanguage { get; set; }

        /// <summary>
        /// Translation domain
        /// </summary>
        /// <example>general</example>
        [JsonPropertyName("domain")]
        public string Domain { get; set; }
    }
}
