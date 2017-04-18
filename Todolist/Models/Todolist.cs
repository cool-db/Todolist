using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Todolist.Models
{
    public class Todolist
    {
        public static Object Select()
        {
            return TodolistHelper.ExecuteReader("select * from todolist");
        }

        public static Object Select(int i)
        {
            return TodolistHelper.ExecuteReader("select * from todolist where id=" + i);
        }

        public static Object Insert(Object data)
        {
            List<TodolistItem> list = JsonConvert.DeserializeObject<List<TodolistItem>>(data.ToString());
            var i = 0;
            foreach (TodolistItem item in list)
            {
                i += TodolistHelper.ExecuteNonQuery("insert into todolist(title,complete) values(" + "'" + item.Title +
                                                    "'" + "," + item.Complete + ")");
            }
            return i;
        }

        public static Object Dalete(Object data)
        {
            List<int> list = JsonConvert.DeserializeObject<List<int>>(data.ToString());
            return TodolistHelper.ExecuteNonQuery("delete from todolist where id=" + list[0]);
        }

        public static Object Update(Object data)
        {
            List<TodolistItem> list = JsonConvert.DeserializeObject<List<TodolistItem>>(data.ToString());
            TodolistItem item = list[0];
            return TodolistHelper.ExecuteNonQuery("UPDATE TODOLIST SET COMPLETE=" + item.Complete +","+ "TITLE='" +
                                                  item.Title + "' WHERE ID=" + item.Id);
        }
    }
}