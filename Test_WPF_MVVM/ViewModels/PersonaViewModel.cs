using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Test_WPF_MVVM.Connectors;
using Test_WPF_MVVM.Core.Commands;
using Test_WPF_MVVM.Models;

namespace Test_WPF_MVVM.ViewModels
{
    public class PersonaViewModel : IGeneric//Aqui va todo lo referente a persona
    {
        private PersonaCollection lista_persona = new PersonaCollection();

        public PersonaCollection Lista_Persona
        {
            get
            {
                return lista_persona;
            }

            set
            {
                lista_persona = value;

                if (value != null && value.Count > 0)//SI LA LISTA NO ESTA VACIA
                {
                    Current_Persona = value[0];
                }

                RaisePropertyChanged("Lista_Persona");
            }
        }

        private Persona current_persona; //me dice que persona esta seleccionada actualmente

        public Persona Current_Persona
        {
            get { return current_persona; }
            set
            {
                current_persona = value;
                RaisePropertyChanged("Current_Persona");
                RaisePropertyChanged("CanShowInfo");
            }
        }

        #region DEFINICION DE LOS COMANDOS
        private ICommand listar_personas_command;

        public ICommand Listar_Personas_Command
        {
            get
            {//PATRON SINGLETON
                if (listar_personas_command == null)
                {
                    listar_personas_command = new RelayCommand(new Action(Listar_Personas));
                }
                return listar_personas_command;
            }
        }


        private ICommand ver_info_command;

        public ICommand Ver_Info_Command
        {
            get
            {//PATRON SINGLETON
                if (ver_info_command == null)
                {
                    ver_info_command = new RelayCommand(new Action(Ver_Info), () => CanShowInfo);//Esto habilita el control que lo usa si es que se puede ejecutar el comando
                }
                return ver_info_command;
            }
        }


        private ICommand ver_info_generic_command;

        public ICommand Ver_Info_Generic_Command
        {
            get
            {//PATRON SINGLETON
                if (ver_info_generic_command == null)
                {
                    ver_info_generic_command = new ParamCommand(new Action<object>(Ver_InfoGeneric));//Esto habilita el control que lo usa si es que se puede ejecutar el comando
                }
                return ver_info_generic_command;
            }
        }

        private ICommand eliminar_persona_command;

        public ICommand Eliminar_Persona_Command
        {
            get
            {//PATRON SINGLETON
                if (eliminar_persona_command == null)
                {
                    eliminar_persona_command = new ParamCommand(new Action<object>(Eliminar_Persona));//Esto habilita el control que lo usa si es que se puede ejecutar el comando
                }
                return eliminar_persona_command;
            }
        }


        #endregion

        #region FUNCIONES Y PROPIEDADES QUE USAN LOS COMANDOS
        private void Listar_Personas()
        {
            Lista_Persona = DataBase.GetInstancia().Listar_Personas();

            /*if (!(current_persona is null))
                MessageBox.Show(Current_Persona.Nombre);
            else
                MessageBox.Show("Es null");*/
        }

        public void Ver_Info()
        {
            if (!(Current_Persona is null))
                MessageBox.Show(Current_Persona.ToString());
        }

        public void Ver_InfoGeneric(object obj)
        {
            if (!(Current_Persona is null))
            {
                Current_Persona = obj as Persona;
                MessageBox.Show(Current_Persona.ToString());
            }
        }

        public void Eliminar_Persona(object obj)
        {
            if (!(Current_Persona is null))
            {
                //Current_Persona = obj as Persona;
                if (DataBase.GetInstancia().Eliminar_Persona(obj as Persona))
                {
                    MessageBox.Show("Eliminado");

                    //Current_Persona = Lista_Persona[0];

                }
            }
            else
            {
                if (DataBase.GetInstancia().Eliminar_Persona(obj as Persona))
                {
                    MessageBox.Show("Eliminado");

                    //Current_Persona = Lista_Persona[0];

                }
            }

        }



        private bool CanShowInfo
        {
            get { return Current_Persona != null; }
        }

        #endregion

        public PersonaViewModel()
        {

        }

    }
}
