namespace MusicApp.Infra.ORM.EntitiesMapping.Base;

public class BaseMapping(string schema)
{
    private const string SchemaDefault = "MusicApp";
    protected string Schema = schema;

    protected BaseMapping() : this(SchemaDefault)
    {
    }
}