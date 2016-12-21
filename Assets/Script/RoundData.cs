using UnityEngine;
using System.Collections;

// 한 라운드에는 여러개의 질문(QuestionDatat 배열)이 있다
// 답안들은 명시적으로 선언하지 않았지만, 답안 정보는 질문 정보를 까보면 바로 나온다는 것에 유의


[System.Serializable]
public class RoundData
{
	// 라운드 이름. 질문 주제로 해주면 된다
	public string name;
	// 시간 제한
	public int timeLimitInSeconds;
	// 정답에 대한 점수
	public int pointsAddedForCorrectAnswer;
	// 질문 정보들
	public QuestionData[] questions;

}