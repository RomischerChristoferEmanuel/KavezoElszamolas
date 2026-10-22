using KavezoElszamolas;
List<Barista> osszlista=new List<Barista>();
string[] tarol = File.ReadAllLines("baristak.txt");
foreach (string line in tarol)
{
    Barista vagot=new Barista();
    string[] vag=line.Split(';');
    vagot.BaristaNev = vag[0];
    vagot.EladottKavek=int.Parse(vag[1]);
    vagot.NapiBevetelFt = int.Parse(vag[2]);
    vagot.RontottItalok = int.Parse(vag[3]);

}