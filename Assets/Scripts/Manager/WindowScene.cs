using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScene : MonoBehaviour
{
    public int windowWidth = 800;
    public int windowHeight = 600;

    void Start()
    {
        // Đặt kích thước cửa sổ khi trò chơi bắt đầu
        Screen.SetResolution(windowWidth, windowHeight, false);
    }
}
