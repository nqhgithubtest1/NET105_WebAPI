void DongBo()
{
    Console.WriteLine("Bat dau cong viec 1...");
    Task.Delay(5000).Wait();
    Console.WriteLine("Ket thuc cong viec 1.");
}

async void BatDongBo()
{
    Console.WriteLine("Bat dau cong viec 1...");
    await Task.Delay(5000);
    Console.WriteLine("Ket thuc cong viec 1.");
}

async void SomeMethod()
{
    Console.WriteLine("Some Method Started......");
    await Task.Delay(TimeSpan.FromSeconds(10));
    Console.WriteLine("\n");
    Console.WriteLine("Some Method End");
}

Console.WriteLine("Bat dau cong viec 2...");
BatDongBo();
Console.WriteLine("Ket thuc cong viec 2.");
Console.ReadKey();