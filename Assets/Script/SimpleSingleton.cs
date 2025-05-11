using Unity.VisualScripting;
using UnityEngine;

public class SimpleSingleton : MonoBehaviour
{
    private static SimpleSingleton instance;

    public static SimpleSingleton Instance
    {
        get
        {
            if(instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void SetupInstance()
    {
        instance = FindAnyObjectByType<SimpleSingleton>();

        if(instance == null)
        {
            GameObject gameObject = new GameObject();
            gameObject.name = "SimpleSingleton";
            instance = gameObject.AddComponent<SimpleSingleton>();
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PrintMessage()
    {
        Debug.Log("ΩÃ±€≈Ê ¡§ªÛ¿€µø¡ﬂ~");
    }
}
