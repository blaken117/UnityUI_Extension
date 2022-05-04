using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIUpdater : MonoBehaviour
{
    public List<Button> AllSceneButtons = new List<Button>();
    public CanvasScaler CanvasScalar;
    public Sprite NormalSprite;
    public Sprite HoverSprite;
    public Sprite ClickedSprite;

    public void UpdateButtonSprites()
    {
        for (int i = 0; i < AllSceneButtons.Count; i++)
        {
            var spriteState = AllSceneButtons[i].spriteState;

            spriteState.highlightedSprite = HoverSprite;
            spriteState.pressedSprite = ClickedSprite;

            AllSceneButtons[i].spriteState = spriteState;

            var image = AllSceneButtons[i].GetComponent<Image>();

            if (image != null)
            {
                image.sprite = NormalSprite;
            }

            AllSceneButtons[i].transition = Selectable.Transition.SpriteSwap;

            float delta = image.sprite.pixelsPerUnit / CanvasScalar.referencePixelsPerUnit;

            AllSceneButtons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(image.sprite.texture.width, image.sprite.texture.height) / delta;
        }
    }

    public void ApplyEventTriggersToButtons()
    {
        for (int i = 0; i < AllSceneButtons.Count; i++)
        {
            var buttonEventTrigger = AllSceneButtons[i].GetComponent<EventTrigger>();

            if (buttonEventTrigger)
            {
                DestroyImmediate(buttonEventTrigger);
            }

            var eventTrigger = GetComponent<EventTrigger>();

            if (eventTrigger)
            {
                AllSceneButtons[i].gameObject.AddComponent(eventTrigger);
            }
        }
    }
}
