class Reference{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    public Reference(string book,int chapter,int verse){
        _book=book;
        _chapter=chapter;
        _verse=verse;
    }
    public Reference(string book,int chapter,int startVerse,int endVerse){
        _book=book;
        _chapter=chapter;
        _verse=startVerse;
        _endVerse=endVerse;
    }
    public Reference(string text){
        string[] reference = text.Split(' ');
        if(reference.Length==2){
            _book=reference[0];
            string[] aux=reference[1].Split(':');
            if(aux.Length==2){
                _chapter=int.Parse(aux[0]);
                string[] verses=aux[1].Split('-');
                _verse=int.Parse(verses[0]);
                if(verses.Length==2){
                    _endVerse=int.Parse(verses[1]);
                }
            }
        }
    }
    public string GetDisplayText(){
        if (_endVerse==0){
            return $"{_book} {_chapter}:{_verse}";
        }
        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}