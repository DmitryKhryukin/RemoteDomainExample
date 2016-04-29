using System;

namespace TestProxy
{
    public class TestProxy : MarshalByRefObject
    {
        private object _testInterfaceImplementation;
        private Type _type;

        public string ReturnString()
        {
            var methodinfo = _type.GetMethod("ReturnString");
            return (string)methodinfo.Invoke(_testInterfaceImplementation, null);
        }

        public void Connect(string type)
        {
            _type = Type.GetType(type);
            if (_type == null)
            {
                throw new Exception(string.Format("Cannot locate type {0}", type));
            }

            _testInterfaceImplementation = Activator.CreateInstance(_type);
        }
    }
}