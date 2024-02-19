using CLINICA.Domain.Entities;

namespace CLINICA.Application.Interfaces
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<Analysis>> ListAnalysis();
        Task<Analysis> AnalysisById(int AnalysisId);
        Task<bool> AnalysisRegister(Analysis analysis);
        Task<bool> AnalysisEdit(Analysis analysis);
        Task<bool> AnalysisDelete(int analysisId);
    }
}
