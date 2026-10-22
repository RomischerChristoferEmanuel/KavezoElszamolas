using KavezoElszamolas;
List<Barista> osszlista=new List<Barista>();
string[] tarol = File.ReadAllLines("baristak.txt");
double alap = 12000;
double napifizetes = 0;
Console.WriteLine("Baristák napi elszámolása:");
foreach (string line in tarol)
{
    Barista vagot=new Barista();
    string[] vag=line.Split(';');
    vagot.BaristaNev = vag[0];
    vagot.EladottKavek=int.Parse(vag[1]);
    vagot.NapiBevetelFt = int.Parse(vag[2]);
    vagot.RontottItalok = int.Parse(vag[3]);
    osszlista.Add(vagot);

    
    napifizetes = alap + vagot.NapiBevetelFt*0.04;
    if(vagot.EladottKavek>=40 && vagot.RontottItalok <= 1)
    {
        alap += 8000;
    }
    else if (vagot.RontottItalok >= 2)
    {
        alap -= 5000;
    }
    Console.WriteLine($"{vagot.BaristaNev}: {vagot.EladottKavek} kávé, {vagot.NapiBevetelFt} Ft bevétel (Rontott: {vagot.RontottItalok}) - Fizetés: {alap} Ft");


}