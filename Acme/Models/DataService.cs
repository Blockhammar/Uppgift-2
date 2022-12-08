using System.Text.Json;

namespace Uppgift2.Models
{
    public class DataService
    {
        // "Fake" DB
        static List<Dog> dogs = new List<Dog>
        {

        };
        public DataService()
        {
            if(dogs.Count == 0)
            {
                string fileName = @"\Storage\Dogs.json";
                string path = Environment.CurrentDirectory + fileName;
                string jsonString = File.ReadAllText(path);
                Dog[] dogArray = JsonSerializer.Deserialize<Dog[]>(jsonString);
                dogs = dogArray.ToList();
            }
        }

        void saveToDisk()
        {
            // Save to disk
            string fileName = @"\Storage\Dogs.json";
            string path = Environment.CurrentDirectory + fileName;
            string jsonString = JsonSerializer.Serialize(dogs);
            File.WriteAllText(path, jsonString);
        }

        public Dog[] GetAllDogs()
        {
            return dogs
                .OrderBy(o => o.Name)
                .ThenBy(o => o.Age)
                .ToArray();
        }

        public void Add(Dog dog)
        {
            dog.Id = dogs.Max(o => o.Id) + 1;
            dogs.Add(dog);
            saveToDisk();
        }

        public Dog GetDogById(int id)
        {
            return dogs
                 .FirstOrDefault(x => x.Id == id);
        }

        internal void Edit(Dog dog)
        {
            var index = dogs.FindIndex(x => x.Id == dog.Id);
            dogs[index] = dog;
            saveToDisk();

        }

        internal void Delete(Dog dog)
        {
            var index = dogs.FindIndex(x => x.Id == dog.Id);
            dogs.RemoveAt(index);
            saveToDisk();
        }
    }
}
