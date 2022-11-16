using System;

public class FilterCharacterDataContainer
{
    public FilterCharacterDataContainer()
    {

        public string Name { get; set; }
    public string NameStartsWith { get; set; }
    public DateTime? ModifiedSince { get; set; }
    public List<int> Comics { get; set; }
    public List<int> Series { get; set; }
    public List<int> Events { get; set; }
    public List<int> Stories { get; set; }
    public string OrderBy { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
}
}
