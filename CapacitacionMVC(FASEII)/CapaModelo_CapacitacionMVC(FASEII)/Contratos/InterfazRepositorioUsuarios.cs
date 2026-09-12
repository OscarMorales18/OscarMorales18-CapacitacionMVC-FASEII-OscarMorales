using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Con esto encuentra la clase usuarios para obtener sus atributos
using CapaModelo_CapacitacionMVC_FASEII_.Entidades;

//ESTA CLASE HEREDA DE LA INTERFAZ DE REPOSITORIO GENERICO, PARA PODER IMPLEMENTAR LOS MÉTODOS DE LA INTERFAZ EN EL REPOSITORIO DE USUARIOS

namespace CapaModelo_CapacitacionMVC_FASEII_.Contratos
{
    public  interface InterfazRepositorioUsuarios : InterfazRepositorioGenerico<Usuarios>
    {   

    }
}
