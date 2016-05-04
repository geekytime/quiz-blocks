using UnityEngine;


public class WildcardBuilder : QuestionBuilder
{

  QuestionBuilder[] options = new QuestionBuilder[]
  {    
    new AddSubBuilder(),
    new MultiplicationBuilder(),
    new DivisionBuilder()
  };

  public Question Build()
  {
    var chance = Random.Range(0, options.Length);   
    return options [chance].Build();
  }

}
