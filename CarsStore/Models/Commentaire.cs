using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class Commentaire
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public virtual Publication Publication { get; set; }
        public virtual Client Client { get; set; }
    }
}