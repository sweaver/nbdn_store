using System;

namespace nothinbutdotnetstore
{
    public static class StubExtensions
    {
        public static ItemToStub until<ItemToStub>(this ItemToStub instance, string date) where ItemToStub : new()
        {
            Stub.a<ItemToStub>().until(date);
        } 
    }

    public class Stub
    {
        public static StubBuilder<ItemToStub> a<ItemToStub>() where ItemToStub : new()
        {
            return new StubBuilder<ItemToStub>();
        }
    }

    public class StubBuilder<ItemToStub> where ItemToStub : new()
    {
        public ItemToStub until(string date_as_string)
        {
            ensure_can_still_stub(date_as_string);
            return new ItemToStub();
        }

        void ensure_can_still_stub(string date_as_string)
        {
            if (DateTime.Parse(date_as_string) > DateTime.Now) return;

            throw new ArgumentException(string.Format("You should not still be trying to stub using the {0}",
                                                      typeof(ItemToStub).Name));
        }
    }
}