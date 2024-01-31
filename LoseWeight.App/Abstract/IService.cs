namespace LoseWeight.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }
        List<T> GetAllItems();
        int GetLastId();
        T GetItemById(int id);
        T GetItemByName(string name);
        int AddItem(T item);
        void DeleteItem(T item);
        int UpdateItem(T item);
    }
}
