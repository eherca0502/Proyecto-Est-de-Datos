using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using Microsoft.VisualStudio.GraphModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PROYECTO_FINAL_ESTRUCTURA_DE_DATOS
{
    class ArbolBinario
    {
        int Profundidad = 0;

        int x = 650;
        int y = 30;
        int x1 = 650;
        int y1 = 30;
        public int indiceInorden = 0;
        int Xin = 120;
        private NodoArbol Auxiliar;
        public NodoArbol auxiliar
        {
            get { return Auxiliar; }
            set { Auxiliar = value; }
        }
        private NodoArbol Raiz;
        public NodoArbol raiz
        {
            get { return Raiz; }
            set { Raiz = value; }
        }
        private NodoArbol Anterior;
        public NodoArbol anterior
        {
            get { return Anterior; }
            set { Anterior = value; }
        }
        public string Salida = "";
        public int indice = 0;
        //Constructor e inicializador de variables de arbol binario
        public ArbolBinario()
        {
            auxiliar = null;
            raiz = null;
            anterior = null;
        }
        //Insertar Metodo Basico
        public void insertar(NodoArbol n)
        {
            if (Buscar(n.Dato) == true)
            {
                MessageBox.Show("Ya existe un nodo con ese valor", "No se puede insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ArbolBinario arbol = new ArbolBinario();
            //En caso de que no exista raiz quiere decir que 
            //nuestro arbol esta vacio y estamos insertando el primer nodo
            if (raiz == null)//si raiz == null(Si no hay nada en el arbol)
            {

                raiz = n;//La raiz se iguala al nodo que se va a insertar
                raiz.derecha = null;
                raiz.izquierda = null;

                //Derecha e izquierda son nulos 
                //pues acabamos de insertar el primer nodo

            }
            else//si raiz no es nulo
            {
                auxiliar = raiz;
                anterior = raiz;
                while (auxiliar != null)//Si auxiliar no es nulo
                {
                    if (n.Dato <= auxiliar.Dato)//si el valor del nodo a insertar es menor a el valor de auxiliar
                    {
                        anterior = auxiliar;
                        auxiliar = auxiliar.izquierda;
                    }
                    else//si el valor del nodo a insertar es mayor a el valor de auxiliar
                    {
                        anterior = auxiliar;
                        auxiliar = auxiliar.derecha;
                    }
                }
                if (n.Dato <= anterior.Dato)//Si el valor del nodo es menor que al anterior osea la raiz
                {

                    //Añadimos el nodo del lado izquierda pues la propiedad 
                    //de un arbol binario es que los valores inferiores que la 
                    //raiz van al lado izquierdo y las mayores al lado derecho
                    anterior.izquierda = n;
                }
                else//Si el valor del nodo no es menor que al anterior osea la raiz
                {

                    //Añadimos el nodo del lado derecho pues la propiedad 
                    //de un arbol binario es que los valores inferiores que la 
                    //raiz van al lado izquierdo y las mayores al lado derecho
                    anterior.derecha = n;
                }
                //igualamos izquierda y derecha de nuestro nodo a insertar pues,
                //se entiende que este al ser el ultimo agregado no tiene nodos hijos
                n.izquierda = null;
                n.derecha = null;
            }

        }
        //Insertar Metodo Con graficos
        public void insertar1(NodoArbol n, Graphics graphics, Form f)
        {
            if (Buscar(n.Dato) == true)
            {
                MessageBox.Show("Ya existe un nodo con ese valor", "No se puede insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Se llama a la clase arbol binario y se le da memoria
            ArbolBinario arbol = new ArbolBinario();
            //En caso de que no exista raiz quiere decir que 
            //nuestro arbol esta vacio y estamos insertando el primer nodo
            if (raiz == null)//si raiz == null(Si no hay nada en el arbol)
            {

                raiz = n;//La raiz se iguala al nodo que se va a insertar
                raiz.derecha = null;
                raiz.izquierda = null;
                graphics.FillEllipse(Brushes.Cyan, 650, 30, 35, 35);
                graphics.DrawString(n.Dato + "", f.Font, Brushes.Purple, 660, 40);
                Pen mynodoraiz = new Pen(Color.Orange, 3);
                graphics.DrawEllipse(mynodoraiz, 650, 30, 35, 35);
                //Derecha e izquierda son nulos 
                //pues acabamos de insertar el primer nodo
                MessageBox.Show("El Nodo fue añadido como Raíz", "Arbol Binario",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else//si raiz no es nulo
            {
                auxiliar = raiz;
                anterior = raiz;
                while (auxiliar != null)//Si auxiliar no es nulo
                {
                    if (n.Dato <= auxiliar.Dato)//si el valor del nodo a insertar es menor a el valor de auxiliar
                    {
                        anterior = auxiliar;
                        auxiliar = auxiliar.izquierda;
                        if (Profundidad == 0)
                        {
                            x -= 258;

                        }
                        if (Profundidad == 1)
                        {
                            x -= 135;

                        }
                        if (Profundidad == 2)
                        {
                            x -= 64;

                        }
                        if (Profundidad == 3)
                        {
                            x -= 32;

                        }

                    }
                    else//si el valor del nodo a insertar es mayor a el valor de auxiliar
                    {
                        anterior = auxiliar;
                        auxiliar = auxiliar.derecha;
                        if (Profundidad == 0)
                        {
                            x += 258;

                        }
                        if (Profundidad == 1)
                        {
                            x += 135;

                        }
                        if (Profundidad == 2)
                        {
                            x += 64;

                        }
                        if (Profundidad == 3)
                        {
                            x += 32;

                        }


                    }
                    y += 50;

                    Profundidad++;
                }
                if (n.Dato <= anterior.Dato)//Si el valor del nodo es menor que al anterior osea la raiz
                {

                    graphics.FillEllipse(Brushes.Cyan, x, y, 35, 35);
                    graphics.DrawString(n.Dato + "", f.Font, Brushes.Purple, x + 10, y + 10);
                    Pen mynodoraiz = new Pen(Color.Orange, 3);
                    graphics.DrawEllipse(mynodoraiz, x, y, 35, 35);

                    if (Profundidad == 0)
                    {
                        Pen mylinea = new Pen(Brushes.Orange, 2);
                        graphics.DrawLine(mylinea, x + 15, y + 10, x + 23, y - 20);

                    }
                    if (Profundidad == 1)
                    {
                        Pen mylinea = new Pen(Brushes.Orange, 2);
                        graphics.DrawLine(mylinea, x + 15, y + 10, x + 155, y - 20);
                    }
                    if (Profundidad == 2)
                    {
                        Pen mylinea = new Pen(Brushes.Orange, 2);
                        graphics.DrawLine(mylinea, x + 15, y + 10, x + 84, y - 20);
                    }
                    if (Profundidad == 3)
                    {
                        Pen mylinea = new Pen(Brushes.Orange, 2);
                        graphics.DrawLine(mylinea, x + 15, y + 10, x + 52, y - 20);
                    }

                    MessageBox.Show("El Nodo fue añadido por el lado Izquierdo", "Arbol Binario",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Añadimos el nodo del lado izquierda pues la propiedad 
                    //de un arbol binario es que los valores inferiores que la 
                    //raiz van al lado izquierdo y las mayores al lado derecho

                    anterior.izquierda = n;
                }
                else//Si el valor del nodo no es menor que al anterior osea la raiz
                {
                    graphics.FillEllipse(Brushes.Cyan, x, y, 35, 35);

                    graphics.DrawString(n.Dato + "", f.Font, Brushes.Purple, x + 10, y + 10);
                    Pen mynodoraiz = new Pen(Color.Orange, 3);
                    graphics.DrawEllipse(mynodoraiz, x, y, 35, 35);

                    if (Profundidad == 0)
                    {
                        Pen mylinea = new Pen(Brushes.Orange, 2);
                        graphics.DrawLine(mylinea, x + 15, y + 10, x - 278, y - 20);

                    }
                    if (Profundidad == 1)
                    {
                        Pen mylinea = new Pen(Brushes.Orange, 2);
                        graphics.DrawLine(mylinea, x + 15, y + 10, x - 155, y - 20);
                    }
                    if (Profundidad == 2)
                    {
                        Pen mylinea = new Pen(Brushes.Orange, 2);
                        graphics.DrawLine(mylinea, x + 15, y + 10, x - 84, y - 20);
                    }
                    if (Profundidad == 3)
                    {
                        Pen mylinea = new Pen(Brushes.Orange, 2);
                        graphics.DrawLine(mylinea, x + 10, y + 15, x - 52, y - 20);
                    }
                    MessageBox.Show("El Nodo fue añadido por el lado Derecho", "Arbol Binario",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Añadimos el nodo del lado derecho pues la propiedad 
                    //de un arbol binario es que los valores inferiores que la 
                    //raiz van al lado izquierdo y las mayores al lado derecho
                    anterior.derecha = n;
                }
                //igualamos izquierda y derecha de nuestro nodo a insertar pues,
                //se entiende que este al ser el ultimo agregado no tiene nodos hijos
                n.izquierda = null;
                n.derecha = null;
            }
            Profundidad = 0;
            x = 650;
            y = 30;
            x1 = 650;
            y1 = 30;
            indiceInorden = 0;
        }
        public void InOrden(NodoArbol n)
        {
            if (indice == 0)
            {
                Salida = "";
            }
            //En este metodo visitamos primero el lado izquierdo del arbol y luego el derecho

            if (n != null)
            {

                InOrden(n.izquierda);//Aqui recorremos recursivamente el arbol
                                     //primero se revisa la izquierda y cuando se llega al final de la izquierda entonces se escribe el valor
                Salida += n.Dato + " ";
                indice++;
                InOrden(n.derecha);
            }

        }
        //Método PreOrden
        public void PreOrden(NodoArbol aux)
        {
            if (indice == 0)
            {
                Salida = "";

            }

            if (aux != null)
            {
                //Este revisa primero la raiz y la escribe
                Salida += aux.Dato + " ";
                indice++;
                PreOrden(aux.izquierda);
                PreOrden(aux.derecha);
            }
        }
        //Método PostOrden
        public void PostOrden(NodoArbol aux)
        {
            if (indice == 0)
            {
                Salida = "";

            }
            //Este revisa primero el lado derecho
            //y la la raiz al final
            if (aux != null)
            {
                PostOrden(aux.izquierda);
                PostOrden(aux.derecha);
                Salida += aux.Dato + " ";
                indice++;

            }
        }
        public void EliminarNodo(int datoN)
        {
            NodoArbol find = this.raiz, prev = null;
            while ((find != null) && (!find.Dato.Equals(datoN)))
            {//Buscando el nodo con el dato que se desea eliminar, y tambien buscando y guardando al padre del mismo
                prev = find;
                if (datoN.CompareTo(find.Dato) < 0)
                {
                    find = find.izquierda;
                }
                else
                {
                    find = find.derecha;
                }
            }
            //find es el nodo con el valor a eliminar y prev es su padre
            if (find == null)
            {
                throw new Exception("No existe un nodo con ese dato");
            }
            int save = find.Dato;
            //save es una referencia al dato del nodo a eliminar
            NodoArbol n = find;
            //n es el nodo que va a quedar despues de la extraccion
            if (n.derecha == null)//No tiene sub arbol derecho
            {
                //Nodo con un descendiente izquierdo o una hoja
                n = n.izquierda;
            }
            else
            {

                if (n.izquierda == null)//No hay un sub arbol izquierdo
                {
                    //nodo con un decendiente o hoja
                    n = n.derecha;
                }
                else
                {
                    //nodo con dos descendientes

                    NodoArbol Last = n;
                    //Last es el padre del menor de los mayores
                    NodoArbol Temp = n.derecha;//a la derecha(1)
                                          //Se aplica la tecnica del menor de los mayores
                    while (Temp.izquierda != null)//Busca el menor de los mayores(2)
                    {
                        Last = Temp;
                        Temp = Temp.izquierda;
                    }
                    //realiza copia de contenidos
                    n.Dato = Temp.Dato;
                    //ajusta los enlaces
                    if (Last == n)
                    {
                        //no hay sub arbol izquierdo en el primer nodo de la derecha
                        Last.derecha = Temp.derecha;
                    }
                    else
                    {//last es el nodo anterior al menor de los mayores
                        Last.izquierda = Temp.izquierda;
                    }
                }

            }
            //Ajusta todo el arbol
            if (find == this.raiz)
            {

                this.raiz = n;
            }
            else
            {
                if (prev.izquierda == find)
                {
                    prev.izquierda = n;
                }
                else
                {
                    prev.derecha = n;
                }
            }
        }
        public bool Buscar(int Dato)
        {
            auxiliar = raiz;

            while (auxiliar != null)
            {
                if (Dato == auxiliar.Dato)
                {
                    return true;
                }
                if (auxiliar.izquierda == null && auxiliar.derecha == null)
                {
                    return false;
                }
                if (auxiliar.izquierda == null && auxiliar.derecha != null && Dato < auxiliar.Dato)
                {
                    return false;
                }
                if (auxiliar.derecha == null && auxiliar.izquierda != null && Dato > auxiliar.Dato)
                {
                    return false;
                }
                if (Dato > auxiliar.Dato && auxiliar.derecha != null)
                {
                    auxiliar = auxiliar.derecha;
                }
                else if (Dato < auxiliar.Dato && auxiliar.izquierda != null)
                {
                    auxiliar = auxiliar.izquierda;
                }



            }
            return false;

        }
    }
}
