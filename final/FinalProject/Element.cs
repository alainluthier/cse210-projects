public abstract class Element{
    private string _side; //top or bottom
    public Element(){
        this._side="top";
    }
    public abstract string GetStringRepresentation();
    public void setSide(string side){
        this._side=side;
    }
    public string getSide(){
        return this._side;
    }
    public bool IsEquals(Element element){
        if(GetStringRepresentation()==element.GetStringRepresentation()){
            return true;
        }
        return false;
    }
}