using System;

public class Birthday
{
	private int _id;
	public int Id {
		get 
		{
			return _id;
		}
		set 
		{ 
			if (value < 0) value = -value;
			_id = value;
		}
	}
	public string Name { get; set; }
	public string Surname { get; set; }
	public DateOnly Date { get; set; }
    public Birthday(int id, string name, string surname, DateOnly date)
    {
        if (id < 0) id = -id;
        _id = id;
		Name = name;
		Surname = surname;
		Date = date;
    }
	public override string ToString()
	{
		return $"{Id}. {Name} {Surname} : {Date}";
	}
}
