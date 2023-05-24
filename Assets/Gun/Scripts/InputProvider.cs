using UnityEngine;

public class InputProvider : MonoBehaviour
{
    public Vector2 Move()
    {
        Vector2 dir = new(Input.GetAxisRaw("Horizontal"), 0f);
        return dir;
    }

    public bool Jump()
    {
        return Input.GetButtonDown("Jump");
    }

    public bool ToggleWeapon()
    {
        return Input.GetButtonDown("Cancel");
    }
}
