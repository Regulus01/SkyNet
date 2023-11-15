namespace SkynetAPI.SentimentAnalyse.ViewModels;

public class TextSentment
{
    public string Sentimento { get; set; }
    public double Positivo { get; set; }
    public double Negativo { get; set; }
    public double Neutro { get; set; }

    public TextSentment()
    {
        
    }
    public TextSentment(string sentimento, double positivo, double negativo, double neutro)
    {
        Sentimento = sentimento;
        Positivo = positivo;
        Negativo = negativo;
        Neutro = neutro;
    }
}