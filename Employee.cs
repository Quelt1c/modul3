class Employee
{
    private string _name;
    private string _position;
    private DateTime _hireDate;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public DateTime HireDate
    {
        get { return _hireDate; }
        set { _hireDate = value; }
    }

    public Employee(string name, string position, DateTime hireDate)
    {
        _name = name;
        _position = position;
        _hireDate = hireDate;
    }
}


