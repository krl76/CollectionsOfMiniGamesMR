using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    public bool _isPick;

    private void Awake()
    {
        _isPick = false;
    }

    public void PickOfPlayer(string name)
    {
        try
        {
            if (FindAnyObjectByType<RockPaperScissors>()._isStart && !_isPick)
            {
                FindAnyObjectByType<RockPaperScissors>().PlayerPick(name);
                _isPick = true;
            }
        }
        catch
        {
            // ignored
        }
    }
}
