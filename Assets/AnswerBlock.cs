using Platypus;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBlock : UsableActivated
{
  public Text AnswerText;
  public GameObject UnansweredBlock;
  public GameObject CorrectBlock;
  public GameObject IncorrectBlock;

  public bool IsCorrect { get; set; }

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
    Invoke("SwitchBlocks", bounceDelay);
  }

  void SwitchBlocks()
  {
    UnansweredBlock.SetActive(false);
    if (IsCorrect)
    {
      CorrectBlock.SetActive(true);
    } else
    {
      IncorrectBlock.SetActive(true);
    }
  }
}
