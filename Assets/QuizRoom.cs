﻿using Platypus;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizRoom : UsableActivated {
	
  public Text ProblemText;
  public AnswerBlock AnswerBlockLeft;
  public AnswerBlock AnswerBlockMiddle;
  public AnswerBlock AnswerBlockRight;
  public List<GameObject> Doors;

  List<AnswerBlock> answerBlocks = new List<AnswerBlock>();

	void Start () {
    answerBlocks.Add(AnswerBlockLeft);
    answerBlocks.Add(AnswerBlockMiddle);
    answerBlocks.Add(AnswerBlockRight);

    NewQuestion();
	}

  void NewQuestion(){
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
    ShowDoors();
    HideBlocks();
  }

  void HideBlocks(){
    foreach (var block in answerBlocks)
    {
      if (! block.IsCorrect)
      {
        block.Hide();
      }
    }
  }

  void ShowDoors(){
    foreach (var door in Doors)
    {
      door.SetActive(true);
    }
  }

  void HideDoors(){
    foreach (var door in Doors)
    {
      door.SetActive(false);
    }
  }

  public override void Activate(GameObject player){
    Reset();
  }
		
  void Reset(){
    HideDoors();
    foreach (var block in answerBlocks)
    {
      block.Reset();
    }

    NewQuestion();
  }

}
