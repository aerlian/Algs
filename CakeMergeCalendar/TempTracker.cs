using System.Collections.Generic;

namespace CakeMergeCalendar
{
    class TempTracker
    {
        public static void TempTrackerMain()
        {
            var t = new TempTrackerImpl();

            t.Insert(5);
            t.Insert(100);
            t.Insert(100);
            t.Insert(2);
            System.Console.WriteLine($"Max {t.GetMax()}");


            System.Console.WriteLine($"Mean {t.GetMean()}");
            System.Console.WriteLine($"Mode {t.GetMode()}");

            t.Insert(2);
            t.Insert(2);
            t.Insert(2);
            System.Console.WriteLine($"Mode {t.GetMode()}");
        }
    }

    class TempTrackerImpl
    {
        private int _minTemp = int.MaxValue;
        private int _maxTemp = int.MinValue;
        private double _tempTotal;
        private int _modeValue;
        private int _modeCount;
        private int []_allTemps = new int[256];
        private int _tempCount;

        public TempTrackerImpl()
        {
            for(var i = 0; i < _allTemps.Length; i++)
            {
                _allTemps[i] = int.MinValue;
            }
        }

        public void Insert(int temp)
        {
            _tempTotal += temp;
            _tempCount += 1;

            if (temp > _maxTemp)
            {
                _maxTemp = temp;
            }

            if (temp < _minTemp)
            {
                _minTemp = temp;
            }

            if (_allTemps[temp] == int.MinValue)
            {
                _allTemps[temp] = 0;
            }

            _allTemps[temp] += 1;

            if (_allTemps[temp] > _modeCount)
            {
                _modeValue = temp;
                _modeCount = _allTemps[temp];
            }
        }

        public int GetMin()
        {
            return _minTemp;
        }

        public int GetMax()
        {
            return _maxTemp;
        }

        public double GetMean()
        {
            return _tempTotal / _tempCount;
        }

        public int GetMode()
        {
            return _modeValue;
        }
    }
}
