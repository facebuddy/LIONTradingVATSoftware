using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public static class SequentialNumber
    {
        private static int _currentNumber;

        static SequentialNumber()
        {
        }

        public static string GetNextNumber()
        {
            SequentialNumber._currentNumber++;
            return SequentialNumber._currentNumber.ToString();
        }
    }
}

