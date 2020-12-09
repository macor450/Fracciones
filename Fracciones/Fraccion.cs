using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fracciones
{
    public class Fraccion
    {
        private int mynumerador;

        private int myEntero;

        public int MyEntero
        {
            get { return myEntero; }
            set { myEntero = value; }
        }


        public int MyNumerador
        {
            get { return mynumerador; }
            set { mynumerador = value; }
        }

        private int mydenominador;

        public int MyDenominador
        {
            get { return mydenominador; }
            set { mydenominador = value; }
        }

        public Fraccion(int e, int n, int d)
        { MyNumerador = n; MyDenominador = d;  if (d == 0) { d = 1; } MyDenominador = d;  MyEntero = e; }

        public Fraccion(int n, int d)
        { MyNumerador = n; MyDenominador = d; if (d == 0) { d = 1; } MyDenominador = d; MyEntero = 0; }

        public Fraccion Sumar(Fraccion otra)
        {
            int denominadorComun = MyDenominador * otra.MyDenominador;
            int e1 = otra.myEntero * denominadorComun;
            int n1 = (denominadorComun / MyDenominador) * MyNumerador;
            n1 += e1;
            int e2 = myEntero * denominadorComun;
            int n2 = (denominadorComun / otra.MyDenominador) * otra.MyNumerador;
            n1 += e2;
            Fraccion resultado = new Fraccion(n1 + n2, denominadorComun);
            resultado = Simplificar(resultado); 
            return resultado;
        }

        public Fraccion Restar(Fraccion otra)
        {
            int denominadorComun = MyDenominador * otra.MyDenominador;
            int e1 = myEntero * denominadorComun;
            int n1 = (denominadorComun / MyDenominador) * MyNumerador;
            n1 += e1;
            int e2 = myEntero * denominadorComun;
            int n2 = (denominadorComun / otra.MyDenominador) * otra.MyNumerador;
            n1 += e2;
            Fraccion resultado = new Fraccion(n1 - n2, denominadorComun);
            resultado = Simplificar(resultado);
            return resultado;
        }

        public Fraccion Multiplicar(Fraccion otra)
        {
            int n1 = MyNumerador + (myEntero * mydenominador);
            int n2 = otra.MyNumerador + (otra.MyEntero * otra.mydenominador);
            Fraccion resultado = new Fraccion(n1 * n2, MyDenominador * otra.MyDenominador);
            resultado = Simplificar(resultado);
            return resultado;
        }

        public Fraccion Dividir(Fraccion otra)
        {
            int n1 = MyNumerador + (myEntero * mydenominador);
            int n2 = otra.MyNumerador + (otra.MyEntero * otra.mydenominador);
            Fraccion resultado = new Fraccion(n1 * otra.MyDenominador, n2 * MyDenominador);
            resultado = Simplificar(resultado);
            return resultado;
        }

        public Fraccion Simplificar(Fraccion f)
        {
            Fraccion fraccionsimplificada;
            int n = (f.myEntero * f.mydenominador) + f.mynumerador;
            int d = f.mydenominador;
            int e = 0;
            bool negativo = false;
            if (n<0)
            {
                negativo = true;
                n *= -1;
            }
            int mcd = MaximoComunDivisor(n, d);
            if (mcd != 0)
            {
                n = n / mcd;
                d = d / mcd;
                if (n >= d)
                { e = n / d; n = n - (e * mydenominador); }
                if (negativo && e>0 ) { e *= -1; }
                if (negativo && e > 0) { e *= -1; }
            }
            fraccionsimplificada = new Fraccion(n, d);
            return fraccionsimplificada;
        }

        public int MaximoComunDivisor(int n, int d)
        {
            while(d != 0)
                {
                int t = d;
                d = n % d;
                n = t;
            }
            return n;
        }

        public override string ToString()
        {
          /*  if (MyEntero == && || 0)
            {
                return MyNumerador + "/" + MyDenominador;
            }*/ 

            if (MyNumerador==0)
            {
                return MyEntero + "";
            }

            if(MyEntero == 0)
            {
                return MyNumerador + "/" + MyDenominador;
            }
            return MyEntero + "" + MyNumerador + "/" + MyDenominador;
        }
    }
}
