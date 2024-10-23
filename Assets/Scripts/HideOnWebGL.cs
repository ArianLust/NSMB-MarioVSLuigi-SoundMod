using UnityEngine;

public class HideOnWebGL : MonoBehaviour
{
    void Awake()
    {
        #if UNITY_WEBGL
            gameObject.SetActive(false);
        #endif
    }
}
