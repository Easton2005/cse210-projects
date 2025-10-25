using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random;

    public Scripture(Reference referenceObject, string text)
    {
        reference = referenceObject;
        words = new List<Word>();
        random = new Random();

        string[] splitWords = text.Split(' ');
        for (int i = 0; i < splitWords.Length; i++)
        {
            words.Add(new Word(splitWords[i]));
        }
    }

    public string GetDisplayText()
    {
        string result = reference.GetDisplayText() + " - ";

        for (int i = 0; i < words.Count; i++)
        {
            result += words[i].GetDisplayText();

            if (i < words.Count - 1)
            {
                result += " ";
            }
        }

        return result;
    }

    public bool HideRandomWords(int numberToHide)
    {
        List<int> visibleIndexes = new List<int>();

        for (int i = 0; i < words.Count; i++)
        {
            if (!words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        if (visibleIndexes.Count == 0)
        {
            return true; // All words hidden
        }

        for (int i = 0; i < numberToHide; i++)
        {
            if (visibleIndexes.Count == 0)
            {
                break;
            }

            int randomIndex = random.Next(0, visibleIndexes.Count);
            int wordIndex = visibleIndexes[randomIndex];
            words[wordIndex].Hide();
            visibleIndexes.RemoveAt(randomIndex);
        }

        // Check if all words are hidden
        bool allHidden = true;
        for (int i = 0; i < words.Count; i++)
        {
            if (!words[i].IsHidden())
            {
                allHidden = false;
                break;
            }
        }

        return allHidden;
    }
}
