using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibilityPackage.ExtPackage.Extensibility
{
    public class Type2<T>
    {
        public readonly T one, two;
        public Type2(T one, T two)
        {
            this.one = one;
            this.two = two;
        }
        public TypeToGet[] GetValues<TypeToGet>(int OptMethod = (int)GetValueMethod.Normal)
        {
            TypeToGet[] Tarray = new TypeToGet[2];
            TypeToGet _one, _two;
            if (typeof(TypeToGet) == typeof(string))
            {
                if (OptMethod == (int)GetValueMethod.RemoveDot)
                {
                    if (one.ToString().Contains("."))
                    {
                        _one = (TypeToGet)(object)one.ToString().Remove(one.ToString().LastIndexOf('.')).Replace(".", "");
                    }
                    else
                    {
                        _one = (TypeToGet)(object)one.ToString();
                    }
                    if (two.ToString().Contains("."))
                    {
                        _two = (TypeToGet)(object)two.ToString().Remove(two.ToString().LastIndexOf('.')).Replace(".", "");
                    }
                    else
                    {
                        _two = (TypeToGet)(object)two.ToString();
                    }
                }
                else
                {
                    _one = (TypeToGet)(object)one.ToString();
                    _two = (TypeToGet)(object)two.ToString();
                }
            }
            else if (typeof(TypeToGet) == typeof(int))
            {
                if (one.ToString().Contains("."))
                {
                    _one = (TypeToGet)(object)int.Parse(one.ToString().Remove(one.ToString().LastIndexOf('.')).Replace(".", ""));
                }
                else
                {
                    _one = (TypeToGet)(object)int.Parse(one.ToString());
                }
                if (two.ToString().Contains("."))
                {
                    _two = (TypeToGet)(object)int.Parse(two.ToString().Remove(two.ToString().LastIndexOf('.')).Replace(".", ""));
                }
                else
                {
                    _two = (TypeToGet)(object)int.Parse(two.ToString());
                }
            }
            else
            {
                _one = (TypeToGet)(object)one;
                _two = (TypeToGet)(object)one;
            }
            Tarray[0] = _one;
            Tarray[1] = _two;
            return Tarray;
        }
    }
    public class Type3
    {
        public readonly float one, two, three;
        public Type3(float one, float two, float three)
        {
            this.one = one;
            this.two = two;
            this.three = three;
        }
    }
}
enum GetValueMethod
{
    Normal = 0,
    RemoveDot = 1,
}
