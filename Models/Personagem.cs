using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Data;
using ProjetoDBZ.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDBZ.Models
{
    public class Personagem
    {
        
        public int Id { get; set; }
       
        public string Nome { get; set; }
        public string Tipo { get; set; }
    
    }
}