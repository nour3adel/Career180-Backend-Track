namespace Main;

class Program
{
    static void Main(string[] args)
    {
        Duration D1 = new Duration(11, 12, 25);
        Duration D2 = new Duration(5, 10, 50);

 
        Duration D3 = D1 + D2;
        Console.WriteLine(D3);  
       
        D3 = D3 + 666;
        Console.WriteLine(D3);  

       
        D1++;
        Console.WriteLine(D1);  

       
        D2 = --D2;
        Console.WriteLine(D2);  

       
        if (D1 <= D2)
        {
            Console.WriteLine("D1 is less than or equal to D2");
        }
        else
        {
            Console.WriteLine("D1 is greater than D2");
        }
    }

    
}
