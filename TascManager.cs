using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure;
using TascManager.ServiceTascManager;

namespace TascManager
{

    public class TascManager : ITascManager
    {
        private static ToDoManagerClient client;
        private static List<IToDoItem> items = new List<IToDoItem>();
        static TascManager()
        {
            client = new ToDoManagerClient();
        }
        public void CreateToDoItem(IToDoItem todo)
        {
            items.Add(todo);
            //SyncToDoItems();
        }

        public int CreateUser(string name)
        {
            return client.CreateUserAsync(name).Result;
        }

        public void DeleteToDoItem(int todoItemId)
        {
            int index = items.FindIndex(i => i.ToDoId == todoItemId);
            if (index != -1)
                items.RemoveAt(index);
            //SyncToDoItems();
        }

        public IEnumerable<IToDoItem> GetTodoList(int userId)
        {
            if (items == null || items.Count == 0)
            {
                items = client.GetTodoList(userId).Select(i => i as IToDoItem).ToList();
            }
            return items;
        }

        public void UpdateToDoItem(IToDoItem todo)
        {
            int index = items.FindIndex(i => i.ToDoId == todo.ToDoId);
            if (index != -1)
            {
                items.RemoveAt(index);
                items.Add(todo);
            }
            //SyncToDoItems();
        }

        //public void SyncToDoItems()
        //{

        //    if (channelFactory == null|| proxy==null)
        //    {
        //        channelFactory = new ChannelFactory<IServiceSync>(new BasicHttpBinding(), new EndpointAddress("http://PC/TascManager"));
        //        proxy = channelFactory.CreateChannel();
        //    }
        //    proxy.SyncToDoItems(items);
        //}
    }
}
