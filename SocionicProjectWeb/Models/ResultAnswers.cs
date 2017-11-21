namespace SocionicProjectWeb.Models
{
	public class ResultAnswers
	{
		public int id { get; set; }
		public bool[] Answers { get; set; }

		public ResultAnswers(AnswerTable answerTable)
		{
			id = answerTable.id;
			Answers = new bool[28];
			Answers[0] = answerTable.Answer1;
			Answers[1] = answerTable.Answer2;
			Answers[2] = answerTable.Answer3;
			Answers[3] = answerTable.Answer4;
			Answers[4] = answerTable.Answer5;
			Answers[5] = answerTable.Answer6;
			Answers[6] = answerTable.Answer7;
			Answers[7] = answerTable.Answer8;
			Answers[8] = answerTable.Answer9;
			Answers[9] = answerTable.Answer10;
			Answers[10] = answerTable.Answer11;
			Answers[11] = answerTable.Answer12;
			Answers[12] = answerTable.Answer13;
			Answers[13] = answerTable.Answer14;
			Answers[14] = answerTable.Answer15;
			Answers[15] = answerTable.Answer16;
			Answers[16] = answerTable.Answer17;
			Answers[17] = answerTable.Answer18;
			Answers[18] = answerTable.Answer19;
			Answers[19] = answerTable.Answer20;
			Answers[20] = answerTable.Answer21;
			Answers[21] = answerTable.Answer22;
			Answers[22] = answerTable.Answer23;
			Answers[23] = answerTable.Answer24;
			Answers[24] = answerTable.Answer25;
			Answers[25] = answerTable.Answer26;
			Answers[26] = answerTable.Answer27;
			Answers[27] = answerTable.Answer28;
		}
	}
}