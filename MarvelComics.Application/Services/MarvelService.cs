using MarvelComics.Application.Dtos;
using MarvelComic.Application.Services.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvelComics.Application.Services
{
    public class MarvelService : IMarvelService
    {
        private readonly IConfiguration _configuration;
        public HttpClient Client { get; }
        public string ApiKey { get => _configuration.GetSection("ApiMarvelKeyForGet").Value; }
        public MarvelService(IConfiguration configuration,HttpClient httpClient)
        {
            _configuration = configuration;
            httpClient.BaseAddress = new Uri(_configuration.GetSection("ApiMarvel").Value); 
            Client = httpClient;
        }
        public async Task<CharacterResponse> GetCharacters(FilterCharacterDataContainer filterCharacter)
        {
            var response = await Client.GetAsync($"characters?{ApiKey}&nameStartsWith={filterCharacter.NameStartsWith}&orderBy=name");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CharacterResponse>(responseStream);
            }

            return new CharacterResponse();
        }
    }
}
