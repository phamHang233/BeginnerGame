using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectionArrow : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;

    private int currentPos;
    private int count;

    private void Awake()
    {

        rect = GetComponent<RectTransform>();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1);
        }
    }
    private void ChangePosition(int _change)
    {
        count += 1;
        currentPos += _change;
        print(count);
        if (_change != 0)
        {
            SoundManager.instance.PlaySound(changeSound);
        }

        if (currentPos < 0)
            currentPos = options.Length - 1;
        else if (currentPos > options.Length - 1)
            currentPos = 0;
        rect.position = new Vector3(rect.position.x, options[currentPos].position.y, rect.position.z);
    }
}

internal class pirvate
{
}