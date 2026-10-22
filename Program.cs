using KavezoElszamolas;
List<Barista> osszlista=new List<Barista>();
string[] tarol = File.ReadAllLines("baristak.txt");
double alap = 12000;
double napifizetes = 0;
double ossznap = 0;
double oszto = 0;
double kaveszamossz = 0;
double atlag = 0;
double magasabb = 0;
string magasabbnev = "";
double rontasnelkul = 0;
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

    ossznap += alap;
    oszto += 1;


    kaveszamossz += vagot.EladottKavek;
    atlag = kaveszamossz / oszto;

    if (magasabb < alap)
    {
        magasabb = alap;
        magasabbnev = vagot.BaristaNev;
    }

    if (vagot.RontottItalok == 0)
    {
        rontasnelkul += 1;
    }

}

Console.WriteLine("Összesített statisztika:");
Console.WriteLine($"Kávézó által kifizetett teljes összeg: {ossznap} Ft");
Console.WriteLine($"Átlagos eladott kávészám baristánként: {atlag} kávé");
Console.WriteLine($"Legmagasabb napi fizetés: {magasabbnev} ({magasabb} Ft)");
Console.WriteLine($"Rontott ital nélkül dolgozó baristák száma: {rontasnelkul} fő");