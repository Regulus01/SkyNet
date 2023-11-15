using Azure;
using Azure.AI.TextAnalytics;
using SkynetAPI.SentimentAnalyse.ViewModels;


namespace SkynetAPI.SentimentAnalyse;

public class Sentiment
{
    private static readonly AzureKeyCredential credentials = new AzureKeyCredential("d568cd5cea2647429ed79504a630ad1c");
    private static readonly Uri endpoint = new Uri("https://hack-idioma.cognitiveservices.azure.com/");

    public static TextSentment ObterSentimento(string text)
    {
        var client = new TextAnalyticsClient(endpoint, credentials);
  
        return SentimentAnalysisExample(client, text);
    }
	
    private static TextSentment SentimentAnalysisExample(TextAnalyticsClient client, string text)
    {
        DocumentSentiment documentSentiment = client.AnalyzeSentiment(text);

        foreach (var sentence in documentSentiment.Sentences)
        {
            return new TextSentment(sentence.Sentiment.ToString(), 
                                    Math.Truncate(sentence.ConfidenceScores.Positive * 100), 
                                     Math.Truncate(sentence.ConfidenceScores.Negative * 100), 
                                     Math.Truncate(sentence.ConfidenceScores.Neutral * 100));
            
        }
        
        return new TextSentment();
    }
}