using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.Services
{
    class ItemsService
    {
        const string baseUrl = "http://formation-roomy.inow.fr/api/todoitems";

        public static async Task<int> LastID()
        {
            string query = $"{baseUrl}";
            var result = await DataService.GetDataFromService(query).ConfigureAwait(false);
            int lastID = 0;

            if (result != null)
            {
                foreach (var r in result)
                {
                    TodoItem i = CreatedNewItem(r);
                    lastID = i.ID;
                }

                lastID += 1;

                return lastID;
            }

            return 0;
        }

        public static async Task<TodoItem> GetItem(int id)
        {
            string query = $"{baseUrl}/{id}";
            var result = await DataService.GetDataFromService(query).ConfigureAwait(false);
            if (result != null)
            {
                return CreatedNewItem(result);
            }
            else
                return null;
        }

        public static async void GetListItem()
        {
            string query = $"{baseUrl}";
            var result = await DataService.GetDataFromService(query).ConfigureAwait(false);

            if (result != null)
            {
                foreach (var r in result)
                {
                    ItemViewModel.AddItem(CreatedNewItem(r));
                }

            }

        }

        public static TodoItem CreatedNewItem(dynamic result)
        {
            TodoItem item = new TodoItem
            {
                ID = Convert.ToInt32(result["id"]),
                Text = result["text"],
                CreatedDate = Convert.ToDateTime(result["createdDate"]),
                Description = result["description"],
                IsDone = Convert.ToBoolean(result["isDone"]),
                DoneDate = result["doneDate"],
                Priority = Convert.ToInt32(result["priority"])
            };

            

            return item;
        }

        public static async Task<bool> UpdateItem(TodoItem item)
        {
            string query = $"{baseUrl}/{item.ID}";
            return await DataService.PutDataToService(item, query);
        }
        public static async Task<bool> AddNewItem(TodoItem item)
        {
            string query = $"{baseUrl}";
            return await DataService.PostDataToService(item, query);
        }
    }
}
