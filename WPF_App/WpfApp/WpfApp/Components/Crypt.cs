using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Components
{
    public static class Crypt
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("your-16-byte-key"); 
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("your-16-byte-iv");
        
        
        
    }
}
