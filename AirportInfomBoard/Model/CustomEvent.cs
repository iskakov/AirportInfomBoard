using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportInfomBoard.Model
{
    public static class CustomEvent
    {
        public delegate void EndImitationDelegate();
        private static event EndImitationDelegate endImitationDelegate;

        public static void SignOrCloseDelegate(EndImitationDelegate close, bool isNotClose)
        {
            if (isNotClose)
            {
                endImitationDelegate += close;

            }
            else
            {
                endImitationDelegate -= close;
            }
        }

        public static void RaiseDelegate()
        {
            if (endImitationDelegate != null)
            {
                endImitationDelegate();
            }
        }
        
    }
}
