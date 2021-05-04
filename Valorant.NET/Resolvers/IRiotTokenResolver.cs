namespace Valorant.NET.Resolvers
{
    /// <summary>
    /// Responsible for retrieving the consuming clients riot api token
    /// </summary>
    public interface IRiotTokenResolver
    {
        /// <summary>
        /// Returns the riot api token
        /// </summary>
        /// <returns>Riot api token</returns>
        string Resolve();
    }
}
