using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{

    public class InMemoryResturantData:IResturantData
    {

        public InMemoryResturantData()
        {
            _resturant = new List<Resturant>
            {
                new Resturant {Id = 1 , Name = "Gyllende Måsen"},
                new Resturant{Id =2 ,Name ="Kebbab Kungen"},
                new Resturant{Id =3 ,Name="Pizza Hut"}
            };

       
        }
        

        public IEnumerable<Resturant> GetAll()
        {
            return _resturant.OrderBy(r => r.Name);
        }

        public Resturant get(int id)
        {
            return _resturant.FirstOrDefault(r => r.Id == id);
        }

        public Resturant Add(Resturant resturant)
        {
            resturant.Id = _resturant.Max(r => r.Id) + 1;
            _resturant.Add(resturant);
            return resturant;
        }

        List<Resturant> _resturant;
    }
}
