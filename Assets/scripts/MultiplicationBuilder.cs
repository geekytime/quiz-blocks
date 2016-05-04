using UnityEngine;


public class MultiplicationBuilder : QuestionBuilder {

  public Question Build(){
    var question = new Question ();

    int lhs = Random.Range(0, 11);
    int rhs = Random.Range(0, 11);
    question.question = lhs + " × " + rhs + " = ?";

    var prod = lhs * rhs;
    question.answer = prod.ToString();
    question.wrongChoice1 = (prod + Random.Range(-lhs, 0)).ToString();
    question.wrongChoice2 = (prod + Random.Range(1, lhs)).ToString();

    return question;
  }

}
