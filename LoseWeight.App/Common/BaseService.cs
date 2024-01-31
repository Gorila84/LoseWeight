using LoseWeight.App.Abstract;
using LoseWeight.Domain.Common;

namespace LoseWeight.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        public BaseService()
        {
            Items = new List<T>();
        }

       

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public void DeleteItem(T item)
        {
            Items.Remove(item);
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public T GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public T GetItemByName(string name)
        {
            var entity = Items.FirstOrDefault(x => x.Name == name);
            return entity;
        }
        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 1;
            }

            return lastId;
        }

        public int UpdateItem(T item)
        {
            var entity = Items.FirstOrDefault(x => x.Id == item.Id);
            if(entity != null)
            {
                entity = item;
            }

            return entity.Id;
        }
    }
}
