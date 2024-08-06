namespace FitnessWorkoutTrackerApi.Service.BearerToken;

public interface IBearerTokenService
{
    void GenerateBearerToken(string email, string username);
}