using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;
using OdeToFood.Data;

namespace OdeToFood.Services
{
    public class SqlResturantData : IResturantData
    {
        private OdeToFoodDBContext _context; 
        public SqlResturantData(OdeToFoodDBContext context)
        {
            _context = context;
        }

        public Resturant Add(Resturant resturant)
        {
            _context.Resturants.Add(resturant);
            _context.SaveChanges();
            return resturant;



        }

        public Resturant get(int id)
        {
            return _context.Resturants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Resturant> GetAll()
        {
           return _context.Resturants.OrderBy(r => r.Name);
        }
    }

}
