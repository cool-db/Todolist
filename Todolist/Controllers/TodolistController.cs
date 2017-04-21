using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.WebPages;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Todolist.Models;

namespace Todolist.Controllers
{
    public class TestController : ApiController
    {
        [System.Web.Mvc.HttpGet]
        public object GetAll()
        {
            Dictionary<Object, Object> dic = new Dictionary<Object, Object>();
            dic["string"] = "value1";
            dic["int"] = 2;
            dic["float"] = 2.1;
            dic["li"] = new List<int>() {1, 2, 3};
            dic["boolean"] = false;
            dic["object"] = new Object();
            dic["null"] = null;

            return dic;
        }

        [System.Web.Mvc.HttpGet]
        public object GetById(int id)
        {
            return id * id;
        }
    }

    public class InsertController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public int Post(Object json)
        {
            List<Object> data = JsonConvert.DeserializeObject<List<Object>>(json.ToString());
            TodolistHelper.ExecuteNonQuery("insert into todolist(title,complete) values('" + data[0] + "',0)");
            return TodolistHelper.ExecuteScalar("select increment_sequence.currval from dual").ToString().AsInt();
        }
    }

    public class SelectController : ApiController
    {
        [System.Web.Mvc.HttpGet]
        public object Get()
        {
            return TodolistHelper.ExecuteReader("select * from todolist");
        }
    }

    public class DeleteController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public object Post(Object json)
        {
            List<Object> data = JsonConvert.DeserializeObject<List<Object>>(json.ToString());
            return TodolistHelper.ExecuteNonQuery("delete from todolist where id=" + data[0]);
        }
    }

    public class UpdateController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public object Post(Object json)
        {
            List<Object> data = JsonConvert.DeserializeObject<List<Object>>(json.ToString());
            return TodolistHelper.ExecuteNonQuery("UPDATE TODOLIST SET COMPLETE=:complete,TITLE=:title WHERE ID=:id",
                new OracleParameter("id",data[0]),new OracleParameter("title",data[1]),new OracleParameter("complete",data[2]));
        }
    }
}