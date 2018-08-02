using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationControler : MonoBehaviour
{
    List<string> spriteNames = new List<string> { "wink", "blink", "sick", "heart", "lick" };

    public Image bill;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Sprite getAnimationImg(string imgName)
    {
        // List < Sprite > buba = new List<Sprite>();
        Sprite buba;
        Sprite img;





        switch (imgName)
                         {
            case "wink":
                {
                    img = Resources.Load<Sprite>("sprites/seal-_0001_wink");

                    break;
                }
            case "blink":
                {
                    img = Resources.Load<Sprite>("sprites/seal-_0000_blink");

                    break;
                }
            case "sick":
                {
                    img = Resources.Load<Sprite>("sprites/seal-_0010_sick");
                    break;
                }
            case "heart":
                {
                    img = Resources.Load<Sprite>("sprites/seal-_0006_heart-2");

                    break;
                }
            case "lick":
                {
                    img = Resources.Load<Sprite>("sprites/seal-_0002_wink-tongue-2");

                    break;
                }
            default:
                {
                    img = Resources.Load<Sprite>("sprites/seal-_0013_base");

                    break;
                }

        }

        // buba.Add(img);

        return img;
    }


    public void changeSpriteRandom()
    {

        int i = Random.Range(0, spriteNames.Count);
        bill.sprite = getAnimationImg(spriteNames[i]);



    }

    public void changeSpriteBack()
    {

        //int i = Random.Range(0, spriteNames.Count);
        bill.sprite = getAnimationImg("");



    }
}
