namespace Todo.Api.Requests;

public class TodoItem
{
    private string _text;

    public Guid Id { get; set; }
    
    public DateTime Created { get; set; }

    public string Text
    {
        get => _text;
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _text = value.ToUpper();
            }
        }
    }

    public DateTime? Completed { get; set; }
}