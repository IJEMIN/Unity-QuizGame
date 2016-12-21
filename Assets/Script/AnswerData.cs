using UnityEngine;
using System.Collections;

/*
    답안 보기를 띄우한 정보

	답안 문장과 해당 답안이 정답인지 아닌지에 대한 정보를 가지고 있다
*/

// Serializable 은 인스펙터에서 해당 클래스를 다룰 수 있다고 지정하는 것
[System.Serializable]
public class AnswerData
{
	// 답안 내용(문장)
	public string answerText;
	// 이 답안이 정답인가 아닌가
	public bool isCorrect;

}