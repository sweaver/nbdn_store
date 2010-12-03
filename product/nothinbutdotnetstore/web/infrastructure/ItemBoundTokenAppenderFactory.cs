namespace nothinbutdotnetstore.web.infrastructure
{
    public class ItemBoundTokenAppenderFactory : TokenAppenderFactory
    {
        public TokenAppender<Item> create_appender<Item>(Item item, DefaultLinkBuilder builder)
        {
            return new ItemBoundTokenAppender<Item>(item,builder);
        }
    }
}