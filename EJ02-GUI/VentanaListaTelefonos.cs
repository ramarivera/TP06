using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EJ02;

namespace EJ02_GUI
{
    public partial class VentanaListaTelefonos: Form
    {
        Persona persona;
        public VentanaListaTelefonos(Persona pPersona)
        {
            InitializeComponent();
            this.P
            this.Name = "Telefonos de "+pPersona.Nombre+" "+pPersona.Apellido;
        }
    }
}
