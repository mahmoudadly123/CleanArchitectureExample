using CleanArchitecture.MVC.Services.Contracts;
using Hanssens.Net;

namespace CleanArchitecture.MVC.Services.Implement
{
    public class LocalStorageService:ILocalStorageService
    {
        private LocalStorage Storage { get; }

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "CleanArchitecture"
            };
            Storage = new LocalStorage(config);
        }


        public void ClearStorage()
        {
            Storage.Clear();
        }

        public void ClearStorage(string key)
        {
            Storage.Remove(key);
        }

        public void ClearStorage(List<string> keys)
        {
            keys.ForEach(keyName =>
            {
                Storage.Remove(keyName);
            });
            
        }
        

        public bool Exist(string key)
        {
            return Storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return Storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            Storage.Store(key,value);
            Storage.Persist();
        }
    }
}
