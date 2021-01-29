using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeverGameManager : Bubble_MonoSingle<SeverGameManager>
{
    void Awake()
    {
        BubbleFrameEntry.Awake();
        
    }

    void Update()
    {
        BubbleFrameEntry.Update(Time.deltaTime);
    }
}
