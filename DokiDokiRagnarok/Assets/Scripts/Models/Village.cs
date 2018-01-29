using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DokiDokiRagnarok;
public static class Village {

    public static Emotion Emotion;
    public static bool AttackedEnglandWhileAngry;
    public static bool AttackedEnglandWhileSweatDrop;

    public static void Reset()
    {
        Emotion = Emotion.None;
        AttackedEnglandWhileAngry = false;
        AttackedEnglandWhileSweatDrop = false;
        
    }
}
