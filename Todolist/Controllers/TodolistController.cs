using System;
using System.Collections.Generic;
using System.Web.Http;
using Todolist = Todolist.Models.Todolist;

namespace Todolist.Controllers
{
    public class TestController : ApiController
    {
        [System.Web.Mvc.HttpGet]
        public object GetAll()
        {
            return "Success";
        }

        [System.Web.Mvc.HttpGet]
        public object GetById(int id)
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
    }

    public class InsertController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public object Post(Object data)
        {
            return Models.Todolist.Insert(data);
        }
    }

    public class SelectController : ApiController
    {
        [System.Web.Mvc.HttpGet]
        public object Get()
        {
            return Models.Todolist.Select();
        }
    }

    public class DeleteController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public object Post(Object data)
        {
            return Models.Todolist.Dalete(data);
        }
    }

    public class UpdateController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public object Post(Object data)
        {
            return Models.Todolist.Update(data);
        }
    }
}