namespace nothinbutdotnetstore.web.infrastructure
{
    public interface TokenAppenderFactory
    {
        TokenAppender<Item> create_appender<Item>(Item item, LinkBuilder builder);
    }
}