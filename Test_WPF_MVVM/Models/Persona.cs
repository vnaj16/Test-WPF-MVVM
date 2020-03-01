using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_WPF_MVVM.Models
{
    public class Persona
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private DateTime fecha_nacimiento;

		public DateTime Fecha_Nacimiento
		{
			get { return fecha_nacimiento; }
			set { fecha_nacimiento = value; }
		}

		public Persona()
		{

		}

		public Persona(int id, string name, DateTime fecha_nac)
		{
			this.ID = id;
			this.Nombre = name;
			this.Fecha_Nacimiento = fecha_nac;
		}

		public override string ToString()
		{
			return Nombre;
		}


	}
}
