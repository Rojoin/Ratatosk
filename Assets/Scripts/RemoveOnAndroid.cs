using UnityEngine;

public class RemoveOnAndroid : MonoBehaviour
{
#if UNITY_ANDROID
	void Start()
	{
		Destroy(gameObject);
	}
#endif
}
