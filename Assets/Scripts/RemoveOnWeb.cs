using UnityEngine;

public class RemoveOnWeb : MonoBehaviour
{
#if UNITY_WEBGL
	void Start()
	{
    	Destroy(gameObject);
	}
#endif
}
