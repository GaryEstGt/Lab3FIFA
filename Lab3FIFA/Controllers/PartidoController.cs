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
                        Data<Partido>.instance.tipoCampo = 4;

                        break;
                    case "Fecha Partido":

                        Data<Partido>.instance.tipoCampo = 2;
                        break;
                    case "Grupo":
                        Data<Partido>.instance.tipoCampo = 1;
                        break;
                    case "Pais":
                        Data<Partido>.instance.tipoCampo = 0;
                        break;
                    case "Estadio":
                        Data<Partido>.instance.tipoCampo = 3;
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
            Data<Partido>.instance.lista.Clear();
            Data<Partido>.instance.Arbol.MostrarInOrden(ref Data<Partido>.instance.lista);
            return View(Data<Partido>.instance.lista);
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
        public ActionResult Delete(int id, string fecha,string grupo,string pais1,string pais2,string estadio, FormCollection collection)
        {
            try
            {
                Partido par = new Partido();
                foreach (var x in Data<Partido>.instance.lista)
                {
                    if (x.noPartido == id)
                    {
                        par = x;
                    }
                }
                
                if (Data<Partido>.instance.tipoCampo == 4)
                {
                    Data<Partido>.instance.Arbol.removeNodo(par, Partido.CompareByNoPartido);
                }
                else if (Data<Partido>.instance.tipoCampo == 0)
                {
                    Data<Partido>.instance.Arbol.removeNodo(par, Partido.CompareByPais1);
                }
                else if(Data<Partido>.instance.tipoCampo == 1)
                {
                    Data<Partido>.instance.Arbol.removeNodo(par, Partido.CompareByGroup);
                }
                else if (Data<Partido>.instance.tipoCampo == 2)
                {
                    Data<Partido>.instance.Arbol.removeNodo(par, Partido.CompareByFecha);
                }
                else if (Data<Partido>.instance.tipoCampo == 3)
                {
                    Data<Partido>.instance.Arbol.removeNodo(par, Partido.CompareByEstadio);
                }

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
                    if (Data<Partido>.instance.tipoCampo == 0)
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
                    else
                    {
                        Partido[] partido = JsonConvert.DeserializeObject<Partido[]>(csvData);
                        if (partido.Length == 1)
                        {
                            Data<Partido>.instance.Arbol.Insertar(partido[0], Partido.CompareByNoPartido);
                        }
                        else
                        {
                            for (int i = 0; i <= partido.Length - 1; i++)
                            {
                                Data<Partido>.instance.Arbol.Insertar(partido[i], Partido.CompareByNoPartido);
                            }
                        }
                    }

                }
                //  Pais p = new Pais {Id = 1, Name = "Brasil", Group = "A"};
                //Data<Pais>.instance.Arbol.removeNodo(p, Pais.CompareByName);
                //}
                // }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Busqueda()
        {
            return View(Data<Partido>.instance.Listabuscada);
        }

        // POST: Partido/Edit/5
        [HttpPost]
        public ActionResult Busqueda(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var Valor = collection["filter"];
                switch (Data<Partido>.instance.tipoCampo)
                {
                    case 0:
                        foreach (var item in Data<Partido>.instance.lista)
                        {
                            if (item.Pais1.Equals(Valor))
                            {
                                Data<Partido>.instance.Listabuscada.Add(item);
                            }
                        }
                        break;
                    case 1:
                        foreach (var item in Data<Partido>.instance.lista)
                        {
                            if (item.Grupo.Equals(Valor))
                            {
                                Data<Partido>.instance.Listabuscada.Add(item);
                            }
                        }
                        break;
                    case 2:
                        foreach (var item in Data<Partido>.instance.lista)
                        {
                            if (item.fechaPartido.Equals(Valor))
                            {
                                Data<Partido>.instance.Listabuscada.Add(item);
                            }
                        }
                        break;
                    case 3:
                        foreach (var item in Data<Partido>.instance.lista)
                        {
                            if (item.Estadio.Equals(Valor))
                            {
                                Data<Partido>.instance.Listabuscada.Add(item);
                            }
                        }
                        break;
                    case 4:
                        foreach (var item in Data<Partido>.instance.lista)
                        {
                            if (item.noPartido==Convert.ToInt16(Valor))
                            {
                                Data<Partido>.instance.Listabuscada.Add(item);
                            }
                        }
                        break;
                    default:
                        break;
                }
                return RedirectToAction("Busqueda");
            }
            catch
            {
                return View();
            }
        }
    }
}
