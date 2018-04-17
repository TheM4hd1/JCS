using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCS_1._0.Utilities
{
    // Component Version Detector
    class VersionDetector
    {
        private string ComponentVersion = "N/A";
        readonly string[] Versions = {"1","1.5","1.6","1.7",
                             "2.5",
                             "3.0","3.1","3.2","3.3","3.4","3.5","3.6","3.7","3.8"};

        readonly string[] DateReleased = {"2005-09-22","2008-01-22","2011-01-10","2011-07-19",
                                          "2012-01-24",
                                          "2012-09-27","2013-04-24","2013-11-06","2014-04-30","2015-02-24","2016-03-21","2016-07-12","2017-04-25","2017-09-19"};

        readonly string[] dateSupported = {"2009-07-22","2012-12-01","2011-08-19","2012-02-24",
                                          "2014-12-31",
                                          "2013-04-01","2013-10-01","2014-10-01","2015-02-01","2016-03-01","2016-07-01","2017-04-01","2018-04-25","2019-09-19"}; //unkown for 3.7 - 3.8
        public string GetVersion(string date)
        {
            try
            {
                DateTime d = Convert.ToDateTime(date);

                for (int i = 0; i < Versions.Length; i++)
                {
                    if (d.CompareTo(Convert.ToDateTime(DateReleased[i])) >= 0 && d.CompareTo(Convert.ToDateTime(dateSupported[i])) <= 0)
                    {
                        ComponentVersion = Versions[i];
                    }
                }

                return ComponentVersion;
            }
            catch (FormatException)
            {
                return ComponentVersion;
            }
        }
    }
}

//1 	January 	31 days
//2 	February 	28 days, 29 in leap years
//3 	March 	31 days
//4 	April 	30 days
//5 	May 	31 days
//6 	June 	30 days
//7 	July 	31 days
//8 	August 	31 days
//9 	September 	30 days
//10 	October 	31 days
//11 	November 	30 days
//12 	December