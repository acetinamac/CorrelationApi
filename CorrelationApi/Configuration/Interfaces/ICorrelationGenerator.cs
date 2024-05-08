namespace CorrelationApi.Configuration.Interfaces;

public interface ICorrelationGenerator
{
    string Get();
    void Set(string correlationId);
}