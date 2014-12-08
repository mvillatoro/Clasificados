using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace MiPrimerMVC.Models
{
    public class MessagesModel
    {
        public string Receptor { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public string Mail { get; set; }
        public int ReceptorId { get; set; }
        public string SenderId { get; set; }
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public int Myid { get; set; }


        public List<Messages> MessageList { get; set; } 

    }
}