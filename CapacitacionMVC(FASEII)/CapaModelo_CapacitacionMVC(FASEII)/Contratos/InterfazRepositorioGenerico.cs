using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ESTA CLASE EXISTE UNICAMENTE PARA LA HEREDACIÓN Y EL POLIMORFISMO DE LOS REPOSITORIOS
//Se consideran las firmas de cada proceso a realizar en el crud

namespace CapaModelo_CapacitacionMVC_FASEII_.Contratos
{
    public interface InterfazRepositorioGenerico<Entity> where Entity : class
    {
        int Insertar(Entity entidad);
        int Actualizar(Entity entidad);
        int Eliminar(Entity entidad);
        IEnumerable<Entity> GetAll(); //Esta obtiene todos los datos
    }
}
