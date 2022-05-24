using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SafeDiningAdmin.Models;
using System.Diagnostics;

namespace SafeDiningAdmin.Controllers
{
    public class FirebaseController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "fUvVWFUPGju48M14LupYTRQzGhDNuXALSZE5K0kA",
            BasePath = "https://safedining-ir.firebaseio.com/"

        };
        IFirebaseClient client;
        
        public IActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Restaurants");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body); //assign response to dynamic object to avoid compile time type checking
            var list = new List<FirebaseData>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<FirebaseData>(((JProperty)item).Value.ToString()));
            }
            return View(list);
        }

        private void AddAdminToFirebase(FirebaseData t)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = t;
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Restaurants/"+ id);
            FirebaseData data = JsonConvert.DeserializeObject<FirebaseData>(response.Body);
            return View(data);
        }
        
        [HttpGet]
        public ActionResult Edit(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Restaurants/" + id);
            FirebaseData data = JsonConvert.DeserializeObject<FirebaseData>(response.Body);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(FirebaseData firebasedata)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client.UpdateAsync("Restaurants/" + firebasedata.id, firebasedata);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Delete("Restaurants/" + id);
            return RedirectToAction("Index");
        }
        static string passid;
        [HttpGet]
        public ActionResult Comments(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Restaurants/" + id + "/reviews");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body); //assign response to dynamic object to avoid compile time type checking
            passid = id;
            if (data != null)
            {
                var list = new List<FirebaseReviews>();
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<FirebaseReviews>(((JProperty)item).Value.ToString()));
                }
                return View(list);
            }
            else
            {
                var emptylist = new List<FirebaseReviews>();
                emptylist = null;
                return View(emptylist);
            }
        }

        [HttpGet]
        public ActionResult DeleteComment(string id)
        { 
            Debug.WriteLine("Restaurants/" + passid + "/reviews/" + id);
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Delete("Restaurants/" + passid + "/reviews/"+id);
            return RedirectToAction("Index");
        }
    }
}
