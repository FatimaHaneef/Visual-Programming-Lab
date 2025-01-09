using System.ComponentModel;

public class Student : INotifyPropertyChanged
{
    private string _name;
    private string _grade;
    private string _subject;
    private int _marks;
    private double _attendance;

    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }
    public string Grade
    {
        get => _grade;
        set { _grade = value; OnPropertyChanged(nameof(Grade)); }
    }
    public string Subject
    {
        get => _subject;
        set { _subject = value; OnPropertyChanged(nameof(Subject)); }
    }
    public int Marks
    {
        get => _marks;
        set { _marks = value; OnPropertyChanged(nameof(Marks)); }
    }
    public double Attendance
    {
        get => _attendance;
        set { _attendance = value; OnPropertyChanged(nameof(Attendance)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
