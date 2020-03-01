using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_WPF_MVVM
{
    public class IGeneric : IEnlace
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string Property_name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(Property_name));
            }
        }
    }
}
