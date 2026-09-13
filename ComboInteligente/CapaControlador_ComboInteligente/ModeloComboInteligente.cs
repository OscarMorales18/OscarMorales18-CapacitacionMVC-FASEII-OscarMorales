using CapaModelo_ComboInteligente.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador_ComboInteligente
{
    public class ModeloComboInteligente
    {
        RepositorioComboInteligente sentencias = new RepositorioComboInteligente();

        public DataTable enviarDatos(string _tabla, string _campo1, string _campo2)
        {
            var dtTabla = sentencias.obtenerDatos(_tabla, _campo1, _campo2);
            return dtTabla;
        }
    }
}
