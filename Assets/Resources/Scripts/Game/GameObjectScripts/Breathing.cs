using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class Breathing : MonoBehaviour
{
    float breathesPerMinute = 16;
    Queue<float> recordedDelayTimes = new Queue<float>();
    Stopwatch total = new Stopwatch();
    float idealTime = 0;
    CharacterStats characterStats;

    private void Start()
    {
        total.Start();
        if (GetComponent<CharacterStats>())
        {
            characterStats = GetComponent<CharacterStats>();
        }
        else
            throw new Exception("Requires 'CharacterStats' or its subclass to initialize.");

        StartCoroutine(breatheInCoroutine());
    }
    private void breatheIn()
    {
        //UnityEngine.Debug.Log("Breathe In");
    }
    private void breatheOut()
    {
        characterStats.setStamina(characterStats.getStamina() + (characterStats.vigor / breathesPerMinute));
        //UnityEngine.Debug.Log("Breathe Out");

        //UnityEngine.Debug.Log("Ideal:" + idealTime + ", Actual:" + total.Elapsed.TotalSeconds.ToString() + ", Offset:" + ((float)total.Elapsed.TotalSeconds - idealTime));
    }

    private IEnumerator breatheInCoroutine()
    {
        float idealBeatTime = getIdealBreathTime();
        float breatheInTime = getBreatheInTime(idealBeatTime);
        TimeSpan ts = total.Elapsed;
        //UnityEngine.Debug.Log("TimeOffFromIdeal: " + timeOffSet + ", AddedTime: " + average);
        while (((float)ts.TotalSeconds - idealTime) > getIdealBreathTime())
        {
            breatheIn();
            breatheOut();

            idealTime += getIdealBreathTime();
            UnityEngine.Debug.Log("Quick Breath");
        }
        yield return new WaitForSeconds((breatheInTime - getAverageDelay()) - ((float)ts.TotalSeconds - idealTime));
        breatheIn();
        float breatheOutTime = idealBeatTime - breatheInTime;
        StartCoroutine(breatheOutCoroutine(breatheOutTime));
    }
    private IEnumerator breatheOutCoroutine(float breatheOutTime)
    {
        yield return new WaitForSeconds(breatheOutTime);
        idealTime += getIdealBreathTime();
        breatheOut();
        recordedDelayTimes.Enqueue((float)total.Elapsed.TotalSeconds - idealTime);
        StartCoroutine(breatheInCoroutine());
    }
    private float getAverageDelay()
    {
        float totalRecordedTime = 0;
        while (recordedDelayTimes.Count > 10)
            recordedDelayTimes.Dequeue();
        foreach (float f in recordedDelayTimes)
            totalRecordedTime += f;
        if (Single.IsNaN(totalRecordedTime / recordedDelayTimes.Count))
            return 0;
        else
            return (totalRecordedTime / recordedDelayTimes.Count);
    }

    private float getBreatheInTime(float idealBeatTime)
    {
        float maxWait = idealBeatTime;
        float minWait = idealBeatTime / 2;
        return UnityEngine.Random.Range(minWait, maxWait);
    }
    private float getIdealBreathTime()
    {
        return (60 / breathesPerMinute);
    }
}
