using UnityEngine;
using System.Collections;


//질문에 대한 정보가 들어있다.
//질문은 질문의 내용과, 답안 정보, 즉 AnswerData 가 한개 이상 들어있다.
//질문 데이터를 까보면 답안 데이터를 가져올수 있다는 것에 유의

[System.Serializable]
public class QuestionData
{
	// 질문 문장
	public string questionText;
	// 한개 이상의 (배열을 사용함) 답안 정보들
	public AnswerData[] answers;
}