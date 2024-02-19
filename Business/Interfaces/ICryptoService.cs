using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces;
public interface ICryptoService
{
    public string Hash(string str);
    public bool Verify(string raw, string hash);
}
