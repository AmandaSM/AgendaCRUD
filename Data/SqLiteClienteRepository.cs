using AgendaCrud.Model;
using Dapper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AgendaCrud.Data
{
    public class SqLiteClienteRepository : SqLiteBaseRepository, IClienteRepository
    {
        //SELECT
        public TbCliente GetTbCliente( long id)
        {
            if (!File.Exists(DbFile))
            {
                return null;
            }

            using(var cnn= SimpleDbConnection())
            {
                cnn.Open();
                TbCliente result = cnn.Query<TbCliente>(
                    @"SELECT id, nome, telefone 
                    FROM TbCliente
                    WHERE id=@id", new { id }).FirstOrDefault();
                return result;
            }
        }

        //INSERT
        public TbCliente SaveTbCliente(TbCliente tbCliente)
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }
            using(var cnn = SimpleDbConnection())
            {
                tbCliente.id = cnn.Query<int>
                    (
                        @"INSERT INTO TbCliente
                        ( nome, telefone) VALUES
                        (@nome, @telefone);
                         select last_insert_rowid()", tbCliente

                     ).First();
            }

            return tbCliente;
        }

        //Alter
        public void AlterarCliente(TbCliente tbCliente)
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }
            using (var cnn = SimpleDbConnection())
            {
                tbCliente.id = cnn.Execute
                    (
                        @"UPDATE  TbCliente SET
                         nome= @nome, telefone = @telefone WHERE
                          id=@id", tbCliente

                     );
            }

        }

        //Delete
        public void DeleteCliente(TbCliente tbCliente)
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }
            using (var cnn = SimpleDbConnection())
            {
                cnn.Execute
                    (
                        @"DELETE FROM TbCliente WHERE
                          id=@id", tbCliente

                     );
            }

        }

        //CREATE
        private static void CreateDatabase()
        {
            using(var cnn= SimpleDbConnection())
            {
                cnn.Open();
                cnn.Execute
                    (
                        @"create table TbCliente
                        (
                            id         integer primary key AUTOINCREMENT,
                            nome       varchar(30) not null,
                            telefone   varchar(15) not null
                         )"
                    );
            }
        }

        //Listas

        //lista Localizar
        public List<TbCliente> GetListaLocalizarCliente(string campo, string valor)
        {
            List<TbCliente> lista = new List<TbCliente>();


            if (!File.Exists(DbFile))
            {
                return null;
            }

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
               var result = cnn.Query<TbCliente>(
                    $@"SELECT id, nome, telefone 
                    FROM TbCliente
                    WHERE {campo} LIKE  @valor order by {campo} ", new {  valor=$"%{valor}%" }).AsList();

                if (result != null)
                {
                    lista = result;
                }
               
                
            }
            return lista;
        }
        //lista INSERIR
        public IEnumerable<TbCliente> GetListaCliente()
        {
            List<TbCliente> listaCliente = new List<TbCliente>();

            if (!File.Exists(DbFile))
            {
                return null;
            }

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                listaCliente = cnn.Query<TbCliente>(
                   @"SELECT id, nome, telefone 
                    FROM TbCliente"
                  ).ToList();

            }
            return listaCliente;
        }





    }
}
