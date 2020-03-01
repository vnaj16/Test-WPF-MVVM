using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_WPF_MVVM.Models;

namespace Test_WPF_MVVM.Connectors
{
    public class DataBase
    {
        private static DataBase Instancia = null;
        PersonaCollection Lista = new PersonaCollection();
        private DataBase()
        {

        }

        public static DataBase GetInstancia()
        {
            if(Instancia is null)
            {
                Instancia = new DataBase();
            }

            return Instancia;
        }

        public PersonaCollection Listar_Personas()
        {

            Lista.Add(new Persona(1, "Arthur", new DateTime(1999, 10, 16)));
            Lista.Add(new Persona(2, "Javier", new DateTime(1999, 10, 17)));
            Lista.Add(new Persona(3, "Graciela", new DateTime(2000, 7, 24)));
            Lista.Add(new Persona(4, "Brigitte", new DateTime(2000, 7, 24)));


            return Lista;
        }

        public bool Eliminar_Persona(Persona obj)
        {
            Lista.Remove(obj);
            return true;
        }

    }
}
