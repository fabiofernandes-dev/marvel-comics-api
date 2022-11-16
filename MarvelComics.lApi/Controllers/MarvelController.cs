using MarvelComics.Api.Validators;
using MarvelComics.Application.Dtos;
using MarvelComics.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelComics.Api.Controllers
{
    [Route("api/[controller]")]
    public class MarvelController : Controller
    {
        private readonly IMarvelService _marvelService;

        public MarvelController(IMarvelService marvelService)
        {
            _marvelService = marvelService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(FilterCharacterDataContainer filterCharacter)
        {
            if (!filterCharacter.OnePropertyHasValue())
                return BadRequest("Preencha pelo menos um campo de filtro");

            var response = await _marvelService.GetCharacters(filterCharacter);
            return Ok(response.data?.results);
        }
    }
}
