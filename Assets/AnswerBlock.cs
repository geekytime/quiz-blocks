using Platypus;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBlock : UsableActivated
{
  public Text AnswerText;
  public GameObject UnansweredBlock;
  public GameObject CorrectBlock;
  public GameObject IncorrectBlock;
  public QuizRoom QuizRoom;
  public Prize Prize;

  public bool IsCorrect { get; set; }

  bool answered = false;
  float bounceDelay = .125f;

  public string Text
  {
    get
    {
      return AnswerText.text;
    }
    set
    {
      AnswerText.text = value;
    }
  }
    
  public override void Activate(GameObject player)
  {
    if (!answered)
    {
      Invoke("Answer", bounceDelay);
      answered = true;
    }
  }

  void Answer()
  {
    UnansweredBlock.SetActive(false);
    if (IsCorrect)
    {
      CorrectBlock.SetActive(true);
      QuizRoom.Correct();
      Prize.Activate();
    } else
    {
      IncorrectBlock.SetActive(true);
      DimText();
    }
  }

  void DimText(){
    var color = AnswerText.color;
    color.a = .5f;
    AnswerText.color = color;
  }

  void ResetText(){
    var color = AnswerText.color;
    color.a = 1f;
    AnswerText.color = color;
  }


  public void Hide(){
    gameObject.SetActive(false);
    AnswerText.gameObject.SetActive(false);
  }

  public void Reset(){
    ResetText();
    answered = false;

    gameObject.SetActive(true);
    AnswerText.gameObject.SetActive(true);
    CorrectBlock.SetActive(false);
    IncorrectBlock.SetActive(false);
    UnansweredBlock.SetActive(true);
    UnansweredBlock.transform.localPosition = Vector3.zero;
    GetComponent<Bonkable>().Reset();
  }
}
