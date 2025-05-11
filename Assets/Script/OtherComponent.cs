using UnityEngine;

public class OtherComponent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SimpleSingleton.Instance.PrintMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
