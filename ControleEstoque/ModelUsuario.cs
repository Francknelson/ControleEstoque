using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque
{
    public class ModelUsuario
    {
        internal void SetUsuario(DtoUsuario u)
        {
            Context db = new Context();
            db.usuario.Add(u);
            db.SaveChanges();
            
        }
       
        internal DtoUsuario GetUsuario(int id)
        {
            Context db = new Context();
            DtoUsuario usuario = db.usuario.FirstOrDefault(o => o.id == id);

            return usuario;
        }

        public List<DtoUsuarioLista> GetUsuarios()
        {
            Context db = new Context();

            List<DtoUsuarioLista> usuarios = (from u in db.usuario
                                            select new DtoUsuarioLista
                                            {
                                                id = u.id,
                                                nome = u.nome
                                            }).ToList();
            return usuarios;
        }

        internal void EditarUsuario(DtoUsuario u)
        {
            Context db = new Context();
            DtoUsuario usuario = db.usuario.FirstOrDefault(o => o.id == u.id);
            usuario.nome = u.nome;
            usuario.login = u.login;
            usuario.senha = u.senha;
            db.SaveChanges();
        }

        internal void DeletarUsuario(int id)
        {
            Context db = new Context();
            DtoUsuario usuario = db.usuario.FirstOrDefault(o => o.id == id);
            db.usuario.Remove(usuario);
            db.SaveChanges();
        }
    }
}
