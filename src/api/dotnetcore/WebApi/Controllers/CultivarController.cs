using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantIO.Data;
using PlantIO.Entities;
using PlantIO.Entities.Cultivar;
using PlantIO.Services;

namespace PlantIO.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CultivarController : ControllerBase
    {
        private readonly CultivarDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<CultivarController> _logger;
        private readonly CultivarService cultivarService;

        public CultivarController(
            CultivarDbContext db, // #refactor: use services
            IMapper mapper, ILogger<CultivarController> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cultivar> Get()
        {
            return _db.Cultivars.ToList();
        }

        // #todo:
        [HttpPost]
        public async Task<IAsyncResult> Post(CreateCultivarRequest command)
        {
            // #review: this project don't have lots of entities, manual mappings could fit better than automapper.
            // var cultivar = _mapper.Map<Cultivar>(command);
            // await cultivarService.AddAsync(cultivar);
            return Task.FromResult(Ok());

        }
    }
}
