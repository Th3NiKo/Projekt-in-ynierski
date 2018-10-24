
public class SpaceCleanup : MonoBehaviour
{
    private Transform childActionPanel;
    private Transform childDescription;

    public void OnPointerClick()
    {
        childDescription.gameObject.SetActive(false);

        if (childActionPanel.gameObject.activeSelf)
        {
            childActionPanel.gameObject.SetActive(false);
        }
        else
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("ActionPanel"))
            {
                go.SetActive(false);
            }

            childActionPanel.gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter()
    {
        if (!childActionPanel.gameObject.activeSelf)
        {
            childDescription.gameObject.SetActive(true);
        }
    }

    public void OnPointerLeave()
    {
        childDescription.gameObject.SetActive(false);
    }

    public void Start()
    {
        childDescription = transform.Find("Description");
        childActionPanel = transform.Find("ActionPanel");

    }
}