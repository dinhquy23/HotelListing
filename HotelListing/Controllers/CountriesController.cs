using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountriesController> _logger;
        private readonly IMapper _mapper;

        public CountriesController(IUnitOfWork unitOfWork, ILogger<CountriesController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCountries)}");
                return StatusCode(StatusCodes.Status500InternalServerError, new Responsive("Error", $"{ex.Message}"));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(item=>item.Id==id,new List<string> { "Hotels"});
                var results = _mapper.Map<CountryDTO>(country);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCountry)}");
                return StatusCode(StatusCodes.Status500InternalServerError, new Responsive("Error", $"{ex.Message}"));
            }
        }
    }
}
