using System;
using System.Collections.Generic;

namespace Incapsulation.Failures
{

    public class Common
    {
        public static int IsFailureSerious(int failureType)
        {
            if (failureType%2==0) return 1;
            return 0;
        }


        public static bool Earlier(DateTime vDate, DateTime date)
        {
            return vDate < date;
        }
    }

    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes, 
            int[] deviceId, 
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            List<Device> newDevices = new List<Device>();
            int i = 0;
            foreach (var dev in devices)
            {
                newDevices.Add(new Device(
                    deviceId[i], 
                    devices[i]["DeviceId"].ToString(),
                    new DateTime((int)times[i][0], (int)times[i][1], (int)times[i][2]), 
                    new Failure((FailureType)failureTypes[i])));
                i++;
            }
            return FindDevicesFailedBeforeDate(
                new DateTime(year, month, day),
                newDevices.ToArray()
                );
        }
         
        public static List<string> FindDevicesFailedBeforeDate(
            DateTime date,
            Device[] devices)
        {
            var problematicDevices = new List<string>();
            foreach (var device in devices)
            {
                if (device.Failure.IsFailureSerious() && Common.Earlier(device.Vdate, date))
                    problematicDevices.Add(device.Name);
            }
            return problematicDevices;
        }
    }

    public class Device
    {
        public Device(int id, string name, DateTime vdate, Failure failure)
        {
            Id = id;
            Name = name;
            Vdate = vdate;
            Failure = failure;
        }

        public int Id { get; }

        public string Name { get;}

        public DateTime Vdate { get; }

        public readonly Failure Failure;
    }

    public class Failure
    {
        public Failure(FailureType failureType)
        {
            FailureType = failureType;
        }

        public FailureType FailureType { get; }

        public bool IsFailureSerious()
        {
            return (int)FailureType % 2 == 0;
        }
    }

    public enum FailureType
    {
        unexpectedShutdown, 
        shortNonResponding,
        hardwareFailures, 
        connectionProblems
    }
}
