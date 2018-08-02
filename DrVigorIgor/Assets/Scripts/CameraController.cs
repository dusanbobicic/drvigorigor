using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Media;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using BarcodeAPI;

public class CameraController : MonoBehaviour {
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    private int resWidth = 1200;
    private int resHeight = 800;

    public Camera camera;
    public Canvas canvas;


    public Text errorLog;

    public RawImage background;

    public AspectRatioFitter fit;
    private bool tru = false;
    // Use this for initialization
    private void TakePitcure()
    {

        //ScreenCapture.CaptureScreenshot("C:\\Users\\flopek\\Desktop\\slikica.png");
        byte[] bytes= ScreenCapture.CaptureScreenshotAsTexture().EncodeToJPG();
        BarcodeControler bc = new BarcodeControler();
        string[] texta = bc.getTextFromByteArray(bytes);
        if (texta.Length > 0) 
        errorLog.text += bc.getTextFromByteArray(bytes)[0];
        
        
        
        
        /* RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = "C:\\Users\\flopek\\Desktop\\testSlika.png";
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to:", filename));
        */


    }

    private void Start()
    {
        InvokeRepeating("TakePitcure", 0f, 3.0f);

        if (tru) return;
       
            defaultBackground = background.texture;
        
    
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera");
            errorLog.text += "No camera \n";
            camAvailable = false;
            return;
        }
        errorLog.text += " " + devices.Length + " number of cameras";

        for (int i = 0; i < devices.Length; i++)
        {
            
                if (!devices[i].isFrontFacing)
                 {

                     backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                     errorLog.text += devices[i].name + "\n";
                 }

                 else
                 {

                     Debug.Log("No backcam");
                     errorLog.text += "No camera \n";

                     return;
                 }
                 
    

        //   backCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height);
      

            errorLog.text += backCam.name+"\n";
            backCam.Play();
           
                background.texture = backCam;
            
            camAvailable = true;
            tru = true;
        }
    }
	// Update is called once per frame
	private void Update () {
        if (!camAvailable)
        {
            errorLog.text += "No camera ava";
            return;
        }
        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;


        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}
}
