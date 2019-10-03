namespace RequestTracker
{
    public interface IRequestTracker
    {
        bool IsRequestExpired(string ipAddress);
        void AddToTracker(string ipAddress, string mathProblem);
        string GetPreviousMathTest(string ipAdress);
    }
}