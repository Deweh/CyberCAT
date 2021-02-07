using System;

namespace CyberCAT.Core.Classes.Mapping
{
    public class WrongDefaultValueEventArgs : EventArgs
    {
        public string ClassName { get; set; }
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public bool Ignore { get; set; }

        public WrongDefaultValueEventArgs(string className, string propertyName, object value)
        {
            ClassName = className;
            PropertyName = propertyName;
            Value = value;
        }
    }

    public class SaveProgressChangedEventArgs : EventArgs
    {
        public int CurrentProgress { get; set; }
        public int Maximum { get; set; }
        public string NodeName { get; set; }

        public SaveProgressChangedEventArgs(int cur, int max, string name = "")
        {
            CurrentProgress = cur;
            Maximum = max;
            NodeName = name;
        }
    }
}