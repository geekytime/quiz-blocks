using UnityEngine;


public class SubtractionBuilder : QuestionBuilder {

  public Question Build(){
    var question = new Question ();

    int a = Random.Range(0, 11);
    int b = Random.Range(0, 11);

    int lhs, rhs;
    if (a > b)
    {
      lhs = a;
      rhs = b;
    } else
    {
      lhs = b;
      rhs = a;
    }

    question.question = lhs + " - " + rhs + " = ?";

    var diff = lhs - rhs;
    question.answer = diff.ToString();
    question.wrongChoice1 = (diff + Random.Range(-3, 0)).ToString();
    question.wrongChoice2 = (diff + Random.Range(1, 4)).ToString();

    return question;
  }

}
