using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class Achat
    {
        public int Id { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public virtual Client Client { get; set; }
    }
}