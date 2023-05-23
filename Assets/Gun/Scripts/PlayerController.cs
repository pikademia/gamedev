using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int playerSpeed = 10;
    InputProvider inputProvider;

    private void Awake()
    {
        inputProvider = GetComponent<InputProvider>();
    }

    private void Update()
    {
        if (inputProvider == null) return;
        {
            transform.Translate(Time.deltaTime * playerSpeed * inputProvider.Move());

        }
    }

}
