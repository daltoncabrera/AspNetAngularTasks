using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AspNetTestProject.DAL;
using Task = AspNetTestProject.DAL.Task;

namespace AspNetTestProject.Controllers
{
    [RoutePrefix("api")]
    public class TasksController : ApiController
    {
        public TaskRepository _repo = new TaskRepository();


        // GET: api/Tasks
        public Object GetTasks()
        {
            var tasksList = _repo.GetTasks().ToList();
            return new 
            {
                ToDo = tasksList.Where(s => s.Status == (int) TaskStatusID.ToDO),
                Doing = tasksList.Where(s => s.Status == (int) TaskStatusID.Doing),
                Test = tasksList.Where(s => s.Status == (int) TaskStatusID.Test),
                Done = tasksList.Where(s => s.Status == (int) TaskStatusID.Done),
            };
        }

        [Route("List")]
        [HttpGet]
        public async Task<IHttpActionResult> List()
        {
            return Ok(_repo.GetTasks());
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public async Task<IHttpActionResult> GetTask(int id)
        {
            var task = _repo.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest();
            }

            try
            {
                _repo.Upadte(task);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public async Task<IHttpActionResult> PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                _repo.Create(task);
                return CreatedAtRoute("DefaultApi", new { id = task.Id }, task);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public async Task<IHttpActionResult> DeleteTask(int id)
        {
            var task = _repo.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            try
            {
                _repo.Delete(task);
                return Ok(task);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return _repo.TaskExists(id);
        }
    }
}