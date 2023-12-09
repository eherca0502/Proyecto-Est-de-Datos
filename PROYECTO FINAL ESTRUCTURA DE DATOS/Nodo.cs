using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL_ESTRUCTURA_DE_DATOS
{
    class Nodo
    {
        private Nodo siguiente;
        private int dato;
  
        public int Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public Nodo Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        public Nodo()
        {
            dato = 0;
            siguiente = null;
        }
        public override string ToString()
        {
            return dato.ToString();
        }
    }
}
