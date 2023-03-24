
class nim
{
    static void Main(string[] args)
    {

        var w = new w();
        var w1 = new W1(w);
        var w2 = new W2(w1);
        w2.In();
        var bu = new Application();
        bu.Use(n =>
        {
            return n2 =>
            {
                Console.WriteLine("A1");
                n(n2);
                Console.WriteLine("A2");
            };
        });
        bu.Use(n =>
        {
            return n2 =>
            {
                Console.WriteLine("B1");
                n(n2);
                Console.WriteLine("B2");
            };
        });
        bu.Use(n =>
        {
            return n2 =>
            {
                Console.WriteLine("OK");
              
                 Console.WriteLine("OK");
            };
        });
        var app =bu.Bulid();
        app(new HttpC());
    }
}
public interface Iw
{
    public void In();
}
public class w : Iw
{
    public void In()
    {
        Console.WriteLine("很好");
    }
}
public class W1 : Iw
{
    private Iw _iw;
    public W1(Iw iw)
    {
        _iw = iw;
    }
    public void In()
    {
        Console.WriteLine("W1 我1");
        _iw.In();
        Console.WriteLine("W1 你1");
    }
}
public class W2 : Iw
{
    private Iw _iw;
    public W2(Iw iw)
    {
        _iw = iw;
    }
    public void In()
    {
        Console.WriteLine("W2 我2");
        _iw.In();
        Console.WriteLine("W2 你2");
    }
}
public class HttpC
{
    public string Request { get; }
    public string Response { get; }
}

public delegate void RequestDelegate(HttpC context);
public class Application
{
    private List<Func<RequestDelegate, RequestDelegate>> _copm = new();
    public void Use(Func<RequestDelegate,RequestDelegate> requser)
    {
        _copm.Add(requser);
    }
    public RequestDelegate Bulid()
    {
        RequestDelegate app= null;
     
        for (int i = _copm.Count-1; i > -1; i--)
        {
            //如果
            app = _copm[i](app);
        }
        return app;
    }
}
