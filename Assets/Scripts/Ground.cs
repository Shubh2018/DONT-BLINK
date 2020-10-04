using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    bool hasLeft = false;
    private bool hasMoved = false;
    public bool HasMoved
    {
        get
        {
            return hasMoved;
        }

        set
        {
            hasMoved = value;
        }
    }

    private void Update()
    {
        //hasLeft = floorCollider.IsTouching(player);

        if (hasLeft)
            Destroy(this.gameObject, 3.5f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            hasLeft = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && hasMoved == false)
            hasLeft = true;
    }
}
