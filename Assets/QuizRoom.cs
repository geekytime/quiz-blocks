using Platypus;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizRoom : UsableActivated
{
	
  public Text ProblemText;
  public AnswerBlock AnswerBlockLeft;
  public AnswerBlock AnswerBlockMiddle;
  public AnswerBlock AnswerBlockRight;
  public List<GameObject> Doors;
  public AudioSource missSound;
  public AudioSource coinSound;
  int currentValue = 2;

  QuestionBuilder currentQB = new AdditionBuilder ();

  List<AnswerBlock> answerBlocks = new List<AnswerBlock> ();

  void Start ()
  {
    answerBlocks.Add (AnswerBlockLeft);
    answerBlocks.Add (AnswerBlockMiddle);
    answerBlocks.Add (AnswerBlockRight);

    NewQuestion ();
  }

  public int CurrentValue {
    get {
      return currentValue;
    }
  }

  void NewQuestion ()
  {
    currentValue = 2;

    var question = currentQB.Build ();

    ProblemText.text = question.question;

    var answers = question.ShuffleAnswers ();

    for (var i = 0; i < answerBlocks.Count; i++) {
      answerBlocks [i].Text = answers.ElementAt (i);
      if (answers.ElementAt (i) == question.answer) {
        answerBlocks [i].IsCorrect = true;
      } else {
        answerBlocks [i].IsCorrect = false;
      }
    }
  }

  public void Correct ()
  {
    Inventory.GetInstance ().AddCoins (currentValue);
    ShowDoors ();
    HideBlocks ();
  }

  public void Incorrect ()
  {
    currentValue--;
    missSound.Play ();
  }

  void HideBlocks ()
  {
    foreach (var block in answerBlocks) {
      if (!block.IsCorrect) {
        block.Hide ();
      }
    }
  }

  void ShowDoors ()
  {
    foreach (var door in Doors) {
      door.SetActive (true);
    }
  }

  void HideDoors ()
  {
    foreach (var door in Doors) {
      door.SetActive (false);
    }
  }

  public override void Activate (GameObject player)
  {
    QuizLevel.instance.GoUp ();
    Reset ();
  }

  public void Reset (QuestionBuilder qb)
  {
    currentQB = qb;
    Reset ();
  }

  void Reset ()
  {
    HideDoors ();
    foreach (var block in answerBlocks) {
      block.Reset ();
    }

    NewQuestion ();
  }

  public void PlayCoinSound ()
  {
    coinSound.Play ();
  }

}
