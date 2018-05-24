using Firebase.Database;
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
        //private FirebaseClient _offlineFirebase;
        private string _name;

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
        public string GetData()
        {
            return _name;
        }

        public async Task PutDataAsync(string name, string surname)
        {
            var user = new User(name, surname);
            //await _firebase.Child("Users").PostAsync<User>(user);
            Console.WriteLine("Put Done");
        }

        public async Task GetDataAsync()
        {
            var items = await _firebase
              .Child("Users")
              //.WithAuth("<Authentication Token>") // <-- Add Auth token if required. Auth instructions further down in readme.
              //.OrderByKey()
              //.LimitToFirst(2)
              .OnceAsync<User>();
            //Console.WriteLine("Working");
            //var newitems = items.Cast<User>();

            var query = _firebase.Child("Users").AsRealtimeDatabase<User>("", "", StreamingOptions.Everything, InitialPullStrategy.Everything, true);
            var users = query.Once();

            //query.Pull("-LD8-RYu1xk8Sn5OOvHZ");
            query.SyncExceptionThrown += (s, ex) => Console.WriteLine(ex.Exception);
            //var users = query.Once();
            //List<User> users = query.Database;
            foreach (var item in users)
            {
                Console.WriteLine("In loop");
                //Console.WriteLine(item.Object.Name);
            }
        }

    }
}
