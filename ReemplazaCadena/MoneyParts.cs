using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumatoriasMonto
{
    public class MoneyParts
    {
        public string build(decimal monto)
        {
            List<Decimal> listaMonedas = new List<Decimal>();            
            listaMonedas.Add(Convert.ToDecimal("0.05", CultureInfo.CreateSpecificCulture("en-US")));
            listaMonedas.Add(Convert.ToDecimal("0.1", CultureInfo.CreateSpecificCulture("en-US")));
            listaMonedas.Add(Convert.ToDecimal("0.2", CultureInfo.CreateSpecificCulture("en-US")));
            listaMonedas.Add(Convert.ToDecimal("0.5", CultureInfo.CreateSpecificCulture("en-US")));
            listaMonedas.Add(1);
            listaMonedas.Add(2);
            listaMonedas.Add(5);
            listaMonedas.Add(10);
            listaMonedas.Add(20);
            listaMonedas.Add(50);
            listaMonedas.Add(100);
            listaMonedas.Add(200);

            List<List<Decimal>> listaFinal = new List<List<Decimal>>();
            

            string cadenaDevolver = "";
            string cadenaCombinacionUnica = "";
            Decimal valorActual = 0;
            Decimal valorAdicional = 0;
            Decimal acumulado = 0;
            int tope = 0;            

            for (int i = 0; i < listaMonedas.Count(); i++)
            {
                valorActual = listaMonedas[i];

                //Nuevo Ini
                tope = (int)(monto / valorActual);
                while (tope > 0)
                {
                    List<Decimal> listaMonedasCombinadas = new List<Decimal>();
                    acumulado = 0;

                    for (int j = 0; j < tope; j++)
                    {
                        listaMonedasCombinadas.Add(valorActual);
                        acumulado = acumulado + valorActual;
                    }
                    
                    if (acumulado == monto)
                    {
                        listaFinal.Add(listaMonedasCombinadas);
                    }
                    else
                    {
                        if (acumulado < monto)
                        {
                            for (int k = 0; k < listaMonedas.Count(); k++)
                            {
                                if (i != k)
                                {
                                    valorAdicional = listaMonedas[k];
                                    if ((acumulado + valorAdicional) == monto)
                                    {
                                        listaMonedasCombinadas.Add(valorAdicional);
                                        listaFinal.Add(listaMonedasCombinadas);
                                    }
                                }
                            }
                        }
                    }
                    tope--;
                }
                //Fin Nuevo

                

            }

            if (listaFinal.Count()>0)
            {
                cadenaDevolver = "[";

                foreach (List<Decimal> miLista in listaFinal)
                {
                    if (miLista.Count>0)
                    {
                        cadenaDevolver = cadenaDevolver + "[";
                        cadenaCombinacionUnica = "";
                        foreach (Decimal item in miLista)
                        {
                            cadenaCombinacionUnica = cadenaCombinacionUnica + item + ",";
                        }
                        cadenaCombinacionUnica = cadenaCombinacionUnica.Remove(cadenaCombinacionUnica.LastIndexOf(","), 1);
                        cadenaDevolver = cadenaDevolver + cadenaCombinacionUnica + "],";
                    }
                    
                }
                cadenaDevolver = cadenaDevolver.Remove(cadenaDevolver.LastIndexOf(","), 1);
                cadenaDevolver = cadenaDevolver + "]";

            }               

            return cadenaDevolver;

        }

        static void Main(string[] args)
        {

            MoneyParts objetoPrueba = new MoneyParts();

            decimal monto = Convert.ToDecimal("10.5", CultureInfo.CreateSpecificCulture("en-US"));
            Console.WriteLine("Imprimiendo Combinaciones");
            Console.WriteLine(objetoPrueba.build(monto));           
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
