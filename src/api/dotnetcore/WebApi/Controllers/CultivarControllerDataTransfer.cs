using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantIO.Entities;
using PlantIO.Services;

namespace PlantIO.WebApi.Controllers
{
    public class CultivarControllerDataTransfer : Profile
    {
        public CultivarControllerDataTransfer()
        {
            CreateMap<Cultivar, AddCultivarCommand>();
        }
    }

    public class AddCultivarCommand
    {
        public Guid CultivarId { get; set; }

        public virtual CultivarNameIdentifier Identifier { get; set; }

        public virtual ICollection<ICultivarCharacteristic> Characteristics { get; set; }
        
        public virtual ICollection<ICultivarInteraction> Interactions { get; set; }
        public ICollection<CultivarPopularNameRequest> PopularNames;
    }

    public class CultivarNameRequest
    {

    }

    public class CultivarPopularNameRequest : CultivarPopularName
    {
        new private Guid? DataSetId { get; set; }

        [DataMember(Name = "culture")]
        new public string LanguageCultureName { get; set; }
    }
}
