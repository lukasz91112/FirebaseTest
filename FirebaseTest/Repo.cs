using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Offline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirebaseConsole
{
    class Repo
    {
        private FirebaseClient _firebase;

        public Repo()
        {
            _firebase = new FirebaseClient(
                "https://fir-test-420af.firebaseio.com/",
                new FirebaseOptions
                {
                    OfflineDatabaseFactory = (t, s) => new OfflineDatabase(t, s),
                    //AuthTokenAsyncFactory = () => Task.FromResult("<YOUR AUTH IF NEEDED>")
                });
        }

        public async Task PostDataAsync(string name, string surname)
        {
            var user = new User(name, surname);
            await _firebase.Child("Users").PostAsync(user);
            Console.WriteLine("Put Done");
        }

        public async Task GetDataAsync()
        {
            var users = await _firebase
              .Child("Users")
              .OnceAsync<User>();

            //To powinno działać offline, ale nie działa
            //var query = _firebase.Child("").AsRealtimeDatabase<User>("", "", StreamingOptions.Everything, InitialPullStrategy.Everything, true);
            //var users = query.Once();

            foreach (var user in users)
            {
                Console.WriteLine(user.Object.Name);
            }
        }
    }
}
