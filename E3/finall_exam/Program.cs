// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//0
public class Animal
{
    public virtual string MakeSound()
    {
        return "Some generic animal sound";
    }
}


public class Dog : Animal
{
    public override string MakeSound()
    {
        return "Woof";
    }
}



//2
public class Comparer<T> where T : IComparable<T>
{
    private T _first;
    private T _second;

    public Comparer(T first, T second)
    {
        _first = first;
        _second = second;
    }

    public T GetLarger()
    {
        return _first.CompareTo(_second) >= 0 ? _first : _second;
    }
}



public class Product : IComparable<Product>
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public int CompareTo(Product other)
    {
        if (other == null) return 1;
        return this.Price.CompareTo(other.Price);
    }
}


//3
public class ResourceManager : IDisposable
{
    public bool IsDisposed { get; private set; } = false;

  
    private MemoryStream _stream;

    public ResourceManager()
    {
        _stream = new MemoryStream();
    }

    public void Use()
    {
        if (IsDisposed)
            throw new ObjectDisposedException(nameof(ResourceManager));

       
        byte[] buffer = new byte[10];
        _stream.Write(buffer, 0, buffer.Length);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            if (disposing)
            {
                
                _stream?.Dispose();
            }

           

            IsDisposed = true;
        }
    }

    ~ResourceManager()
    {
        Dispose(false);
    }
}

//6
public struct Money : IEquatable<Money>
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    
    public static Money operator +(Money m1, Money m2)
    {
        if (m1.Currency != m2.Currency)
            throw new InvalidOperationException("Cannot add Money with different currencies.");

        return new Money(m1.Amount + m2.Amount, m1.Currency);
    }

    
    public static bool operator ==(Money m1, Money m2) => m1.Equals(m2);
    public static bool operator !=(Money m1, Money m2) => !m1.Equals(m2);

   
    public bool Equals(Money other)
    {
        return Amount == other.Amount && Currency == other.Currency;
    }

    public override bool Equals(object obj)
    {
        return obj is Money other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }
}


//7
// public static class DelegateProblems
// {
//     public static string ProcessString(string input, StringOperation operation)
//     {
//         return operation(input);
//     }

//     public static string ToUpper(string input)
//     {
//         return input.ToUpper();
//     }

//     public static string ToLower(string input)
//     {
//         return input.ToLower();
//     }
// }



//8



public static class LambdaProblems
{
    public static Func<string, int> GetStringLengthCalculator()
    {
        return s => s.Length;
    }
}


//13
public class DataService
{


    public async Task<string?> FetchDataAsync(string v)
    {
        throw new NotImplementedException();

    }

    public async Task<string> GetDataAsync()
    {
        await Task.Delay(2000);
        return "delay";
    }
}


//14
public interface IEntity
{
    Guid Id { get; set; }
}

public class Customer : IEntity
{
    public Guid Id { get; set; }
   
}


public class Order : IEntity
{
    public Guid Id { get; set; }
   
}
public class Repository<T> where T : IEntity, new()
{
    public T CreateNew()
    {
        return new T();
    }
}


//1
public class MyPointType1
{
    public int X;
    public int Y;
}

public struct MyPointType2
{
    public int X;
    public int Y;
}
public static class ValueAndReference
{
    public static void ChangeType1(MyPointType1 point)
    {
        point.X = 100;
    }

    public static void ChangeType2(MyPointType2 point)
    {
        point.X = 100;
    }
}

//11
public static class Closures
{
    public static Func<int> CreateCounter()
    {
        int count = 0;
        return () =>
        {
            count++;
            return count;
        };
    }
}
