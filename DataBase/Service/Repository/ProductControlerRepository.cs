using DataBase.Model;
using DataBase.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Service.Repository
{
    public class ProductControlerRepository : IDataBaseControlerService
    {
        private SqlService sqlService;
        private MyDbContext myDbContext;
        private List<string> CategoryForFinded;

        public ProductControlerRepository(SqlService sqlService)
        {
            this.sqlService = sqlService;
        }

        public Task DeleteItem(object currentItem)
        {
            return Task.Run(() =>
            {
                using (myDbContext = new MyDbContext(sqlService.GetConnectionString()))
                {
                    var product = currentItem as Product;
                    if (product == null)
                    {
                        throw new System.Exception("Конкретная заявка не найдена");
                    }
                    if (myDbContext.Products.Select((select) => select.Id == product.Id).FirstOrDefault())
                    {
                        myDbContext.Products.Remove(product);
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
                foreach (var item in myDbContext.Products)
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
                    var currentItem = addItem as Product;
                    if (currentItem == null)
                    {
                        throw new System.Exception("Конкретная заявка не найдена");
                    }
                    if (!myDbContext.Products.Select((select) => select.Id == currentItem.Id).FirstOrDefault())
                    {
                        myDbContext.Products.Add(currentItem);
                    }
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
                    if (myDbContext.Products.Select((select) => select.Id == item.Id).FirstOrDefault())
                    {
                        myDbContext.Products.FirstOrDefault((select) => select.Id == item.Id);
                        myDbContext.SaveChanges();
                        myDbContext.Dispose();
                    }
                }
            });
        }
    }
}
