using System;

public class Word
{
    private string text;
    private bool hidden;

    public Word(string wordText)
    {
        text = wordText;
        hidden = false;
    }

    public void Hide()
    {
        hidden = true;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public string GetDisplayText()
    {
        if (hidden)
        {
            string underscores = "";
            for (int i = 0; i < text.Length; i++)
            {
                underscores += "_";
            }
            return underscores;
        }
        else
        {
            return text;
        }
    }
}
 