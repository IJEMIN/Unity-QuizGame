using UnityEngine;
using System.Collections.Generic;


/*
    오브젝트 풀링이란,
	
	오브젝트가 필요할때 만들고, 필요없으면 삭제하고,,,
	이런식으로 자꾸 게임 도중에 만들고 지우는 것은 렉을 유발할 수 있다.
	
	오브젝트 풀링은 수영장(풀)을 만들어, 거기다가 미리 만들어 놓은 오브젝트들을 잔뜩 놓아두면,
	오브젝트가 필요할땐:
	    새로 만드는 척 하면서 풀 에서 오브젝트를 가져와서 던져주고
	필요 없을때는:
	    지우는 척 하면서 풀 로 오브젝트들 다시 넣어주는
	
	작업을 통해서 게임 도중 뚝뚝 끊기는 현상을 개선해준다.

*/

/*
    사용법은
	
	이 스크립트를 적당히 빈 게임 오브젝트에 붙여놓는다.
	인스펙터에 prefab 슬롯이 생길텐데, 풀에 미리 만들어 쓸 프리팹을 지정해주면 된다.

	Instantiate 대신에
	SimpleObjectPool 의 GetObject 를 쓰고
	
	Destroy 대신에
	SimpleObjectPool 의 ReturnObject 를 쓰는 것이다.

*/

// A very simple object pooling class
public class SimpleObjectPool : MonoBehaviour
{
	// the prefab that this object pool returns instances of
	public GameObject prefab;
	// collection of currently inactive instances of the prefab
	private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

	// Returns an instance of the prefab
	public GameObject GetObject()
	{
		GameObject spawnedGameObject;

		// if there is an inactive instance of the prefab ready to return, return that
		if (inactiveInstances.Count > 0)
		{
			// remove the instance from teh collection of inactive instances
			spawnedGameObject = inactiveInstances.Pop();
		}
		// otherwise, create a new instance
		else
		{
			spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

			// add the PooledObject component to the prefab so we know it came from this pool
			PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
			pooledObject.pool = this;
		}

		// put the instance in the root of the scene and enable it
		spawnedGameObject.transform.SetParent(null);
		spawnedGameObject.SetActive(true);

		// return a reference to the instance
		return spawnedGameObject;
	}

	// Return an instance of the prefab to the pool
	public void ReturnObject(GameObject toReturn)
	{
		PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

		// if the instance came from this pool, return it to the pool
		if (pooledObject != null && pooledObject.pool == this)
		{
			// make the instance a child of this and disable it
			toReturn.transform.SetParent(transform);
			toReturn.SetActive(false);

			// add the instance to the collection of inactive instances
			inactiveInstances.Push(toReturn);
		}
		// otherwise, just destroy it
		else
		{
			Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from! Destroying.");
			Destroy(toReturn);
		}
	}
}

// a component that simply identifies the pool that a GameObject came from
public class PooledObject : MonoBehaviour
{
	public SimpleObjectPool pool;
}