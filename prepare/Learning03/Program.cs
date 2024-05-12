using System;
using System.Collections.Generic;

class Word
{
    private string _text;

    public Word(string text)
    {
        _text = text;
    }

    public override string ToString()
    {
        return _text;
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    // Constructor for single verse
    public Reference(string book, int chapter, int verseStart)
        : this(book, chapter, verseStart, verseStart)
    {
    }

    // Constructor for verse range
    public Reference(string book, int chapter, string verses)
    {
        _book = book;
        _chapter = chapter;

        string[] parts = verses.Split('-');
        _verseStart = int.Parse(parts[0]);
        _verseEnd = int.Parse(parts[1]);
    }

    public override string ToString()
    {
        if (_verseStart == _verseEnd)
            return $"{_book} {_chapter}:{_verseStart}";
        else
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private HashSet<int> _hiddenIndices;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _hiddenIndices = new HashSet<int>();

        // Split the text into words
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference);
        foreach (Word word in _words)
        {
            if (_hiddenIndices.Contains(_words.IndexOf(word)))
            {
                Console.Write("_ ");
            }
            else
            {
                Console.Write(word + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideRandomWords(int wordsToHideCount)
    {
        Random rand = new Random();

        // Hide all remaining words if there are fewer words to hide than the count requested
        if (wordsToHideCount > _words.Count - _hiddenIndices.Count)
        {
            wordsToHideCount = _words.Count - _hiddenIndices.Count;
        }

        // Hide words
        for (int i = 0; i < wordsToHideCount; i++)
        {
            int index;
            do
            {
                index = rand.Next(0, _words.Count);
            } while (_hiddenIndices.Contains(index));

            _hiddenIndices.Add(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _hiddenIndices.Count == _words.Count;
    }

    public int CountWordsToHide()
    {
        return Math.Min(+3, _words.Count - _hiddenIndices.Count);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Mosiah", 2, 17);
        string scriptureText = "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God";

        Scripture scripture = new Scripture(reference, scriptureText);

        do
        {
            int wordsToHideCount = scripture.CountWordsToHide(); // Number of words to hide in each iteration
            scripture.Display();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else
            {
                scripture.HideRandomWords(wordsToHideCount); // Hide words
            }
        } while (!scripture.AllWordsHidden());
    }
}
