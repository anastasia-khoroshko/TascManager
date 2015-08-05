using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure;

namespace TascManager
{
    public interface ITascManager
    {
        void CreateToDoItem(IToDoItem todo);
        int CreateUser(string name);
        void DeleteToDoItem(int todoItemId);
        IEnumerable<IToDoItem> GetTodoList(int userId);
        void UpdateToDoItem(IToDoItem todo);
       // void SyncToDoItems();
    }
}
