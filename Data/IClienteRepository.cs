using AgendaCrud.Model;
using System.Collections.Generic;

namespace AgendaCrud.Data
{
    public interface IClienteRepository
    {
        TbCliente GetTbCliente(long id);//pegando id da classe TbCliente
        TbCliente SaveTbCliente(TbCliente tbCliente);//salvar as informaçãoes da tabela, por iso está com paramentro a classe tbCliente, 
        void AlterarCliente(TbCliente tbCliente);
        void DeleteCliente(TbCliente tbCliente);
        IEnumerable<TbCliente> GetListaCliente();
        List<TbCliente> GetListaLocalizarCliente(string campo, string valor);

        

    }



}
