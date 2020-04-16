using System.Collections.Generic;

// #review:
// ITrait?
// IFeature?
// those interfaces will contain information about the plant *during each one* of its cicles / time range: 
// - environment conditions in which the plant fits
// e.g.: required soil moisture, soil PH, prefered shadow level or direct sun (including tropic regional data)
// - what modifications plant make to the environment
// e.g.: casting a shadow (size, density), nitrogen fixation (x)
// - which layer the plant occupies in a forest

namespace PlantIO.Entities
{
    
    public class ICultivarCharacteristic
    {
        /// <summary>
        /// A standard code for characteristc name, 
        /// for instance, "🌞"  would be the code for both
        /// "en-US|sun" and "pt-BR|sol"
        /// </summary>
        string Code { get; set; }
    }

    public class IRangeCultivarCharacteristic : ICultivarCharacteristic
    {
        int Min { get; set; }
        int Max { get; set; }
        int Fit { get; set; }
    }

    public class IMathematicalCultivarCharacteristic : ICultivarCharacteristic
    {
        public string FunctionName { get; set; }
        public Dictionary<string, object> Arguments { get; set; }
    }
}

/* Cultivar characteristics
    PH: min: 5.5; max: 7; fit: 6;
    soil-moisture...
    */
