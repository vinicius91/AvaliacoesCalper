using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.CrossCutting.Helpers;

namespace AvaliacoesCalper.Domain.Entities
{
    public class Resposta : EntityBase
    {
        public int UserID { get; private set; }

        public int AvaliadorID { get; private set; }

        public int AlternativaID { get; private set; }

        public int QuestaoID { get; private set; }

        public int QuestionarioID { get; private set; }

        public Users Usuario { get; set; }

        public Users Avaliador { get; set; }

        public Alternativa Alternativa { get; set; }

        public Questao Questao { get; set; }

        public Questionario Questionario { get; set; }

        protected Resposta()
        {
            
        }

        public Resposta(int userId, int alternativaId, int questaoId, int questionarioId, int avaliadorId)
        {
            SetUserAndAvaliador(avaliadorId, userId);
            AlternativaID = alternativaId;
            QuestaoID = questaoId;
            QuestionarioID = questionarioId;

        }

        public void SetUserAndAvaliador(int avaliadorId, int userId)
        {
            if (avaliadorId == userId)
            {
                throw new Exception("O avaliador e o avaliado não podem ser a mesma pessoa");
            }

            AvaliadorID = avaliadorId;
            UserID = userId;

        }
    }
}
