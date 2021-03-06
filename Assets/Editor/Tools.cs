﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Tools
{
    public static Font new_Font = Resources.Load<Font>("造字工房悦圆");

    [MenuItem("GameObject/显示碰撞体", priority = 49)]
    public static void RemoveColliders()
    {
        Transform[] transforms = Selection.transforms;
        for (int i = 0; i < transforms.Length; i++)
        {
            ChangeColliders(transforms[i], true);
        }
    }

    [MenuItem("GameObject/隐藏碰撞体", priority = 49)]
    public static void AddColliders()
    {
        Transform[] transforms = Selection.transforms;
        for (int i = 0; i < transforms.Length; i++)
        {
            ChangeColliders(transforms[i], false);
        }
    }

    [MenuItem("GameObject/合并选中物体", priority = 49)]
    public static void Unite()
    {
        Transform[] transforms = Selection.transforms;
        Transform parent = transforms[0].parent;
        if (parent && parent.name == "666666")
            return;

        GameObject gameObject = new GameObject("666666");
        gameObject.transform.SetParent(parent);
        gameObject.transform.SetAsFirstSibling();
        //Selection.activeObject = gameObject;
        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].SetParent(gameObject.transform);
        }
    }

    [MenuItem("GameObject/添加脚本RWVR_SimpleGrab", priority = 49)]
    public static void AddRWVR_SimpleGrab()
    {
        Transform[] transforms = Selection.transforms;
        for (int i = 0; i < transforms.Length; i++)
        {
            if (!transforms[i].GetComponent<RWVR_SimpleGrab>())
            {
                transforms[i].gameObject.AddComponent<RWVR_SimpleGrab>().hideControllerModelOnGrab = true;
            }
        }
    }

    [MenuItem("GameObject/去掉脚本RWVR_SimpleGrab", priority = 49)]
    public static void RemoveRWVR_SimpleGrab()
    {
        Transform[] transforms = Selection.transforms;
        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i].GetComponent<RWVR_SimpleGrab>())
            {
                Object.DestroyImmediate(transforms[i].GetComponent<RWVR_SimpleGrab>());
            }
        }
    }

    [MenuItem("GameObject/修改字体", priority = 49)]
    public static void ChangeFonts()
    {
        Transform[] transforms = Selection.transforms;
        for (int i = 0; i < transforms.Length; i++)
        {
            ChangeFont(transforms[i]);
        }
    }
    [MenuItem("GameObject/修改字体颜色为白色", priority = 49)]
    public static void ChangeFontsColor()
    {
        Transform[] transforms = Selection.transforms;
        for (int i = 0; i < transforms.Length; i++)
        {
            ChangeFontColor(transforms[i]);
        }
    }

    //[MenuItem("GameObject/修改Tag为ExcludeTeleport", priority = 49)]
    //public static void Tag_ExcludeTeleport()
    //{
    //    Transform[] transforms = Selection.transforms;
    //    for (int i = 0; i < transforms.Length; i++)
    //    {
    //        ChangeTag(transforms[i], "ExcludeTeleport");
    //    }
    //}

    //[MenuItem("GameObject/修改Tag为Untagged", priority = 49)]
    //public static void Tag_Untagged()
    //{
    //    Transform[] transforms = Selection.transforms;
    //    for (int i = 0; i < transforms.Length; i++)
    //    {
    //        ChangeTag(transforms[i], "Untagged");
    //    }
    //}

    static void ChangeColliders(Transform transform, bool flag)
    {
        if (transform.GetComponent<Collider>())
        {
            transform.GetComponent<Collider>().enabled = flag;
        }
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                ChangeColliders(transform.GetChild(i), flag);
            }
        }
    }

    static void ChangeTag(Transform transform, string str)
    {

        transform.tag = str;

        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                ChangeTag(transform.GetChild(i), str);
            }
        }
    }

    static void ChangeFont(Transform transform)
    {
        if (transform.GetComponent<Text>())
        {
            transform.GetComponent<Text>().font = new_Font;
        }
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                ChangeFont(transform.GetChild(i));
            }
        }
    }
    static void ChangeFontColor(Transform transform)
    {
        if (transform.GetComponent<Text>())
        {
            transform.GetComponent<Text>().color = Color.white;
        }
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                ChangeFontColor(transform.GetChild(i));
            }
        }
    }
}
