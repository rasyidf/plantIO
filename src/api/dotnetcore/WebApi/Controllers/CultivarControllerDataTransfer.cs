using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantIO.Entities;
using PlantIO.Entities.Cultivar;
using PlantIO.Entities.Taxonomy;
using PlantIO.Services;

// #refactor: DTOS

namespace PlantIO.WebApi.Controllers
{
    public class CultivarControllerDataTransfer : Profile
    {
        public CultivarControllerDataTransfer()
        {
            //CreateMap<Cultivar, CreateCultivarRequest>(); 
        }
    }

    public class CreateCultivarRequest
    {
        public string ScientificName { get; set; }
        public int TaxaHierarchyId { get; set; }

        public virtual List<CultivarIdentifierRequest> Identifiers { get; set; }
        public virtual List<CultivarPopularNameRequest> PopularNames { get; set; }

        // public virtual ICollection<ICultivarCharacteristic> Characteristics { get; set; }
        // public virtual ICollection<ICultivarInteraction> Interactions { get; set; }
        // public ICollection<CultivarPopularNameRequest> PopularNames;
    }

    public class CultivarIdentifierRequest : ITaxon
    {
        public string TaxonType { get; set; }
        public string Value { get; set; }
    }

    public class CultivarPopularNameRequest
    {
        // private Guid? DataSetId { get; set; }

        public string Culture { get; set; }
    }
}
