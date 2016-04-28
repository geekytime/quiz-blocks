using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Question {
	public string question;
	public string answer;
	public string wrongChoice1;
	public string wrongChoice2;

  public List<string> ShuffleAnswers(){
    List<string> answers = new List<string>(){ answer, wrongChoice1, wrongChoice2 };
    var shuffledAnswers = answers.OrderBy(x => Random.value).ToList();
    return shuffledAnswers;
  }
}
