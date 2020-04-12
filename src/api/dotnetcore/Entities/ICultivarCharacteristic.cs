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
}

/* Cultivar characteristics
    PH: min: 5.5; max: 7; fit: 6;
    soil-moisture...
    */