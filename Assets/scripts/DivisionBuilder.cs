using UnityEngine;


public class DivisionBuilder : QuestionBuilder {

  public Question Build(){
    var question = new Question ();

    int rhs = Random.Range(1, 11);
    int answer = Random.Range(1, 11);

    var lhs = rhs * answer;

    question.question = lhs + " ÷ " + rhs + " = ?";

    question.answer = answer.ToString();
    question.wrongChoice1 = (Random.Range(1, 11)).ToString();
    question.wrongChoice2 = (Random.Range(1, 11)).ToString();

    return question;
  }

}
