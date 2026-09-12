using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_CapacitacionMVC_FASEII_.Repositorio
{
    //La clase RepositorioMaestro hereda de la clase Repositorio; para que se conecte mediante el ODBC a la base de datos y pueda ejecutar los procedimientos almacenados que se encuentran en la base de datos.
    public abstract class RepositorioMaestro : Repositorio
    {
        //Las siguientes instrucciones almaceranán el contenido de un CRUD
        private DataTable dtTablaDatos; 
        public int EjecuccionNonQuery(String _comandoTexto, List<OdbcParameter> _parametros, CommandType _comandoTipo)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var ocComando = new OdbcCommand())
                {
                    ocComando.Connection = conexion;
                    ocComando.CommandText = _comandoTexto;
                    ocComando.CommandType = _comandoTipo;
                    ocComando.Parameters.Add(_parametros.ToArray());
                    //Aqui regresa todo lo que no sean consultas,es decir, insert, update, delete
                    return ocComando.ExecuteNonQuery();
                }
            }
        }   

        //Esta clase lleva el llenado de la tabla a nuestra capa controladora y ella a la capa de datos (métodos en diversas instancias)
        public DataTable EjecucionConsulta(String _comandoTexto, CommandType _comandoTipo)
        {
            dtTablaDatos = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var ocComando = new OdbcCommand())
                {
                    ocComando.Connection = conexion;
                    ocComando.CommandText = _comandoTexto;
                    ocComando.CommandType = _comandoTipo;
                    using (var reader = ocComando.ExecuteReader())
                        dtTablaDatos.Load(reader); //Llena la tabla de datos
                }
                return dtTablaDatos; //Regresa la tabla de datos
            }
        }
    }
}
