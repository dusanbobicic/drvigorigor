using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class CameraController : MonoBehaviour {
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    private int resWidth = 1200;
    private int resHeight = 800;

    public Camera camera;
    public Canvas canvas;
    public static String data;

    

    public Text errorLog;

    public RawImage background;

    public AspectRatioFitter fit;
    private bool tru = false;
    // Use this for initialization
    [Serializable]
    public class child
    {
        public string FirstName;
    }
    private void TakePitcure()
    {
        try
        {
            String FileName = Convert.ToBase64String(ScreenCapture.CaptureScreenshotAsTexture().EncodeToJPG());
           // String json = "{\n" + "\"firstName\":";
            //errorLog.text= data = json+ "\"" + FileName+ "\"" + "\n}";
            child cd = new child();
            cd.FirstName = FileName;
            string jsonS = JsonUtility.ToJson(cd);
            errorLog.text = data = jsonS;
            StartCoroutine(makeRequest("http://barcodeproces.azurewebsites.net/child/"));

        }
        catch (Exception ex) { errorLog.text = ex.ToString(); }
        
     }
    IEnumerator makeRequest(string url)
    {
        UnityWebRequest delReq = UnityWebRequest.Post(url,data);
        yield return delReq.Send();

        if (delReq.responseCode==404)
        {
            errorLog.text = delReq.error;
        }
        else
        {
            errorLog.text = delReq.downloadHandler.text+"weee";
        }
    }
    private void Start()
    {
        InvokeRepeating("TakePitcure", 2f, 3.0f);

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
            
             /*   if (!devices[i].isFrontFacing)
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
            */     
    

           backCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height);
      

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
