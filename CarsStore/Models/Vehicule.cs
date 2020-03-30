﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Power { get; set; }
        public string Engine { get; set; }//diesel essence
        public double Price { get; set; }
        public string MainPicture { get; set; }
        public virtual List<String> Pictures { get; set; }

        public Vehicule()
        {
            Pictures = new List<string>();
        }
    }
}