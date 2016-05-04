using Platypus;
using UnityEngine;
using System.Collections;

public class OperationSelector : UsableActivated
{
	
  public TextMesh text;
  public QuizRoom quizRoom;
  string[] operators = new string[]{ "+", "-", "±", "×", "÷",  "!" };
  QuestionBuilder[] quizBuilders = new QuestionBuilder[]
  { 
    new AdditionBuilder(),
    new SubtractionBuilder(),
    new AddSubBuilder(),
    new MultiplicationBuilder(),
    new DivisionBuilder(),
    new WildcardBuilder()
  };
  int currentIndex = 0;

  void Start()
  {        
    currentIndex = PlayerPrefs.GetInt("operator");
    Reset();
  }

  public override void Activate(GameObject player)
  {
    Increment();
    Reset();
    PlayerPrefs.SetInt("operator", currentIndex);
    PlayerPrefs.Save();
  }

  void Reset()
  {
    text.text = operators [currentIndex];
    var qb = quizBuilders [currentIndex];
    quizRoom.Reset(qb);
  }


  void Increment()
  {
    if (currentIndex < operators.Length - 1)
    {
      currentIndex++;
    } else
    {
      currentIndex = 0;
    }
  }
}
