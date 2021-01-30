using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GhostSister))]
public class GhostSisterEditor :Editor
{
    //Draw position the good sister will teleport to
    private void OnSceneGUI()
    {
        var sister = target as GhostSister;
        if (sister != null)
        {
            for (var index = 0; index < sister.positions.Length; index++)
            {
                var position = sister.positions[index];
                sister.positions[index] = Handles.PositionHandle(position,Quaternion.identity);
            }
        }
    }
}
