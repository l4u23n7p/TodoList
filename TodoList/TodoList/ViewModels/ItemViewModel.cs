using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.ViewModels
{
    class ItemViewModel
    {
        private static ObservableCollection<TodoItem> todoItems;
        public static ObservableCollection<TodoItem> TodoItems
        {
            get
            {
                if (todoItems == null)
                {
                    todoItems = new ObservableCollection<TodoItem>();
                    ItemsService.GetListItem();
                }

                return todoItems;
            }
        }

        public static void AddItem(TodoItem item)
        {
            if (!TodoItems.Contains(item))
                TodoItems.Add(item);
        }

        internal static void RefreshData()
        {
            TodoItems.Clear();
            ItemsService.GetListItem();
        }
    }

}
