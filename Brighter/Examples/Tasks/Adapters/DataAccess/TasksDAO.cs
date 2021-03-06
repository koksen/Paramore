#region Licence
/* The MIT License (MIT)
Copyright � 2014 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the �Software�), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED �AS IS�, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

#endregion

using System.IO;
using System.Reflection;
using Simple.Data;
using Tasks.Model;

namespace Tasks.Adapters.DataAccess
{
    public class TasksDAO : ITasksDAO
    {
        private dynamic db;

        public TasksDAO()
        {

            if (System.Web.HttpContext.Current != null)
            {
                var databasePath = System.Web.HttpContext.Current.Server.MapPath("~\\App_Data\\Tasks.sdf");
                db = Database.Opener.OpenFile(databasePath);
            }
            else
            {
                var file =  Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)), "App_Data\\Tasks.sdf");
    
                db = Database.OpenFile(file);
            }
        }
 
        public Task Add(Task newTask)
        {
            return db.Tasks.Insert(newTask);
        }

        public void Update(Task task)
        {
            db.Tasks.UpdateById(task);
        }

        public void Clear()
        {
            db.Tasks.DeleteAll();
        }

        public Task FindById(int taskId)
        {
            return db.Tasks.FindById(taskId);
        }

        public Task FindByName(string taskName)
        {
            return db.Tasks.FindBy(taskName: taskName);
        }

    }
}