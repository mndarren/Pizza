/*@Class: CSCU531
 *@Author: Zhao Xie
 *@Date:11/6/2014
 *@File: Service.cs
 *@Description: this class contains service info
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class Service
    {
        #region Private Members
        private int _serviceCode;
        private string _serviceName;
        private decimal _serviceFee;
        #endregion

        public Service (){}
	    
        public Service(int code,string name,decimal fee)
        {
            _serviceCode = code; _serviceName = name; _serviceFee = (decimal)fee;
        }
        public int ServiceCode { get {return _serviceCode;} set {_serviceCode = value;}}
        public string ServiceName { get { return _serviceName; } set { _serviceName = value; } }
        public decimal ServiceFee { get { return _serviceFee; } set { _serviceFee = value; } }
        public override string ToString()
        { 
           return "ServiceCode: "+_serviceCode+ "ServiceName: " + _serviceName + "ServiceFee: " + _serviceFee;
        }
    }
}