using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    /// <summary>
    /// Will Represent Users
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class ApplicationUser<TKey> : IdentityUser<TKey> where TKey : IEquatable<TKey>
    {
        //Put Here any Aditionals Fields that will be stored inside Users Table
    }

}
