using System.Collections.Generic;
using Tilde.MT.TranslationSystemService.Models.Configuration.SettingsConfiguration;
using Tilde.MT.TranslationSystemService.Models.DTO.LanguageDirections;

namespace Tilde.MT.TranslationSystemService.Models.Configuration
{
    public class ConfigurationSettings
    {
        public List<Models.Configuration.SettingsConfiguration.LanguageDirection> LanguageDirections { get; set; }
    }
}
