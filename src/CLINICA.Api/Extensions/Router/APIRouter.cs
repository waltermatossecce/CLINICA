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
        public struct PACIENTES
        {
            public const string ListaPacientes = API + "ListaPacientes";
            public const string PacientesById = API + "Pacientes/{patientId:int}";
            public const string PacientRegister = API + "PacientRegister";
            public const string PacientesUpdate = API + "UpdatePacientes";
            public const string PacientesRemove = API + "PacientesRemove/{patientId:int}";
            public const string ChangeStatePatient = API + "ChangeStatePatient";
        }
        public struct MEDICOS
        {
            public const string ListaMedicos = API + "ListaMedicos";
            public const string MedicosById = API + "Medicos/{medicId:int}";
            public const string MedicRegister = API + "MedicRegister";
            public const string MedicUpdate = API + "UpdateMedic";
            public const string MedicDelete = API + "Delete/medicId:int";
            public const string ChangeStateMedic = API + "ChangeStateMedic";
        }
        public struct TAKEEXAM
        {
            public const string ListadoTakeExam = API + "ListadoTakeExam";
            public const string TakeExamById = API + "TakeExamById/{takeExamId:int}";
            public const string RegisterTakeExam = API + "RegisterTakeExam";
        }
    }
}
