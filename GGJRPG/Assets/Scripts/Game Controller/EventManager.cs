﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Game Controller/Event Manager")]
public class EventManager : MonoBehaviour
{
    public delegate void GameStateChange();
    public static event GameStateChange OnGameInit;
    public static event GameStateChange OnGameStart;
    public static event GameStateChange OnGameResume;
    public static event GameStateChange OnGamePause;
    public static event GameStateChange OnGameOver;

    public delegate void OptionChange();
    public static event OptionChange OnSoundOn;
    public static event OptionChange OnSoundOff;
    public static event OptionChange OnMusicOn;
    public static event OptionChange OnMusicOff;

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

            case EventMessage.SoundOn:
                if(OnSoundOn != null)
                    OnSoundOn();
                break;

            case EventMessage.SoundOff:
                if(OnSoundOff != null)
                    OnSoundOff();
                break;

            case EventMessage.MusicOn:
                if(OnMusicOn != null)
                    OnMusicOn();
                break;

            case EventMessage.MusicOff:
                if(OnMusicOff != null)
                    OnMusicOff();
                break;
        }
    } // end Broadcast()
}
