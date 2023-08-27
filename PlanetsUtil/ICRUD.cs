using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsUtil
{
    public interface ICRUD<T> { 
    
        public bool Create(T obj, out string errorMessage) {
            errorMessage = null;
            return default(bool);
        }
        public T Read() { return default(T); }
        public void Update(T obj) { }
        public void Delete(T obj) { }
        public List<T> ReadAll() { return default(List<T>);}
        public bool Exists(T obj);
        //public void Save() { }
    }
    // How to call my own API (in class library) from other project?
    // https://stackoverflow.com/questions/1031431/how-to-call-my-own-api-in-class-library-from-other-project
    // How to call a method in a C# DLL, from another C# DLL
    // https://stackoverflow.com/questions/1031431/how-to-call-my-own-api-in-class-library-from-other-project



}
