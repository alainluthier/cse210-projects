class Word{
    private string _text;
    private bool _isHidden;
    public Word(string text){
        _text=text;
        _isHidden=false;
    }
    public void Hide(){
        _isHidden=true;
    }
    public void Show(){
        _isHidden=false;
    }
    public bool isHidden(){
        return _isHidden;
    }
    public string GetDisplayText(){
        string newString="";
        if(_isHidden==false){
            return _text;
        }
        else{
            
            foreach (char s in _text)
            {
                newString = newString+"_";
            }
        }
        return newString;    
    }
}