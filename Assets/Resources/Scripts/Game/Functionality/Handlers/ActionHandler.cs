﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionHandler
{
    private InputHandler inputHandler;

    public ActionHandler(InputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public void attemptActions(GameObject o, HashSet<CharacterAction> attemptedActions)
    {
        if (attemptedActions.Contains(CharacterAction.Escape))
        {
            Time.timeScale = 0;
            MonoBehaviour.Instantiate(GameObject.Find("ResourceObject").GetComponent<ResourceLoader>().getObjectPrefab("InGameMenu"),
new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            bool primaryClicked = attemptedActions.Contains(CharacterAction.MousePrimary);
            bool upPressed = attemptedActions.Contains(CharacterAction.MoveUp);
            bool rightPressed = attemptedActions.Contains(CharacterAction.MoveRight);
            bool downPressed = attemptedActions.Contains(CharacterAction.MoveDown);
            bool leftPressed = attemptedActions.Contains(CharacterAction.MoveLeft);
            bool userAttemptingToMove = false;

            if (primaryClicked || upPressed || rightPressed || downPressed || leftPressed)
                userAttemptingToMove = true;

            if (!userAttemptingToMove)
                new Action().attemptToStopMoving(o);
            else
                new Action().moving(o);


            if (primaryClicked)
            {
                GameObject clickedObject = inputHandler.CheckIfObjectAtPostion(Input.mousePosition);

                if (clickedObject != null)
                    //Debug.Log(clickedObject.name);
                    new Action().mouseMove(o, Input.mousePosition);
                else
                    new Action().mouseMove(o, Input.mousePosition);

            }

            if (!primaryClicked)
                if (upPressed || rightPressed || downPressed || leftPressed)
                    new Action().moveCardinal(o, attemptedActions, upPressed, rightPressed, downPressed, leftPressed);

        }

    }
}
class Action
{

    public void moveCardinal(GameObject o, HashSet<CharacterAction> actions, bool upPressed, bool rightPressed, bool downPressed, bool leftPressed)
    {
        Rigidbody2D rigidBody = o.GetComponent<Rigidbody2D>();
        float strength = o.GetComponent<Character>().strength;
        float velx = 0f, vely = 0f;

        if (upPressed) vely++;
        if (rightPressed) velx++;
        if (downPressed) vely--;
        if (leftPressed) velx--;

        if (upPressed && downPressed)
            attemptToStopMoving(o);

        if (leftPressed && rightPressed)
            attemptToStopMoving(o);

        // Creates a point 1 unit away from object in a cardinal or intercardinal direction.
        Vector2 position = Vector2.MoveTowards(rigidBody.position, rigidBody.position + new Vector2(velx, vely), 1);

        // Accelerates based off strength
        rigidBody.AddForce((position - rigidBody.position) * strength);
    }

    public void mouseMove(GameObject o, Vector2 mousePos)
    {
        moveToPoint(o, mousePos);
    }

    public void attemptToStopMoving(GameObject o)
    {
        // Slows down based on agilty
        o.GetComponent<Rigidbody2D>().drag = o.GetComponent<Character>().agility;
    }

    public void moving(GameObject o)
    {
        //Debug.Log(o.GetComponent<Rigidbody2D>().velocity.magnitude);
        o.GetComponent<Rigidbody2D>().drag = 1;
    }

    private void moveToPoint(GameObject o, Vector2 mousePos)
    {
        Camera mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        Rigidbody2D rigidBody = o.GetComponent<Rigidbody2D>();
        float strength = o.GetComponent<Character>().strength;
        if (mainCamera != null)
        {
            Vector2 target = mainCamera.ScreenToWorldPoint(mousePos);

            // Creates a point 1 unit away from object in a 360 degree direction.
            double deltaX = target.x - rigidBody.position.x;
            double deltaY = target.y - rigidBody.position.y;
            double directionToPoint = Math.Atan2(deltaY, deltaX);
            float dtpX = (float)(rigidBody.position.x + (1 * Math.Cos(directionToPoint)));
            float dtpY = (float)(rigidBody.position.y + (1 * Math.Sin(directionToPoint)));
            Vector2 direction = new Vector2(dtpX, dtpY) - rigidBody.position;
            //Debug.Log(direction);

            // Accelerates based off agility
            rigidBody.AddForce(direction * strength);
        }
    }

    /* AS LONG AS THE LINEAR DRAG COEFFICIENT IS >= 1  SPEED WILL NEVER ACCELERATE PAST FORCE APPLIED MAKING THIS FUNCTION SUPERFLUOUS
     * 
    private bool limitSpeedToMaxSpeed(Rigidbody2D rigidbody, float maxSpeed)
    {
        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            return true;
        }
        return false;
    }
    */
}
