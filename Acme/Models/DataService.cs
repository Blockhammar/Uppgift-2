namespace Uppgift2.Models
{
    public class DataService
    {
        // "Fake" DB
        static List<Dog> dogs = new List<Dog>
        {
            new Dog { Id = 20, Name = "Taylor", Age = 5},
            new Dog { Id = 10, Name = "Gibson", Age = 5},
            new Dog { Id = 30, Name = "Roland", Age = 5},
        };

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

        }

        internal void Delete(Dog dog)
        {
            var index = dogs.FindIndex(x => x.Id == dog.Id);
            dogs.RemoveAt(index);
        }
    }
}
