using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3FIFA.Models
{
    public class Partido
    {
        [Key]
        public int noPartido { get; set; }
        [Display(Name ="Fecha Partido")]
        public string fechaPartido { get; set; }
        [Display(Name = "Grupo")]
        public string Grupo { get; set; }
        [Display(Name = "Pais 1")]
        public string Pais1 { get; set; }
        [Display(Name = "Pais 2")]
        public string Pais2 { get; set; }
        [Display(Name = "Estadio")]
        public string Estadio { get; set; }

        public static Comparison<Partido> CompareByFecha = delegate (Partido p1, Partido p2)
        {
            return p1.fechaPartido.CompareTo(p2.fechaPartido);
        };

        public static Comparison<Partido> CompareByGroup = delegate (Partido p1, Partido p2)
        {
            return p1.Grupo.CompareTo(p2.Grupo);
        };
        public static Comparison<Partido> CompareByPais1 = delegate (Partido p1, Partido p2)
        {
            return p1.Pais1.CompareTo(p2.Pais1);
        };
        public static Comparison<Partido> CompareByEstadio = delegate (Partido p1, Partido p2)
        {
            return p1.Estadio.CompareTo(p2.Estadio);
        };
        public static Comparison<Partido> CompareByNoPartido = delegate (Partido p1, Partido p2)
        {
            return p1.noPartido.CompareTo(p2.noPartido);
        };
    }
}