namespace nothinbutdotnetstore.web.infrastructure
{
    public interface Request
    {
        string full_command { get; }
        ViewModel map<ViewModel>();
    }
}