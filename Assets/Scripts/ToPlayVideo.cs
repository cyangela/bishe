using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ToPlayVideo : MonoBehaviour {

    public VideoClip[] videoClips;      // 视频的文件 参数
    public Text videoTimeText;          // 视频的当前时间 Text
    public Text videoNameText;          // 视频的总时长 Text
    public Slider videoTimeSlider;      // 视频的时间 Slider
    // 定义参数获取VideoPlayer组件和RawImage组件
    internal VideoPlayer videoPlayer;
    private RawImage rawImage;
    public Texture pingBao;             // 屏保图片
    // 当前视频的总时间值和当前播放时间值的参数
    private int currentHour;
    private int currentMinute;
    private int currentSecond;
    private int clipHour;
    private int clipMinute;
    private int clipSecond;

    public Sprite play;
    public Sprite pause;
    private bool isPlay = true;          //是否正在播放视频
    public Button playPauseButton;       //播放暂停按钮
    public Button stopButton;            //停止播放按钮
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    // Use this for initialization
    void Start()
    {
        //清空文本
        videoNameText.text = "";
        videoTimeText.text = "";

        //获取场景中对应的组件
        videoPlayer = this.GetComponent<VideoPlayer>();
        rawImage = this.GetComponent<RawImage>();
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, this.GetComponent<AudioSource>());
        videoPlayer.playOnAwake = false;
        videoPlayer.IsAudioTrackEnabled(0);

        playPauseButton.onClick.AddListener(PlayOrPause);
        stopButton.onClick.AddListener(StopVideo);
        button1.onClick.AddListener(delegate { OnClick(0); });
        button2.onClick.AddListener(delegate { OnClick(1); });
        button3.onClick.AddListener(delegate { OnClick(2); });
        button4.onClick.AddListener(delegate { OnClick(3); });
    }

    // Update is called once per frame
    void Update()
    {
        //如果videoPlayer没有对应的视频texture，则返回屏保
        if (videoPlayer.texture == null)
        {
            rawImage.texture = pingBao;
            return;
        }
        //把VideoPlayerd的视频渲染到UGUI的RawImage
        rawImage.texture = videoPlayer.texture;
        ShowVideoTime();
    }

    /// <summary>
    /// 显示当前视频的时间
    /// </summary>
    private void ShowVideoTime()
    {
        // 当前的视频播放时间
        currentHour = (int)videoPlayer.time / 3600;
        currentMinute = (int)(videoPlayer.time - currentHour * 3600) / 60;
        currentSecond = (int)(videoPlayer.time - currentHour * 3600 - currentMinute * 60);
        // 把当前视频播放的时间显示在 Text 上
        videoTimeText.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
            currentHour, currentMinute, currentSecond);
        // 把当前视频播放的时间比例赋值到 Slider 上
        videoTimeSlider.value = (float)(videoPlayer.time / videoPlayer.clip.length);
    }

    /// <summary>
    /// 显示视频的总时长
    /// </summary>
    /// <param name="videos">当前视频</param>
    void ShowVideoLength(VideoClip videos)
    {
        videoPlayer.clip = videos;
        videoPlayer.Play();
        videoTimeSlider.gameObject.SetActive(true);
        clipHour = (int)videoPlayer.clip.length / 3600;
        clipMinute = (int)(videoPlayer.clip.length - clipHour * 3600) / 60;
        clipSecond = (int)(videoPlayer.clip.length - clipHour * 3600 - clipMinute * 60);
        videoNameText.text = string.Format("{0:D2}:{1:D2}:{2:D2} ",
             clipHour, clipMinute, clipSecond);
    }

    private void OnClick(int num)
    {
        switch (num)
        {
            case 0:
                ShowVideoLength(videoClips[0]);
                break;
            case 1:
                ShowVideoLength(videoClips[1]);
                break;
            case 2:
                ShowVideoLength(videoClips[2]);
                break;
            case 3:
                ShowVideoLength(videoClips[3]);
                break;
            case 4:
                ShowVideoLength(videoClips[4]);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 视频播放暂停
    /// </summary>
    void PlayOrPause()
    {
        //如果视频片段不为空，并且视频画面没有播放完毕
        if (videoPlayer.clip != null && (ulong)videoPlayer.frame < videoPlayer.frameCount)
        {
            //如果视频正在播放
            if (isPlay)
            {
                playPauseButton.image.sprite = pause;
                videoPlayer.Pause();
                isPlay = false;
            }
            else
            {
                playPauseButton.image.sprite = play;
                videoPlayer.Play();
                isPlay = true;
            }
        }
    }

    void StopVideo()
    {
        videoPlayer.Stop();
        playPauseButton.image.sprite = play;
        videoTimeSlider.gameObject.SetActive(false);
        videoNameText.text = "";
        videoTimeText.text = "";
        isPlay = true;
    }

}
