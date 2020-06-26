using DataBase.Model;
using System;
using System.Threading.Tasks;

namespace DataBase.Service
{
    public interface IDataBaseControlerService
    {
        Task FindItem(Action<object> parametrForFinded);
        Task DeleteItem(object currentItem);
        Task InsertItem(object addItem);
        Task UpdateItem(object updateItem);
        Task GetItems(Action<MyDbContext> action);
    }
}
