namespace CleanArchitecture.MVC.Services.Contracts
{
    public interface ILocalStorageService
    {
        /// <summary>
        /// Clear All Keys inside Storage
        /// </summary>
        void ClearStorage();

        /// <summary>
        /// Clear Specific Key inside Storage
        /// </summary>
        /// <param name="key"></param>
        void ClearStorage(string key);

        /// <summary>
        /// Clear Some Keys inside Storage
        /// </summary>
        /// <param name="keys"></param>
        void ClearStorage(List<string> keys);

        /// <summary>
        /// Check if Key exist inside Storage
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exist(string key);

        /// <summary>
        /// Read Value of Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetStorageValue<T>(string key);

        /// <summary>
        /// Set Value of Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetStorageValue<T>(string key,T value);
    }
}
