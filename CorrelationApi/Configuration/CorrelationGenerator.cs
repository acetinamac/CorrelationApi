using CorrelationApi.Configuration.Interfaces;

namespace CorrelationApi.Configuration;

public class CorrelationGenerator: ICorrelationGenerator
{
    private string _correlationId = Guid.NewGuid().ToString();

    public string Get() => _correlationId;

    public void Set(string correlationId) => _correlationId = correlationId;
    
}