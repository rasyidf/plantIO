// using System;
// using System.Diagnostics;
// namespace PlantIO.Entities.Taxonomy
// {
//     public class TaxonomicMethodologyRank : ITaxonomicMethodologyReference
//     {
//         const NomenclatureConnectingTermUsage defaultConnectingTermUsage
//             = NomenclatureConnectingTermUsage.Unused;

//         public TaxonomicMethodologyRank() { }
//         public TaxonomicMethodologyRank(int level, string taxonType, NomenclatureConnectingTermUsage connectingTermUsage = defaultConnectingTermUsage)
//         : this(
//             level,
//             taxonType == null ? null : new TaxonType(taxonType),
//             connectingTermUsage
//         )
//         { }
//         public TaxonomicMethodologyRank(int level, TaxonType taxon, NomenclatureConnectingTermUsage connectingTermUsage = defaultConnectingTermUsage)
//         {
//             Debug.Assert(taxon != null, nameof(taxon) + "is null");

//             Level = level;
//             Taxon = taxon;
//             TaxonId = taxon.Id;
//             ConnectingTermUsage = connectingTermUsage;
//         }

//         #region keys / indexes // #todo: split region
//         public int Id { get; set; }

//         public int TaxonTypeId { get; set; }
//         public virtual TaxonType TaxonType { get; set; }

//         public Guid NomenclatureCodeId { get; set; }
//         public TaxonomicRankBasedMethodology Methodology { get; set; }

//         #endregion

//         public int Level { get; set; }

//         public bool IsActive { get; set; }

//         public NomenclatureConnectingTermUsage ConnectingTermUsage { get; set; }
//     }

//     public enum NomenclatureConnectingTermUsage
//     {
//         Unused = 0,

//         /// <summary>
//         /// Requires a connecting term in writen name,
//         /// e.g.: "subsp." for subspecies
//         /// </summary>
//         Required = 1,
//     }
// }