using UnityEngine;
using TMPro;

public class CreditsList : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text[] title;
    [SerializeField] TMPro.TMP_Text[] names;
    private RectTransform rectTransform;
    public float minTitle;
    public float minNames;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 87);
        foreach (TMP_Text item in title)
        {
            item.fontSizeMin = minTitle;
        }
        foreach (TMP_Text item in names)
        {
            item.fontSizeMin = minNames;
        }
    }

    private void OnDrawGizmos()
    {
        foreach (TMP_Text item in title)
        {
            item.fontSizeMin = minTitle;
        }
    }
}
