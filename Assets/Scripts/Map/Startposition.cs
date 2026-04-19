using UnityEngine;

public class Startposition : BaseMapObject
{

    static readonly string[] Namelist =
        {
        "Alpha",
"Beta",
"Gamma",
"Delta",
"Epsilon",
"Zeta",
"Eta",
"Theta",
"Iota",
"Kappa",
"Lambda",
"Mu",
"Nu",
"Xi",
"Omicron",
"Pi",
"Rho",
"Sigma",
"Tau",
"Upsilon",
"Phi",
"Chi",
"Psi",
"Omega", 
"forfuckssake", 
"toomanystarts", 
"seriously", 
"thisoughttobeenough", 
"whysomany",
"idon'tseriouslythinkineedthismanyhonestly", 
"butjustincase", 
"mightaswell", 
"doesn'tmatterreally", 
"justneedstobeastring"
        };


    public MapScript map;


    public string Name; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void RegisterMapObject(MapScript mapScript)
    {
        map = mapScript;
        mapScript.Startpositions.Add(this);
        Name = Namelist[mapScript.Startpositions.Count - 1];
    }

}
