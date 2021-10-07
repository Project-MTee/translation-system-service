using AutoMapper;

namespace Tilde.MT.TranslationSystemService.Models.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Configuration.SettingsConfiguration.LanguageDirection, Models.LanguageDirection>();
        }
    }
}
