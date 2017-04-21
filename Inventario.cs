using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_De_Inventario
{
    class Inventario
    {
        private Producto primero;
        private Producto actual;
        private Producto anterior;
        //private Producto final;


        public void agregar(int codigo, string nombre, int cantidad, int costo)
        {
            Producto nuevoP = new Producto(codigo, nombre, cantidad, costo);
            if (primero == null)
                primero = nuevoP;
            else
            {
                actual = primero;
                while (actual != null && actual.Codigo < nuevoP.Codigo)
                {
                    anterior = actual;
                    actual = actual._Siguiente;
                }
                if (actual == null)
                {
                    actual = nuevoP;
                    anterior._Siguiente = actual;
                }
                else
                {
                    nuevoP._Siguiente = actual;
                    actual = nuevoP;
                    anterior._Siguiente = actual;
                }
            }
        }

        public void eliminar(string nombre)
        {
            if (primero.Nombre == nombre)
            {
                primero = primero._Siguiente;
            }
            else
            {
                actual = primero;
                while (actual._Siguiente.Nombre != nombre)
                {
                    actual = actual._Siguiente;
                }
                actual._Siguiente = actual._Siguiente._Siguiente;
            }
        }

        public string reporte()
        {
            string cadena="";
            actual = primero;
            while (actual != null)
            {
                cadena += actual.Codigo + "\r\n" + actual.Nombre + "\r\n" + actual.Cantidad + "\r\n" + actual.Costo + "\r\n\r\n";
                actual = actual._Siguiente;
            }
            return cadena;
        }

        public string buscar(string nombre)
        {
            string cadena = "";
            actual = primero;
            while (actual.Nombre != nombre)
            {
                actual = actual._Siguiente;
            }
            cadena += actual.Codigo + "\r\n" + actual.Nombre + "\r\n" + actual.Cantidad + "\r\n" + actual.Costo + "\r\n\r\n";
            return cadena;
        }

        /*public void insertar (int codigo, string nombre, int cantidad, int costo, int pos)
        {
            int cont = 1;
            Producto nuevoP = new Producto(codigo, nombre, cantidad, costo);
            actual = primero;
            if (pos == 1)
            {
                if (primero == null)
                    primero = nuevoP;
                else
                {
                    nuevoP._Siguiente = primero;
                    primero = nuevoP;
                }
            }
            else
            {
                cont++;
                while (cont != pos)
                {
                    cont++;
                    actual = actual._Siguiente;
                }
                nuevoP._Siguiente = actual._Siguiente;
                actual._Siguiente = nuevoP;
            }
            
        }

        public void agregaInicio(int codigo, string nombre, int cantidad, int costo)
        {
            Producto nuevoP = new Producto(codigo, nombre, cantidad, costo);
            if (primero == null)
                primero = nuevoP;
            else
            {
                nuevoP._Siguiente = primero;
                primero = nuevoP;
            }
        }

        public void agregaFinal(int codigo, string nombre, int cantidad, int costo)
        {
            Producto nuevoP = new Producto(codigo, nombre, cantidad, costo);
            if (primero == null)
            {
                primero = nuevoP;
                final = nuevoP;
            }
            else
            {
                final._Siguiente = nuevoP;
                final = final._Siguiente;
            }
        }*/
    }
}
