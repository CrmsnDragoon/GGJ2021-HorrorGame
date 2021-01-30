using UnityEngine;

public class Journal : MonoBehaviour
{
    public void JournalOpened()
    {
        Global.BlockInput();
    }
    public void JournalClosed()
    {
        Global.UnblockInput();
    }
}
