using UnityEngine;
using System.Collections;

public class AdditionBuilder : QuestionBuilder {

	public Question Build(){
		var question = new Question ();

		int lhs = Random.Range(0, 11);
		int rhs = Random.Range(0, 11);
		question.question = lhs + " + " + rhs + " = ?";

		var sum = lhs + rhs;
		question.answer = sum.ToString();
		question.wrongChoice1 = (sum + Random.Range(-3, 0)).ToString();
		question.wrongChoice2 = (sum + Random.Range(1, 4)).ToString();

		return question;
	}
 
}
