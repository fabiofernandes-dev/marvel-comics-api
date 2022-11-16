using System;

public interface IMarvelService
{
	CharacterDto GetCharacters(FilterCharacterDataContainer filterCharacter);
}
