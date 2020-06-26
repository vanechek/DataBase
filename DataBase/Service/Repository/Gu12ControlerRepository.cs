using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Model;
using DataBase.Model.Table;


namespace DataBase.Service.Repository
{
    class Gu12ControlerRepository : IDataBaseControlerService
    {
        private SqlService sqlService;
        private MyDbContext myDbContext;
        private List<string> CategoryForFinded;
        public Gu12ControlerRepository(SqlService sqlService)
        {
            this.sqlService = sqlService;
            CategoryForFinded = new List<string>()
            {
                "Номер заявки",
                "Станция отправления",
                "Станция назначения",
                "Дата начало назначение",
                "Планируемая дата перевозки",
                "Номер продукта",
                "Номер отправки",
                "Номер Графика"
            };
        }

        public Task DeleteItem(object currentItem)
        {
            return Task.Run(() =>
            {
                using (myDbContext = new MyDbContext(sqlService.GetConnectionString()))
                {
                    var gu12 = currentItem as Gu12;
                    if (gu12 == null)
                    {
                        throw new System.Exception("Конкретная заявка не найдена");
                    }
                    if (myDbContext.Gu12s.Select((select) => select.Id == gu12.Id).FirstOrDefault())
                    {
                        myDbContext.Gu12s.Remove(gu12);
                        myDbContext.SaveChanges();
                        myDbContext.Dispose();
                    }
                }
            });
        }

        public Task FindItem(Action<object> parametrForFinded)
        {
            using (myDbContext = new MyDbContext(sqlService.GetConnectionString()))
            {
                foreach (var item in myDbContext.Gu12s)
                {
                    parametrForFinded?.Invoke(item);
                }
            }
            return Task.Delay(100);
        }

        public Task GetItems(Action<MyDbContext> action)
        {
            using (myDbContext = new MyDbContext(sqlService.GetConnectionString()))
            {
                action?.Invoke(myDbContext);
            }
            return Task.Delay(100);
        }

        public Task InsertItem(object addItem)
        {
            return Task.Run(() =>
            {
                using (myDbContext = new MyDbContext(sqlService.GetConnectionString()))
                {
                    var currentItem = addItem as Gu12;
                    if (currentItem == null)
                    {
                        throw new System.Exception("Конкретная заявка не найдена");
                    }
                    if (!myDbContext.Gu12s.Select((select) => select.Id == currentItem.Id).FirstOrDefault())
                    {
                        throw new Exception("Заявка уже создана");
                    }
                    myDbContext.Gu12s.Add(currentItem);
                    myDbContext.SaveChanges();
                }
            });
        }

        public Task UpdateItem(object updateItem)
        {
            return Task.Run(() =>
            {
                using (myDbContext = new MyDbContext(sqlService.GetConnectionString()))
                {
                    var item = updateItem as Gu12;
                    if (myDbContext.Gu12s.Select((select) => select.Id == item.Id).FirstOrDefault())
                    {
                        myDbContext.Gu12s.FirstOrDefault((select) => select.Id == item.Id);
                        myDbContext.SaveChanges();
                        myDbContext.Dispose();
                    }
                }
            });
        }
    }
}
