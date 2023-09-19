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
            if(_fileName.Contains(".csv"))
            {
                string csv = "";
                foreach (Record record in _records)
                {
                    string newLine=$"\"{record._date.ToShortDateString()}\",\"{record._prompt}\",\"{record._response}\"\n";
                    csv+=newLine;    
                }
                File.WriteAllText(_fileName,csv.ToString());
            }
            else{
                Console.WriteLine("Wrong extention file it must be .csv");
            }
    }
    public void Load(){
       
            if(_fileName.Contains(".csv")){
                string[] lines = System.IO.File.ReadAllLines(_fileName);
                foreach (string line in lines)
                {
                    string[] values = line.Split(",");
                    Record record = new Record();
                    record._date = Convert.ToDateTime(values[0].Replace("\"",""));
                    record._prompt = values[1].Replace("\"","");
                    record._response = values[2].Replace("\"","");
                    _records.Add(record);
                }
            }else{
                Console.WriteLine("Wrong extention file it must be .csv");
            }
    }
}