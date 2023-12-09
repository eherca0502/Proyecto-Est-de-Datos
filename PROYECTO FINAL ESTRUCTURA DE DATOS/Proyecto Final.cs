using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Drawing2D;

namespace PROYECTO_FINAL_ESTRUCTURA_DE_DATOS
{
    public partial class Form1 : Form
    {
        ArbolBinario Arbol;
        // variables globales
        private Grafo MiGrafo;
        private bool _agregandoNodo;
        private Point _posicionNodo;
        private string _nombreNodo;
        private Graphics g;
        private Pen Lapiz = new Pen(Color.Black, 3);
        private Brush Pincel = new SolidBrush(Color.Blue);
        private Brush PincelNodoBuscado = new SolidBrush(Color.Yellow);
        private Brush PincelFuente = new SolidBrush(Color.White);
        private Brush PincelFuentePeso = new SolidBrush(Color.Black);
        private Brush PincelFuenteNodoBuscado = new SolidBrush(Color.Black);
        private Pen LapizFuente = new Pen(Color.White, 1);
        private Pen LapizPeso = new Pen(Color.Black, 1);
        private Pen LapizArco = new Pen(Color.Red, 5);
        private Font Fuente = new Font("Calibri", 16, FontStyle.Bold);
        private Font FuentePeso = new Font("Calibri", 12, FontStyle.Bold);
        private Size Tamaño = new Size(40, 40);
        private Pen LapizCuadroPeso = new Pen(Color.Black, 3);
        private Brush PincelCuadroPeso = new SolidBrush(Color.White);
        private int TipoGrafo = 0; // 0 - dirigido, 1 - no dirigido
        private int numDeNodos = 0;

        private string[,] matrizAdyacencia;
        private string[] arregloDeVertices;

        // VARIABLES AUXILIARES PARA DIBUJAR GRAFO
        Rectangle R;
        Brush pincel;
        Point P1, P2, P3;
        StringFormat formato = new StringFormat();

        // FIN VARIABLES GLOBALES
        public Form1()
        {
            InitializeComponent();
            Arbol = new ArbolBinario();
            foreach (var con in Controls.OfType<Control>())
            {
                con.Hide();
                comboBox1.Show();
                btnEstructura.Show();

                this.Size = new Size(304, 115);
            }
        }
        Lista_doble_circular L = new Lista_doble_circular();
        Lista_simple Lista = new Lista_simple();
        Lista_doble lista = new Lista_doble();
        pilaArreglo pilas = new pilaArreglo();
        pilaListas pila = new pilaListas();
        Cola Cola = new Cola();
        Lista_circular ListaCircular = new Lista_circular();

        private void btnEstructura_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: //Lista simple
                    foreach (var con in Controls.OfType<Control>())
                    {
                        con.Hide();
                        comboBox1.Show();
                        btnEstructura.Show();
                        btnBuscarListaSimple.Show();
                        btnEliminarListaSimple.Show();
                        btnInsertarListaSimple.Show();
                        txtListaSimple.Show();
                        btnMostrarListasimple.Show();
                        this.Size = new Size(304, 212);
                    }
                    L.Head = null; Lista.Head = null; lista.P_Primero = null; ListaCircular.Head = null; Cola.frente = null; Arbol.raiz = null; break;
                case 1://Lista doble
                    foreach (var con in Controls.OfType<Control>())
                    {
                        con.Hide();
                        comboBox1.Show();
                        btnEstructura.Show();
                        btnBuscarListaDoble.Show();
                        btnEliminarListaDoble.Show();
                        btnInsertarListaDoble.Show();
                        txtListaDoble.Show();
                        btnMostrarListaDoble.Show();
                        this.Size = new Size(304, 212);
                    }
                    L.Head = null; Lista.Head = null; lista.P_Primero = null; ListaCircular.Head = null; Cola.frente = null; Arbol.raiz = null; break;
                case 2://Lista circular
                    foreach (var con in Controls.OfType<Control>())
                    {
                        con.Hide();
                        comboBox1.Show();
                        btnEstructura.Show();
                        btnBuscarListaCircular.Show();
                        btnEliminarListaCircular.Show();
                        btnInsertarListaCircular.Show();
                        txtListaCircular.Show();
                        btnMostrarListaCircular.Show();
                        this.Size = new Size(304, 212);
                    }
                    L.Head = null; Lista.Head = null; lista.P_Primero = null; ListaCircular.Head = null; Cola.frente = null; Arbol.raiz = null; break;
                case 3: //LDC
                    foreach (var con in Controls.OfType<Control>())
                    {
                        con.Hide();
                        comboBox1.Show();
                        btnEstructura.Show();
                        btnBuscar.Show();
                        btnEliminar.Show();
                        btnInsertar.Show();
                        txtDato.Show();
                        btnMostrar.Show();
                        this.Size = new Size(304, 212);
                    }
                    L.Head = null; Lista.Head = null; lista.P_Primero = null; ListaCircular.Head = null; Cola.frente = null; Arbol.raiz = null; break;
                case 4: //PILA
                    foreach (var con in Controls.OfType<Control>())
                    {
                        con.Hide();
                        comboBox1.Show();
                        btnEstructura.Show();
                        label1.Show();
                        label2.Show();
                        label3.Show();
                        label4.Show();
                        label5.Show();
                        label6.Show();
                        label7.Show();
                        lbltexto.Show();
                        txtpila.Show();
                        txtmaximo.Show();
                        txtNumeroLista.Show();
                        txtnumero.Show();
                        txtbuscararreglo.Show();
                        txtbuscarnodo.Show();
                        btncrear.Show();
                        btnpush.Show();
                        btnpop.Show();
                        button2.Show();
                        btnBuscarArr.Show();
                        BtnPUSHP.Show();
                        btnPopeliminar.Show();
                        btnbuscarnodo.Show();
                        btnCimaPilalista.Show();
                        this.Size = new Size(856, 514);
                    }
                    L.Head = null; Lista.Head = null; lista.P_Primero = null; ListaCircular.Head = null; Cola.frente = null; Arbol.raiz = null; break;
                case 5: ///// COLA //////
                    foreach (var con in Controls.OfType<Control>())
                    {
                        con.Hide();
                        comboBox1.Show();
                        btnEstructura.Show();
                        btnEliminarCola.Show();
                        btnInsertarCola.Show();
                        btnMostrarCola.Show();
                        txtCola.Show();
                        this.Size = new Size(304, 212);
                    }
                    L.Head = null; Lista.Head = null; lista.P_Primero = null; ListaCircular.Head = null; Cola.frente = null; Arbol.raiz = null; break;
                case 6: // ARBOL
                    foreach (var con in Controls.OfType<Control>())
                    {
                        con.Hide();
                        comboBox1.Show();
                        btnEstructura.Show();
                        button1.Show();
                        btnEliminarArbol.Show();
                        btnBuscarArbol.Show();
                        btnInOrden.Show();
                        btnInOrden.Show();
                        btnPostOrden.Show();
                        txtBuscarArbol.Show();
                        txtInsertarArbol.Show();
                        txtEliminarArbol.Show();
                        listBox1.Show();

                        this.Size = new Size(1386, 788);
                    }
                    L.Head = null; Lista.Head = null; lista.P_Primero = null; ListaCircular.Head = null; Cola.frente = null; Arbol.raiz = null; break;
                case 7:
                    foreach (var con in Controls.OfType<Control>())
                    {
                        con.Hide();
                        comboBox1.Show();
                        btnEstructura.Show();
                        cbTipoGrafo.Show();
                     
                        statusStrip1.Show();
                        gbRecorridos.Show();
       
                        gbGrafo.Show();
                        gbBuscar.Show();
                      
                        gbDistancia.Show();
      
                        gbGradoNodo.Show();
                        gbVertices.Show();
                        gbArcos.Show();
                        pbGrafo.Show();
                        btnCargarMatriz.Show();
                        txt1.Show();
                        txt2.Show();
                        btnGenerarMatriz.Show();
                        btnOrdMat.Show();
                        btnAbrir.Show();

                        this.Size = new Size(1386, 788);
                    }
                    L.Head = null; Lista.Head = null; lista.P_Primero = null; ListaCircular.Head = null; Cola.frente = null; Arbol.raiz = null; ; break;
                default: MessageBox.Show("Selecciona una estructura de datos"); break;
            }
        }
        //////////////////////////  LISTA DOBLE CIRCULAR  ///////////////////////////////
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (L.Head == null)
                {
                    NodoDoble n = new NodoDoble();
                    n.Dato = int.Parse(txtDato.Text);
                    L.Insertar(n);
                    MessageBox.Show("Nodo insertado exitosamente: " + L.ToString());
                    txtDato.Clear();
                    txtDato.Focus();
                    return;
                }

                if (L.Head != null)
                {
                    if (L.Buscar(int.Parse(txtDato.Text)) == true)
                    {
                        MessageBox.Show("El nodo que intentas ingresar ya existe");
                    }
                    else if (L.Buscar(int.Parse(txtDato.Text)) == false)
                    {
                        NodoDoble n = new NodoDoble();
                        n.Dato = int.Parse(txtDato.Text);
                        L.Insertar(n);
                        txtDato.Clear();
                        MessageBox.Show("Nodo insertado exitosamente: " + L.ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Te equivocaste");
            }
            txtDato.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDato.Text != "")
                {
                    int d = int.Parse(txtDato.Text);
                    if (L.Eliminar(d) == true)
                    {
                        MessageBox.Show("Nodo eliminado: " + L.ToString());
                    }
                    else if (L.Eliminar(d) == false)
                    {
                        MessageBox.Show("Nodo no encontrado");
                    }
                }
                else if (txtDato.Text == "")
                {
                    MessageBox.Show("Ingresa el dato del nodo a eliminar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hiciste algo mal");
            }
            txtDato.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (L.Head == null)
                {
                    MessageBox.Show("Lista vacia");
                    return;
                }
                if (L.Buscar(int.Parse(txtDato.Text)) == true)
                {
                    MessageBox.Show("Nodo encontrado");
                }
                else if (L.Buscar(int.Parse(txtDato.Text)) == false)
                {
                    MessageBox.Show("Nodo no encontrado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hiciste algo mal");
            }
            txtDato.Clear();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (L.Head == null)
            {
                MessageBox.Show("Lista vacia");
            }
            if (L.Head != null)
            {
                MessageBox.Show(L.ToString());
            }
        }
        /////////////////////////////////////// LISTA SIMPLE /////////////////////////////////////////////////////
        private void btnEliminarListaSimple_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtListaSimple.Text != "")
                {
                    int d = int.Parse(txtListaSimple.Text);
                    if (Lista.Eliminar(d) == true)
                    {
                        MessageBox.Show("Nodo eliminado: " + Lista.ToString());
                    }
                    else if (Lista.Eliminar(d) == false)
                    {
                        MessageBox.Show("Nodo no encontrado");
                    }
                }
                else if (txtListaSimple.Text == "")
                {
                    MessageBox.Show("Ingresa el dato del nodo a eliminar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hiciste algo mal");
            }
            txtListaSimple.Clear();
        }

        

        private void btnMostrarListasimple_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Lista.ToString());
        }

        private void btnInsertarListaSimple_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lista.Buscar(int.Parse(txtListaSimple.Text)) == true)
                {
                    txtListaSimple.Clear();
                    MessageBox.Show("El numero ya existe y no se puede duplicar, elige otro");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El dato ingresado no corresponde a un numero");
            }
            Nodo n = new Nodo();
            try
            {
                n.Dato = int.Parse(txtListaSimple.Text);
                txtListaSimple.Clear();
                Lista.Insertar(n);
                MessageBox.Show(Lista.ToString());
                txtListaSimple.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnBuscarListaSimple_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lista.Buscar(int.Parse(txtListaSimple.Text)) == false)
                {
                    MessageBox.Show("El dato buscado no existe");
                }

                if (Lista.Buscar(int.Parse(txtListaSimple.Text)) == true)
                {
                    MessageBox.Show("El nodo existe");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dato a buscar no es valido");
            }
        }
        /////////////////////////////////////// LISTA DOBLE /////////////////////////////////////////////////////
        private void btnInsertarListaDoble_Click(object sender, EventArgs e)
        {
            try
            {
                NodoDoble n = new NodoDoble();
                if (lista.BuscarNodo(int.Parse(txtListaDoble.Text)) == true)
                {
                    txtListaDoble.Clear();
                    MessageBox.Show("El NUMERO QUE ESTA NO ES POSIBLE DUPLICARSE");
                    return;
                }
                else
                {
                    n.Dato = int.Parse(txtListaDoble.Text);
                    lista.Insertarnodo(n);
                    MessageBox.Show(lista.DesplegarListaPU());

                }
                txtListaDoble.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("INGRESE UN DATO");
            }
        }

        private void btnBuscarListaDoble_Click(object sender, EventArgs e)
        {
            if (txtListaDoble.Text != "")
            {


                if (lista.BuscarNodo(int.Parse(txtListaDoble.Text)) == false)
                {
                    MessageBox.Show("El dato no existe");
                }

                if (lista.BuscarNodo(int.Parse(txtListaDoble.Text)) == true)
                {
                    MessageBox.Show("El dato " + txtListaDoble.Text + "   si existe");
                    txtListaDoble.Clear();
                }
            }
            else
            {
                MessageBox.Show("INGRESE UN DATO");
            }
        }

        private void btnEliminarListaDoble_Click(object sender, EventArgs e)
        {
            if (txtListaDoble.Text != "")
            {
                if (lista.BuscarNodo(int.Parse(txtListaDoble.Text)) == true)
                {
                    lista.EliminarNodo(int.Parse(txtListaDoble.Text));
                    txtListaDoble.Clear();
                    MessageBox.Show(lista.DesplegarListaPU());
                }
                else
                {
                    MessageBox.Show("El dato " + txtListaDoble.Text + " No existe en esta lista");
                    txtListaDoble.Clear();
                }
            }
            else
            {
                MessageBox.Show("INGRESE UN DATO");
            }
        }

        private void btnMostrarListaDoble_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lista.DesplegarListaPU());
        }
        ///////////////////////LISTA CIRCULAR//////////////////
        private void btnEliminarListaCircular_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtListaCircular.Text);
                txtListaCircular.Clear();
                if (ListaCircular.Eliminar(d) == true)
                {
                    MessageBox.Show("Nodo ha sido eliminado: " + ListaCircular.ToString());
                }
                else
                {
                    MessageBox.Show("Nodo no existe");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dato no valido");
            }
        }

        private void btnMostrarListaCircular_Click(object sender, EventArgs e)
        {
            if (ListaCircular.Head == null)
            {
                MessageBox.Show("Lista vacia");
            }
            if (ListaCircular.Head != null)
            {
                MessageBox.Show(ListaCircular.ToString());
            }
        }

        private void btnBuscarListaCircular_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaCircular.Buscar(int.Parse(txtListaCircular.Text)) == true)
                {
                    MessageBox.Show("Nodo encontrado");
                }
                else
                {
                    MessageBox.Show("Nodo no encontrado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El dato buscado no es valio...");
            }
            txtListaCircular.Clear();
        }

        private void btnInsertarListaCircular_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaCircular.Head == null)
                {
                    Nodo n = new Nodo();
                    n.Dato = int.Parse(txtListaCircular.Text);
                    ListaCircular.Insertar(n);
                    txtListaCircular.Clear();
                    MessageBox.Show("Nodo insertado exitosamente: " + ListaCircular.ToString());
                    txtListaCircular.Focus();
                    return;
                }

                if (ListaCircular.Head != null)
                {
                    if (ListaCircular.Buscar(int.Parse(txtListaCircular.Text)) == true)
                    {
                        MessageBox.Show("El nodo que intentas ingresar ya existe");
                        txtListaCircular.Clear();
                    }
                    else if (ListaCircular.Buscar(int.Parse(txtListaCircular.Text)) == false)
                    {
                        Nodo n = new Nodo();
                        n.Dato = int.Parse(txtListaCircular.Text);
                        ListaCircular.Insertar(n);
                        txtListaCircular.Clear();
                        MessageBox.Show("Nodo insertado exitosamente: " + ListaCircular.ToString());
                        txtListaCircular.Focus();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hiciste algo mal");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        ////////////////// PILA //////////////////////////////////
        private void btncrear_Click(object sender, EventArgs e)
        {
            if (txtmaximo.Text != "")
            {
                int m = int.Parse(txtmaximo.Text);
                pilas = new pilaArreglo(m);
                txtmaximo.Clear();
                txtnumero.Focus();
                MessageBox.Show("PILA CREADA");
            }
            else { MessageBox.Show("INGRESE EL TAMAÑO DE LA PILA"); }
        }

        private void btnpush_Click(object sender, EventArgs e)
        {
            if (txtnumero.Text != "")
            {
                int n = int.Parse(txtnumero.Text);
                pilas.push(n);
                txtpila.Text = pilas.ToString();
                txtmaximo.Clear();
                txtnumero.Clear();
                txtnumero.Focus();

            }
            else
            {
                MessageBox.Show("INGRESE UN NUMERO");
                txtnumero.Focus();
            }
        }

        private void btnpop_Click(object sender, EventArgs e)
        {
            if (!pilas.estaVacia)
            {
                string dato;
                dato = pilas.pop() + "";
                txtpila.Text = pilas.ToString();
            }
            else { MessageBox.Show("LA PILA ESTA VACIA"); }
        }

        private void btnBuscarArr_Click(object sender, EventArgs e)
        {
            if (txtbuscararreglo.Text != "")
                if (!pilas.Buscar(int.Parse(txtbuscararreglo.Text)) == true)
                {
                    MessageBox.Show("EL NODO CON EL DATO " + txtbuscararreglo.Text + " NO EXISTE EN LA PILA");
                    txtbuscararreglo.Text = "";
                    txtbuscararreglo.Focus();
                }
                else
                {
                    MessageBox.Show("EL NODO CON EL DATO " + txtbuscararreglo.Text + " SI EXISTE EN LA PILA");
                    txtbuscararreglo.Text = "";
                    txtbuscararreglo.Focus();
                }
            else
            {
                MessageBox.Show("INSERTE DATO A BUSCAR");
                txtbuscararreglo.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pilas.cima();
        }

        private void BtnPUSHP_Click(object sender, EventArgs e)
        {
            if (txtNumeroLista.Text != "")
            {
                Nodo n = new Nodo();
                n.Dato = int.Parse(txtNumeroLista.Text);
                pila.push(n);
                lbltexto.Text = pila.ToString();
                txtNumeroLista.Text = "";
                txtNumeroLista.Focus();
            }
            else
            {
                MessageBox.Show("INGRESE UN NUMERO");
                txtNumeroLista.Focus();
            }
        }

        private void btnPopeliminar_Click(object sender, EventArgs e)
        {
            if (pila.pop() == true)
            {

                lbltexto.Text = pila.ToString();
            }
            else
            {
                MessageBox.Show("LA PILA ESTA VACIA");

            }
        }

        private void btnbuscarnodo_Click(object sender, EventArgs e)
        {
            if (txtbuscarnodo.Text != "")
                if (!pila.Buscar(int.Parse(txtbuscarnodo.Text)) == true)
                {
                    MessageBox.Show("EL NODO CON EL DATO " + txtbuscarnodo.Text + " NO EXISTE EN LA PILA");
                    txtbuscarnodo.Text = "";
                    txtbuscarnodo.Focus();
                }
                else
                {
                    MessageBox.Show("EL NODO CON EL DATO " + txtbuscarnodo.Text + " SI EXISTE PILA");
                    txtbuscarnodo.Text = "";
                    txtbuscarnodo.Focus();
                }
            else
            {
                MessageBox.Show("INSERTE DATO A BUSCAR");
                txtbuscarnodo.Focus();
            }
        }

        private void btnCimaPilalista_Click(object sender, EventArgs e)
        {
            pila.CimaPila();
        }

        private void btnMostrarCola_Click(object sender, EventArgs e)
        {
            if (Cola.EstaVacia() == false)
            {
                MessageBox.Show(Cola.ToString());

            }
            if (Cola.EstaVacia())
            {
                MessageBox.Show("Cola vacia");
            }
        }

        private void btnEliminarCola_Click(object sender, EventArgs e)
        {
            if (Cola.EstaVacia() == false)
            {
                Cola.Eliminar();
                if (Cola.EstaVacia() == false)
                {
                    MessageBox.Show(Cola.ToString());
                }

            }

            if (Cola.EstaVacia())
            {
                MessageBox.Show("Cola vacia");
            }
        }

        private void btnInsertarCola_Click(object sender, EventArgs e)
        {
            if (txtCola.Text == "")
            {
                MessageBox.Show("Ingresa dato");

            }
            if (txtCola.Text != "")
            {

                Nodo n = new Nodo();
                n.Dato = int.Parse(txtCola.Text);
                Cola.Insertar(n);
                MessageBox.Show(Cola.ToString());
                txtCola.Clear();
            }
        }
        ////////// Arbol
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtInsertarArbol.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debes ingresar un valor entero en cuadro de texto", "Tipo de dato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInsertarArbol.Clear();
                txtInsertarArbol.Focus();
                return;
            }
            if (Arbol.Buscar(int.Parse(txtInsertarArbol.Text)) == false)
            {


                NodoArbol n = new NodoArbol();

                n.Dato = int.Parse(txtInsertarArbol.Text);

                Graphics nodo;
                nodo = CreateGraphics();
                Arbol.insertar1(n, nodo, this);
                txtInsertarArbol.Clear();
                txtInsertarArbol.Focus();
            }
            else
            {
                MessageBox.Show("Ya existe un nodo con ese valor", "No se puede insertar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }

        private void btnInOrden_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Arbol.raiz.Dato;
            }
            catch (Exception)
            {
                MessageBox.Show("No hay nodos en el arbol", "Arbol vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listBox1.Items.Clear();
            Arbol.indice = 0;
            NodoArbol n = new NodoArbol();
            n = Arbol.raiz;
            Arbol.InOrden(n);
            listBox1.Items.Add("In Orden");
            string[] coleccion = Arbol.Salida.Split(' ');
            for (int i = 0; i < coleccion.Length; i++)
            {
                if (coleccion[i] == "")
                {
                    break;
                }
                listBox1.Items.Add(coleccion[i]);
            }
        }

        private void btnPreOrden_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Arbol.raiz.Dato;
            }
            catch (Exception)
            {
                MessageBox.Show("No hay nodos en el arbol", "Arbol vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listBox1.Items.Clear();
            Arbol.indice = 0;
            NodoArbol n = new NodoArbol();
            n = Arbol.raiz;
            Arbol.PreOrden(n);
            listBox1.Items.Add("Pre Orden");
            string[] coleccion = Arbol.Salida.Split(' ');
            for (int i = 0; i < coleccion.Length; i++)
            {
                if (coleccion[i] == "")
                {
                    break;
                }
                listBox1.Items.Add(coleccion[i]);
            }
        }

        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Arbol.raiz.Dato;
            }
            catch (Exception)
            {
                MessageBox.Show("No hay nodos en el arbol", "Arbol vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listBox1.Items.Clear();
            Arbol.indice = 0;
            NodoArbol n = new NodoArbol();
            n = Arbol.raiz;
            Arbol.PostOrden(n);
            listBox1.Items.Add("Post Orden");
            string[] coleccion = Arbol.Salida.Split(' ');
            for (int i = 0; i < coleccion.Length; i++)
            {
                if (coleccion[i] == "")
                {
                    break;
                }
                listBox1.Items.Add(coleccion[i]);
            }
        }

        private void btnBuscarArbol_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtBuscarArbol.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debes ingresar un valor entero en cuadro de texto", "Tipo de dato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuscarArbol.Clear();
                txtBuscarArbol.Focus();
                return;
            }
            if (Arbol.Buscar(int.Parse(txtBuscarArbol.Text)) == true)
            {
                MessageBox.Show("El nodo con el numero " + txtBuscarArbol.Text + " existe", "Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El nodo con el numero " + txtBuscarArbol.Text + " no existe", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarArbol_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtEliminarArbol.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Debes ingresar un valor entero en cuadro de texto", "Tipo de dato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEliminarArbol.Clear();
                txtEliminarArbol.Focus();
                return;
            }
            if (Arbol.Buscar(int.Parse(txtEliminarArbol.Text)) == true)
            {
                NodoArbol Eliminado = new NodoArbol();
                Eliminado = Arbol.raiz;
                Arbol.EliminarNodo(int.Parse(txtEliminarArbol.Text));
            }
            else
            {
                MessageBox.Show("El nodo con el numero " + txtBuscarArbol.Text + " no existe, y por lo tanto no se puede eliminar", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizarInformacion(Grafo G)
        {
            lbVertices.Items.Clear();
            lbArcos.Items.Clear();
            foreach (KeyValuePair<string, Point> Vertice in G.Vertices)
            {
                lbVertices.Items.Add(Vertice.Key);
            }
            foreach (KeyValuePair<string, int> Arco in G.Arcos)
            {
                lbArcos.Items.Add(Arco.Key + "; Peso => " + Arco.Value);
            }
            DibujarGrafo(G);
        }
        private void frmGrafos_Load(object sender, EventArgs e)
        {
            MiGrafo = new Grafo(this.TipoGrafo);
            _agregandoNodo = false;
            g = pbGrafo.CreateGraphics();
            this.DoubleBuffered = true;
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            cbTipoGrafo.SelectedIndex = 0;
            this.ConfigurarFlecha();
            btnAbrir.Enabled = false;
            btnOrdMat.Enabled = false;
        }
        private void ConfigurarFlecha()
        {
            if (this.TipoGrafo == 0)
                LapizArco.EndCap = LineCap.ArrowAnchor;
            else
                LapizArco.EndCap = LineCap.Flat;
        }
        private void btNuevoGrafo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea crear un nuevo grafo?", "Nuevo grafo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MiGrafo = new Grafo(this.TipoGrafo);
                ActualizarInformacion(MiGrafo);
                VaciarTextBox();
                ConfigurarFlecha();
            }
        }
        private void btAgregarVertice_Click(object sender, EventArgs e)
        {
            string vertice = txAgregarVertice.Text.Trim();
            if (vertice == string.Empty) MessageBox.Show("Debe ingresar el nombre del vértice.");
            else
                if (MiGrafo.ExisteVertice(vertice)) MessageBox.Show("El vértice ya existe.");
            else
            {
                _agregandoNodo = true;
                _nombreNodo = vertice;
                pbGrafo.Focus();
                pbGrafo.Cursor = Cursors.Hand;
                HabilitacionElementos(false);
                MostrarIndicacion("Haga clic en la posición dónde desea ubicar el vértice.");
            }
        }
        private void HabilitacionElementos(bool valor)
        {
            gbArcos.Enabled = gbGrafo.Enabled = gbVertices.Enabled = gbBuscar.Enabled = gbRecorridos.Enabled = gbDistancia.Enabled = gbGradoNodo.Enabled = valor;
        }
        private void MostrarIndicacion(string mensaje)
        {
            lbIndicacion.Text = mensaje.Trim();
        }
        private void pbGrafo_MouseMove(object sender, MouseEventArgs e)
        {
            if (_agregandoNodo)
            {
                _posicionNodo = new Point(e.X, e.Y);
                DibujarGrafo(MiGrafo);
            }
        }
        private void DibujarGrafo(Grafo grafo, bool BuscarVertice = false, string VerticeBuscado = "", Queue<string> Rec = null)
        {
            g.Clear(Color.White);
            foreach (KeyValuePair<string, Point> Vertice in grafo.Vertices)
            {
                R = new Rectangle(Vertice.Value, Tamaño);
                g.DrawEllipse(Lapiz, R);
                g.FillEllipse(((BuscarVertice && Vertice.Key == VerticeBuscado) || (Rec != null && Rec.Contains(Vertice.Key))) ? PincelNodoBuscado : Pincel, R);
                pincel = ((BuscarVertice && Vertice.Key == VerticeBuscado) ? PincelFuenteNodoBuscado : PincelFuente);
                g.DrawString(Vertice.Key, Fuente, pincel, Vertice.Value + new Size(20, 20), formato);
            }
            foreach (KeyValuePair<string, int> Arco in grafo.Arcos)
            {
                try
                {
                    string[] nombresVertices = Arco.Key.Split('_');
                    P1 = MiGrafo.Vertices[nombresVertices[0]] + new Size(20, 20);
                    P2 = MiGrafo.Vertices[nombresVertices[1]] + new Size(20, 20);
                    if (P1.X < P2.X)
                    {
                        P1 += new Size(14, 0);
                        P2 -= new Size(14, 0);
                    }
                    else if (P2.X < P1.X)
                    {
                        P2 += new Size(14, 0);
                        P1 -= new Size(14, 0);
                    }
                    if (P1.Y < P2.Y)
                    {
                        P1 += new Size(0, 14);
                        P2 -= new Size(0, 14);
                    }
                    else
                    {
                        P2 += new Size(0, 14);
                        P1 -= new Size(0, 14);
                    }
                    P3 = MidPoint(P1, P2);
                    g.DrawLine(LapizArco, P1, P2);
                    R = new Rectangle(P3 - new Size(12, 10), new Size(25, 20));
                    g.DrawRectangle(LapizCuadroPeso, R);
                    g.FillRectangle(PincelCuadroPeso, R);
                    g.DrawString(Arco.Value.ToString(), FuentePeso, PincelFuentePeso, P3, formato);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (_agregandoNodo)
            {
                R = new Rectangle(_posicionNodo, Tamaño);
                g.DrawEllipse(Lapiz, R);
                g.FillEllipse(Pincel, R);
                g.DrawString(_nombreNodo, Fuente, PincelFuente, _posicionNodo + new Size(20, 20), formato);
            }
        }
        private static Point Punto23(Point P1, Point P2)
        {

            int x = (Math.Max(P1.X, P2.X) - Math.Min(P1.X, P2.X)) * 2 / 3 + Math.Min(P1.X, P2.X);

            int y = (Math.Max(P1.Y, P2.Y) - Math.Min(P1.Y, P2.Y)) * 2 / 3 + Math.Min(P1.Y, P2.Y);

            return new Point(x, y);
        }
        private static Point MidPoint(Point pt1, Point pt2)
        {
            var midX = (pt1.X + pt2.X) / 2;
            var midY = (pt1.Y + pt2.Y) / 2;
            return new Point(midX, midY);
        }
        private void pbGrafo_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pbGrafo_Click(object sender, EventArgs e)
        {
            if (_agregandoNodo)
            {
                MiGrafo.AgregarVertice(_nombreNodo, _posicionNodo);
                MostrarIndicacion(string.Empty);
                _agregandoNodo = false;
                HabilitacionElementos(true);
                pbGrafo.Cursor = Cursors.Default;
                ActualizarInformacion(MiGrafo);
                VaciarTextBox();
            }
        }
        private void VaciarTextBox()
        {
            txOrigen.Text = txDestino.Text = txAgregarVertice.Text = string.Empty;
            nuPeso.Value = 1;
        }
        private void btAgregarArco_Click(object sender, EventArgs e)
        {
            if (TipoGrafo == 1)
            {
                string Origen = txOrigen.Text.Trim();
                string Destino = txDestino.Text.Trim();
                int peso = Convert.ToInt32(nuPeso.Value);
                if (Origen != string.Empty && Destino != string.Empty)
                {
                    MiGrafo.AgregarArco(Origen, Destino, peso);
                    ActualizarInformacion(MiGrafo);
                    MiGrafo.AgregarArco(Destino, Origen, peso);
                    ActualizarInformacion(MiGrafo);
                    VaciarTextBox();
                }
                else
                {
                    MessageBox.Show("Debe ingresar los vértices origen y destino.");
                }
            }
            else
            {
                string Origen = txOrigen.Text.Trim();
                string Destino = txDestino.Text.Trim();
                int peso = Convert.ToInt32(nuPeso.Value);
                if (Origen != string.Empty && Destino != string.Empty)
                {
                    MiGrafo.AgregarArco(Origen, Destino, peso);
                    ActualizarInformacion(MiGrafo);
                    VaciarTextBox();
                }
                else
                {
                    MessageBox.Show("Debe ingresar los vértices origen y destino.");
                }
            }

        }
        private void btEliminarVertice_Click(object sender, EventArgs e)
        {
            if (lbVertices.Items.Count > 0)
            {
                if (lbVertices.SelectedItems.Count > 0)
                {
                    MiGrafo.EliminarVertice(lbVertices.SelectedItem.ToString());
                    ActualizarInformacion(MiGrafo);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el vértice a eliminar.");
                }
            }
            else
            {
                MessageBox.Show("No existen vértices en el grafo.");
            }
        }
        private void btEliminarArco_Click(object sender, EventArgs e)
        {
            if (lbArcos.Items.Count > 0)
            {
                if (lbArcos.SelectedItems.Count > 0)
                {
                    string[] verts = lbArcos.SelectedItem.ToString().Split(';')[0].Split('_');
                    MiGrafo.EliminarArco(verts[0], verts[1]);
                    ActualizarInformacion(MiGrafo);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el arco a eliminar.");
                }
            }
            else
            {
                MessageBox.Show("No existen arcos en el grafo.");
            }
        }
        private void frmGrafos_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.DibujarGrafo(MiGrafo);
            }
            catch (Exception)
            {
            }

        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string Vert = txtBuscar.Text.Trim();
            if (Text != string.Empty)
                if (MiGrafo.ExisteVertice(Vert))
                {
                    MessageBox.Show("Vertice encontrado. Se coloreará de amarillo.");
                    DibujarGrafo(MiGrafo, true, Vert);
                }
                else
                {
                    MessageBox.Show("Vertice NO encontrado.");
                    DibujarGrafo(MiGrafo);
                }
            else
                MessageBox.Show("Debe especificar el nombre del vértice a buscar");
        }
        private void btAnchura_Click(object sender, EventArgs e)
        {
            string ver = txtNodoRecorrido.Text.Trim();
            if (MiGrafo.ExisteVertice(ver) == true)
            {
                if (ver != string.Empty)
                {
                    Queue<string> Rec = MiGrafo.RecorridoAnchura(ver);
                    EjecutarRecorrido(Rec, false);
                }
                else
                {
                    MessageBox.Show("Debe digitar el nodo raiz");
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar un valor existente");
            }

        }
        private string ConcatenarLista(Queue<string> Lista, char Separador)
        {
            if (Lista.Count == 0) return string.Empty;
            string Texto = string.Empty;
            while (Lista.Count > 0)
                Texto += Lista.Dequeue() + Separador.ToString() + " ";
            return Texto.Substring(0, Texto.Length - 2);
        }
        private void btProfundidad_Click(object sender, EventArgs e)
        {

            string ver = txtNodoRecorrido.Text.Trim();
            if (MiGrafo.ExisteVertice(ver) == true)
            {
                if (ver != string.Empty)
                {
                    Queue<string> Rec = MiGrafo.RecorridoProfundidad(ver);
                    EjecutarRecorrido(Rec, true);
                }
                else
                {
                    MessageBox.Show("Debe digitar el nodo raiz");
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar un nodo existente");
            }

        }
        private void EjecutarRecorrido(Queue<string> Recorrido, bool tipo) // TIP0: true - Profundidad, false - Anchura
        {
            HabilitacionElementos(false);
            MessageBox.Show("El recorrido en " + ((tipo) ? "Profundidad" : "Anchura") + " va a iniciar...");
            Queue<string> Recorridos = new Queue<string>();
            foreach (string Nodo in Recorrido)
            {
                Recorridos.Enqueue(Nodo);
                this.DibujarGrafo(MiGrafo, false, string.Empty, Recorridos);
                Thread.Sleep(1000);
            }
            string Texto = "El recorrido en " + ((tipo) ? "Profundidad" : "Anchura") + " ha finalizado."
                + Environment.NewLine + "El recorrido es: " + ConcatenarLista(Recorrido, ',');
            MessageBox.Show(Texto);
            this.DibujarGrafo(MiGrafo);
            HabilitacionElementos(true);
        }
        private void txtCalcularDist_Click(object sender, EventArgs e)
        {
            string Origen = txtDist1.Text.Trim();
            string Destino = txtDist2.Text.Trim();
            if (Origen != string.Empty && Destino != string.Empty)
            {
                if (MiGrafo.ExisteVertice(Origen) == true)
                {
                    if (MiGrafo.ExisteVertice(Destino) == true)
                    {
                        try
                        {
                            Queue<string> Rec = MiGrafo.RecorridoAnchura(Origen);
                            ColorearCamino(Rec, Origen, Destino);

                            Dictionary<string, int> Distancias = this.MiGrafo.Dijkstra(Origen);
                            if (Distancias[Destino] == -1)
                                MessageBox.Show("No fue posible trazar un camino desde [" + Origen + "] hasta [" + Destino + "]");
                            else
                                MessageBox.Show("La longitud del camino entre los nodos [" + Origen
                                + "] y [" + Destino + "] es: " + Distancias[Destino]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Debe ingresar vértices existentes");
                            //throw ex;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Destino inexistente");
                    }
                }
                else
                {
                    MessageBox.Show("Origen inexistente");
                }


            }
            else
            {
                MessageBox.Show("Debe ingresar los vértices origen y destino.");
            }
        }
        private void cbTipoGrafo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TipoGrafo = cbTipoGrafo.SelectedIndex;
        }

        private void btnCalcularDijkstra_Click(object sender, EventArgs e)
        {
            string Origen = txtDist1.Text.Trim();
            string Destino = txtDist2.Text.Trim();
            if (Origen != string.Empty && Destino != string.Empty)
            {
                if (MiGrafo.ExisteVertice(Origen) == true)
                {
                    if (MiGrafo.ExisteVertice(Destino) == true)
                    {
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Debe ingresar vértices existentes");
                            //throw ex;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Destino inexistente");
                    }
                }
                else
                {
                    MessageBox.Show("Origen inexistente");
                }


            }
            else
            {
                MessageBox.Show("Debe ingresar los vértices origen y destino.");
            }
        }

        private void btnGenerarMatriz_Click(object sender, EventArgs e)
        {
            if (MiGrafo.Vertices.Count > 0)
            {
                matrizAdyacencia = new string[MiGrafo.Vertices.Count, MiGrafo.Vertices.Count];
                arregloDeVertices = new string[MiGrafo.Vertices.Count];


                int v = 0;
                foreach (KeyValuePair<string, Point> Vertice in MiGrafo.Vertices)
                {
                    arregloDeVertices[v] = (Vertice.Key);
                    v++;
                }
                v = 0;

                for (int i = 0; i < MiGrafo.Vertices.Count; i++)
                {
                    for (int j = 0; j < MiGrafo.Vertices.Count; j++)
                    {
                        matrizAdyacencia[i, j] = 0 + "";
                    }
                }

                string ruta = "";
                SaveFileDialog dialogo = new SaveFileDialog();
                //dialogo.ShowDialog();
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    ruta = dialogo.FileName;
                    string line = "";
                    using (StreamWriter file = new StreamWriter(ruta + ".txt", false))
                    {
                        int u = 0;
                        foreach (var item1 in MiGrafo.Arcos)
                        {
                            line = item1.Key + "_";
                            line += item1.Value;
                            if (MiGrafo.Arcos.Count == u)
                            {
                                file.Write(line);

                            }
                            else
                            {
                                file.WriteLine(line);
                                u++;
                            }
                        }
                        file.Close();
                    }
                    btnAbrir.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Debe haber al menos un vértice en el grafo");
            }



        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string ruta = "";
                ruta = dialogo.FileName;

                string[] a = File.ReadAllLines(ruta);
                int p = 0;
                foreach (string linea in a)
                {
                    string[] lineaSpliteada = linea.Split('_');
                    matrizAdyacencia[Array.IndexOf(arregloDeVertices, lineaSpliteada[0]), Array.IndexOf(arregloDeVertices, lineaSpliteada[1])] = lineaSpliteada[2];
                    if (TipoGrafo == 1)
                    {
                        p++;
                        if (p > MiGrafo.Arcos.Count)
                        {
                            break;
                        }
                    }
                    else
                    {
                        p++;
                        if (p > (MiGrafo.Arcos.Count))
                        {
                            break;
                        }
                    }
                }
                p = 0;
                using (StreamWriter file = new StreamWriter(ruta + ".txt", false))
                {

                    for (int i = 0; i < MiGrafo.Vertices.Count; i++)
                    {
                        for (int j = 0; j < MiGrafo.Vertices.Count; j++)
                        {
                            file.Write(matrizAdyacencia[i, j] + " ");
                        }
                        file.WriteLine();

                    }
                    file.Close();
                }
                btnOrdMat.Enabled = true;

            }

        }

        private void btnOrdMat_Click(object sender, EventArgs e)
        {
            string ruta = "";
            SaveFileDialog dialogo = new SaveFileDialog();
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                ruta = dialogo.FileName;
                string line = "";
                using (StreamWriter file = new StreamWriter(ruta + ".txt", false))
                {
                    int i = 0;
                    int j = 0;
                    for (i = 0; i < MiGrafo.Vertices.Count; i++)
                        file.Write("\t{0}", arregloDeVertices[i]);

                    file.WriteLine();
                    for (i = 0; i < MiGrafo.Vertices.Count; i++)
                    {
                        file.Write(arregloDeVertices[i]);
                        for (j = 0; j < MiGrafo.Vertices.Count; j++)
                        {
                            file.Write("\t{0}", matrizAdyacencia[i, j] + "");
                        }
                        file.WriteLine();

                    }
                    file.Close();
                }

            }

        }

        private void btnCargarMatriz_Click(object sender, EventArgs e)
        {
            try
            {

                int inicio = 0;
                int final = 0;
                string inicio2 = "";
                string final2 = "";
                int distancia = 0;
                int n = 0;
                int cantNodos = 7;
                string dato = "";
                int actual = 0;
                int columna = 0;

                //Crearemos el grafo
                CGrafo unGrafo = new CGrafo(cantNodos);

                //unGrafo.AdicionaArista(0, 1, 2);
                //unGrafo.AdicionaArista(0, 3, 1);
                //unGrafo.AdicionaArista(1, 3, 3);
                //unGrafo.AdicionaArista(1, 4, 10);
                //unGrafo.AdicionaArista(2, 0, 4);
                //unGrafo.AdicionaArista(2, 5, 5);
                //unGrafo.AdicionaArista(3, 2, 2);
                //unGrafo.AdicionaArista(3, 4, 2);
                //unGrafo.AdicionaArista(3, 5, 8);
                //unGrafo.AdicionaArista(3, 6, 4);
                //unGrafo.AdicionaArista(4, 6, 6);
                //unGrafo.AdicionaArista(6, 5, 1);

                int[,] matrizAdyacenciaInt = new int[matrizAdyacencia.GetLength(0), matrizAdyacencia.GetLength(0)];
                cantNodos = matrizAdyacenciaInt.GetLength(0);

                for (int i = 0; i < matrizAdyacencia.GetLength(0); i++)
                {
                    for (int j = 0; j < matrizAdyacencia.GetLength(0); j++)
                    {
                        matrizAdyacenciaInt[i, j] = Convert.ToInt32(matrizAdyacencia[i, j]);
                        unGrafo.AdicionaArista(i, j, matrizAdyacenciaInt[i, j]);

                    }
                }

                unGrafo.MuestraAdyacencia();

                inicio2 = txt1.Text;
                final2 = txt2.Text;
                inicio = Array.IndexOf(arregloDeVertices, inicio2);
                final = Array.IndexOf(arregloDeVertices, final2);

                //inicio = Convert.ToInt32(txt1.Text);
                //final = Convert.ToInt32(txt2.Text);

                //Creamos la tabla
                //0 - Visitado
                //1 - Distancia
                //2 - Previo
                int[,] tabla = new int[cantNodos, 3];

                //Inicializamos la tabla
                for (n = 0; n < cantNodos; n++)
                {
                    tabla[n, 0] = 0;
                    tabla[n, 1] = int.MaxValue;
                    tabla[n, 2] = 0;
                }
                tabla[inicio, 1] = 0;
                MostrarTabla(tabla);

                //Inicio Dijkstra
                actual = inicio;
                do
                {
                    //Marcar nodo como visitado
                    tabla[actual, 0] = 1;

                    for (columna = 0; columna < cantNodos; columna++)
                    {
                        //Buscamos a quien se dirige
                        if (unGrafo.ObtenAdyacencia(actual, columna) != 0)
                        {
                            //Calculamos la distancia
                            distancia = unGrafo.ObtenAdyacencia(actual, columna) + tabla[actual, 1];
                            //Colocamos las distancias
                            if (distancia < tabla[columna, 1])
                            {
                                tabla[columna, 1] = distancia;

                                //Colocamos la informacion de padre
                                tabla[columna, 2] = actual;

                            }
                        }
                    }
                    //El nuevo actual es el nodo con la menor distancia que no ha sido visitado
                    int indiceMenor = -1;
                    int distanciaMenor = int.MaxValue;

                    for (int x = 0; x < cantNodos; x++)
                    {
                        if (tabla[x, 1] < distanciaMenor && tabla[x, 0] == 0)
                        {
                            indiceMenor = x;
                            distanciaMenor = tabla[x, 1];
                        }
                    }

                    actual = indiceMenor;
                } while (actual != -1);

                MostrarTabla(tabla);

                //Obtenemos la ruta
                List<int> ruta = new List<int>();
                int nodo = final;

                while (nodo != inicio)
                {
                    ruta.Add(nodo);
                    nodo = tabla[nodo, 2];
                }
                ruta.Add(inicio);

                ruta.Reverse();

                foreach (int posicion in ruta)
                {
                    Console.Write("{0}-->", posicion);
                }
                Console.WriteLine("---");
                foreach (int posicion in ruta)
                {
                    Console.Write("{0}-->", arregloDeVertices[posicion]);
                }
                Console.WriteLine();
                Console.ReadLine();

            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese valores numéricos con nodos existentes");
            }

        }

        public static void MostrarTabla(int[,] pTabla)
        {
            int n = 0;

            for (n = 0; n < pTabla.GetLength(0); n++)
            {
                Console.WriteLine("{0}--> {1}\t{2}\t{3}", n, pTabla[n, 0], pTabla[n, 1], pTabla[n, 2]);
            }
            Console.WriteLine("------");
        }

        private void btCalcularGrado_Click(object sender, EventArgs e)
        {
            string vert = txtGradoNodo.Text.Trim();
            if (vert == string.Empty)
                MessageBox.Show("Debe ingresar el nombre de un vértice.");
            else
                this.MiGrafo.GradoVertice(vert);
        }


        private void ColorearCamino(Queue<string> Recorrido, string origen, string destino)
        {
            HabilitacionElementos(false);
            MessageBox.Show("El camino es...");
            Queue<string> Recorridos = new Queue<string>();
            bool Recorriendo = false;
            foreach (string Nodo in Recorrido)
            {
                Recorridos.Enqueue(Nodo);
                if (Nodo == origen)
                {
                    Recorriendo = true;
                    Recorridos.Enqueue(Nodo);
                    this.DibujarGrafo(MiGrafo, false, string.Empty, Recorridos);
                    Thread.Sleep(1000);
                }
                else if (Recorriendo)
                {
                    if (Nodo == destino)
                        Recorriendo = false;
                    this.DibujarGrafo(MiGrafo, false, string.Empty, Recorridos);
                    Thread.Sleep(1000);
                }

            }
            string Texto = "El camino ha finalizado.";
            this.DibujarGrafo(MiGrafo);
            HabilitacionElementos(true);
        }
    }
}

