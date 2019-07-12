using System;
using System.Collections;
using System.Collections.Generic;
namespace Cos.Models{
    public class PaginationResultModel<T>:BaseModel{
        public List<T> Data{get;set;}
        public int Index{get;set;}
        public int Size{get;set;}
        public int Total{get;set;}
    }
}