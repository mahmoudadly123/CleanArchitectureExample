namespace CleanArchitecture.Application.Models.Identity
{
    //Stored inside Api Settings
    public class JWTSettings
    {
        /// <summary>
        /// Key for sign the JWT Token to sure that token not edited over network
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Who Create the JWT Token (Identity System)
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Who will Receive the JWT token (Client)
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Durations in Minutes for expiration of jwt token
        /// </summary>
        public string DurationInMinutes { get; set; }
    }
}
