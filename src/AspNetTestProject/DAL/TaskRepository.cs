using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetTestProject.DAL
{
    public class TaskRepository :IDisposable
    {
        private readonly DbEntities _db = null;
        public TaskRepository()
        {
            _db = new DbEntities();
        }

        public IEnumerable<Task> GetTasks()
        {
            return _db.Tasks;
        }



        public void Create(Task task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public void Upadte(Task task)
        {
            _db.Entry(task).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var task =  _db.Tasks.Find(id);
            if (task != null)
            {
               Delete(task);
            }
            else
            {
                throw  new Exception("Not found");
            }

           
        }

        public Task Find(int id)
        {
            return _db.Tasks.FirstOrDefault(s => s.Id == id);
        }

        internal void Delete(Task task)
        {
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }

        public bool TaskExists(int id)
        {
            return _db.Tasks.Any(s => s.Id == id);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        internal void Upadte(Task[] taskList)
        {
            foreach (var task in taskList)
            {
                _db.Entry(task).State = EntityState.Modified;
            }

            _db.SaveChanges();
        }
    }
}