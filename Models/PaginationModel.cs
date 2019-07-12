using System;
namespace Cos.Models{
    public class PaginationModel<T>
    {
        public T Data{get;set;}
        public int Index{get;set;}
        public int Size{get;set;}

        public PaginationModel()
        {
            Index=1;
            Size=20;
        }
    }
}