using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Arc 
{
    public int Vertex { get; set; }

    public int Cost { get; set; }

    public override string ToString()
    {
        return "Vertex: " + Vertex + "  Cost: " + Cost;
    }

}

