using Lab3FIFA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3FIFA.Controllers
{
    public class PartidoController : Controller
    {
        public ActionResult ElegirCampo()
        {
            return View();
        }

        // POST: Jugador/ElegirLista
        [HttpPost]
        public ActionResult ElegirCampo(string submitButton)
        {
            try
            {
                switch (submitButton)
                {
                    case "No Partido":
                        
                        
                        break;
                    case "Fecha Partido":
                       
                        
                        break;
                    case "Grupo":
                       
                        break;
                    case "Pais":

                        break;
                    case "Estadio":

                        break;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Partido
        public ActionResult Index()
        {
            List<Partido> Temp = new List<Partido>();
            return View(Temp);
        }

        // GET: Partido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Partido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partido/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Partido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Partido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CrearPorArchivo()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult CrearPorArchivo(HttpPostedFileBase postedFile)
        {
            try
            {
                string todoeltexto = "";
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    int contLinea = 0;
                    string csvData = System.IO.File.ReadAllText(filePath);
                    /* foreach (string row in csvData.Split('}'))
                     {*/


                    /* if (!string.IsNullOrEmpty(row))
                     {*/
                    /**if (Data<Partido>.instance.tipoCampo == 0)
                    {
                        Partido[] partido = JsonConvert.DeserializeObject<Partido[]>(csvData);
                        if (partido.Length == 1)
                        {
                            Data<Partido>.instance.Arbol.Insertar(partido[0], Partido.CompareByPais1);
                        }
                        else
                        {
                            for (int i = 0; i <= partido.Length - 1; i++)
                            {
                                Data<Partido>.instance.Arbol.Insertar(partido[i], Partido.CompareByPais1);
                            }
                        }

                    }
                    else if (Data<Partido>.instance.tipoCampo == 1)
                    {
                        Partido[] partido = JsonConvert.DeserializeObject<Partido[]>(csvData);
                        if (partido.Length == 1)
                        {
                            Data<Partido>.instance.Arbol.Insertar(partido[0], Partido.CompareByGroup);
                        }
                        else
                        {
                            for (int i = 0; i <= partido.Length - 1; i++)
                            {
                                Data<Partido>.instance.Arbol.Insertar(partido[i], Partido.CompareByGroup);
                            }
                        }
                    }
                    else if(Data<Partido>.instance.tipoCampo == 2)
                    {
                        Partido[] partido = JsonConvert.DeserializeObject<Partido[]>(csvData);
                        if (partido.Length == 1)
                        {
                            Data<Partido>.instance.Arbol.Insertar(partido[0], Partido.CompareByFecha);
                        }
                        else
                        {
                            for (int i = 0; i <= partido.Length - 1; i++)
                            {
                                Data<Partido>.instance.Arbol.Insertar(partido[i], Partido.CompareByFecha);
                            }
                        }
                    }
                    else if(Data<Partido>.instance.tipoCampo == 3)
                    {
                        Partido[] partido = JsonConvert.DeserializeObject<Partido[]>(csvData);
                        if (partido.Length == 1)
                        {
                            Data<Partido>.instance.Arbol.Insertar(partido[0], Partido.CompareByEstadio);
                        }
                        else
                        {
                            for (int i = 0; i <= partido.Length - 1; i++)
                            {
                                Data<Partido>.instance.Arbol.Insertar(partido[i], Partido.CompareByEstadio);
                            }
                        }
                    }

                }*/
                //  Pais p = new Pais {Id = 1, Name = "Brasil", Group = "A"};
                //Data<Pais>.instance.Arbol.removeNodo(p, Pais.CompareByName);
                }
                //}
                // }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
