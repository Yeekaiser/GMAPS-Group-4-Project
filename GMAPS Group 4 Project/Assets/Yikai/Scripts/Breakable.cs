using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    GameObject IntactGlass;

    [SerializeField]
    GameObject BrokenGlass;

    BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider>();

        IntactGlass.SetActive(true);
        BrokenGlass.SetActive(false);
    }

    private void OnMouseDown()
    {
        Break();
    }
    // Update is called once per frame
    public void Break()
    {
        col.enabled = false;

        IntactGlass.SetActive(false);
        BrokenGlass.SetActive(true);
    }
}
