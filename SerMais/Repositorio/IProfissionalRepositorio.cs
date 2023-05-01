using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IProfissionalRepositorio
    {
        void AtualizaAtivoProfissional(ProfissionalModel profissional);
        ProfissionalModel Inserir(ProfissionalModel profissional);
        ProfissionalModel ObterPorId(int id);
        List<ProfissionalModel> BuscarTodos();
        ProfissionalModel BuscarEmailPorID(int id);
        ProfissionalModel BuscaCrp(string crp);

    }
}
