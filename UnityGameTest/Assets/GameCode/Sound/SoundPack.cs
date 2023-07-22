using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu(fileName = "New Sound Pack", menuName = "Sound System/SoundPack")]
public class SoundPack : ScriptableObject
{
    public List<AudioClip> Container = new List<AudioClip>();
}
