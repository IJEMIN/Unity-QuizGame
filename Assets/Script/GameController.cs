using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{


	public Text questionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;


	private DataController dataController;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	private bool isRoundActive;
	private float timeRemaining;
	private int questionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects;
	

	void Start()
	{
		/*
             레퍼런스들을 찾고 초기화를 여기에
		*/
		
		
		// UI의 남은 시간을 갱신
		UpdateTimeRemainingDisplay();

		// 점수랑 현재 질문 인덱스를 초기화


		//첫 질문을 보여주기 시작
		ShowQuestion();
		
		// 라운드 활성화를 참으로 해준다
		isRoundActive = true;

	}

	// 질문을 가져와서 띄우고 답안 버튼 들을 만든다
	private void ShowQuestion()
	{
		// 이전 버튼들을 전부 제거
		RemoveAnswerButtons();

		// 여러개의 질문정보(QuestionData) 들 중에 현재 순번(questionIndex) 의 질문을 가져온다
		QuestionData questionData = questionPool[questionIndex];
		// 질문에 대한 텍스트틀 띄어준다
		questionDisplayText.text = questionData.questionText;

		// questionData의 answers(AnswerData 를 여러개 가진 배열임) 의 배열의 길이 만큼 순회ㅙ준다
		for (int i = 0; i < questionData.answers.Length; i++)
		{
			// 버튼들을 순번에 맞추어 만들어준다
		}
	}

	// 지금 띄어져 있는 모든 버튼들을 다음 질문과 답안 버튼들을 위해 삭제해준다
	private void RemoveAnswerButtons()
	{
		// 답안 버튼이 하나라도 남아 있는 동안,,, 계속 삭제할것이다!
		while (answerButtonGameObjects.Count > 0)
		{
			// 남은 버튼중 가장 첫번째 버튼을 퀴즈에서 풀장으로 다시 되돌린다.
			// 즉 퀴즈에서 날려버린다
			answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
			// 현재 답안 버튼의 리스트에서 제거해준다 (= 현재 리스트의 가장 첫번째 친구를 제거해준다 )
			answerButtonGameObjects.RemoveAt(0);
		}
	}

	// 답안 버튼이 클릭됬을때 실행될 함수
	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect)
		{

		}

		if (questionPool.Length > questionIndex + 1)
		{

		}
		else
		{
			EndRound();
		}

	}

	// 라운드가 끝났을때의 처리를 해준다
	public void EndRound()
	{

	}

	// 메뉴로 되돌아가는 코드를 여기 짜준다
	public void ReturnToMenu()
	{
		
	}

	// UI에 남은 시간을 갱신해준다
	private void UpdateTimeRemainingDisplay()
	{
		timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
	}

	// Update 는 반복실행된다
	void Update()
	{
		if (isRoundActive)
		{
			UpdateTimeRemainingDisplay();

			if (timeRemaining <= 0f)
			{
			
			}

		}
	}
}