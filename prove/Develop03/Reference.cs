using System;

public class Reference
{
    private string book;
    private int chapter;
    private int verseStart;
    private int verseEnd;
    private bool hasRange;

    // Constructor for one verse
    public Reference(string bookName, int chapterNumber, int verseNumber)
    {
        book = bookName;
        chapter = chapterNumber;
        verseStart = verseNumber;
        verseEnd = verseNumber;
        hasRange = false;
    }

    // Constructor for multiple verses
    public Reference(string bookName, int chapterNumber, int startVerse, int endVerse)
    {
        book = bookName;
        chapter = chapterNumber;
        verseStart = startVerse;
        verseEnd = endVerse;
        hasRange = true;
    }

    public string GetDisplayText()
    {
        if (hasRange)
        {
            return book + " " + chapter + ":" + verseStart + "-" + verseEnd;
        }
        else
        {
            return book + " " + chapter + ":" + verseStart;
        }
    }
}
