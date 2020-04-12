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
    [ApiController]
    [Route("[controller]")]
    public class CultivarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CultivarController> _logger;
        private readonly CultivarService cultivarService;

        public CultivarController(IMapper mapper, ILogger<CultivarController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cultivar> Get()
        {
            return null;

        }

        [HttpPost]
        public async Task<IAsyncResult> Post(AddCultivarCommand command)
        {
            var cultivar = _mapper.Map<Cultivar>(command);
            await cultivarService.AddAsync(cultivar);
            return Task.FromResult(Ok());

        }
    }
}
