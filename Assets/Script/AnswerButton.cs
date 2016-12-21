using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AnswerButton : MonoBehaviour
{

	// 답안들을 띄울 텍스트 오브젝트에 대한 레퍼런스
	public Text answerText;

	// 답안 정보 (안에 "답안의 내용"과 "해당 답안이 정답 인지" 들어 있음)
	private AnswerData answerData;
	
	// 라운드를 컨트롤하는 컨트롤러에 대한 레퍼런스
	private GameController gameController;

	// 씬이 시작될때
	void Start()
	{
		// 씬 상의 모든 오브젝트를 뒤져서 GameController 를 가지고 있는 오브젝트를 가져옴
		gameController = FindObjectOfType<GameController>();
	}

	// 입력으로 AnswerData를 받아 버튼 셋업하기
	public void Setup(AnswerData data)
	{
		// 자신의 answerData 를 입력으로 받아온 AnswerData data 로 지정
		answerData = data;
		// 텍스트의 내용을 입력으로 받아온 data 안에서 찾은 답안 문장으로 바꿈
		answerText.text = answerData.answerText;
	}

	// 클릭을 했을때 처리
	public void HandleClick()
	{
		
	}
}