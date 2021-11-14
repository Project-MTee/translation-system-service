using AutoMapper;
using Tilde.MT.TranslationSystemService.Models.DTO.LanguageDirections;

namespace Tilde.MT.TranslationSystemService.Models.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Configuration.SettingsConfiguration.LanguageDirection, LanguageDirection>();
        }
    }
}
