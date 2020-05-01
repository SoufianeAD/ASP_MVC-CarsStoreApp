using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Status { get; set; }//open or closed
        public virtual Vehicule Vehicule { get; set; }
    }
}