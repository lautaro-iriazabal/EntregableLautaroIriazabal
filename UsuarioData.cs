using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregableLautaroIriazabal
{
    internal static class UsuarioData
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public static Usuario ObtenerUsuario(int id)
        {
            return usuarios.Find(u => u.Id == id);
        }

        public static List<Usuario> ListarUsuarios()
        {
            return usuarios;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public static void ModificarUsuario(int id, Usuario usuario)
        {
            var index = usuarios.FindIndex(u => u.Id == id);
            if (index != -1)
            {
                usuarios[index] = usuario;
            }
        }

        public static void EliminarUsuario(int id)
        {
            usuarios.RemoveAll(u => u.Id == id);
        }
    }
}
