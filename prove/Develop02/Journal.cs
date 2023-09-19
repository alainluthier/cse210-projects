public class Journal{
    public string _fileName;
    public List<Record> _records = new List<Record>();
   
    public void Display(){
        foreach (Record record in _records)
        {
            Console.WriteLine("");
            record.Display();
        }
    }
    public void Save(){
        string csv = "";
        foreach (Record record in _records)
        {
            string newLine=$"{record._date.ToShortDateString()};{record._prompt};{record._response}\n";
            csv+=newLine;    
        }
        File.WriteAllText(_fileName,csv.ToString());
    }
    public void Load(){
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string line in lines)
        {
            string[] values = line.Split(";");
            Record record = new Record();
            record._date = Convert.ToDateTime(values[0]);
            record._prompt = values[1];
            record._response = values[2];
            _records.Add(record);
        }
    }
}