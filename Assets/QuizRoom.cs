using Platypus;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizRoom : MonoBehaviour {
	
  public Text ProblemText;
  public AnswerBlock AnswerBlockLeft;
  public AnswerBlock AnswerBlockMiddle;
  public AnswerBlock AnswerBlockRight;

  List<AnswerBlock> answerBlocks = new List<AnswerBlock>();

	void Start () {
    answerBlocks.Add(AnswerBlockLeft);
    answerBlocks.Add(AnswerBlockMiddle);
    answerBlocks.Add(AnswerBlockRight);

    QuestionBuilder qb = new SimpleAdditionBuilder ();

    var question = qb.Build ();

    ProblemText.text = question.question;

    var answers = question.ShuffleAnswers ();
    
    for (var i = 0; i < answerBlocks.Count; i++)
    {
      answerBlocks [i].Text = answers.ElementAt(i);
      if (answers.ElementAt(i) == question.answer)
      {
        answerBlocks [i].IsCorrect = true;
      } else
      {
        answerBlocks [i].IsCorrect = false;
      }
    }

	}

  public void Correct(){
    Inventory.GetInstance().AddCoin();

    foreach (var block in answerBlocks)
    {
      if (! block.IsCorrect)
      {
        block.Hide();
      }
    }
  }
		
}
