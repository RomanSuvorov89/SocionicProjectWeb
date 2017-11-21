using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Threading.Tasks;

namespace SocionicProjectWeb.Models
{
	public class DBSaveContext : IDisposable
	{
		private int[] _groupAnswers;
		private string TaskResult;

		public DBSaveContext()
		{
		}

		private string SocionicTypeAnswers()
		{
			return "R: " + _groupAnswers[0] + " L: " + _groupAnswers[1] + " S: " + _groupAnswers[2] + " E: " + _groupAnswers[3];
		}

		private string SocioType()
		{
			char logicOrEthic = GetDihotomie(_groupAnswers[1], 'l', 'e');
			char sensOrInt = GetDihotomie(_groupAnswers[2], 's', 'i');
			char extraOrIntra = GetDihotomie(_groupAnswers[3], 'e', 'i');
			if (_groupAnswers[0] > 3)
			{
				return new string(new char[] {logicOrEthic, sensOrInt, extraOrIntra});
			}
			else
			{
				return new string(new char[] {sensOrInt, logicOrEthic, extraOrIntra});
			}
		}

		private char GetDihotomie(int answers, char firstDihotomie, char secondDihotomie)
		{
			if (answers > 3)
			{
				return firstDihotomie;
			}
			else return secondDihotomie;
		}

		public void Dispose()
		{

		}

		public Task<string> SaveToDB(ResultModel result) //int[] groupAnswers, int[] arrayAnswers, string currentTime)
		{
			_groupAnswers = result.GroupOfAnswers;
			try
			{
				using (var socionicEntities = new SocionicEntities())
				{
					var answerBools = result.ArrayAnswers.Select(i => i != 0).ToArray();
					var last = socionicEntities.Results.ToList().Last();
					var answerTable = new AnswerTable
					{
						id = last.ID + 1,
						Answer1 = answerBools[0],
						Answer2 = answerBools[1],
						Answer3 = answerBools[2],
						Answer4 = answerBools[3],
						Answer5 = answerBools[4],
						Answer6 = answerBools[5],
						Answer7 = answerBools[6],
						Answer8 = answerBools[7],
						Answer9 = answerBools[8],
						Answer10 = answerBools[9],
						Answer11 = answerBools[10],
						Answer12 = answerBools[11],
						Answer13 = answerBools[12],
						Answer14 = answerBools[13],
						Answer15 = answerBools[14],
						Answer16 = answerBools[15],
						Answer17 = answerBools[16],
						Answer18 = answerBools[17],
						Answer19 = answerBools[18],
						Answer20 = answerBools[19],
						Answer21 = answerBools[20],
						Answer22 = answerBools[21],
						Answer23 = answerBools[22],
						Answer24 = answerBools[23],
						Answer25 = answerBools[24],
						Answer26 = answerBools[25],
						Answer27 = answerBools[26],
						Answer28 = answerBools[27]
					};
					var results = new Results
					{
						ID = last.ID + 1,
						LoginName = result.UserInfo,
						MassiveAnswers = SocionicTypeAnswers(),
						PCName = result.Device,
						Result = SocioType(),
						TimeData = result.CurrentTime,
						AnswerTable = answerTable
					};
					
					socionicEntities.Results.Add(results);
					//socionicEntities.AnswerTable.Add(answerTable);
					socionicEntities.SaveChanges();
				}
				TaskResult = SocioType();
			}
			catch (Exception e)
			{
				TaskResult = e.ToString();
			}
			return Task.FromResult(TaskResult);
		}
	}
}