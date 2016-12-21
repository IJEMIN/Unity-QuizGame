using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


/*
이 게임은 한 라운드에 여러가지 질문이 나온다.
그리고 라운드가 끝나면 다른 라운드가 시작된다.
 
RoundData 는 질문들을 들고 있는데,
이 라운드에 대한 정보를 가져오면, 질문을 가져올수 있는 것이다.

따라서 GameController 는 RoundData 를 가져와서
퀴즈 게임을 세팅해주는데, GameController가 라운드 정보들을 가져오기 위해서는
어딘가에서 RoundData 를 저장해놓아야만 한다.

DataController 는 바로 저장소의 역할을 한다.
따라서 게임의 가장 첫 시작부터 존재하여, 게임이 완전이 끝날때 까지 파괴되어선 안될것이다.
*/

public class DataController : MonoBehaviour
{
	// 배열[]을 통해 여러개의 데이터를 한번에 묶어 가져올수 있는 것.
	// 모든 라운드에 대한 정보들
	public RoundData[] allRoundData;


	// 가장 처음 실행되는 함수는 Start 이다.
	void Start()
	{
		// DontDestroyOnLoad 는 씬이 교체가 되도 오브젝트가 파괴되지 않도록 지정해준다
		DontDestroyOnLoad(gameObject);

		//SceneManager.LoadScene("씬이름") 은 해당 씬을 로드해준다
		// 첫 씬이 시작되자 마자 바로 메인메뉴로 넘어가고 있다
		SceneManager.LoadScene("MenuScreen");
	}

	// 현재 순번의 데이터를 넘겨준다. 일단은 첫번째(컴퓨터 입장에선 0번째) 라운드만 넘겨주었다
	// 현재 라운드의 다음 라운드를 주도록 해야 할 것이다
	public RoundData GetCurrentRoundData()
	{
		return allRoundData[0];
	}

}