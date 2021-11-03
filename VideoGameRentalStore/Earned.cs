using System;
using System.Collections.Generic;
using System.IO;

namespace VideoGameRentalStore
{
    public class Earned
    {
        private List<double> _earnedList;
        public List<double> EarnedListObj
        {
            get
            {
                if (_earnedList == null)
                {
                    _earnedList = new List<double>();
                }
                return _earnedList;
            }
            set
            {
                _earnedList = value;
            }
        }
        public Earned()
        {

            FileStream fsEarned = new FileStream("EarnedTotal.txt", FileMode.OpenOrCreate, FileAccess.Read);
            fsEarned.Seek(0, SeekOrigin.Begin);
            StreamReader srEarned = new StreamReader(fsEarned);
            string strEarned = srEarned.ReadLine();
            while (!string.IsNullOrWhiteSpace(strEarned))
            {
                double strEarnedDouble = Double.Parse(strEarned);
                if (!EarnedListObj.Contains(strEarnedDouble))
                {
                    EarnedListObj.Add(strEarnedDouble);
                }
                strEarned = srEarned.ReadLine();
            }
            srEarned.Close();
            fsEarned.Close();
        }
        public void UpdateEarned()
        {
            FileStream fsEarned = new FileStream("EarnedTotal.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter swEarned = new StreamWriter(fsEarned);
            foreach (var earned in EarnedListObj)
            {
                swEarned.WriteLine(earned);
            }
            swEarned.Close();
            fsEarned.Close();
        }
    }
}
