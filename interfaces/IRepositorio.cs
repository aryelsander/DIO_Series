namespace DIO_Series.Interfaces
{  
    using System.Collections.Generic;
    public interface IRepositorio<T>
    {
         List<T>Lista();
         T RetornoPorId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id,T entidade);
         int ProximoId();
    }
}