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

        public static Object Insert(Object json)
        {
            List<Object> data = JsonConvert.DeserializeObject<List<Object>>(json.ToString());
            TodolistHelper.ExecuteNonQuery("insert into todolist(title,complete) values('" + data[0] + "',0)");
            return TodolistHelper.ExecuteScalar("select INCREASE_SEQUENCE.currval from dual");
        }

        public static Object Dalete(Object json)
        {
            List<Object> data = JsonConvert.DeserializeObject<List<Object>>(json.ToString());
            return TodolistHelper.ExecuteNonQuery("delete from todolist where id=" + data[0]);
        }

        public static Object Update(Object json)
        {
            List<Object> data = JsonConvert.DeserializeObject<List<Object>>(json.ToString());
            return TodolistHelper.ExecuteNonQuery("UPDATE TODOLIST SET COMPLETE=" + data[2] + "," + "TITLE='"+data[1]+"' WHERE ID=" + data[0]);
        }
    }
}