using System;

class Program
{
    static void Main(string[] args)
    {
        
        /*List<Word> words = new List<Word>
        {new Word("Jesus"),new Word("answered,"),new Word("Verily,")};
        Reference reference = new Reference("John",3,5);
        Scripture scripture = new Scripture(reference,"Jesus answered, Verily, verily, I say unto thee, Except a man be born of water and of the Spirit, he cannot enter into the kingdom of God");*/
        
        ScriptureGenerator scriptureGenerator = new ScriptureGenerator("scriptures.csv");
        Scripture scripture = scriptureGenerator.RandomScripture();
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Press enter to continue or type 'quit' to finish:");
        string input="";
        input=Console.ReadLine();
        while(input !="quit" && !scripture.isCompletelyHidden()){
            scripture.HideRandom(3);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            input=Console.ReadLine();
        }
    }
}