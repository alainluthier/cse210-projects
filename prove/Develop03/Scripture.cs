class Scripture{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    public Scripture(Reference reference,string text){
        _reference=reference;
        string[] textSplit=text.Split(" ");
        for(int i=0;i<textSplit.Length;i++) {
            _words.Add(new Word(textSplit[i]));
        }
    }
    public void HideRandom(int numberToHide){
        Random randomGenerator=new Random();
        int hidden=0;
        while(hidden<numberToHide && !isCompletelyHidden()){
            int number = randomGenerator.Next(0, _words.Count);
            if(!_words[number].isHidden()){
                _words[number].Hide();
                hidden=hidden+1;
            }
        }
        
    }
    public string GetDisplayText(){
        string text=$"{_reference.GetDisplayText()} ";
        foreach (Word word in _words)
        {
            text=text+word.GetDisplayText()+" ";
        }
        return text;
    }
    public bool isCompletelyHidden(){
        foreach (Word word in _words)
        {
            if(!word.isHidden()){
                return false;
            }
        }
        return true;
    }
}