using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] GameObject IntactGlass;
    
    [SerializeField] GameObject BrokenGlass;

    [SerializeField] GameObject dustEffect;

    BoxCollider col;

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider>();

        IntactGlass.SetActive(true);
        BrokenGlass.SetActive(false);
    }

    //private void OnMouseDown()
    //{
    //    Break();
    //}

    public void TakeDmg(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Break();
        }
    }
    private void Break()
    {
        col.enabled = false;

        IntactGlass.SetActive(false);
        BrokenGlass.SetActive(true);

        EnableDust();
    }

    private void EnableDust()
    {
        dustEffect.SetActive(true);
        Invoke("DisableDust", 10f);
    }

    private void DisableDust()
    {
        dustEffect.SetActive(false);
    }
}
