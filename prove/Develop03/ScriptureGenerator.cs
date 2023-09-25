class ScriptureGenerator{
    private string _fileName;
    private List<Scripture> _scriptures = new List<Scripture>();
    public ScriptureGenerator(string fileName){
        _fileName=fileName;
        if(_fileName.Contains(".csv")){
                string[] lines = System.IO.File.ReadAllLines(_fileName);
                foreach (string line in lines)
                {
                    //"Book Chapter:verse-endVerse","text"
                    string[] values = line.Split("|");
                    Reference reference = new Reference(values[0].Replace("\"",""));
                    Scripture scripture = new Scripture(reference,values[1].Replace("\"",""));
                    _scriptures.Add(scripture);
                }
            }else{
                Console.WriteLine("Wrong extention file it must be .csv");
        }
    }
    public Scripture RandomScripture(){
        Random randomGenerator=new Random();
        int number = randomGenerator.Next(0, _scriptures.Count);
        return _scriptures[number];
    }
}