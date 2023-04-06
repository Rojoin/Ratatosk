using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Sprite image, image2;
    [SerializeField] private Image currentImage;
    private void Start()
    {
        currentImage.sprite = image;
    }
    public void ChangeImage()
    {
        if (currentImage.sprite == image) currentImage.sprite = image2;
        else currentImage.sprite = image;

        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
    }

}
