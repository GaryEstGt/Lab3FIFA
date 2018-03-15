using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3FIFA
{
    public class Data<T>
    {
        private static Data<T> Instance;
        public static Data<T> instance
        {

            get
            {
                if (Instance == null)
                {
                    Instance = new Data<T>();
                }
                return Instance;
            }
            set { Instance = value; }
        }
                
        public Biblioteca.ArbolAVL<T> Arbol = new Biblioteca.ArbolAVL<T>();
        public int tipoCampo;
        public int orden = 0;
        public List<T> lista = new List<T>();
        public List<T> Listabuscada = new List<T>();
        public MedicionTiempos Tiempos = new MedicionTiempos();
        public string Log = string.Empty;
    }
}