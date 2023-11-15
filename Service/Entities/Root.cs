namespace SkynetAPI.Entities;

public class Root
{
    public List<Translation> Translations { get; set; }
}

public class Translation
{
    public string Text { get; set; }
}

