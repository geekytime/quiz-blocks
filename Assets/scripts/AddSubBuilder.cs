using UnityEngine;


public class AddSubBuilder : QuestionBuilder {

  AdditionBuilder ab = new AdditionBuilder();
  SubtractionBuilder sb = new SubtractionBuilder();

  public Question Build(){
    var chance = Random.Range(0,2);
    if (chance == 0)
    {
      return ab.Build();
    } else
    {
      return sb.Build();
    }
  }

}
