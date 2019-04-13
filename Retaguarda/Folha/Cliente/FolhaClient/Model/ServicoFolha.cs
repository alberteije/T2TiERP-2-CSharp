using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FolhaClient.ServicoFolhaReference;
using SearchWindow.Attributes;
using SearchWindow;

namespace FolhaClient.Model
{
    public class ServicoFolha : ServicoFolhaClient
    {
        [SearchWindowDataSource(typeof(ColaboradorDTO), new string[] { "Id", "Pessoa.Nome" }, new string[] { "Id", "Nome" })]
        public new List<ColaboradorDTO> selectColaborador(ColaboradorDTO dtoPesquisa)
        {
            return base.selectColaborador(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(OperadoraPlanoSaudeDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new List<OperadoraPlanoSaudeDTO> selectOperadoraPlanoSaude(OperadoraPlanoSaudeDTO dtoPesquisa)
        {
            return base.selectOperadoraPlanoSaude(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(FolhaTipoAfastamentoDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new List<FolhaTipoAfastamentoDTO> selectFolhaTipoAfastamento(FolhaTipoAfastamentoDTO dtoPesquisa)
        {
            return base.selectFolhaTipoAfastamento(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(EmpresaTransporteItinerarioDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new List<EmpresaTransporteItinerarioDTO> selectEmpresaTransporteItinerario(EmpresaTransporteItinerarioDTO dtoPesquisa)
        {
            return base.selectEmpresaTransporteItinerario(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(FolhaEventoDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new List<FolhaEventoDTO> selectFolhaEvento(FolhaEventoDTO dtoPesquisa)
        {
            return base.selectFolhaEvento(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(FolhaInssServicoDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new List<FolhaInssServicoDTO> selectFolhaInssServico(FolhaInssServicoDTO dtoPesquisa)
        {
            return base.selectFolhaInssServico(dtoPesquisa);
        }

    }
}
