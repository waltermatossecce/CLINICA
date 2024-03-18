namespace CLINICA.Api.Extensions.Router
{
    public class APIRouter
    {
        public const string Services = "clinica";
        public const string Version = "v1";
        public const string API = Services +"/" + Version + "/";


        public struct ANALISTC
        {
            public const string listadoAnalysis = API + "ListadoAnalysis";
            public const string AnalysisById = API + "Analysis/{analysisId:int}";
            public const string Register = API + "Analysis/register";
            public const string EditarAnalysis = API + "EditarAnalysis";
            public const string RemoveAnalysis = API + "Remove/{analysisId:int}";
            public const string UpdateStateAnalysis = API +  "changeStateAnalysis";
        }
        public struct EXAMEN
        {
            public const string ListaExamen = API + "ListaExamen";
            public const string ExamenById = API + "Examen/{examId:int}";
            public const string ExamenRegister = API + "ExamenRegister";
            public const string UpdateExamen = API + "UpdateExamen";
            public const string DeleteExamen = API + "Examen/examId:int";
            public const string ChangeStateExamen = API + "ChangeStateExamen";
        }
    }
}
