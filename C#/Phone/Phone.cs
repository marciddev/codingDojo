using System;

namespace Phone
{
    public abstract class Phone {
        private string _versionNum;
        private int _batteryPercentage;
        private string _carrier;
        private string _ringTone;
        public string __versionNum {get{return _versionNum;}}
        public int __batteryPercentage {get {return _batteryPercentage; } }
        public string __carrier {get { return _carrier;}}
        public string __ringtone {get {return _ringTone;}}
        public Phone(string versionNumber, int batteryPercentage, string carrier, string ringTone) {
            _versionNum = versionNumber;
            _batteryPercentage = batteryPercentage;
            _carrier = carrier;
            _ringTone = ringTone;
        }
        public abstract void DisplayInfo();
    }
}
