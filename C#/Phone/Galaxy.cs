using System;

namespace Phone {
    public class Galaxy : Phone, IRingable {
        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringtone) : base(versionNumber, batteryPercentage, carrier, ringtone) {}
    public string Ring() {
        return __ringtone;
    }
    public string Unlock() {
        return "Phone has been unlocked!";
    }
    public override void DisplayInfo() {
        Console.WriteLine($"Version: {__versionNum}, battery: {__batteryPercentage}, carrier: {__carrier}, ringtone: {__ringtone}");
    }
    }
}