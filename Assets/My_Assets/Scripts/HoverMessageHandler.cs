using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using GON.TelloControll;
using Hover.Core.Items.Types;

public class HoverMessageHandler : MonoBehaviour {

    [SerializeField]
    private string PicPath;

    [SerializeField]
    private RawImage DisplayPanel, NorthStarPanel;

    private int SlideNum = 0;
    [SerializeField]
    private List<Texture2D> Slides;

    public Controller controller = new Controller();

    #region SlideControll

    public void LoadSlide()
    {
        LoadPic();
    }

    [ContextMenu("Activate")]
    public void Activate()
    {
        DisplayPanel.texture = Slides[SlideNum];
        NorthStarPanel.texture = Slides[SlideNum];

        DisplayPanel.enabled = true;
        NorthStarPanel.enabled = true;
    }

    [ContextMenu("Inactivate")]
    public void Inactivate()
    {
        DisplayPanel.enabled = false;
       //NorthStarPanel.enabled = false;
    }

    [ContextMenu("Next")]
    public void Next()
    {
        SlideNum++;
        if (SlideNum > Slides.Count)
        {
            SlideNum = 0;
        }
        Activate();
    }

    [ContextMenu("Previous")]
    public void Previous()
    {
        SlideNum--;
        if (SlideNum < 0)
        {
            SlideNum = Slides.Count;
        }
        Activate();
    }

    public void OnSliderRelease(IItemDataSelectable data)
    {
        
        //SlideNum = (int)Mathf.Round(data.Value);

        if (SlideNum > Slides.Count)
        {
            SlideNum = Slides.Count;
        }

        if (SlideNum <= 0)
        {
            SlideNum = 0;
        }

        Activate();
    }

    #endregion

    #region DroneControll

    public void Initialize()
    {
        controller.Initialize();
    }

    public void Connect()
    {
        controller.Connect();
    }

    public void Takeoff()
    {
        controller.Takeoff();
    }

    public void Land()
    {
        controller.Land();
    }

    #endregion

    [ContextMenu("LoadPic")]
    public void LoadPic()
    {
        Slides = new List<Texture2D>();

        string PictureDirectory = Application.streamingAssetsPath + "/" + PicPath;

        foreach (string path in Directory.GetFiles(PictureDirectory, ".png"))
        {
            string Newpath = path;
            Newpath = path.Replace("\\", "/");

            StartCoroutine(WWWPictureLoad(Newpath));
        }
    }

    public IEnumerator WWWPictureLoad(string path)
    {
        Texture2D texture;
        using(WWW www=new WWW("file:///" + path))
        {
            yield return www;

            texture = www.textureNonReadable;
        }
        Slides.Add(texture);
    }
}
