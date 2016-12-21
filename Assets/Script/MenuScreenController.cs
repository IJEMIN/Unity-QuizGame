using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// 스크린의 버튼들이 사용할 public 함수들을 여기다가 놓으려고 만들었다.
public class MenuScreenController : MonoBehaviour
{

	// 버튼이 이 함수를 이용하면, Game 씬을 띄울수 있다
	public void StartGame()
	{
		// SceneManager.LoadScene("씬이름") 은 새로운 씬을 띄우게 해준다
		SceneManager.LoadScene("Game");
	}
}