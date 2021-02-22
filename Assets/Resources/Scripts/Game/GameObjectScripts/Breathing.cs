using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class Breathing : MonoBehaviour
{
    float breathesPerMinute = 60;
    private float timeOffSet = 0;
    private Queue<float> averageList = new Queue<float>();
    Stopwatch stopWatch = new Stopwatch();
    CharacterStats characterStats;

    private void Start()
    {
        timeOffSet += 60 / breathesPerMinute;
        characterStats = GetComponent<CharacterStats>();
        StartCoroutine(breatheInCoroutine());
    }
    private void breatheIn()
    {

    }
    private void breatheOut()
    {
        characterStats.setStamina(characterStats.getStamina() + (characterStats.vigor / breathesPerMinute));
    }

    private IEnumerator breatheInCoroutine()
    {
        float idealBeatTime = 60 / breathesPerMinute;
        float breatheInTime = getBreatheInTime(idealBeatTime);
        TimeSpan ts = stopWatch.Elapsed;
        stopWatch.Restart();
        float average = getAverageDelayTime(ts, idealBeatTime);

        //UnityEngine.Debug.Log(timeOffSet);

        if (timeOffSet > 0)
            yield return new WaitForSeconds(breatheInTime - (timeOffSet + average));
        else
            yield return new WaitForSeconds(breatheInTime - timeOffSet);
        breatheIn();
        float breatheOutTime = idealBeatTime - breatheInTime;
        StartCoroutine(breatheOutCoroutine(breatheOutTime));
    }
    private float getAverageDelayTime(TimeSpan ts, float idealBeatTime)
    {
        timeOffSet += (float)ts.TotalSeconds - idealBeatTime;
        if (timeOffSet != 0)
            averageList.Enqueue(timeOffSet);

        float totalAverage = 0;

        if (averageList.Count > 20)
            averageList.Dequeue();

        foreach (float f in averageList)
            totalAverage += f;

        return totalAverage / averageList.Count;
    }
    private IEnumerator breatheOutCoroutine(float breatheOutTime)
    {
        yield return new WaitForSeconds(breatheOutTime);
        breatheOut();
        StartCoroutine(breatheInCoroutine());
    }
    private float getBreatheInTime(float idealBeatTime)
    {
        float maxWait = idealBeatTime;
        float minWait = idealBeatTime / 2;
        return UnityEngine.Random.Range(minWait, maxWait);
    }
}
