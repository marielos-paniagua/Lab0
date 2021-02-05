using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab0.Models.Data;

namespace Lab0.Controllers
{
    public class ClientController : Controller
    {
        

        // GET: ClientController
        public ActionResult Index()
        {
            return View(Singleton.Instance.ClientList);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            var ViewClient = Singleton.Instance.ClientList.Find(x => x.id == id);
            return View(ViewClient);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newClient = new Models.Client
                {
                    id = Convert.ToInt32(collection["id"]),
                    Name = collection["Name"],
                    Surname = collection["Surname"],
                    Telephone = Convert.ToInt32(collection["Telephone"]),
                    Description = collection["Description"]
                };
                Singleton.Instance.ClientList.Add(newClient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            var ViewClient = Singleton.Instance.ClientList.Find(x => x.id == id);
            return View(ViewClient);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var ViewClient = Singleton.Instance.ClientList.Find(x => x.id == id);
                Singleton.Instance.ClientList.Remove(ViewClient);
                var newClient = new Models.Client
                {
                    id = Convert.ToInt32(collection["id"]),
                    Name = collection["Name"],
                    Surname = collection["Surname"],
                    Telephone = Convert.ToInt32(collection["Telephone"]),
                    Description = collection["Description"]
                };
                Singleton.Instance.ClientList.Add(newClient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/SortName/5
        public ActionResult SortName(int id)
        {
            for (int i = 0; i < Singleton.Instance.ClientList.Count -1; i++)
            {
                for (int j = 0; j < Singleton.Instance.ClientList.Count-i-1; j++)
                {
                    if (Compare(Singleton.Instance.ClientList[j].Name, Singleton.Instance.ClientList[j+1].Name))
                    {
                        Models.Client AuxClient = Singleton.Instance.ClientList[j];
                        Singleton.Instance.ClientList[j] = Singleton.Instance.ClientList[j + 1];
                        Singleton.Instance.ClientList[j + 1] = AuxClient;
                    }
                }
            }
            return View(Singleton.Instance.ClientList);
        }

        // GET: ClientController/SortSurName/5
        public ActionResult SortSurname(int id)
        {
            for (int i = 0; i < Singleton.Instance.ClientList.Count - 1; i++)
            {
                for (int j = 0; j < Singleton.Instance.ClientList.Count - i - 1; j++)
                {
                    if (Compare(Singleton.Instance.ClientList[j].Surname, Singleton.Instance.ClientList[j + 1].Surname))
                    {
                        Models.Client AuxClient = Singleton.Instance.ClientList[j];
                        Singleton.Instance.ClientList[j] = Singleton.Instance.ClientList[j + 1];
                        Singleton.Instance.ClientList[j + 1] = AuxClient;
                    }
                }
            }
            return View(Singleton.Instance.ClientList);
        }

        public bool Compare(String Name, String Nam)
        {
            int length = 0;
            if (Name.Length > Nam.Length)
            {
                length = Name.Length;
            }
            else if (Nam.Length > Name.Length)
            {
                length = Nam.Length;
            }

            for (int i = 0; i < length; i++)
            {
                if (i < Name.Length && i < Nam.Length)
                {
                    if (Name[i].CompareTo(Nam[i]) < 0)
                    {
                        return false;
                    }
                    else if (Name[i].CompareTo(Nam[i]) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (i >= Name.Length)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

    


        // POST: ClientController/SortName/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SortName(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ClientController/SortName/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SortSurname(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            var ViewClient = Singleton.Instance.ClientList.Find(x => x.id == id);
            return View(ViewClient);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var ViewClient = Singleton.Instance.ClientList.Find(x => x.id == id);
                Singleton.Instance.ClientList.Remove(ViewClient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
