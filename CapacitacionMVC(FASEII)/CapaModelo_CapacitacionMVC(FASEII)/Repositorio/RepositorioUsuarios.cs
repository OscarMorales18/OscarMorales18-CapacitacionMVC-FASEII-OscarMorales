using CapaModelo_CapacitacionMVC_FASEII_.Contratos;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_CapacitacionMVC_FASEII_.Entidades;
//Para que fuyncione CommandType sin la necesidad de poner System.Data.CommandType
using System.Data;

//UNICA CLASE DE REPOSITÓRIO PARA USUARIOS (TABLA QUE ESCOGÍ)

namespace CapaModelo_CapacitacionMVC_FASEII_.Repositorio
{
    public class RepositorioUsuarios : RepositorioMaestro , InterfazRepositorioUsuarios
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;
        public RepositorioUsuarios()
        {
            selectAll = "SELECT * FROM usuarios";
            insert = "INSERT INTO usuarios (Usuario, Contrasena, Rol) VALUES (?, ?, ?)";
            update = "UPDATE usuarios SET Usuario = ?, Contrasena = ?, Rol = ? WHERE IdUsuario = ?";
            delete = "DELETE FROM usuarios WHERE IdUsuario = ?";
        }

        public int Insertar(Usuarios entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("Usuario", entidad.Usuario));
            _parametros.Add(new OdbcParameter("Contrasena", entidad.Contrasena));
            _parametros.Add(new OdbcParameter("Rol", entidad.Rol));
            _parametros.Add(new OdbcParameter("IdUsuario", entidad.IdUsuario));
            return EjecuccionNonQuery(insert, _parametros, CommandType.Text);
        }

        public int Actualizar(Usuarios entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("Usuario", entidad.Usuario));
            _parametros.Add(new OdbcParameter("Contrasena", entidad.Contrasena));
            _parametros.Add(new OdbcParameter("Rol", entidad.Rol));
            _parametros.Add(new OdbcParameter("IdUsuario", entidad.IdUsuario));
            return EjecuccionNonQuery(update, _parametros, CommandType.Text);
        }

        public int Eliminar(Usuarios entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("IdUsuario", entidad.IdUsuario));
            return EjecuccionNonQuery(delete, _parametros, CommandType.Text);
        }

        public IEnumerable<Usuarios> GetAll()
        {
            var lstUsuarios = new List<Usuarios>();
            var tblUsuarios = EjecucionConsulta(selectAll, CommandType.Text);
            foreach (DataRow row in tblUsuarios.Rows)
            {
                var usuario = new Usuarios();
                usuario.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                usuario.Usuario = row[1].ToString();
                usuario.Contrasena = row[2].ToString();
                usuario.Rol = row[3].ToString();    
                lstUsuarios.Add(usuario);
            }
            tblUsuarios.Clear();
            tblUsuarios = null;
            return lstUsuarios;
        }
    }
}
