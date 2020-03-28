using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BvsM.Events
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }

    }
#endif
}

