using MarvelComics.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComics.Application.Services.Contracts
{
    public interface IMarvelService
    {
        Task<CharacterResponse> GetCharacters(FilterCharacterDataContainer filterCharacter);
    }
}
