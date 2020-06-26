using DataBase.Model;
using System;
using System.Threading.Tasks;

namespace DataBase.Service
{
    public class DataBaseService
    {
        private IDataBaseControlerService _dataBaseControlerService;

        public DataBaseService(IDataBaseControlerService dataBaseControlerService)
        {
            _dataBaseControlerService = dataBaseControlerService;
        }

        public Task DeleteItem<T>(T currentItem)
        {
            return _dataBaseControlerService.DeleteItem(currentItem);
        }
        public Task FindItem(Action<object> parametrForFinded)
        {
            return _dataBaseControlerService.FindItem(parametrForFinded);
        }

        public Task InsertItem(object addItem)
        {
            return _dataBaseControlerService.InsertItem(addItem);
        }

        public Task UpdateItem(object updateItem)
        {
            return _dataBaseControlerService.UpdateItem(updateItem);
        }

        public Task GetItems(Action<MyDbContext> database)
        {
            return _dataBaseControlerService.GetItems(database);
        }
    }
}
