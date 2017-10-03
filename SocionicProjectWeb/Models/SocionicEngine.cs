using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace SocionicProjectWeb.Models
{
    public class SocionicEngine: IDisposable
    {
        public SocionicEngine()
        {
            
        }
        public void SaveToDB(int[] arrayAnswers,bool[] massiveAnswers, string dateTime)
        {
            using (SocionicEntities socionicEntities=new SocionicEntities())
            {
                var Last = socionicEntities.Results.ToList().LastOrDefault();
                Results results = new Results
                {
                    ID = Last.ID+1,
                    LoginName = "test",
                    MassiveAnswers = SocionicTypeAnswers(arrayAnswers),
                    PCName = "test",
                    Result = "test",
                    TimeData = dateTime
                };
                AnswerTable answerTable=new AnswerTable
                {
                    id = Last.ID + 1,
                    Answer1 = massiveAnswers[0],
                    Answer2 = massiveAnswers[1],
                    Answer3 = massiveAnswers[2],
                    Answer4 = massiveAnswers[3],
                    Answer5 = massiveAnswers[4],
                    Answer6 = massiveAnswers[5],
                    Answer7 = massiveAnswers[6],
                    Answer8 = massiveAnswers[7],
                    Answer9 = massiveAnswers[8],
                    Answer10 = massiveAnswers[9],
                    Answer11 = massiveAnswers[10],
                    Answer12 = massiveAnswers[11],
                    Answer13 = massiveAnswers[12],
                    Answer14 = massiveAnswers[13],
                    Answer15 = massiveAnswers[14],
                    Answer16 = massiveAnswers[15],
                    Answer17 = massiveAnswers[16],
                    Answer18 = massiveAnswers[17],
                    Answer19 = massiveAnswers[18],
                    Answer20 = massiveAnswers[19],
                    Answer21 = massiveAnswers[20],
                    Answer22 = massiveAnswers[21],
                    Answer23 = massiveAnswers[22],
                    Answer24 = massiveAnswers[23],
                    Answer25 = massiveAnswers[24],
                    Answer26 = massiveAnswers[25],
                    Answer27 = massiveAnswers[26],
                    Answer28 = massiveAnswers[27]
                };
                socionicEntities.Results.Add(results);
                socionicEntities.AnswerTable.Add(answerTable);
                socionicEntities.SaveChanges();
            }
            
        }

        private string SocionicTypeAnswers(int[] arrayAnswers)
        {
             return  "R:" + arrayAnswers[0].ToString() + " L: " + arrayAnswers[1].ToString() + " S: " + arrayAnswers[2].ToString() + " E: " + arrayAnswers[3].ToString();

        }

        public void Dispose()
        {
            
        }
    }
}