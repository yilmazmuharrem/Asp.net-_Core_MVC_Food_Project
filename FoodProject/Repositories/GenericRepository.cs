using FoodProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FoodProject.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        Context context = new Context();

        public List<T> List()
        {

            return context.Set<T>().ToList();

        }



        public List<T> List(string include)
        {

            return context.Set<T>().Include(include).ToList();

        }

        public List<T> ListC(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter).ToList();
        }

        public void Add(T temp )
        {
            context.Set<T>().Add(temp);
            context.SaveChanges();

        }

        public void Update(T  temp)
        {
            context.Set<T>().Update(temp);
            context.SaveChanges();
        }

        public void Delete(T temp)
        {
            context.Set<T>().Remove(temp);
            context.SaveChanges();
        }


        public T Get(int id)
        {
            var temp = context.Set<T>().Find(id);

            return temp;
        }
    }
}
