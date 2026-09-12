using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_CapacitacionMVC_FASEII_.Contratos;
using CapaModelo_CapacitacionMVC_FASEII_.Entidades;
using CapaModelo_CapacitacionMVC_FASEII_.Repositorio;
//Objeto de visual studio que permite hacer validaciones
using System.ComponentModel.DataAnnotations;

//EN ESTA CLASE SE REALIZAN LAS VALIDACIONES DE LOS DATOS QUE SE RECIBEN DESDE LA VISTA, ANTES DE ENVIARLOS A LA CAPA MODELO

namespace CapaControlador_CapacitacionMVC_FASEII_.Modelos
{
    public class ModeloUsuarios
    {
        private int _idUsuario;
        private string _usuario;
        private string _contrasena;
        private string _rol;
        private InterfazRepositorioUsuarios RepositorioUsuarios;

        public EstadoEntidad Estado { private get; set; }
        private List<ModeloUsuarios> ListaUsuarios;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }

        //Validaciones de los datos que se reciben desde la vista
        //Primero se valida el campo, luego se hace el public string con el get y set

        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        [RegularExpression("^[a-zA-Z-ú ]+$", ErrorMessage = "El nombre del usuario solo debe contener letras")]
        [StringLength(maximumLength:25, MinimumLength = 3, ErrorMessage = "El nombre del usuario debe tener entre 3 y 25 caracteres")]
        public string Usuario { get => _usuario; set => _usuario = value; }

        [Required(ErrorMessage = "La contraseña del usuario es obligatoria")]
        [StringLength(maximumLength: 35, MinimumLength = 3, ErrorMessage = "La contraseña del usuario debe tener entre 3 y 35 caracteres")]
        public string Contrasena { get => _contrasena; set => _contrasena = value; }

        [Required(ErrorMessage = "El rol del usuario es obligatorio")]
        [RegularExpression("^[a-zA-Z-ú ]+$", ErrorMessage = "El rol del usuario solo debe contener letras")]
        [StringLength(maximumLength: 150, MinimumLength = 3, ErrorMessage = "El rol del usuario debe tener entre 3 y 150 caracteres")]
        public string Rol { get => _rol; set => _rol = value; }

        //Constructor

        private ModeloUsuarios()
        {
            RepositorioUsuarios = new RepositorioUsuarios();
        }

        //Llamado de los botones de la vista, para que se ejecuten las funciones de la capa modelo

        public string GrabarCambios()
        {
            string mensaje = null;
            try
            {
                var modeloDatosUsuarios = new Usuarios();
                modeloDatosUsuarios.IdUsuario = _idUsuario;
                modeloDatosUsuarios.Usuario = _usuario; 
                modeloDatosUsuarios.Contrasena = _contrasena;   
                modeloDatosUsuarios.Rol = _rol; 
                switch (Estado)
                {
                    case EstadoEntidad.Added:
                        RepositorioUsuarios.Insertar(modeloDatosUsuarios);
                        mensaje = "Usuario agregado correctamente";
                        break;
                    case EstadoEntidad.Modified:
                        RepositorioUsuarios.Actualizar(modeloDatosUsuarios);
                        mensaje = "Usuario modificado correctamente";
                        break;
                    case EstadoEntidad.Deleted:     
                        RepositorioUsuarios.Eliminar(modeloDatosUsuarios);
                        mensaje = "Usuario eliminado correctamente";
                        break;
                }
            } 
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            return mensaje;
        }

        public List<ModeloUsuarios> GetAll()
        {
            var modeloDatosUsuarios = RepositorioUsuarios.GetAll();
            ListaUsuarios = new List<ModeloUsuarios>();
            foreach (Usuarios item in modeloDatosUsuarios)
            {
                ListaUsuarios.Add(new ModeloUsuarios
                {
                    _idUsuario = item.IdUsuario,
                    _usuario = item.Usuario,
                    _contrasena = item.Contrasena,
                    _rol = item.Rol,
                });
            }
            return ListaUsuarios;
        }
        //Permite buscar por caracter
        public IEnumerable<ModeloUsuarios> FindbyId (string filter)
        {
            return ListaUsuarios.FindAll(e=> e._idUsuario.ToString().Contains(filter) || e._usuario.Contains(filter));
        }
    }
}
