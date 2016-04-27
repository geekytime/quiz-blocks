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

    int lhs = Random.Range(0, 10);
    int rhs = Random.Range(0, 10);
    ProblemText.text = lhs + " + " + rhs + " = ?";

    int answer = lhs + rhs;
    int wrong1 = lhs + rhs + Random.Range(-3, 3);
    int wrong2 = lhs + rhs + Random.Range(-3, 3);

    List<int> answers = new List<int>(){ answer, wrong1, wrong2 };
    var shuffledAnswers = answers.OrderBy(x => Random.value);
    for (var i = 0; i < answerTexts.Count; i++)
    {
      answerTexts [i].text = shuffledAnswers.ElementAt(i).ToString();
    }

	}
		
	void Update () {
	
	}
}
