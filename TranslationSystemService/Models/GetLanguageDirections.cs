﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tilde.MT.TranslationSystemService.Models
{
    public class GetLanguageDirections
    {
        [JsonPropertyName("languageDirections")]
        public IEnumerable<LanguageDirection> LanguageDirections { get; set; }
    }
}
