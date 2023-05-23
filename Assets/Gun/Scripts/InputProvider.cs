using UnityEngine;

public class InputProvider : MonoBehaviour
{
    private void Start()
    {
        
    }
    public Vector2 Move()
    {
        Vector2 dir = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        dir.Normalize();
        return dir;
    }


}
