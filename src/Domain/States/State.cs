
namespace Domain.States;

public class State : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    private State()
    {

    }

    private State(string name, string code, Guid id = default) : base(id)
    {
        this.Code = code;
        this.Name = name;
    }

    public static Result<State> Create(string name, string code, Guid id = default)
    {
        return new State(name, code, id);
    }
}
