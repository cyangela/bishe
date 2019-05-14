using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class ToPlayVideo : MonoBehaviour
{
    public VideoClip[] videoClips;      // 视频的文件 参数
    //public Text videoNameText;          // 视频的名字
    public Text videoTimeText;          // 视频的当前时间 Text
    public Slider videoTimeSlider;      // 视频的时间 Slider

    internal VideoPlayer videoPlayer;
    private RawImage rawImage;
    public Texture pingBao;             // 屏保图片

    // 当前视频的总时间值和当前播放时间值的参数
    private int currentHour;
    private int currentMinute;
    private int currentSecond;

    public Sprite play;
    public Sprite pause;
    private bool isFristPlay = true;     //是否第一次播放
    private bool isDraging = false;      //是否正在拖拽

    public Button playPauseButton;       //播放暂停按钮

    [HideInInspector]
    public Button back_Button;           //上一个视频
    [HideInInspector]
    public Button go_Button;             //下一个视频

    public Button next_Button;

    private int current_Clips = 0;           //当前播放视频索引
    void Start()
    {
        //清空文本
        videoTimeText.text = "";

        //获取场景中对应的组件
        videoPlayer = this.GetComponent<VideoPlayer>();
        rawImage = this.GetComponent<RawImage>();

        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, this.GetComponent<AudioSource>());
        videoPlayer.IsAudioTrackEnabled(0);
        //注册事件
        playPauseButton.onClick.AddListener(PlayOrPause);
        //back_Button.onClick.AddListener(() => { VideoPlay(false); });
        //go_Button.onClick.AddListener(() => { VideoPlay(true); });
    }


    void Update()
    {
        //如果videoPlayer没有对应的视频texture，则返回屏保
        if (videoPlayer.texture == null)
        {
            rawImage.texture = pingBao;
            return;
        }

        //SetGoBack_Active();

        //视频播放结束
        if (!isFristPlay)
        {
            if ((ulong)videoPlayer.frame == videoPlayer.frameCount)
            {
                Debug.Log(000);
                videoPlayer.Stop();
                next_Button.gameObject.SetActive(true);
            }
        }

        // 把当前视频播放的时间比例赋值到 Slider 上
        if (!isDraging)
        {
            videoTimeSlider.value = (float)(videoPlayer.time / videoPlayer.clip.length);
        }

        //把VideoPlayerd的视频渲染到UGUI的RawImage
        rawImage.texture = videoPlayer.texture;
        ShowVideoTime();
    }

    /// <summary>
    /// 视频播放
    /// </summary>
    /// <param name="flag"></param>
    private void VideoPlay(bool flag)
    {
        if (flag)
        {
            videoPlayer.clip = videoClips[++current_Clips];
        }
        else
        {
            videoPlayer.clip = videoClips[--current_Clips];          
        }
        videoPlayer.Play();
        //videoNameText.text = videoClips[current_Clips].name;
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
        videoTimeText.text = string.Format("{0:D2}:{1:D2}:{2:D2}",currentHour, currentMinute, currentSecond);

        if (videoPlayer.isPlaying)
            playPauseButton.image.sprite = pause;
        else
            playPauseButton.image.sprite = play;
    }


    /// <summary>
    /// 视频播放暂停
    /// </summary>
    void PlayOrPause()
    {
        if (isFristPlay)
        {
            videoPlayer.clip = videoClips[current_Clips];
            //videoNameText.text = videoClips[current_Clips].name;
            videoPlayer.Play();
            playPauseButton.image.sprite = pause;
            isFristPlay = false;
            return;
        }
        //如果视频片段不为空，并且视频画面没有播放完毕 && (ulong)videoPlayer.frame < videoPlayer.frameCount
        if (videoPlayer.clip != null)
        {
            //如果视频正在播放
            if (videoPlayer.isPlaying)
            {
                playPauseButton.image.sprite = play;
                videoPlayer.Pause();
            }
            else
            {
                playPauseButton.image.sprite = pause;
                videoPlayer.Play();
            }
        }
    }

    /// <summary>
    /// 拖拽Slider事件
    /// </summary>
    /// <param name="flag"></param>
    public void DragEvent(bool flag)
    {
        if (flag)
        {
            isDraging = flag;
            videoPlayer.Pause();
        }
        else
        {
            isDraging = flag;
            videoPlayer.Play();
        }
    }

    /// <summary>
    /// 当前的 Slider 比例值转换为当前的视频播放时间
    /// </summary>
    public void SetVideoTimeValueChange()
    {
        videoPlayer.time = videoTimeSlider.value * videoPlayer.clip.length;
    }

    /// <summary>
    /// 设置前进后退按钮的活性
    /// </summary>
    private void SetGoBack_Active()
    {
        if (current_Clips == 0)
        {
            back_Button.gameObject.SetActive(false);
        }
        else
        {
            back_Button.gameObject.SetActive(true);
        }

        if ((videoClips.Length - 1) == current_Clips)
        {
            go_Button.gameObject.SetActive(false);
        }
        else
        {
            go_Button.gameObject.SetActive(true);
        }
    }
}