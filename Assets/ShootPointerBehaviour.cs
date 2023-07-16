using UnityEngine;

public class ShootPointerBehaviour : MonoBehaviour
{
    public void RotatePointer(bool FlipPlayer)
    {
        if (FlipPlayer)
        {
            transform.Rotate(0f, 0f, 0f);
        }
        else
            transform.Rotate(0f, 190, 0f);
    }
}
