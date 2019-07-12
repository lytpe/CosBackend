using System;
using System.Collections;
namespace Cos.Models{
    public class BaseResultModel<T>:BaseModel
    {
        public T Data{get;set;}
    }
}