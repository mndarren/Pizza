using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Service
    {
        private int _serviceCode;
        private string _serviceName;
        private float _serviceFee;

        public Service ()
	   {
          _serviceCode = 0; _serviceName = null; _serviceFee = 0.0;
	   }
        public Service(int code,string name,float fee)
        {
            _serviceCode = code; _serviceName = name; _serviceFee = fee;
        }
        public int ServiceCode { get {return _serviceCode;} set {_serviceCode = value;}}
        public string ServiceName { get { return _serviceName; } set { _serviceName = value; } }
        public float ServiceFee { get { return _serviceFee; } set { _serviceFee = value; } }
    }
}