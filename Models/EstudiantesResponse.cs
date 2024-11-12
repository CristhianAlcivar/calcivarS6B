using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.Controls.Internals.Profile;

namespace calcivarS6B.Models
{
    public  class EstudiantesResponse
    {
        public bool success { get; set; }
        public List<Estudiante> data { get; set; } 
        public object error { get; set; }
    }
}
