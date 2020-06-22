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
            _dataBaseControlerService.DeleteItem(currentItem);
            return default;
        }
        public Task FindItem(Action<object> parametrForFinded)
        {
            _dataBaseControlerService.FindItem(parametrForFinded);
            return Task.Delay(10);
        }

        public Task InsertItem(object addItem)
        {
            _dataBaseControlerService.InsertItem(addItem);
            return default;
        }

        public Task UpdateItem(object updateItem)
        {
            _dataBaseControlerService.UpdateItem(updateItem);
            return default;
        }
    }
}
