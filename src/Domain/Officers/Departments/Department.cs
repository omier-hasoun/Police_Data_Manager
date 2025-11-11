namespace Domain.Officers.Departments;

public sealed class Department : Entity
{
    public string Name { get; private set; } = string.Empty;

    private Department()
    {

    }

    private Department(string name) : base()
    {
        this.Name = name;
    }

    public static Result<Department> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.Validation("cosiejfj");
        }
        return new Department(name);
    }
}
