using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Net;
using Tilde.MT.TranslationSystemService.Models;
using Tilde.MT.TranslationSystemService.Models.Configuration;

namespace Tilde.MT.TranslationSystemService.Controllers
{
    /// <summary>
    /// API for language directions
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LanguageDirectionController : ControllerBase
    {
        private readonly ConfigurationSettings _configurationSettings;
        private readonly IMapper _mapper;

        public LanguageDirectionController(
            IOptions<ConfigurationSettings> configurationSettings,
            IMapper mapper
        )
        {
            _configurationSettings = configurationSettings.Value;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists available languages and domains
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(LanguageDirectionsResponse), Description ="")]
        public ActionResult<LanguageDirectionsResponse> Get()
        {
            var response = new LanguageDirectionsResponse()
            {
                LanguageDirections = _configurationSettings.LanguageDirections.Select(item => _mapper.Map<Models.LanguageDirection>(item))
            };

            return Ok(response);
        }
    }
}
