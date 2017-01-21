using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void GameStateChange();
    public static event GameStateChange OnGameInit;
    public static event GameStateChange OnGameStart;
    public static event GameStateChange OnGameResume;
    public static event GameStateChange OnGamePause;
    public static event GameStateChange OnGameOver;

    public delegate void TurnStateChange();

    public enum EventMessage {
                                GameInit, GameStart, GameResume,
                                GamePause, GameOver, RoundReady,
                                RoundStart, RoundRestart, RoundResults,
                                RoundOver, RoundSpin, TargetHit,
                                TargetMiss, BasicTargetHit, SpecialTargetHit,
                                MysteryBoxHit, TimeManipulated, OmniHit,
                                MultiplierUsed, SoundOn, SoundOff,
                                MusicOn, MusicOff, AchievementUnlocked
                            }
    /**
     */
    public static void Broadcast(EventMessage msg)
    {
        switch(msg)
        {
            case EventMessage.GameInit:
                if(OnGameInit != null)
                    OnGameInit();
                break;

            case EventMessage.GameStart:
                if(OnGameStart != null)
                    OnGameStart();
                break;

            case EventMessage.GameResume:
                if(OnGameResume != null)
                    OnGameResume();
                break;

            case EventMessage.GamePause:
                if(OnGamePause != null)
                    OnGamePause();
                break;

            case EventMessage.GameOver:
                if(OnGameOver != null)
                    OnGameOver();
                break;
        }
    } // end Broadcast()
}
