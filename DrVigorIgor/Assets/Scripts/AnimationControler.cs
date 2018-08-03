using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationControler : MonoBehaviour
{
    List<string> spriteNames = new List<string> { "wink", "blink", "heart", "lick", "blush" };

    public Image bill;

    private static Sprite neal;
    private static Sprite wink;
    private static Sprite blink;
    private static Sprite sick;
    private static Sprite heart;
    private static Sprite lick;
    private static Sprite blush;

    // Use this for initialization
    void Start()
    {
        neal = Resources.Load<Sprite>("sprites/seal-_0013_base");
        wink = Resources.Load<Sprite>("sprites/seal-_0001_wink");
        blink = Resources.Load<Sprite>("sprites/seal-_0000_blink");
        sick = Resources.Load<Sprite>("sprites/seal-_0010_sick");
        heart = Resources.Load<Sprite>("sprites/seal-_0006_heart-2");
        lick = Resources.Load<Sprite>("sprites/seal-_0002_wink-tongue-2");
        blush = Resources.Load<Sprite>("sprites/seal-_0012_blush");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Sprite getAnimationImg(string imgName)
    {
        switch (imgName)
        {
            case "wink":
                {
                    return wink;
                }
            case "blink":
                {
                    return blink;
                }
            case "sick":
                {
                    return sick;
                }
            case "heart":
                {
                    return heart;
                }
            case "lick":
                {
                    return lick;
                }
            case "blush":
                {
                    return blush;
                }
            default:
                {
                    return neal;
                }

        }
    }

    public void changeSpriteRandom()
    {
        int i = Random.Range(0, spriteNames.Count);
        bill.sprite = getAnimationImg(spriteNames[i]);
    }

    public void changeSpriteBack()
    {
        bill.sprite = getAnimationImg("");
    }
}
