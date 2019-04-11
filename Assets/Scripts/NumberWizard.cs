using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    //[SerializeField] TextMeshProUGUI victoryText;

    private TreeNode root;
    private TreeNode tree;
    private TreeNode guessNode;    
    
    // Game 
    int guess;
    private readonly int higher = +1;
    private readonly int lower = -1;
    
    // Start is called before the first frame update
    public void Start()
    {
        ResetGame();
    }

    public void OnPressHigher()
    {
        if (min < max)
        {
            min = guess + 1;
            UpdateGuess(higher);
        }
    }

    public void OnPressLower()
    {
        max = guess;
        UpdateGuess(lower);
    }

    private void NewGuess(int newMin, int newMax)
    {
        guess = Random.Range(min, max);
        guessText.text = guess.ToString();
    }

    private void UpdateGuess(int direction)
    {
        NewGuess(min, max);

        tree.Add(guess);
        if (direction > 0)
        {
            tree = tree.Right;
        }
        else
        {
            tree = tree.Left;
        }        
    }

    private void ResetGame()
    {
        NewGuess(min, max + 1);
        root = new TreeNode(guess);
        tree = root;
    }

    public void Victory()
    {
        int guessCount = 0;
        Queue<TreeNode> guessQueue = new Queue<TreeNode>();
        guessQueue.Enqueue(root);
        while (guessQueue.Count > 0)
        {
            guessCount++;
            root = guessQueue.Dequeue();
            
            if (root.Left != null)
            {
                guessQueue.Enqueue(root.Left);
            }
            if (root.Right != null)
            {
                guessQueue.Enqueue(root.Right);
            }
        }

        //victoryText.text = $"Victory! It only took me {guessCount} tries!";
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else        
            Application.Quit();
        #endif
    }
}
