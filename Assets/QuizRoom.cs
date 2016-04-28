using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizRoom : MonoBehaviour {
	
  public Text ProblemText;
  public Text AnswerLeftText;
  public Text AnswerMiddleText;
  public Text AnswerRightText;

  List<Text> answerTexts = new List<Text>();

	void Start () {
    answerTexts.Add(AnswerLeftText);
    answerTexts.Add(AnswerMiddleText);
    answerTexts.Add(AnswerRightText);

    QuestionBuilder qb = new SimpleAdditionBuilder ();

    var question = qb.Build ();

    ProblemText.text = question.question;

    var answers = question.ShuffleAnswers ();
    
    for (var i = 0; i < answerTexts.Count; i++)
    {
      answerTexts [i].text = answers.ElementAt(i);
    }

	}
		
	void Update () {
	
	}
}
